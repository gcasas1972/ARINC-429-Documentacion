

               INSTALLING THE CM1553-1 DRIVER UNDER WINDOWS 2000

                               April 9, 1999

                Copyright 1997,1999 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIWDM.SYS   Ballard Technology's Universal WDM Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          C11W2K.INF   Plug-and-play INF file
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



     AUTOMATIC INSTALLATION

          The CM1553-1 is a Plug-and-Play device.  The first
          time the CM1553-1 is inserted into a PCMCIA slot,
          the card is detected and the driver installation
          process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the 'Found New Hardware
              Wizard' starts.

          2.  Select the 'Search for a suitable driver for my
              device' option and click 'Next'.

          3.  Remove all check marks from all of the check
              boxes and check the 'Specify a location' check
              box.  Click 'Next'.

          4.  Insert the media containing the CM1553-1
              installation files into the floppy or CD-ROM
              drive.

          5.  In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the CM1553-1 (A:\DRIVERS\WIN2K for floppy disk
              installation).  Click 'OK'.

          6.  When the drivers are found, click 'Next'.

          7.  Click 'Finish' to complete the installation
              process.



     MANUAL INSTALLATION

          If Windows 2000 does not prompt for the CM1553-1
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Insert the CM1553-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Hardware' tab.

          5.  Click the 'Device Manager' button.

          6.  Expand the 'Other devices' tree item and double
              click the CM1553-1 card.

          7.  Click the "Reinstall Driver' button to start
              the 'Update Device Driver Wizard'.

          8.  Click 'Next' when the 'Update Device Driver
              Wizard' starts.

          9.  Select the 'Search for better driver' option
              and click 'Next'.

          10. Remove all check marks from all of the check
              boxes.

          11. Check the 'Specify a location' check box.

          12. Insert the media containing the CM1553-1
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          13. In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the CM1553-1 (A:\DRIVERS\WIN2K for floppy disk
              installation).  Click 'OK'.

          14. When the drivers are found, click 'Next'.

          15. Click 'Finish' to complete the installation
              process.



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



     DEBUGGING GUIDELINES

          To verify that the CM1553-1 drivers are properly
          installed:

          1.  Insert the CM1553-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Hardware' tab.

          5.  Click the 'Device Manager' button.

          6.  Verify the 'Avionics Databus Interface' group
              is visible.

          7.  Expand the 'Avionics Databus Interface' group
              and verify the CM1553-1 device is visible.

          8.  Double-click on the CM1553-1 device to see the
              CM1553-1 property page.



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
