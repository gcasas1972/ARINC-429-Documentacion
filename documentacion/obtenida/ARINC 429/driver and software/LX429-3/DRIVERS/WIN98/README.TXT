

            INSTALLING THE LP429-3 OR LC429-3 DRIVER UNDER WINDOWS 98

                             February 5, 2003

                 Copyright 1997-2003 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          L43W98.INF   Plug-and-play INF file
          L43W32.DLL   WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file L43W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     AUTOMATIC INSTALLATION

          The LP429-3 and LC429-3 are Plug-and-Play
          devices.  The first time Windows 98 boots with the
          LP429-3 installed in a PCI slot or the LC429-3
          installed in a cPCI slot, the card is detected and
          the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the Add New Hardware Wizard
              detects a 'PCI Bridge'.

          2.  Select the 'Display a list of all the drivers in
              a specific location' option and click 'Next'.

          3.  When prompted to select the device type, ignore
              this step and press 'Next'.

          4.  Click 'Have Disk' and insert the media
              containing the LP429-3 and LC429-3
              installation files into the floppy or CD-ROM
              drive.

          5.  Type the path containing the driver files for
              the LP429-3 and LC429-3 (A:\DRIVERS\WIN98 for
              floppy disk installation) in the 'Copy
              manufacturer's files from' field of the
              'Install From Disk' window.

          6.  Click 'OK' to return to the 'Add New Hardware
              Wizard'.

          7.  Select the LP429-3 or LC429-3 and click 'Next'.

          8.  Press 'Next' again to install the drivers at
              the specified location.

          9.  Click 'Finish' to complete the driver
              installation process.



     MANUAL INSTALLATION

          If Windows 98 does not prompt for the LP429-3 or
          LC429-3 drivers, and the drivers are not yet
          installed, a manual installation of the drivers is
          required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'Add New Hardware' icon.

          3.  When the first 'Add New Hardware Wizard' window
              opens, click 'Next'.

          4.  Click 'Next' to automatically search for Plug
              and Play hardware.

          5.  Select the 'No' option so Windows does not
              search for new hardware and click 'Next'.

          6.  Select 'Other devices' from the Hardware types
              list and click 'Next'.

          7.  Click 'Have Disk' and insert the media
              containing the LP429-3 and LC429-3
              installation files into the floppy or CD-ROM
              drive.

          8.  Type the path containing the driver files for
              the LP429-3 and LC429-3 (A:\DRIVERS\WIN98 for
              floppy disk installation) in the 'Copy
              manufacturer's files from' field of the
              'Install From Disk' window.

          9.  Click 'OK' to return to the 'Add New Hardware
              Wizard'.

          10.  Select the LP429-3 or LC429-3 from the
               Models list box and click 'Next'.

          11.  Click 'Next' to install drivers.

          12.  Click 'Finish' to complete driver installation
               process.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your LP429-3 or LC429-3 by double-clicking the
          L43TST32.EXE program provided on this installation
          disk.  This program completes execution within
          several seconds.  If the program does not detect
          any faults with the interface or the LP429-3 or
          LC429-3 hardware, it displays the Card Number and
          a "passed" test message.  The LP429-3 or LC429-3
          is now ready to be connected to the ARINC 429
          databuses.

          If the L43TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the L43TST32.EXE
          utility.  Run it with the ? switch (i.e., L43TST32
          ?) to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the "Device Manager" tab.

          4.  Expand the "Avionics Databus Interface" group.

          5.  Double-click the LP429-3 or LC429-3 card.

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
