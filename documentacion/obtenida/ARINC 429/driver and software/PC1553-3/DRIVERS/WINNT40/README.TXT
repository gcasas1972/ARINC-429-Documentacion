

              INSTALLING THE PC1553-3 DRIVER UNDER WINDOWS NT 4.0

                             February 20, 1998

                Copyright 1995-1998 by Ballard Technology, Inc.

                                Version 1.4


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P13WNT0.REG  Registry file that does not call out an interrupt
          P13WNT1.REG  Registry file that calls out an interrupt
          P13W32.DLL   PC1553-3 WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P13W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.  It has been tested using the
          Microsoft Visual C++ Compiler Version 4.0 and
          Microsoft Visual C++ Compiler Version 5.0.



     INSTALLATION

          Both P13WNT0.REG and P13WNT1.REG install the
          required registry keys to operate the PC1553-3
          32-bit Driver.  P13WNT0.REG configures the PC1553-3
          with no interrupt allocated for the card, and
          P13WNT1.REG configures the PC1553-3 with an
          interrupt.

          It is highly suggested that an interrupt NOT be
          allocated for the PC1553-3 on the first install.
          Most Windows NT installations use a majority of the
          interrupts, requiring the user to manually assign
          an interrupt to the PC1553-3.  The process for
          manually assigning resources is described in the
          next section.

          1.  Open this folder and double click on the
              following file to update the required registry
              keys.

                   P13WNT0.REG

          2.  Copy the following files into the
              C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL
                   P13W32.DLL

          3.  Copy the following file into the
              C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4.  Restart the computer.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your PC1553-3 by double-clicking the P13TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the PC1553-3 hardware, it displays the
          Card Number and a "passed" test message.  The
          PC1553-3 is now ready to be connected to the
          MIL-STD-1553 databus.

          If the P13TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the P13TST32.EXE
          utility.  Run it with the ? switch (i.e., P13TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     START-UP PROBLEMS

          If Windows NT displays a message indicating a
          service cannot be started, most likely the
          resources called out by the PC1553-3 device are
          conflicting with other devices in the computer.

          To see the resources being assigned to the
          PC1553-3, run the Registry Editor program
          REGEDIT.EXE.  Then go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ballard\Parameters\PC1553-3]

          This key contains several value entries which
          specify hardware resources that the PC1553-3
          requests from the operating system.  Since the
          PC1553-3 is a legacy card, the registry entries
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
