

                    INSTALLING THE Mx5 UNDER WINDOWS XP

                               March 22, 2013

               Copyright 2011-2013 by Ballard Technology, Inc.


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
          PCI5GV6.INF   Plug-and-play INF file
          PCI5GV6.CAT   CAT file
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
          needed for operating the Mx5 from a host
          computer.



     AUTOMATIC INSTALLATION

          The Mx5 family of products are a plug-and-play devices.
          The first time Windows XP boots with an Mx5 card in a
          PMC or XMC slot, the card is detected and the driver
          installation process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          2.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          3.  Insert the media containing the Mx5
              installation files into the floppy or CD-ROM
              drive.

          4.  In the edit box, type the path to the folder
              containing the driver files for the Mx5
              (D:\Mx5\DRIVERS for CD installation).
              Browse for the folder if needed.  When the
              path is entered, click 'OK'.

          5.  Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     MANUAL INSTALLATION

          If Windows XP does not prompt for the Mx5
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Install the Mx5 card into a PMC or XMC slot
              and turn power on to the computer.

          2.  Run the 'System' applet in the Control Panel.

          3.  Select the 'Hardware' tab and click the 'Device
              Manager' button.

          4.  Expand the 'Other devices' tree item and double
              click the Mx5 device.

          5.  Click the "Reinstall Driver' button to start
              the 'Hardware Update Wizard'.

          6.  Select the 'Install from a list or specific
              location' option and click 'Next'.

          7.  Remove the checkmark from 'Search removable media'
              and check 'Include this location in the search'.

          8.  Insert the media containing the Mx5
              installation files into the floppy or CD-ROM
              drive.

          9.  In the edit box, type the path to the folder
              containing the driver files for the Mx5
              (D:\MX5\DRIVERS for CD installation).
              Browse for the folder if needed.  When the
              path is entered, click 'OK'.

          10. Wait for the wizard to copy the files.  Click
              'Finish' when the installation is complete.



     TESTING THE INSTALLATION AND ASSIGNING CARD NUMBERS

          Please refer to the README.TXT file in the <TEST>
          folder of the Mx5 distribution media for
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
