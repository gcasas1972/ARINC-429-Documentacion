

            INSTALLING THE Lx-AFDX-1 DRIVER UNDER WINDOWS 2000 & XP

                               July 14, 2006

                Copyright 2005-2006 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIWDM.SYS   Ballard Technology's Universal WDM Driver
          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          AX1W32.INF   Plug-and-play INF file
          AX1W32.DLL   WIN32 dynamic-link library
          RCVW32.DLL   WIN32 receive dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file AX1W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     AUTOMATIC INSTALLATION FOR WINDOWS XP

          The LP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 are
          Plug-and-Play devices.  The first time Windows XP
          boots with the LP-AFDX-1 installed in a PCI slot,
          the LC-AFDX-1 installed in a cPCI slot, or
          LM-AFDX-1 installed in a PMC slot, the card is
          detected and the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          2.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          3.  Insert the media containing the Lx-AFDX-1
              installation files into the floppy or CD-ROM
              drive.

          4.  In the edit box, type the path to the folder
              containing the driver files for the Lx-AFDX-1
              (D:\LX-AFDX-1\DRIVERS for CD installation).
              Browse for the folder if needed.  When the path
              is entered, click 'OK'.

          5.  Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     AUTOMATIC INSTALLATION FOR WINDOWS 2000

          The LP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 are
          Plug-and-Play devices.  The first time Windows 2000
          boots with the LP-AFDX-1 installed in a PCI slot,
          the LC-AFDX-1 installed in a cPCI slot, or
          LM-AFDX-1 installed in a PMC slot, the card is
          detected and the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the Found New Hardware Wizard
              starts to begin installing the driver.

          2.  After the wizard finds the 'Other PCI Bridge
              Device', select the 'Search for a suitable
              driver for my device' option and click 'Next'.

          3.  Enable the checkbox for the option 'Specify a
              location' in the list of optional search
              locations.  Remove the check box for the other
              search locations.

          4.  Click 'Next' and insert the media containing
              the Lx-AFDX-1 installation files into the
              floppy or CD-ROM drive.

          5.  Type the path containing the driver files for
              the Lx-AFDX-1 (D:\LX-AFDX-1\DRIVERS for CD
              installation) in the 'Copy manufacturer's files
              from' field.

          6.  Click 'OK' to search for the drivers for the
              LP-AFDX-1, LC-AFDX-1, or LM-AFDX-1.

          7.  Click 'Next' to proceed with the driver
              installation.

          8.  Click 'Finish' to complete the driver
              installation process.



     MANUAL INSTALLATION FOR WINDOWS XP

          If Windows XP does not prompt for the Lx-AFDX-1
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Install the LP-AFDX-1 in a PCI slot, LC-AFDX-1
              in a cPCI slot, or LM-AFDX-1 in a PMC slot, and
              turn power on to the computer.

          2.  Run the 'System' applet in the Control Panel.

          3.  Select the 'Hardware' tab and click the 'Device
              Manager' button.

          4.  Expand the 'Other devices' tree item and double
              click the Lx-AFDX-1 device.

          5.  Click the "Reinstall Driver' button to start
              the 'Hardware Update Wizard'.

          6.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          7.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          8.  Insert the media containing the Lx-AFDX-1
              installation files into the floppy or CD-ROM
              drive.

          9.  In the edit box, type the path to the folder
              containing the driver files for the Lx-AFDX-1
              (D:\LX-AFDX-1\DRIVERS for CD installation).
              Browse for the folder if needed.  When the path
              is entered, click 'OK'.

          10. Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     MANUAL INSTALLATION FOR WINDOWS 2000

          If Windows 2000 does not prompt for the Lx-AFDX-1
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the 'Hardware' tab.

          4.  Click the 'Device Manager' button.

          5.  Expand the 'Other devices' tree item and double
              click the Lx-AFDX-1 card.

          6.  Click the "Reinstall Driver' button to start
              the 'Update Device Driver Wizard'.

          7.  Click 'Next' when the 'Update Device Driver
              Wizard' starts.

          8.  Select the 'Search for better driver' option
              and click 'Next'.

          9.  Remove all check marks from all of the check
              boxes.

          10. Check the 'Specify a location' check box.

          11. Insert the media containing the Lx-AFDX-1
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          12. In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the Lx-AFDX-1 (D:\LX-AFDX-1\DRIVERS for CD
              installation).  Click 'OK'.

          13. When the drivers are found, click 'Next'.

          14. Click 'Finish' to complete the installation
              process.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your LP-AFDX-1, LC-AFDX-1, or LM-AFDX-1 by
          double-clicking the AX1TST32.EXE program provided
          on this installation disk.  This program completes
          execution within several seconds.  If the program
          does not detect any faults with the interface or
          the LP-AFDX-1, LC-AFDX-1, or LM-AFDX-1 hardware, it
          displays the Card Number and a "passed" test
          message.  The LP-AFDX-1, LC-AFDX-1, or LM-AFDX-1 is
          now ready to be connected to the AFDX databus.

          If the AX1TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the AX1TST32.EXE
          utility.  Run it with the ? switch (i.e., AX1TST32
          ?) to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Run the 'System' applet in the Control Panel.

          2.  In Windows XP, select the 'Hardware' tab and
              click the 'Device Manager' button.  In Windows
              2000, select the 'Device Manager' tab.

          3.  Verify the 'Avionics Databus Interface' group
              is visible.

          4.  Expand the 'Avionics Databus Interface' group
              and verify the LP-AFDX-1, LC-AFDX-1, or
              LM-AFDX-1 device is present.

          5.  Double-click the LP-AFDX-1, LC-AFDX-1, or
              LM-AFDX-1 card to see the property page.

          6.  Verify the "Device Status" box does not report
              any errors.



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
