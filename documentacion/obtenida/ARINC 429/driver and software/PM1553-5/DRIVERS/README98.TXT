

                  INSTALLING THE PM1553-5 UNDER WINDOWS 98

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
          PM15.INF      Plug-and-play INF file
          PM15.CAT      CAT file
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

          This file describes how to install the driver files
          needed for operating the PM1553-5 from a host
          computer.



     AUTOMATIC INSTALLATION

          The LP1553-5 and LE1553-5 are plug-and-play
          devices.  The first time Windows 98 boots with the
          LP1553-5 in a PCI slot, or the LE1553-5 in a PCI
          Express slot, the card is detected and the driver
          installation process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Driver from disk provided by
              hardware manufacturer' option.

          2.  Click 'OK'.

          3.  Insert the PM1553-5 installation disk into
              the floppy or CD-ROM drive.

          4.  Type the path containing the driver files for
              the PM1553-5 (D:\PM1553-5\DRIVERS for CD
              installation) in the 'Copy manufacturer's files
              from' field.

          5.  Click OK to complete the installation process.



     MANUAL INSTALLATION

          If Windows 98 does not prompt for the PM1553-5
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'Add New Hardware' icon.

          3.  When the first 'Add New Hardware Wizard' window
              opens, click Next.

          5.  Select the 'No' option so Windows does not
              search for new hardware and click 'Next'.

          6.  Select the 'Other Devices' list box selection
              from the Hardware types list and click 'Next'.

          7.  Click the 'Have Disk' button and insert the
              media containing the PM1553-5 installation
              files (if the data is not located on the hard
              disk).

          8.  Type the path containing the driver files for
              the PM1553-5 (D:\PM1553-5\DRIVERS for CD
              installation) in the 'Copy manufacturer's files
              from' field of the 'Install From Disk' window.

          9.  Click 'OK' to return to the 'Add New Hardware
              Wizard'.

          10.  Select the PM1553-5 configuration that
               applies from the Models list box and click
               'Next'.

          11.  Click 'Next' to install drivers.

          12.  Click 'Finish' to complete driver installation.



     TESTING THE INSTALLATION AND ASSIGNING CARD NUMBERS

          Please refer to the README.TXT file in the <TEST>
          folder of the PM1553-5 distribution media for
          information on testing the installation and
          assigning card numbers.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the "Device Manager" tab.

          4.  Expand the "Avionics Databus Interface" group.

          5.  Double-click the PM1553-5 card.

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
