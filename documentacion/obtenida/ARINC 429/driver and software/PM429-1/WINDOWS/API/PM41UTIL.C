/**
*
*  PM429-1 WIN32 DRIVER  Version 1.2  (09/30/2008)
*  Copyright (c) 2001-2008
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41.C --  PM429-1 WIN32 Driver Source File.
*
**/

/**
*
*  Function names and descriptions:
*
*  WIN32 Only Card functions
*
*   BOOL    PM41_CardOpen()         -- Returns a handle to a PM429-1
*   BOOL    PM41_CardClose()        -- Close a PM429-1
*   BOOL    PM41_IntInstall()       -- Install an event to handle interrupts
*   BOOL    PM41_IntUninstall()     -- Uninstall event
*   BOOL    PM41_IntReset()         -- Clear pending interrupt
*
*  WIN32 Only Utility functions
*
*   HANDLE  PM41_UtilFindCard()     -- Finds the card HANDLE associated with the port
*   BOOL    PM41_UtilPushCard()     -- Adds a card to the table, using its port as the key
*   BOOL    PM41_UtilPopCard()      -- Removes a card from the table, using its port as the key
*
*  Utility functions
*
*   HANDLE  PM41_UtilFindCard()     -- Finds the card HANDLE associated with the port
*   BOOL    PM41_UtilPushCard()     -- Adds a card to the table, using its port as the key
*   BOOL    PM41_UtilPopCard()      -- Removes a card from the table, using its port as the key
*
*   USHORT  PM41_UtilGetPage()      -- Extracts the page value from a PM429-1 register #define
*   USHORT  PM41_UtilGetReg()       -- Extracts the register value from a pM429-1 register #define
*   UINT    PM41_UtilGetMsgData()   -- Extracts the original data from a received dataword
*   BOOL    PM41_UtilGetParity()    -- Extracts the original parity bit value from a received dataword.
*   UINT    PM41_UtilScrambleData() -- Simulates data scramble mode of PM429-1
*   UCHAR   PM41_UtilReverseLabel() -- Formats a label into reverse bit order
*   
*  Host I/O functions
*
*   VOID    PM41_Outp()             -- Write 1 byte of data to the specified I/O port
*   UCHAR   PM41_Inp()              -- Reads 1 byte of data from the specified I/O port
*   VOID    PM41_OutpW()            -- Writes a 16-bit value to the specified I/O port
*   USHORT  PM41_InpW()             -- Reads a 16-bit value from the specified I/O port
*
*  PM41 Register functions
*
*   VOID    PM41_PageWr()           -- Writes a value to the PM429-1 PAGE register.
*   USHORT  PM41_PageRd()           -- Reads a value from the PM429-1 PAGE register.
*   VOID    PM41_RegWr()            -- Writes a value to the specified PM429-1 register.
*   USHORT  PM41_RegRd()            -- Reads a value from the specified PM429-1 register.
*   VOID    PM41_RegClr()           -- Clears (wipes w/ zeros) the specified  PM41 register.
*   VOID    PM41_RegBitSet()        -- Reads the current value from the specified PM41 register, 
*                                      ORs in specified data, and writes result back.
*   VOID    PM41_RegBitClr()        -- Clears the specified flags from the specified PM41 register.
*
*  PM41 Card functions
*
*   VOID    PM41_CardReset()        -- Resets specified PM429-1.
*   BOOL    PM41_IsCard()           -- Checks if specified PM429-1 exists.
*   INT     PM41_SelfTest()         -- Performs hardware test of specified PM429-1.
*
*  PM41 SRQ Functions
*
*   BOOL    PM41_SRQIsSet()         -- Checks for specified SRQ(s) from the PM429-1
*   USHORT  PM41_SRQRd()            -- Read the value of the PM429-1 SRQ register
*   VOID    PM41_SRQClr()           -- Clears the specified SRQ bit(s)
*   VOID    PM41_SRQConfig()        -- Configures ARINC SRQ on specified channel
* 
*  PM41 Channel functions
*
*   BOOL    PM41_IsChan()           -- Checks if specified channel is present
*   BOOL    PM41_ChIsRcv()          -- Checks if specified channel is receive channel
*   BOOL    PM41_ChIsXmt()          -- Checks if specified channel is transmit channel
*   VOID    PM41_ChDataWr()         -- Writes 1 dataword to specified ARINC 429 TCH. 
*   UINT    PM41_ChDataRd()         -- Reads 1 dataword from specified ARINC 429 RCH.
*   USHORT  PM41_ChStatRd()         -- Reads Status register from specified channel
*   VOID    PM41_ChGapWr()          -- Writes gap value to specified TCH
*   USHORT  PM41_ChGapRd()          -- Reads gap value from specified TCH
*   BOOL    PM41_IsChGapDone()      -- Checks if the gap timer has counted down
*   VOID    PM41_ChClear()          -- Clears receive buffer of specified channel
*   VOID    PM41_ChConfig()         -- Sets channel options for specified channel
* 
*  PM41 Filter functions
*
*   VOID    PM41_FilterSDISet()     -- Sets SDI filter for specified channel
*   VOID    PM41_FilterSDIClear()   -- Clears SDI filter for specified channel
*   VOID    PM41_FilterLabelSet()   -- Sets label filter for specified channel
*   VOID    PM41_FilterLabelClr()   -- Disables label filter for specified channel
*   PUCHAR  PM41_FilterLabelRead()  -- Reads label filter for specified channel
* 
*  PM41 LED functions
*
*   BOOL    PM41_LEDIsSet()         -- Reads status of external LED
*   VOID    PM41_LEDWr()            -- Turns LED on or off
*   VOID    PM41_LEDBlink()         -- Blinks user LED once (on, off)
*
*  PM41 Timer functions
* 
*   VOID    PM41_TimerConfig()      -- Configures on-board timer
*   VOID    PM41_TimerStart()       -- Starts on-board timer
*   VOID    PM41_TimerStop()        -- Stops on-board timer
*   VOID    PM41_TimerClr()         -- Stops and clears on-board timer
*   UINT    PM41_TimerRd()          -- Reads on-board timer
*   VOID    PM41_TimerWr()          -- Writes value to on-board timer
*   VOID    PM41_TimerSRQEn()       -- Enables SRQs on timer
*   VOID    PM41_TimerSRQDis()      -- Disables SRQs on timer
* 
*  PM41 DIN functions
* 
*   BOOL    PM41_DINIsSet()         -- Reads value of specified DIN
*   VOID    PM41_DINConfig()        -- Configures digital inputs
*   USHORT  PM41_DINSRQRd()         -- Reads value of DIN SRQ configuration register
*   VOID    PM41_DINSRQSet()        -- Sets digital input SRQ configuration
* 
*  PM41 DOUT functions
* 
*   VOID    PM41_DOUTWr()           -- Sets specified DOUT
*   BOOL    PM41_DOUTIsSet()        -- Reads specified DOUT
*   VOID    PM41_DOUTClr()          -- Clears specified DOUT
*
**/

/**
*
*	PM429-1 include file
*
**/

#include <stdlib.h>
#include "pm41.h"

/**
*
*	Utility functions
*
**/

#ifdef _WIN32

#include <memory.h>

/**
*
*	These variables are used by the windows extensions to properly
*	manage the cards used by this library of functions.
*   PM41_MAXCARDS can be changed to any appropriate value.
*
*/

#define PM41_MAXCARDS 5

BOOL bInitialized=FALSE;
ULONG ulCards[PM41_MAXCARDS][2];

/**
*
*	PM41_UtilFindCard()
*	Finds the card HANDLE associated with the port.
*	Arguments:
*		port: I/O port value
*	Returns: a HANDLE to the card
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

HANDLE PM41_UtilFindCard(USHORT port)
{
	INT j;

	if (FALSE == bInitialized)
	{
		return(PM41_INVALID_HANDLE);
	}

	for (j=0;j<PM41_MAXCARDS;++j)
	{

		//
		//	Look for card in the list
		//

		if (ulCards[j][0] == (ULONG)(port & 0x0FF0))
		{
			return((HANDLE)ulCards[j][1]);
		}
	}

	return(PM41_INVALID_HANDLE);
}

/**
*
*	PM41_UtilPushCard()
*	Adds a card to the list, using its port as a key.
*	Arguments:
*		port: I/O port value
*		card: HANDLE to the card associated with port.
*	Returns: TRUE on success, FALSE on failure
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

BOOL PM41_UtilPushCard(USHORT port,HANDLE card)
{
	INT j;

	//
	//	Perform one-time initialization
	//

	if (FALSE == bInitialized)
	{
		memset(ulCards, (ULONG)PM41_INVALID_HANDLE, PM41_MAXCARDS*2*sizeof(ulCards[0][0]));
		bInitialized = TRUE;
	}

	//
	//	Loop through list looking for open position
	//

	for (j=0;j<PM41_MAXCARDS;++j)
	{
		if (ulCards[j][0] == (ULONG)PM41_INVALID_HANDLE)
		{
			ulCards[j][0] = (ULONG)(port & 0x0FF0);
			ulCards[j][1] = (UINT)card;
			return(TRUE);
		}
	}

	return(FALSE);
}

/**
*
*	PM41_UtilPopCard()
*	Removes a card from the list, using its port as a key.
*	Arguments:
*		port: I/O port value
*	Returns: TRUE on success, FALSE on failure
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

BOOL PM41_UtilPopCard(USHORT port)
{
	INT i;

	if (FALSE == bInitialized) return(FALSE);

	for (i = 0; i < PM41_MAXCARDS; ++i)
	{
		if (ulCards[i][0] == port)
		{
			ulCards[i][0] = (ULONG)PM41_INVALID_HANDLE;
			ulCards[i][1] = (ULONG)PM41_INVALID_HANDLE;
			return(TRUE);
		}
	}

	return(FALSE);
}

/**
*
*	PM41_IntInstall()
*	Installs an event interrupt handler.  Event is signaled
*	whenever an interrupt is generated
*	Arguments:
*		hEvent: event handle
*		port: I/O port value
*	Returns: TRUE on success, FALSE on failure
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

BOOL PM41_IntInstall(HANDLE hEvent,USHORT port)
{
	BOOL result;

	//
	//	Register event object with kernel driver.
	//

	result = BTIKRNL_InterruptEnable(hEvent,PM41_UtilFindCard(port));
	if (!result) return(FALSE);

	return(TRUE);
}

/**
*
*	PM41_IntUninstall()
*	Uninstalls an event interrupt handler.
*	Arguments:
*		port: I/O port value
*	Returns: TRUE on success, FALSE on failure
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

BOOL PM41_IntUninstall(USHORT port)
{
	BOOL result;

	//
	//	Unregister event object with kernel driver.
	//

	result = BTIKRNL_InterruptDisable(0,PM41_UtilFindCard(port));
	if (!result) return(FALSE);

	//
	//	Disable interrupts from card.
	//

	PM41_IntDisable(port);
	
	return(TRUE);
}

/**
*
*	PM41_IntReset()
*	Clears interrupt to allow next interrupt to signal event
*	Arguments:
*		port: I/O port value
*	Returns: TRUE on success, FALSE on failure
*	Warnings: Do not use this function outside of PM41_CardOpen/Close.
*
**/

BOOL PM41_IntReset(USHORT port)
{
	BOOL result;

	//
	//	Clear interrupt in kernel
	//

	result = BTIKRNL_InterruptClear(PM41_UtilFindCard(port));
	if (!result) return(FALSE);

	return(TRUE);
}

#endif

/**
*
*	PM41_UtilGetPage()
*	Extracts the page value from a PM429-1 Register/Page #define.
*	Arguments:
*		regval: value to process
*	Returns: Page value
*	Warnings: None
*
**/

USHORT PM41_UtilGetPage(USHORT regval)
{
	return ((regval & 0xF0) >> 4);
}

/**
*
*	PM41_UtilGetReg()
*	Extracts the register value from a PM429-1 Register/Page #define.
*	Arguments:
*		regval: value to process
*	Returns: Register value
*	Warnings: None
*
**/

USHORT PM41_UtilGetReg(USHORT regval)
{
	return (regval & 0x0F);
}

/**
*
*	PM41_UtilGetMsgData()
*	Extracts the original data from a received dataword
*	Arguments:
*		data: data to process
*	Returns:  32 bit dataword
*	Warnings: None
*
**/

UINT PM41_UtilGetMsgData(UINT data)
{
	if(PM41_UtilGetParity(data))	// if odd parity...
	{
		return (data & 0x7FFFFFFF);	// reset 32nd bit
	}
	
	return (data | 0x80000000);	// set 32nd bit
}

/**
*
*	PM41_UtilGetParity()
*	Extracts the original parity bit value from a received dataword.
*	Arguments:
*		data: data to process
*	Returns:  TRUE if odd parity, FALSE if even
*	Warnings: None
*
**/

BOOL PM41_UtilGetParity(UINT data)
{       
	UINT high_w;		// High half of ARINC dataword
	UINT low_w;			// Low half of ARINC dataword
	USHORT bits;		// variable for databits
	UINT mask;			// bitmask
	BOOL count = FALSE;	// odd/even

	high_w = data & 0xFFFF0000U;	// Filter for High word	
	low_w = data & 0x0000FFFFU;		// Filter for Low word

	high_w = high_w >> 16;			// Shift High word
	
	for(bits=0; bits<=16U; bits++)	// Loop through both halves of ARINC word
	{
		mask = 1<<bits;		// set mask to current bit position		
		if(mask & high_w)	// check for a '1' bit
		{
			count = !count;	// swap count
		}
		if(mask & low_w)		// check for a '1' bit
		{
			count = !count;	// swap count
		}
	}

	return count;
}

/**
*
*	PM41_UtilScrambleData()
*	Simulates data scramble mode of PM429-1
*	Arguments:
*		data: data to process
*	Returns:  32 bit scrambled dataword
*	Warnings: None
*
**/
		
UINT PM41_UtilScrambleData(UINT data)
{
	UINT par;
	UINT ssm;
	UINT sdi;
	UINT label;

	par = data & 0x80000000;	// get parity
	ssm = data & 0x60000000;	// get ssm
	sdi = data & 0x00000300;	// get data

	label = PM41_UtilReverseLabel((UCHAR)(data & 0x000000FF));	// get label
	
	data = data & 0x1FFFFC00;	// mask off data

	data = data << 3;
	par = par >> 23;
	ssm = ssm >> 20;
	sdi = sdi << 3;

	return (label | par | ssm | sdi | data);
}

/**
*
*	PM41_UtilReverseLabel()
*	Formats a label into reverse bit order
*	Arguments:
*		label: data to process
*	Returns:  reversed label
*	Warnings: None
*
**/

UCHAR PM41_UtilReverseLabel(UCHAR label)
{
	USHORT newlabel;	// holds label being processed
	USHORT count;		// position counter
	UINT bitmask;		// bitmask of old data

	newlabel = (label << 8);	// shift old data to upper byte
	count = 1;					// init count

	for(bitmask=0x0100; bitmask<=0x8000; bitmask = (bitmask<<1))	// loop through label bits
	{
		newlabel = newlabel | ((newlabel & (USHORT) bitmask) >> count);	// get label and shift to new position
		count+=2;	// increment position counter
	}

	return (UCHAR)(newlabel & 0x00FF);	// return new label data
}

/**
*
*	Host I/O functions
*
**/
	
/**
*
*	PM41_Outp()
*	Write 1 byte of data to the specified I/O port
*	Arguments:
*		data: data to write
*		port: I/O port to write to
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_Outp(UCHAR data, USHORT port)
{

#ifdef _WIN32          // if compiling for NT

	// (port &0xff0) gives an aligned address, which *should* be the base
	// io port for the card.  This may not be the best solution.
	BTIKRNL_PortWrB(data, (port & 0xff0), 0, PM41_UtilFindCard(port));

#else

#  ifdef _MSC_VER       // if using MS Visual C, use the MS name
	_outp(port, data);  // COMPILER_DEP Note that data and port are reversed for _outp()
#  else
	outp(port, data);   // COMPILER_DEP Note that data and port are reversed for outp()
#  endif                // _MSC_VER

#endif                  // _WIN32

}

/**
*
*	PM41_Inp()
*	Reads 1 byte of data from the specified I/O port
*	Arguments:
*		port: I/O port to write to
*	Returns:  Data read
*	Warnings: None
*
**/

UCHAR PM41_Inp(USHORT port)
{
	UCHAR val = 0;

#ifdef _WIN32                // if compiling for NT
	// (port & 0x00f) gives the LSB, which should be the offset.
	BTIKRNL_PortRdB(&val, (port & 0x00f), 0, PM41_UtilFindCard(port));
#else
#  ifdef _MSC_VER             // if using MS Visual C, use the MS name
	val = (UCHAR)_inp(port);  // COMPILER_DEP
	return val;
#  else
	val = (UCHAR)inp(port);   // COMPILER_DEP
#  endif                      // _MSC_VER
#endif                        // _WIN32

	return(val);
}

/**
*
*	PM41_OutpW()
*	Writes a 16-bit value to the specified I/O port.
*	Arguments:
*		data: data to write
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_OutpW(USHORT data, USHORT port)
{

#ifndef _16BIT_W    // if 8-bit only
	{
		USHORT low_b;
		USHORT high_b;

		low_b  = (data & 0x00FF);  // get low byte
		high_b = (data & 0xFF00);  // get high byte
		high_b = (high_b >> 8);    // shift high byte

		PM41_Outp((UCHAR)low_b, port);      // write low byte
		PM41_Outp((UCHAR)high_b, port+1);   // write high byte

		return;
	}
#else	// 16 bit
#  ifdef _WIN32         // if compiling for NT
	// (port & 0x00f) gives the LSB, which should be the offset.
	BTIKRNL_PortWrW(data, (port & 0x00f), 0, PM41_UtilFindCard(port));
#  else
#    ifdef _MSC_VER      // if using MS Visual C, use the MS name
	_outpw(port, data);  // COMPILER_DEP Note that data and port are reversed
			return;
#    else
	outpw(port, data);   // COMPILER_DEP Note that data and port are reversed
#    endif               // _MSC_VER
#  endif                 // _WIN32
#endif                   // 16 bit
}

/**
*
*	PM41_InpW()
*	Reads a 16-bit value from the specified I/O port.
*	Arguments:
*		port: port to read from
*	Returns:  data read
*	Warnings: None
*
**/

USHORT PM41_InpW(USHORT port)
{

#ifndef _16BIT_R // if 8-bit only
	{
		USHORT low_b;
		USHORT high_b;

		low_b  = PM41_Inp(port);    // read low byte
		high_b = PM41_Inp(port+1);  // Read high byte

		return ((high_b << 8) | low_b);  // OR high and low bytes together
	}
#else  // _16BIT_R
#  ifdef _WIN32         // if compiling for NT
	USHORT sVal = 0;
	// (port & 0x00f) gives the LSB, which should be the offset.
	BTIKRNL_PortRdW(&sVal, (port & 0x00f), 0, PM41_UtilFindCard(port));
	return sVal;
#  else
#    ifdef _MSC_VER      // if using MS Visual C, use the MS name
	return _inpw(port);  // COMPILER_DEP
#    else
	return inpw(port);   // COMPILER_DEP
#    endif	             // _MSC_VER
#  endif                 // _WIN32
#endif                   // _16BIT_R
}

/**
*
*	PM41 Register functions
*
**/

/**
*
*	PM41_PageWr()
*	Writes a value to the PM429-1 PAGE register.
*	Arguments:
*		page: PAGE register value
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_PageWr(USHORT page, USHORT port)
{
	PM41_OutpW(page, (USHORT)(port+REG_PAGE)); //set PAGE register to specified page
}

/**
*
*	PM41_PageRd()
*	Reads a value from the PM429-1 PAGE register.
*	Arguments:
*		page: PAGE register value
*		port: PM429-1 port setting
*	Returns:  Value of PAGE register
*	Warnings: None
*
**/

USHORT PM41_PageRd(USHORT port)
{
	return PM41_InpW((USHORT)(port+REG_PAGE));
}

/**
*
*	PM41_RegWr()
*	Writes a value to the specified PM429-1 register.
*	Arguments:
*		data: Data to write
*		reg:  PM41 register
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: This function cannot be used to write a value to the page 
*			  register -- use PM41_PageWr().
*
**/

VOID PM41_RegWr(USHORT data, USHORT reg, USHORT port)
{
	PM41_PageWr( PM41_UtilGetPage(reg) ,port);			// set page
	PM41_OutpW(data, (USHORT)(port+(PM41_UtilGetReg(reg))) );	// write data
}

/**
*
*	PM41_RegRd()
*	Reads a value from the specified PM429-1 register.
*	Arguments: 
*		reg:  PM41 register
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: This function cannot be used to read a value from the PAGE register -- use PM41_PageRd()
*
**/

USHORT PM41_RegRd(USHORT reg, USHORT port)
{
	PM41_PageWr( PM41_UtilGetPage(reg) ,port);				// set page
	return PM41_InpW((USHORT)(port+PM41_UtilGetReg(reg)));	// get value
}

/**
*
*	PM41_RegClr()
*	Clears (wipes w/ zeros) the specified  PM41 register.
*	Arguments: 
*		reg:  PM41 register
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_RegClr(USHORT reg, USHORT port)
{
	PM41_RegWr(0x0000, reg, port); // write 0s to register
}

/**
*
*	PM41_RegBitSet()
*	Reads the current value from the specified PM41 register, 
*		ORs in specified data, and writes result back.
*	Arguments: 
*		mask: Data to write
*		reg:  PM41 register
*	Returns:  None
*	Warnings: Only adds settings -- does not clear any bits. Use PM41_RegBitClr() to clear bits
*
**/

VOID PM41_RegBitSet(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;	// data to be read

	PM41_PageWr( PM41_UtilGetPage(reg), port);	// set page

	data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(reg))); // read data from register
	data = (mask | data);			// OR new values in

	PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(reg))); // write back new data
}


/**
*
*	PM41_RegBitClr()
*	Clears the specified flags from the specified PM41 register.
*	Arguments: 
*		mask: Data to clear
*		reg:  PM41 register
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_RegBitClr(USHORT mask, USHORT reg, USHORT port)
{
	USHORT data;				// data to be read

	PM41_PageWr(PM41_UtilGetPage(reg), port);				// set page
	data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(reg)));	// get current register value

	mask = (~mask);				// set bitmask to its complement
	mask = (mask & data);		// AND new value of mask w/ register contents

	PM41_OutpW(mask,(USHORT)(port+PM41_UtilGetReg(reg)));	// write value back
}

/**
*
*	PM41 Card functions
*
**/

/**
*
*	PM41_CardOpen()
*	Obtains access to a PM429-1.
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  Handle to a card.
*	Warnings: Be sure to have a companion PM41_CardClose call for each
*             PM41_CardOpen call.
*             As a fail-safe, this function will fail if the port is
*             already in use.  The port is used for compatability, and
*             can be any valid address ending in '0'.  In other words,
*             this function maps the handle value of 'name' to 'port'.
*
*/

HANDLE PM41_CardOpen(LPCTSTR name,USHORT port)
{

#ifdef _WIN32

	HANDLE hCard = PM41_UtilFindCard(port);

	//
	//	Return error if the port has already been opened.
	//

	if (hCard!=PM41_INVALID_HANDLE)
	{
		return(hCard);
	}

	//
	//  Open device
	//

	hCard = BTIKRNL_KernelOpen(name, 0xFFFF, 0xFFF, 0x00, 0x0);

	if (hCard)
	{
		if (FALSE == PM41_UtilPushCard(port, hCard))
		{
			return(PM41_ERRMEM_HANDLE);
		}
		else
		{
			return(hCard);
		}
	}

	return(PM41_INVALID_HANDLE);

#else

	return(0xF00DF00D);	// bogus 'good' value

#endif

}

/**
*
*	PM41_CardClose()
*	Releases access to the PM429-1 card previously gained by PM41_CardOpen.
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  0 on failue, otherwise for success
*	Warnings: Be sure to have a companion PM41_CardClose call for each
*             PM41_CardOpen call.
*
*/

BOOL PM41_CardClose(USHORT port)
{

#ifdef _WIN32

	HANDLE hCard = PM41_UtilFindCard(port);

	if (FALSE == PM41_UtilPopCard(port))
	{
		return(FALSE);
	}

	return(BTIKRNL_KernelClose(hCard));

#else

	return(TRUE);

#endif

}

/**
*
*	PM41_CardReset()
*	Resets specified PM429-1.
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: REG_CTRLA and REG_CTRLB do not reset upon write to reset register.
*			  This function clears REG_CTRLA/REG_CTRLB, and then resets the card.
*			  The delay is to allow the PM429-1 channel presence bits to stabilize.
*
*/	

VOID PM41_CardReset(USHORT port)	
{
	USHORT delay;		// delay counter

	PM41_RegClr(REG_CTRLA,  port);	// clear REG_CTRLA
	PM41_RegClr(REG_CTRLB,  port);	// clear REG_CTRLB

	PM41_RegWr(1, REG_RESET, port);		// write to reset register

	for(delay = 0; delay <=32; delay++)		// loop through accesses, wait for channel presence bits to stabilize.
	{
		PM41_RegRd(REG_CTRLA, port);
	}
}

/**
*
*	PM41_IsCard()
*	Checks if specified PM429-1 exists
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  TRUE is card present, FALSE if not
*	Warnings: None
*
**/	

BOOL PM41_IsCard(USHORT port)
{
	USHORT val;		// holds ID register value

	val = PM41_RegRd(REG_ID, port);	// read ID register
	val = (val & 0xFFF0);			// filter for relevant value
	
	if(val == IDVAL)	// if correct ID value
	{
		return TRUE;
	}
	return FALSE;
}

/**
*
*	PM41_SelfTest()
*	Performs a hardware test of the PM429-1
*	Arguments:
*		iobase: PM429-1 port setting
*		irq:	PM429-1 IRQ setting
*	Returns:  Zero if card passes, or a negative value indicating the error 
*	Warnings: None
*
**/	

INT PM41_SelfTest(USHORT iobase, USHORT irq)
{
	USHORT count;	// loop counter
	UINT read;		// test variable
	UINT exp;		// comparison variable

	// Verify IO address and IRQ are valid
	if((iobase < IOBASE_MIN) || (iobase > IOBASE_MAX))	return ERR_BADPARAMS;	// outside valid IO range
	if(iobase & 0x00F)									return ERR_BADPARAMS;	// does not end in 0

	if((irq >= 0) && (irq <= 12))		// Only IRQ 3,4,5,7,9,10,11,12 are valid; IRQ 0 skips interrupt tests
	{
		if(irq == 1)	return ERR_BADPARAMS;
		if(irq == 2)	return ERR_BADPARAMS;
		if(irq == 6)	return ERR_BADPARAMS;
		if(irq == 8)	return ERR_BADPARAMS;
	}
	else
	{
		return ERR_BADPARAMS;
	}

	// Verify Card is present
	if(!PM41_IsCard(iobase)) return ERR_NOCARD;
		
	// Verify Page Register is only 4 bits
	for(count = 0; count <= 0xFF; count++)	// Write values 0 - 256 to page register
	{
		PM41_PageWr(count, iobase);
		read = PM41_PageRd(iobase);

		exp = (count % 16);
		if(read != exp) return ERR_SELFIOFAIL;
			
	}

	// Verify IFGA is accessible
	PM41_CardReset(iobase);
	exp = 0x0030; read = PM41_RegRd(REG_TCTRL, iobase);  if (read != exp) return ERR_SELFIOFAIL;

	PM41_RegWr(0xFFFE, REG_TCTRL, iobase);
	exp = 0x003E; read = PM41_RegRd(REG_TCTRL, iobase);  if (read != exp) return ERR_SELFIOFAIL;

	PM41_CardReset(iobase);
	exp = 0x0030; read = PM41_RegRd(REG_TCTRL, iobase);  if (read != exp) return ERR_SELFIOFAIL;

	if (PM41_ChIsXmt(CH4,iobase))
	{
		// Verify Holt part is accessible
		PM41_CardReset(iobase);
		exp = 0x0000; read = PM41_RegRd(REG_CTRLA, iobase);  if (read != exp) return ERR_SELFIOFAIL;

		PM41_RegWr(0xF000, REG_CTRLA, iobase);
		exp = 0xF000; read = PM41_RegRd(REG_CTRLA, iobase);  if (read != exp) return ERR_SELFIOFAIL;

		PM41_CardReset(iobase);
		exp = 0x0000; read = PM41_RegRd(REG_CTRLA, iobase);  if (read != exp) return ERR_SELFIOFAIL;
	}

	// Verify transmission on internal wrap-around (high speed)
	if (PM41_ChIsXmt(CH4,iobase))
	{
		// Configure channels
		PM41_ChConfig(ARINCCTRL_SPEED_HIGH, ARINCCTRL_PAR_ODD, FALSE, TRUE, CH0, iobase);
		PM41_ChConfig(ARINCCTRL_SPEED_HIGH, ARINCCTRL_PAR_ODD, FALSE, TRUE, CH1, iobase);
		PM41_ChConfig(ARINCCTRL_SPEED_HIGH, ARINCCTRL_PAR_ODD, FALSE, TRUE, CH4, iobase);
		PM41_SRQConfig(ASRQ_RCV_RDY,CH0,iobase);

		srand(rand());						// Seed random number generator
		exp = rand();						// Get random number

		PM41_ChDataWr(exp, CH4, iobase);	// Load data
		PM41_ChGapWr(200, CH4, iobase);		// Trigger transmission

		// Wait until data received
		read = 0;
		count = 1000;
		while(!read && count)
		{
			read = (0x0008 && PM41_SRQIsSet(SRQ_RCH0,iobase));
			count--;
		}
		exp = (exp & 0x7FFFFFFF);			// Mask parity bit
		read = PM41_ChDataRd(CH0, iobase);
		read = (read & 0x7FFFFFFF);			// Mask parity bit
		if(read!=exp)	return ERR_SELFXMTFAIL;

		read = PM41_ChDataRd(CH1, iobase);

		read = (~read & 0x7FFFFFFF);			// Mask parity bit

		if(read!=exp)	return ERR_SELFXMTFAIL;
	}

#ifndef _WIN32	// no interrupt support yet.

	// Verify Interrupts	// COMPILER_DEP
	if(irq)
	{
		PM41_CardReset(iobase);

		PM41_LEDBlink(iobase);

		// Configure card for timer interrupt
		PM41_IntEnable(SRQ_TIMER,iobase);

		// Verify card present/jumper on
		if (irq>7)
		{
			PM41_Outp(0x0A,SEC_INT+0);	//Point to IR register
			if((PM41_Inp(SEC_INT+0)>>(irq - 8)) & 0x01)	return ERR_IRQFAIL;
		}
		else
		{
			PM41_Outp(0x0A,MAST_INT+0);	//Point to IR register
			if((PM41_Inp(MAST_INT+0)>>(irq - 0)) & 0x01)	return ERR_IRQFAIL;
		}

		// Trigger interrupt
		PM41_TimerWr(0x000000FF,iobase);
		PM41_RegWr(0x000D,REG_TCTRL,iobase);

		read = 1;
		count = 1000;
		while(read && count)
		{
			read = PM41_TimerRd(iobase);
			count--;
		}

		// Verify interrupt set in controller
		if (irq>7)
		{
			PM41_Outp(0x0A,SEC_INT+0);	//Point to IR register
			if(!(PM41_Inp(SEC_INT+0)>>(irq - 8)) & 0x01)	return ERR_IRQFAIL;
			PM41_Outp(EOI, SEC_OCW);
		}
		else
		{
			PM41_Outp(0x0A,MAST_INT+0);	//Point to IR register
			if(!(PM41_Inp(MAST_INT+0)>>(irq - 0)) & 0x01)	return ERR_IRQFAIL;
			PM41_Outp(EOI, MAST_OCW);
		}


		// Clear interrupt
		PM41_SRQClr(SRQ_TIMER,iobase);

	    }
#endif	// ifndef _WIN32

	// Blink USER LED
	PM41_LEDBlink(iobase);

	PM41_CardReset(iobase);	

	return ERR_NONE;
}

/**
*
*	PM41 SRQ Functions
*
**/

/**
*
*	PM41_SRQIsSet()
*	Checks for specified SRQ(s) from the PM429-1.
*	Arguments:
*		srq:  SRQ(s) to check
*		port: PM429-1 port setting
*	Returns:  TRUE if SRQ specified is set, else FALSE
*	Warnings: None
*
**/

BOOL PM41_SRQIsSet(USHORT srq, USHORT port)
{
	if(PM41_RegRd(REG_SRQ, port) & srq)	// if SRQ set...
	{
		return TRUE;
	}
	return FALSE;
}

/**
*
*	PM41_SRQClr()
*	Clears the specified SRQ bit(s)
*	Arguments:		
*		srq:  SRQ to clear
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: The actual cause of the SRQ must be cleared before the SRQ can be cleared
*
**/

VOID PM41_SRQClr(USHORT srq, USHORT port)
{
	PM41_RegWr(srq, REG_SRQ, port);	// write value to SRQ register
}

/**
*
*	PM41_SRQConfig()
*	Configures ARINC SRQ on specified channel
*	Arguments:
*		status:  SRQ type(s) to set
*		chan:	specified channel
*		port:	PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/ 

VOID PM41_SRQConfig(USHORT status, USHORT chan, USHORT port)
{
	USHORT val;		// value of REG_ASRQ

	val = PM41_RegRd(REG_ASRQ, port); // get current srq

	val = (val & ( ~(ASRQ_MASK_ARINC << (chan * 2)) )); // wipe srq cfg bits from srq register value
	val = (val | (status << (chan*2)));		// OR in new cfg bits

	PM41_OutpW(val, (USHORT)(port+PM41_UtilGetReg(REG_ASRQ)));	// write new value back

}

/**
*
*	PM41 Channel functions
*
**/

/**
*
*	PM41_IsChan()
*	Checks if specified channel is present
*	Arguments:
*		chan: specified channel
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: Cannot detect externally disabled transmitter
*
*/	

BOOL PM41_IsChan(USHORT chan, USHORT port)
{
	if(PM41_IsCard(port))	// if it's  a card...
	{
		return (PM41_RegRd( (USHORT)((chan << 4) | CHAN_CHSTAT), port) & CHSTAT_CHPRESENT);// return channel presence bit
	}
	return FALSE;
}

/**
*
*	PM41_ChIsRcv()
*	Checks if specified channel is receive channel
*	Arguments:
*		chan: specified channel
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

BOOL PM41_ChIsRcv(USHORT chan, USHORT port)
{
	if(PM41_IsChan(chan, port))	// if it's a channel...
	{
		if(chan <= 3)				// and if the channel number is <= 3...
		{
			return TRUE;		// ...the channel is a receiver.
		}
	}
	return FALSE;

}

/**
*
*	PM41_ChIsXmt()
*	Checks if specified channel is transmit channel
*	Arguments:
*		chan: specified channel
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: Cannot detect externally disabled transmitter
*
*/	

BOOL PM41_ChIsXmt(USHORT chan, USHORT port)
{
	if(PM41_IsChan(chan, port))		// if it's a channel...
	{
		if(chan>3)					// and if the channel number is >= 4...
		{
			return TRUE;			// ...the channel is a transmitter.
		}
	}
	return FALSE;

}

/**
*
*	PM41_ChDataWr()
*	Writes 1 dataword to specified ARINC 429 TCH.
*	Arguments:
*		data: Data to write
*		chan: Channel to write data to
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_ChDataWr(UINT data, USHORT chan, USHORT port)
{
	UINT word_l;						// low half of word
	UINT word_h;						// high half of word

	PM41_PageWr(chan, port);			// select channel

	word_l = (data & 0x0000FFFF);		// filter for low word
	PM41_OutpW( (USHORT)word_l, (USHORT)(port+CHAN_CHDATA_L));	// write low word

	word_h = (data & 0xFFFF0000);		// filter for high word
	word_h = (word_h >> 16);			// shift high word
	PM41_OutpW( (USHORT)word_h, (USHORT)(port+CHAN_CHDATA_H));	// write high word
}

/**
*
*	PM41_ChDataRd()
*	Reads 1 dataword from specified ARINC 429 RCH.
*	Arguments:
*		chan: Channel to write data to
*		port: PM429-1 port setting
*	Returns:  1 ARINC dataword from channel
*	Warnings: If no data is present in the specified channel FIFO,
*			  an undefined value will be returned.
*
**/	

UINT PM41_ChDataRd(USHORT chan, USHORT port)
{
	UINT word_l;	// low half of word
	UINT word_h;	// high half of word

	PM41_PageWr(chan, port);			// select channel

	word_l = PM41_InpW((USHORT)(port+CHAN_CHDATA_L));	// get low word
	word_h = PM41_InpW((USHORT)(port+CHAN_CHDATA_H));	// get high word

	return ((word_h << 16) | word_l);	// return low and high words ORed together
}

/**
*
*	PM41_ChStatRd()
*	Reads Status register from specified channel
*	Arguments:
*		chan: Channel to read from
*		port: PM429-1 port setting
*	Returns:  Contents of status register from channel
*	Warnings: None
*
**/	

USHORT	PM41_ChStatRd(USHORT chan, USHORT port)
{
	return (PM41_RegRd( (USHORT)((chan << 4) | CHAN_CHSTAT), port));	// return CHSTAT contents
}

/**
*
*	PM41_ChGapWr()
*	Writes gap value to specified TCH
*	Arguments:
*		gap:  Gap value to write (in bit-times)
*		chan: Channel to write to 
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: ChGapWr() causes transmission on specified channel if
*			  data is present in FIFO.
*
**/	

VOID PM41_ChGapWr(USHORT gap, USHORT chan, USHORT port)
{
	PM41_RegWr(gap, (USHORT)((chan << 4) | CHAN_CHGAP), port);	// write gap value
}

/**
*
*	PM41_ChGapRd()
*	Reads gap value from specified TCH
*	Arguments:
*		chan: Channel to read from 
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

USHORT PM41_ChGapRd(USHORT chan, USHORT port)
{
	return PM41_RegRd((USHORT)((chan << 4) | CHAN_CHGAP), port);	// read gap value
}

/**
*
*	PM41_IsChGapDone()
*	Checks if the gap timer has counted down
*	Arguments:
*		chan: Channel to write to 
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

BOOL PM41_IsChGapDone(USHORT chan, USHORT port)
{
	USHORT val;
	val = PM41_RegRd((USHORT)((chan << 4) | CHAN_CHSTAT), port);	// get CHSTAT

	val = (val & CHSTAT_TIMZ);						// filter for gap timer done

	if(val)		// check for gap timer counted down
	{
		return TRUE;
	}
	return FALSE;
}

/**
*
*	PM41_ChClear()
*	Clears receive buffer of specified channel
*	Arguments:
*		chan: Channel to clear
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_ChClear(USHORT chan, USHORT port)
{
	USHORT count;
	for(count = 0; (count<=31); count++)	// loop through rcv buffer entries
	{
		PM41_ChDataRd(chan, port);	// read data and throw away
	}
}
	
/**
*
*	PM41_ChCfg()
*	Sets channel options for specified channel
*	Arguments:
*		speed: ARINCCTRL_SPEED_HIGH or ARINCCTRL_SPEED_LOW
*		parity: ARINCCTRL_PAR_ODD, ARINCCTRL_PAR_EVEN, or ARINCCTRL_PAR_DATA
*		scramble: TRUE for data scramble, FALSE for unscramble
*		selftest: TRUE for self-test bus, FALSE for normal
*		chan: Channel to configure
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: Scramble & Selftest options are global for CH0/CH1/CH4 or CH2/CH3/CH5, not per channel
*
**/

VOID PM41_ChConfig(USHORT speed, USHORT parity, BOOL scramble, BOOL selftest, USHORT chan, USHORT port)
{
	USHORT data;				// holds old contents of REG_CTRLA/REG_CTRLB
	USHORT chanflag;			// flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr( ((REG_ACTRL & 0xF0) >> 4), port);	// set PAGE

	if( (chan == CH0) || (chan == CH1) || (chan == CH4) )		// working with REG_CTRLA
	{
		chanflag = REG_CTRLA;				// set flag
	}
	else if( (chan==CH2) || (chan == CH3) || (chan == CH5) )	// working with REG_CTRLB
	{
		chanflag = REG_CTRLB;				// set flag
	}
	data = PM41_InpW((USHORT)(port+(PM41_UtilGetReg(chanflag))));	// get register data

	scramble ? data = data & ~ARINCCTRL_DATAUNSCRAM : (data = data | ARINCCTRL_DATAUNSCRAM);	// check for scramble option
	selftest ? data = data & ~ARINCCTRL_SELFTESTOFF : (data = data | ARINCCTRL_SELFTESTOFF);	// check for self-test bus option


	if( (chan == CH4) || (chan == CH5)	)// Transmit channel
	{
		parity == ARINCCTRL_PAR_DATA ? data = data & ARINCCTRL_PAR_DATA : (data = data | ~ARINCCTRL_PAR_DATA);	// check no parity/for parity
		parity == ARINCCTRL_PAR_EVEN ? data = data | ARINCCTRL_PAR_EVEN : (data = data | ARINCCTRL_PAR_ODD);	// check for even/odd parity

		speed == ARINCCTRL_SPEED_HIGH ? data = data & ~(speed << 13) : (data = data | (speed << 13));	// set speed
	}

	if( (chan == 0) || (chan == 2)	) // set speed for 1st RCH
	{
		speed == ARINCCTRL_SPEED_HIGH ? data = data & ~(speed << 0) : (data = data | (speed << 0));
	}

	if( (chan == 1) || (chan == 3)	) // set speed for 2nd RCH
	{
		speed == ARINCCTRL_SPEED_HIGH ? data = data & ~(speed << 14) : (data = data | (speed << 14));
	}

	PM41_OutpW(data, (USHORT)(port+(PM41_UtilGetReg(chanflag))));	// write to REG_CTRLA
}

/**
*
*	PM41 Filter functions
*
**/

/**
*
*	PM41_FilterSDISet()
*	Sets SDI filter for specified channel
*	Arguments:
*		SDI:  SDI (CFG_SDI_xx)
*		chan: Channel to set
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/

VOID PM41_FilterSDISet(USHORT sdi, USHORT chan, USHORT port)
{
	USHORT data;		// old REG_CTRLA data
	USHORT chanflag;	// flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr( ((REG_ACTRL & 0xF0) >> 4), port );	// set PAGE register

	if( (chan == CH0) || (chan == CH1) )		// working w/ REG_CTRLA
	{
		chanflag = REG_CTRLA;	// set flag
	}
	else if( (chan == CH2) || (chan == CH3) )	// working w/ REG_CTRLB
	{
		chanflag = REG_CTRLB;	// set flag
	}
	
	data = PM41_InpW((USHORT)(port+(PM41_UtilGetReg(chanflag))));		// get current value
	
	( (chan == 0) || (chan == 2) ) ? data = data & ~(ASRQ_MASK_ARINC << 7) : (data = data & ~(ASRQ_MASK_ARINC << 10));	// mask off appropriate SDI value

	if(sdi != ARINCCTRL_CFG_SDI_NONE)	// setting SDI
	{
		( (chan == 0) || (chan == 2) ) ? data = data | (sdi << 7) : (data = data | (sdi << 10));	// OR in filter value
		( (chan == 0) || (chan == 2) ) ? data = data | (ARINCCTRL_CFG_SDI_EN << 6) : (data = data | (ARINCCTRL_CFG_SDI_EN << 9));	// OR in enable bit
	}

	PM41_OutpW(data, (USHORT)(port+(PM41_UtilGetReg(chanflag))));	// write to REG_CTRLA/B
}

/**
*
*	PM41_FilterSDIClear()
*	Clears SDI filter for specified channel
*	Arguments:
*		chan: Channel to clear
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_FilterSDIClear(USHORT chan, USHORT port)
{
	USHORT data;		// old REG_CTRLA/B data
	USHORT chanflag;	// flag for REG_CTRLA/REG_CTRLB

	PM41_PageWr( ((REG_ACTRL & 0xF0)>>4), port);	// set PAGE register

	if( (chan == CH0) || (chan == CH1) )		// working w/ REG_CTRLA
	{
		chanflag = REG_CTRLA;	// set flag
	}
	else if( (chan == CH2) || (chan == CH3) )	// working w/ REG_CTRLB
	{
		chanflag = REG_CTRLB;	// set flag
	}

	data = PM41_InpW((USHORT)(port+(PM41_UtilGetReg(chanflag))));		// get current value
	
	( (chan == 0) || (chan == 2) ) ? data = data & ~(ASRQ_MASK_ARINC << 7) : (data = data & ~(ASRQ_MASK_ARINC << 10));	// mask off appropriate SDI value

	( (chan == 0) || (chan == 2) ) ? data = data & ~(ASRQ_MASK_ENABLE << 6) : (data = data & ~(ASRQ_MASK_ENABLE << 9));	// turn off sdi filter


	PM41_OutpW(data, (USHORT)(port+(PM41_UtilGetReg(chanflag))));	// write to REG_CTRLA/B

}

/**
*
*	PM41_FilterLabelSet()
*	Sets label filter for specified channel
*	Arguments:
*		label[16]:  array of 16 labels
*		chan:		Channel to set
*		port:		PM429-1 port setting
*	Returns:  None
*	Warnings: 
*
*/	

VOID PM41_FilterLabelSet(UCHAR label[16], USHORT chan, USHORT port)
{
	USHORT data;	// holds register value

	PM41_PageWr( (PM41_UtilGetPage(REG_CTRLA)), port);	// set page
	
	( (chan == CH0) || (chan == CH1) ) ? data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : (data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLB))));	// get data

	data = data | (ARINCCTRL_CFG_LABEL_FLT);	// set label memory open

	( (chan == CH0) || (chan == CH1) ) ? PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLB)));	// write data

	( (chan == CH0) || (chan == CH1) ) ? PM41_PageWr(CH4, port) : PM41_PageWr(CH5, port);	// set page

	if( (chan == CH0) || (chan == CH2) )	// using lower channel
	{
		for(data = 0; data <= 15; data++)	// loop through array positions
		{
			PM41_OutpW((USHORT)label[data], (USHORT)(port+CHAN_CHDATA_L));	// write labels
		}
	}

	if( (chan == CH1) || (chan == CH3) )	// using upper channel
	{
		for(data = 0; data <= 15; data++)	// loop through array positions
		{
			PM41_OutpW((USHORT)label[data], (USHORT)(port+CHAN_CHDATA_H));	// write labels
		}
	}

	PM41_PageWr(PM41_UtilGetPage(REG_CTRLA), port);	// set page

	( (chan == CH0) || (chan == CH1) ) ? data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : (data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLB))));	// get data

	data = data & ~(ARINCCTRL_CFG_LABEL_FLT);	// set label memory close

	( (chan == CH0) || (chan == CH2) ) ? data = data | ARINCCTRL_CFG_LABEL_CH0 : (data = data | ARINCCTRL_CFG_LABEL_CH1 ); // set filter enable

	( (chan == CH0) || (chan == CH1) ) ? PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLB)));	// write data
}

/**
*
*	PM41_FilterLabelClr()
*	Disables label filter for specified channel
*	Arguments:
*		chan: Channel to clear
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_FilterLabelClr(USHORT chan, USHORT port)
{
	USHORT data;	// holds data from card
	PM41_PageWr(chan, port);	// set page value

	(chan<2) ? data = PM41_InpW((USHORT)(port+REG_CTRLA)) : (data = PM41_InpW((USHORT)(port+REG_CTRLB)));	// get REG_CTRLA/REG_CTRLB

	( (chan == 0) || (chan == 2) ) ?	data = data & ~(ARINCCTRL_CFG_LABEL_CH0) : (data = data & ~(ARINCCTRL_CFG_LABEL_CH1));	// set label filter off

	(chan<2) ? PM41_OutpW(data, (USHORT)(port+REG_CTRLA)) : PM41_OutpW(data, (USHORT)(port+REG_CTRLB));	// write data back
}

/**
*
*	PM41_FilterLabelRead()
*	Reads label filter for specified channel
*	Arguments:
*		chan: Channel to read from
*		port: PM429-1 port setting
*	Returns:  Pointer to array of label values
*	Warnings: None
*
**/	

PUCHAR PM41_FilterLabelRead(PUCHAR labels,USHORT chan, USHORT port)
{
	USHORT data;	// holds data from card
	PM41_PageWr( PM41_UtilGetPage(REG_CTRLA), port);	// set page to ARINCCTRL (0x9)

	(chan<2) ? data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : (data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLB))));		// get data from register

	data = data | (ARINCCTRL_CFG_LABEL_FLT);	// set label memory open

	(chan<2) ? PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLB)));	// write data back
	
	PM41_PageWr(chan, port);	// set page to channel
	
	for(data=0; data<=15; data++)	// loop through labels
	{
		labels[data] = (UCHAR)PM41_InpW((USHORT)(port+CHAN_CHDATA_L));	// read label into array
	}

	PM41_PageWr( ((REG_ACTRL & 0xF0) >> 4), port);	// set page to ARINCCTRL (0x9)
	(chan<2) ? data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : (data = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_CTRLB))));	// read data

	data = data & ~(ARINCCTRL_CFG_LABEL_FLT);	// set label memory close

	(chan<2) ? PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLA))) : PM41_OutpW(data, (USHORT)(port+PM41_UtilGetReg(REG_CTRLB)));	// write data back

	return &labels[0];
}

/**
*
*	PM41 LED functions
*
**/

/**
*
*	PM41_IsLEDSet()
*	Reads status of external LED
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  TRUE = on, FALSE = off
*	Warnings: None
*
*/	

BOOL PM41_IsLEDSet(USHORT port)
{
	BOOL val;	// holds LED value

	val = (PM41_RegRd(REG_CLKCTRL, port) & LED_ON);	// get current led value

	return val;
}

/**
*
*	PM41_LEDWr()
*	Turns LED on or off
*	Arguments:
*		val:  LED value (TRUE = on, FALSE = off)
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_LEDWr(BOOL val, USHORT port)
{
	val ? PM41_RegBitSet(LED_ON, REG_CLKCTRL, port) : PM41_RegBitClr(LED_ON, REG_CLKCTRL, port);	// set/clear LED
}

/**
*
*	PM41_LEDBlink()
*	Blinks user LED once (on, off)
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: This function uses the on-board timer
*
**/	

VOID PM41_LEDBlink(USHORT port)
{
	USHORT timeval = 1;		// timer value
	USHORT period = 250;	// change this value to change LED frequency

	PM41_LEDWr(TRUE, port);		// set LED
	PM41_TimerClr(port);		// clear timer
	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_STOPZERO, port);	// 1 Msec
	PM41_TimerWr(period, port);	// 250 Msec
	PM41_TimerStart(port);		// start timer

	do	// wait for timer to count down
	{
		timeval = (USHORT)PM41_TimerRd(port);	// read timer val
	}while(timeval);


	PM41_LEDWr(FALSE, port);	// reset LED
	PM41_TimerClr(port);		// clear timer
	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_STOPZERO, port);	// 1 Msec
	PM41_TimerWr(period, port);	// 250 Msec
	PM41_TimerStart(port);		// start timer

	timeval = 1;				// reinit timeval

	do	// wait for timer to count down
	{
		timeval = (USHORT)PM41_TimerRd(port);	// read timer val
	}while(timeval);

	PM41_TimerStop(port);		// stop timer
}

/**
*
*	PM41 Timer functions
*
**/

/**
*
*	PM41_TimerConfig()
*	Configures on-board timer
*	Arguments:
*		ctrlflags:  Timer settings
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/

VOID PM41_TimerConfig(USHORT cfgflags, USHORT port)
{
	PM41_RegWr(cfgflags, REG_TCTRL, port);
}

/**
*
*	PM41_TimerStart()
*	Starts on-board timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_TimerStart(USHORT port)
{
	PM41_RegBitSet(TCTRL_EN, REG_TCTRL, port);
}

/**
*
*	PM41_TimerStop()
*	Stops on-board timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_TimerStop(USHORT port)
{
	PM41_RegBitClr(TCTRL_EN, REG_TCTRL, port);
}

/**
*
*	PM41_TimerClr()
*	Stops and clears on-board timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: This function clears both the timer value and the timer control register
*
*/	

VOID PM41_TimerClr(USHORT port)
{
	PM41_PageWr(PM41_UtilGetPage(REG_TCTRL),port);
	PM41_OutpW(0x0000, (USHORT)(port+PM41_UtilGetReg(REG_TCTRL )));		// stop timer, reset all flags
	PM41_OutpW(0x0000, (USHORT)(port+PM41_UtilGetReg(REG_TIME_L)));		// reset timer low word
	PM41_OutpW(0x0000, (USHORT)(port+PM41_UtilGetReg(REG_TIME_H)));		// reset timer high word
}

/**
*
*	PM41_TimerRd()
*	Reads on-board timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  Timer value
*	Warnings: None
*
*/	

UINT PM41_TimerRd(USHORT port)
{
	UINT data_l;	// low word of timer
	UINT data_h;	// high word of timer

	PM41_PageWr((PM41_UtilGetPage(REG_TCTRL)), port);	// set PAGE

	data_l = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_TIME_L)));	// get low word
	data_h = PM41_InpW((USHORT)(port+PM41_UtilGetReg(REG_TIME_H)));	// get high word
	data_h = data_h << 16;		// shift high word
	data_l = data_l | data_h;	// OR low and high words together

	return data_l;	// return Complete word
}

/**
*
*	PM41_TimerWr()
*	Writes value to on-board timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  Timer value
*	Warnings: None
*
*/	

VOID PM41_TimerWr(UINT timeval, USHORT port)
{
	UINT val;	// holds data from card
	PM41_PageWr(PM41_UtilGetPage(REG_TCTRL), port);	// set PAGE

	val = (timeval & 0x0000FFFF);	// get low word of timeval
	PM41_OutpW((USHORT)val, (USHORT)(port+PM41_UtilGetReg(REG_TIME_L)));		// write low word

	val = (timeval & 0xFFFF0000) >> 16;	// get high word of timeval
	PM41_OutpW((USHORT)val, (USHORT)(port+PM41_UtilGetReg(REG_TIME_H)));		// write high word
}

/**
*
*	PM41_TimerSRQEn()
*	Enables SRQs on timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM41_TimerSRQEn(USHORT port)
{
	PM41_RegBitSet(TCTRL_SRQEN, REG_TCTRL, port);
}

/**
*
*	PM41_TimerSRQDis()
*	Disables SRQs on timer
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
**/	

VOID PM41_TimerSRQDis(USHORT port)
{
	PM41_RegBitClr(TCTRL_SRQEN, REG_TCTRL, port);
}

/**
*
*	PM41 DIN functions
*
**/

/**
*
*	PM41_IsDINSet()
*	Reads value of specified DIN
*	Arguments:
*		din:  Specified DIN
*		port: PM429-1 port setting
*	Returns:  TRUE if set, FALSE if not
*	Warnings: None
*
*/	

BOOL PM41_IsDINSet(USHORT din, USHORT port)
{
	USHORT data;	// holds data from card

	data = PM41_RegRd(REG_DIN, port);	// get data
	data = (data & din);	// filter for specified DIN

	return (BOOL)data;	
}

/**
*
*	PM41_DINConfig()
*	Configures digital inputs
*	Arguments:
*		res:  Sample rate resolution (DBRES_1U or DBRES_1M)
*		period: Sample rate period
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/	

VOID PM41_DINConfig(USHORT res, USHORT period, USHORT port)
{
	PM41_RegWr( (USHORT)(res | period), REG_DSAMP, port);
}

/**
*
*	PM41_DINSRQRd()
*	Reads value of DIN SRQ configuration register
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  DINT register value
*	Warnings: None
*
*/	
USHORT PM41_DINSRQRd(USHORT port)
{
	return PM41_RegRd(REG_DINT, port);
}

/**
*
*	PM41_DINSRQSet()
*	Sets digital input SRQ configuration
*	Arguments:
*		srq:  SRQ settings (DINT_SRQ_7P, etc)
*		port: PM429-1 port setting
*	Returns:  DINT register value
*	Warnings: None
*
*/	

VOID PM41_DINSRQSet(USHORT srq, USHORT port)
{
	PM41_RegWr(srq, REG_DINT, port);	
}

/**
*
*	PM41 DOUT functions
*
**/

/**
*
*	PM41_DOUTWr()
*	Sets specified DOUT
*	Arguments:
*		dout: specified dout (DOUT_0 - DOUT_3)
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None
*
*/

VOID PM41_DOUTWr(USHORT dout, USHORT port)
{
	PM41_RegWr(dout, REG_DOUT_S, port);
}

/**
*
*	PM41_DOUTIsSet()
*	Reads specified DOUT
*	Arguments:
*		dout: specified dout (DOUT_0 - DOUT_3)
*		port: PM429-1 port setting
*	Returns:  TRUE if set, FALSE if reset
*	Warnings: None
*
*/	

BOOL PM41_DOUTIsSet(USHORT dout, USHORT port)
{
	return (PM41_RegRd(REG_DOUT_ST, port) & dout);	
}

/**
*
*	PM41_DOUTClr()
*	Clears specified DOUT
*	Arguments:
*		dout: specified dout (DOUT_0 - DOUT_3)
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None 
*
**/

VOID PM41_DOUTClr(USHORT dout, USHORT port)
{
	PM41_RegWr(dout, REG_DOUT_C,  port);
}

/**
*
*	PM41 Interrupt Functions
*
**/

/**
*
*	PM41_IntEnable()
*	Enables specified interrupts from PM429-1
*	Arguments:
*		intsource: specified interrupt
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: This function will overwrite the previous settings of REG_INTMASK 
*
**/

VOID PM41_IntEnable(USHORT intsource, USHORT port)
{
	PM41_RegWr((USHORT)(intsource | INTMASK_ENABLE), REG_INTMASK, port);
}

/**
*
*	PM41_IntDisable()
*	Diables interrupts from PM429-1
*	Arguments:
*		port: PM429-1 port setting
*	Returns:  None
*	Warnings: None 
*
**/

VOID PM41_IntDisable(USHORT port)
{
	PM41_RegBitClr(INTMASK_ENABLE, REG_INTMASK, port);
}
