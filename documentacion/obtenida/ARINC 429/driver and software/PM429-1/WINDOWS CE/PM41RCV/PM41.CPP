/**
*
*  PM429-1 C/C++ DRIVER  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41.CPP --  PM1553-1 Driver Source File.
*
**/

/**
*
*  Function names and descriptions:
*
*   Card open/close functions
*
*    BOOL   PM41_CardOpen()         -- Opens access to the card and passes back a handle
*    VOID   PM41_CardClose()        -- Closes access to the card
*
*  Utility functions
*
*    INT    PM41_UtilGetPage()      -- Extracts the page value from a PM429-1 register #define
*    USHORT PM41_UtilGetReg()       -- Extracts the register value from a PM429-1 register #define
*    UINT   PM41_UtilGetMsgData()   -- Extracts the original data from a received dataword
*    BOOL   PM41_UtilGetParity()    -- Extracts the original parity bit value from a received dataword.
*    UINT   PM41_UtilScrambleData() -- Simulates data scramble mode of PM429-1
*    UCHAR  PM41_UtilReverseLabel() -- Formats a label into reverse bit order
*
*  Host I/O functions
*
*    BOOL   PM41_PortWrB()          -- Write 1 byte of data to the specified I/O port
*    BOOL   PM41_PortRdB()          -- Reads 1 byte of data from the specified I/O port
*    BOOL   PM41_PortWrW()          -- Writes a 16-bit value to the specified I/O port
*    BOOL   PM41_PortRdW()          -- Reads a 16-bit value from the specified I/O port
*
*  PM41 Register functions
*
*    VOID   PM41_PageWr()           -- Writes a value to the PM429-1 PAGE register.
*    INT    PM41_PageRd()           -- Reads a value from the PM429-1 PAGE register.
*    VOID   PM41_RegWr()            -- Writes a value to the specified PM429-1 register.
*    USHORT PM41_RegRd()            -- Reads a value from the specified PM429-1 register.
*    VOID   PM41_RegClr()           -- Clears (wipes w/ zeros) the specified  PM41 register.
*    VOID   PM41_RegBitSet()        -- Reads the value from a PM41 register, ORs in data, and writes it back.
*    VOID   PM41_RegBitClr()        -- Clears the specified flags from the specified PM41 register.
*
*  PM41 Card functions
*
*    VOID   PM41_CardReset()        -- Resets specified PM429-1.
*    BOOL   PM41_IsCard()           -- Checks if specified PM429-1 exists.
*    INT    PM41_SelfTest()         -- Performs hardware test of specified PM429-1.
*
*  PM41 Interrupt/SRQ Functions
*
*    BOOL   PM41_SRQIsSet()         -- Checks for specified SRQ(s) from the PM429-1
*    VOID   PM41_SRQClr()           -- Clears the specified SRQ bit(s)
*    VOID   PM41_SRQConfig()        -- Configures ARINC SRQ on specified channel
* 
*  PM41 Channel functions
*
*    BOOL   PM41_IsChan()           -- Checks if specified channel is present
*    BOOL   PM41_ChIsRcv()          -- Checks if specified channel is receive channel
*    BOOL   PM41_ChIsXmt()          -- Checks if specified channel is transmit channel
*    VOID   PM41_ChDataWr()         -- Writes 1 dataword to specified ARINC 429 TCH. 
*    UINT   PM41_ChDataRd()         -- Reads 1 dataword from specified ARINC 429 RCH.
*    USHORT PM41_ChStatRd()         -- Reads Status register from specified channel
*    VOID   PM41_ChGapWr()          -- Writes gap value to specified TCH
*    USHORT PM41_ChGapRd()          -- Reads gap value from specified TCH
*    BOOL   PM41_IsChGapDone()      -- Checks if the gap timer has counted down
*    VOID   PM41_ChClear()          -- Clears receive buffer of specified channel
*    VOID   PM41_ChConfig()         -- Sets channel options for specified channel
* 
*  PM41 Filter functions
*
*    VOID   PM41_FilterSDISet()     -- Sets SDI filter for specified channel
*    VOID   PM41_FilterSDIClear()   -- Clears SDI filter for specified channel
*    VOID   PM41_FilterLabelSet()   -- Sets label filter for specified channel
*    VOID   PM41_FilterLabelClr()   -- Disables label filter for specified channel
*    PUCHAR PM41_FilterLabelRead()  -- Reads label filter for specified channel
* 
*  PM41 LED functions
*
*    BOOL   PM41_IsLEDSet()         -- Reads status of external LED
*    VOID   PM41_LEDWr()            -- Turns LED on or off
*    VOID   PM41_LEDBlink()         -- Blinks user LED once (on, off)
*
*  PM41 Timer functions
* 
*    VOID   PM41_TimerConfig()      -- Configures on-board timer
*    VOID   PM41_TimerStart()       -- Starts on-board timer
*    VOID   PM41_TimerStop()        -- Stops on-board timer
*    VOID   PM41_TimerClr()         -- Stops and clears on-board timer
*    UINT   PM41_TimerRd()          -- Reads on-board timer
*    VOID   PM41_TimerWr()          -- Writes value to on-board timer
*    VOID   PM41_TimerSRQEn()       -- Enables SRQs on timer
*    VOID   PM41_TimerSRQDis()      -- Disables SRQs on timer
* 
*  PM41 DIN functions
* 
*    BOOL   PM41_IsDINSet()         -- Reads value of specified DIN
*    VOID   PM41_DINConfig()        -- Configures digital inputs
*    USHORT PM41_DINSRQRd()         -- Reads value of DIN SRQ configuration register
*    VOID   PM41_DINSRQSet()        -- Sets digital input SRQ configuration
* 
*  PM41 DOUT functions
* 
*    VOID   PM41_DOUTWr()           -- Sets specified DOUT
*    BOOL   PM41_DOUTIsSet()        -- Reads specified DOUT
*    VOID   PM41_DOUTClr()          -- Clears specified DOUT
*
*  PM41 Interrupt functions
*
*    BOOL   PM41_IntInstall()       -- Installs an interrupt handler
*    VOID   PM41_IntUninstall()     -- Uninstalls the interrupt handler
*    VOID   PM41_IntEnable()        -- Enables card interrupts to host
*    VOID   PM41_IntDisable()       -- Disables card interrupts to host
*
**/

/**
*
*  PM429-1 include file
*
**/

#include "stdafx.h"

#include "pm41.h"

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
*  Define IO control codes
*
**/

#define BALLARD_TECH_DEVICE 0x00009000

#define FUNC_PORT_RD    0x900
#define FUNC_PORT_WR    0x901
#define FUNC_CONFIG_RD  0x902
#define FUNC_CONFIG_WR  0x903
#define FUNC_INT_INST   0x904
#define FUNC_INT_UNINST 0x905

#define IOCTL_PORT_RD    CTL_CODE(BALLARD_TECH_DEVICE,FUNC_PORT_RD,   METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_PORT_WR    CTL_CODE(BALLARD_TECH_DEVICE,FUNC_PORT_WR,   METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_CONFIG_RD  CTL_CODE(BALLARD_TECH_DEVICE,FUNC_CONFIG_RD, METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_CONFIG_WR  CTL_CODE(BALLARD_TECH_DEVICE,FUNC_CONFIG_WR, METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_INT_INST   CTL_CODE(BALLARD_TECH_DEVICE,FUNC_INT_INST,  METHOD_BUFFERED,FILE_ANY_ACCESS)
#define IOCTL_INT_UNINST CTL_CODE(BALLARD_TECH_DEVICE,FUNC_INT_UNINST,METHOD_BUFFERED,FILE_ANY_ACCESS)

/**
*
*  Card open/close functions
*
**/

BOOL PM41_CardOpen(HANDLE* handleptr,INT portnum,INT irqnum)
{
	HANDLE handleval;
	DWORD dwBytesOut;

	//
	//	Verify pointer
	//

	if (!handleptr) return(FALSE);

	//
	//  Verify IO address and IRQ are valid
	//

	if ((portnum < PORTNUM_MIN) || (portnum > PORTNUM_MAX)) return(FALSE);	//Outside valid IO range
	if (portnum & 0x00F) return(FALSE);										//Does not end in 0

	if (irqnum <= 12)			//Only IRQ 3,4,5,7,9,10,11,12 are valid; IRQ 0 skips interrupt tests
	{
		if (irqnum==1 || irqnum==2 || irqnum==6 ||irqnum==8)
		{
			return(FALSE);
		}
	}
	else
	{
		return(FALSE);
	}

	//
	//	Cook up device string and open it
	//

	handleval = CreateFile(L"BTI1:",GENERIC_READ+GENERIC_WRITE,0,NULL,OPEN_EXISTING,0,0);
	if (INVALID_HANDLE_VALUE==handleval) return(FALSE);

	//
	//	Config device
	//

	IOCTLARGS Args;
	Args.portcount = 1;
	Args.portnum   = portnum;
	Args.portsize  = 16;
	Args.irqcount  = (irqnum) ? 1:0;
	Args.irqnum    = irqnum;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_CONFIG_WR,
									&Args,sizeof(Args),
									NULL,0,
									&dwBytesOut,
									NULL);

	if (!bResult)
	{
		CloseHandle(handleval);
		return(FALSE);
	}

	//
	//	Probe for card
	//

	if (!PM41_IsCard(handleval))
	{
		PM41_CardClose(handleval);
		return(FALSE);
	}

	*handleptr = handleval;				//Pass back index as handle

	return(TRUE);
}

VOID PM41_CardClose(HANDLE handleval)
{
	if (handleval==INVALID_HANDLE_VALUE) return;

	CloseHandle(handleval);
}

/**
*
*  Utility functions
*
**/

/**
*
*  PM41_UtilGetPage()
*  Extracts the page value from a PM429-1 Register/Page #define.
*  Arguments:
*    regval: value to process
*  Returns: Page value
*  Warnings: None
*
**/

INT PM41_UtilGetPage(USHORT regval)
{
	return((regval & 0xF0) >> 4);
}

/**
*
*  PM41_UtilGetReg()
*  Extracts the register value from a PM429-1 Register/Page #define.
*  Arguments:
*    regval: value to process
*  Returns: Register value
*  Warnings: None
*
**/

USHORT PM41_UtilGetReg(USHORT regval)
{
	return(regval & 0x0F);
}

/**
*
*  PM41_UtilGetMsgData()
*  Extracts the original data from a received dataword
*  Arguments:
*    data: data to process
*  Returns:  32 bit dataword
*  Warnings: None
*
**/

UINT PM41_UtilGetMsgData(UINT data)
{
	if (PM41_UtilGetParity(data))										//If odd parity...
	{
		return(data & 0x7FFFFFFF);										//Reset 32nd bit
	}
	
	return(data | 0x80000000);											//Set 32nd bit
}

/**
*
*  PM41_UtilGetParity()
*  Extracts the original parity bit value from a received dataword.
*  Arguments:
*    data: data to process
*  Returns:  TRUE if odd parity, FALSE if even
*  Warnings: None
*
**/

BOOL PM41_UtilGetParity(UINT data)
{       
	UINT high_w;														//High half of ARINC dataword
	UINT low_w;															//Low half of ARINC dataword
	USHORT bits;														//Variable for databits
	UINT mask;															//Bitmask
	BOOL count = FALSE;													//Odd/even

	high_w = (data>>16) & 0x0000FFFF;									//Filter for High word	
	low_w  = (data>> 0) & 0x0000FFFF;									//Filter for Low word

	for (bits=0; bits<=16; bits++)										//Loop through both halves of ARINC word
	{
		mask = 1<<bits;													//Set mask to current bit position		

		if (mask & high_w)												//Check for a '1' bit
		{
			count = !count;												//Swap count
		}

		if (mask & low_w)												//Check for a '1' bit
		{
			count = !count;												//Swap count
		}
	}

	return(count);
}

/**
*
*  PM41_UtilScrambleData()
*  Simulates data scramble mode of PM429-1
*  Arguments:
*    data: data to process
*  Returns:  32 bit scrambled dataword
*  Warnings: None
*
**/

UINT PM41_UtilScrambleData(UINT data)
{
	UINT par;
	UINT ssm;
	UINT sdi;
	UINT label;

	par = data & 0x80000000;											//Get parity
	ssm = data & 0x60000000;											//Get ssm
	sdi = data & 0x00000300;											//Get data

	label = PM41_UtilReverseLabel((UCHAR)(data & 0x000000FF));			//Get label
	
	data = data & 0x1FFFFC00;											//Mask off data

	data = data << 3;
	par = par >> 23;
	ssm = ssm >> 20;
	sdi = sdi << 3;

	return(label | par | ssm | sdi | data);
}

/**
*
*  PM41_UtilReverseLabel()
*  Formats a label into reverse bit order
*  Arguments:
*    label: data to process
*  Returns:  reversed label
*  Warnings: None
*
**/

UCHAR PM41_UtilReverseLabel(UCHAR label)
{
	USHORT newlabel;													//Holds label being processed
	USHORT count;														//Position counter
	UINT bitmask;														//Bitmask of old data

	newlabel = (label << 8);											//Shift old data to upper byte
	count = 1;															//Init count

	for (bitmask=0x0100;bitmask<=0x8000;bitmask=(bitmask<<1))			//Loop through label bits
	{
		newlabel |= ((newlabel & bitmask) >> count);					//Get label and shift to new position
		count    += 2;													//Increment position counter
	}

	return((UCHAR)(newlabel & 0x00FF));									//Return new label data
}

/**
*
*  Host I/O functions
*
**/

/**
*
*  PM41_PortWrB()
*  Write 1 byte of data to the specified I/O port
*  Arguments:
*    data: data to write
*    offset: port offset to write to
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_PortWrB(UCHAR data,INT offset,HANDLE handleval)
{
	DWORD dwBytesOut;
	
	if (handleval==INVALID_HANDLE_VALUE) return;

	IOCTLARGS Args;
	Args.offval  = offset;
	Args.dataval = data;
	Args.sizeval = 1;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_PORT_WR,
									&Args,sizeof(Args),
									NULL,0,
									&dwBytesOut,
									NULL);
}

/**
*
*  PM41_PortRdB()
*  Reads 1 byte of data from the specified I/O port
*  Arguments:
*    offset: port offset to read from
*    handleval: card handle
*  Returns:  Data read
*  Warnings: None
*
**/

UCHAR PM41_PortRdB(INT offset,HANDLE handleval)
{
	DWORD dwBytesOut;

	if (handleval==INVALID_HANDLE_VALUE) return(0);

	IOCTLARGS Args;
	Args.offval  = offset;
	Args.sizeval = 1;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_PORT_RD,
									&Args,sizeof(Args),
									&Args,sizeof(Args),
									&dwBytesOut,
									NULL);

	return((BYTE)Args.dataval);
}

/**
*
*  PM41_PortWrW()
*  Writes a 16-bit value to the specified I/O port.
*  Arguments:
*    data: data to write
*    offset: port offset to write to
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_PortWrW(USHORT data,INT offset,HANDLE handleval)
{
	DWORD dwBytesOut;
	
	if (handleval==INVALID_HANDLE_VALUE) return;

	IOCTLARGS Args;
	Args.offval  = offset;
	Args.dataval = data;
	Args.sizeval = 2;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_PORT_WR,
									&Args,sizeof(Args),
									NULL,0,
									&dwBytesOut,
									NULL);
}

/**
*
*  PM41_PortRdW()
*  Reads a 16-bit value from the specified I/O port.
*  Arguments:
*    offset: port offset to read from
*    handleval: card handle
*  Returns:  data read
*  Warnings: None
*
**/

USHORT PM41_PortRdW(INT offset,HANDLE handleval)
{
	DWORD dwBytesOut;

	if (handleval==INVALID_HANDLE_VALUE) return(0);

	IOCTLARGS Args;
	Args.offval  = offset;
	Args.sizeval = 2;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_PORT_RD,
									&Args,sizeof(Args),
									&Args,sizeof(Args),
									&dwBytesOut,
									NULL);

	return((USHORT)Args.dataval);
}

/**
*
*  PM41 Register functions
*
**/

/**
*
*  PM41_PageWr()
*  Writes a value to the PM429-1 PAGE register.
*  Arguments:
*    page: PAGE register value
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_PageWr(INT page,HANDLE handleval)
{
	PM41_PortWrW((USHORT)page,REG_PAGE,handleval);						//Set PAGE register to specified page
}

/**
*
*  PM41_PageRd()
*  Reads a value from the PM429-1 PAGE register.
*  Arguments:
*    page: PAGE register value
*    handleval: card handle
*  Returns:  Value of PAGE register
*  Warnings: None
*
**/

USHORT PM41_PageRd(HANDLE handleval)
{
	return(PM41_PortRdW(REG_PAGE,handleval));
}

/**
*
*  PM41_RegWr()
*  Writes a value to the specified PM429-1 register.
*  Arguments:
*    data: Data to write
*    reg:  PM41 register
*    handleval: card handle
*  Returns:  None
*  Warnings: This function cannot be used to write a value to the page register -- use PM41_PageWr().
*
**/

VOID PM41_RegWr(USHORT data,USHORT reg,HANDLE handleval)
{
	PM41_PageWr(PM41_UtilGetPage(reg),handleval);						//Set page
	PM41_PortWrW(data,PM41_UtilGetReg(reg),handleval);					//Write data
}

/**
*
*  PM41_RegRd()
*  Reads a value from the specified PM429-1 register.
*  Arguments: 
*    reg:  PM41 register
*    handleval: card handle
*  Returns:  None
*  Warnings: This function cannot be used to read a value from the PAGE register -- use PM41_PageRd()
*
**/

USHORT PM41_RegRd(USHORT reg,HANDLE handleval)
{
	PM41_PageWr(PM41_UtilGetPage(reg),handleval);						//Set page
	return(PM41_PortRdW(PM41_UtilGetReg(reg),handleval));				//Get value
}

/**
*
*  PM41_RegClr()
*  Clears (wipes w/ zeros) the specified  PM41 register.
*  Arguments: 
*    reg:  PM41 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_RegClr(USHORT reg,HANDLE handleval)
{
	PM41_RegWr(0x0000,reg,handleval);									//Write 0s to register
}

/**
*
*  PM41_RegBitSet()
*  Reads the current value from the specified PM41 register,
*    ORs in specified data, and writes result back.
*  Arguments: 
*    mask: Data to write
*    reg:  PM41 register
*  Returns:  None
*  Warnings: Only adds settings -- does not clear any bits. Use PM41_RegBitClr() to clear bits
*
**/

VOID PM41_RegBitSet(USHORT mask,USHORT reg,HANDLE handleval)
{
	USHORT data;														//Data to be read

	PM41_PageWr(PM41_UtilGetPage(reg),handleval);						//Set page

	data = PM41_PortRdW(PM41_UtilGetReg(reg),handleval);				//Read data from register
	data = (mask | data);												//OR new values in

	PM41_PortWrW(data,PM41_UtilGetReg(reg),handleval); 					//Write back new data
}

/**
*
*  PM41_RegBitClr()
*  Clears the specified flags from the specified PM41 register.
*  Arguments: 
*    mask: Data to clear
*    reg:  PM41 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_RegBitClr(USHORT mask,USHORT reg,HANDLE handleval)
{
	USHORT data;														//Data to be read

	PM41_PageWr(PM41_UtilGetPage(reg),handleval);						//Set page
	data = PM41_PortRdW(PM41_UtilGetReg(reg),handleval);				//Get current register value

	mask = (~mask);														//Set bitmask to its complement
	mask = (mask & data);												//AND new value of mask w/ register contents

	PM41_PortWrW(mask,PM41_UtilGetReg(reg),handleval);					//Srite value back
}

/**
*
*  PM41 Card functions
*
**/

/**
*
*  PM41_CardReset()
*  Resets specified PM429-1.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: REG_CTRLA and REG_CTRLB do not reset upon write to reset register.
*    	  This function clears REG_CTRLA/REG_CTRLB, and then resets the card.
*    	  The delay is to allow the PM429-1 channel presence bits to stabilize.
*
*/

VOID PM41_CardReset(HANDLE handleval)	
{
	USHORT delay;														//Delay counter

	PM41_RegClr(REG_CTRLA,handleval);									//Clear REG_CTRLA
	PM41_RegClr(REG_CTRLB,handleval);									//Clear REG_CTRLB

	PM41_RegWr(1,REG_RESET,handleval);									//Write to reset register

	for (delay = 0; delay <=32; delay++)								//Loop through accesses, wait for channel presence bits to stabilize.
	{
		PM41_RegRd(REG_CTRLA,handleval);
	}
}

/**
*
*  PM41_IsCard()
*  Checks if specified PM429-1 exists
*  Arguments:
*    handleval: card handle
*  Returns:  TRUE is card present, FALSE if not
*  Warnings: None
*
**/

BOOL PM41_IsCard(HANDLE handleval)
{
	USHORT val;															//Holds ID register value

	val = (PM41_RegRd(REG_ID,handleval) & 0xFFF0);						//Read ID register
	if (val==IDVAL) return(TRUE);										//If correct ID value

	return(FALSE);
}

/**
*
*  PM41_SelfTest()
*  Performs a hardware test of the PM429-1
*  Arguments:
*    handleval: card handle
*  Returns:  Zero if card passes, or a negative value indicating the error 
*  Warnings: None
*
**/

INT PM41_SelfTest(HANDLE handleval)
{
	USHORT count;																//Loop counter
	UINT read;																	//Test variable
	UINT exp;																	//Comparison variable
	DWORD dwBytesOut;

	//
	//	Retrieve device configuration
	//

	IOCTLARGS Args;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_CONFIG_RD,
									NULL,0,
									&Args,sizeof(Args),
									&dwBytesOut,
									NULL);

	if (!bResult) return(ERR_NOCARD);

	//
	//  Verify Card is present
	//

	if (!PM41_IsCard(handleval)) return(ERR_NOCARD);
		
	//
	//  Verify Page Register is only 4 bits
	//

	for (count=0;count<=0xFF;++count)								//Write values 0 - 256 to page register
	{
		PM41_PageWr(count,handleval);
		read = PM41_PageRd(handleval);

		exp = (count % 16);
		if (read!=exp) return(ERR_SELFIOFAIL);
	}

	//
	//  Verify IFGA is accessible
	//

	PM41_CardReset(handleval);
	exp=0x0030; read=PM41_RegRd(REG_TCTRL,handleval);
	if (read!=exp) return(ERR_SELFIOFAIL);

	PM41_RegWr(0xFFFE,REG_TCTRL,handleval);
	exp=0x003E; read=PM41_RegRd(REG_TCTRL,handleval);
	if (read!=exp) return(ERR_SELFIOFAIL);

	PM41_CardReset(handleval);
	exp=0x0030; read=PM41_RegRd(REG_TCTRL,handleval);
	if (read!=exp) return(ERR_SELFIOFAIL);

	if (PM41_ChIsXmt(CH4,handleval))
	{
		//
		//  Verify Holt part is accessible
		//

		PM41_CardReset(handleval);
		exp=0x0000; read=PM41_RegRd(REG_CTRLA,handleval);
		if (read!=exp) return(ERR_SELFIOFAIL);

		PM41_RegWr(0xF000,REG_CTRLA,handleval);
		exp=0xF000; read=PM41_RegRd(REG_CTRLA,handleval);
		if (read!=exp) return(ERR_SELFIOFAIL);

		PM41_CardReset(handleval);
		exp=0x0000; read=PM41_RegRd(REG_CTRLA,handleval);
		if (read!=exp) return(ERR_SELFIOFAIL);
	}

	//
	//  Verify transmission on internal wrap-around (high speed)
	//

	if (PM41_ChIsXmt(CH4,handleval))
	{
		//
		//  Configure channels
		//

		PM41_ChConfig(ARINCCTRL_SPEED_HIGH,ARINCCTRL_PAR_ODD,FALSE,TRUE,CH0,handleval);
		PM41_ChConfig(ARINCCTRL_SPEED_HIGH,ARINCCTRL_PAR_ODD,FALSE,TRUE,CH1,handleval);
		PM41_ChConfig(ARINCCTRL_SPEED_HIGH,ARINCCTRL_PAR_ODD,FALSE,TRUE,CH4,handleval);
		PM41_SRQConfig(ASRQ_RCV_RDY,CH0,handleval);

		srand(rand());													//Seed random number generator
		exp = rand();													//Get random number

		PM41_ChDataWr(exp,CH4,handleval);								//Load data
		PM41_ChGapWr(200,CH4,handleval);								//Trigger transmission

		//
		//  Wait until data received
		//

		for (count=0xFFFF;count;--count)
		{
			read = (0x0008 && PM41_SRQIsSet(SRQ_RCH0,handleval));
			if (read) break;
		}

		exp  = (exp & 0x7FFFFFFF);									//Mask parity bit

		read = PM41_ChDataRd(CH0,handleval) & 0x7FFFFFFF;			//Mask parity bit
		if (read!=exp) return(ERR_SELFXMTFAIL);

		read = (~(PM41_ChDataRd(CH1,handleval))) & 0x7FFFFFFF;		//Mask parity bit
		if (read!=exp) return(ERR_SELFXMTFAIL);
	}

	//
	//  Verify Interrupts
	//

	if (Args.irqcount)
	{
		PM41_CardReset(handleval);

		PM41_LEDBlink(handleval);

		//
		//	Create event
		//

	    HANDLE hEvent = CreateEvent(NULL,FALSE,FALSE,NULL);

		if (INVALID_HANDLE_VALUE==hEvent) return(ERR_UNKNOWN);

		//
		//  Configure card for timer interrupt
		//

		PM41_IntEnable(SRQ_TIMER,handleval);

		//
		//	Install kernel interrupt handler
		//

		if (!PM41_IntInstall(hEvent,handleval))
		{
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//	Verify no interrupt has been received
		//

		if (WAIT_TIMEOUT != WaitForSingleObject(hEvent,1000))
		{
			PM41_IntUninstall(handleval);
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//  Trigger interrupt
		//

		PM41_TimerWr(0x000000FF,handleval);
		PM41_RegWr(0x000D,REG_TCTRL,handleval);

		for (count=0xFFFF;count;--count)
		{
			read = PM41_TimerRd(handleval);
			if (!read) break;
		}

		//
		//	Verify interrupt was received
		//

		if (WAIT_TIMEOUT == WaitForSingleObject(hEvent,1000))
		{
			PM41_IntUninstall(handleval);
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//  Clear interrupt
		//

		PM41_SRQClr(SRQ_TIMER,handleval);

		PM41_IntUninstall(handleval);

		PM41_IntDisable(handleval);
		
		CloseHandle(hEvent);
	}

	//
	//  Blink USER LED
	//

	PM41_LEDBlink(handleval);

	PM41_CardReset(handleval);

	return(ERR_NONE);
}

/**
*
*  PM41 SRQ Functions
*
**/

/**
*
*  PM41_SRQIsSet()
*  Checks for specified SRQ(s) from the PM429-1.
*  Arguments:
*    srq:  SRQ(s) to check
*    handleval: card handle
*  Returns:  TRUE if SRQ specified is set, else FALSE
*  Warnings: None
*
**/

BOOL PM41_SRQIsSet(USHORT srq,HANDLE handleval)
{
	if (PM41_RegRd(REG_SRQ,handleval) & srq)										//If SRQ set...
	{
		return(TRUE);
	}
	return(FALSE);
}

/**
*
*  PM41_SRQClr()
*  Clears the specified SRQ bit(s)
*  Arguments:
*    srq:  SRQ to clear
*    handleval: card handle
*  Returns:  None
*  Warnings: The actual cause of the SRQ must be cleared before the SRQ can be cleared
*
**/

VOID PM41_SRQClr(USHORT srq,HANDLE handleval)
{
	PM41_RegWr(srq,REG_SRQ,handleval);												//Write value to SRQ register
}

/**
*
*  PM41_SRQConfig()
*  Configures ARINC SRQ on specified channel
*  Arguments:
*    status:    SRQ type(s) to set
*    chan:      specified channel
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/ 

VOID PM41_SRQConfig(USHORT status,INT chan,HANDLE handleval)
{
	USHORT val;																		//Value of REG_ASRQ

	val = PM41_RegRd(REG_ASRQ,handleval);											//Get current srq

	val = (val & (~(ASRQ_MASK_ARINC << (chan * 2))));								//Wipe srq cfg bits from srq register value
	val = (val | (status << (chan*2)));												//OR in new cfg bits

	PM41_PortWrW(val,PM41_UtilGetReg(REG_ASRQ),handleval);							//Write new value back
}

/**
*
*  PM41 Channel functions
*
**/

/**
*
*  PM41_IsChan()
*  Checks if specified channel is present
*  Arguments:
*    chan: specified channel
*    handleval: card handle
*  Returns:  None
*  Warnings: Cannot detect externally disabled transmitter
*
*/

BOOL PM41_IsChan(INT chan,HANDLE handleval)
{
	if (PM41_IsCard(handleval))																	//If it's  a card...
	{
		return(PM41_RegRd((USHORT)((chan<<4) | CHAN_CHSTAT),handleval) & CHSTAT_CHPRESENT);		//Return channel presence bit
	}
	return(FALSE);
}

/**
*
*  PM41_ChIsRcv()
*  Checks if specified channel is receive channel
*  Arguments:
*    chan: specified channel
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

BOOL PM41_ChIsRcv(INT chan,HANDLE handleval)
{
	if (PM41_IsChan(chan,handleval))												//If it's a channel...
	{
		if (chan <= CH3)															//And if the channel number is <= 3...
		{
			return(TRUE);															//The channel is a receiver.
		}
	}
	return(FALSE);

}

/**
*
*  PM41_ChIsXmt()
*  Checks if specified channel is transmit channel
*  Arguments:
*    chan: specified channel
*    handleval: card handle
*  Returns:  None
*  Warnings: Cannot detect externally disabled transmitter
*
*/

BOOL PM41_ChIsXmt(INT chan,HANDLE handleval)
{
	if (PM41_IsChan(chan,handleval))												//If it's a channel...
	{
		if (chan>CH3)																//And if the channel number is >= 4...
		{
			return(TRUE);															//The channel is a transmitter.
		}
	}
	return(FALSE);
}

/**
*
*  PM41_ChDataWr()
*  Writes 1 dataword to specified ARINC 429 TCH.
*  Arguments:
*    data: Data to write
*    chan: Channel to write data to
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_ChDataWr(UINT data,INT chan,HANDLE handleval)
{
	UINT word_l;																	//Low half of word
	UINT word_h;																	//High half of word

	PM41_PageWr(chan,handleval);													//Select channel

	word_l = (data & 0x0000FFFF);													//Filter for low word
	PM41_PortWrW((USHORT)word_l,CHAN_CHDATA_L,handleval);							//Write low word

	word_h = (data & 0xFFFF0000);													//Filter for high word
	word_h = (word_h >> 16);														//Shift high word
	PM41_PortWrW((USHORT)word_h,CHAN_CHDATA_H,handleval);							//Write high word
}

/**
*
*  PM41_ChDataRd()
*  Reads 1 dataword from specified ARINC 429 RCH.
*  Arguments:
*    chan: Channel to write data to
*    handleval: card handle
*  Returns:  1 ARINC dataword from channel
*  Warnings: If no data is present in the specified channel FIFO,
*    	  an undefined value will be returned.
*
**/

UINT PM41_ChDataRd(INT chan,HANDLE handleval)
{
	UINT word_l;																	//Low half of word
	UINT word_h;																	//High half of word

	PM41_PageWr(chan,handleval);													//Select channel

	word_l = PM41_PortRdW(CHAN_CHDATA_L,handleval);									//Get low word
	word_h = PM41_PortRdW(CHAN_CHDATA_H,handleval);									//Get high word

	return((word_h<<16) | (word_l<<0));												//Return low and high words ORed together
}

/**
*
*  PM41_ChStatRd()
*  Reads Status register from specified channel
*  Arguments:
*    chan: Channel to read from
*    handleval: card handle
*  Returns:  Contents of status register from channel
*  Warnings: None
*
**/

USHORT	PM41_ChStatRd(INT chan,HANDLE handleval)
{
	return(PM41_RegRd((USHORT)((chan << 4) | CHAN_CHSTAT),handleval));				//Return CHSTAT contents
}

/**
*
*  PM41_ChGapWr()
*  Writes gap value to specified TCH
*  Arguments:
*    gap:  Gap value to write (in bit-times)
*    chan: Channel to write to 
*    handleval: card handle
*  Returns:  None
*  Warnings: ChGapWr() causes transmission on specified channel if
*    	  data is present in FIFO.
*
**/

VOID PM41_ChGapWr(USHORT gap,INT chan,HANDLE handleval)
{
	PM41_RegWr(gap,(USHORT)((chan << 4) | CHAN_CHGAP),handleval);					//Write gap value
}

/**
*
*  PM41_ChGapRd()
*  Reads gap value from specified TCH
*  Arguments:
*    chan: Channel to read from 
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

USHORT PM41_ChGapRd(INT chan,HANDLE handleval)
{
	return(PM41_RegRd((USHORT)((chan << 4) | CHAN_CHGAP),handleval));				//Read gap value
}

/**
*
*  PM41_IsChGapDone()
*  Checks if the gap timer has counted down
*  Arguments:
*    chan: Channel to write to 
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

BOOL PM41_IsChGapDone(INT chan,HANDLE handleval)
{
	USHORT val;
	val = PM41_RegRd((USHORT)((chan << 4) | CHAN_CHSTAT),handleval);				//Get CHSTAT

	val = (val & CHSTAT_TIMZ);														//Filter for gap timer done

	if (val)		//check for gap timer counted down
	{
		return(TRUE);
	}

	return(FALSE);
}

/**
*
*  PM41_ChClear()
*  Clears receive buffer of specified channel
*  Arguments:
*    chan: Channel to clear
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_ChClear(INT chan,HANDLE handleval)
{
	USHORT count;
	for (count=0;count<=31;count++)													//Loop through rcv buffer entries
	{
		PM41_ChDataRd(chan,handleval);												//Read data and throw away
	}
}

/**
*
*  PM41_ChCfg()
*  Sets channel options for specified channel
*  Arguments:
*    speed: ARINCCTRL_SPEED_HIGH or ARINCCTRL_SPEED_LOW
*    parity: ARINCCTRL_PAR_ODD, ARINCCTRL_PAR_EVEN, or ARINCCTRL_PAR_DATA
*    scramble: TRUE for data scramble, FALSE for unscramble
*    selftest: TRUE for self-test bus, FALSE for normal
*    chan: Channel to configure
*    handleval: card handle
*  Returns:  None
*  Warnings: Scramble & Selftest options are global for CH0/CH1/CH4 or CH2/CH3/CH5, not per channel
*
**/

VOID PM41_ChConfig(USHORT speed,USHORT parity,BOOL scramble,BOOL selftest,INT chan,HANDLE handleval)
{
	USHORT data;																	//Holds old contents of REG_CTRLA/REG_CTRLB
	USHORT chanflag=0;																//Flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr(((REG_ACTRL & 0xF0) >> 4),handleval);								//Set PAGE

	if ((chan==CH0) || (chan==CH1) || (chan==CH4))									//Working with REG_CTRLA
	{
		chanflag = REG_CTRLA;														//Set flag
	}
	else if ((chan==CH2) || (chan==CH3) || (chan==CH5))								//Working with REG_CTRLB
	{
		chanflag = REG_CTRLB;														//Set flag
	}

	data = PM41_PortRdW(PM41_UtilGetReg(chanflag),handleval);						//Get register data

	scramble ? (data &= ~ARINCCTRL_DATAUNSCRAM) : (data |= ARINCCTRL_DATAUNSCRAM);	//Check for scramble option
	selftest ? (data &= ~ARINCCTRL_SELFTESTOFF) : (data |= ARINCCTRL_SELFTESTOFF);	//Check for self-test bus option

	if ((chan==CH4) || (chan==CH5))																		//Transmit channel
	{
		(parity==ARINCCTRL_PAR_DATA) ? (data &= ARINCCTRL_PAR_DATA) : (data |= ~ARINCCTRL_PAR_DATA);	//Check no parity/for parity
		(parity==ARINCCTRL_PAR_EVEN) ? (data |= ARINCCTRL_PAR_EVEN) : (data |=  ARINCCTRL_PAR_ODD);		//Check for even/odd parity

		(speed==ARINCCTRL_SPEED_HIGH) ? (data &= ~(speed << 13)) : (data |= (speed << 13));				//Set speed
	}

	if ((chan==CH0) || (chan==CH2))																		//Set speed for 1st RCH
	{
		(speed==ARINCCTRL_SPEED_HIGH) ? (data &= ~(speed << 0)) : (data |= (speed << 0));
	}

	if ((chan==CH1) || (chan==CH3))																		//Set speed for 2nd RCH
	{
		(speed==ARINCCTRL_SPEED_HIGH) ? (data &= ~(speed << 14)) : (data |= (speed << 14));
	}

	PM41_PortWrW(data,PM41_UtilGetReg(chanflag),handleval);												//Write to REG_CTRLA
}

/**
*
*  PM41 Filter functions
*
**/

/**
*
*  PM41_FilterSDISet()
*  Sets SDI filter for specified channel
*  Arguments:
*    SDI:  SDI (CFG_SDI_xx)
*    chan: Channel to set
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_FilterSDISet(USHORT sdi,INT chan,HANDLE handleval)
{
	USHORT data;																	//Old REG_CTRLA data
	USHORT chanflag=0;																//Flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr(((REG_ACTRL & 0xF0) >> 4),handleval);								//Set PAGE register

	if ((chan==CH0) || (chan==CH1))													//Working w/ REG_CTRLA
	{
		chanflag = REG_CTRLA;														//Set flag
	}
	else if ((chan==CH2) || (chan==CH3))											//Working w/ REG_CTRLB
	{
		chanflag = REG_CTRLB;														//Set flag
	}
	
	data = PM41_PortRdW(PM41_UtilGetReg(chanflag),handleval);						//Get current value
	
	data &= (((chan==0) || (chan==2)) ? ~(ASRQ_MASK_ARINC<<7) : ~(ASRQ_MASK_ARINC<<10));	//Mask off appropriate SDI value

	if (sdi != ARINCCTRL_CFG_SDI_NONE)												//Setting SDI
	{
		data |= (((chan==CH0) || (chan==CH2)) ? (sdi<<7) : (sdi<<10));									//OR in filter value
		data |= (((chan==CH0) || (chan==CH2)) ? (ARINCCTRL_CFG_SDI_EN<<6) : (ARINCCTRL_CFG_SDI_EN<<9));	//OR in enable bit
	}

	PM41_PortWrW(data,PM41_UtilGetReg(chanflag),handleval);							//Write to REG_CTRLA/B
}

/**
*
*  PM41_FilterSDIClear()
*  Clears SDI filter for specified channel
*  Arguments:
*    chan: Channel to clear
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_FilterSDIClear(INT chan,HANDLE handleval)
{
	USHORT data;																	//Old REG_CTRLA/B data
	USHORT chanflag=0;																//Flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr(((REG_ACTRL & 0xF0)>>4),handleval);									//Set PAGE register

	if ((chan==CH0) || (chan==CH1))													//Working w/ REG_CTRLA
	{
		chanflag = REG_CTRLA;														//Set flag
	}
	else if ((chan==CH2) || (chan==CH3))											//Working w/ REG_CTRLB
	{
		chanflag = REG_CTRLB;														//Set flag
	}

	data = PM41_PortRdW(PM41_UtilGetReg(chanflag),handleval);									//Get current value
	
	data &= (((chan==CH0) || (chan==CH2)) ? ~(ASRQ_MASK_ARINC <<7) : ~(ASRQ_MASK_ARINC <<10));	//Mask off appropriate SDI value
	data &= (((chan==CH0) || (chan==CH2)) ? ~(ASRQ_MASK_ENABLE<<6) : ~(ASRQ_MASK_ENABLE<< 9));	//Turn off sdi filter

	PM41_PortWrW(data,PM41_UtilGetReg(chanflag),handleval);							//Write to REG_CTRLA/B

}

/**
*
*  PM41_FilterLabelSet()
*  Sets label filter for specified channel
*  Arguments:
*    label[16]: array of 16 labels
*    chan:      Channel to set
*    handleval: card handle
*  Returns:  None
*  Warnings: 
*
*/

VOID PM41_FilterLabelSet(UCHAR label[16],INT chan,HANDLE handleval)
{
	USHORT data;																			//Holds register value

	PM41_PageWr((PM41_UtilGetPage(REG_CTRLA)),handleval);									//Set page
	
	data = (((chan==CH0) || (chan==CH1)) ? PM41_PortRdW(PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortRdW(PM41_UtilGetReg(REG_CTRLB),handleval));	//get data

	data |= ARINCCTRL_CFG_LABEL_FLT;														//Set label memory open

	((chan==CH0) || (chan==CH1)) ? PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLB),handleval);	//write data

	((chan==CH0) || (chan==CH1)) ? PM41_PageWr(CH4,handleval) : PM41_PageWr(CH5,handleval);	//Set page

	for (data=0;data<=15;data++)															//Loop through array positions
	{
		if ((chan==CH0) || (chan==CH2))														//Using lower channel
		{
			PM41_PortWrW((USHORT)label[data],CHAN_CHDATA_L,handleval);																//write labels
		}

		if ((chan==CH1) || (chan==CH3))														//Using upper channel
		{
			PM41_PortWrW((USHORT)label[data],CHAN_CHDATA_H,handleval);																//write labels
		}
	}

	PM41_PageWr(PM41_UtilGetPage(REG_CTRLA),handleval);												//Set page

	data = (((chan==CH0) || (chan==CH1)) ? PM41_PortRdW(PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortRdW(PM41_UtilGetReg(REG_CTRLB),handleval));	//get data

	data &= ~(ARINCCTRL_CFG_LABEL_FLT);																//Set label memory close

	data |= (((chan==CH0) || (chan==CH2)) ? ARINCCTRL_CFG_LABEL_CH0 : ARINCCTRL_CFG_LABEL_CH1);		//Set filter enable

	((chan==CH0) || (chan==CH1)) ? PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLB),handleval);	//write data
}

/**
*
*  PM41_FilterLabelClr()
*  Disables label filter for specified channel
*  Arguments:
*    chan: Channel to clear
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_FilterLabelClr(INT chan,HANDLE handleval)
{
	USHORT data;																					//Holds data from card

	PM41_PageWr(chan,handleval);																	//Set page value

	data = ((chan<CH2) ? PM41_PortRdW(REG_CTRLA,handleval) : PM41_PortRdW(REG_CTRLB,handleval));	//Get REG_CTRLA/REG_CTRLB

	data &= (((chan==CH0) || (chan==CH2)) ? ~ARINCCTRL_CFG_LABEL_CH0 : ~ARINCCTRL_CFG_LABEL_CH1);	//Set label filter off

	(chan<CH2) ? PM41_PortWrW(data,REG_CTRLA,handleval) : PM41_PortWrW(data,REG_CTRLB,handleval);	//Write data back
	
}

/**
*
*  PM41_FilterLabelRead()
*  Reads label filter for specified channel
*  Arguments:
*    chan:   Channel to read from
*    handleval: card handle
*  Returns:  Pointer to array of label values
*  Warnings: None
*
**/

PUCHAR PM41_FilterLabelRead(PUCHAR labels,INT chan,HANDLE handleval)
{
	USHORT data;																					//Holds data from card

	PM41_PageWr(PM41_UtilGetPage(REG_CTRLA),handleval);																					//set page to ARINCCTRL (0x9)

	data = ((chan<CH2) ? PM41_PortRdW(PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortRdW(PM41_UtilGetReg(REG_CTRLB),handleval));		//get data from register

	data |= ARINCCTRL_CFG_LABEL_FLT;																//Set label memory open

	(chan<CH2) ? PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLB),handleval);	//write data back
	
	PM41_PageWr(chan,handleval);																	//Set page to channel
	
	for (data=0;data<=15;data++)																	//Loop through labels
	{
		labels[data] = (UCHAR)PM41_PortRdW(CHAN_CHDATA_L,handleval);								//Read label into array
	}

	PM41_PageWr(((REG_ACTRL & 0xF0) >> 4),handleval);																					//set page to ARINCCTRL (0x9)

	data = ((chan<CH2) ? PM41_PortRdW(PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortRdW(PM41_UtilGetReg(REG_CTRLB),handleval));	//read data

	data &= ~ARINCCTRL_CFG_LABEL_FLT;																//Set label memory close

	(chan<CH2) ? PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLA),handleval) : PM41_PortWrW(data,PM41_UtilGetReg(REG_CTRLB),handleval);	//write data back

	return(&labels[0]);
}

/**
*
*  PM41 LED functions
*
**/

/**
*
*  PM41_IsLEDSet()
*  Reads status of external LED
*  Arguments:
*    handleval: card handle
*  Returns:  TRUE = on,FALSE = off
*  Warnings: None
*
*/

BOOL PM41_IsLEDSet(HANDLE handleval)
{
	BOOL val;														//Holds LED value

	val = (PM41_RegRd(REG_CLKCTRL,handleval) & LED_ON);				//Get current led value

	return(val);
}

/**
*
*  PM41_LEDWr()
*  Turns LED on or off
*  Arguments:
*    val:  LED value (TRUE = on, FALSE = off)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_LEDWr(BOOL val,HANDLE handleval)
{
	(val) ? PM41_RegBitSet(LED_ON,REG_CLKCTRL,handleval) : PM41_RegBitClr(LED_ON,REG_CLKCTRL,handleval);	//Set/clear LED
}

/**
*
*  PM41_LEDBlink()
*  Blinks user LED once (on, off)
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: This function uses the on-board timer
*
**/

VOID PM41_LEDBlink(HANDLE handleval)
{
	USHORT timeval = 1;												//Timer value
	USHORT period = 250;											//Change this value to change LED frequency

	PM41_LEDWr(TRUE,handleval);										//Set LED
	PM41_TimerClr(handleval);										//Clear timer
	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_STOPZERO,handleval);		//1 Msec
	PM41_TimerWr(period,handleval);									//250 Msec
	PM41_TimerStart(handleval);										//Start timer

	do																//Wait for timer to count down
	{
		timeval = (USHORT)PM41_TimerRd(handleval);					//Read timer val
	}while(timeval);


	PM41_LEDWr(FALSE,handleval);									//Reset LED
	PM41_TimerClr(handleval);										//Clear timer
	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_STOPZERO,handleval);		//1 Msec
	PM41_TimerWr(period,handleval);									//250 Msec
	PM41_TimerStart(handleval);										//Start timer

	timeval = 1;													//Reinit timeval

	do																//Wait for timer to count down
	{
		timeval = (USHORT)PM41_TimerRd(handleval);					//Read timer val
	}while(timeval);

	PM41_TimerStop(handleval);										//Stop timer
}

/**
*
*  PM41 Timer functions
*
**/

/**
*
*  PM41_TimerConfig()
*  Configures on-board timer
*  Arguments:
*    ctrlflags:  Timer settings
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_TimerConfig(USHORT cfgflags,HANDLE handleval)
{
	PM41_RegWr(cfgflags,REG_TCTRL,handleval);
}

/**
*
*  PM41_TimerStart()
*  Starts on-board timer
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_TimerStart(HANDLE handleval)
{
	PM41_RegBitSet(TCTRL_EN,REG_TCTRL,handleval);
}

/**
*
*  PM41_TimerStop()
*  Stops on-board timer
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_TimerStop(HANDLE handleval)
{
	PM41_RegBitClr(TCTRL_EN,REG_TCTRL,handleval);
}

/**
*
*  PM41_TimerClr()
*  Stops and clears on-board timer
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: This function clears both the timer value and the timer control register
*
*/

VOID PM41_TimerClr(HANDLE handleval)
{
	PM41_PageWr(PM41_UtilGetPage(REG_TCTRL),handleval);

	PM41_PortWrW(0x0000,PM41_UtilGetReg(REG_TCTRL),handleval);		//Stop timer,reset all flags

	PM41_PortWrW(0x0000,PM41_UtilGetReg(REG_TIME_L),handleval);		//Reset timer low word
	PM41_PortWrW(0x0000,PM41_UtilGetReg(REG_TIME_H),handleval);		//Reset timer high word
}

/**
*
*  PM41_TimerRd()
*  Reads on-board timer
*  Arguments:
*    handleval: card handle
*  Returns:  Timer value
*  Warnings: None
*
*/

UINT PM41_TimerRd(HANDLE handleval)
{
	UINT data_l;														//Low word of timer
	UINT data_h;														//High word of timer

	PM41_PageWr((PM41_UtilGetPage(REG_TCTRL)),handleval);				//Set PAGE

	data_l = PM41_PortRdW(PM41_UtilGetReg(REG_TIME_L),handleval);		//Get low word
	data_h = PM41_PortRdW(PM41_UtilGetReg(REG_TIME_H),handleval);		//Get high word

	return((data_h<<16) | (data_l<<0));									//Return Complete word
}

/**
*
*  PM41_TimerWr()
*  Writes value to on-board timer
*  Arguments:
*    timeval: Value to write
*    handleval: card handle
*  Returns:  Timer value
*  Warnings: None
*
*/

VOID PM41_TimerWr(UINT timeval,HANDLE handleval)
{
	UINT val;																								//Holds data from card
	PM41_PageWr(PM41_UtilGetPage(REG_TCTRL),handleval);														//Set PAGE

	val = ((timeval>> 0) & 0x0000FFFF); PM41_PortWrW((USHORT)val,PM41_UtilGetReg(REG_TIME_L),handleval);	//Get low word of timeval
	val = ((timeval>>16) & 0x0000FFFF); PM41_PortWrW((USHORT)val,PM41_UtilGetReg(REG_TIME_H),handleval);	//Get high word of timeval
}

/**
*
*  PM41_TimerSRQEn()
*  Enables SRQs on timer
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_TimerSRQEn(HANDLE handleval)
{
	PM41_RegBitSet(TCTRL_SRQEN,REG_TCTRL,handleval);
}

/**
*
*  PM41_TimerSRQDis()
*  Disables SRQs on timer
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_TimerSRQDis(HANDLE handleval)
{
	PM41_RegBitClr(TCTRL_SRQEN,REG_TCTRL,handleval);
}

/**
*
*  PM41 DIN functions
*
**/

/**
*
*  PM41_IsDINSet()
*  Reads value of specified DIN
*  Arguments:
*    din:  Specified DIN
*    handleval: card handle
*  Returns:  TRUE if set,FALSE if not
*  Warnings: None
*
*/

BOOL PM41_IsDINSet(USHORT din,HANDLE handleval)
{
	USHORT data;														//Holds data from card

	data = PM41_RegRd(REG_DIN,handleval);								//Get data
	data = (data & din);												//Filter for specified DIN

	return(BOOL)data;
}

/**
*
*  PM41_DINConfig()
*  Configures digital inputs
*  Arguments:
*    res:    Sample rate resolution (DBRES_1U or DBRES_1M)
*    period: Sample rate period
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_DINConfig(INT resol,INT period,HANDLE handleval)
{
	PM41_RegWr((USHORT)(resol | period),REG_DSAMP,handleval);
}

/**
*
*  PM41_DINSRQRd()
*  Reads value of DIN SRQ configuration register
*  Arguments:
*    handleval: card handle
*  Returns:  DINT register value
*  Warnings: None
*
*/

USHORT PM41_DINSRQRd(HANDLE handleval)
{
	return(PM41_RegRd(REG_DINT,handleval));
}

/**
*
*  PM41_DINSRQSet()
*  Sets digital input SRQ configuration
*  Arguments:
*    srq:    SRQ settings (DINT_SRQ_7P, etc)
*    handleval: card handle
*  Returns:  DINT register value
*  Warnings: None
*
*/

VOID PM41_DINSRQSet(USHORT srq,HANDLE handleval)
{
	PM41_RegWr(srq,REG_DINT,handleval);
}

/**
*
*  PM41 DOUT functions
*
**/

/**
*
*  PM41_DOUTWr()
*  Sets specified DOUT
*  Arguments:
*    dout:   specified dout (DOUT_0 - DOUT_3)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
*/

VOID PM41_DOUTWr(USHORT dout,HANDLE handleval)
{
	PM41_RegWr(dout,REG_DOUT_S,handleval);
}

/**
*
*  PM41_DOUTIsSet()
*  Reads specified DOUT
*  Arguments:
*    dout:   specified dout (DOUT_0 - DOUT_3)
*    handleval: card handle
*  Returns:  TRUE if set, FALSE if reset
*  Warnings: None
*
*/

BOOL PM41_DOUTIsSet(USHORT dout,HANDLE handleval)
{
	return(PM41_RegRd(REG_DOUT_ST,handleval) & dout);
}

/**
*
*  PM41_DOUTClr()
*  Clears specified DOUT
*  Arguments:
*    dout:   specified dout (DOUT_0 - DOUT_3)
*    handleval: card handle
*  Returns:  None
*  Warnings: None 
*
**/

VOID PM41_DOUTClr(USHORT dout,HANDLE handleval)
{
	PM41_RegWr(dout,REG_DOUT_C,handleval);
}

/**
*
*  PM41 Interrupt Functions
*
**/

/**
*
*  PM41_IntInstall()
*  Installs an interrupt handler for the PM429-1
*  Arguments:
*    hEvent:    event object to set
*    handleval: card handle
*  Returns:  TRUE if successful, otherwise FALSE
*  Warnings: None
*
**/

BOOL PM41_IntInstall(HANDLE hEvent,HANDLE handleval)
{
	DWORD dwBytesOut;

	if (handleval==INVALID_HANDLE_VALUE) return(FALSE);
	if (hEvent==INVALID_HANDLE_VALUE) return(FALSE);

	//
	//	Config device
	//

	IOCTLARGS Args;
	Args.hEvent = hEvent;

	BOOL bResult = DeviceIoControl(	handleval,
									IOCTL_INT_INST,
									&Args,sizeof(Args),
									NULL,0,
									&dwBytesOut,
									NULL);
	if (!bResult) return(FALSE);

	return(TRUE);
}

/**
*
*  PM41_IntUninstall()
*  Uninstalls the interrupt handler for the PM429-1
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM41_IntUninstall(HANDLE handleval)
{
	DWORD dwBytesOut;

	if (handleval==INVALID_HANDLE_VALUE) return;

	//
	//	Config device
	//

	DeviceIoControl(	handleval,
						IOCTL_INT_UNINST,
						NULL,0,
						NULL,0,
						&dwBytesOut,
						NULL);
}

/**
*
*  PM41_IntEnable()
*  Enables specified interrupts from PM429-1
*  Arguments:
*    intsource: specified interrupt
*    handleval: card handle
*  Returns:  None
*  Warnings: This function will overwrite the previous settings of REG_INTMASK 
*
**/

VOID PM41_IntEnable(INT intsource,HANDLE handleval)
{
	PM41_RegWr((USHORT)(intsource | INTMASK_ENABLE),REG_INTMASK,handleval);
}

/**
*
*  PM41_IntDisable()
*  Diables interrupts from PM429-1
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None 
*
**/

VOID PM41_IntDisable(HANDLE handleval)
{
	PM41_RegBitClr(INTMASK_ENABLE,REG_INTMASK,handleval);
}
