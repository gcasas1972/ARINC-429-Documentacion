

             USING THE LP1553-3 AND LC1553-3 DRIVER API AND EXAMPLES

                              February 1, 2008

                  Copyright 1997-2008 by Ballard Technology, Inc.

                                Version 2.2


                                ------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW
          <SUPPORT>     Unsupported examples from Customer Support

          L13W32.LIB    WIN32 import library
          L13W32.H      C/C++ language include file
          L13W32VB.BAS  Visual Basic header file
          L13W32NET.VB  VB.NET header file
          L13W32NET.CS  C# header file
          L13W32BC.LIB  WIN32 import library for Borland tools

          EXAMP1.C     Example 1: Simulating the BC - Unscheduled Messages
          EXAMP1.EXE
          EXAMP2.C     Example 2: Simulating the BC - Scheduled Messages
          EXAMP2.EXE
          EXAMP3.C     Example 3: Simulating an RT
          EXAMP3.EXE
          EXAMP4.C     Example 4: Monitoring the bus
          EXAMP4.EXE
          EXAMP5.C     Example 5: Simultaneous BC, RT, and monitor simulation
          EXAMP5.EXE
          EXAMP6.C     Example 6: Errors in BC Transmissions - Unscheduled Messages
          EXAMP6.EXE
          EXAMP7.C     Example 7: Errors in BC Transmissions - Scheduled Messages
          EXAMP7.EXE
          EXAMP8.C     Example 8: Errors in RT Transmissions
          EXAMP8.EXE
          EXAMP9.C     Example 9: Interrupts
          EXAMP9.EXE
          EXAMP10.C    Example 10: BC Transmission of Ramping Data Using a Circular Buffer
          EXAMP10.EXE
          EXAMP11.C    Example 11: BC Transmission of Ramping Data Using a FIFO
          EXAMP11.EXE
          EXAMP12.C    Example 12: BC Transmission of Data Using a Ping-Pong Buffer
          EXAMP12.EXE
          EXAMP13.C    Example 13: Polled interrupts
          EXAMP13.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The L13W32.H and L13W32.LIB files are the C/C++
          language header and import library for the LP1553-3
          and LC1553-3 Driver API.  With these files, the
          user can write applications that operate the
          LP1553-3 PCI MIL-STD-1553 card and the LC1553-3
          cPCI MIL-STD-1553 card.  The Driver API has been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          5.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          5.5.



     L13W32.H

          WIN32 applications written in the C or C++ language
          that use the LP1553-3 and LC1553-3 Driver API
          library must incorporate the header file L13W32.H
          using the #include preprocessor directive.
          Assuming the header file is in the current working
          directory or in the INCLUDE path, the following
          line must be added to the top of the application's
          source file:

          #include "L13W32.H"



     L13W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the LP1553-3 and LC1553-3 Driver
          API by adding L13W32VB.BAS to the Visual Basic
          project.  Once added to the project, Driver API
          functions can be called along with other
          user-defined functions.



     L13W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library L13W32.LIB.  Instead, Borland users should
          use L13W32BC.LIB.



     EXAMPLE PROGRAMS

          There are eight examples discussed in the LP1553-3
          and LC1553-3 User's Manual.  These examples, and
          others, are provided both in C source code files
          and 32-bit console executable files.

          Refer to the comments in each example source file
          and to the discussion in the LP1553-3 and LC1553-3
          User's Manual.  The section number of each example
          is shown below:

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
          EXAMP9.C  Interrupts
          EXAMP10.C Transmission of Ramping Data Using a Circular Buffer
          EXAMP11.C Transmission of Ramping Data Using a FIFO
          EXAMP12.C Transmission of Data Using a Ping-Pong Buffer
          EXAMP13.C Polled interrupts

          The C source code is written for Visual C++
          Version 6.0.



     FUNCTION OVERVIEW

          The most commonly used functions in the LP1553-3
          and LC1553-3 Driver library are listed below.  All
          functions are described in detail in Appendix A of
          the LP1553-3 and LC1553-3 User's Manual.

          L13_BCConfig      Initializes a BC terminal configuration.
          L13_BCCreateMsg   Creates and initializes a BC message structure.
          L13_BCSchedFrame  Appends the start of a new frame to the schedule.
          L13_BCSchedMsg    Appends a message transmission to the schedule.
          L13_BCSchedRetry  Appends a conditional retry of the last transmssion.
          L13_BCTransmitMsg Transmit a single message.
          L13_CardClose     Disables access to a LP1553-3 or LC1553-3 card.
          L13_CardOpen      Enables access to a LP1553-3 or LC1553-3 card.
          L13_CardReset     Resets the LP1553-3 or LC1553-3 hardware.
          L13_CardStart     Start operation of the specified LP1553-3 or LC1553-3.
          L13_CardStop      Stop operation of the specified LP1553-3 or LC1553-3.
          L13_ErrorCtrl     Enables error injection.
          L13_ErrorDefine   Defines an error to be injected.
          L13_ErrorSent     Determines whether or not an error has been sent.
          L13_ErrorTagBC    Tags a BC message to receive an error.
          L13_ErrorTagRT    Tags an RT message to receive an error.
          L13_MonConfig     Configures the monitor of the card.
          L13_MonFilterSA   Configures subaddress filtering.
          L13_MonFilterTA   Configures terminal address filtering.
          L13_MonIsRunning  Determines whether the monitor is recording.
          L13_MonRd         Reads the next message record from the monitor.
          L13_MsgDataRd     Read the data associated with a message.
          L13_MsgDataWr     Write the data associated with a message.
          L13_MsgFieldRd    Read a field from a message structure.
          L13_MsgFieldWr    Write a field to a message structure.
          L13_RTConfig      Configure the card for remote terminal mode.
          L13_RTCreateMsg   Create or reconfigure an RT message structure.
          L13_RTGetMsg      Gets the address of an existing message.
          L13_RTSWDWr       Sets the status word for the RT.
          L13_ValPackCWD    Create a MIL-STD-1553 command word from its fields.
          L13_ValUnpackCWD  Extract fields from a MIL-STD-1553 command word.



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
