/**
*
*  PM429-1 C/C++ DRIVER  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41.H --  PM429-1 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the C/C++ 
*  Driver Library for the PM429-1.  Applications
*  using the PM429-1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "PM41.H"
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

#ifndef _PM4291_H
#define _PM4291_H

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
*  TRUE and FALSE #defines
*
**/

#define TRUE  1
#define FALSE 0

/**
*
*  Error #define constants -- used by PM41_CardTest()
*
***/

#define	ERR_NONE		  0
#define	ERR_UNKNOWN		 -1
#define	ERR_BADHANDLE	 -2
#define	ERR_BADPARAMS	-11
#define	ERR_NOCARD		-13
#define	ERR_SELFIOFAIL	-71
#define	ERR_SELFXMTFAIL	-74
#define	ERR_IRQFAIL		-75

/**
*
*  I/O base range #defines -- used by PM41_CardTest()
*
**/

#define PORTNUM_MIN 0x200
#define PORTNUM_MAX 0x3F0

/**
*
*  Page/Register #defines:  The PM429-1 register #defines are 8-bit values, with the
*  first four bits reserved for the page value, and the second four reserved for the
*  register value.  
*
**/

#define REG_SRQ				0x00
#define REG_RESET			0x02
#define REG_PAGE			0x04

#define REG_DSAMP			0x6A
#define REG_DIN				0x6C
#define REG_DINT			0x6E

#define REG_DOUT_ST			0x7A
#define REG_DOUT_S			0x7C
#define REG_DOUT_C			0x7E

#define REG_TIME_L			0x8A
#define REG_TIME_H			0x8C
#define REG_TCTRL			0x8E

#define REG_CTRLA			0x96
#define REG_CTRLB			0x98
#define REG_ASRQ			0x9C
#define REG_ACTRL			0x9E

#define REG_INTMASK			0xAA
#define REG_CLKDIV			0xAC
#define REG_CLKCTRL			0xAE

#define REG_ID				0xBA

/**
*
*  ARINC 429 Channel #defines
*
**/

#define CH0 0x0
#define CH1 0x1
#define CH2 0x2
#define CH3 0x3
#define CH4 0x4
#define CH5 0x5

#define CHAN_CHDATA_L	0x6
#define CHAN_CHDATA_H	0x8
#define CHAN_CHGAP		0xA
#define CHAN_CHCTRL		0xC
#define CHAN_CHSTAT		0xE

/**
*
*  Register Helper Constants
*
**/

//
//  Service Request (SRQ) Register
//

#define SRQ_ALL			0x7FFF
#define SRQ_NONE		0x0000
#define SRQ_TIMER		0x4000
#define SRQ_DIN7		0x2000
#define SRQ_DIN6		0x1000
#define SRQ_DIN5		0x0800
#define SRQ_DIN4		0x0400
#define SRQ_DIN3		0x0200
#define SRQ_DIN2		0x0100
#define SRQ_DIN1		0x0080
#define SRQ_DIN0		0x0040
#define SRQ_TCH5		0x0020
#define SRQ_TCH4		0x0010
#define SRQ_RCH3		0x0008
#define SRQ_RCH2		0x0004
#define SRQ_RCH1		0x0002
#define SRQ_RCH0		0x0001

//
//  No values for RESET Register
//  PAGE Register values are #defined above
//

/**
*
*  CH0 - CH3 Helper Constants (ARINC RCV Channels)
*
**/

//
//  No values for CHDATA_L Register
//

//
//  No values for CHDATA_H Register
//

//
//  Channel Status (CHSTAT) Register
//

#define CHSTAT_CHPRESENT		0x0100		//Channel Present
#define CHSTAT_FIFO_FULL		0x0004		//FIFO Full
#define CHSTAT_FIFO_HALF		0x0002		//FIFO Half-full (or more)
#define CHSTAT_FIFO_RDY			0x0001		//FIFO Ready

/**
*
*  CH4 - CH5 Helper Constants (ARINC XMT Channels)
*
**/

//
//  No values for CHDATA_L Register
//

//
//  No values for CHDATA_H Register
//

//
//  Channel Control (CHCTRL) Register
//

#define CHCTRL_TXEN				0x0001		//Transmit Enable Override

//
//  Channel Status (CHSTAT) Register
//

#define CHSTAT_CHPRESENT		0x0100		//Channel Present
#define CHSTAT_ENTX				0x0010		//Enable Transmit Channel
#define CHSTAT_TIMZ				0x0008		//Timer Zero
#define CHSTAT_FIFO_NOT_FULL	0x0004		//FIFO not full
#define CHSTAT_FIFO_HALF		0x0002		//FIFO half-full (or more)
#define CHSTAT_FIFO_EMPTY		0x0001		//FIFO empty

/**
*
*  PAGE_DIN Helper Constants
*
**/

//
//  Debounce Resolutions (DSAMP) Register
//

#define DSAMP_DBRES_1US			0x0000		//1 microsecond (Usec) resolution
#define DSAMP_DBRES_1MS			0x0400		//1 millisecond (Msec) resolution

//
//  Data Inputs (DIN) Register
//

#define DIN_7			0x0080
#define DIN_6			0x0040
#define DIN_5			0x0020
#define DIN_4			0x0010
#define DIN_3			0x0008
#define DIN_2			0x0004
#define DIN_1			0x0002
#define DIN_0			0x0001

//
//  DIN SRQ Control (DINT) Register
//

#define DINT_SRQ_7P		0x8000
#define DINT_SRQ_7N		0x4000
#define DINT_SRQ_6P		0x2000
#define DINT_SRQ_6N		0x1000
#define DINT_SRQ_5P		0x0800
#define DINT_SRQ_5N		0x0400
#define DINT_SRQ_4P		0x0200
#define DINT_SRQ_4N		0x0100
#define DINT_SRQ_3P		0x0080
#define DINT_SRQ_3N		0x0040
#define DINT_SRQ_2P		0x0020
#define DINT_SRQ_2N		0x0010
#define DINT_SRQ_1P		0x0008
#define DINT_SRQ_1N		0x0004
#define DINT_SRQ_0P		0x0002
#define DINT_SRQ_0N		0x0001

/**
*
*  PAGE_DOUT Helper Constants
*
**/

//
//  Digital Output Status, Set, Clear (DOUT_ST, DOUT_S, DOUT_C) Registers
//

#define DOUT_ALL		0x000F
#define DOUT_NONE		0x0000
#define DOUT_3			0x0008
#define DOUT_2			0x0004
#define DOUT_1			0x0002
#define DOUT_0			0x0001


/**
*
*  PAGE_TIMER Helper Constants
*
**/

//
//  No values for TIME_L Register
//

//
//  No values for TIME_H Register
//

//
//  Timer Control (TCTRL) Register
//

#define TCTRL_RES_1US		0x0000
#define TCTRL_RES_10US		0x0010
#define TCTRL_RES_100US		0x0020
#define TCTRL_RES_1MS		0x0030
#define TCTRL_STOPZERO		0x0008
#define TCTRL_NOSTOPZERO	0x0000
#define TCTRL_SRQEN			0x0004
#define TCTRL_SRQDIS		0x0000
#define TCTRL_INCR			0x0002
#define TCTRL_DECR			0x0000
#define TCTRL_EN			0x0001
#define TCTRL_DIS			0x0000

/**
*
*  PAGE_ARINCCTRL Helper Constants
*
**/

//
//  Channel Control (CTRLA/CTRLB) Registers
//

#define ARINCCTRL_DATAUNSCRAM		0x8000
#define ARINCCTRL_SELFTESTOFF		0x0020
#define ARINCCTRL_LABELMEMOPEN		0x0002

//
//  Filter (CTRLA/CTRLB) Registers
//

#define ARINCCTRL_CFG_LABEL_FLT	0x0002		//Label memory access enable
#define ARINCCTRL_CFG_LABEL_CH0	0x0004		//CH0/CH2 label filter enable
#define ARINCCTRL_CFG_LABEL_CH1	0x0008		//CH1/CH3 label filter enable

//
//  SDI (CTRLA/CTRLB) Registers
//

#define ARINCCTRL_CFG_SDI_NONE	4
#define ARINCCTRL_CFG_SDI_00	0
#define ARINCCTRL_CFG_SDI_01	1
#define ARINCCTRL_CFG_SDI_10	2
#define ARINCCTRL_CFG_SDI_11	3
#define ARINCCTRL_CFG_SDI_EN	1

//
//  Speed (CTRLA/CTRLB) Registers
//

#define ARINCCTRL_SPEED_LOW			1
#define ARINCCTRL_SPEED_HIGH		0

//
//  Parity (CTRLA/CTRLB) Registers
//

#define ARINCCTRL_PAR_ODD			0x0010
#define ARINCCTRL_PAR_EVEN			0x1010
#define ARINCCTRL_PAR_DATA			0xFFEF

//
//  ARINC SRQ Control (ASRQ) Register
//

#define ASRQ_MASK_ENABLE	0x0001		//SDI Filter enable
#define ASRQ_MASK_ARINC		0x0003		//Individual channel mask

//
//  ARINC SRQ Control (ASRQ) Register -- RCV Channels
//

#define ASRQ_RCV_FULL		0x0003
#define ASRQ_RCV_HALF		0x0002
#define ASRQ_RCV_RDY		0x0001
#define ASRQ_RCV_NONE		0x0000

//
//  ARINC SRQ Control (ASRQ) Register -- XMT Channels
//

#define ASRQ_XMT_NFULL		0x0003
#define ASRQ_XMT_HALF		0x0002
#define ASRQ_XMT_EMPT		0x0001
#define ASRQ_XMT_NONE		0x0000

//
//  ARINC Control (ACTRL) Register
//

#define ACTRL_XMTOUTPSELF	0x0004
#define ACTRL_CH235NFD		0x0002
#define ACTRL_CH014NFD		0x0001

/**
*
*  PAGE_SETUP Helper Constants
*
**/

//
//  Interrupt Mask (INTMASK) Register
//

#define INTMASK_ENABLE		0x8000
#define INTMASK_ALL			0x7FFF
#define INTMASK_NONE		0x0000
#define INTMASK_TIMER		0x4000
#define INTMASK_DIN7		0x2000
#define INTMASK_DIN6		0x1000
#define INTMASK_DIN5		0x0800
#define INTMASK_DIN4		0x0400
#define INTMASK_DIN3		0x0200
#define INTMASK_DIN2		0x0100
#define INTMASK_DIN1		0x0080
#define INTMASK_DIN0		0x0040
#define INTMASK_TCH5		0x0020
#define INTMASK_TCH4		0x0010
#define INTMASK_RCH3		0x0008
#define INTMASK_RCH2		0x0004
#define INTMASK_RCH1		0x0002
#define INTMASK_RCH0		0x0001

//
//  No values for CLKDIV Register
//

//
//  Clock Control (CLKCTRL) Register
//

#define LED_ON				0x0010
#define CLKCTRL_DIV_MAIN	0x0000
#define CLKCTRL_DIV_CUST	0x0004
#define CLKCTRL_B_1MHZ		0x0000
#define CLKCTRL_B_DIV		0x0002
#define CLKCTRL_A_1MHZ		0x0000
#define CLKCTRL_A_DIV		0x0001

/**
*
*  PAGE_MISC Helper Constants
*
**/

//
//  Identification (ID) Register
//

#define IDVAL			0x1160		//PM429-1 ID register value 

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

BOOL    PM41_CardOpen(HANDLE* handleptr,INT portnum,INT irqnum);
VOID    PM41_CardClose(HANDLE handleval);
INT     PM41_CardIndex(HANDLE handleval);

/**
*
*  Utility functions
*
**/

INT     PM41_UtilGetPage(USHORT regval);
USHORT  PM41_UtilGetReg(USHORT regval);
UINT    PM41_UtilGetMsgData(UINT data);
BOOL    PM41_UtilGetParity(UINT data);
UINT    PM41_UtilScrambleData(UINT data);
UCHAR   PM41_UtilReverseLabel(UCHAR label);

/**
*
*  Host I/O functions
*
**/

VOID    PM41_PortWrB(UCHAR data,INT offset,HANDLE handleval);
BYTE    PM41_PortRdB(INT offset,HANDLE handleval);
VOID    PM41_PortWrW(USHORT data,INT offset,HANDLE handleval);
USHORT  PM41_PortRdW(INT offset,HANDLE handleval);

/**
*
*  PM41 Register functions
*
**/

VOID    PM41_PageWr(INT page,HANDLE handleval);
USHORT  PM41_PageRd(HANDLE handleval);
VOID    PM41_RegWr(USHORT data,USHORT reg,HANDLE handleval);
USHORT  PM41_RegRd(USHORT reg,HANDLE handleval);
VOID    PM41_RegClr(USHORT reg,HANDLE handleval);
VOID    PM41_RegBitSet(USHORT mask,USHORT reg,HANDLE handleval);
VOID    PM41_RegBitClr(USHORT mask,USHORT reg,HANDLE handleval);

/**
*
*  PM41 Card functions
*
**/

VOID    PM41_CardReset(HANDLE handleval);
BOOL    PM41_IsCard(HANDLE handleval);
INT     PM41_SelfTest(HANDLE handleval);

/**
*
*  PM41 SRQ Functions
*
**/

BOOL    PM41_SRQIsSet(USHORT srq,HANDLE handleval);
VOID    PM41_SRQClr(USHORT srq,HANDLE handleval);
VOID    PM41_SRQConfig(USHORT status,INT chan,HANDLE handleval);

/**
*
*  PM41 Channel functions
*
**/

BOOL    PM41_IsChan(INT chan,HANDLE handleval);
BOOL    PM41_ChIsRcv(INT chan,HANDLE handleval);
BOOL    PM41_ChIsXmt(INT chan,HANDLE handleval);
VOID    PM41_ChDataWr(UINT data,INT chan,HANDLE handleval);
UINT    PM41_ChDataRd(INT chan,HANDLE handleval);
USHORT  PM41_ChStatRd(INT chan,HANDLE handleval);
VOID    PM41_ChGapWr(USHORT gap,INT chan,HANDLE handleval);
USHORT  PM41_ChGapRd(INT chan,HANDLE handleval);
BOOL    PM41_IsChGapDone(INT chan,HANDLE handleval);
VOID    PM41_ChClear(INT chan,HANDLE handleval);
VOID    PM41_ChConfig(USHORT speed,USHORT parity,BOOL scramble,BOOL selftest,INT chan,HANDLE handleval);

/**
*
*  PM41 Filter functions
*
**/

VOID    PM41_FilterSDISet(USHORT sdi,INT chan,HANDLE handleval);
VOID    PM41_FilterSDIClear(INT chan,HANDLE handleval);
VOID    PM41_FilterLabelSet(UCHAR label[16],INT chan,HANDLE handleval);
VOID    PM41_FilterLabelClr(INT chan,HANDLE handleval);
PUCHAR  PM41_FilterLabelRead(PUCHAR labels,INT chan,HANDLE handleval);

/**
*
*  PM41 LED functions
*
**/

BOOL    PM41_IsLEDSet(HANDLE handleval);
VOID    PM41_LEDWr(BOOL val,HANDLE handleval);
VOID    PM41_LEDBlink(HANDLE handleval);

/**
*
*  PM41 Timer functions
*
**/

VOID    PM41_TimerConfig(USHORT cfgflags,HANDLE handleval);
VOID    PM41_TimerStart(HANDLE handleval);
VOID    PM41_TimerStop(HANDLE handleval);
VOID    PM41_TimerClr(HANDLE handleval);
UINT    PM41_TimerRd(HANDLE handleval);
VOID    PM41_TimerWr(UINT timeval,HANDLE handleval);
VOID    PM41_TimerSRQEn(HANDLE handleval);
VOID    PM41_TimerSRQDis(HANDLE handleval);

/**
*
*  PM41 DIN functions
*
**/

BOOL    PM41_IsDINSet(USHORT din,HANDLE handleval);
VOID    PM41_DINConfig(INT resol,INT period,HANDLE handleval);
USHORT  PM41_DINSRQRd(HANDLE handleval);
VOID    PM41_DINSRQSet(USHORT srq,HANDLE handleval);

/**
*
*  PM41 DOUT functions
*
**/

VOID    PM41_DOUTWr(USHORT dout,HANDLE handleval);
BOOL    PM41_DOUTIsSet(USHORT dout,HANDLE handleval);
VOID    PM41_DOUTClr(USHORT dout,HANDLE handleval);

/**
*
*  PM41 Interrupt Functions
*
**/

BOOL    PM41_IntInstall(HANDLE hEvent,HANDLE handleval);
VOID    PM41_IntUninstall(HANDLE handleval);
VOID    PM41_IntEnable(INT intsource,HANDLE handleval);
VOID    PM41_IntDisable(HANDLE handleval);

#ifdef __cplusplus
}
#endif


#endif	//_PM4291_H
