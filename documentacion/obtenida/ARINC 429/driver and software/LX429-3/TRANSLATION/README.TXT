
                          Lx429-3 Translation DLL
                           for BTIDriver Hardware

                                March 2, 2011

                Copyright 2009-2011 by Ballard Technology, Inc.

                                Version 1.21


                                ------------


          This folder contains the following subfolders and files:

          Folder Name             Description

          L43W32.DLL        Translation DLL used to provide existing
                            Lx429-3 applications to run with BTIDriver
                            compliant hardware
          L43W32_DEBUG.DLL  Debug version of the translation DLL
          L43W32.INI        Translation DLL initialization file

          README.TXT        This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



    INTRODUCTION

          This translation DLL allows the use of newer BTIDriver
          compliant hardware in application written for the
          Lx429-3. The use of this translation DLL allows most
          existing software written for the Lx429-3 PCI
          interface device to be run unmodified and without re-
          compiling using Ballard's family of BTIDriver compliant
          databus interface products. These include interfaces for
          PCI, cPCI, VME, PMC, USB, and Ethernet.

          See below for installation information and the functions
          supported by this translation DLL.

          The INI initialization file specifies channel mappings and
          other configuration parameters as described below.

          This Lx429-3 Translation DLL is intended for use in 32-bit
          Windows operating systems. Contact Ballard Technology for
          other operating systems.



     INSTALLATION AND USE

          The translation DLL has the same name as the standard
          Lx429-3 Win32 driver (L43W32.DLL). The translation DLL
          is used selectively for specific applications.

          The translation DLL is also named L43W32.DLL and is intended
          to replace the standard DLL for the Lx429-3 hardware. If
          functions in the translation DLL are called, the translatation
          DLL translates the Lx429-3 call into a BTIDriver call. When
          using a multi-core BTIDriver compliant device with this Lx429-3
          translation DLL, the first core with an ARINC 429 channel is
          used; other cores, if they exist, are ignored.

          Before using the translation DLL, the BTIDriver compliant device
          (such as an OmniBusBox) and drivers must first be installed.
          To install the hardware, refer to the Installation section of
          the User's Manual that accompanies the hardware.

          To use the translation DLL for a specific application:

                 1. Locate the directory containing the specified
                    application
                 2. Copy the the L43W32.DLL translation DLL into the
                    application directory
                 3. Copy the L43W32.INI file into the application
                    directory
                 4. Modify the L43W32.INI file for card number, channel
                    numbers as described in the following section

                 NOTE: Do not place the DLL into the system32 directory
                 in order to use it globally. This will potentially conflict
                 with the use of other Ballard software.



     INITIALIZATION FILE (L43W32.INI)

          The L43W32.INI initialization file provides the channel
          mapping and channel configuration. This information can be
          specified for multiple devices, however, the card number of
          each Lx429-3 must match the card number of the BTIDriver
          device.

          The INI file has the following format:

               [cardnumber]
               L43chan=BTIDriverchan
               L43chan=BTIDriverchan

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



     IMPLEMENTED FUNCTIONS

          The following is a complete list of the functions implemented for
          this translation DLL.

          /**
          *
          *  L43 Driver functions.
          *
          **/
          L43W32API ULONG FARCODE L43_BCDGetData(ULONG msg,USHORT msb,USHORT lsb);
          L43W32API ULONG FARCODE L43_BCDGetMant(ULONG msg,USHORT sigdig);
          L43W32API USHORT FARCODE L43_BCDGetSign(ULONG msg);
          L43W32API USHORT FARCODE L43_BCDGetSSM(ULONG msg);
          L43W32API VOID FARCODE L43_BCDGetVal(LPSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
          L43W32API ULONG FARCODE L43_BCDPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
          L43W32API ULONG FARCODE L43_BCDPutMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
          L43W32API ULONG FARCODE L43_BCDPutSign(ULONG msg,USHORT sign);
          L43W32API ULONG FARCODE L43_BCDPutSSM(ULONG msg,USHORT value);
          L43W32API ULONG FARCODE L43_BCDPutVal(LPCSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
          L43W32API ULONG FARCODE L43_BNRGetData(ULONG msg,USHORT msb,USHORT lsb);
          L43W32API ULONG FARCODE L43_BNRGetMant(ULONG msg,USHORT sigbit);
          L43W32API USHORT FARCODE L43_BNRGetSign(ULONG msg);
          L43W32API USHORT FARCODE L43_BNRGetSSM(ULONG msg);
          L43W32API VOID FARCODE L43_BNRGetVal(LPSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
          L43W32API ULONG FARCODE L43_BNRPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
          L43W32API ULONG FARCODE L43_BNRPutMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
          L43W32API ULONG FARCODE L43_BNRPutSign(ULONG msg,USHORT twos);
          L43W32API ULONG FARCODE L43_BNRPutSSM(ULONG msg,USHORT value);
          L43W32API ULONG FARCODE L43_BNRPutVal(LPCSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
          L43W32API ERRVAL FARCODE L43_CardClose(HCARD handleval);
          L43W32API HCARD FARCODE L43_CardOpen(INT cardnum);
          L43W32API VOID FARCODE L43_CardReset(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardResume(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardStart(HCARD handleval);
          L43W32API BOOL FARCODE L43_CardStop(HCARD handleval);
          L43W32API VOID FARCODE L43_CardTrigger(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_ChClear(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_ChConfig(ULONG configval,INT channum,HCARD handleval);
          L43W32API VOID FARCODE L43_ChPause(INT channum,HCARD handleval);
          L43W32API INT FARCODE L43_ChPauseCheck(INT channum,HCARD handleval);
          L43W32API VOID FARCODE L43_ChResume(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_ExtDinRd(HCARD handleval);
          L43W32API VOID FARCODE L43_ExtDinWr(BOOL dinval,HCARD handleval);
          L43W32API BOOL FARCODE L43_ExtDIORd(INT dionum,HCARD handleval);
          L43W32API VOID FARCODE L43_ExtDIOWr(INT dionum,BOOL dioval,HCARD handleval);
          L43W32API BOOL FARCODE L43_ExtLEDRd(HCARD handleval);
          L43W32API VOID FARCODE L43_ExtLEDWr(BOOL ledval,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_FilterClear(BASEADDR baseaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_FilterDefault(ULONG configval,INT channum,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_FilterRd(INT labelval,INT sdival,INT channum,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_FilterSet(ULONG configval,INT labelval,INT sdimask,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_FilterWr(MSGADDR msgaddr,INT labelval,INT sdival,INT channum,HCARD handleval);
          L43W32API ULONG FARCODE L43_FldGetData(ULONG msgval);
          L43W32API USHORT FARCODE L43_FldGetLabel(ULONG msgval);
          L43W32API USHORT FARCODE L43_FldGetParity(ULONG msgval);
          L43W32API USHORT FARCODE L43_FldGetSDI(ULONG msgval);
          L43W32API ULONG FARCODE L43_FldGetValue(ULONG msgval,USHORT startbit,USHORT endbit);
          L43W32API ULONG FARCODE L43_FldPutData(ULONG msgval,ULONG data);
          L43W32API ULONG FARCODE L43_FldPutLabel(ULONG msgval,USHORT label);
          L43W32API ULONG FARCODE L43_FldPutSDI(ULONG msgval,USHORT sdi);
          L43W32API ULONG FARCODE L43_FldPutValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
          L43W32API VOID FARCODE L43_GetChanCount(LPINT rcvcount,LPINT xmtcount,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntConfig(USHORT configval,USHORT count,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntInstall(LPVOID hEvent,HCARD handleval);
          L43W32API ULONG FARCODE L43_IntRd(LPUSHORT typeval,LPULONG infoval,HCARD handleval);
          L43W32API VOID FARCODE L43_IntReset(HCARD handleval);
          L43W32API INT FARCODE L43_IntStatus(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntUninstall(HCARD handleval);
          L43W32API BOOL FARCODE L43_IsChan(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_IsRcvChan(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_IsXmtChan(INT channum,HCARD handleval);
          L43W32API LISTADDR FARCODE L43_ListAsyncCreate(ULONG listconfigval,INT count,INT channum,HCARD handleval);
          L43W32API ULONG FARCODE L43_ListDataRd(LISTADDR listaddr,HCARD handleval);
          L43W32API BOOL FARCODE L43_ListDataWr(ULONG value,LISTADDR listaddr,HCARD handleval);
          L43W32API LISTADDR FARCODE L43_ListRcvCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCARD handleval);
          L43W32API LISTADDR FARCODE L43_ListXmtCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgBlockRd(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgBlockWr(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgCommRd(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgCommWr(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgCreate(ULONG configval,HCARD handleval);
          L43W32API ULONG FARCODE L43_MsgDataRd(MSGADDR msgaddr,HCARD handleval);
          L43W32API VOID FARCODE L43_MsgDataWr(ULONG value,MSGADDR msgaddr,HCARD handleval);
          L43W32API BOOL FARCODE L43_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedBranch(USHORT condition,SCHNDX destindex,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedCall(USHORT condition,SCHNDX destindex,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedEntry(INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedGap(USHORT gapval,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedGapFixed(USHORT gapval,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedGapList(USHORT gapval,LISTADDR listaddr,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedHalt(INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedInt(USHORT condition,USHORT tagval,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedMsg(MSGADDR msgaddr,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedMsgEx(MSGADDR msgaddr,USHORT gapval,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedPause(INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedPulse(INT dionum,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedRestart(INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedReturn(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SeqConfig(ULONG configval,HCARD handleval);
          L43W32API INT FARCODE L43_SeqInterval(INT interval,INT mode,HCARD handleval);
          L43W32API USHORT FARCODE L43_SeqIntFrequency(USHORT intfreq,HCARD handleval);
          L43W32API BOOL FARCODE L43_SeqIsRunning(HCARD handleval);
          L43W32API USHORT FARCODE L43_SeqRd(LPSEQRECORD buf,HCARD handleval);
          L43W32API BOOL FARCODE L43_SeqStatus(HCARD handleval);
          L43W32API VOID FARCODE L43_TimerClear(HCARD handleval);
          L43W32API ULONG FARCODE L43_TimerRd(HCARD handleval);
          L43W32API INT FARCODE L43_TimerResolution(INT timerresol,HCARD handleval);

          /**
          *
          *  L43/717 functions.
          *
          **/
          L43W32API ERRVAL FARCODE L43_Ch717Status(LPUSHORT buf,INT channum,HCARD handleval);
          L43W32API VOID FARCODE L43_Get717ChanCount(LPINT rcvcount,LPINT xmtcount,HCARD handleval);
          L43W32API BOOL FARCODE L43_Is717BiPhaseChan(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_Is717Chan(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_Is717RcvChan(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_Is717XmtChan(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmBlkRd(LPUSHORT databuf,INT subframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmBlkWr(LPUSHORT databuf,INT subframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmStatus(LPUSHORT buf,INT subframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmWordConfig(ULONG configval,INT subframe,INT word,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmWordRd(LPUSHORT value,INT subframe,INT word,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmWordWr(USHORT value,INT subframe,INT word,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmConfig(INT count,INT framespersuperframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmCounterPos(INT subframe,INT word,INT channum,HCARD handleval);
          L43W32API SUPERFRMADDR FARCODE L43_SuperFrmDefine(INT subframe,INT word,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmWordRd(LPUSHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmWordWr(USHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmWordConfig(ULONG configval,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_SyncTest(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SyncValRd(LPINT syncword1,LPINT syncword2,LPINT syncword3,LPINT syncword4,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SyncValWr(INT syncword1,INT syncword2,INT syncword3,INT syncword4,INT channum,HCARD handleval);

          /**
          *
          *  Internal functions used by the L43 Driver.
          *
          **/
          L43W32API ERRVAL FARCODE L43_AsciiToMant(LPCSTR str,LPULONG mant,LPINT exp);
          L43W32API ERRVAL FARCODE L43_CardCloseAll(VOID);
          L43W32API ULONG FARCODE L43_CardGetInfo(USHORT infotype,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
          L43W32API BOOL FARCODE L43_CardIsRunning(HCARD handleval);
          L43W32API VOID FARCODE L43_CardResetEx(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardTest(USHORT level,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardTest0(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardTest1(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardTest2(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_CardTest3(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_Ch717Config(ULONG configval,INT channum,HCARD handleval);
          L43W32API BASEADDR FARCODE L43_Ch717Create(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_Ch717Reset(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_ChConfigEx(ULONG configval,USHORT count,INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_ChStart(INT channum,HCARD handleval);
          L43W32API BOOL FARCODE L43_ChStop(INT channum,HCARD handleval);
          L43W32API ULONG FARCODE L43_ConvFromArinc(ULONG msgval);
          L43W32API ULONG FARCODE L43_ConvToArinc(ULONG msgval);
          L43W32API ULONG FARCODE L43_Div(ULONG diva,ULONG divb);
          L43W32API LPCSTR FARCODE L43_ErrDesc(INT errval);
          L43W32API LPCSTR FARCODE L43_ErrDescStr(INT errval);
          L43W32API LPCSTR FARCODE L43_ErrName(INT errval);
          L43W32API VOID FARCODE L43_ExtDIODirSet(INT dionum,BOOL dirval,HCARD handleval);
          L43W32API ULONG FARCODE L43_FilterAddr(INT labelval,INT sdival,INT channum,HCARD handleval);
          L43W32API BASEADDR FARCODE L43_FilterCreate(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_FilterFill(MSGADDR msgaddr,BASEADDR baseaddr,HCARD handleval);
          L43W32API USHORT FARCODE L43_FldGetParBit(ULONG msgval);
          L43W32API ULONG FARCODE L43_FldPutParBit(ULONG msgval);
          L43W32API USHORT FARCODE L43_GetHigh(ULONG val);
          L43W32API USHORT FARCODE L43_GetLow(ULONG val);
          L43W32API ERRVAL FARCODE L43_IntClear(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntDisable(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntEnable(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_IntEnableCond(HCARD handleval);
          L43W32API LPVOID FARCODE L43_IntGet(HCARD handleval);
          L43W32API ULONG FARCODE L43_LabelReverse(ULONG msgval);
          L43W32API ERRVAL FARCODE L43_ListAdvance(LISTADDR listaddr,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_ListClear(LISTADDR listaddr,HCARD handleval);
          L43W32API LISTADDR FARCODE L43_ListConfig(ULONG configval,INT count,HCARD handleval);
          L43W32API LISTADDR FARCODE L43_ListConfigEx(ULONG configval,INT count,HCARD handleval);
          L43W32API USHORT FARCODE L43_ListDataBlkRd(ULONG data[],USHORT datacount,LISTADDR listaddr,HCARD handleval);
          L43W32API BOOL FARCODE L43_ListDataBlkWr(LPULONG dataptr,USHORT datacount,LISTADDR listaddr,HCARD handleval);
          L43W32API ULONG FARCODE L43_ListDataRdEx(INT index,LISTADDR listaddr,HCARD handleval);
          L43W32API VOID FARCODE L43_ListDataWrEx(ULONG value,INT index,LISTADDR listaddr,HCARD handleval);
          L43W32API INT FARCODE L43_ListStatus(LISTADDR listaddr,HCARD handleval);
          L43W32API ULONG FARCODE L43_MakeLong(USHORT valh,USHORT vall);
          L43W32API LPSTR FARCODE L43_MantToAscii(LPSTR buf,long mant,int exp);
          L43W32API ULONG FARCODE L43_Mask(ULONG dataval,INT cntval);
          L43W32API ULONG FARCODE L43_Mod(ULONG moda,ULONG modb);
          L43W32API USHORT FARCODE L43_MsgActivityRd(MSGADDR msgaddr,HCARD handleval);
          L43W32API VOID FARCODE L43_MsgActivityWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
          L43W32API USHORT FARCODE L43_MsgCheck(MSGADDR msgaddr,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_MsgConfig(ULONG configval,MSGADDR msgaddr,HCARD handleval);
          L43W32API MSGADDR FARCODE L43_MsgReset(MSGADDR msgaddr,HCARD handleval);
          L43W32API ULONG FARCODE L43_Mul(ULONG mula,ULONG mulb);
          L43W32API VOID FARCODE L43_NormalMant(LPULONG mant,LPINT exp);
          L43W32API SCHNDX FARCODE L43_SchedAgain(SCHNDX index,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,BOOL speed,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SchedBuildExx(INT basemsgnum,INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,INT speed,LPVOID buf,ULONG bufsize,INT channum,HCARD handleval);
          L43W32API SCHNDX FARCODE L43_SchedNop(INT channum,HCARD handleval);
          L43W32API ULONG FARCODE L43_SeqBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
          L43W32API ULONG FARCODE L43_SeqBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SeqClear(HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SeqConfigEx(ULONG configval,ULONG seqcount,USHORT cardnum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SeqConfigExx(ULONG configval,ULONG seqaddr,ULONG seqcount,USHORT cardnum,HCARD handleval);
          L43W32API USHORT FARCODE L43_SeqRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
          L43W32API BOOL FARCODE L43_SeqResume(HCARD handleval);
          L43W32API BOOL FARCODE L43_SeqStart(HCARD handleval);
          L43W32API BOOL FARCODE L43_SeqStop(HCARD handleval);
          L43W32API ULONG FARCODE L43_Shl(ULONG dataval,INT cntval);
          L43W32API ULONG FARCODE L43_Shr(ULONG dataval,INT cntval);
          L43W32API USHORT FARCODE L43_SignMant(LPCSTR str);
          L43W32API SUBFRMADDR FARCODE L43_SubFrmAddr(INT subframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmCreate(ULONG configval,INT subframe,BASEADDR chanbase,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SubFrmReset(INT subframe,INT channum,HCARD handleval);
          L43W32API BASEADDR FARCODE L43_SuperFrmBaseAddr(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmConfigEx(ULONG configval,INT count,INT framespersuperframe,INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SuperFrmReset(INT channum,HCARD handleval);
          L43W32API ERRVAL FARCODE L43_SyncValPtrInit(INT channum,HCARD handleval);
          L43W32API USHORT FARCODE L43_TimerResolutionEx(USHORT timershift,HCARD handleval);
          L43W32API USHORT FARCODE L43_Transpose12(USHORT val);
          L43W32API INT FARCODE L43_ValAsciiCmpi(LPSTR str1,LPSTR str2);
          L43W32API LPSTR FARCODE L43_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
          L43W32API VOID FARCODE L43_ValAsciiTrimLead(LPSTR buf);
          L43W32API VOID FARCODE L43_ValAsciiTrimTrail(LPSTR buf);
          L43W32API ULONG FARCODE L43_ValFromAscii(LPCSTR asciistr,INT radixval);
          L43W32API ULONG FARCODE L43_ValGetBits(ULONG oldvalue,INT startbit,INT endbit);
          L43W32API LPSTR FARCODE L43_ValIncAscii(LPSTR asciistr);
          L43W32API LPSTR FARCODE L43_ValInccAscii(LPSTR asciistr);
          L43W32API BOOL FARCODE L43_ValIsLower(INT value);
          L43W32API INT FARCODE L43_ValLenAscii(INT numbits,INT radixval);
          L43W32API ULONG FARCODE L43_ValPutBits(ULONG oldvalue,ULONG newfld,INT startbit,INT endbit);
          L43W32API LPSTR FARCODE L43_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
          L43W32API INT FARCODE L43_ValToUpper(INT value);



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
