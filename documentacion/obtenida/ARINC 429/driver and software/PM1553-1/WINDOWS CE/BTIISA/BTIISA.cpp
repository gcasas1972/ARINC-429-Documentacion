
#include "stdafx.h"

/**
*
*  Define miscellaneous constants
*
**/

#define MAX_NUM_CARDS 32

/**
*
*  Define IO control codes
*
**/

#define BTI_ISA_DEVICE 0x00009000

#define FUNC_PORT_RD    0x900
#define FUNC_PORT_WR    0x901
#define FUNC_CONFIG_RD  0x902
#define FUNC_CONFIG_WR  0x903
#define FUNC_INT_INST   0x904
#define FUNC_INT_UNINST 0x905

#define IOCTL_PORT_RD    CTL_CODE(BTI_ISA_DEVICE,FUNC_PORT_RD,   METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_PORT_WR    CTL_CODE(BTI_ISA_DEVICE,FUNC_PORT_WR,   METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_CONFIG_RD  CTL_CODE(BTI_ISA_DEVICE,FUNC_CONFIG_RD, METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_CONFIG_WR  CTL_CODE(BTI_ISA_DEVICE,FUNC_CONFIG_WR, METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_INT_INST   CTL_CODE(BTI_ISA_DEVICE,FUNC_INT_INST,  METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_INT_UNINST CTL_CODE(BTI_ISA_DEVICE,FUNC_INT_UNINST,METHOD_BUFFERED,FILE_ANY_ACCESS)

/**
*
*  IO control arguments
*
**/

typedef struct
{
	INT portcount;
	INT portnum;
	INT portsize;
	INT irqcount;
	INT irqnum;
	INT intnum;
	DWORD offval;
	DWORD dataval;
	DWORD sizeval;
	HANDLE hEvent;
} IOCTLARGS,*LPIOCTLARGS;

/**
*
*  Card structures
*
**/

typedef struct
{
	BOOL inuse;
	INT portcount;
	INT portnum;
	INT portsize;
	INT irqcount;
	INT irqnum;
	INT intnum;
	PUCHAR portptr;
	HANDLE hEvent;
} ISACARD,*LPISACARD;

ISACARD IsaCards[MAX_NUM_CARDS];

/**
*
*  Prototypes
*
**/

DWORD BTI_Init(LPCTSTR pContext,LPCVOID lpvBusContext);
BOOL  BTI_Deinit(DWORD hDeviceContext);
DWORD BTI_Open(DWORD hDeviceContext,DWORD AccessCode,DWORD ShareMode);
BOOL  BTI_Close(DWORD hOpenContext);
DWORD BTI_ThreadProc(LPVOID pParam);
BOOL  BTI_IOControl(DWORD hOpenContext,DWORD dwCode,PBYTE pBufIn,DWORD dwLenIn,PBYTE pBufOut,DWORD dwLenOut,PDWORD pdwActualOut);
VOID  BTI_PowerUp(DWORD hDeviceContext);
VOID  BTI_PowerDown(DWORD hDeviceContext);
DWORD BTI_Read(DWORD hOpenContext,LPVOID pBuffer,DWORD Count);
DWORD BTI_Write(DWORD hOpenContext,LPCVOID pBuffer,DWORD Count);
DWORD BTI_Seek(DWORD hOpenContext,long Amount,WORD Type);

VOID OutputDebugString1(LPCWSTR lpOutputString,DWORD dwValue);

// ----------------------------------------------------

BOOL APIENTRY DllMain(HANDLE hModule,DWORD ul_reason_for_call,LPVOID lpReserved)
{
	switch(ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
			OutputDebugString(L"BTIISA - DllMain - DLL_PROCESS_ATTACH\n");
			memset(&IsaCards,0,sizeof(IsaCards));
			DisableThreadLibraryCalls((HMODULE)hModule);
			break;
		case DLL_PROCESS_DETACH:
			OutputDebugString(L"BTIISA - DllMain - DLL_PROCESS_DETACH\n");
			break;
		case DLL_THREAD_ATTACH:
			OutputDebugString(L"BTIISA - DllMain - DLL_THREAD_ATTACH\n");
			break;
		case DLL_THREAD_DETACH:
			OutputDebugString(L"BTIISA - DllMain - DLL_THREAD_DETACH\n");
			break;
		default:
			OutputDebugString(L"BTIISA - DllMain - DLL_THREAD_DETACH\n");
			break;
	}
	return(TRUE);
}

DWORD BTI_Init(LPCTSTR pContext,LPCVOID lpvBusContext)
{
	OutputDebugString(L"BTIISA - BTI_Init - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Init - pContext=%s\n",(DWORD)pContext);
	OutputDebugString1(L"BTIISA - BTI_Init - lpvBusContext=%p\n",(DWORD)lpvBusContext);

 	OutputDebugString(L"BTIISA - BTI_Init - Leaving\n");

	return(0x4254);
}

BOOL BTI_Deinit(DWORD hDeviceContext)
{
	OutputDebugString(L"BTIISA - BTI_Deinit - Entering\n");
	OutputDebugString(L"BTIISA - BTI_Deinit - Leaving\n");
	return(TRUE);
}

//
//	Driver Open
//

DWORD BTI_Open(DWORD hDeviceContext,DWORD AccessCode,DWORD ShareMode)
{
	OutputDebugString(L"BTIISA - BTI_Open - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Open - hDeviceContext=%08X",(DWORD)hDeviceContext);

	for (INT j=0;j<MAX_NUM_CARDS;++j)
	{
		if (!IsaCards[j].inuse)
		{
			LPISACARD pCard = &IsaCards[j];

			pCard->inuse = TRUE;

		 	OutputDebugString1(L"BTIISA - BTI_Open - Leaving with value %p\n",(DWORD)pCard);

			return((DWORD)pCard);
		}
	}

	OutputDebugString(L"BTIISA - BTI_Open - Leaving with error\n");

	return(0);
}

BOOL BTI_Close(DWORD hOpenContext)
{
	LPISACARD pCard = (LPISACARD)hOpenContext;

	OutputDebugString(L"BTIISA - BTI_Close - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Close - hOpenContext=%p",(DWORD)pCard);

	if (pCard->irqcount)
	{
		KernelIoControl(IOCTL_HAL_RELEASE_SYSINTR,&pCard->intnum,sizeof(UINT32),NULL,0,NULL);
	}

	if (pCard->portptr)
	{
		MmUnmapIoSpace(pCard->portptr,pCard->portsize);
		pCard->portptr=NULL;
	}

	pCard->inuse = FALSE;

	OutputDebugString(L"BTIISA - BTI_Close - Leaving\n");
	
	return(TRUE);
}

BOOL BTI_IOControl(DWORD hOpenContext,DWORD dwCode,PBYTE pBufIn,DWORD dwLenIn,PBYTE pBufOut,DWORD dwLenOut,PDWORD pdwActualOut)
{
	LPISACARD pCard = (LPISACARD)hOpenContext;

//	OutputDebugString(L"BTIISA - BTI_IOControl - Entering\n");
//	OutputDebugString1(L"BTIISA - BTI_IOControl - hOpenContext=%08X\n",hOpenContext);

//	OutputDebugString1(L"BTIISA - BTI_IOControl - portcount=%04X\n", pCard->portcount);
//	OutputDebugString1(L"BTIISA - BTI_IOControl - portnum=%04X\n",   pCard->portnum);
//	OutputDebugString1(L"BTIISA - BTI_IOControl - irqcount=%04X\n",  pCard->irqcount);
//	OutputDebugString1(L"BTIISA - BTI_IOControl - irqnum=%04X\n",    pCard->irqnum);

	switch(dwCode)
	{
		case IOCTL_PORT_RD:
		{
//			OutputDebugString(L"BTIISA - BTI_IOControl - PORTRD\n");
			LPIOCTLARGS pInArgs  = (LPIOCTLARGS)pBufIn;
			LPIOCTLARGS pOutArgs = (LPIOCTLARGS)pBufOut;

//			OutputDebugString1(L"BTIISA - BTI_IOControl - offval=%04X\n", pInArgs->offval);
//			OutputDebugString1(L"BTIISA - BTI_IOControl - dataval=%08X\n",pInArgs->dataval);
//			OutputDebugString1(L"BTIISA - BTI_IOControl - sizeval=%u\n",  pInArgs->sizeval);

			switch(pInArgs->sizeval)
			{
				case 1: pOutArgs->dataval = READ_PORT_UCHAR ((PUCHAR) (pCard->portptr+pInArgs->offval)); break;
				case 2: pOutArgs->dataval = READ_PORT_USHORT((PUSHORT)(pCard->portptr+pInArgs->offval)); break;
				case 4: pOutArgs->dataval = READ_PORT_ULONG ((PULONG) (pCard->portptr+pInArgs->offval)); break;
				default:
					OutputDebugString(L"BTIISA - BTI_IOControl - Leaving with bad size value\n");
					return(FALSE);
			}

			break;
		}

		case IOCTL_PORT_WR:
		{
//			OutputDebugString(L"BTIISA - BTI_IOControl - PORTWR\n");
			LPIOCTLARGS pInArgs = (LPIOCTLARGS)pBufIn;

//			OutputDebugString1(L"BTIISA - BTI_IOControl - offval=%04X\n", pInArgs->offval);
//			OutputDebugString1(L"BTIISA - BTI_IOControl - dataval=%08X\n",pInArgs->dataval);
//			OutputDebugString1(L"BTIISA - BTI_IOControl - sizeval=%u\n",  pInArgs->sizeval);

			switch(pInArgs->sizeval)
			{
				case 1: WRITE_PORT_UCHAR ((PUCHAR) (pCard->portptr+pInArgs->offval),(UCHAR) pInArgs->dataval); break;
				case 2: WRITE_PORT_USHORT((PUSHORT)(pCard->portptr+pInArgs->offval),(USHORT)pInArgs->dataval); break;
				case 4: WRITE_PORT_ULONG ((PULONG) (pCard->portptr+pInArgs->offval),(ULONG) pInArgs->dataval); break;
				default:
					OutputDebugString(L"BTIISA - BTI_IOControl - Leaving with bad size value\n");
					return(FALSE);
			}

			break;
		}

		case IOCTL_CONFIG_WR:
		{
			OutputDebugString(L"BTIISA - BTI_IOControl - CONFIGWR\n");
			LPIOCTLARGS pInArgs = (LPIOCTLARGS)pBufIn;

			pCard->portcount = pInArgs->portcount;
			pCard->portnum   = pInArgs->portnum;
			pCard->portsize  = pInArgs->portsize;
			pCard->irqcount  = pInArgs->irqcount;
			pCard->irqnum    = pInArgs->irqnum;

			if (pCard->irqcount)
			{
				BOOL bResult = KernelIoControl(IOCTL_HAL_TRANSLATE_IRQ,&pCard->irqnum,sizeof(UINT32),&pCard->intnum,sizeof(UINT32),NULL);
				if (!bResult)
				{
					OutputDebugString(L"BTIISA - BTI_IOControl - Unable to translate IRQ\n");
					return(FALSE);
				}
			}

			PHYSICAL_ADDRESS portaddr;
			portaddr.HighPart = 0;
			portaddr.LowPart  = pCard->portnum;

			pCard->portptr = (PBYTE)MmMapIoSpace(portaddr,pCard->portsize,FALSE);

			if (!pCard->portptr)
			{
				OutputDebugString(L"BTIISA - BTI_IOControl - Unable map IO space\n");
				return(FALSE);
			}

			OutputDebugString1(L"BTIISA - BTI_IOControl - portcount=%u\n",pInArgs->portcount);
			OutputDebugString1(L"BTIISA - BTI_IOControl - portnum=%04X\n",pInArgs->portnum);
			OutputDebugString1(L"BTIISA - BTI_IOControl - portsize=%u\n", pInArgs->portsize);
			OutputDebugString1(L"BTIISA - BTI_IOControl - irqcount=%u\n", pInArgs->irqcount);
			OutputDebugString1(L"BTIISA - BTI_IOControl - irqnum=%u\n",   pInArgs->irqnum);
			OutputDebugString1(L"BTIISA - BTI_IOControl - intnum=%u\n",   pCard->intnum);

			break;
		}

		case IOCTL_CONFIG_RD:
		{
			OutputDebugString(L"BTIISA - BTI_IOControl - CONFIGRD\n");
			LPIOCTLARGS pOutArgs = (LPIOCTLARGS)pBufOut;

			pOutArgs->portcount = pCard->portcount;
			pOutArgs->portnum   = pCard->portnum;
			pOutArgs->irqcount  = pCard->irqcount;
			pOutArgs->irqnum    = pCard->irqnum;
			pOutArgs->intnum    = pCard->intnum;

			break;
		}

		case IOCTL_INT_INST:
		{
			BOOL bResult;

			OutputDebugString(L"BTIISA - BTI_IOControl - INTINST\n");

			if (!pCard->irqcount)
			{
				OutputDebugString(L"BTIISA - BTI_IOControl - No IRQ has been specified\n");
				return(FALSE);
			}

			LPIOCTLARGS pInArgs = (LPIOCTLARGS)pBufIn;

			pCard->hEvent = pInArgs->hEvent;

			bResult = InterruptInitialize(pCard->intnum,pCard->hEvent,NULL,0);

			if (!bResult)
			{
				OutputDebugString(L"BTIISA - BTI_IOControl - Unable to initialize interrupt\n");
				return(FALSE);
			}

			break;
		}

		case IOCTL_INT_UNINST:
		{
			OutputDebugString(L"BTIISA - BTI_IOControl - INTUNINST\n");

			if (!pCard->irqcount)
			{
				OutputDebugString(L"BTIISA - BTI_IOControl - No IRQ has been specified\n");
				return(FALSE);
			}

			InterruptDisable(pCard->intnum);

			break;
		}

		default:
		{
			OutputDebugString1(L"BTIISA - BTI_IOControl - Unknown IOCTL dwCode=%04X\n",dwCode);

			break;
		}
	}

//	OutputDebugString(L"BTIISA - BTI_IOControl - Leaving\n");
	return(TRUE);
}

void BTI_PowerUp(DWORD hDeviceContext)
{
	OutputDebugString(L"BTIISA - BTI_PowerUp - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_PowerUp - hDeviceContext=%08X",hDeviceContext);

	OutputDebugString(L"BTIISA - BTI_PowerUp - Leaving\n");
}

void BTI_PowerDown(DWORD hDeviceContext)
{
	OutputDebugString(L"BTIISA - BTI_PowerDown - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_PowerDown - hDeviceContext=%08X\n",hDeviceContext);

	OutputDebugString(L"BTIISA - BTI_PowerDown - Leaving\n");
}

DWORD BTI_Read(DWORD hOpenContext,LPVOID pBuffer,DWORD Count)
{
	DWORD dwRetCount=0xffff;      // default to error

	OutputDebugString(L"BTIISA - BTI_Read - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Read - hOpenContext=%08X\n",hOpenContext);

	OutputDebugString(L"BTIISA - BTI_Read - Leaving\n");

	return(dwRetCount);
}

DWORD BTI_Write(DWORD hOpenContext,LPCVOID pBuffer,DWORD Count)
{
	OutputDebugString(L"BTIISA - BTI_Write - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Write - hOpenContext=%08X\n",hOpenContext);

	OutputDebugString(L"BTIISA - BTI_Write - Leaving\n");

	return(Count);
}

DWORD BTI_Seek(DWORD hOpenContext,long Amount,WORD Type)
{
	OutputDebugString(L"BTIISA - BTI_Seek - Entering\n");
	OutputDebugString1(L"BTIISA - BTI_Seek - hOpenContext=%08X\n",hOpenContext);

	OutputDebugString(L"BTIISA - BTI_Seek - Leaving\n");

	return(0);
}

VOID OutputDebugString1(LPCWSTR lpOutputString,DWORD dwValue)
{
	TCHAR tcTemp[256];
	wsprintf(tcTemp,lpOutputString,dwValue);
	OutputDebugString(tcTemp);
}
