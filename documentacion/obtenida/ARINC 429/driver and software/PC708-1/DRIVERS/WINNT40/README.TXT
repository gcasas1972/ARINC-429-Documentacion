

                 INSTALLING THE PC708-1 DRIVER UNDER WINDOWS NT

                               July 14, 2000

                 Copyright 1998-2000 by Ballard Technology, Inc.

                                Version 1.3


                                ------------


          This subdirectory contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P71WNT0.REG  Registry file that does not call out an interrupt
          P71WNT1.REG  Registry file that calls out an interrupt
          P71W32.DLL   WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P71W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     INSTALLATION

          Both P71WNT0.REG and P71WNT1.REG install the
          required registry keys to operate the PC708-1
          32-bit Driver.  P71WNT0.REG configures the PC708-1
          with no interrupt allocated for the card, and
          P71WNT1.REG configures the PC708-1 with an
          interrupt.

          It is highly suggested that an interrupt NOT be
          allocated for the PC708-1 on the first install.
          Most Windows NT installations use a majority of the
          interrupts, requiring the user to manually assign
          an interrupt to the PC708-1.  The process for
          manually assigning resources is described in the
          next section.

          1)  To install required registry keys, open the
              folder containing the following file and double
              click on it.  Windows will update the required
              registry keys.

                   P71WNT0.REG

          2)  Copy the following files into the
              C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL
                   P71W32.DLL

          3)  Then, copy the following file into the
              C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4)  Restart the computer.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'Devices' icon.

          3.  Scroll down the Devices list and verify that
              the status of the 'Ballard Tech Universal'
              driver is shown as 'Started'.

          If the driver is not started, then an error
          occurred loading the driver.  To see the error
          messages, follow these steps:

          1.  Click the 'Start' button, open the 'Programs'
              group, open the 'Administrative Toos' group,
              and click 'Event Viewer'.

          2.  Open the 'Log' menu and verify 'System' is
              selected.

          3.  Starting at the top of the list, double-click
              each entry tagged with a red X.  Any error
              messages from the Ballard Tech Universal driver
              will have the prefix BTI listed.

          If Windows NT displays a message indicating a
          service cannot be started, most likely the
          resources called out by the PC708-1 device are
          conflicting with other devices in the computer.

          To see the resources being assigned to the
          PC708-1, run the Registry Editor program
          REGEDIT.EXE.  Then go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ballard\Parameters\PC708-1]

          This key contains several value entries which
          specify hardware resources that the PC708-1
          requests from the operating system.  Since the
          PC708-1 is a legacy card, the registry entries
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



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your PC708-1 by double-clicking the P71TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the PC708-1 hardware, it displays the
          card resources and a "passed" test message.  The
          PC708-1 is now ready to be connected to the
          ARINC 708 / ARINC 453 databuses.

          If the P71TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the P71TST32.EXE
          utility.  Run it with the ? switch (i.e., P71TST32
          ?) to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



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
