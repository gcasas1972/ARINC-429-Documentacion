

                  INSTALLING THE LX429-5 UNDER WINDOWS 2000

                               March 22, 2013

                Copyright 2008-2013 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTI1553.DLL   MIL-STD-1553 32-bit dynamic-link library
          BTI155364.DLL MIL-STD-1553 64-bit dynamic-link library
          BTI422.DLL    RS-422 32-bit dynamic-link library
          BTI42264.DLL  RS-422 64-bit dynamic-link library
          BTI429.DLL    ARINC 429 32-bit dynamic-link library
          BTI42964.DLL  ARINC 429 64-bit dynamic-link library
          BTI708.DLL    ARINC 708 32-bit dynamic-link library
          BTI70864.DLL  ARINC 708 64-bit dynamic-link library
          BTI717.DLL    ARINC 717 32-bit dynamic-link library
          BTI71764.DLL  ARINC 717 64-bit dynamic-link library
          BTICARD.DLL   Card 32-bit dynamic-link library
          BTICARD64.DLL Card 64-bit dynamic-link library
          BTICSDB.DLL   CSDB 32-bit dynamic-link library
          BTICSDB64.DLL CSDB 64-bit dynamic-link library
          BTIDIO.DLL    DIO 32-bit dynamic-link library
          BTIDIO64.DLL  DIO 64-bit dynamic-link library
          BTIKRNL.DLL   Kernel level 32-bit Driver
          BTIKRNL64.DLL Kernel level 64-bit Driver
          BTIRPC.DLL    RPC 32-bit Driver
          BTIRPC64.DLL  RPC 64-bit Driver
          BTIPROP.DLL   Property Page Provider
          LX4295.INF    Plug-and-play INF file
          LX4295.CAT    CAT file
          BTIWDM.SYS    Ballard Technology's Universal WDM Driver
          BTIWDM64.SYS  Ballard Technology's Universal 64-bit WDM Driver
          BTIUNIV.VXD   Universal Device Driver

          README95.TXT  Install instructions for Windows 95
          README98.TXT  Install instructions for Windows 98
          READMEME.TXT  Install instructions for Windows ME
          README2K.TXT  Install instructions for Windows 2000
          READMEXP.TXT  Install instructions for Windows XP
          READMEVS.TXT  Install instructions for Windows Vista and above

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This file describes how to install the driver files needed
          for operating the LX429-5 from a host computer.



     AUTOMATIC INSTALLATION

          The LP429-5 and LE429-5 are plug-and-play devices.  The
          first time Windows 2000 boots with the LP429-5 in a PCI
          slot, or the LE429-5 in a PCI Express slot, the card is
          detected and the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the 'Found New Hardware
              Wizard' starts.

          2.  Select the 'Search for a suitable driver for my
              device' option and click 'Next'.

          3.  Remove all check marks from all of the check
              boxes and check the 'Specify a location' check
              box.  Click 'Next'.

          4.  Insert the media containing the LX429-5
              installation files into the floppy or CD-ROM
              drive.

          5.  In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the LX429-5 (D:\LX429-5\DRIVERS for CD
              installation).  Click 'OK'.

          6.  When the drivers are found, click 'Next'.

          7.  Click 'Finish' to complete the installation
              process.



     MANUAL INSTALLATION

          If Windows 2000 does not prompt for the LX429-5
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Install the LP429-5 in a PCI slot, or the
              LE429-5 in a PCI Express slot and turn power
              on to the computer.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Select the 'Hardware' tab.

          5.  Click the 'Device Manager' button.

          6.  Expand the 'Other devices' tree item and double
              click the LX429-5 device.

          7.  Click the "Reinstall Driver' button to start
              the 'Update Device Driver Wizard'.

          8.  Click 'Next' when the 'Update Device Driver
              Wizard' starts.

          9.  Select the 'Search for better driver' option
              and click 'Next'.

          10. Remove all check marks from all of the check
              boxes.

          11. Check the 'Specify a location' check box.

          12. Insert the media containing the LX429-5
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          13. In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the LX429-5 (D:\LX429-5\DRIVERS for CD
              installation).  Click 'OK'.

          14. When the drivers are found, click 'Next'.

          15. Click 'Finish' to complete the installation
              process.



     TESTING THE INSTALLATION AND ASSIGNING CARD NUMBERS

          Please refer to the README.TXT file in the <TEST>
          folder of the LX429-5 distribution media for
          information on testing the installation and
          assigning card numbers.



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
