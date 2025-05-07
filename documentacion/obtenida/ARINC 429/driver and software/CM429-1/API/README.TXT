

                        USING THE CM429-1 DRIVER API

                               August 4, 2004

                Copyright 1997-1999 by Ballard Technology, Inc.

                                Version 1.7


                                ------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW

          C41W32.LIB    CM429-1 WIN32 import library
          C41W32.H      C/C++ language include file
          C41W32VB.BAS  Visual Basic header file
          C41W32NET.VB  VB.NET header file
          C41W32NET.CS  C# header file
          C41W32BC.LIB  CM429-1 WIN32 import library for Borland tools

          EXAMP1.C     Example 1: Receiver example from Section 3.4.
          EXAMP1.EXE
          EXAMP2.C     Example 2: Transmitter example from Section 3.5.
          EXAMP2.EXE
          EXAMP3.C     Example 3: Monitor example from Section 3.6.
          EXAMP3.EXE
          EXAMP4.C     Example 4: Explicit message timing from Section 4.4.
          EXAMP4.EXE
          EXAMP5.C     Example 5: Auto-filtering example.
          EXAMP5.EXE
          EXAMP6.C     Example 6: List buffer example.
          EXAMP6.EXE
          EXAMP7.C     Example 7: Explicit message timing and interrupts.
          EXAMP7.EXE
          EXAMP8.C     Example 8: ARINC 717 receive channel example for CM429-1/2R1T/717 card only.
          EXAMP8.EXE
          EXAMP9.C     Example 8: BNR/BCD example.
          EXAMP9.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The C41W32.H and C41W32.LIB files are the C/C++
          language header and import library for the CM429-1
          Driver API.  With these files, the user can write
          applications that operate the CM429-1 PCMCIA ARINC
          429 card.  The Driver API has been tested using the
          Microsoft Visual C++ Compiler Version 6.0 and the
          Borland C++ Compiler Version 4.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          4.5.



     C41W32.H

          WIN32 applications written in the C or C++ language
          that use the CM429-1 Driver API library must
          incorporate the header file C41W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "C41W32.H"



     C41W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the CM429-1 Driver API by adding
          C41W32VB.BAS into the Visual Basic project.  Once
          added to the project, Driver API functions can be
          called along with other user-defined functions.



     C41W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library C41W32.LIB.  Instead, Borland users should
          use C41W32BC.LIB.



     EXAMPLE PROGRAMS

          There are four examples discussed in the CM429-1
          User's Manual.  These examples, and others, are
          provided both in C source code files and WIN32
          console executable files.

          Refer to the comments in each example source file
          and to the discussion in the CM429-1 User's Manual.
          The section number of each example is shown below:

           FILE                   TITLE                      SECTION
          ---------------------------------------------------------------
          EXAMP1.C  Receiver example                           3.4
          EXAMP2.C  Transmitter example                        3.5
          EXAMP3.C  Monitor example                            3.6
          EXAMP4.C  Explicit message timing                    4.4
          EXAMP5.C  Auto-filtering example
          EXAMP6.C  List buffer example
          EXAMP7.C  Explicit message timing and interrupts
          EXAMP8.C  ARINC 717 receive example



     FUNCTION OVERVIEW

          Each function in the CM429-1 Driver library are
          listed below.  All general functions are described
          in detail in Appendix A of the CM429-1 User's
          Manual.  Functions that deal with the ARINC 717
          operation of the CM429-1/2R1T/717 are listed in the
          ARINC 717 Functions section below.

          [General Functions]

          C41_AsciiFrom       Converts ASCII string to 32-bit unsigned value.
          C41_AsciiTo         Converts 32-bit unsigned value to an ASCII string.
          C41_BCDGetData      Extracts the data value from a BCD message word.
          C41_BCDGetMant      Extracts the mantissa value from a BCD message word.
          C41_BCDGetSign      Extracts the sign from a BCD message word.
          C41_BCDGetSSM       Extracts the SSM field from a BCD message word.
          C41_BCDGetVal       Calculates the value of a BCD message word.
          C41_BCDPutData      Inserts the data value into a BCD message word.
          C41_BCDPutMant      Inserts the mantissa value into a BCD message word.
          C41_BCDPutSign      Inserts the sign into a BCD message word.
          C41_BCDPutSSM       Inserts the SSM field into a BCD message word.
          C41_BCDPutVal       Inserts the value into a BCD message word.
          C41_BNRGetData      Extracts the data value from a BNR message word.
          C41_BNRGetMant      Extracts the mantissa value from a BNR message word.
          C41_BNRGetSign      Extracts the sign from a BNR message word.
          C41_BNRGetSSM       Extracts the SSM field from a BNR message word.
          C41_BNRGetVal       Calculates the value of a BNR message word.
          C41_BNRPutData      Inserts the data value into a BNR message word.
          C41_BNRPutMant      Inserts the mantissa value into a BNR message word.
          C41_BNRPutSign      Inserts the sign into a BNR message word.
          C41_BNRPutSSM       Inserts the SSM field into a BNR message word.
          C41_BNRPutVal       Inserts the value into a BNR message word.
          C41_ChCheck         Checks if a channel exists and is a transmitter or receiver.
          C41_ChClear         Clear the contents of a channel.
          C41_ChConfig        Configure transmit or receive channel.
          C41_ChPause         Pause the operation of a channel.
          C41_ChResume        Pause the operation of a channel.
          C41_CloseAll        Close all CM429-1 cards and release all handles.
          C41_CloseCard       Close a CM429-1 card and release its handle.
          C41_ExtRd           Reads the state of the DIN and DOUT external signals.
          C41_ExtWr           Writes the state of the DOUT external signal.
          C41_FilterDefault   Creates a default filter for a receive channel.
          C41_FilterSet       Creates a message filter for a receive channel.
          C41_FldGetData      Extracts data field from a 32-bit ARINC 429 word.
          C41_FldGetLabel     Extracts the label field from a 32-bit ARINC 429 word.
          C41_FldGetParity    Extracts the parity bit from a 32-bit ARINC 429 word.
          C41_FldGetSDI       Extracts the SDI field from a 32-bit ARINC 429 word.
          C41_FldGetValue     Gets value of specified field of ARINC 429 word.
          C41_FldPutData      Inserts the data field into message word.
          C41_FldPutLabel     Inserts the label field into a message word.
          C41_FldPutSDI       Inserts the SDI field into a message word.
          C41_FldPutValue     Inserts the specified field into a message word.
          C41_IntDin          Enables interrupts on DIN external signal.
          C41_IntInstall      Install an interrupt handler.
          C41_IntRd           Read the next entry from the interrupt log list.
          C41_IntUninstall    Uninstall the interrupt handler.
          C41_ListMakeRcv     Create a Receive List Buffer for a message record.
          C41_ListMakeXmt     Create a Transmit List Buffer for a transmit channel.
          C41_ListRd          Read the next entry from a Receive List Buffer.
          C41_ListStatus      Returns the status of a Transmit or Receive List Buffer.
          C41_ListWr          Write an entry to a Transmit List Buffer.
          C41_MemPeek         Read a 16-bit word from the card memory.
          C41_MemPoke         Write a 16-bit word to the card memory.
          C41_MsgArincRd      Read message record in encoder/decoder format.
          C41_MsgArincWr      Write a value in ARINC format to a message record.
          C41_MsgBlockRd      Read the contents of a message record.
          C41_MsgBlockWr      Write the contents of a message record.
          C41_MsgCommRd       Reads a message record using communcation process.
          C41_MsgCommWr       Writes a message record using communcation process.
          C41_MsgConfig       Configure options for a message record.
          C41_MsgEncoderRd    Read message record in encoder/decoder format.
          C41_MsgEncoderWr    Write a value in HI-8282 format to a message record.
          C41_OpenCard        Open a CM429-1 card and request a handle.
          C41_PortRd          Read a byte from an IFGA register.
          C41_PortWr          Write a byte to an IFGA register.
          C41_ProcCall        Calls user code at the specified address.
          C41_ProcLoad        Loads user code into the heap.
          C41_ProcSetCh       Installs user code associated with a channel.
          C41_ProcSetMsg      Installs user code associated with a message.
          C41_Reset           Reset the CM429-1.
          C41_Restart         Restart operation of the CM429-1.
          C41_SchedBranch     Inserts a conditional branch into the transmit schedule.
          C41_SchedBuild      Creates a transmit schedule from repetition rates.
          C41_SchedCall       Inserts a call to a subroutine in the transmit schedule.
          C41_SchedGap        Insert an intermessage gap into a transmit schedule.
          C41_SchedHalt       Insert a halt into the transmit schedule.
          C41_SchedInt        Insert an interrupt into the transmit schedule.
          C41_SchedMsg        Insert a message into the transmit schedule.
          C41_SchedPause      Insert a pause into the schedule.
          C41_SchedPulse      Inserts a DIN pulse into a transmit schedule.
          C41_SchedRestart    Inserts a jump to the start the schedule.
          C41_SchedRet        Inserts a return from a subroutine in the transmit schedule.
          C41_SchedStart      Marks the start of the transmit schedule.
          C41_SelfTest        Perform a self-test of the card.
          C41_SeqClear        Clear the sequential record.
          C41_SeqConfig       Configure parameters for the sequential record.
          C41_SeqRd           Read the next entry from the sequential record.
          C41_Start           Start operation of the card.
          C41_Stop            Stop operation of the card.
          C41_TimerClear      Writes the current value of the time-tag.
          C41_TimerRd         Reads the current value of the time-tag.
          C41_TimerResolution Sets the resolution of the time-tag.

          [ARINC 717 Functions]

          C41_717Boot             Boots the card into ARINC 717 mode.
          C41_717SubFrmWordConfig Configures a word in the Subframe record.
          C41_717SubFrmWordRd     Reads a word from the Subframe record.
          C41_717SyncTest         Tests the synchronization status of the card.
          C41_717SyncWordSet      Sets the synch words to the specified values.



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
