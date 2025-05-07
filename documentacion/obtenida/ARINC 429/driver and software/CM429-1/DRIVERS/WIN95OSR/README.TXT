

             INSTALLING THE CM429-1 DRIVER UNDER WINDOWS 95 OSR2

                                May 26, 1999

                Copyright 1997-1999 by Ballard Technology, Inc.

                                Version 1.7


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          C41W95.INF   Plug-and-play INF file
          C41W32.DLL   CM429-1 WIN32 dynamic link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file C41W32.DLL is a dynamic-link library
          containing the CM429-1 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 4.0, Microsoft Visual C++ Compiler Version
          5.0, and Microsoft Visual C++ Compiler Version 6.0.



     AUTOMATIC INSTALLATION

          The CM429-1 is a Plug-and-Play device.  The first
          time the CM429-1 is inserted into a PCMCIA slot,
          the card is detected and the driver installation
          process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the 'Update Device Driver
              Wizard' starts.

          2.  If the drivers are not found, click on the
              'Other Locations' button.

          3.  Type the path containing the driver files for
              the CM429-1 (A:\DRIVERS\WIN95OSR for floppy
              disk installation) and click 'OK'.

          4.  Click the 'Finish' button to start the
              installation process.

          5.  If some of the files cannot be found, reenter
              the path containing the driver files for the
              CM429-1 (A:\DRIVERS\WIN95OSR for floppy disk
              installation) into the 'Copy Files From' field
              and click 'OK'.



     MANUAL INSTALLATION

          If Windows 95 OSR2 does not prompt for the CM429-1
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Insert the CM429-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Expand the 'Other devices' tree item and double
              click the CM429-1 card.

          5.  Select the 'Driver' tab.

          6.  Click the 'Update Driver' button to start
              the 'Update Device Driver Wizard'.

          7.  Select the 'Yes' option to search for the
              driver and click 'Next'.

          8.  If the drivers are not found, click on the
              'Other Locations' button.

          9.  Type the path containing the driver files for
              the CM429-1 (A:\DRIVERS\WIN95OSR for floppy
              disk installation) and click 'OK'.

          10. Click the 'Finish' button to start the
              installation process.

          11. If some of the files cannot be found, reenter
              the path containing the driver files for the
              CM429-1 (A:\DRIVERS\WIN95OSR for floppy disk
              installation) into the 'Copy Files From' field
              and click 'OK'.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your CM429-1 by double-clicking the C41TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the CM429-1 hardware, it displays the
          Card Number and a "passed" test message.  The
          CM429-1 is now ready to be connected to the ARINC
          429 databus.

          If the C41TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the C41TST32.EXE
          utility.  Run it with the ? switch (i.e., C41TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     DEBUGGING GUIDELINES

          To verify that the PCMCIA drivers are properly
          installed:

          1.  Insert the CM429-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'PC Card' icon.

          4.  Verify the Ballard Technology company name is
              displayed for the appropriate PCMCIA slot.


          To verify that the CM429-1 drivers are properly
          installed:

          1.  Insert the CM429-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Device Manager' tab.

          5.  Verify the 'Avionics Databus Interface' group
              is visible.

          6.  Expand the 'Avionics Databus Interface' group
              and verify the CM429-1 device is visible.

          7.  Double-click on the CM429-1 device to see the
              CM429-1 property page.


          To change the configuration of the CM429-1 driver
          that already has been installed:

          1.  Insert the CM429-1 card into a PCMCIA slot.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Device Manager' tab.

          5.  Expand the 'Avionics Databus Interface' group.

          6.  Double-click on the CM429-1 device to see the
              CM429-1 property page.

          7.  Select the 'Driver' tab.

          8.  Click the 'Change Driver' button.

          9.  Select the driver configuration to activate and
              click the 'OK' button.

          10. Click the 'OK' button on the CM429-1 property
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
