/**
*
*  PM1553-1 C/C++ DRIVER  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11.CPP --  PM1553-1 Driver Source File.
*
**/

/**
*
*  Function names and descriptions:
*
*   Card open/close functions
*
*    BOOL   PM11_CardOpen()         -- Opens access to the card and passes back a handle
*    VOID   PM11_CardClose()        -- Closes access to the card
*
*  Utility functions
*
*    USHORT  PM11_PackCWD()         -- Builds a MIL-STD-1553 command word from its fields.
*    VOID    PM11_UnpackCWD()       -- Gets the individual fields from a MIL-STD-1553 command word.
*
*  Host I/O functions
*
*    VOID    PM11_PortWrB()         -- Write 1 byte of data to the specified I/O port.
*    UCHAR   PM11_PortRdB()         -- Reads 1 byte of data from the specified I/O port.
*    VOID    PM11_PortWrW()         -- Writes a 16-bit value to the specified I/O port.
*    USHORT  PM11_PortRdW()         -- Reads a 16-bit value from the specified I/O port.
*
*  PM11 Register functions
*
*    VOID    PM11_RegWr()           -- Writes a value to the specified PM1553-1 register.
*    USHORT  PM11_RegRd()           -- Reads a value from the specified PM1553-1 register.
*    VOID    PM11_RegClr()          -- Clears (wipes w/ zeros) the specified  PM11 register.
*    VOID    PM11_RegBitSet()       -- Reads value from PM11 register, ORs in data, and writes it back.
*    VOID    PM11_RegBitClr()       -- Clears the specified flags from the specified PM11 register.
*
*  PM11 Summit register functions
*
*    VOID    PM11_SummitWr()        -- Writes a value to the specified Summit register.
*    USHORT  PM11_SummitRd()        -- Reads a value from the specified Summit register.
*    VOID    PM11_SummitClr()       -- Clears (wipes w/ zeros) the specified Summit register.
*    VOID    PM11_SummitBitSet()    -- Reads from Summit register, ORs in data, and writes it back.
*    VOID    PM11_SummitBitClr()    -- Clears the specified flags from the specified Summit register.
*
*  PM11 Card/Summit functions
*
*    VOID    PM11_SummitStart()     -- Sets the STEX bit of the Summit.
*    VOID    PM11_SummitStop()      -- Clears the STEX bit of the Summit.
*    BOOL    PM11_SummitIsReady()   -- Checks whether Summit ready is set.
*    VOID    PM11_CardReset()       -- Resets specified PM1553-1.
*    BOOL    PM11_IsCard()          -- Checks if specified PM1553-1 exists.
*    INT     PM11_SelfTest()        -- Performs hardware test of specified PM1553-1.
*    VOID    PM11_ModeSet()         -- Sets the mode of the PM1553-1.
*
*  PM11 PROM/Memory functions
*
*    INT     PM11_ROMWr()           -- Writes one byte to the PM1553-1 PROM.
*    UCHAR   PM11_ROMRd()           -- Reads one byte from the PM1553-1 PROM.
*    INT     PM11_ROMWipe()         -- Erases the PM1553-1 PROM.
*    INT     PM11_ROMWipeSect()     -- Erases the specified sector of the PM1553-1 PROM
*    INT     PM11_ROMWrIsComplete() -- Checks whether a write to the PM1553-1 PROM completed correcetly.
*    UINT    PM11_ROMGetIDVal()     -- Gets the ID value of the PM1553-1 PROM.
*    VOID    PM11_ROMReset()        -- Resets the PM1553-1 PROM to reading data.
*    VOID    PM11_MemFill()         -- Fills PM1553-1 memory in the specified range with the specified value.
*    USHORT  PM11_MemGetSize()      -- Returns the memory size (in 16-bit words) of the PM1553-1.
*
*  PM11 RT functions
*
*    VOID    PM11_RTAddrSet()       -- Sets the RT address of the PM1553-1
*    VOID    PM11_RTDescBlockWr()   -- Writes an RTDESCBLOCK structure to the PM1553-1.
*    VOID    PM11_RTDescBlockRd()   -- Reads data from the PM1553-1 into an RTDESCBLOCK structure.
*
*  PM11 BC functions
*
*    VOID    PM11_BCCmdBlockWr()    -- Writes a BCCMDBLOCK structure to the PM1553-1.
*    VOID    PM11_BCCmdBlockRd()    -- Reads data fron the PM1553-1 into a BCCMDBLOCK structure.
*
*  PM11 LED functions
*
*    BOOL    PM11_LEDIsSet()        -- Reads status of external LED
*    VOID    PM11_LEDWr()           -- Turns LED on or off
*    VOID    PM11_LEDBlink()        -- Blinks user LED once (on, off)
*
*  PM11 Monitor functions
*
*    VOID    PM11_MonBlockRd()      -- Reads data fronm the PM1553-1 into a MONBLOCK structure.
*
*  PM11 Timer functions
* 
*    VOID    PM11_TimerConfig()     -- Configures on-board timer.
*    USHORT  PM11_TimerRd()         -- Reads on-board timer.
*    VOID    PM11_TimerWr()         -- Writes value to on-board timer.
*    VOID    PM11_TimerSSFEn()      -- Enables SSF on timer.
*    VOID    PM11_TimerSSFDis()     -- Disables SSF on timer.
* 
*  PM11 DIN functions
* 
*    BOOL    PM11_DINIsSet()        -- Reads value of specified DIN
*    VOID    PM11_DINConfig()       -- Configures digital inputs
* 
*  PM11 DOUT functions
* 
*    VOID    PM11_DOUTSet()         -- Sets specified DOUT
*    BOOL    PM11_DOUTIsSet()       -- Reads specified DOUT
*    VOID    PM11_DOUTClr()         -- Clears specified DOUT
*
*  PM11 Interrupt/SRQ functions
*
*    VOID    PM11_SRQClr()          -- Clears specified SRQ bit(s) in CREG_STAT
*    VOID    PM11_SRQRd()           -- Reads the SRQ bit(s) set in CREG_STAT
*    BOOL    PM11_IntInstall()      -- Installs an interrupt handler
*    VOID    PM11_IntUninstall()    -- Uninstalls the interrupt handler
*    BOOL    PM11_IntEnable()       -- Enables card interrupts to host
*    BOOL    PM11_IntDisable()      -- Disables card interrupts to host
*
**/

/**
*
*  PM1553-1 include file
*
**/

#include "stdafx.h"

#include "pm11.h"

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

BOOL PM11_CardOpen(HANDLE* handleptr,INT portnum,INT irqnum)
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
	if (portnum & 0x00F) return(FALSE);									//Does not end in 0

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

	if (!PM11_IsCard(handleval))
	{
		PM11_CardClose(handleval);
		return(FALSE);
	}

	*handleptr = handleval;				//Pass back index as handle

	return(TRUE);
}

VOID PM11_CardClose(HANDLE handleval)
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
*  PM11_PackCWD()
*  Builds a command word from the given fields.
*  Arguments:
*    TAval: Terminal address
*    TRval: T/R bit
*    SAval: Subaddress
*    WCval: Word count
*  Returns:  Resulting command word
*  Warnings: None
*
**/

USHORT PM11_PackCWD(INT TAval,INT TRval,INT SAval,INT WCval)
{
	return(USHORT)((((USHORT)TAval&0x1F)<<11) +
	               (((USHORT)TRval&0x01)<<10) +
	               (((USHORT)SAval&0x1F)<< 5) +
	               (((USHORT)WCval&0x1F)<< 0));
}

/**
*
*  PM11_UnpackCWD()
*  Extracts the fields from a given command word
*  Arguments:
*    TAval: Terminal address
*    TRval: T/R bit
*    SAval: Subaddress
*    WCval: Word count
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_UnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRval,LPINT SAval,LPINT WCval)
{
	if (TAval) *TAval = (INT)(((USHORT)CWDval>>11) & 0x1F);					//Shift and filter TA
	if (TRval) *TRval = (INT)(((USHORT)CWDval>>10) & 0x01);					//Shift and filter T/R
	if (SAval) *SAval = (INT)(((USHORT)CWDval>> 5) & 0x1F);					//Shift and filter SA
	if (WCval) *WCval = (INT)(((USHORT)CWDval>> 0) & 0x1F);					//Shift and filter WC
}

/**
*
*  Host I/O functions
*
**/

/**
*
*  PM11_PortWrB()
*  Write 1 byte of data to the specified I/O port
*  Arguments:
*    data: data to write
*    offset: port offset to write to
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_PortWrB(UCHAR data,INT offset,HANDLE handleval)
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
*  PM11_PortRdB()
*  Reads 1 byte of data from the specified I/O port
*  Arguments:
*    offset: port offset to read from
*    handleval: card handle
*  Returns:  Data read
*  Warnings: None
*
**/

UCHAR PM11_PortRdB(INT offset,HANDLE handleval)
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
*  PM11_PortWrW()
*  Writes a 16-bit value to the specified I/O port.
*  Arguments:
*    data: data to write
*    offset: port offset to write to
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_PortWrW(USHORT data,INT offset,HANDLE handleval)
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
*  PM11_PortRdW()
*  Reads a 16-bit value from the specified I/O port.
*  Arguments:
*    offset: port offset to read from
*    handleval: card handle
*  Returns:  Data read
*  Warnings: None
*
**/

USHORT PM11_PortRdW(INT offset,HANDLE handleval)
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
*  PM11 Register functions
*
**/

/**
*
*  PM11_RegWr()
*  Writes a value to the specified PM1553-1 register.
*  Arguments:
*    data: Data to write
*    reg: PM11 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_RegWr(USHORT data,USHORT reg,HANDLE handleval)
{
	PM11_PortWrW(data,reg,handleval);								//Write data
}

/**
*
*  PM11_RegRd()
*  Reads a value from the specified PM1553-1 register.
*  Arguments: 
*    reg:  PM11 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

USHORT PM11_RegRd(USHORT reg,HANDLE handleval)
{
	return(PM11_PortRdW(reg,handleval));							//If reading from IFGA, get value
}

/**
*
*  PM11_RegClr()
*  Clears (wipes w/ zeros) the specified PM11 register.
*  Arguments: 
*    reg:  PM11 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_RegClr(USHORT reg,HANDLE handleval)
{
	PM11_RegWr(0x0000,reg,handleval);								//Write 0s to register
}

/**
*
*  PM11_RegBitSet()
*  Reads the current value from the specified PM11 register, 
*    ORs in specified data, and writes result back.
*  Arguments: 
*    mask: Data to write
*    reg:  PM11 register
*  Returns:  None
*  Warnings: Only adds settings -- does not clear any bits.
*            Use PM11_RegBitClr() to clear bits
*
**/

VOID PM11_RegBitSet(USHORT mask,USHORT reg,HANDLE handleval)
{
	USHORT data;													//Data to be read

	data = PM11_RegRd(reg,handleval);								//Read data from register
	data = (mask | data);											//OR new values in

	PM11_RegWr(data,reg,handleval);									//Write back new data
}

/**
*
*  PM11_RegBitClr()
*  Clears the specified flags from the specified PM11 register.
*  Arguments: 
*    mask: Data to clear
*    reg:  PM11 register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_RegBitClr(USHORT mask,USHORT reg,HANDLE handleval)
{
	USHORT data;													//Data to be read

	data = PM11_RegRd(reg,handleval);								//Get current register value

	mask = (~mask);													//Set bitmask to its complement
	mask = (mask & data);											//AND new value of mask w/ register contents

	PM11_RegWr(mask,reg,handleval);									//Write value back
}

/**
*
*  PM11 Summit Register functions
*
**/

/**
*
*  PM11_SummitWr()
*  Writes the specified data to the specified PM1553-1 SuMMIT register.
*  Arguments: 
*    data: Data to write
*    addr:  SuMMIT register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitWr(USHORT data,USHORT addr,HANDLE handleval) 
{
	PM11_PortWrW(addr,CREG_ADDR,handleval);							//Write address
	PM11_PortWrW(data,CREG_DATA,handleval);							//Write data
}

/**
*
*  PM11_SummitRd()
*  Reads the  data of the specified PM1553-1 SuMMIT register.
*  Arguments: 
*    addr:  SuMMIT register
*    handleval: card handle
*  Returns:  Data from SuMMIT register
*  Warnings: None
*
**/

USHORT PM11_SummitRd(USHORT addr,HANDLE handleval)
{
	PM11_PortWrW(addr,CREG_ADDR,handleval);							//Write address
	return(PM11_PortRdW(CREG_DATA,handleval));						//Get value
}

/**
*
*  PM11_SummitClr()
*  Clears (wipes w/ zeros) the specified PM1553-1 SuMMIT register.
*  Arguments: 
*    addr:  SuMMIT register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitClr(USHORT addr,HANDLE handleval)
{
	PM11_SummitWr(0x0000,addr,handleval);
}

/**
*
*  PM11_SummitBitSet()
*  Reads the current value from the specified PM1553-1 SuMMIT register, 
*    ORs in specified data, and writes result back.
*  Arguments: 
*    mask: Bits to set
*    addr:  SuMMIT register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitBitSet(USHORT mask,USHORT addr,HANDLE handleval)
{
	USHORT data;													//Data to be read

	PM11_RegWr(addr,CREG_ADDR,handleval);							//Set ADDR register
	data = PM11_RegRd(CREG_DATA,handleval);							//Read data from register
	data = (mask | data);											//OR new values in

	PM11_RegWr(data,CREG_DATA,handleval);							//Write back new data
}
	
/**
*
*  PM11_SummitBitSet()
*  Clears the specified flags from the specified PM1553-1 SuMMIT register.
*  Arguments: 
*    mask: Bits to clear
*    addr:  SuMMIT register
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitBitClr(USHORT mask,USHORT addr,HANDLE handleval)
{
	USHORT data;													//Data to be read

	PM11_RegWr(addr,CREG_ADDR,handleval);							//Set ADDR register
	data = PM11_RegRd(CREG_DATA,handleval);							//Get current register value

	mask = (~mask);													//Set bitmask to its complement
	mask = (mask & data);											//AND new value of mask w/ register contents

	PM11_RegWr(mask,CREG_DATA,handleval);							//Write value back
}

/**
*
*  PM11 Card/Summit functions
*
**/

/**
*
*  PM11_SummitStart()
*  Starts operation of the PM1553-1.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitStart(HANDLE handleval)
{
	PM11_SummitBitSet(STEX,SREG_CTRL,handleval);
}

/**
*
*  PM11_SummitStop()
*  Stops operation of the PM1553-1.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SummitStop(HANDLE handleval)
{
	PM11_SummitBitClr(STEX,SREG_CTRL,handleval);
}

/**
*
*  PM11_SummitIsReady()
*  Checks whether the PM1553-1 Summit is ready.
*  Arguments:
*    handleval: card handle
*  Returns:  Non-zero if ready, FALSE if not
*  Warnings: None
*
**/

BOOL PM11_SummitIsReady(HANDLE handleval)
{
	return(PM11_RegRd(CREG_STATUS,handleval) & READY);
}

/**
*
*  PM11_CardReset()
*  Resets specified PM1553-1.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_CardReset(HANDLE handleval)
{
	PM11_RegWr(0,CREG_RESET,handleval);										//Write to reset register
	while(!(PM11_RegRd(CREG_STATUS,handleval) & READY));					//Wait for READY to active
}

/**
*
*  PM11_IsCard()
*  Checks if specified PM1553-1 exists
*  Arguments:
*    handleval: card handle
*  Returns:  TRUE is card present, FALSE if not
*  Warnings: None
*
**/

BOOL PM11_IsCard(HANDLE handleval)	
{
	USHORT val;																//Holds ID register value

	val = (PM11_RegRd(CREG_ID,handleval) & 0xFFF0);							//Read ID register, ignore version
	if (val==IDVAL) return(TRUE);											//If correct ID value

	return(FALSE);
}

/**
*
*  PM11_SelfTest()
*  Performs a hardware test of the PM1553-1
*  Arguments:
*    handleval: card handle
*  Returns:    0 if successful, negative value if not
*  Warnings:   None
*
**/

INT PM11_SelfTest(HANDLE handleval)
{
	USHORT count;															//Loop counter
	USHORT read;
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

	if (!PM11_IsCard(handleval)) return(ERR_NOCARD);

	//
	//  Verify IFGA is accessible
	//

	PM11_CardReset(handleval);
	PM11_RegWr(0x1200,CREG_INTCFG,handleval);												//Write to INTCFG register
	if ((PM11_RegRd(CREG_INTCFG,handleval) & 0xFF00) != 0x1200) return(ERR_SELFIOFAIL);

	//
	//  Initiate BIST
	//

	PM11_SummitWr(SBIT,SREG_CTRL,handleval);
	PM11_RegWr(0x00FF,CREG_TIMERS,handleval);												//Write max value to timer

	while((!(PM11_SummitIsReady(handleval))) && (PM11_RegRd(CREG_TIMERS,handleval)));		//Wait for READY or timeout

	if (!(PM11_RegRd(CREG_TIMERS,handleval)))  return(ERR_BITFAIL);							//Timed out waiting for READY
	if (PM11_SummitRd(SREG_BITWORD,handleval)) return(ERR_BITFAIL);

	//
	//  Verify Interrupts
	//

	if (Args.irqcount)
	{
		PM11_CardReset(handleval);

		//
		//	Create event
		//

	    HANDLE hEvent = CreateEvent(NULL,FALSE,FALSE,NULL);

		if (INVALID_HANDLE_VALUE==hEvent) return(ERR_UNKNOWN);

		//
		//  Configure card for timer interrupt
		//

		PM11_IntEnable(SSFSRQ,handleval);

		//
		//	Install kernel interrupt handler
		//

		if (!PM11_IntInstall(hEvent,handleval))
		{
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//	Verify no interrupt has been received
		//

		if (WAIT_TIMEOUT != WaitForSingleObject(hEvent,1000))
		{
			PM11_IntUninstall(handleval);
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//  Trigger interrupt
		//

		PM11_TimerSSFEn(handleval);
		PM11_TimerConfig(TIMER_MODE_ONCE,handleval);
		PM11_TimerWr(0x0001,handleval);

		for (count=0xFFFF;count;--count)
		{
			read = PM11_TimerRd(handleval);
			if (!read) break;
		}

		//
		//  Verify interrupt set in controller
		//

		//
		//	Verify interrupt was received
		//

		if (WAIT_TIMEOUT == WaitForSingleObject(hEvent,1000))
		{
			PM11_IntUninstall(handleval);
			CloseHandle(hEvent);
			return(ERR_IRQFAIL);
		}

		//
		//  Clear interrupt
		//

		PM11_SRQClr(SSFSRQ,handleval);

		PM11_IntUninstall(handleval);

		PM11_IntDisable(SSFSRQ,handleval);
		
		CloseHandle(hEvent);
	}

	//
	//  Blink USER LED
	//

	PM11_LEDBlink(handleval);

	PM11_CardReset(handleval);

	return(ERR_NONE);
}

/**
*
*  PM11_ModeSet()
*  Sets the mode of the PM1553-1.
*  Arguments:
*    mode:  mode (MODE_RT, etc.)
*    handleval: card handle
*  Returns:   None
*  Warnings:  Do not attempt to use this function on an RT-only PM1553-1. (P/N PM1553-1/x1x or /x3x)
*             This function will clear all other settings in the OPSTAT register
*
**/

VOID PM11_ModeSet(USHORT modeval,HANDLE handleval)
{
	PM11_SummitWr(modeval,SREG_OPSTAT,handleval);
}

/**
*
*  PM11 PROM/Memory functions
*
**/

/**
*
*  PM11_ROMWr()
*  Writes a 8-bit byte to the onboard EEPROM.
*  Arguments:
*    data: Data to write
*    addr: Address
*    handleval: card handle
*  Returns:  0 if successful, -1 if write failed
*  Warnings: This function cannot rewrite data without a previous erase cycle.
*
**/

INT PM11_ROMWr(UCHAR data,UINT addr,HANDLE handleval)
{
	INT status;																			//Pass/fail value

	PM11_RegBitSet(PROM_ENABLE,CREG_MISC,handleval);									//OR in PROM enable bit

	//
	//  This sequence enables a write to the PROM 
	//

	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00AA,CREG_DATA,handleval);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); PM11_RegWr(0x0055,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00A0,CREG_DATA,handleval);

	PM11_RegWr((USHORT)((addr>>16) & 0x0001),CREG_ADDR,handleval);						//Write address bit 16
	PM11_RegWr((USHORT)((addr>> 0) & 0xFFFF),CREG_ADDR,handleval);						//Write address bits 0-15

	PM11_PortWrW(data,CREG_DATA_INC,handleval);											//Write data to data register

	status = PM11_ROMWrIsComplete(handleval);											//Check for successful write

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);									//Clear PROM enable bit

	return(status);
}

/**
*
*  PM11_ROMRd()
*  Reads a 8-bit byte from the specified address of the onboard EEPROM.
*  Arguments:
*    addr: Address to read from
*    handleval: card handle
*  Returns:  1 byte from PROM
*  Warnings: This function does NOT check if the PROM is installed.
*
**/

UCHAR PM11_ROMRd(UINT addr,HANDLE handleval)
{
	UCHAR data;																			//Holds data from PROM

	PM11_RegBitSet(PROM_ENABLE,CREG_MISC,handleval);									//OR in PROM enable bit

	PM11_RegWr((USHORT)((addr>>16) & 0x0001),CREG_ADDR,handleval);						//Write address bit 16
	PM11_RegWr((USHORT)((addr>> 0) & 0xFFFF),CREG_ADDR,handleval);						//Write address bits 0-15

	data = (UCHAR)PM11_RegRd(CREG_DATA,handleval);										//Read from data register

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);									//Clear PROM enable bit

	return(data);
}

/**
*
*  PM11_ROMWipe()
*  Erases the entire PM1553-1 PROM.
*  Arguments:
*    handleval: card handle
*  Returns:  0 if successful, -1 if PROM failed to erase
*  Warnings: None
*
**/

INT PM11_ROMWipe(HANDLE handleval)
{
	INT status;																			//Pass/fail value

	PM11_RegBitSet(PROM_ENABLE,CREG_MISC,handleval);									//OR in PROM enable bit

	//
	//  This sequence enables chip erase of the PROM 
	//

	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00AA,CREG_DATA,handleval);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); PM11_RegWr(0x0055,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x0080,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00AA,CREG_DATA,handleval);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); PM11_RegWr(0x0055,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x0010,CREG_DATA,handleval);

	status = PM11_ROMWrIsComplete(handleval);											//Check for erase to complete

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);									//Clear PROM enable bit

	return(status);
}

/**
*
*  PM11_ROMWipeSect()
*  Erases a 16Kbyte sector of the PM1553-1 PROM.
*  Arguments:
*    sector: Sector address to erase (PROM_SECTOR_0, etc.)
*    handleval: card handle
*  Returns:    0 if sucessful, -1 if erase failed
*  Warnings:   None
*
**/

INT PM11_ROMWipeSect(UCHAR sector,HANDLE handleval)
{
	INT status;																			//Pass/fail value

	PM11_RegBitSet(PROM_ENABLE,CREG_MISC,handleval);									//OR in PROM enable bit

	//
	//  This sequence enables sector erase of the PROM
	//

	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00AA,CREG_DATA,handleval);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); PM11_RegWr(0x0055,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x0080,CREG_DATA,handleval);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); PM11_RegWr(0x00AA,CREG_DATA,handleval);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); PM11_RegWr(0x0055,CREG_DATA,handleval);

	PM11_RegWr(sector,CREG_ADDR,handleval);												//Write sector address to wipe
	PM11_RegWr(0x30,CREG_DATA,handleval);												//Write erase command 

	status = PM11_ROMWrIsComplete(handleval);											//Check for successful erase

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);									//Clear PROM enable bit

	return(status);
}

/**
*
*  PM11_ROMWrIsComplete()
*  Checks for successful completion of a write/erase operation of the PM11 PROM
*  Arguments: 
*    handleval: card handle
*  Returns : 0 if successful, -1 if PROM failed write/erase operation
*  Warnings: None
*
**/

INT PM11_ROMWrIsComplete(HANDLE handleval)
{
	UCHAR newDQ6;																		//Holds value read from PROM toggle bit
	UCHAR oldDQ6;																		//Holds value read from PROM toggle bit
	UCHAR DQ5;																			//Holds value read from PROM timeout bit
	BOOL  done;																			//Done flag
	BOOL  failflag;																		//Operation fail flag

	done = FALSE;
	failflag = FALSE;
	DQ5 = 0;																			//Initialize DQ5

	while(!done)																		//Wait for status
	{
		oldDQ6 = (PM11_RegRd(CREG_DATA,handleval) & 0x0040);							//Get value of PROM bit 6
		newDQ6 = (PM11_RegRd(CREG_DATA,handleval) & 0x0040);							//Get value of PROM bit 6

		if (oldDQ6==newDQ6)																//Toggle bit steady
		{
			done = TRUE;
			break;
		}
		else																			//Toggle bit toggling
		{
			DQ5 =  (PM11_RegRd(CREG_DATA,handleval) & 0x0020);							//Get value of PROM bit 5
			if (DQ5)
			{
				done = TRUE;
				break;
			}
		}
	}

	if (DQ5)
	{
		oldDQ6 = (PM11_RegRd(CREG_DATA,handleval) & 0x0040);							//Get value of PROM bit 6
		newDQ6 = (PM11_RegRd(CREG_DATA,handleval) & 0x0040);							//Get value of PROM bit 6

		failflag = ((oldDQ6==newDQ6) ? FALSE : TRUE);									//Check toggle bit
	}
	
	if (failflag)
	{
		PM11_ROMReset(handleval);														//Write PROM reset command

		return(-1);																		//Flag as failed
	}

	return(0);
}

/**
*
*  PM11_ROMGetIDVal()
*  Returns the manufacturer ID and device ID from the PM1553-1 PROM.
*  Arguments:
*    handleval: card handle
*  Returns:  No error: 16-bit value: first 8 bits are manufacturer code, last 8 bits 
*            are the device code (default: 0x0120)
*            Error:    -1
*  Warnings: None
*
**/

UINT PM11_ROMGetIDVal(HANDLE handleval)
{
	USHORT idval;
	INT status;

	status = 0;
	PM11_RegBitSet(PROM_ENABLE,CREG_MISC,handleval);									//OR in PROM enable bit

	//
	//  This sequence gets the manufacturer ID 
	//

	PM11_RegWr(0x0555,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x00AA,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0055,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0090,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0100,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	
	idval = (UCHAR)PM11_RegRd(CREG_DATA,handleval);										//Get manufacturer code
	idval = (idval << 8);																//Shift relevant value to upper byte

	//
	//  This sequence gets the device ID 
	//

	PM11_RegWr(0x0555,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x00AA,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x02AA,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0055,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0555,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0090,CREG_DATA,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);
	PM11_RegWr(0x0101,CREG_ADDR,handleval); status = PM11_ROMWrIsComplete(handleval); if (status) return(status);

	idval |= (UCHAR)PM11_RegRd(CREG_DATA,handleval);									//Get device ID & OR value in

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);									//Clear PROM enable bit

	return(idval);
}

/**
*
*  PM11_ROMReset()
*  Resets the PM1553-1 PROM to reading data.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_ROMReset(HANDLE handleval)
{
	PM11_ROMWr(0xF0,0x0000,handleval);									//Write 1-cycle reset command
}

/**
*
*  PM11_MemFill()
*  Fills the PM1553-1 memory with the value specified
*  Arguments:
*    fillval: 16 bit value to fill PM1553-1 memory with
*    range:   Upper limit of memory to fill
*    handleval: card handle
*  Returns:  1 word from memory
*  Warnings: None
*
**/

VOID PM11_MemFill(USHORT fillval,USHORT range,HANDLE handleval)
{
	USHORT index;														//Memory address index

	PM11_RegBitClr(PROM_ENABLE,CREG_MISC,handleval);					//Deselect PROM

	PM11_RegWr(0x0020,CREG_ADDR,handleval);								//Write memory base address

	for (index=0x0020;index<=range;index++)
	{
		PM11_RegWr(fillval,CREG_DATA_INC,handleval);					//Write data to post-increment register
	}
}

/**
*
*  PM11_MemGetSize()
*  Gets the memory size of the PM1553-1.
*  Arguments:
*    handleval: card handle
*  Returns:  Memory size in 16-bit words	
*  Warnings: This function will overwrite some memory addresses
*
**/

USHORT PM11_MemGetSize(HANDLE handleval)
{
	USHORT addr;
	USHORT read;														//Memory compare 

	addr = 0x0020;
	PM11_SummitWr(0xAAAA,addr,handleval);								//Write known value to base memory

	for (addr=0x0040;addr<=0x4000;addr=(addr<<1))						//Loop through memory addresses 
	{
		PM11_SummitWr(0x1234,(USHORT)(addr+0x0020),handleval);			//Write known value to memory, w/ offset for registers

		read = PM11_SummitRd(0x0020,handleval);							//Read base memory location

		if (read != 0xAAAA)												//If we overwrote base memory...
		{
			addr = (addr>>1);											//Set upper memory to 1 less than what failed
			break;
		}
		else if (addr==0x4000)											//Max memory addr bits tested
		{
			addr = 0x8000;												//Set max memory availiable
			break;
		}
	}

	return(addr);
}

/**
*
*  PM11 RT functions
*
**/

/**
*
*  PM11_RTAddrSet()
*  Sets the RT address of the PM1553-1.
*  Arguments:
*    rtaddr:  RT address
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_RTAddrSet(USHORT rtaddr,HANDLE handleval)
{
	USHORT index;														//Loop index
	USHORT mask;														//Bitmask
	USHORT par;															//Parity bit

	PM11_SummitBitClr(0xFC00,SREG_OPSTAT,handleval);					//Clear old rt address & parity

	//
	//  This sequence figures out the correct (odd) RT parity
	//

	for (par=1,index=0;index<=4;index++)								//Loop through RTA bits
	{
		mask = 1<<index;												//Set mask to current bit position
		if (rtaddr & mask)												//If a ones bit
		{
			par = !par;													//Swap parity
		}
	}
	
	rtaddr = (rtaddr<<11);												//Shift RTA
	par = (par<<10);													//Shift RT parity

	rtaddr |= par;														//OR in parity bit

	PM11_SummitBitSet(rtaddr,SREG_OPSTAT,handleval);
}


/**
*
*  PM11_RTDescBlockWr()
*  Sets a RT descriptor block into PM1553-1 memory.
*  Arguments:
*    descblock: pointer to RTDESCBLOCK structure
*    handleval: card handle
*  Returns:  None
*  Warnings: 
*
**/

VOID PM11_RTDescBlockWr(RTDESCBLOCK* descblock,HANDLE handleval)
{
	PM11_RegWr(descblock->baseaddr,CREG_ADDR,handleval);				//Set address

	PM11_RegWr(descblock->ctrlwrd, CREG_DATA_INC,handleval);			//Write to post-increment register
	PM11_RegWr(descblock->dptra,   CREG_DATA_INC,handleval);			//Write to post-increment register
	PM11_RegWr(descblock->dptrb,   CREG_DATA_INC,handleval);			//Write to post-increment register
	PM11_RegWr(descblock->bcastptr,CREG_DATA_INC,handleval);			//Write to post-increment register
}

/**
*
*  PM11_RTDescBlockRd()
*  Reads an RT descriptor block from PM1553-1 memory.
*  Arguments:
*    descblock: pointer to RTDESCBLOCK structure
*    handleval: card handle
*  Returns:  None
*  Warnings: 
*
**/

VOID PM11_RTDescBlockRd(RTDESCBLOCK* descblock,HANDLE handleval)
{
	PM11_RegWr(descblock->baseaddr,CREG_ADDR,handleval);				//Set address

	descblock->ctrlwrd  = PM11_RegRd(CREG_DATA_INC,handleval);			//Read from post-increment register
	descblock->dptra    = PM11_RegRd(CREG_DATA_INC,handleval);			//Read from post-increment register
	descblock->dptrb    = PM11_RegRd(CREG_DATA_INC,handleval);			//Read from post-increment register
	descblock->bcastptr = PM11_RegRd(CREG_DATA_INC,handleval);			//Read from post-increment register
}

/**
*
*  PM11 BC functions
*
**/

/**
*
*  PM11_BCCmdBlockWr()
*  Sets a BC command block into PM1553-1 memory.
*  Arguments:
*    cmdblock: pointer to CMDBLOCK structure
*    handleval: card handle
*  Returns:  None
*  Warnings: 
*
**/

VOID PM11_BCCmdBlockWr(CMDBLOCK* cmdblock,HANDLE handleval)
{
	USHORT index;														//Loop index

	//
	//  This sequence sets the word count (WC) value. A WC value of 00000B 
	//  means 32 data words
	//

	cmdblock->datacount = (cmdblock->cwd1 & 0x001F);
	if (cmdblock->datacount==0) cmdblock->datacount = 32;

	PM11_RegWr(cmdblock->baseaddr,CREG_ADDR,handleval);						//Set address

	PM11_RegWr(cmdblock->ctrlwrd,   CREG_DATA_INC,handleval);				//Set command block control word
	PM11_RegWr(cmdblock->cwd1,      CREG_DATA_INC,handleval);				//Set CWD 1
	PM11_RegWr(cmdblock->cwd2,      CREG_DATA_INC,handleval);				//Set CWD 2
	PM11_RegWr(cmdblock->dataptr,   CREG_DATA_INC,handleval);				//Set data pointer
	PM11_RegWr(0x0000,              CREG_DATA_INC,handleval);				//Set SWD1 = 0000
	PM11_RegWr(0x0000,              CREG_DATA_INC,handleval);				//Set SWD2 = 0000
	PM11_RegWr(cmdblock->branchaddr,CREG_DATA_INC,handleval);				//Set branch-to address
	PM11_RegWr(cmdblock->timeval,   CREG_DATA_INC,handleval);				//Set timer value

	PM11_RegWr(cmdblock->dataptr,CREG_ADDR,handleval);						//Set address for data words
	
	//
	//  This sequence checks whether a RCV or XMT command was set in CWD1, and
	//  sets or clears the associated data word(s) accordingly
	//

	if (cmdblock->cwd1 & 0x0400)											//If T/R bit set in CWD (RT transmit to BC)
	{
		for (index=0;index<(cmdblock->datacount);index++)					//Loop through data
		{
			PM11_RegWr(0x0000,CREG_DATA_INC,handleval);						//Clear data in buffer
		}
	}
	else																	//RT recieve from BC
	{
		for (index=0;index<(cmdblock->datacount);index++)					//Loop through data
		{
			PM11_RegWr(cmdblock->data[index],CREG_DATA_INC,handleval);		//Set data
		}
	}
}

/**
*
*  PM11_BCCmdBlockRd()
*  Reads a BC command block from PM1553-1 memory.
*  Arguments:
*    cmdblock:  pointer to monitor data structure
*    handleval: card handle
*  Returns:  None
*  Warnings: None 
*
**/

VOID PM11_BCCmdBlockRd(CMDBLOCK* cmdblock,HANDLE handleval)
{
	USHORT index;															//Loop index
	PM11_RegWr(cmdblock->baseaddr,CREG_ADDR,handleval);						//Set address

	cmdblock->ctrlwrd    = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->cwd1       = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->cwd2       = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->dataptr    = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->swd1       = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->swd2       = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->branchaddr = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register
	cmdblock->timeval    = PM11_RegRd(CREG_DATA_INC,handleval);				//Read from post-increment register

	//
	//  This sequence sets the word count (WC) value. A WC value of 00000B 
	//  means 32 data words
	//

	cmdblock->datacount = (cmdblock->cwd1 & 0x001F);						//Set word count
	if (cmdblock->datacount==0) cmdblock->datacount = 32;

	PM11_RegWr(cmdblock->dataptr,CREG_ADDR,handleval);						//Set address for data words

	for (index=0;index<(cmdblock->datacount);index++)						//Loop through data
	{
		cmdblock->data[index] = PM11_RegRd(CREG_DATA_INC,handleval); 
	}
}

/**
*
*  PM11 Monitor functions
*
**/

/**
*
*  PM11_MonBlockRd()
*  Reads a monitor block from PM1553-1 memory.
*  Arguments:
*    monblock:  pointer to monitor data structure
*    handleval: card handle
*  Returns:  None
*  Warnings: None 
*
**/

VOID PM11_MonBlockRd(MONBLOCK* monblock,HANDLE handleval)
{

	USHORT index;															//Loop index

	PM11_RegWr(monblock->baseaddr,CREG_ADDR,handleval);						//Set base address of monitor block

	monblock->msginfowrd = PM11_RegRd(CREG_DATA_INC,handleval);				//Get info word
	monblock->cwd1		 = PM11_RegRd(CREG_DATA_INC,handleval);				//Get CWD1
	monblock->cwd2		 = PM11_RegRd(CREG_DATA_INC,handleval);				//Get CWD2
	monblock->dataptr	 = PM11_RegRd(CREG_DATA_INC,handleval);				//Get data pointer
	monblock->swd1		 = PM11_RegRd(CREG_DATA_INC,handleval);				//Get SWD1
	monblock->swd2       = PM11_RegRd(CREG_DATA_INC,handleval);				//Get SWD2 
	monblock->timeval    = PM11_RegRd(CREG_DATA_INC,handleval);				//Get timetag 

	PM11_RegRd(CREG_DATA_INC,handleval);									//Read unused position from monitor block and throw away:
																			//This post-increments the ADDR register in the PM1553-1
	//
	//  This sequence sets the word count (WC) value. A WC value of 00000B 
	//  means 32 data words
	//

	monblock->datacount = (monblock->cwd1 & 0x001F);
	if (monblock->datacount==0) monblock->datacount = 32;

	PM11_RegWr(monblock->dataptr,CREG_ADDR,handleval);						//Set monitor data pointer

	for (index=0;index<monblock->datacount;index++)							//Read data words
	{
		monblock->data[index] = PM11_RegRd(CREG_DATA_INC,handleval);		//Read data form post-increment register
	}
}

/**
*
*  PM11 LED functions
*
**/

/**
*
*  PM11_LEDIsSet()
*  Checks if the user LED is set.
*  Arguments:
*    handleval: card handle
*  Returns:  Non-zero if LED set, FALSE if not set
*  Warnings: None
*
**/

BOOL PM11_LEDIsSet(HANDLE handleval)
{
	return(PM11_RegRd(CREG_MISC,handleval) & LED_SET);						//Filter and return LED status bit
}
	
/**
*
*  PM11_LEDWr()
*  Sets or resets the user LED.
*  Arguments:
*    val:  TRUE to set LED, FALSE to reset
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_LEDWr(BOOL val,HANDLE handleval)
{
	if (val)
	{
		PM11_RegBitSet(LED_SET,CREG_MISC,handleval);
	}
	else
	{
		PM11_RegBitClr(LED_SET,CREG_MISC,handleval);
	}
}

/**
*
*  PM11_LEDBlink()
*  Blinks the user LED once (on, off).
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: This function uses the SSF timer, and will cause the SSFSRQ bit to be set
*            in register 0.
*
**/

VOID PM11_LEDBlink(HANDLE handleval)
{
	USHORT timeval = 1;														//Timer value
	USHORT period = 0xFF;													//Change this value to change LED frequency

	PM11_LEDWr(TRUE,handleval);												//Set LED
	PM11_TimerWr(period,handleval);											//255 msec

	do																		//Wait for timer to count down
	{
		timeval = PM11_TimerRd(handleval);									//Read timer val
	} while(timeval);

	PM11_LEDWr(FALSE,handleval);											//Reset LED
	PM11_TimerWr(period,handleval);											//255 msec

	timeval = 1;															//Reinit timeval

	do																		//Wait for timer to count down
	{
		timeval = PM11_TimerRd(handleval);									//Read timer val
	} while(timeval);
}

/**
*
*  PM11 Timer functions
*
**/

/**
*
*  PM11_TimerConfig()
*  Configures the PM1553-1 timer.
*  Arguments:
*    cfgflags: TIMER_MODE_FREE or TIMER_MODE_ONCE
*    handleval: card handle
*  Returns:  None
*  Warnings: The timer cannot be stopped after being started except by a card or system reset
*
**/

VOID PM11_TimerConfig(USHORT cfgflags,HANDLE handleval)
{
	if (cfgflags)
	{
		PM11_RegBitSet(TIMER_MODE,CREG_MISC,handleval);
	}
	else
	{
		PM11_RegBitClr(TIMER_MODE,CREG_MISC,handleval);
	}
}

/**
*
*  PM11_TimerRd()
*  Reads the value of the SSF timer.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

USHORT	PM11_TimerRd(HANDLE handleval)
{
	return(PM11_RegRd(CREG_TIMERS,handleval) & 0x00FF);			//Filter and return the timer value
}

/**
*
*  PM11_TimerWr()
*  Writes a value to the SSF timer.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_TimerWr(USHORT timeval,HANDLE handleval)
{
	PM11_RegBitSet((USHORT)(timeval & 0xFF),CREG_TIMERS,handleval);
}

/**
*
*  PM11_TimerSSFEn()
*  Enables SSF on timer countdown.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: The SSF timer cannot be stopped after being started except by a card or system reset
*
**/

VOID PM11_TimerSSFEn(HANDLE handleval)
{
	PM11_RegBitSet(SSF_TIMER_EN,CREG_MISC,handleval);
}

/**
*
*  PM11_TimerSSFDis()
*  Disables SSF on timer countdown.
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: The SSF timer cannot be stopped after being started except by a card or system reset
*
**/

VOID PM11_TimerSSFDis(HANDLE handleval)
{
	PM11_RegBitSet(SSF_TIMER_EN,CREG_MISC,handleval);
}

/**
*
*  PM11 DIN functions
*
**/

/**
*
*  PM11_DINIsSet()
*  Checks whether the specified DIN of the PM1553-1 is set.
*  Arguments:
*    din:  DIN(s) to check
*    handleval: card handle
*  Returns:  non-zero value if set, FALSE if not
*  Warnings: None
*
**/

BOOL PM11_DINIsSet(USHORT mask,HANDLE handleval)
{
	return(PM11_RegRd(CREG_MISC,handleval) & mask);
}

/**
*
*  PM11_DINConfig()
*  Configures the digital inputs of the PM1553-1 is set.
*  Arguments:
*    resolution: TIMER_RES_4US or TIMER_RES_4MS
*    period:     period in timer ticks
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_DINConfig(USHORT resolution,USHORT period,HANDLE handleval)
{
	period = (period<<8);										//Shift period to proper position
	resolution |= period;										//OR period and resolution
	PM11_RegBitSet(resolution,CREG_TIMERS,handleval);			//Set bits in TIMERS register
}

/**
*
*  PM11 DOUT functions
*
**/

/**
*
*  PM11_DOUTWr()
*  Sets the specified digital output (DOUT) of the PM1553-1.
*  Arguments:
*    dout:  DOUT to set
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_DOUTSet(USHORT dout,HANDLE handleval)
{
	PM11_RegBitSet(dout,CREG_MISC,handleval);
}

/**
*
*  PM11_DOUTIsSet()
*  Checks if the specified digital output (DOUT) of the PM1553-1 is set.
*  Arguments:
*    dout: DOUT to set
*    handleval: card handle
*  Returns:  Non-zero if set, FALSE if not
*  Warnings: None
*
**/

BOOL PM11_DOUTIsSet(USHORT dout,HANDLE handleval)
{
	return(PM11_RegRd(CREG_MISC,handleval) & dout);				//Filter and return the dout status
}

/**
*
*  PM11_DOUTClr()
*  Clears the specified digital output (DOUT) of the PM1553-1.
*  Arguments:
*    dout: DOUT to set
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_DOUTClr(USHORT dout,HANDLE handleval)
{
	PM11_RegBitClr(dout,CREG_MISC,handleval);
}

/**
*
*  PM11 Interrupt/SRQ Functions
*
**/

/**
*
*  PM11_SRQClr()
*  Clears the specified SRQ of the PM1553-1.
*  Arguments:
*    mask: SRQ(s) to clear (SSFSRQ,etc.)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_SRQClr(USHORT mask,HANDLE handleval)
{
	PM11_RegBitSet(mask,CREG_STATUS,handleval);
}

/**
*
*  PM11_SRQRd()
*  Reads value of the specified SRQ(s) of the PM1553-1.
*  Arguments:
*    mask: SRQ(s) to clear (SSFSRQ,etc.)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

USHORT PM11_SRQRd(USHORT mask,HANDLE handleval)
{
	return(PM11_RegRd(CREG_STATUS,handleval) & mask);
}

/**
*
*  PM11_IntInstall()
*  Installs an interrupt handler for the PM1553-1
*  Arguments:
*    hEvent:    event object to set
*    handleval: card handle
*  Returns:  TRUE if successful, otherwise FALSE
*  Warnings: None
*
**/

BOOL PM11_IntInstall(HANDLE hEvent,HANDLE handleval)
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
*  PM11_IntUninstall()
*  Uninstalls the interrupt handler for the PM1553-1
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_IntUninstall(HANDLE handleval)
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
*  PM11_IntEnable()
*  Enables interrupts to the host from a specified source on the PM1553-1.
*  Arguments:
*    intsource: interrupt source (MSGIEN, etc.)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_IntEnable(USHORT intsource,HANDLE handleval)
{
	PM11_RegBitSet((USHORT)(PCIEN | intsource),CREG_INTCFG,handleval);
}

/**
*
*  PM11_IntDisable()
*  Disables interrupts to the host from a specified source on the PM1553-1.
*  Arguments:
*    intsource: interrupt source (MSGIEN, PCIEN (disables all), etc.)
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11_IntDisable(USHORT intsource,HANDLE handleval)
{
	PM11_RegBitClr(intsource,CREG_INTCFG,handleval);
}
