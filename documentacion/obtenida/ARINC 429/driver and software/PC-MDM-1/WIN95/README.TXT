

                     USING THE PC-MDM-1 32-BIT DRIVER

                             September 20, 1997

                  Copyright 1997 by Ballard Technology, Inc.

                                Version 1.0


                                ------------


          This subdirectory contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver

          MDMW95.REG   Registry file
          MDMW32.DLL   PC-MDM-1 WIN32 dynamic-link library
          MDMW32.LIB   PC-MDM-1 WIN32 import library
          MDMW32.H     Include file
          MDMW32BC.LIB PC-MDM-1 WIN32 import library for Borland tools

          EXAMP1.C     Example 1: BC example transmitting from the BC to the RT
          EXAMP1.EXE
          EXAMP2.C     Example 2: BC example receiving from the RT to the BC
          EXAMP2.EXE
          EXAMP3.C     Example 3: RT example using interrupts
          EXAMP3.EXE

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file MDMW32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.  It has been tested using the
          Microsoft Visual C++ Compiler Version 4.0 and
          Microsoft Visual C++ Compiler Version 5.0.



     INSTALLATION

          MDMW95.REG installs the required registry keys to
          operate the PC-MDM-1 32-bit Driver.  To install,
          open the folder containing this file and double
          click on it.  Windows will update the required
          registry keys.

          Next, copy the following files into the
          C:\WINDOWS\SYSTEM folder:

               BTIUNIV.VXD
               BTIKRNL.DLL
               MDMW32.DLL

          Finally, restart the computer and test the card by
          running the program MDMTST32.EXE located on this
          disk.

          To verify installation of the driver, run the
          System applet in the Control Panel.  Select the
          Device Manager and verify the Avionics Databus
          Interface group is visible.  Expand the Avionics
          Databus Interface group and verify that the
          PC-MDM-1 device is visible.  Double-click on the
          PC-MDM-1 device to see the PC-MDM-1 property page.



     MDMW32.H

          WIN32 applications using the PC-MDM-1 Driver
          library must incorporate the header file MDMW32.H
          using the #include preprocessor directive.
          Assuming the header file is in the current working
          directory, the following line must be added to the
          top of the application's source file:

          #include "MDMW32.H"



     EXAMPLE PROGRAMS

          There are three examples included on the disk.  All
          three examples are provided both in C source code
          files and WIN32 console executable files.

          Refer to the comments in the source code for a
          discussion of each example.

           FILE                   TITLE
          --------------------------------------------------
          EXAMP1.C  BC example transmitting from the BC to the RT
          EXAMP2.C  BC example receiving from the RT to the BC
          EXAMP3.C  RT example using interrupts

          The C source code is written for Microsoft Visual
          C++ Version 5.0.



     FUNCTION OVERVIEW

          Each function in the PC-MDM-1 Driver library is
          listed below.  All functions are described in
          detail in Appendix A of the PC-MDM-1 User's Manual.

          MDM_CardClose     Disables access to an MDM card.
          MDM_CardOpen      Opens access to an MDM card.
          MDM_Go            Initiates a message transfer.
          MDM_OnOff         Sets or clears the on/off discrete.
          MDM_OnOffStatus   Get status of the on/off discrete.
          MDM_RcvRd         Reads the data words last received.
          MDM_RcvWr         Initializes the receive buffer.
          MDM_Status        Retrieves status information from card.
          MDM_XmtRd         Reads the data words to be transmitted.
          MDM_XmtWr         Writes the data words to be transmitted.



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
