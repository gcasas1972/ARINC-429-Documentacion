

                     USING THE PC-MDM-1 32-BIT DRIVER

                             September 20, 1997

                  Copyright 1997 by Ballard Technology, Inc.

                                Version 1.0


                                ------------


          This subdirectory contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver

          MDMWNT0.REG  Registry file that does not call out an interrupt
          MDMWNT1.REG  Registry file that calls out an interrupt
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

          Both MDMWNT0.REG and MDMWNT1.REG install the
          required registry keys to operate the PC-MDM-1
          32-bit Driver.  MDMWNT0.REG configures the PC-MDM-1
          with no interrupt allocated for the card, and
          MDMWNT1.REG configures the PC-MDM-1 with an
          interrupt.

          It is highly suggested that an interrupt NOT be
          allocated for the PC-MDM-1 on the first install.
          Most Windows NT installations use a majority of the
          interrupts, requiring the user to manually assign
          an interrupt to the PC-MDM-1.  The process for
          manually assigning resources is described in the
          next section.

          1)  To install required registry keys, open the
              folder containing the following file and double
              click on it.  Windows will update the required
              registry keys.

                   MDMWNT0.REG

          2)  Copy the following file into the
              C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL
                   MDMW32.DLL

          3)  Then, copy the following file into the
              C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4)  Restart the computer.

          5)  Test the card by running the program
              MDMTST32.EXE located on this disk.



     START-UP PROBLEMS

          If Windows NT displays a message indicating a
          service cannot be started, most likely the
          resources called out by the PC-MDM-1 device are
          conflicting with other devices in the computer.

          To see the resources being assigned to the
          PC-MDM-1, run the Registry Editor program
          REGEDIT.EXE.  Then go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ballard\Parameters\PC-MDM-1]

          This key contains several value entries which
          specify hardware resources that the PC-MDM-1
          requests from the operating system.  Since the
          PC-MDM-1 is a legacy card, the registry entries
          must be manually configured to match the DIP switch
          settings on the card.  You may need to manually
          modify the following keys:

          IrqNumber
          IoBase
          MemoryBase

          Values should be chosen that do not overlap
          resource allocations of another devices.  To see
          the allocations for other devices, run the Windows
          NT Diagnostics program in the Administrative Tools
          folder.  Select the Resources tab to see the
          interrupt, I/O, and memory allocations.



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
