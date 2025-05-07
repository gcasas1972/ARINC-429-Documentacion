
                          CM1553-3 Translation DLL
                           for BTIDriver Hardware

                                March 2, 2011

                Copyright 2009-2010 by Ballard Technology, Inc.

                                Version 1.21


                                ------------


          This folder contains the following subfolders and files:

          Folder Name             Description

          C13W32.DLL        Translation DLL used to provide existing
                            CM1553-3 applications to run with BTIDriver
                            compliant hardware
          C13W32_DEBUG.DLL  Debug version of the translation dll

          README.TXT        This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



    INTRODUCTION

          This translation DLL allows the use of newer BTIDriver
          compliant hardware in application written for the
          CM1553-3. The use of this translation DLL allows most
          existing software written for the CM1553-3 PCMCIA
          interface device to be run unmodified and without re-
          compiling using Ballard's family of BTIDriver compliant
          databus interface products. These include interfaces for
          PCI, cPCI, VME, PMC, USB, and Ethernet.

          See below for installation information and the functions
          supported by this translation DLL.

          This CM1553-3 Translation DLL is intended for use in 32-bit
          Windows operating systems. Contact Ballard Technology for
          other operating systems.



     INSTALLATION AND USE

          The translation DLL has the same name as the standard
          CM1553-3 Win32 driver (C13W32.DLL). The translation DLL
          is used selectively for specific applications.

          The translation DLL is also named C13W32.DLL and is intended
          to replace the standard DLL for the CM1553-3 hardware. If
          functions in the translation DLL are called, the translatation
          DLL translates the CM1553-3 call into a BTIDriver call. When
          using a multi-core BTIDriver compliant device with this CM1553-3
          translation DLL, the first core with a MIL-STD-1553 channel is
          used; other cores, if they exist, are ignored. Channel 0 will
          always be used for the BTIDriver calls.

          Before using the translation DLL, the BTIDriver compliant device
          (such as an OmniBusBox) and drivers must first be installed.
          To install the hardware, refer to the Installation section of
          the User's Manual that accompanies the hardware.

          To use the translation DLL for a specific application:

                 1. Locate the directory containing the specified
                    application
                 2. Copy the the C13W32.DLL translation DLL into the
                    application directory

                 NOTE: Do not place the DLL into the system32 directory
                 in order to use it globally. This will potentially conflict
                 with the use of other Ballard software.



     IMPLEMENTED FUNCTIONS

          The following is a complete list of the functions implemented for
          this translation DLL.

          /**
          *
          *  C13 Driver functions.
          *
          **/
          C13DRVAPI ERRVAL FARCODE C13_BCConfig(ULONG configval,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_BCCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedFrame(ULONG timeval,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BCTransmitMsg(LPXMITFIELDS xmitfields,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BCTransmitMsgEx(LPXMITFIELDS xmitfields,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardClose(HCARD handleval);
          C13DRVAPI HCARD FARCODE C13_CardOpen(INT cardnum);
          C13DRVAPI VOID FARCODE C13_CardReset(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardStart(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_CardStop(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorCtrl(ULONG ctrlval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorDefine(ULONG defineval,USHORT errvalue,INT countval,USHORT wordpos,USHORT bitpos,HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ErrorSent(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorTagBC(BOOL tagval,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorTagRT(BOOL tagval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI INT FARCODE C13_ListDataRd(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI INT FARCODE C13_ListDataWr(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonConfig(ULONG configval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonFilterSA(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonFilterTA(ULONG tamask,HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_MonIsRunning(HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MonRd(LPUSHORT buf,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_PlayConfig(ULONG configval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_PlayWr(LPUSHORT buf,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_RTConfig(ULONG configval,INT taval,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_RTCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_RTCreateMsg(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_RTGetMsg(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
          C13DRVAPI VOID FARCODE C13_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);

          /**
          *
          *  Internal functions used by the C13 Driver.
          *
          **/
          C13DRVAPI ERRVAL FARCODE C13_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_BCCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_BCCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_BCGetMsg(INT index,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedAgain(SCHNDX index,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedCall(SCHNDX destindex,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedEntry(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedFrameEnd(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedFrameStart(ULONG timeval,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedGap(USHORT gapval,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedGoto(SCHNDX destindex,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedHalt(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedInt(USHORT tagval,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedNop(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedPause(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedRestart(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSchedReturn(HCARD handleval);
          C13DRVAPI SCHNDX FARCODE C13_BCSetEntry(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BCSetTimeout(USHORT timeoutval,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_BlkAddr(INT taval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_BlkOptRd(INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkOptWr(USHORT rtopt,INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkRd(LPUSHORT block,INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkReset(INT taval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_BlkSWDRd(INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkWipe(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_BlkWr(LPUSHORT block,INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardBoot(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardCloseAll(VOID);
          C13DRVAPI ULONG FARCODE C13_CardGetInfo(USHORT infotype,HCARD handleval);
          C13DRVAPI LPCSTR FARCODE C13_CardGetInfos(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardGetParam(LPSTR cardstr,LPINT cardnum,LPINT devnum,LPULONG sizval,LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,LPUSHORT spdval,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_CardInit(VOID);
          C13DRVAPI BOOL FARCODE C13_CardIsRunning(HCARD handleval);
          C13DRVAPI VOID FARCODE C13_CardResetEx(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardResume(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardTest(USHORT level,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardTest0(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardTest1(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardTest2(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_CardTest3(HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_Div(ULONG diva,ULONG divb);
          C13DRVAPI LPCSTR FARCODE C13_ErrDesc(INT errval);
          C13DRVAPI LPCSTR FARCODE C13_ErrDescStr(INT errval);
          C13DRVAPI LPCSTR FARCODE C13_ErrName(INT errval);
          C13DRVAPI BOOL FARCODE C13_ErrorIsTaggedBC(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ErrorIsTaggedRT(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorResponse(USHORT responseval,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_ErrorSync(BOOL value,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ErrorTimeout(USHORT timeoutval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_GetHigh(ULONG val);
          C13DRVAPI USHORT FARCODE C13_GetLow(ULONG val);
          C13DRVAPI ERRVAL FARCODE C13_IntClear(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntConfig(USHORT configval,USHORT count,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntDisable(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntEnable(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntEnableCond(HCARD handleval);
          C13DRVAPI LPVOID FARCODE C13_IntGet(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntInstall(LPVOID hEvent,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_IntReset(HCARD handleval);
          C13DRVAPI INT FARCODE C13_IntStatus(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_IntUninstall(HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_ListAddr(INT index,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_ListBlockRd(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_ListBlockRdEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_ListBlockWr(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_ListBlockWrEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ListClear(LISTADDR listaddr,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_ListConfig(ULONG configval,INT count,USHORT skipval,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_ListConfigEx(ULONG configval,INT count,USHORT skipval,HCARD handleval);
          C13DRVAPI INT FARCODE C13_ListDataRdEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI INT FARCODE C13_ListDataWrEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
          C13DRVAPI INT FARCODE C13_ListStatus(LISTADDR listaddr,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_MakeLong(USHORT valh,USHORT vall);
          C13DRVAPI ULONG FARCODE C13_Mask(ULONG dataval,USHORT cntval);
          C13DRVAPI ULONG FARCODE C13_Mod(ULONG moda,ULONG modb);
          C13DRVAPI BOOL FARCODE C13_ModeIsBC(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsMon(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsNotBC(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsNotMon(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsNotPlay(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsNotRT(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsNotSerial(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsPlay(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsRT(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_ModeIsSerial(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonClear(HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_MonFilterSAEx(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_MonResume(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_MonStart(HCARD handleval);
          C13DRVAPI INT FARCODE C13_MonStatus(HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_MonStop(HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgCheck(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgConfig(ULONG configval,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgFlagRd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI VOID FARCODE C13_MsgFlagWr(USHORT msgflag,MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI BOOL FARCODE C13_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI MSGADDR FARCODE C13_MsgReset(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_Mul(ULONG mula,ULONG mulb);
          C13DRVAPI ERRVAL FARCODE C13_RTConfigEx(ULONG configval,INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_RTCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI LISTADDR FARCODE C13_RTCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_RTReset(INT taval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_RTStatus(INT taval,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_RTSWDRd(INT taval,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
          C13DRVAPI ERRVAL FARCODE C13_SchedBuildExx(ULONG frametime,INT nummsgs,LPMSGADDR msgaddr,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_Shl(ULONG dataval,USHORT cntval);
          C13DRVAPI ULONG FARCODE C13_Shr(ULONG dataval,USHORT cntval);
          C13DRVAPI VOID FARCODE C13_TimerClear(HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_TimerRd(HCARD handleval);
          C13DRVAPI INT FARCODE C13_TimerResolution(INT timerresol,HCARD handleval);
          C13DRVAPI USHORT FARCODE C13_TimerResolutionEx(USHORT timershift,HCARD handleval);
          C13DRVAPI ULONG FARCODE C13_ValFromAscii(LPCSTR asciistr,INT radixval);
          C13DRVAPI USHORT FARCODE C13_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
          C13DRVAPI USHORT FARCODE C13_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
          C13DRVAPI USHORT FARCODE C13_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
          C13DRVAPI LPSTR FARCODE C13_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
          C13DRVAPI VOID FARCODE C13_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);



     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION

          There is no additional information.


                                ------------


          SAFETY WARNING:  Ballard products are of commercial
          grade and therefore are neither designed,
          manufactured, nor tested to standards required for
          use in critical applications where a failure or
          deficiency of the product may lead to injury,
          death, or damage to property.  Without prior
          specific approval in writing by the president of
          Ballard Technology, Inc., Ballard products are not
          authorized for use in such critical applications.

          This software is provided as a laboratory tool.
          For any application it is the responsibility of the
          user to verify the suitability, correctness, and
          safety of using this software or data derived
          therefrom.


                                ------------


     Ballard Technology would appreciate hearing your questions,
     comments, and suggestions concerning this product.

     Ballard Technology, Inc.
     (800) 829-1553
     www.ballardtech.com
     support@ballardtech.com
