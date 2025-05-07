/**
*
*  PM1553-1 C/C++ DRIVER  Version 1.0  (06/21/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11.H --  PM1553-1 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the C/C++ 
*  Driver Library for the PM1553-1.  Applications
*  using the PM1553-1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "PM11.H"
*
*  Refer to the C++ manual for more information on
*  header files.
*
**/

/**
*
*  Conditional block to prevent multiple #defines	
*
**/

#ifndef _PM15531_H
#define _PM15531_H

/**
*
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*  typedefs of structures used in the PM1553-1 driver
*
**/

#ifndef RTDESCBLOCK								//RT Descriptor Block structure

typedef struct
{
	//
	//  These values are set into the RT descriptor block of the PM1553-1
	//

	USHORT ctrlwrd;								//Control word
	USHORT dptra;								//Data pointer A
	USHORT dptrb;								//Data pointer B
	USHORT bcastptr;							//Broadcast pointer

	//
	//  These values are set in host memory
	//

	USHORT baseaddr;							//Descriptor block base address

} RTDESCBLOCK;

#endif

#ifndef CMDBLOCK								//BC Command Block structure

typedef struct
{
	//
	//  These values are set into or read from the command block of the PM1553-1
	//

	USHORT ctrlwrd;								//Control Word
	USHORT cwd1;								//CWD #1
	USHORT cwd2;								//CWD #2
	USHORT dataptr;								//BC data pointer
	USHORT swd1;								//SWD #1
	USHORT swd2;								//SWD #2
	USHORT branchaddr;							//Branch Address
	USHORT timeval;								//Timer value

	//
	//  These values are set in host memory
	//

	USHORT baseaddr;							//Command block base address (in PM1553-1)
	USHORT datacount;							//Number of data words
	USHORT data[32];							//Data buffer

} CMDBLOCK;

#endif

#ifndef MONBLOCK								//Monitor Block structure

typedef struct
{
	//
	//  These values are read from the PM1553-1
	//

	USHORT msginfowrd;							//Message information word
	USHORT cwd1;								//CWD #1
	USHORT cwd2;								//CWD #2
	USHORT dataptr;								//Monitor data pointer
	USHORT swd1;								//SWD #1
	USHORT swd2;								//SWD #2
	USHORT timeval;								//Timer value

	//
	//  Note that there is no entry for the unused monitor block word
	//

	//
	//  These values are set in host memory
	//

	USHORT baseaddr;							//Monitor block base address
	USHORT datacount;							//Number of data words
	USHORT data[32];							//Data buffer
} MONBLOCK;

#endif

/**
*
*  Memory size #defines for RT descriptor blocks, BC command blocks, and MON blocks:
*  Adding these values to the base address of the previous block will give the 
*  next block's base address
*
**/

#define RT_BLOCK_SIZE  0x4
#define BC_BLOCK_SIZE  0x8
#define MON_BLOCK_SIZE 0x8

/**
*
*  TRUE and FALSE #defines
*
**/

#define TRUE  1
#define FALSE 0

/**
*
*  Error #define constants -- used by PM11_CardTest()
*
***/

#define ERR_NONE          0
#define ERR_UNKNOWN      -1
#define ERR_BADPARAMS   -11
#define ERR_NOCARD      -13
#define ERR_SELFIOFAIL  -71
#define ERR_BITFAIL     -74
#define ERR_IRQFAIL     -75

/**
*
*  I/O base range #defines -- used by PM11_CardTest()
*
**/

#define PORTNUM_MIN 0x200						//Minimum I/O setting
#define PORTNUM_MAX 0x3F0						//Maximum I/O setting

/**
*
*  Register #defines: 
*  Note that the ID and RESET registers share the same address. 
*
**/

//
//  These registers are located on the PM1553-1 IFGA
//

#define CREG_STATUS			0x00				//Status register
#define CREG_RESET			0x02				//Reset register (write)
#define CREG_ID				0x02				//ID register (read)
#define CREG_MISC			0x04				//Misc. register
#define CREG_INTCFG			0x06				//Interrupt Config. register
#define CREG_TIMERS			0x08				//Timers register
#define CREG_ADDR			0x0A				//Index address register
#define CREG_DATA			0x0C				//Indexed data register
#define CREG_DATA_INC		0x0E				//Indexed data w/ post-increment register

//
//  These registers are located on the SuMMIT, and apply to all PM1553-1 boards.
//

#define SREG_CTRL			0x00				//Control register
#define SREG_OPSTAT			0x01				//Operational status register
#define SREG_CURCMD			0x02				//Current Command register
#define SREG_INTMASK		0x03				//Interrupt mask register
#define SREG_INTPEND		0x04				//Pending interrupt register
#define SREG_INTLOG			0x05				//Interrupt log list pointer register
#define SREG_BITWORD		0x06				//BIT word register
#define SREG_ILLEGAL		0x10				//Illegalization register (base) 

//
//  These registers apply to RT mode PM1553-1 boards only.
//

#define SREG_RT_TIMETAG		0x07				//Timetag timer register
#define SREG_RT_DESCPTR		0x08				//RT Descriptor pointer
#define SREG_RT_STATWRD		0x09				//1553 Status word register

//
//  These registers apply to BC mode PM1553-1 boards only
//

#define SREG_BC_FRAMETIME	0x07				//Minor frame timer
#define	SREG_BC_CMDBLKPTR	0x08				//BC command block pointer register
#define SREG_BC_CMDBLKINIT	0x0A				//BC Command block initialization count register

//
//  These registers apply to Monitor mode PM1553-1 boards only
//

#define SREG_MON_COMBLKPTR	0x0B				//Monitor command block register
#define SREG_MON_DATAPTR	0x0C				//Monitor data pointer register
#define SREG_MON_BLKCOUNT	0x0D				//Monitor block counter register
#define SREG_MON_FILT_H		0x0E				//Monitor filter register (high)
#define SREG_MON_FILT_L		0x0F				//Monitor filter register (low)

/**
*
*  Helper constants -- IFGA registers
*
**/

//
//  CREG_STATUS (0x0) #defines
//

#define PROM_WE				0x0080				//PROM write enable
#define READY				0x0040				//SuMMIT ready
#define BIST				0x0020				//BIST active
#define TCLK				0x0008				//Trigger TCLK
#define SSFSRQ				0x0004				//SSF Timer interrupt
#define YFINT				0x0002				//You Failed interrupt
#define MSGINT				0x0001				//MSG interrupt

//
//  CREG_RESET #defines (0x2) (write)
//

#define RESET_AUTOINIT		0x0001				//Reset w/ autoinitialization
#define RESET_NORMAL		0x0000				//Reset w/o autoinit

//
//  CREG_ID #defines (0x2) (read)
//

#define IDVAL						0x1170		//PM11 ID register default value

//
//  CREG_MISC #defines (0x4)
//

#define LED_SET						0x4000		//LED set
#define DOUT_1_SET					0x2000
#define DOUT_0_SET					0x1000
#define DIN3						0x0800
#define DIN2						0x0400
#define DIN1						0x0200
#define DIN0						0x0100
#define PROM_ENABLE					0x0080		//PROM enable
#define AUTOINIT_EN					0x0040		//SuMMIT autoinit enable
#define TIMER_MODE					0x0020		//Timer mode bit
#define SSF_TIMER_EN				0x0010		//Subsystem flag timer enable
#define TCLK_SEL					0x0008		//External timetag clock select
#define SSF_SET						0x0004		//Subsystem flag set

//
//  CREG_INTCFG #defines (0x6)
//

#define PCIEN						0x0010		//PC Interrupt enable
#define SSFTIEN						0x0004		//SSF Timer Interrupt Enable
#define YFIEN						0x0002		//You Failed Interrupt enable
#define MSGIEN						0x0001		//MSG Interrupt Enable

//
//  CREG_TIMERS #defines (0x8)
//

#define DIN_RES_4US					0x0000
#define DIN_RES_4MS					0x8000

//
//  No values for CREG_ADDR (0xA)
//

//
//  No values for CREG_DATA (0xC)
//

//
//  No values for CREG_DATA_INC (0xE)
//

/**
*
*  #defines: Summit common registers
*
**/

//
//  SREG_CTRL (0x0) #defines
//

#define STEX		0x8000			//Start execution
#define SBIT		0x4000			//Start BIT
#define SRST		0x2000			//Software reset
#define CHAEN		0x1000			//BUS A enable
#define CHBEN		0x0800			//BUS B enable
#define ETCE		0x0400			//External time clock enable -- enables CREG_STATUS bit 3 to increment timetag clock
#define BUFR		0x0040			//Buffer mode enable
#define BCEN		0x0010			//Broadcast enable
#define DYNBBC		0x0008			//Dynamic BC acceptance
#define PPEN		0x0004			//ping-pong enable
#define INTEN		0x0002			//Interrupt log enable
#define XMTSW		0x0001			//Transmit status word (1553A operation)

//
//  SREG_OPSTAT (0x2) #defines
//

#define MODE_RTMON	0x0300			//RT/MON mode
#define MODE_MON	0x0200			//Monitor mode
#define MODE_RT		0x0100			//RT mode
#define MODE_BC		0x0000			//BC mode

#define SSYSF		0x0010			//Subsystem flag
#define EX			0x0008			//SuMMIT executing
#define TAPF		0x0004			//Terminal address parity fail
#define SREADY		0x0002			//SuMMIT ready
#define TERACT		0x0001			//Terminal active

/**
*
*  Helper constants -- PROM
*
**/

//
//  PROM Sectors -- used by PM11_ROMWipeSect()
//

#define PROM_SECT_0 0x00000
#define PROM_SECT_1 0x04000
#define PROM_SECT_2 0x08000
#define PROM_SECT_3 0x0C000
#define PROM_SECT_4 0x10000
#define PROM_SECT_5 0x14000
#define PROM_SECT_6 0x18000
#define PROM_SECT_7 0x1C000

/**
*
*  Helper constants -- Timer
*
**/

#define TIMER_MODE_FREE 1
#define TIMER_MODE_ONCE 0

/**
*
*  Device driver ioctl numbers
*
**/

#define IOCTL_GET_IOCOUNT		_IOR(  'B', 0x12, unsigned char)
#define	IOCTL_INTERRUPT_ON		_IO(   'B', 0x13)
#define	IOCTL_INTERRUPT_OFF 	_IO(   'B', 0x14)
#define IOCTL_GET_IRQNUM		_IOR(  'B', 0x16, unsigned char)
#define	IOCTL_PORT_RDB_SINGLE	_IOWR( 'B', 0x20, unsigned int)
#define	IOCTL_PORT_WRB_SINGLE	_IOWR( 'B', 0x21, unsigned int)
#define	IOCTL_PORT_RDW_SINGLE	_IOWR( 'B', 0x74, unsigned int)
#define	IOCTL_PORT_WRW_SINGLE	_IOWR( 'B', 0x75, unsigned int)
#define	IOCTL_INTERRUPT_PARAM	_IOWR( 'B', 0x76, unsigned long *)
#define IOCTL_GET_IOWINSIZE0    _IOR(  'B', 0x3C, unsigned long)
#define IOCTL_GET_IOWINBASE0    _IOR(  'B', 0x3E, unsigned long)

/**
*
*  Function prototypes
*
**/

/**
*
*  Card open/close functions
*
**/

BOOL    PM11_CardOpen(HANDLE* handleptr,INT portnum,INT irqnum);
VOID    PM11_CardClose(HANDLE handleval);

/**
*
*  Utility functions
*
**/

USHORT  PM11_PackCWD(INT TAval,INT TRval,INT SAval,INT WCval);
VOID    PM11_UnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRval,LPINT SAval,LPINT WCval);

/**
*
*  Host I/O functions
*
**/

VOID    PM11_PortWrB(UCHAR data,INT offset,HANDLE handleval);
UCHAR   PM11_PortRdB(INT offset,HANDLE handleval);
VOID    PM11_PortWrW(USHORT data,INT offset,HANDLE handleval);
USHORT  PM11_PortRdW(INT offset,HANDLE handleval);

/**
*
*  PM11 Register functions
*
**/

VOID    PM11_RegWr(USHORT data,USHORT reg,HANDLE handleval);
USHORT  PM11_RegRd(USHORT reg,HANDLE handleval);
VOID    PM11_RegClr(USHORT reg,HANDLE handleval);
VOID    PM11_RegBitSet(USHORT mask,USHORT reg,HANDLE handleval);
VOID    PM11_RegBitClr(USHORT mask,USHORT reg,HANDLE handleval);

/**
*
*  PM11 SuMMIT register functions
*
**/

VOID    PM11_SummitWr(USHORT data,USHORT addr,HANDLE handleval);
USHORT  PM11_SummitRd(USHORT addr,HANDLE handleval);
VOID    PM11_SummitClr(USHORT addr,HANDLE handleval);
VOID    PM11_SummitBitSet(USHORT mask,USHORT addr,HANDLE handleval);
VOID    PM11_SummitBitClr(USHORT mask,USHORT addr,HANDLE handleval);

/**
*
*  PM11 Card/Summit functions
*
**/

VOID    PM11_SummitStart(HANDLE handleval);
VOID    PM11_SummitStop(HANDLE handleval);
BOOL    PM11_SummitIsReady(HANDLE handleval);

VOID    PM11_CardReset(HANDLE handleval);
BOOL    PM11_IsCard(HANDLE handleval);
INT     PM11_SelfTest(HANDLE handleval);
VOID    PM11_ModeSet(USHORT modeval,HANDLE handleval);

/**
*
*  PM11 PROM/memory functions
*
**/

INT     PM11_ROMWr(UCHAR data,UINT addr,HANDLE handleval);
UCHAR   PM11_ROMRd(UINT addr,HANDLE handleval);
INT     PM11_ROMWipe(HANDLE handleval);
INT     PM11_ROMWipeSect(UCHAR sector,HANDLE handleval);
INT     PM11_ROMWrIsComplete(HANDLE handleval);
UINT    PM11_ROMGetIDVal(HANDLE handleval);
VOID    PM11_ROMReset(HANDLE handleval);

VOID    PM11_MemFill(USHORT fillval,USHORT range,HANDLE handleval);
USHORT  PM11_MemGetSize(HANDLE handleval);

/**
*
*  PM11 RT functions
*
**/

VOID    PM11_RTAddrSet(USHORT rtaddr,HANDLE handleval);
VOID    PM11_RTDescBlockWr(RTDESCBLOCK* descblock,HANDLE handleval);
VOID    PM11_RTDescBlockRd(RTDESCBLOCK* descblock,HANDLE handleval);

/**
*
*  PM11 BC functions
*
**/

VOID    PM11_BCCmdBlockWr(CMDBLOCK* cmdblock,HANDLE handleval);
VOID    PM11_BCCmdBlockRd(CMDBLOCK* cmdblock,HANDLE handleval);

/**
*
*  PM11 Monitor functions
*
**/

VOID    PM11_MonBlockRd(MONBLOCK* monblock,HANDLE handleval);

/**
*
*  PM11 LED functions
*
**/

BOOL    PM11_LEDIsSet(HANDLE handleval);
VOID    PM11_LEDWr(BOOL val,HANDLE handleval);
VOID    PM11_LEDBlink(HANDLE handleval);

/**
*
*  PM11 Timer functions
*
**/

VOID    PM11_TimerConfig(USHORT cfgflags,HANDLE handleval);
USHORT  PM11_TimerRd(HANDLE handleval);
VOID    PM11_TimerWr(USHORT timeval,HANDLE handleval);
VOID    PM11_TimerSSFEn(HANDLE handleval);
VOID    PM11_TimerSSFDis(HANDLE handleval);

/**
*
*  PM11 DIN functions
*
**/

BOOL    PM11_DINIsSet(USHORT mask,HANDLE handleval);
VOID    PM11_DINConfig(USHORT resolution,USHORT period,HANDLE handleval);

/**
*
*  PM11 DOUT functions
*
**/

VOID    PM11_DOUTSet(USHORT dout,HANDLE handleval);
BOOL    PM11_DOUTIsSet(USHORT dout,HANDLE handleval);
VOID    PM11_DOUTClr(USHORT dout,HANDLE handleval);

/**
*
*  PM11 Interrupt/SRQ Functions
*
**/

VOID    PM11_SRQClr(USHORT mask,HANDLE handleval);
USHORT  PM11_SRQRd(USHORT mask,HANDLE handleval);
BOOL    PM11_IntInstall(HANDLE hEvent,HANDLE handleval);
VOID    PM11_IntUninstall(HANDLE handleval);
VOID    PM11_IntEnable(USHORT intsource,HANDLE handleval);
VOID    PM11_IntDisable(USHORT intsource,HANDLE handleval);

#ifdef __cplusplus
}
#endif

#endif			//_PM15531_H
