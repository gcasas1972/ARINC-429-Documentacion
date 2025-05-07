
                          CM429-1 Translation DLL
                           for BTIDriver Hardware

                                March 2, 2011

                Copyright 2009-2010 by Ballard Technology, Inc.

                                Version 1.21


                                ------------


          This folder contains the following subfolders and files:

          Folder Name             Description

          C41W32.DLL        Translation DLL used to provide existing
                            CM429-1 applications to run with BTIDriver
                            compliant hardware
          C41W32_DEBUG.DLL  Debug version of the translation DLL
          C41W32.INI        Translation DLL initialization file

          README.TXT        This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



    INTRODUCTION

          This translation DLL allows the use of newer BTIDriver
          compliant hardware in application written for the
          CM429-1. The use of this translation DLL allows most
          existing software written for the CM429-1 PCMCIA
          interface device to be run unmodified and without re-
          compiling using Ballard's family of BTIDriver compliant
          databus interface products. These include interfaces for
          PCI, cPCI, VME, PMC, USB, and Ethernet.

          See below for installation information and the functions
          supported by this translation DLL.

          The INI initialization file specifies channel mappings and
          other configuration parameters as described below.

          This CM429-1 Translation DLL is intended for use in 32-bit
          Windows operating systems. Contact Ballard Technology for
          other operating systems.



     INSTALLATION AND USE

          The translation DLL has the same name as the standard
          CM429-1 Win32 driver (C41W32.DLL). The translation DLL
          is used selectively for specific applications.

          The translation DLL is also named C41W32.DLL and is intended
          to replace the standard DLL for the CM429-1 hardware. If
          functions in the translation DLL are called, the translatation
          DLL translates the CM429-1 call into a BTIDriver call. When
          using a multi-core BTIDriver compliant device with this CM429-1
          translation DLL, the first core with an ARINC 429 channel is
          used; other cores, if they exist, are ignored.

          Before using the translation DLL, the BTIDriver compliant device
          (such as an OmniBusBox) and drivers must first be installed.
          To install the hardware, refer to the Installation
          section of the User's Manual that accompanies the
          hardware.

          To use the translation DLL for a specific application:

                 1. Locate the directory containing the specified
                    application
                 2. Copy the the C41W32.DLL translation DLL into the
                    application directory
                 3. Copy the C41W32.INI file into the application
                    directory
                 4. Modify the C41W32.INI file for card number, channel
                    numbers (and additional ARINC 717 channel settings)
                    as described in the following section

                 NOTE: Do not place the DLL into the system32 directory
                 in order to use it globally. This will potentially conflict
                 with the use of other Ballard software.



     INITIALIZATION FILE (C41W32.INI)

          The C41W32.INI initialization file provides the channel
          mapping and channel configuration. This information can be
          specified for multiple devices, however, the card number of
          each CM429-1 must match the card number of the BTIDriver
          device.

          The INI file has the following format:

               [cardnumber]
               C41chan=BTIDriverchan
               C41chan=BTIDriverchan

          In addition to the BTIDriver channel number, ARINC 717
          channels also have a type specifier of 'BipolarRx',
          'BipolarTx', 'BiphaseRx', or 'BiphaseRx'.

          For example, the following example maps channels CH0 to CH0,
          CH1 to CH1, CH2 to CH8, and CH3 to CH9 for Card 0. Then for
          Card 1, another set of mappings are done.

               [0]
               0=0
               1=1
               2=8
               3=9

               [1]
               0=0
               1=1
               2=8
               3=9
               4=4BipolarRx
               5=12BipolarTx
               6=5BiphaseRx
               7=13BiphaseTx



     FUNCTION DIFFERENCES

          See the next section for a complete list of the functions
          implemented for this translation DLL. However, the following
          functions have special warnings and additional information.

          C41_ChConfig
               Does not support CHCFG_SDI00, CHCFG_SDI01, CHCFG_SDI10, CHCFG_SDI11,
               CHCFG_INTSCH, CHCFG_INTLIST, CHCFG_INTPARITY, CHCFG_EXTSTART.

               CHCFG_SERVICE cannot be used with CHCFG_TIMETAG, BTIDriver cards
               cannot record both simultaneously.

          C41_IntDin
               Not supported.

          C41_IntRd
               Returns 16 bit value (truncated from 32 bit).

          C41_ListRd
               Does not return list entry addr, just a positive value, 0 for failure
               or empty.

          C41_ListWr
               Does not return list entry addr, just a positive value, 0 for failure.

          C41_MemPeek
               Not supported (returns 0).

          C41_MemPoke
               Not supported (just returns).

          C41_PortWr
               Only supports REG_INTC addrval for clearing interupts on BTIDriver
               devices.

          C41_ProcCall
               Not supported.

          C41_ProcLoad
               Not supported.

          C41_ProcSetCh
               Not supported.

          C41_ProcSetMsg
               Not supported.

          C41_SchedBranch
               COND_NONE not supported.

          C41_SeqConfig
               C41SEQCFG_ALL flag has no corresponding flag in for BTIDriver cards.
               Calling with this flag will walk the channels and set the
               CHCFG429_SEQALL flag for all of them, but if the user does a ChanCfg
               after this the setting will be lost.

               C41SEQCFG_WRAP flag is translated to SEQCFG_CONTINUOUS. The behavior
               may be slightly different due to the variable length records in 4th
               gen and beyond.

               The default recording mode (C41SEQCFG_WRAPOFF) translates to
               SEQCFG_FILLHALT. With BTIDriver hardware, recording will stop and
               cannot be resumed when the sequential record is full. This is
               different from C41 behavior which will resume again recording as
               soon as space becomes available.

          C41_717Boot
               Unnecessary, just returns.

          C41_SeqInterval
               Minimum supported interval time is 1 second.
               Returns actual interval time that gets used instead of ERRVAL
               Supported interval times will be different than C41.



     IMPLEMENTED FUNCTIONS

          The following is a complete list of the functions implemented for
          this translation DLL.

          /**
          *
          *  CM429-1 Driver functions.
          *
          **/
          C41W32API ULONG FARCODE C41_AsciiFrom(LPCSTR asciistr,INT radixval);
          C41W32API VOID FARCODE C41_AsciiTo(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
          C41W32API ULONG FARCODE C41_BCDGetData(ULONG msg,USHORT msb,USHORT lsb);
          C41W32API ULONG FARCODE C41_BCDGetMant(ULONG msg,USHORT sigdig);
          C41W32API USHORT FARCODE C41_BCDGetSign(ULONG msg);
          C41W32API USHORT FARCODE C41_BCDGetSSM(ULONG msg);
          C41W32API VOID FARCODE C41_BCDGetVal(LPSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
          C41W32API ULONG FARCODE C41_BCDPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
          C41W32API ULONG FARCODE C41_BCDPutMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
          C41W32API ULONG FARCODE C41_BCDPutSign(ULONG msg,USHORT sign);
          C41W32API ULONG FARCODE C41_BCDPutSSM(ULONG msg,USHORT value);
          C41W32API ULONG FARCODE C41_BCDPutVal(LPCSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
          C41W32API ULONG FARCODE C41_BNRGetData(ULONG msg,USHORT msb,USHORT lsb);
          C41W32API ULONG FARCODE C41_BNRGetMant(ULONG msg,USHORT sigbit);
          C41W32API USHORT FARCODE C41_BNRGetSign(ULONG msg);
          C41W32API USHORT FARCODE C41_BNRGetSSM(ULONG msg);
          C41W32API VOID FARCODE C41_BNRGetVal(LPSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
          C41W32API ULONG FARCODE C41_BNRPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
          C41W32API ULONG FARCODE C41_BNRPutMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
          C41W32API ULONG FARCODE C41_BNRPutSign(ULONG msg,USHORT twos);
          C41W32API ULONG FARCODE C41_BNRPutSSM(ULONG msg,USHORT value);
          C41W32API ULONG FARCODE C41_BNRPutVal(LPCSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
          C41W32API INT FARCODE C41_ChCheck(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_ChClear(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_ChConfig(ULONG configval,INT channum,HCARD handleval);
          C41W32API VOID FARCODE C41_ChPause(INT channum,HCARD handleval);
          C41W32API VOID FARCODE C41_ChResume(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_CloseAll(VOID);
          C41W32API ERRVAL FARCODE C41_CloseCard(HCARD handleval);
          C41W32API INT FARCODE C41_ExtRd(HCARD handleval);
          C41W32API VOID FARCODE C41_ExtWr(INT extflag,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_FilterDefault(INT msgnum,INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_FilterSet(INT labelval,INT sdimask,INT msgnum,INT channum,HCARD handleval);
          C41W32API ULONG FARCODE C41_FldGetData(ULONG msgval);
          C41W32API USHORT FARCODE C41_FldGetLabel(ULONG msgval);
          C41W32API USHORT FARCODE C41_FldGetParity(ULONG msgval);
          C41W32API USHORT FARCODE C41_FldGetSDI(ULONG msgval);
          C41W32API ULONG FARCODE C41_FldGetValue(ULONG msgval,USHORT startbit,USHORT endbit);
          C41W32API ULONG FARCODE C41_FldPutData(ULONG msgval,ULONG data);
          C41W32API ULONG FARCODE C41_FldPutLabel(ULONG msgval,USHORT label);
          C41W32API ULONG FARCODE C41_FldPutSDI(ULONG msgval,USHORT sdi);
          C41W32API ULONG FARCODE C41_FldPutValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
          C41W32API USHORT FARCODE C41_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
          C41W32API USHORT FARCODE C41_ListMakeRcv(USHORT count,INT msgnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_ListMakeXmt(USHORT count,INT channum,HCARD handleval);
          C41W32API USHORT FARCODE C41_ListRd(LPULONG msgval,USHORT listaddr,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_ListStatus(USHORT listaddr,HCARD handleval);
          C41W32API USHORT FARCODE C41_ListWr(ULONG msgval,USHORT listaddr,HCARD handleval);
          C41W32API USHORT FARCODE C41_MemPeek(USHORT addrval,HCARD handleval);
          C41W32API VOID FARCODE C41_MemPoke(USHORT value,USHORT addrval,HCARD handleval);
          C41W32API ULONG FARCODE C41_MsgArincRd(INT msgnum,HCARD handleval);
          C41W32API VOID FARCODE C41_MsgArincWr(ULONG msgval,INT msgnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_MsgBlockRd(LPUSHORT valueptr,INT msgnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_MsgBlockWr(LPUSHORT valueptr,INT msgnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_MsgCommRd(LPUSHORT valueptr,INT msgnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_MsgCommWr(LPUSHORT valueptr,INT msgnum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_MsgConfig(USHORT configval,INT msgnum,HCARD handleval);
          C41W32API ULONG FARCODE C41_MsgEncoderRd(INT msgnum,HCARD handleval);
          C41W32API VOID FARCODE C41_MsgEncoderWr(ULONG msgval,INT msgnum,HCARD handleval);
          C41W32API HCARD FARCODE C41_OpenCard(INT cardnum);
          C41W32API ERRVAL FARCODE C41_ProcCall(USHORT useraddr,HCARD handleval);
          C41W32API USHORT FARCODE C41_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_ProcSetCh(USHORT useraddr,INT type,INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_ProcSetMsg(USHORT useraddr,INT msgnum,HCARD handleval);
          C41W32API VOID FARCODE C41_Reset(HCARD handleval);
          C41W32API VOID FARCODE C41_Restart(HCARD handleval);
          C41W32API INT FARCODE C41_SchedBranch(INT schindex,INT condition,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedBuild(INT basemsgnum,USHORT nummsgs,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedCall(INT schindex,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedGap(USHORT gapval,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedHalt(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedInt(USHORT tagval,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedMsg(INT msgnum,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedPause(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedPulse(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedRestart(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedRet(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedStart(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SelfTest(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SeqClear(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SeqConfig(USHORT configval,INT interval,INT cardnum,HCARD handleval);
          C41W32API USHORT FARCODE C41_SeqRd(LPULONG msgval,LPULONG stampval,HCARD handleval);
          C41W32API USHORT FARCODE C41_Start(HCARD handleval);
          C41W32API USHORT FARCODE C41_Stop(HCARD handleval);
          C41W32API VOID FARCODE C41_TimerClear(HCARD handleval);
          C41W32API ULONG FARCODE C41_TimerRd(HCARD handleval);
          C41W32API USHORT FARCODE C41_TimerResolution(INT timerresol,HCARD handleval);

          /**
          *
          *  CM429-1 717 Driver functions.
          *
          **/
          C41W32API ERRVAL FARCODE C41_717Boot(INT handleval);
          C41W32API ERRVAL FARCODE C41_717FrameWipe(INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SubFrmClear(INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SubFrmDataWipe(INT subframe,INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SubFrmRecordWipe(INT subframe,INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SubFrmWordConfig(LONG configval,INT subframe,INT wordnum,INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SubFrmWordConfigEx(LONG configval,INT subframe,INT channum,INT handleval);
          C41W32API INT FARCODE C41_717SubFrmWordRd(INT subframe,INT wordnum,INT channum,INT handleval);
          C41W32API BOOL FARCODE C41_717SyncTest(INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SyncWordDefault(INT channum,INT handleval);
          C41W32API ERRVAL FARCODE C41_717SyncWordSet(INT sync1,INT sync2,INT sync3,INT sync4,INT channum,INT handleval);
          C41W32API VOID FARCODE C41_Ch717Disable(INT handleval);
          C41W32API VOID FARCODE C41_Ch717Enable(INT handleval);

          /**
          *
          *  Internal functions used by the CM429-1 Driver.
          *
          **/
          C41W32API ERRVAL FARCODE C41_CardClose(HCARD handleval);
          C41W32API HCARD FARCODE C41_CardOpen(INT cardnum);
          C41W32API INT FARCODE C41_ChPauseCheck(INT channum,HCARD handleval);
          C41W32API USHORT FARCODE C41_ChStart(INT channum,HCARD handleval);
          C41W32API USHORT FARCODE C41_ChStop(INT channum,HCARD handleval);
          C41W32API ULONG FARCODE C41_ConvFromArinc(ULONG msgval);
          C41W32API ULONG FARCODE C41_ConvToArinc(ULONG msgval);
          C41W32API ULONG FARCODE C41_Div(ULONG diva,ULONG divb);
          C41W32API LPCSTR FARCODE C41_ErrDesc(INT errval);
          C41W32API LPCSTR FARCODE C41_ErrDescStr(INT errval);
          C41W32API LPCSTR FARCODE C41_ErrName(INT errval);
          C41W32API INT FARCODE C41_ExtDinWr(INT dinvalue,INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_FilterClear(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_FilterFill(LPUSHORT msgaddr,INT channum,HCARD handleval);
          C41W32API USHORT FARCODE C41_FldGetParBit(ULONG msgval);
          C41W32API USHORT FARCODE C41_GetHigh(ULONG val);
          C41W32API USHORT FARCODE C41_GetLow(ULONG val);
          C41W32API ERRVAL FARCODE C41_IntClear(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_INTDisable(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_INTEnable(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_INTEnableCond(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_IntInstall(LPVOID hEvent,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_IntUninstall(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_IntWipe(HCARD handleval);
          C41W32API ULONG FARCODE C41_MakeLong(USHORT valh,USHORT vall);
          C41W32API ULONG FARCODE C41_Mask(ULONG dataval,USHORT cntval);
          C41W32API ULONG FARCODE C41_Mod(ULONG moda,ULONG modb);
          C41W32API ERRVAL FARCODE C41_MsgDisable(INT msgnum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_MsgEnable(INT msgnum,HCARD handleval);
          C41W32API ULONG FARCODE C41_Mul(ULONG mula,ULONG mulb);
          C41W32API VOID FARCODE C41_PortWr(USHORT value,USHORT addrval,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SchedClear(INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedFixedGap(USHORT gapval,INT channum,HCARD handleval);
          C41W32API INT FARCODE C41_SchedNop(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SchedWipe(INT channum,HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SeqInterval(INT interval,HCARD handleval);
          C41W32API BOOL FARCODE C41_SeqIsRunning(HCARD handleval);
          C41W32API ULONG FARCODE C41_SeqRdEx(LPUSHORT buf,ULONG bufcount,HCARD handleval);
          C41W32API USHORT FARCODE C41_SeqStart(HCARD handleval);
          C41W32API USHORT FARCODE C41_SeqStop(HCARD handleval);
          C41W32API ERRVAL FARCODE C41_SeqWipe(HCARD handleval);
          C41W32API ULONG FARCODE C41_Shl(ULONG dataval,USHORT cntval);
          C41W32API ULONG FARCODE C41_Shr(ULONG dataval,USHORT cntval);
          C41W32API INT FARCODE C41_ValAsciiCmpi(LPSTR str1,LPSTR str2);
          C41W32API LPSTR FARCODE C41_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
          C41W32API VOID FARCODE C41_ValAsciiTrimLead(LPSTR buf);
          C41W32API VOID FARCODE C41_ValAsciiTrimTrail(LPSTR buf);
          C41W32API ULONG FARCODE C41_ValFromAscii(LPCSTR asciistr,INT radixval);
          C41W32API LPSTR FARCODE C41_ValIncAscii(LPSTR asciistr);
          C41W32API LPSTR FARCODE C41_ValInccAscii(LPSTR asciistr);
          C41W32API BOOL FARCODE C41_ValIsLower(INT value);
          C41W32API INT FARCODE C41_ValLenAscii(INT numbits,INT radixval);
          C41W32API LPSTR FARCODE C41_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
          C41W32API INT FARCODE C41_ValToUpper(INT value);


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
