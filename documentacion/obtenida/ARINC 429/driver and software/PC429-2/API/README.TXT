

                        USING THE PC429-1/2 DRIVER API

                               March 31, 1999

                Copyright 1997-1999 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW

          P42W32.LIB    PC429-1/2 WIN32 import library
          P42W32.H      Include file
          P42W32VB.BAS  Visual Basic header file
          P42W32NET.VB  VB.NET header file
          P42W32BC.LIB  PC429-1/2 WIN32 import library for Borland tools
          OVERVIEW.TXT  Description of API functions

          DEMO1.C       Demo #1
          DEMO1.EXE
          DEMO2.C       Demo #2
          DEMO2.EXE
          DEMO2.429
          DEMO3.C       Demo #3
          DEMO3.EXE
          DEMO4.C       Demo #4
          DEMO4.EXE
          DEMO5.C       Demo #5
          DEMO5.EXE
          DEMO6.C       Demo #6
          DEMO6.EXE

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The P42W32.H and P42W32.LIB files are the C/C++
          language header and import library for the
          PC429-1/2 Driver API.  With these files, the user
          can write applications that operate the PC429-1/2
          ISA ARINC 429 card.  The Driver API has been tested
          using the Microsoft Visual C++ Compiler Version 6.0
          and the Borland C++ Compiler Version 4.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          4.5.



     P42W32.H

          WIN32 applications written in the C or C++ language
          that use the PC429-1/2 Driver API library must
          incorporate the header file P42W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "P42W32.H"



     P42W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the PC429-1/2 Driver API by adding
          P42W32VB.BAS into the Visual Basic project.  Once
          added to the project, Driver API functions can be
          called along with other user-defined functions.



     P42W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library P42W32.LIB.  Instead, Borland users should
          use P42W32BC.LIB.



     EXAMPLE PROGRAMS DEMO1.C, DEMO2.C, DEMO3.C

          Three example programs have been provided.  To run
          these programs, a PC429-1/2 board must be installed
          in the computer at the factory settings of segment
          address CE00H and port address 250H.

          The program DEMO1 simulates a propulsion
          multiplexer.  Fuel flow and exhaust gas temperature
          messages are transmitted and received through the
          internal wrap-around.

          The program DEMO2 transmits and receives a fuel
          flow message every 150ms.  The card is configured
          using the image contained in the DOS Copilot file
          DEMO2.429.

          The program DEMO3 transmits and receives a fuel
          flow message every 150ms with every other message
          containing a parity error.

          The C source code is written for Microsoft Visual C++
          Version 5.0.



     FUNCTION OVERVIEW

          Each function in the PC429-1/2 Driver API are
          listed in 12 categories.  Functions marked with an
          asterisk (*) are the high level functions and are
          described in detail in the PC429-1/2 User's Manual.
          Functions that are unmarked are described in detail
          in the text file OVERVIEW.TXT.


           1)  INITIALIZATION SUBROUTINES

               These subroutines initialize the PC429-1/2
               driver library and check for the presence of
               the specified PC429-1/2 cards.  These
               subroutines must be called at the start of the
               user's program.

              *PC429_Check         Checks for presence of card.
              *PC429_CheckChan     Reports the configuration of card.
               PC429_Init          Initializes the PC429 driver library.


           2)  CONFIGURATION SUBROUTINES

               These subroutines configure the PC429-1/2
               hardware.  Any changes to the PC429-1/2
               configuration will not be put into effect
               until PC429_Start() is called.

               PC429_Active        Enables active channels.
               PC429_BrdNum        Sets the board number.
               PC429_Error         Enables transmit errors.
               PC429_Extern        Enables sync/external trigger.
               PC429_HighSpeed     Sets channels to high speed.
               PC429_IsRcv         Checks if channel is a receiver.
               PC429_IsXmit        Checks if channel is a transmitter.
               PC429_Parity        Selects parity of each channel.
               PC429_SelfTest      Enables selftest on the card.
               PC429_Single        Sets single mode for transmit channel.


           3)  BOARD OPERATION SUBROUTINES

               These are general purpose subroutines that are
               used to operate the PC429-1/2 card.

               PC429_Halt          Halts the on-board CPU.
               PC429_Pulse         Pulses pin 25.
               PC429_Rearm         Rearms card if in single internal mode.
               PC429_Reset         Resets the card.
              *PC429_Start         Starts the operation of the card.
              *PC429_Stop          Stops the operation of the card.
               PC429_WipeMem       Clears the card RAM.


           4)  ON-BOARD CLOCK SUBROUTINES

               These subroutines access the on-board clock of
               the PC429-1/2 card.

               PC429_ElapseClk     Selects whether elapsed time recorded.
               PC429_OscClk        Tells the firmware the CPU clock speed.
               PC429_RdClk         Reads the on-board clock.
               PC429_SpeedClk      Selects 10ms, 1ms, or .1ms clock res.
               PC429_WrClk         Sets the on-board clock.


           5)  IMAGE SUBROUTINES

               These subroutines allow the user to
               dynamically create messages and filters on the
               PC429-1/2 card without the use of the DOS Copilot
               program.

               PC429_ClrMsgFilt    Clears board of all messages and filters.
               PC429_GetFilt       Gets address of a specified filter.
               PC429_GetGap        Gets address of a specified gap.
               PC429_GetMsg        Gets address of a specified message.
               PC429_GetMsgCnt     Gets count of messages.
               PC429_InsFilt       Adds filter to receive channel.
               PC429_InsMsg        Adds message and gap to transmit channel.


           6)  MESSAGE AND FILTER ACCESS SUBROUTINES

               These subroutines access any messages and
               filters on the PC429-1/2 card.

              *PC429_PeekMsg       Read message using communication process.
              *PC429_PokeMsg       Write message using communication process.
               PC429_RdGap         Read gap value for message.
              *PC429_RdMsg         Read message value for message.
              *PC429_RdTime        Read timestamp for receive message.
               PC429_WrGap         Write gap value for message.
              *PC429_WrMsg         Write message value for message.


           7)  USER CODE HOOK

               This subroutine allows custom user code to be
               loaded and executed by the PC429-1/2 on-board
               CPU.

               PC429_UserCode      Install user code.


           8)  FILE I/O SUBROUTINES

               These subroutines access files created by
               DOS Copilot.

              *PC429_Load          Loads an image from a DOS Copilot file.
              *PC429_NameToAddr    Retrieves address of message or filter.


           9)  STRING FORMATTING SUBROUTINES

               The following are general-purpose subroutines
               for ASCII string conversion.  These
               subroutines do not access the PC429-1/2
               hardware.

               PC429_FromAscii     Converts ASCII string to 32-bit value.
               PC429_ToAscii       Converts 32-bit value to ASCII string.


          10)  ARINC WORD FORMAT SUBROUTINES

               The following subroutines operate on the
               various fields of an ARINC 429 message word.
               These subroutines do not access the PC429-1/2
               hardware.

              *PC429_GetFldData    Gets value of data field of ARINC word.
               PC429_GetFldLabel   Gets value of label field of ARINC word.
               PC429_GetFldParity  Gets value of parity bit of ARINC word.
               PC429_GetFldSDI     Gets value of SDI field of ARINC word.
               PC429_GetFldValue   Gets value of specified field of ARINC word.
              *PC429_PutFldData    Puts data field value in ARINC word.
               PC429_PutFldLabel   Puts label field value in ARINC word.
               PC429_PutFldSDI     Puts SDI field value in ARINC word.
               PC429_PutFldValue   Puts value of specified field of ARINC word.


          11)  BCD CONVERSION SUBROUTINES

               The following subroutines operate on the data
               field of an ARINC 429 BCD message word.  These
               subroutines do not access the PC429-1/2
               hardware.

               PC429_GetBCDData    Gets data value of BCD word.
               PC429_GetBCDMant    Gets mantissa value of BCD word.
               PC429_GetBCDSSM     Gets value of SSM field of BCD word.
               PC429_GetBCDSign    Gets sign of BCD word.
               PC429_GetBCDVal     Gets value of BCD word.
               PC429_PutBCDData    Puts data value of BCD word.
               PC429_PutBCDMant    Puts mantissa value of BCD word.
               PC429_PutBCDSSM     Puts value of SSM field in BCD word.
               PC429_PutBCDSign    Puts sign of BCD word.
               PC429_PutBCDVal     Puts value of BCD word.


          12)  BNR CONVERSION SUBROUTINES

               The following subroutines operate on the data
               field of an ARINC 429 BNR message word.  These
               subroutines do not access the PC429-1/2
               hardware.

               PC429_GetBNRData    Gets data value of BNR word.
               PC429_GetBNRMant    Gets mantissa value of BNR word.
               PC429_GetBNRSSM     Gets value of SSM field of BNR word.
               PC429_GetBNRSign    Gets sign of BNR word.
               PC429_GetBNRVal     Gets value of BNR word.
               PC429_PutBNRData    Puts data value of BNR word.
               PC429_PutBNRMant    Puts mantissa value of BNR word.
               PC429_PutBNRSSM     Puts value of SSM field in BNR word.
               PC429_PutBNRSign    Puts sign of BNR word.
               PC429_PutBNRVal     Puts value of BNR word.



     FUNCTION SUMMARY

          Functions marked with an asterisk (*) are the high
          level functions of the Driver and are described in
          detail in the PC429-1/2 User's Manual.  Functions that
          are unmarked are described in detail in the on-line
          text file OVERVIEW.TXT.


      1) PC429_Active -- Selects which channels are active.

          oldchannels = PC429_Active(channels,hDevice);
          USHORT channels;       Which channels are active or inactive.
          HANDLE hDevice;        Device handle of PC429-1/2 card.
          USHORT oldchannels;    Returns previous channels that were active.

          Returns previous channels that were active.


      2) PC429_BrdNum -- Sets the board number.

          oldbrdnum = PC429_BrdNum(brdnum,hDevice);
          USHORT brdnum;       Board number to assign to card.
          HANDLE hDevice;      Device handle of PC429-1/2 card.
          USHORT oldbrdnum;    Returns previous board number assigned to card.

          Returns previous board number assigned to card.


     *3) PC429_Check -- Tests for presence of PC429-1/2 hardware.

          result = PC429_Check(devname,phDevice);
          HANDLE devname;      Path and name of device.
          PHANDLE phDevice;    Pointer to a device handle to update.
          SHORT result;        Non-zero if unable to create handle for device.

          Returns a non-zero value if card is not present.


     *4) PC429_CheckChan -- Returns the configuration of the PC429-1/2 card.

          result = PC429_CheckChan(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          USHORT result;     Returns channel configuration.

          Returns available channels in upper byte, direction
          in lower byte.


      5) PC429_ClrMsgFilt -- Clears board of all messages and filters.

          result = PC429_ClrMsgFilt(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          USHORT result;     Returns a non-zero value if an error occurred.

          Returns a non-zero value if an error occurred.


      6) PC429_ElapseClk -- Selects whether elapsed time is recorded.

          oldchannels = PC429_ElapseClk(channels,hDevice);
          USHORT channels;       Non-zero to enable elapse clock mode.
          HANDLE hDevice;        Device handle of PC429-1/2 card.
          USHORT oldchannels;    Returns previous value of elapse clock mode.

          Returns previous value of elapse clock mode.


      7) PC429_Error -- Enables transmitter errors.

          oldchannels = PC429_Error(channels,hDevice);
          USHORT channels;       Non-zero to enable errors in transmitter.
          HANDLE hDevice;        Device handle of PC429-1/2 card.
          USHORT oldchannels;    Returns previous value of error.

          Returns previous value of error.


      8) PC429_Extern -- Enables sync/external trigger for each channel.

          oldchannels = PC429_Extern(channels,hDevice);
          USHORT channels;       Which channel have external enabled.
          HANDLE hDevice;        Device handle of PC429-1/2 card.
          USHORT oldchannels;    Returns previous value of external.

          Returns previous value of external.


      9) PC429_FromAscii -- Converts ASCII string to 32-bit unsigned.

          result = PC429_FromAscii(asciistr,radix);
          PCHAR asciistr;    Pointer to null-terminated string to convert.
          USHORT radix;      Radix of string.
          ULONG result;      Returns result of conversion.

          Returns result of conversion.


     10) PC429_GetBCDData -- Extracts data value from BCD message word.

          result = PC429_GetBCDData(msg,msb,lsb);
          ULONG msg;       BCD message word to extract data from.
          USHORT msb;      Most significant bit number of BCD field.
          USHORT lsb;      Least significant bit number of BCD field.
          ULONG result;    Returns the data field value.

          Returns the data field value.


     11) PC429_GetBCDMant -- Extracts mantissa from a BCD message word.

          result = PC429_GetBCDMant(msg,sigdig);
          ULONG msg;        BCD message word to extract data from.
          USHORT sigdig;    Number of significant digits in BCD field.
          ULONG result;     Returns the data field mantissa.

          Returns the data field mantissa.


     12) PC429_GetBCDSign -- Extracts the sign from a BCD message word.

          sign = PC429_GetBCDSign(msg);
          ULONG msg;      BCD message word to extract data from.
          USHORT sign;    Non-zero if the sign of the BCD message word is negative.

          Non-zero if the sign of the BCD message word is negative.


     13) PC429_GetBCDSSM -- Extracts SSM field from BCD message word.

          result = PC429_GetBCDSSM(msg);
          ULONG msg;        BCD message word to extract data from.
          USHORT result;    Returns the SSM field of the BCD message word.

          Returns the SSM field of the BCD message word.


     14) PC429_GetBCDVal -- Calculates the value of a BCD message word.

          VOID PC429_GetBCDVal(resultstr,msg,sigdig,resolstr);
          PCHAR resultstr;    Pointer to resulting null-terminated ASCII string.
          ULONG msg;          BCD message word to extract data from.
          USHORT sigdig;      Number of significant digits in BCD field.
          PCHAR resolstr;     Pointer to null-terminated resolution string.


     15) PC429_GetBNRData -- Extracts data value from BNR message word.

          result = PC429_GetBNRData(msg,msb,lsb,twos);
          ULONG msg;       BNR message word to extract data from.
          USHORT msb;      Most significant bit number of BNR field.
          USHORT lsb;      Least significant bit number of BNR field.
          USHORT twos;     Non-zero if two's complement conversion is needed.
          ULONG result;    Returns the data field value.

          Returns the data field value.


     16) PC429_GetBNRMant -- Extracts mantissa from a BNR message word.

          result = PC429_GetBNRMant(msg,sigbit);
          ULONG msg;        BNR message word to extract data from.
          USHORT sigbit;    Number of significant digits in BNR field.
          ULONG result;     Returns the data field mantissa.

          Returns the data field mantissa.


     17) PC429_GetBNRSign -- Extracts the sign from a BNR message word.

          sign = PC429_GetBNRSign(msg);
          ULONG msg;      BNR message word to extract data from.
          USHORT sign;    Non-zero if the sign of the BNR message word is negative.

          Returns non-zero value if sign of BNR message word negative.


     18) PC429_GetBNRSSM -- Extracts SSM field from BNR message word.

          result = PC429_GetBNRSSM(msg);
          ULONG msg;        BNR message word to extract data from.
          USHORT result;    Returns the SSM field in the message word.

          Returns the SSM field in the message word.


     19) PC429_GetBNRVal -- Calculates the value of a BNR message word.

          VOID PC429_GetBNRVal(resultstr,msg,sigbit,resolstr);
          PCHAR resultstr;    Pointer to resulting null-terminated ASCII string.
          ULONG msg;          BNR message word to extract data from.
          USHORT sigdig;      Number of significant digits in BNR field.
          PCHAR resolstr;     Pointer to null-terminated resolution string.


     20) PC429_GetFilt -- Gets address of the specified filter.

          address = PC429_GetFilt(label,sdi,channel,hDevice);
          USHORT label;      Lable value of filter to get address of.
          USHORT sdi;        SDI value of filter to get address of.
          USHORT channel;    Which channel to get address from.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          ULONG address;     Returns address of filter, zero if error.

          Returns address of filter, zero if error.


    *21) PC429_GetFldData -- Extracts data field from ARINC 429 word.

          data = PC429_GetFldData(msg);
          ULONG msg;     32-bit ARINC 429 message word.
          ULONG data;    Returns the 23-bit data field value.

          Returns the 23-bit data field value.


     22) PC429_GetFldLabel -- Extracts label field from ARINC 429 word.

          label = PC429_GetFldLabel(msg);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT label;    Returns the 8-bit label field value.

          Returns the 8-bit label field value.


     23) PC429_GetFldParity -- Extracts parity bit from ARINC 429 word.

          parity = PC429_GetFldParity(msg);
          ULONG msg;        32-bit ARINC 429 message word.
          USHORT parity;    Returns the parity bit value.

          Returns the parity bit value.


     24) PC429_GetFldSDI -- Extracts SDI field from ARINC 429 word.

          sdi = PC429_GetFldSDI(msg);
          ULONG msg;     32-bit ARINC 429 message word.
          USHORT sdi;    Returns the 2-bit SDI field value.

          Returns the 2-bit SDI field value.


     25) PC429_GetFldValue -- Extracts specified field from ARINC 429 word.

          value = PC429_GetFldValue(msg,startbit,endbit);
          ULONG msg;          32-bit ARINC 429 message word.
          USHORT startbit;    Starting bit number of BCD field.
          USHORT endbit;      Ending bit number of BCD field.

          Returns the value of the specified field.


     26) PC429_GetGap -- Gets the address of a specified gap.

          address = PC429_GetGap(index,channel,hDevice);
          USHORT index;      Index of gap.
          USHORT channel;    Which channel to get address from.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          ULONG address;     Returns address of gap, zero if error.

          Returns address of gap, zero if error.


     27) PC429_GetMsg -- Gets the address of a specified message.

          address = PC429_GetMsg(index,channel,hDevice);
          USHORT index;      Index of message.
          USHORT channel;    Which channel to get address from.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          ULONG address;     Returns address of message, zero if error.

          Returns address of message, zero if error.


     28) PC429_GetMsgCnt -- Gets count of messages in transmit channel.

          count = PC429_GetMsgCnt(channel,hDevice);
          USHORT channel;    Which channel to count.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          USHORT count;      Returns count of messages in a transmit channel.

          Returns count of messages in transmit channel.


     29) PC429_Halt -- Halts the on-board CPU.

          VOID PC429_Halt(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.


     30) PC429_HighSpeed -- Selects which channels operate at high speed.

          oldchannels = PC429_HighSpeed(channels,hDevice);
          USHORT channels;       Which channels to set at high speed.
          HANDLE hDevice;        Device handle of PC429-1/2 card.
          USHORT oldchannels;    Returns old value of high speed.

          Returns old value of high speed.


     31) PC429_Init -- Initializes the PC429-1/2 Driver library.

          result = PC429_Init(VOID);
          SHORT result;    Returns a non-zero value if an error occurred.

          Returns a non-zero value if an error occurred.


     32) PC429_InsFilt -- Adds a filter to the receive channel.

          address = PC429_InsFilt(label,sdi,channel,hDevice);
          USHORT label;      Lable value of filter.
          USHORT sdi;        SDI value of filter.
          USHORT channel;    Which channel to insert filter into.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          ULONG address;     Returns address of filter, zero if error.

          Returns address of filter, zero if error.


     33) PC429_InsMsg -- Adds a message and gap to the transmit channel.

          address = PC429_InsMsg(index,msg,gap,channel,hDevice);
          USHORT index;      Index of message to insert.
          ULONG msg;         32-bit message value.
          ULONG gap;         32-bit gap value.
          USHORT channel;    Which channel to insert message into.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          ULONG address;     Returns address of message, zero if error.

          Returns address of message, zero if error.


     34) PC429_IsRcv -- Checks if channel is a receive channel.

          result = PC429_IsRcv(channel,hDevice);
          USHORT channel;    Which channel to check.
          HANDLE hDevice;    Device handle of PC429-1/2 card to load.
          USHORT result;     Returns a non-zero value if channel is a receiver.

          Returns a non-zero value if channel is a receive channel.


     35) PC429_IsXmit -- Checks if channel is a transmit channel.

          result = PC429_IsXmit(channel,hDevice);
          USHORT channel;    Which channel to check.
          HANDLE hDevice;    Device handle of PC429-1/2 card to load.
          USHORT result;     Returns a non-zero value if channel is a transmitter.

          Returns a non-zero value if channel is a transmit channel.


    *36) PC429_Load -- Loads the image from a file into the PC429-1/2 card.

          result = PC429_Load(imagefh,hDevice);
          HANDLE imagefh;    File handle of an opened file.
          HANDLE hDevice;    Device handle of PC429-1/2 card to load.
          SHORT result;      Returns a non-zero value if an error occurred.

          Returns a non-zero value if an error occurred.


    *37) PC429_NameToAddr -- Retrieves an address from the image file.

          address = PC429_NameToAddr(name,hDevice,imagefh);
          PCHAR name;      Pointer to null-terminated name of message or filter.
          HANDLE hDevice;  Device handle of PC429-1/2 card.
          HANDLE imagefh;  File handle of an opened file.
          ULONG address;   Returns address of message or filter, zero if error.

          Returns address of message or filter, zero if error.


     38) PC429_OscClk -- Informs the firmware of the CPU clock speed.

          oldvalue = PC429_OscClk(oscval,hDevice);
          USHORT oscval;    Oscillator clock value.
          HANDLE hDevice;   Device handle of PC429-1/2 card.
          USHORT oldvalue;  Returns old oscillator clock value.

          Returns old oscillator clock value.


     39) PC429_Parity -- Selects the parity of each channel.

          oldchannels = PC429_Parity(channels,hDevice);
          USHORT channels;     Parity of each channel.
          HANDLE hDevice;      Device handle of PC429-1/2 card.
          USHORT oldchannels;  Returns old value of parity.

          Returns old value of parity.


    *40) PC429_PeekMsg -- Reads a message using communication process.

          msg = PC429_PeekMsg(address);
          ULONG address;   Address of message to read.
          ULONG msg;       Returns 32-bit value of message.

          Returns 32-bit value of message.


    *41) PC429_PokeMsg -- Writes a message using communication process.

          VOID PC429_PokeMsg(address,msg);
          ULONG address;   Address of message to write.
          ULONG msg;       Returns 32-bit value of message.


     42) PC429_Pulse -- Pulses pin 25.

          VOID PC429_Pulse(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.


     43) PC429_PutBCDData -- Inserts data value into BCD message word.

          newmsg = PC429_PutBCDData(msg,value,msb,lsb);
          ULONG msg;       32-bit ARINC 429 message word.
          ULONG value;     New data value.
          USHORT msb;      Most significant bit number of BCD field.
          USHORT lsb;      Least significant bit number of BCD field.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


     44) PC429_PutBCDMant -- Inserts mantissa value into BCD word.

          newmsg = PC429_PutBCDMant(msg,value,sigdig,sign);
          ULONG msg;       32-bit ARINC 429 message word.
          ULONG value;     New data value.
          USHORT sigdig;   Number of significant digits in BCD field.
          USHORT sign;     Non-zero if to take two's complement.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


     45) PC429_PutBCDSign -- Inserts the sign into a BCD message word.

          newmsg = PC429_PutBCDSign(msg,sign);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT sign;     Non-zero if to take two's complement.
          ULONG newmsg;    Returns message word with new sign.

          Returns message word with new sign field.


     46) PC429_PutBCDSSM -- Inserts SSM field into BCD message word.

          newmsg = PC429_PutBCDSSM(msg,value);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT value;    2-bit value of SSM field.
          ULONG newmsg;    Returns message word with new SSM field.

          Returns message word with new SSM field.


     47) PC429_PutBCDVal -- Inserts the value into a BCD message word.

          newmsg = PC429_PutBCDVal(valuestr,msg,sigdig,resolstr);
          PCHAR valuestr;  Pointer to null-terminated value string.
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT sigdig;   Number of significant digits in BCD field.
          PCHAR resolstr;  Pointer to null-terminated resolution string.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


     48) PC429_PutBNRData -- Inserts data value into BNR message word.

          newmsg = PC429_PutBNRData(msg,value,msb,lsb,twos);
          ULONG msg;     32-bit ARINC 429 message word.
          ULONG value;   New data value.
          USHORT msb;    Most significant bit number of BNR field.
          USHORT lsb;    Least significant bit number of BNR field.
          USHORT twos;   Non-zero if two's complement conversion is needed.
          ULONG newmsg;  Returns message word with new data field.

          Returns message word with new data field.


     49) PC429_PutBNRMant -- Inserts mantissa value into BNR message word.

          newmsg = PC429_PutBNRMant(msg,value,sigbit,twos);
          ULONG msg;       32-bit ARINC 429 message word.
          ULONG value;     New data value.
          USHORT sigbit;   Number of significant bits in BNR field.
          USHORT twos;     Non-zero if two's complement conversion is needed.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


     50) PC429_PutBNRSign -- Inserts the sign into a BNR message word.

          newmsg = PC429_PutBNRSign(msg,sign);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT sign;     Non-zero if to put negative sign.
          ULONG newmsg;    Returns message word with new sign.

          Returns message word with new sign.


     51) PC429_PutBNRSSM -- Inserts the SSM field into a BNR message word.

          newmsg = PC429_PutBNRSSM(msg,value);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT value;    3-bit value of SSM field.
          ULONG newmsg;    Returns message word with new SSM field.

          Returns message word with new SSM field.


     52) PC429_PutBNRVal -- Inserts the value into a BNR message word.

          newmsg = PC429_PutBNRVal(valuestr,msg,sigbit,resolstr);
          PCHAR valuestr;  Pointer to null-terminated value string.
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT sigbit;   Number of significant bits in BNR field.
          PCHAR resolstr;  Pointer to null-terminated resolution string.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


    *53) PC429_PutFldData -- Inserts the data field into a message word.

          newmsg = PC429_PutFldData(msg,data);
          ULONG msg;       32-bit ARINC 429 message word.
          ULONG data;      New 23-bit data field value.
          ULONG newmsg;    Returns message word with new data field.

          Returns message word with new data field.


     54) PC429_PutFldLabel -- Inserts the label field into a message word.

          newmsg = PC429_PutFldLabel(msg,label);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT label;    New 8-bit label field value.
          ULONG newmsg;    Returns message word with new label field.

          Returns message word with new label field.


     55) PC429_PutFldSDI -- Inserts the SDI field into a message word.

          newmsg = PC429_PutFldSDI(msg,sdi);
          ULONG msg;       32-bit ARINC 429 message word.
          USHORT sdi;      New 2-bit sdi field value.
          ULONG newmsg;    Returns message word with new sdi field.

          Returns message word with new sdi field.


     56) PC429_PutFldValue -- Inserts the specified field into a message word.

          newmsg = PC429_PutFldValue(msg,data,startbit,endbit);
          ULONG msg;         32-bit ARINC 429 message word.
          ULONG data;        New 23-bit data field value.
          USHORT startbit;   Starting bit position of field.
          USHORT endbit;     Ending bit position of field.
          ULONG newmsg;      Returns message with new data field.

          Returns message word with new field.


     57) PC429_RdClk -- Reads the on-board clock.

          clkval = PC429_RdClk(hDevice);
          HANDLE hDevice;  Device handle of PC429-1/2 card.
          ULONG clkval;    Returns current clock value.

          Returns current clock value.


     58) PC429_RdGap -- Reads the gap value for a transmitted message.

          gapval = PC429_RdGap(address);
          ULONG address;   Address of gap to read.
          ULONG gapval;    Returns 32-bit value of gap

          Returns 32-bit value of gap


    *59) PC429_RdMsg -- Reads transmitted or received messages.

          msg = PC429_RdMsg(address);
          ULONG address;   Address of message to read.
          ULONG msg;       Returns 32-bit value of message.

          Returns 32-bit value of message.


    *60) PC429_RdTime -- Reads the timestamp of received messages.

          timeval = PC429_RdTime(address);
          ULONG address;   Address of receive message.
          ULONG timeval;   Returns 32-bit value of timestamp.

          Returns 32-bit value of timestamp and status bits.


     61) PC429_Rearm -- Rearms PC429 card if in single internal mode.

          VOID PC429_Rearm(channel,hDevice);
          USHORT channel;    Which channel to rearm.
          HANDLE hDevice;    Device handle of PC429-1/2 card.



     62) PC429_Reset -- Resets the PC429 hardware.

          VOID PC429_Reset(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.


     63) PC429_SelfTest -- Enables selftest on the PC429-1/2 card.

          oldchannels = PC429_SelfTest(channels,hDevice);
          USHORT channels;     Non-zero to enable self-test mode.
          HANDLE hDevice;      Device handle of PC429-1/2 card.
          USHORT oldchannels;  Returns old value of self-test mode.

          Returns old value of self-test mode.


     64) PC429_Single -- Selects single mode for the transmitter channel.

          oldchannels = PC429_Single(channels,hDevice);
          USHORT channels;      Non-zero to enable single mode.
          HANDLE hDevice;       Device handle of PC429-1/2 card.
          USHORT oldchannels;   Returns old value of single mode.

          Returns old value of single mode.


     65) PC429_SpeedClk -- Selects 10ms, 1ms, or .1ms clock resolution.

          oldspeed = PC429_SpeedClk(speed,hDevice);
          USHORT speed;       Speed of clock.
          HANDLE hDevice;     Device handle of PC429-1/2 card.
          USHORT oldspeed;    Returns old speed of clock.

          Returns old speed of clock.


    *66) PC429_Start -- Starts operation of the PC429-1/2 card.

          VOID PC429_Start(hDevice);
          HANDLE hDevice;     Device handle of PC429-1/2 card.


    *67) PC429_Stop -- Stops operation of the PC429-1/2 card.

          VOID PC429_Stop(hDevice);
          HANDLE hDevice;     Device handle of PC429-1/2 card.


     68) PC429_ToAscii -- Converts 32-bit unsigned value to ASCII string.

          VOID PC429_ToAscii(value,asciistr,numbits,radix);
          ULONG value;       32-bit bit value to convert.
          PCHAR asciistr;    Pointer to null-terminated resulting string.
          USHORT numbits;    Number of bits in value.
          USHORT radix;      Radix of string.


     69) PC429_UserCode -- Installs user code into PC429-1/2 hardware.

          result = PC429_UserCode(usercode,count,hDevice);
          PUCHAR usercode;   Pointer to buffer.
          USHORT count;      Number of bytes in buffer.
          HANDLE hDevice;    Device handle of PC429-1/2 card.
          USHORT result;     Returns a non-zero value if an error occurred.

          Returns a non-zero value if an error occurred.


     70) PC429_WipeMem -- Clears the RAM of the PC429-1/2 hardware.

          VOID PC429_WipeMem(hDevice);
          HANDLE hDevice;    Device handle of PC429-1/2 card.


     71) PC429_WrClk -- Sets the on-board clock.

          VOID PC429_WrClk(clock,hDevice);
          ULONG clock;       New clock value.
          HANDLE hDevice;    Device handle of PC429-1/2 card.


     72) PC429_WrGap -- Writes a message gap value to PC429-1/2 memory.

          VOID PC429_WrGap(address,gap);
          ULONG address;   Address of gap to write.
          ULONG gap;       32-bit value of gap.


    *73) PC429_WrMsg -- Writes transmit message value to PC429-1/2 memory.

          VOID PC429_WrMsg(address,msg);
          ULONG address;   Address of message to write.
          ULONG msg;       32-bit value of message.


                                ------------


     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION


          1)   Some of the procedures that were in the DOS
               and 16-bit Windows Driver are NOT implemented
               in this verion of the PC429-1/2 WIN32 Driver.
               The procedures are PC429_SeqRecOn(),
               PC429_SeqRecOff(), and PC429_SeqRecParam().

          2)   All functions that access the PC429-1/2 hardware
               no longer use the segment address of the
               board.  Instead, they require the HCARD
               handle returned by PC429_Check().

          3)   The function PC429_Check() has changed
               significantly from the documentation in the
               PC429-1/2 User's Manual.  It still takes the
               segment and port address of the PC429-1/2 card,
               but returns an HCARD handle that must be
               passed to the other functions.  If the
               function fails, a negative value is returned.
               Refer to OVERVIEW.TXT for full information on
               the function.

          4)   The functions PC429_Load() and
               PC429_NameToAddr() no longer use a DOS file
               number and instead take the name of the file.
               Refer to OVERVIEW.TXT for full information on
               these functions.


                                ------------


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
     www.ballardtech.com
     support@ballardtech.com
