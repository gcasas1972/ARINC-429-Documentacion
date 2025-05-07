

            INSTALLING THE LP429-3 OR LC429-3 DRIVER UNDER WINDOWS ME

                             February 5, 2003

                Copyright 1997-2003 by Ballard Technology, Inc.

                                Version 2.0


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          L43WME.INF   Plug-and-play INF file
          L43W32.DLL   WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file L43W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     AUTOMATIC INSTALLATION

          The LP429-3 and LC429-3 are Plug-and-Play devices.
          The first time Windows ME boots with the LP429-3
          installed in a PCI slot or the LC429-3 installed in
          a cPCI slot, the card is detected and the driver
          installation process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Specify the location of the driver'
              option and click 'Next'.

          2.  Remove all check marks from all of the check
              boxes.

          3.  Check the 'Specify a location' check box and
              type the path containing the driver files for
              the Lx429-3 (A:\DRIVERS\WINME for floppy disk
              installation).

          4.  Insert the media containing the Lx429-3
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          5.  Select 'The updated software' option and click
              'Next'.

          6.  Click 'Next' again to begin the installation
              process.

          7.  Click 'Finish' to complete the installation
              process.



     MANUAL INSTALLATION

          If Windows ME does not prompt for the LP429-3 or
          LC429-3 drivers, and the drivers are not yet
          installed, a manual installation of the drivers is
          required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the 'Device Manager' tab.

          4.  Expand the 'Other devices' tree item and double
              click the Lx429-3 card.

          5.  Click the "Reinstall Driver' button to start
              the 'Update Device Driver Wizard'.

          6.  Select the 'Specify the location of the driver'
              option and click 'Next'.

          7.  Remove all check marks from all of the check
              boxes.

          8.  Check the 'Specify a location' check box and
              type the path containing the driver files for
              the Lx429-3 (A:\DRIVERS\WINME for floppy disk
              installation).

          9.  Insert the media containing the Lx429-3
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          10. Select 'The updated driver' option and click
              'Next'.

          11. Click 'Next' again to begin the installation
              process.

          12. Click 'Finish' to complete the installation
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
