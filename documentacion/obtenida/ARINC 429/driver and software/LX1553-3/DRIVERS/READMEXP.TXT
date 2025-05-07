

            INSTALLING THE LP1553-3 OR LC1553-3 DRIVER UNDER WINDOWS XP

                              February 1, 2008

                 Copyright 1997-2008 by Ballard Technology, Inc.

                                Version 2.2


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIWDM.SYS   Ballard Technology's Universal WDM Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          L13W32.INF   Plug-and-play INF file
          L13W32.REG   Windows NT Registry file
          L13W32.DLL   WIN32 dynamic-link library

          README95.TXT  Install instructions for Windows 95
          README98.TXT  Install instructions for Windows 98
          READMEME.TXT  Install instructions for Windows ME
          READMENT.TXT  Install instructions for Windows NT
          README2K.TXT  Install instructions for Windows 2000
          READMEXP.TXT  Install instructions for Windows XP
          READMEVS.TXT  Install instructions for Windows Vista and above

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file L13W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     AUTOMATIC INSTALLATION

          The LP1553-3 and LC1553-3 are Plug-and-Play
          devices.  The first time Windows XP boots with
          the LP1553-3 installed in a PCI slot or the
          LC1553-3 installed in a cPCI slot, the card is
          detected and the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          2.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          3.  Insert the media containing the Lx1553-3
              installation files into the floppy or CD-ROM
              drive.

          4.  In the edit box, type the path to the folder
              containing the driver files for the LX1553-3
              (D:\LX1553-3\DRIVERS for CD installation).
              Browse for the folder if needed.  When the path
              is entered, click 'OK'.

          5.  Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     MANUAL INSTALLATION

          If Windows XP does not prompt for the LP1553-3 or
          LC1553-3 drivers, and the drivers are not yet
          installed, a manual installation of the drivers is
          required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Install the LP1553-3 in a PCI slot or LC1553-3 in
              a cPCI slot and turn power on to the computer.

          2.  Run the 'System' applet in the Control Panel.

          3.  Select the 'Hardware' tab and click the 'Device
              Manager' button.

          4.  Expand the 'Other devices' tree item and double
              click the Lx1553-3 device.

          5.  Click the "Reinstall Driver' button to start
              the 'Hardware Update Wizard'.

          6.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          7.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          8.  Insert the media containing the Lx1553-3
              installation files into the floppy or CD-ROM
              drive.

          9.  In the edit box, type the path to the folder
              containing the driver files for the Lx1553-3
              (D:\LX1553-3\DRIVERS for CD
              installation).  Browse for the folder if
              needed.  When the path is entered, click 'OK'.

          10. Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your LP1553-3 or LC1553-3 by double-clicking the
          L13TST32.EXE program provided on this installation
          disk.  This program completes execution within
          several seconds.  If the program does not detect
          any faults with the interface or the LP1553-3 or
          LC1553-3 hardware, it displays the Card Number and
          a "passed" test message.  The LP1553-3 or LC1553-3
          is now ready to be connected to the MIL-STD-1553
          databus.

          If the L13TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the L13TST32.EXE
          utility.  Run it with the ? switch (i.e., L13TST32
          ?) to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Run the 'System' applet in the Control Panel.

          2.  Select the 'Hardware' tab and click the 'Device
              Manager' button.

          3.  Verify the 'Avionics Databus Interface' group
              is visible.

          4.  Expand the 'Avionics Databus Interface' group
              and verify the LP1553-3 or LC1553-3 device is
              present.

          5.  Double-click the LP1553-3 or LC1553-3 card to
              see the property page.

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
