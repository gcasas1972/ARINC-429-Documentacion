/**
*
* PM11.C: Library of API functions for the Ballard Technology PM1553-1 Version 1.0 (04/15/2002)
* Copyright (c) 2002
* Ballard Technology, Inc.
* www.ballardtech.com
* support@ballardtech.com
* ALL RIGHTS RESERVED
*
* Function names and descriptions:
*
*  Utility functions
*
*   USHORT  PM11_PackCWD()          -- Builds a MIL-STD-1553 command word from its fields.
*   VOID    PM11_UnpackCWD()        -- Gets the individual fields from a MIL-STD-1553 command word.
*
*  Host I/O functions
*
*   VOID    PM11_Outp()             -- Write 1 byte of data to the specified I/O port.
*   UCHAR   PM11_Inp()              -- Reads 1 byte of data from the specified I/O port.
*   VOID    PM11_OutpW()            -- Writes a 16-bit value to the specified I/O port.
*   USHORT  PM11_InpW()             -- Reads a 16-bit value from the specified I/O port.
*
*  PM11 Register functions
*
*   VOID    PM11_RegWr()            -- Writes a value to the specified PM1553-1 register.
*   USHORT  PM11_RegRd()            -- Reads a value from the specified PM1553-1 register.
*   VOID    PM11_RegClr()           -- Clears (wipes w/ zeros) the specified  PM11 register.
*   VOID    PM11_RegBitSet()        -- Reads the current value from the specified PM11 register, 
*                                       ORs in specified data, and writes result back.
*   VOID    PM11_RegBitClr()        -- Clears the specified flags from the specified PM11 register.
*
*  PM11 Summit register functions
*
*   VOID    PM11_SummitWr()         -- Writes a value to the specified Summit register.
*   USHORT  PM11_SummitRd()         -- Reads a value from the specified Summit register.
*   VOID    PM11_SummitClr()        -- Clears (wipes w/ zeros) the specified Summit register.
*   VOID    PM11_SummitBitSet()     -- Reads the current value from the specified Summit register,
*                                       ORs in specified data, and writes result back.
*   VOID    PM11_SummitBitClr()     -- Clears the specified flags from the specified Summit register.
*
*  PM11 Card/Summit functions
*
*   VOID    PM11_SummitStart()      -- Sets the STEX bit of the Summit.
*   VOID    PM11_SummitStop()       -- Clears the STEX bit of the Summit.
*   BOOL    PM11_SummitIsReady()    -- Checks whether Summit ready is set.
*   VOID    PM11_CardReset()        -- Resets specified PM1553-1.
*   BOOL    PM11_IsCard()           -- Checks if specified PM1553-1 exists.
*   INT     PM11_SelfTest()         -- Performs hardware test of specified PM1553-1.
*   VOID    PM11_ModeSet()          -- Sets the mode of the PM1553-1.
*
*  PM11 PROM/Memory functions
*
*   INT     PM11_ROMWr()            -- Writes one byte to the PM1553-1 PROM.
*   UCHAR   PM11_ROMRd()            -- Reads one byte from the PM1553-1 PROM.
*   INT     PM11_ROMWipe()          -- Erases the PM1553-1 PROM.
*   INT     PM11_ROMWipeSect()      -- Erases the specified sector of the PM1553-1 PROM
*   INT     PM11_ROMWrIsComplete()  -- Checks whether a write to the PM1553-1 PROM completed correcetly.
*   INT     PM11_ROMGetIDVal()      -- Gets the ID value of the PM1553-1 PROM.
*   VOID    PM11_MemFill()          -- Fills the memory of the PM1553-1 from the base to the specified
*                                       range with the specified value.
*   USHORT  PM11_MemGetSize()       -- Returns the memory size (in 16-bit words) of the PM1553-1.
*
*  PM11 RT functions
*
*   VOID    PM11_RTAddrSet()        -- Sets the RT address of the PM1553-1
*   VOID    PM11_RTDescBlockWr()    -- Writes an RTDESCBLOCK structure to the PM1553-1.
*   VOID    PM11_RTDescBlockRd()    -- Reads data from the PM1553-1 into an RTDESCBLOCK structure.
*
*  PM11 BC functions
*
*   VOID    PM11_BCCmdBlockWr()     -- Writes a BCCMDBLOCK structure to the PM1553-1.
*   VOID    PM11_BCCmdBlockRd()     -- Reads data fron the PM1553-1 into a BCCMDBLOCK structure.
*
*  PM11 LED functions
*
*   BOOL    PM11_LEDIsSet()         -- Reads status of external LED
*   VOID    PM11_LEDWr()            -- Turns LED on or off
*   VOID    PM11_LEDBlink()         -- Blinks user LED once (on, off)
*
*  PM11 Monitor functions
*
*   VOID    PM11_MonBlockRd()       -- Reads data fronm the PM1553-1 into a MONBLOCK structure.
*
*
*  PM11 Timer functions
* 
*   VOID    PM11_TimerConfig()      -- Configures on-board timer.
*   VOID    PM11_TimerStart()       -- Starts on-board timer.
*   UINT    PM11_TimerRd()          -- Reads on-board timer.
*   VOID    PM11_TimerWr()          -- Writes value to on-board timer.
*   VOID    PM11_TimerSSFEn()       -- Enables SSF on timer.
*   VOID    PM11_TimerSSFDis()      -- Disables SSF on timer.
* 
*  PM11 DIN functions
* 
*   BOOL    PM11_DINIsSet()         -- Reads value of specified DIN
*   VOID    PM11_DINConfig()        -- Configures digital inputs
*   USHORT  PM11_DINSRQClr()        -- Clears SRQ set by specified DIN
* 
*  PM11 DOUT functions
* 
*   VOID    PM11_DOUTSet()          -- Sets specified DOUT
*   BOOL    PM11_DOUTIsSet()        -- Reads specified DOUT
*   VOID    PM11_DOUTClr()          -- Clears specified DOUT
*
*  PM11 Interrupt/SRQ functions
*
*   VOID    M11_SRQClr()            -- Clears specified SRQ bit(s) in CREG_STAT
*   VOID    PM11_SRQRd()            -- Reads the SRQ bit(s) set in CREG_STAT
*   VOID    PM11_IntEnable()        -- Enables card interrupts to host
*   VOID    PM11_IntDisable()       -- Disables card interrupts to host
*
**/

/**
*
*  PM1553-1 include file
*
**/

#include "PM11.h"


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
*  Returns:  None
*  Warnings: None
*
**/
USHORT PM11_PackCWD(INT TAval,INT TRval,INT SAval,INT WCval)
{
	return(USHORT)( (((USHORT)TAval&0x1F)<<11) + (((USHORT)TRval&0x01)<<10) + (((USHORT)SAval&0x1F)<<5) + (((USHORT)WCval&0x1F)<<0) );
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
	if (TAval) *TAval = (INT)(((USHORT)CWDval>>11) & 0x1F); // shift and filter TA
	if (TRval) *TRval = (INT)(((USHORT)CWDval>>10) & 0x01); // shift and filter T/R
	if (SAval) *SAval = (INT)(((USHORT)CWDval>> 5) & 0x1F); // shift and filter SA
	if (WCval) *WCval = (INT)(((USHORT)CWDval>> 0) & 0x1F); // shift and filter WC
}

/**
*
*  Host I/O functions
*
**/

/**
*
*	PM11_Outp()
*	Write 1 byte of data to the specified I/O port
*	Arguments:
*		data: data to write
*		port: I/O port to write to
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_Outp(UCHAR data, USHORT port)
{
#ifdef _MSC_VER         // if using MS Visual C, use the MS name
	_outp(port, data);  // COMPILER_DEP Note that data and port are reversed for _outp()
	return;
#else
	outp(port, data);   // COMPILER_DEP Note that data and port are reversed for outp()
#endif                  // _MSC_VER
}

/**
*
*	PM11_Inp()
*	Reads 1 byte of data from the specified I/O port
*	Arguments:
*		port: I/O port to write to
*	Returns:  Data read
*	Warnings: None
*
**/

UCHAR PM11_Inp(USHORT port)
{
#ifdef _MSC_VER                     // if using MS Visual C, use the MS name
	UCHAR val = (UCHAR)_inp(port);  // COMPILER_DEP
	return val;
#else
	UCHAR val = (UCHAR)inp(port);   // COMPILER_DEP
	return val;
#endif                              // _MSC_VER
}

/**
*
*	PM11_OutpW()
*	Writes a 16-bit value to the specified I/O port.
*	Arguments:
*		data: data to write
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_OutpW(USHORT data, USHORT port)
{

#ifndef _16BIT_W    // if 8-bit only
	{
		USHORT low_b;
		USHORT high_b;

		low_b  = (data & 0x00FF);  // get low byte
		high_b = (data & 0xFF00);  // get high byte
		high_b = (high_b >> 8);    // shift high byte

		PM11_Outp((UCHAR)low_b, port);      // write low byte
		PM11_Outp((UCHAR)high_b, port+1);   // write high byte

		return;
	}
#endif  // _16BIT_W

#ifdef _MSC_VER              // if using MS Visual C, use the MS name
		_outpw(port, data);  // COMPILER_DEP Note that data and port are reversed
		return;
#else
		outpw(port, data);   // COMPILER_DEP Note that data and port are reversed
#endif                       // _MSC_VER

}

/**
*
*	PM11_InpW()
*	Reads a 16-bit value from the specified I/O port.
*	Arguments:
*		port: port to read from
*	Returns:  data read
*	Warnings: None
*
**/

USHORT PM11_InpW(USHORT port)
{

#ifndef _16BIT_R // if 8-bit only
	{
		USHORT low_b;
		USHORT high_b;

		low_b  = PM11_Inp(port);    // read low byte
		high_b = PM11_Inp(port+1);  // Read high byte

		return ((high_b << 8) | low_b);  // OR high and low bytes together
	}
#endif  // _16BIT_R

#ifdef _MSC_VER              // if using MS Visual C, use the MS name
		return _inpw(port);  // COMPILER_DEP
#else
		return inpw(port);   // COMPILER_DEP
#endif	// _MSC_VER
}

/**
*
*	PM11 Register functions
*
**/


/**
*
*	PM11_RegWr()
*	Writes a value to the specified PM1553-1 register.
*	Arguments:
*		data: Data to write
*		reg:  PM11 register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
**/

VOID PM11_RegWr(USHORT data, USHORT reg, USHORT port)
{
	PM11_OutpW(data, (USHORT)(port+reg));  // write data
}

/**
*
*	PM11_RegRd()
*	Reads a value from the specified PM1553-1 register.
*	Arguments: 
*		reg:  PM11 register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

USHORT PM11_RegRd(USHORT reg, USHORT port)
{
	return PM11_InpW((USHORT)(port+reg));	// if reading from IFGA, get value


}

/**
*
*	PM11_RegClr()
*	Clears (wipes w/ zeros) the specified PM11 register.
*	Arguments: 
*		reg:  PM11 register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_RegClr(USHORT reg, USHORT port)
{
	PM11_RegWr(0x0000, reg, port); // write 0s to register
}

/**
*
*	PM11_RegBitSet()
*	Reads the current value from the specified PM11 register, 
*		ORs in specified data, and writes result back.
*	Arguments: 
*		mask: Data to write
*		reg:  PM11 register
*	Returns:  None
*	Warnings: Only adds settings -- does not clear any bits. Use PM11_RegBitClr() to clear bits
*
**/

VOID PM11_RegBitSet(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;	// data to be read

	data = PM11_RegRd(reg, port);  // read data from register
	data = (mask | data);          // OR new values in

	PM11_RegWr(data, reg, port);   // write back new data
}


/**
*
*	PM11_RegBitClr()
*	Clears the specified flags from the specified PM11 register.
*	Arguments: 
*		mask: Data to clear
*		reg:  PM11 register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_RegBitClr(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;				// data to be read

	data = PM11_RegRd(reg, port);	// get current register value

	mask = (~mask);				// set bitmask to its complement
	mask = (mask & data);		// AND new value of mask w/ register contents

	PM11_RegWr(mask,reg,port);	// write value back
}

/**
*
*	PM11 Summit Register functions
*
**/

/**
*
*	PM11_SummitWr()
*	Writes the specified data to the specified PM1553-1 SuMMIT register.
*	Arguments: 
*		data: Data to write
*		reg:  SuMMIT register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_SummitWr(USHORT data, USHORT addr, USHORT port) 
{
	PM11_OutpW(addr, (USHORT)(port+CREG_ADDR));  // write address
	PM11_OutpW(data, (USHORT)(port+CREG_DATA));  // write data
}

/**
*
*	PM11_SummitRd()
*	Reads the  data of the specified PM1553-1 SuMMIT register.
*	Arguments: 
*		reg:  SuMMIT register
*		port: PM1553-1 port setting
*	Returns:  Data from SuMMIT register
*	Warnings: None
*
**/

USHORT PM11_SummitRd(USHORT addr, USHORT port)
{
	PM11_OutpW(addr, (USHORT)(port+CREG_ADDR));  // write address
	return PM11_InpW((USHORT)(port+CREG_DATA));  // get value
}

/**
*
*	PM11_SummitClr()
*	Clears (wipes w/ zeros) the specified PM1553-1 SuMMIT register.
*	Arguments: 
*		reg:  SuMMIT register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_SummitClr(USHORT reg, USHORT port)
{
	PM11_SummitWr(0x0000, reg, port);
}

/**
*
*	PM11_SummitBitSet()
*	Reads the current value from the specified PM1553-1 SuMMIT register, 
*		ORs in specified data, and writes result back.
*	Arguments: 
*		mask: Bits to set
*		reg:  SuMMIT register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_SummitBitSet(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;    // data to be read

	PM11_RegWr(reg, CREG_ADDR, port);    // set ADDR register
	data = PM11_RegRd(CREG_DATA, port);  // read data from register
	data = (mask | data);                // OR new values in

	PM11_RegWr(data, CREG_DATA, port);   // write back new data
}
	
/**
*
*	PM11_SummitBitSet()
*	Clears the specified flags from the specified PM1553-1 SuMMIT register.
*	Arguments: 
*		mask: Bits to clear
*		reg:  SuMMIT register
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_SummitBitClr(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;  // data to be read

	PM11_RegWr(reg, CREG_ADDR, port);    // set ADDR register
	data = PM11_RegRd(CREG_DATA, port);  // get current register value

	mask = (~mask);            // set bitmask to its complement
	mask = (mask & data);      // AND new value of mask w/ register contents

	PM11_RegWr(mask,CREG_DATA,port);     // write value back
}

/**
*
*	PM11 Card/Summit functions
*
**/

/**
*
*	PM11_SummitStart()
*	Starts operation of the PM1553-1.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_SummitStart(USHORT port)
{
	PM11_SummitBitSet(STEX, SREG_CTRL, port);
}

/**
*
*	PM11_SummitStop()
*	Stops operation of the PM1553-1.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_SummitStop(USHORT port)
{
	PM11_SummitBitClr(STEX, SREG_CTRL, port);
}

/**
*
*	PM11_SummitIsReady()
*	Checks whether the PM1553-1 Summit is ready.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  Non-zero if ready, FALSE if not
*	Warnings: None
*
**/	

BOOL PM11_SummitIsReady(USHORT port)
{
	return(PM11_RegRd(CREG_STATUS, port) & READY);
}

/**
*
*	PM11_CardReset()
*	Resets specified PM1553-1.
*	Arguments:
*		port: PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*/

VOID PM11_CardReset(USHORT port)
{
	PM11_RegWr(0x0, CREG_RESET, port);                  // write to reset register
	while( !(PM11_RegRd(CREG_STATUS, port) & READY) );  // wait for READY to active
}



/**
*
*	PM11_IsCard()
*	Checks if specified PM1553-1 exists
*	Arguments:
*		port: PM1553-1 port setting
*	Returns:  TRUE is card present, FALSE if not
*	Warnings: None
*
**/	

BOOL PM11_IsCard(USHORT port)	
{
	USHORT val;    // holds ID register value

	val = PM11_RegRd(CREG_ID, port);    // read ID register
	val = (val & 0xFFF0);               // filter for relevant value (version ignored)
	
	if(val == IDVAL)  // if correct ID value
	{
		return TRUE;
	}
	return FALSE;
}

/**
*
*	PM11_SelfTest()
*	Performs a hardware test of the PM1553-1
*	Arguments:
*		iobase: PM1553-1 port setting
*		irq:	IRQ to use
*	Returns:  0 if successful, negative value if not
*	Warnings: None
*
**/	

INT PM11_SelfTest(USHORT iobase, USHORT irq)
{
	USHORT count;  // loop counter
	USHORT read;

	// Verify IO address and IRQ are valid
	if((iobase < IOBASE_MIN) || (iobase > IOBASE_MAX))  return ERR_BADPARAMS;  // outside valid IO range
	if(iobase & 0x00F)                                  return ERR_BADPARAMS;  // does not end in 0

	if((irq >= 0) && (irq <= 12))  // Only IRQ 3,4,5,7,9,10,11,12 are valid; IRQ 0 skips interrupt tests
	{
		if(irq == 1)  return ERR_BADPARAMS;
		if(irq == 2)  return ERR_BADPARAMS;
		if(irq == 6)  return ERR_BADPARAMS;
		if(irq == 8)  return ERR_BADPARAMS;
	}
	else
	{
		return ERR_BADPARAMS;
	}

	// Verify Card is present
	if(!PM11_IsCard(iobase)) return ERR_NOCARD;

	// Verify IFGA is accessible
	PM11_CardReset(iobase);
	PM11_RegWr(0x1200, CREG_INTCFG, iobase);  // write to INTCFG register
	if( (PM11_RegRd(CREG_INTCFG, iobase) & 0xFF00) != 0x1200) return ERR_SELFIOFAIL;

	// Initiate BIST
	PM11_SummitWr(SBIT, SREG_CTRL, iobase);
	PM11_RegWr(0x00FF, CREG_TIMERS, iobase);  // write max value to timer
	while( (!(PM11_SummitIsReady(iobase))) && (PM11_RegRd(CREG_TIMERS, iobase)) );  // wait for READY or timeout
	if( !(PM11_RegRd(CREG_TIMERS, iobase)))  return ERR_BITFAIL;  // Timed out waiting for READY
	if(PM11_SummitRd(SREG_BITWORD, iobase)) return ERR_BITFAIL;

	// Verify Interrupts  // COMPILER_DEP
	if(irq)
	{
		PM11_CardReset(iobase);

		// Configure card for timer interrupt
		PM11_IntEnable(SSFSRQ,iobase);

		// Verify card present/jumper on
		if (irq>7)
		{
			PM11_Outp(0x0A,SEC_INT+0);	//Point to IR register
			if((PM11_Inp(SEC_INT+0)>>(irq - 8)) & 0x01)	return ERR_IRQFAIL;
		}
		else
		{
			PM11_Outp(0x0A,MAST_INT+0);	//Point to IR register
			if((PM11_Inp(MAST_INT+0)>>(irq - 0)) & 0x01)	return ERR_IRQFAIL;
		}

		// Trigger interrupt
		PM11_TimerSSFEn(iobase);
		PM11_TimerConfig(TIMER_MODE_ONCE, iobase);
		PM11_TimerWr(0x0001,iobase);

		read = 1;
		count = 1000;
		while(read && count)
		{
			read = PM11_TimerRd(iobase);
			count--;
		}

		// Verify interrupt set in controller
		if (irq>7)
		{
			PM11_Outp(0x0A,SEC_INT+0);	//Point to IR register
			if(!(PM11_Inp(SEC_INT+0)>>(irq - 8)) & 0x01)	return ERR_IRQFAIL;
			PM11_Outp(EOI, SEC_OCW);
		}
		else
		{
			PM11_Outp(0x0A,MAST_INT+0);	//Point to IR register
			if(!(PM11_Inp(MAST_INT+0)>>(irq - 0)) & 0x01)	return ERR_IRQFAIL;
			PM11_Outp(EOI, MAST_OCW);
		}


		// Clear interrupt
		PM11_SRQClr(SSFSRQ,iobase);

	}


	// Blink USER LED
	PM11_LEDBlink(iobase);

	PM11_CardReset(iobase);

	return ERR_NONE;
}

/**
*
*	PM11_ModeSet()
*	Sets the mode of the PM1553-1.
*	Arguments:
*		mode:  mode (MODE_RT, etc.)
*		port:  PM1553-1 port setting
*	Returns:  None
*	Warnings: Do not attempt to use this function on an RT-only PM1553-1. (P/N PM1553-1/x1x or /x3x )
*	          This function will clear all other settings in the OPSTAT register
*
**/

VOID PM11_ModeSet(USHORT modeval, USHORT port)
{
	PM11_SummitWr(modeval, SREG_OPSTAT, port);
}

/**
*
*	PM11 PROM/Memory functions
*
**/

/**
*
*	PM11_ROMWr()
*	Writes a 8-bit byte to the onboard EEPROM.
*	Arguments:
*		data: Data to write
*		addr: Address
*		port: PM1553-1 port setting
*	Returns:  0 if successful, -1 if write failed
*	Warnings: This function cannot rewrite data without a previous erase cycle.
*			 
**/	

INT PM11_ROMWr(UCHAR data, UINT addr, USHORT port)
{
	INT status;    // pass/fail value

	PM11_RegBitSet(PROM_ENABLE, CREG_MISC, port);  // OR in PROM enable bit

	// This sequence enables a write to the PROM 

	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xAA, CREG_DATA, port);
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	PM11_RegWr(0x55, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xA0, CREG_DATA, port);

	PM11_RegWr((USHORT)((addr & 0x10000)>>16), CREG_ADDR, port);
	PM11_RegWr((USHORT)(addr & 0xFFFF), CREG_ADDR, port);

	PM11_OutpW(data, (USHORT)(port+CREG_DATA_INC));  // write data to data register

	status = PM11_ROMWrIsComplete(port);             // check for successful write

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);    // clear PROM enable bit
	return status;
}

/**
*
*	PM11_ROMRd()
*	Reads a 8-bit byte from the specified address of the onboard EEPROM.
*	Arguments:
*		addr: Address to read from
*		port: PM1553-1 port setting
*	Returns:  1 byte from PROM
*	Warnings: This function does NOT check if the PROM is installed.
*
**/

UCHAR PM11_ROMRd(UINT addr, USHORT port)
{
	UCHAR data;    // holds data from PROM

	PM11_RegBitSet(PROM_ENABLE, CREG_MISC, port);    // OR in PROM enable bit

	PM11_RegWr((USHORT)((addr & 0x10000)>>16), CREG_ADDR, port);
	PM11_RegWr((USHORT)(addr & 0xFFFF),        CREG_ADDR, port);

	data = (UCHAR)PM11_RegRd(CREG_DATA, port);       // read from data register

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);    // clear PROM enable bit
	return data;
}

/**
*
*	PM11_ROMWipe()
*	Erases the entire PM1553-1 PROM.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  0 if successful, -1 if PROM failed to erase
*	Warnings: None
*
**/	

INT PM11_ROMWipe(USHORT port)
{
	INT status;  // pass/fail value

	PM11_RegBitSet(PROM_ENABLE, CREG_MISC, port);    // OR in PROM enable bit

	// This sequence enables chip erase of the PROM 

	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xAA, CREG_DATA, port);
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	PM11_RegWr(0x55, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0x80, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xAA, CREG_DATA, port);
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	PM11_RegWr(0x55, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0x10, CREG_DATA, port);

	status = PM11_ROMWrIsComplete(port);    // check for erase to complete

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);  // clear PROM enable bit

	return status;
}

/**
*
*	PM11_ROMWipeSect()
*	Erases a 16Kbyte sector of the PM1553-1 PROM.
*	Arguments:
*		sector:	Sector address to erase (PROM_SECTOR_0, etc.)
*		port:	PM1553-1 port setting
*	Returns:  0 if sucessful, -1 if erase failed
*	Warnings: None
*
**/	

INT PM11_ROMWipeSect(UCHAR sector,USHORT port)
{
	INT status;    // pass/fail value

	PM11_RegBitSet(PROM_ENABLE, CREG_MISC, port);    // OR in PROM enable bit

	// This sequence enables sector erase of the PROM 

	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xAA, CREG_DATA, port);
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	PM11_RegWr(0x55, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0x80, CREG_DATA, port);
	PM11_RegWr(0x0555, CREG_ADDR, port);
	PM11_RegWr(0xAA, CREG_DATA, port);
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	PM11_RegWr(0x55, CREG_DATA, port);

	PM11_RegWr(sector, CREG_ADDR, port);    // write sector address to wipe
	PM11_RegWr(0x30, CREG_DATA, port);      // write erase command 

	status = PM11_ROMWrIsComplete(port);    // check for successful erase

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);  // clear PROM enable bit

	return status;
}

/**
*
*	PM11_ROMWrIsComplete()
*	Checks for successful completion of a write/erase operation of the PM11 PROM
*	Arguments: 
*		port: PM1553-1 port setting
*	Returns : 0 if successful, -1 if PROM failed write/erase operation
*	Warnings: None
**/

INT PM11_ROMWrIsComplete(USHORT port)
{
	UCHAR newDQ6;   // holds value read from PROM toggle bit
	UCHAR oldDQ6;   // holds value read from PROM toggle bit
	UCHAR DQ5;      // holds value read from PROM timeout bit
	BOOL done;      // done flag
	BOOL failflag;  // operation fail flag

	done = FALSE;
	failflag = FALSE;
	DQ5 = 0;  // initialize DQ5

	while(!done)  // wait for status
	{
		oldDQ6 = ( PM11_RegRd(CREG_DATA, port) & 0x0040);  // get value of PROM bit 6
		newDQ6 = ( PM11_RegRd(CREG_DATA, port) & 0x0040);  // get value of PROM bit 6
		if(oldDQ6 == newDQ6)  // toggle bit steady
		{
			done = TRUE;
			break;
		}
		else                  // toggle bit toggling
		{
			DQ5 =  ( PM11_RegRd(CREG_DATA, port) & 0x0020);  // get value of PROM bit 5
			if(DQ5)
			{
				done = TRUE;
				break;
			}
		}
	}

	if(DQ5)
	{
		oldDQ6 = ( PM11_RegRd(CREG_DATA, port) & 0x0040);  // get value of PROM bit 6
		newDQ6 = ( PM11_RegRd(CREG_DATA, port) & 0x0040);  // get value of PROM bit 6

		(oldDQ6 == newDQ6) ? (failflag = FALSE) : (failflag = TRUE);  // check toggle bit
	}
	
	if(failflag)
	{
		PM11_ROMReset(port);  // write PROM reset command
		return -1;            // flag as failed
	}
	else
	{
		return 0;
	}
}



/**
*
*	PM11_ROMGetIDVal()
*	Returns the manufacturer ID and device ID from the PM1553-1 PROM.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  
*			  No error: 16-bit value: first 8 bits are manufacturer code, last 8 bits 
*			            are the device code (default: 0x0120)
*			  Error:    -1
*	Warnings: None
*
**/	

UINT PM11_ROMGetIDVal(USHORT port)
{
	USHORT idval;
	INT status;

	status = 0;
	PM11_RegBitSet(PROM_ENABLE, CREG_MISC, port);    // OR in PROM enable bit

	// This sequence gets the manufacturer ID 

	PM11_RegWr(0x0555, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0xAA, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x55, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x0555, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x90, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x0100, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	
	idval = (UCHAR)PM11_RegRd(CREG_DATA, port);  // get manufacturer code
	idval = (idval << 8);                        // shift relevant value to upper byte

	// This sequence gets the device ID 

	PM11_RegWr(0x0555, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0xAA, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x02AA, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x55, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x0555, CREG_ADDR, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x90, CREG_DATA, port);
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;
	PM11_RegWr(0x0101, CREG_ADDR, port);	
	status = PM11_ROMWrIsComplete(port);
	if(status) return status;

	idval |= (UCHAR)PM11_RegRd(CREG_DATA, port);   // get device ID & OR value in

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);  // clear PROM enable bit

	return idval;
}

/**
*
*	PM11_ROMReset()
*	Resets the PM1553-1 PROM to reading data.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	
VOID PM11_ROMReset(USHORT port)
{
	PM11_ROMWr(0xF0, 0x0000, port);  // write 1-cycle reset command
}


/**
*
*	PM11_MemFill()
*	Fills the PM1553-1 memory with the value specified
*	Arguments:
*		fillval:	16 bit value to fill PM1553-1 memory with
*		range:		Upper limit of memory to fill
*		port:		PM1553-1 port setting
*	Returns:  1 word from memory
*	Warnings: None
*
**/	

VOID PM11_MemFill(USHORT fillval, USHORT range, USHORT port)
{
	USHORT index;  // memory address index

	PM11_RegBitClr(PROM_ENABLE, CREG_MISC, port);   // deselect PROM

	PM11_RegWr(0x0020, CREG_ADDR, port);            // write memory base address
	for(index = 0x0020; index <= range; index++)
	{
		PM11_RegWr(fillval, CREG_DATA_INC, port);   // write data to post-increment register
	}
}


/**
*
*	PM11_MemGetSize()
*	Gets the memory size of the PM1553-1.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  Memory size in 16-bit words	
*	Warnings: This function will overwrite some memory addresses
*
**/	

USHORT PM11_MemGetSize(USHORT port)
{
	USHORT addr;
	USHORT read;  // memory compare 

	addr = 0x0020;
	PM11_SummitWr(0xAAAA, addr, port);  // write known value to base memory

	for(addr=0x0040; addr<=0x4000; addr=(addr<<1))  //loop through memory addresses 
	{
		PM11_SummitWr(0x1234,(USHORT)(addr+0x0020),port);    // write known value to memory, w/ offset for registers

		read = PM11_SummitRd(0x0020, port);         // read base memory location

		if(read != 0xAAAA)                          // if we overwrote base memory...
		{
			addr = (addr>>1);        // set upper memory to 1 less than what failed
			break;
		}
		else if(addr==0x4000)        // max memory addr bits tested
		{
			addr = 0x8000;           // set max memory availiable
			break;
		}
	}

	return addr;
}

/**
*
*	PM11 RT functions
*
**/

/**
*
*	PM11_RTAddrSet()
*	Sets the RT address of the PM1553-1.
*	Arguments:
*		rtaddr:		 RT address
*		port:		 PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM11_RTAddrSet(USHORT rtaddr, USHORT port)
{
	USHORT index;  // loop index
	USHORT mask;   // bitmask
	USHORT par;    // parity bit

	PM11_SummitBitClr(0xFC00, SREG_OPSTAT, port);  // clear old rt address & parity

	// This sequence figures out the correct (odd) RT parity

	par = 1;
	for(index=0; index<=4; index++)  // loop through RTA bits
	{
		mask = 1<<index;    // set mask to current bit position		
		if(rtaddr & mask)   // if a ones bit
		{
			par = !par;     // swap parity
		}
	}
	
	rtaddr = (rtaddr<<11);  // shift RTA
	par = (par<<10);        // shift RT parity

	rtaddr |= par;          // OR in parity bit

	PM11_SummitBitSet(rtaddr, SREG_OPSTAT, port);
}


/**
*
*	PM11_RTDescBlockWr()
*	Sets a RT descriptor block into PM1553-1 memory.
*	Arguments:
*		descblock:	 pointer to RTDESCBLOCK structure
*		port:		 PM1553-1 port setting
*	Returns:  None
*	Warnings: 
*
**/	

VOID PM11_RTDescBlockWr(RTDESCBLOCK* descblock, USHORT port)
{
	PM11_RegWr(descblock->baseaddr, CREG_ADDR, port);       // set address

	PM11_RegWr(descblock->ctrlwrd, CREG_DATA_INC, port);    // write to post-increment register
	PM11_RegWr(descblock->dptra, CREG_DATA_INC, port);      // write to post-increment register
	PM11_RegWr(descblock->dptrb, CREG_DATA_INC, port);      // write to post-increment register
	PM11_RegWr(descblock->bcastptr, CREG_DATA_INC, port);   // write to post-increment register
}

/**
*
*	PM11_RTDescBlockRd()
*	Reads an RT descriptor block from PM1553-1 memory.
*	Arguments:
*		descblock:	 pointer to RTDESCBLOCK structure
*		port:		 PM1553-1 port setting
*	Returns:  None
*	Warnings: 
*
**/	

VOID PM11_RTDescBlockRd(RTDESCBLOCK* descblock, USHORT port)
{
	PM11_RegWr(descblock->baseaddr, CREG_ADDR, port);       // set address

	descblock->ctrlwrd  = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	descblock->dptra    = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	descblock->dptrb    = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	descblock->bcastptr = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
}

/**
*
*	PM11 BC functions
*
**/

/**
*
*	PM11_BCCmdBlockWr()
*	Sets a BC command block into PM1553-1 memory.
*	Arguments:
*		cmdblock:	 pointer to CMDBLOCK structure
*		port:		 PM1553-1 port setting
*	Returns:  None
*	Warnings: 
*
**/	

VOID PM11_BCCmdBlockWr(CMDBLOCK* cmdblock, USHORT port)
{
	USHORT index;  // loop index

	//
	// This sequence sets the word count (WC) value. A WC value of 00000B 
	// means 32 data words
	//
	cmdblock->datacount = (cmdblock->cwd1 & 0x001F);
	if(cmdblock->datacount == 0) cmdblock->datacount = 32;

	PM11_RegWr(cmdblock->baseaddr, CREG_ADDR, port);        // set address

	PM11_RegWr(cmdblock->ctrlwrd, CREG_DATA_INC, port);     // set command block control word
	PM11_RegWr(cmdblock->cwd1, CREG_DATA_INC, port);        // set CWD 1
	PM11_RegWr(cmdblock->cwd2, CREG_DATA_INC, port);        // set CWD 2
	PM11_RegWr(cmdblock->dataptr, CREG_DATA_INC, port);     // set data pointer
	PM11_RegWr(0, CREG_DATA_INC, port);                     // set SWD1 = 0
	PM11_RegWr(0, CREG_DATA_INC, port);                     // set SWD2 = 0
	PM11_RegWr(cmdblock->branchaddr, CREG_DATA_INC, port);  // set branch-to address
	PM11_RegWr(cmdblock->timeval, CREG_DATA_INC, port);     // set timer value
	PM11_RegWr(cmdblock->dataptr, CREG_ADDR, port);         // set address for data words
	
	//
	// This sequence checks whether a RCV or XMT command was set in CWD1, and
	// sets or clears the associated data word(s) accordingly
	//
	if(cmdblock->cwd1 & 0x0400)  // if T/R bit set in CWD (RT transmit to BC)
	{
		for(index=0; index<(cmdblock->datacount); index++)  // loop through data
		{
			PM11_RegWr(0x0000, CREG_DATA_INC, port);  // clear data in buffer
		}
	}
	else	// RT recieve from BC
	{
		for(index=0; index<(cmdblock->datacount); index++)  // loop through data
		{
			PM11_RegWr(cmdblock->data[index], CREG_DATA_INC, port);  // set data
		}
	}
}

/**
*
*	PM11_BCCmdBlockRd()
*	Reads a BC command block from PM1553-1 memory.
*	Arguments:
*		cmdblock:	pointer to monitor data structure
*		port:		PM1553-1 port setting
*	Returns:  None
*	Warnings: None 
*
**/	
VOID PM11_BCCmdBlockRd(CMDBLOCK* cmdblock, USHORT port)
{
	USHORT index;  // loop index
	PM11_RegWr(cmdblock->baseaddr, CREG_ADDR, port);  // set address

	cmdblock->ctrlwrd    = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->cwd1       = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->cwd2       = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->dataptr    = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->swd1       = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->swd2       = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->branchaddr = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register
	cmdblock->timeval    = PM11_RegRd(CREG_DATA_INC, port);  // read from post-increment register

	// This sequence sets the word count (WC) value. A WC value of 00000B 
	// means 32 data words

	cmdblock->datacount = (cmdblock->cwd1 & 0x001F);     // set word count
	if(cmdblock->datacount == 0) cmdblock->datacount = 32;

	PM11_RegWr(cmdblock->dataptr, CREG_ADDR, port);      // set address for data words

	for(index=0; index<(cmdblock->datacount); index++)   // loop through data
	{
		cmdblock->data[index] = PM11_RegRd(CREG_DATA_INC, port); 
	}
}

/**
*
*	PM11 Monitor functions
*
**/

/**
*
*	PM11_MonBlockRd()
*	Reads a monitor block from PM1553-1 memory.
*	Arguments:
*		monblock:	pointer to monitor data structure
*		port:		PM1553-1 port setting
*	Returns:  None
*	Warnings: None 
*
**/	

VOID PM11_MonBlockRd(MONBLOCK* monblock, USHORT port)
{

	USHORT index;  // loop index

	PM11_RegWr(monblock->baseaddr, CREG_ADDR, port);  // set base address of monitor block

	monblock->msginfowrd = PM11_RegRd(CREG_DATA_INC, port);  // get info word
	monblock->cwd1		 = PM11_RegRd(CREG_DATA_INC, port);  // get CWD1
	monblock->cwd2		 = PM11_RegRd(CREG_DATA_INC, port);  // get CWD2
	monblock->dataptr	 = PM11_RegRd(CREG_DATA_INC, port);  // get data pointer
	monblock->swd1		 = PM11_RegRd(CREG_DATA_INC, port);  // get SWD1
	monblock->swd2       = PM11_RegRd(CREG_DATA_INC, port);  // get SWD2 
	monblock->timeval    = PM11_RegRd(CREG_DATA_INC, port);  // get timetag 

	PM11_RegRd(CREG_DATA_INC, port);  // read unused position from monitor block and throw away:
	                                  // This post-increments the ADDR register in the PM1553-1

	// This sequence sets the word count (WC) value. A WC value of 00000B 
	// means 32 data words

	monblock->datacount = (monblock->cwd1 & 0x001F);
	if(monblock->datacount == 0) monblock->datacount = 32;

	PM11_RegWr(monblock->dataptr, CREG_ADDR, port);        // set monitor data pointer

	for(index = 0; index <monblock->datacount; index++)    // read data words
	{
		monblock->data[index] = PM11_RegRd(CREG_DATA_INC, port);  // read data form post-increment register
	}
}

/**
*
*	PM11 LED functions
*
**/

/**
*
*	PM11_LEDIsSet()
*	Checks if the user LED is set.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  Non-zero if LED set, FALSE if not set
*	Warnings: None
*
**/	

BOOL PM11_LEDIsSet(USHORT port)
{
	return (PM11_RegRd(CREG_MISC, port) & LED_SET);  // filter and return LED status bit
}
	
/**
*
*	PM11_LEDWr()
*	Sets or resets the user LED.
*	Arguments:
*		val:	TRUE to set LED, FALSE to reset
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_LEDWr(BOOL val, USHORT port)
{
	if(val)
	{
		PM11_RegBitSet(LED_SET, CREG_MISC, port);
	}
	else
	{
		PM11_RegBitClr(LED_SET, CREG_MISC, port);
	}
}

/**
*
*	PM11_LEDBlink()
*	Blinks the user LED once (on, off).
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: This function uses the SSF timer, and will cause the SSFSRQ bit to be set
*			  in register 0.
*
**/	

VOID PM11_LEDBlink(USHORT port)
{
	USHORT timeval = 1;     // timer value
	USHORT period = 0xFF;   // change this value to change LED frequency

	PM11_LEDWr(TRUE, port);      // set LED
	PM11_TimerWr(period, port);  // 255 Msec

	do  // wait for timer to count down
	{
		timeval = PM11_TimerRd(port);  // read timer val
	}while(timeval);

	PM11_LEDWr(FALSE, port);     // reset LED
	PM11_TimerWr(period, port);  // 255 Msec

	timeval = 1;                 // reinit timeval

	do  // wait for timer to count down
	{
		timeval = PM11_TimerRd(port);  // read timer val
	}while(timeval);
}


/**
*
*	PM11 Timer functions
*
**/

/**
*
*	PM11_TimerConfig()
*	Configures the PM1553-1 timer.
*	Arguments:
*		cfgflags: TIMER_MODE_FREE or TIMER_MODE_ONCE
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: The timer cannot be stopped after being started except by a card or system reset
*
**/	

VOID PM11_TimerConfig(USHORT cfgflags, USHORT port)
{
	if(cfgflags)
	{
		PM11_RegBitSet(TIMER_MODE, CREG_MISC, port);
	}
	else
	{
		PM11_RegBitClr(TIMER_MODE, CREG_MISC, port);
	}
}


/**
*
*	PM11_TimerRd()
*	Reads the value of the SSF timer.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	
USHORT	PM11_TimerRd(USHORT port)
{
	return (PM11_RegRd(CREG_TIMERS, port) & 0x00FF);  // filter and return the timer value
}

/**
*
*	PM11_TimerWr()
*	Writes a value to the SSF timer.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	
VOID PM11_TimerWr(USHORT timeval, USHORT port)
{
	PM11_RegBitSet( (USHORT)(timeval & 0xFF), CREG_TIMERS, port);
}

/**
*
*	PM11_TimerSSFEn()
*	Enables SSF on timer countdown.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: The SSF timer cannot be stopped after being started except by a card or system reset
*
**/	

VOID PM11_TimerSSFEn(USHORT port)
{
	PM11_RegBitSet(SSF_TIMER_EN, CREG_MISC, port);
}

/**
*
*	PM11_TimerSSFDis()
*	Disables SSF on timer countdown.
*	Arguments:
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: The SSF timer cannot be stopped after being started except by a card or system reset
*
**/	

VOID PM11_TimerSSFDis(USHORT port)
{
	PM11_RegBitSet(SSF_TIMER_EN, CREG_MISC, port);
}

/**
*
*	PM11 DIN functions
*
**/

/**
*
*	PM11_DINIsSet()
*	Checks whether the specified DIN of the PM1553-1 is set.
*	Arguments:
*		din:	DIN(s) to check
*		port:	PM1553-1 port setting
*	Returns:  non-zero value if set, FALSE if not
*	Warnings: None
*
**/	

BOOL PM11_DINIsSet(USHORT mask, USHORT port)
{
	return(PM11_RegRd(CREG_MISC, port) & mask);
}

/**
*
*	PM11_DINConfig()
*	Configures the digital inputs of the PM1553-1 is set.
*	Arguments:
*		resolution:	TIMER_RES_4US or TIMER_RES_4MS
*		period: period in timer ticks
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	
VOID PM11_DINConfig(USHORT resolution, USHORT period, USHORT port)
{
	period = (period << 8);  // shift period to proper position
	resolution |= period;    // OR period and resolution
	PM11_RegBitSet(resolution, CREG_TIMERS, port);  // set bits in TIMERS register
}


/**
*
*	PM11 DOUT functions
*
**/

/**
*
*	PM11_DOUTWr()
*	Sets the specified digital output (DOUT) of the PM1553-1.
*	Arguments:
*		dout:   DOUT to set
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID	PM11_DOUTSet(USHORT dout, USHORT port)
{
	PM11_RegBitSet(dout, CREG_MISC, port);
}

/**
*
*	PM11_DOUTIsSet()
*	Checks if the specified digital output (DOUT) of the PM1553-1 is set.
*	Arguments:
*		dout:   DOUT to set
*		port:	PM1553-1 port setting
*	Returns:  Non-zero if set, FALSE if not
*	Warnings: None
*
**/	

BOOL PM11_DOUTIsSet(USHORT dout, USHORT port)
{
	return (PM11_RegRd(CREG_MISC, port) & dout);  // filter and return the dout status
}

/**
*
*	PM11_DOUTClr()
*	Clears the specified digital output (DOUT) of the PM1553-1.
*	Arguments:
*		dout:   DOUT to set
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_DOUTClr(USHORT dout, USHORT port)
{
	PM11_RegBitClr(dout, CREG_MISC, port);
}

/**
*
*	PM11 Interrupt/SRQ Functions
*
**/

/**
*
*	PM11_SRQClr()
*	Clears the specified SRQ of the PM1553-1.
*	Arguments:
*		mask:   SRQ(s) to clear (SSFSRQ,etc.)
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_SRQClr(USHORT mask, USHORT port)
{
	PM11_RegBitSet(mask, CREG_STATUS, port);
}

/**
*
*	PM11_SRQRd()
*	Reads value of the specified SRQ(s) of the PM1553-1.
*	Arguments:
*		mask:   SRQ(s) to clear (SSFSRQ,etc.)
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

USHORT PM11_SRQRd(USHORT mask, USHORT port)
{
	return (PM11_RegRd(CREG_STATUS, port) & mask);
}

/**
*
*	PM11_IntEnable()
*	Enables interrupts to the host from a specified source on the PM1553-1.
*	Arguments:
*		intsource:   interrupt source (MSGIEN, etc.)
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_IntEnable(USHORT intsource, USHORT port)
{
	PM11_RegBitSet( (USHORT)(PCIEN | intsource), CREG_INTCFG, port);
}

/**
*
*	PM11_IntDisable()
*	Disables interrupts to the host from a specified source on the PM1553-1.
*	Arguments:
*		intsource:   interrupt source (MSGIEN, PCIEN (disables all), etc.)
*		port:	PM1553-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM11_IntDisable(USHORT intsource, USHORT port)
{
	PM11_RegBitClr(intsource, CREG_INTCFG, port);
}
