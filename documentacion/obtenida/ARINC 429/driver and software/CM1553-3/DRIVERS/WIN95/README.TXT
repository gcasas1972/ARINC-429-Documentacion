

               INSTALLING THE CM1553-3 DRIVER UNDER WINDOWS 95

                              February 1, 2008

                Copyright 1999-2008 by Ballard Technology, Inc.

                                Version 1.5


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          C13W95.INF   Plug-and-play INF file
          C13W32.DLL   CM1553-3 WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file C13W32.DLL is a dynamic-link library
          containing the CM1553-3 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0.



     AUTOMATIC INSTALLATION

          The CM1553-3 is a Plug-and-Play device.  The first
          time the CM1553-3 is inserted into a PCMCIA slot,
          the card is detected and the driver installation
          process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Driver Provided by Manufacturer'
              option.

          2.  Click 'Next'.

          3.  Insert the CM1553-3 installation disk into
              the floppy or CD-ROM drive.

          4.  Type the path containing the driver files for
              the CM1553-3 (A:\DRIVERS\WIN95 for floppy disk
              installation) in the 'Copy manufacturer's files
              from' field.

          5.  Click 'OK' to complete the installation process.



     MANUAL INSTALLATION

          If Windows 95 does not prompt for the CM1553-3
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Insert the CM1553-3 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'Add New Hardware' icon.

          4.  When the first 'Add New Hardware Wizard' window
              opens, click 'Next'.

          5.  Select the 'No' option so Windows does not
              search for new hardware and click 'Next'.

          6.  Select 'Other Devices' from the 'Hardware
              Types' list and click 'Next'.

          7.  Click the 'Have Disk' button and insert the
              media containing the CM1553-3 installation files
              into the floppy or CD-ROM drive (if the files
              are not present on the hard disk).

          8.  Type the path containing the driver files for
              the CM1553-3 (A:\DRIVERS\WIN95 for floppy disk
              installation) in the 'Copy Manufacturer's Files
              From' field of the 'Install From Disk' dialog.

          9.  Click 'OK' to return to the 'Add New Hardware
              Wizard'.

          10. Select whichever CM1553-3 model is appropriate
              from the 'Models' list box and click 'Next'.

          11. Click 'Next' to install drivers.

          12. Click 'Finish' to complete the driver
              installation.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your CM1553-3 by double-clicking the C13TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the CM1553-3 hardware, it displays the
          Card Number and a "passed" test message.  The
          CM1553-3 is now ready to be connected to the
          MIL-STD-1553 databus.

          If the C13TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the C13TST32.EXE
          utility.  Run it with the ? switch (i.e., C13TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     DEBUGGING GUIDELINES

          To verify that the PCMCIA drivers are properly
          installed:

          1.  Insert the CM1553-3 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'PC Card' icon.

          4.  Verify the Ballard Technology company name is
              displayed for the appropriate PCMCIA slot.


          To verify that the CM1553-3 drivers are properly
          installed:

          1.  Insert the CM1553-3 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Device Manager' tab.

          5.  Verify the 'Avionics Databus Interface' group
              is visible.

          6.  Expand the 'Avionics Databus Interface' group
              and verify the CM1553-3 device is visible.

          7.  Double-click on the CM1553-3 device to see the
              CM1553-3 property page.


          To change the configuration of the CM1553-3 driver
          that already has been installed:

          1.  Insert the CM1553-3 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Device Manager' tab.

          5.  Expand the 'Avionics Databus Interface' group.

          6.  Double-click on the CM1553-3 device to see the
              CM1553-3 property page.

          7.  Select the 'Driver' tab.

          8.  Click the 'Change Driver' button.

          9.  Select the driver configuration to activate and
              click the 'OK' button.

          10. Click the 'OK' button on the CM1553-3 property
              page to make any changes active.



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
