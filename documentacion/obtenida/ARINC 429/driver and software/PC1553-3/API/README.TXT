

                        USING THE PC1553-3 DRIVER API

                             February 20, 1998

                Copyright 1995-1998 by Ballard Technology, Inc.

                                Version 1.4


                                ------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW

          P13W32.LIB    PC1553-3 WIN32 import library
          P13W32.H      C/C++ language include file
          P13W32VB.BAS  Visual Basic header file
          P13W32NET.VB  VB.NET header file
          P13W32NET.CS  C# header file
          P13W32BC.LIB  PC1553-3 WIN32 import library for Borland tools

          EXAMP1.C      Example 1: Simulating the BC - Unscheduled Messages
          EXAMP1.EXE
          EXAMP2.C      Example 2: Simulating the BC - Scheduled Messages
          EXAMP2.EXE
          EXAMP3.C      Example 3: Simulating an RT
          EXAMP3.EXE
          EXAMP4.C      Example 4: Monitoring the bus
          EXAMP4.EXE
          EXAMP5.C      Example 5: Simultaneous BC, RT, and monitor simulation
          EXAMP5.EXE
          EXAMP6.C      Example 6: Errors in BC Transmissions - Unscheduled Messages
          EXAMP6.EXE
          EXAMP7.C      Example 7: Errors in BC Transmissions - Scheduled Messages
          EXAMP7.EXE
          EXAMP8.C      Example 8: Errors in RT Transmissions
          EXAMP8.EXE
          EXAMP9.C      Example 9: Interrupts
          EXAMP9.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The P13W32.H and P13W32.LIB files are the C/C++
          language header and import library for the PC1553-3
          Driver API.  With these files, the user can write
          applications that operate the PC1553-3 ISA
          MIL-STD-1553 card.  The Driver API has been tested
          using the Microsoft Visual C++ Compiler Version 6.0
          and the Borland C++ Compiler Version 4.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          4.5.



     P13W32.H

          WIN32 applications written in the C or C++ language
          that use the PC1553-3 Driver API library must
          incorporate the header file P13W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "P13W32.H"



     P13W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the PC1553-3 Driver API by adding
          P13W32VB.BAS into the Visual Basic project.  Once
          added to the project, Driver API functions can be
          called along with other user-defined functions.



     P13W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library P13W32.LIB.  Instead, Borland users should
          use P13W32BC.LIB.



     EXAMPLE PROGRAMS

          There are eight examples discussed in the PC1553-3
          User's Manual.  These examples, and others, are
          provided both in C source code files and WIN32
          console executable files.

          Refer to the comments in each example source file
          and to the discussion in the PC1553-3 User's
          Manual.  The section number of each example is
          shown below:

           FILE                   TITLE                              SECTION
          -------------------------------------------------------------------
          EXAMP1.C  Simulating the BC - Unscheduled Messages           4.1
          EXAMP2.C  Simulating the BC - Scheduled Messages             4.2
          EXAMP3.C  Simulating an RT                                   4.3
          EXAMP4.C  Monitoring the bus                                 4.4
          EXAMP5.C  Simultaneous BC, RT, and monitor simulation        5.1
          EXAMP6.C  Errors in BC Transmissions - Unscheduled Messages  6.2
          EXAMP7.C  Errors in BC Transmissions - Scheduled Messages    6.3
          EXAMP8.C  Errors in RT Transmissions                         6.4
          EXAMP9.C  Interrupts                                         X.X



     FUNCTION OVERVIEW

          Each function in the PC1553-3 Driver library are
          listed below.  All functions are described in
          detail in Appendix A of the PC1553-3 User's Manual.

          P13_BCConfig      Initializes a BC terminal configuration.
          P13_BCCreateMsg   Creates and initializes a BC message structure.
          P13_BCSchedFrame  Appends the start of a new frame to the schedule.
          P13_BCSchedMsg    Appends a message transmission to the schedule.
          P13_BCSchedRetry  Appends a conditional retry of the last transmssion.
          P13_BCTransmitMsg Transmit a single message.
          P13_CardClose     Disables access to a PC1553-3 card.
          P13_CardOpen      Enables access to a PC1553-3 card.
          P13_CardReset     Resets the PC1553-3 hardware.
          P13_CardStart     Start operation of the specified PC1553-3.
          P13_CardStop      Stop operation of the specified PC1553-3.
          P13_ErrorCtrl     Enables error injection.
          P13_ErrorDefine   Defines an error to be injected.
          P13_ErrorSent     Determines whether or not an error has been sent.
          P13_ErrorTagBC    Tags a BC message to receive an error.
          P13_ErrorTagRT    Tags an RT message to receive an error.
          P13_MonConfig     Configures the monitor of the card.
          P13_MonFilterSA   Configures subaddress filtering.
          P13_MonFilterTA   Configures terminal address filtering.
          P13_MonIsRunning  Determines whether the monitor is recording.
          P13_MonRd         Reads the next message record from the monitor.
          P13_MsgDataRd     Read the data associated with a message.
          P13_MsgDataWr     Write the data associated with a message.
          P13_MsgFieldRd    Read a field from a message structure.
          P13_MsgFieldWr    Write a field to a message structure.
          P13_RTConfig      Configure the card for remote terminal mode.
          P13_RTCreateMsg   Create or reconfigure an RT message structure.
          P13_RTGetMsg      Gets the address of an existing message.
          P13_RTSWDWr       Sets the status word for the RT.
          P13_ValPackCWD    Create a MIL-STD-1553 command word from its fields.
          P13_ValUnpackCWD  Extract fields from a MIL-STD-1553 command word.



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
