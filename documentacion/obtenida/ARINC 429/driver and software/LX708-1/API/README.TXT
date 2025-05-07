

             USING THE LP708-1 AND LC708-1 DRIVER API AND EXAMPLES

                              January 19, 2001

                Copyright 1999-2001 by Ballard Technology, Inc.

                                Version 1.2


                               -------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW

          L71W32.LIB    WIN32 import library
          L71W32.H      C/C++ language include file
          L71W32VB.BAS  Visual Basic header file
          L71W32NET.VB  VB.NET header file
          L71W32NET.CS  C# header file
          L71W32BC.LIB  WIN32 import library for Borland tools

          EXAMP1.C      Example 1: Transmitter Interrupt example
          EXAMP1.EXE
          EXAMP2.C      Example 2: Transmitter Polling example
          EXAMP2.EXE
          EXAMP3.C      Example 3: Transmitter File loading example
          EXAMP3.EXE
          EXAMP3.DAT
          EXAMP4.C      Example 4: Receiver Single message example
          EXAMP4.EXE
          EXAMP5.C      Example 5: Receiver Sequential Record example
          EXAMP5.EXE
          EXAMP6.C      Example 6: Receiver File storing example
          EXAMP6.EXE
          EXAMP7.C      Example 7: Header extraction example
          EXAMP7.EXE
          EXAMP8.C      Example 8: Delta monitoring example
          EXAMP8.EXE
          EXAMP9.C      Example 9: Sequential Record Block Read example
          EXAMP9.EXE

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The L71W32.H and L71W32.LIB files are the C/C++
          language header and import library for the LP708-1
          and LC708-1 Driver API.  With these files, the user
          can write applications that operate the LP708-1 PCI
          ARINC 708 card and the LC708-1 cPCI ARINC 708 card.
          The Driver API has been tested using the Microsoft
          Visual C++ Compiler Version 6.0 and the Borland C++
          Compiler Version 5.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          5.5.



     L71W32.H

          WIN32 applications written in the C or C++ language
          that use the LP708-1 and LC708-1 Driver API library
          must incorporate the header file L71W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "L71W32.H"



     L71W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the LP708-1 and LC708-1 Driver API
          by adding L71W32VB.BAS to the Visual Basic project.
          Once added to the project, Driver API functions can
          be called along with other user-defined functions.



     L71W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library L71W32.LIB.  Instead, Borland users should
          use L71W32BC.LIB.



     FUNCTION OVERVIEW

          The most commonly used functions in the L71 Driver
          library are listed below.  All functions are
          described in detail in Appendix A of the L71 User's
          Manual.

          L71_CardClose     Disables access to a PC708-1 card.
          L71_CardOpen      Enables access to a PC708-1 card.
          L71_CardReset     Resets a PC708-1 card.
          L71_CardStart     Start operation of the specified PC708-1.
          L71_CardStop      Stop operation of the specified PC708-1.
          L71_IntInstall    Install an interrupt handler.
          L71_IntRd         Read an entry from the interrupt log list.
          L71_IntStatus     Check the status of the interrupt log list.
          L71_IntUninstall  Uninstall an interrupt handler.
          L71_RcvConfig     Configures the receiver.
          L71_RcvConfigEx   Configures the receiver with a periodic interrupt.
          L71_RcvMonBlkRd   Reads a block of messages out of the sequential monitor.
          L71_RcvMonRd      Reads a message out of the sequential monitor.
          L71_RcvMonRdEx    Reads an indexed message out of the monitor.
          L71_RcvMonStatus  Check the status of the sequential monitor.
          L71_RcvRd         Reads the most current message.
          L71_XmtConfig     Configures the transmitter for a single message.
          L71_XmtConfigEx   Configures the transmitter for several messages.
          L71_XmtRd         Read the data associated with a message.
          L71_XmtStatus     Get the status of the transmitter.
          L71_XmtWr         Write the data associated with a message.

          The following utility functions allow for reading
          and writing of the ARINC 708 data fields.  These
          functions read and write to data fields in host
          memory.  They do not access hardware.

          L71_FieldGetAngle
          L71_FieldGetAngleFl
          L71_FieldGetControlAccept
          L71_FieldGetData
          L71_FieldGetDataAccept
          L71_FieldGetFaults
          L71_FieldGetGain
          L71_FieldGetLabel
          L71_FieldGetMode
          L71_FieldGetRange
          L71_FieldGetTilt
          L71_FieldGetTiltFl
          L71_FieldPutAngle
          L71_FieldPutAngleFl
          L71_FieldPutControlAccept
          L71_FieldPutData
          L71_FieldPutDataAccept
          L71_FieldPutFaults
          L71_FieldPutGain
          L71_FieldPutLabel
          L71_FieldPutMode
          L71_FieldPutRange
          L71_FieldPutTilt
          L71_FieldPutTiltFl



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
