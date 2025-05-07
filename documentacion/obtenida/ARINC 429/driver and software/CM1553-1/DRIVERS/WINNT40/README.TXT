

             INSTALLING THE CM1553-1 DRIVER UNDER WINDOWS NT 4.0

                               April 9, 1999

                Copyright 1997,1999 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          C11WNT0.REG  Registry file that does not allocate an interrupt
          C11WNT1.REG  Registry file that allocates an interrupt
          C11WNT2.REG  Registry file with no interrupt or attribute window
          C11WNT3.REG  Registry file with an interrupt but no attribute window
          C11W32.DLL   CM1553-1 WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file C11W32.DLL is a dynamic-link library
          containing the CM1553-1 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0.



     PCMCIA DRIVER INSTALLATION

          Windows NT 4.0 includes built-in support for PCMCIA
          card drives.  When the operating system is
          installed, this support is usually disabled.  To
          enable PCMCIA support, follow these steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'Devices' icon.

          3.  Scroll down the 'Device' list and locate the
              'Pcmcia' device.

          4.  If the 'Status' column indicates 'Started', the
              PCMCIA device driver is already running.

          5.  If the 'Status column is empty, the PCMCIA
              device driver needs to be enabled.  Click the
              'Startup' button.

          6.  Select the 'System' radio button in the
              'Startup Type' group and click 'OK'.

          7.  Click 'Close' to close the 'Devices' applet.

          8.  Insert the CM1553-1 card into the PCMCIA card
              drive and restart the computer.


          To verify the Windows NT 4.0 built-in PCMCIA support is
          enabled, follow these steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'PC Card (PCMCIA)' icon.

          3.  Verify the Ballard Technology company name is
              displayed for the appropriate PCMCIA slot.



     MANUAL INSTALLATION

          Windows NT 4.0 is not a Plug-and-Play operating
          system, so the CM1553-1 drivers must be manually
          installed.

          The CM1553-1 must be inserted into the
          PCMCIA card drive before the computer is booted.

          1.  Open this folder on the driver disk and
              double-click the C11WNT0.REG file.  Windows
              will update the required registry keys.

          2.  Copy the BTIKRNL.DLL and C11W32.DLL files from
              this folder to the C:\WINNT\SYSTEM32 folder.

          3.  Copy the BTIUNIV.SYS file from this folder to
              the C:\WINNT\SYSTEM32\DRIVERS folder.

          4.  Restart the computer.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your CM1553-1 by double-clicking the C11TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the CM1553-1 hardware, it displays the
          Card Number and a "passed" test message.  The
          CM1553-1 is now ready to be connected to the
          MIL-STD-1553 databus.

          If the C11TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the C11TST32.EXE
          utility.  Run it with the ? switch (i.e., C11TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     START-UP PROBLEMS

          If Windows NT displays a message indicating a
          service cannot be started, most likely the
          resources called out by the CM1553-1 device are
          conflicting with other devices in the computer.

          To see the resources being assigned to the
          CM1553-1, run the Registry Editor program
          REGEDIT.EXE.  Then go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\CM1553Rsrc1\Parameters]

          This key contains several value entries which
          specify hardware resources that the CM1553-1
          requests from the operating system.  Since Windows
          NT does not completely support plug-and-play
          technology, you may need to manually modify the
          following keys:

          InterruptNumber
          IoBaseAddress
          MemoryMappedBaseAddress

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
