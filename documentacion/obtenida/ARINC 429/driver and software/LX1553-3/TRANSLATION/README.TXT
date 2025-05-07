
                          Lx1553-3 Translation DLL
                           for BTIDriver Hardware

                                March 2, 2011

                Copyright 2009-2010 by Ballard Technology, Inc.

                                Version 1.21


                                ------------


          This folder contains the following subfolders and files:

          Folder Name             Description

          L13W32.DLL        Translation DLL used to provide existing
                            Lx1553-3 applications to run with BTIDriver
                            compliant hardware
          L13W32_DEBUG.DLL  Debug version of the translation DLL

          README.TXT        This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



    INTRODUCTION

          This translation DLL allows the use of newer BTIDriver
          compliant hardware in application written for the
          Lx1553-3. The use of this translation DLL allows most
          existing software written for the Lx1553-3 PCI
          interface device to be run unmodified and without re-
          compiling using Ballard's family of BTIDriver compliant
          databus interface products. These include interfaces for
          PCI, cPCI, VME, PMC, USB, and Ethernet.

          See below for installation information and the functions
          supported by this translation DLL.

          This Lx1553-3 Translation DLL is intended for use in 32-bit
          Windows operating systems. Contact Ballard Technology for
          other operating systems.



     INSTALLATION AND USE

          The translation DLL has the same name as the standard
          Lx1553-3 Win32 driver (L13W32.DLL).  The translation DLL
          is used selectively for specific applications.

          The translation DLL is also named L13W32.DLL and is intended
          to replace the standard DLL for the Lx1553-3 hardware. If
          functions in the translation DLL are called, the translatation
          DLL translates the Lx1553-3 call into a BTIDriver call. When
          using a multi-core BTIDriver compliant device with this Lx1553-3
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
                 2. Copy the the L13W32.DLL translation DLL into the
                    application directory

                 NOTE: Do not place the DLL into the system32 directory
                 in order to use it globally. This will potentially conflict
                 with the use of other Ballard software.



     IMPLEMENTED FUNCTIONS

          The following is a complete list of the functions implemented for
          this translation DLL.

          /**
          *
          *  L13 Driver functions.
          *
          **/
          L13W32API ERRVAL FARCODE L13_BCConfig(ULONG configval,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_BCCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedFrame(ULONG timeval,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BCTransmitMsg(LPXMITFIELDS xmitfields,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BCTransmitMsgEx(LPXMITFIELDS xmitfields,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardClose(HCARD handleval);
          L13W32API HCARD FARCODE L13_CardOpen(INT cardnum);
          L13W32API VOID FARCODE L13_CardReset(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardStart(HCARD handleval);
          L13W32API BOOL FARCODE L13_CardStop(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorCtrl(ULONG ctrlval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorDefine(ULONG defineval,USHORT errvalue,INT countval,USHORT wordpos,USHORT bitpos,HCARD handleval);
          L13W32API BOOL FARCODE L13_ErrorSent(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorTagBC(BOOL tagval,MSGADDR msgaddr,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorTagRT(BOOL tagval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntConfig(USHORT configval,USHORT count,HCARD handleval);
          L13W32API INT FARCODE L13_ListDataRd(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
          L13W32API INT FARCODE L13_ListDataWr(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonConfig(ULONG configval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonFilterSA(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonFilterTA(ULONG tamask,HCARD handleval);
          L13W32API BOOL FARCODE L13_MonIsRunning(HCARD handleval);
          L13W32API USHORT FARCODE L13_MonRd(LPUSHORT buf,HCARD handleval);
          L13W32API VOID FARCODE L13_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
          L13W32API VOID FARCODE L13_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
          L13W32API ULONG FARCODE L13_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
          L13W32API ULONG FARCODE L13_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_PlayConfig(ULONG configval,HCARD handleval);
          L13W32API USHORT FARCODE L13_PlayWr(LPUSHORT buf,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_RTConfig(ULONG configval,INT taval,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_RTCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_RTCreateMsg(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_RTGetMsg(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
          L13W32API USHORT FARCODE L13_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
          L13W32API VOID FARCODE L13_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);

          /**
          *
          *  Internal functions used by the L13 Driver.
          *
          **/
          L13W32API ERRVAL FARCODE L13_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_BCCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_BCCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_BCGetMsg(INT index,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedAgain(SCHNDX index,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedCall(SCHNDX destindex,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedEntry(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedFrameEnd(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedFrameStart(ULONG timeval,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedGap(USHORT gapval,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedGoto(SCHNDX destindex,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedHalt(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedInt(USHORT tagval,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedNop(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedPause(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedRestart(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSchedReturn(HCARD handleval);
          L13W32API SCHNDX FARCODE L13_BCSetEntry(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BCSetTimeout(USHORT timeoutval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BlkReset(INT taval,HCARD handleval);
          L13W32API USHORT FARCODE L13_BlkSWDRd(INT taval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardBoot(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardCloseAll(VOID);
          L13W32API ULONG FARCODE L13_CardGetInfo(USHORT infotype,HCARD handleval);
          L13W32API BOOL FARCODE L13_CardIsRunning(HCARD handleval);
          L13W32API VOID FARCODE L13_CardResetEx(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardResume(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardTest(USHORT level,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardTest0(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardTest1(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardTest2(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_CardTest3(HCARD handleval);
          L13W32API VOID FARCODE L13_CardTrigger(HCARD handleval);
          L13W32API ULONG FARCODE L13_Div(ULONG diva,ULONG divb);
          L13W32API LPCSTR FARCODE L13_ErrDesc(INT errval);
          L13W32API LPCSTR FARCODE L13_ErrDescStr(INT errval);
          L13W32API LPCSTR FARCODE L13_ErrName(INT errval);
          L13W32API BOOL FARCODE L13_ErrorIsTaggedBC(MSGADDR msgaddr,HCARD handleval);
          L13W32API BOOL FARCODE L13_ErrorIsTaggedRT(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorResponse(USHORT responseval,HCARD handleval);
          L13W32API VOID FARCODE L13_ErrorSync(BOOL value,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ErrorTimeout(USHORT timeoutval,HCARD handleval);
          L13W32API USHORT FARCODE L13_GetHigh(ULONG val);
          L13W32API USHORT FARCODE L13_GetLow(ULONG val);
          L13W32API ERRVAL FARCODE L13_HandleClose(HCARD handleval);
          L13W32API BOOL FARCODE L13_HandleOkay(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntClear(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntDisable(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntEnable(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntEnableCond(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntInstall(LPVOID hEvent,HCARD handleval);
          L13W32API ULONG FARCODE L13_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
          L13W32API VOID FARCODE L13_IntReset(HCARD handleval);
          L13W32API INT FARCODE L13_IntStatus(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_IntUninstall(HCARD handleval);
          L13W32API MSGADDR FARCODE L13_ListBlockRd(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_ListBlockRdEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_ListBlockWr(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_ListBlockWrEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_ListClear(LISTADDR listaddr,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_ListConfig(ULONG configval,INT count,USHORT skipval,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_ListConfigEx(ULONG configval,INT count,USHORT skipval,HCARD handleval);
          L13W32API INT FARCODE L13_ListDataRdEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
          L13W32API INT FARCODE L13_ListDataWrEx(LPUSHORT buf,INT count,INT index  LISTADDR listaddr,HCARD handleval);
          L13W32API INT FARCODE L13_ListStatus(LISTADDR listaddr,HCARD handleval);
          L13W32API ULONG FARCODE L13_MakeLong(USHORT valh,USHORT vall);
          L13W32API ULONG FARCODE L13_Mask(ULONG dataval,USHORT cntval);
          L13W32API ULONG FARCODE L13_Mod(ULONG moda,ULONG modb);
          L13W32API ULONG FARCODE L13_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
          L13W32API ULONG FARCODE L13_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonClear(HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_MonFilterSAEx(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
          L13W32API USHORT FARCODE L13_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
          L13W32API BOOL FARCODE L13_MonResume(HCARD handleval);
          L13W32API BOOL FARCODE L13_MonStart(HCARD handleval);
          L13W32API BOOL FARCODE L13_MonStatus(HCARD handleval);
          L13W32API BOOL FARCODE L13_MonStop(HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgCheck(MSGADDR msgaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgConfig(ULONG configval,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
          L13W32API VOID FARCODE L13_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
          L13W32API VOID FARCODE L13_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
          L13W32API VOID FARCODE L13_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
          L13W32API BOOL FARCODE L13_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
          L13W32API MSGADDR FARCODE L13_MsgReset(MSGADDR msgaddr,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
          L13W32API USHORT FARCODE L13_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
          L13W32API ULONG FARCODE L13_Mul(ULONG mula,ULONG mulb);
          L13W32API ERRVAL FARCODE L13_RTConfigEx(ULONG configval,INT taval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_RTCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API LISTADDR FARCODE L13_RTCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_RTReset(INT taval,HCARD handleval);
          L13W32API USHORT FARCODE L13_RTSWDRd(INT taval,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
          L13W32API ERRVAL FARCODE L13_SchedBuildExx(ULONG frametime,INT nummsgs,LPMSGADDR msgaddr,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
          L13W32API ULONG FARCODE L13_Shl(ULONG dataval,USHORT cntval);
          L13W32API ULONG FARCODE L13_Shr(ULONG dataval,USHORT cntval);
          L13W32API VOID FARCODE L13_TimerClear(HCARD handleval);
          L13W32API ULONG FARCODE L13_TimerRd(HCARD handleval);
          L13W32API INT FARCODE L13_TimerResolution(INT timerresol,HCARD handleval);
          L13W32API USHORT FARCODE L13_TimerResolutionEx(USHORT timershift,HCARD handleval);
          L13W32API INT FARCODE L13_ValAsciiCmpi(LPSTR str1,LPSTR str2);
          L13W32API LPSTR FARCODE L13_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
          L13W32API VOID FARCODE L13_ValAsciiTrimLead(LPSTR buf);
          L13W32API VOID FARCODE L13_ValAsciiTrimTrail(LPSTR buf);
          L13W32API ULONG FARCODE L13_ValFromAscii(LPCSTR asciistr,INT radixval);
          L13W32API USHORT FARCODE L13_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
          L13W32API LPSTR FARCODE L13_ValIncAscii(LPSTR asciistr);
          L13W32API LPSTR FARCODE L13_ValInccAscii(LPSTR asciistr);
          L13W32API BOOL FARCODE L13_ValIsLower(INT value);
          L13W32API INT FARCODE L13_ValLenAscii(INT numbits,INT radixval);
          L13W32API USHORT FARCODE L13_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
          L13W32API USHORT FARCODE L13_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
          L13W32API LPSTR FARCODE L13_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
          L13W32API INT FARCODE L13_ValToUpper(INT value);
          L13W32API VOID FARCODE L13_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);



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
