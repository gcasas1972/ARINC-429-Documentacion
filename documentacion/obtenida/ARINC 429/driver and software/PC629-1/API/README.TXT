

                  USING THE PC629-1 DRIVER API AND EXAMPLES

                                July 5, 2002

                Copyright 1999-2002 by Ballard Technology, Inc.

                                Version 1.1


                                ------------


          This folder contains the following files:

           File Name                Description

          P61W32.LIB    PC629-1 WIN32 import library
          P61W32.H      Include file
          P61W32VB.BAS  Visual Basic header file
          P61W32NET.VB  VB.NET header file
          P61W32BC.LIB  PC629-1 WIN32 import library for Borland tools

          EXAMP1.C     Example 1: Cockpit Simulator Example
          EXAMP1.EXE
          EXAMP1.SCR
          EXAMP1.ROM
          EXAMP2.C     Example 2: Landing Gear Simulator Example
          EXAMP2.EXE
          EXAMP2.SCR
          EXAMP2.ROM
          EXAMP3.C     Example 3: Landing Gear Simulator Example Without Script
          EXAMP3.EXE
          EXAMP4.C     Example 4: Monitor Example
          EXAMP4.EXE
          EXAMP5.C     Example 5: RAM Dump Example
          EXAMP5.EXE
          EXAMP6.C     Example 6: PROM Dump Example
          EXAMP6.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The P61W32.H and P61W32.LIB files are the C/C++
          language header and import library for the PC629-1
          Driver API.  With these files, the user can write
          applications that operate the PC629-1 ISA ARINC 629
          card.  The Driver API has been tested using the
          Microsoft Visual C++ Compiler Version 6.0 and the
          Borland C++ Compiler Version 4.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          4.5.



     P61W32.H

          WIN32 applications written in the C or C++ language
          that use the PC629-1 Driver API library must
          incorporate the header file P61W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "P61W32.H"



     P61W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the PC629-1 Driver API by adding
          P61W32VB.BAS into the Visual Basic project.  Once
          added to the project, Driver API functions can be
          called along with other user-defined functions.



     P61W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library P61W32.LIB.  Instead, Borland users should
          use P61W32BC.LIB.



     PORTING TO WIN32

          Many functions have been modified to accomodate the
          WIN32 operating system.  As a result, the function
          prototypes described in the PC629-1 User's Manual
          do not match the actual function prototypes called
          out in the P61W32.H header file.  All of the
          changes can be summarized as follows:

          1)  The PC629_Check() function has been supersceded
              by the PC629_CardOpen() function.
              PC629_CardOpen() takes a card number and not
              the card memory and I/O address that
              PC629_Check() used.  Since card numbers start
              at zero, PC629_CardOpen(0) will always open the
              first card installed in the computer.

          2)  PC629_CardOpen() returns an HCARD card handle.
              The HCARD return value should be saved by the
              user's application and provided to every
              function that touches the hardware.

          3)  If PC629_CardOpen() fails, it returns an ERRVAL
              value.  The possible values that can be
              returned are defined in the P61W32.H header
              file.

          4)  All documented functions that required a segment
              address to select the hardware no longer take a
              segment address.  Instead, an HCARD card handle
              should be specified.  The HCARD card handle
              must have been returned by PC629_CardOpen().

          5)  PC629_CardClose() must be called by the user's
              application before it terminates.
              PC629_CardClose() takes the HCARD card handle
              returned by PC629_CardOpen() and frees resources
              associated with the hardware.

          6)  When installing an interrupt with
              PC629_IntInst(), an interrupt handler is no
              longer specified.  Instead, a WIN32 event
              handle must be specified.  The event handle is
              set to the signaled state whenever an interrupt
              is issued by the hardware.  Refer to the
              interrupt example program for details on using
              interrupts from the PC629-1 card.



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
