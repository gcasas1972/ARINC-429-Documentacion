

                INSTALLING THE BUSBox DRIVER UNDER WINDOWS 98

                               March 22, 2013

                Copyright 2001-2013 by Ballard Technology, Inc.


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
          BTISERIAL.DLL Serial Port Driver
          BUSBOX.INF    Plug-and-play INF file
          BUSBOX.CAT    CAT file
          BTIUSB.SYS    USB WDM 32-bit Driver
          BTIUSB64.SYS  USB WDM 64-bit Driver
          WDMSTUB.SYS   Windows 98/ME WDM Stub Driver

          README98.TXT  Install instructions for Windows 98
          READMEME.TXT  Install instructions for Windows ME
          README2K.TXT  Install instructions for Windows 2000
          READMEXP.TXT  Install instructions for Windows XP
          READMEVS.TXT  Install instructions for Windows Vista and above

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This file describes how to install the driver files
          needed for operating the BUSBox from a host computer.
          If you want to communicate with the BUSBox via a USB
          port, follow the instructions in the "AUTOMATIC" or
          "MANUAL" installation sections.  Otherwise, if you
          want to use the BUSBox in the RS-232 mode, follow the
          instructions in the "RS-232" installation section.



     AUTOMATIC INSTALLATION

          The BUSBox is a Plug-and-Play device.  The first
          time the BUSBox is plugged into a USB port and
          powered on, the device is detected and the driver
          installation process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Click 'Next' when the 'Add New Hardware Wizard'
              starts.

          2.  Select the 'Search for the best driver for your
              device' option and click 'Next'.

          3.  Remove all check marks from all of the check
              boxes.

          4.  Check the 'Specify a location' check box and
              type the path containing the driver files for
              the BUSBox (e.g.  D:\BUSBox\DRIVERS for CD
              installation).

          5.  Insert the media containing the BUSBox
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          6.  Select 'The updated driver' option and click
              'Next'.

          7.  Click 'Next' again to begin the installation
              process.

          8.  Click 'Finish' to complete the installation
              process.



     MANUAL INSTALLATION

          If Windows 98 does not prompt for the BUSBox
          drivers, and the drivers are not yet installed, a
          manual installation of the drivers is required.

          A manual installation may also be required if a
          previous installation failed, or the drivers need
          reinstallation.

          To manually install the drivers:

          1.  Connect the BUSBox to a USB port on your
              computer and turn power on to the BUSBox.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'System' icon.

          4.  Expand the 'Other devices' tree item and double
              click the BUSBox device.

          5.  Click the "Reinstall Driver' button to start
              the 'Update Device Driver Wizard'.

          6.  Click 'Next' when the 'Update Device Driver
              Wizard' starts.

          7.  Select the 'Search for better driver' option
              and click 'Next'.

          8.  Remove all check marks from all of the check
              boxes.

          9.  Check the 'Specify a location' check box and
              type the path containing the driver files for
              the BUSBox (e.g.  D:\BUSBox\DRIVERS for CD
              installation).

          10. Insert the media containing the BUSBox
              installation files into the floppy or CD-ROM
              drive and click 'Next'.

          11. Select 'The updated driver' option and click
              'Next'.

          12. Click 'Next' again to begin the installation
              process.

          13. Click 'Finish' to complete the installation
              process.



     TESTING THE INSTALLATION

          Please refer to the README.TXT file in the <TEST>
          folder of the BUSBox distribution media for
          information on testing the installation.



     CARD NUMBER ASSIGNMENTS

          Each installed BUSBox device is assigned a unique
          Card Number to distinguish it from the other BUSBox
          devices.  In Windows 98, the Card Number is assigned
          by order of insertion / power on.  If you have only
          one BUSBox turned on and plugged in to your system,
          then it is assigned Card Number zero.  If you have
          multiple BUSBoxes connected to your system, then the
          order in which you turn on and plug them into the
          computer will determine the Card Number assignments.
          The assignments start are incrementing, starting at
          zero.



     RS-232 INSTALLATION

          The RS-232 driver is not a kernel mode driver,
          and therefore will not display the BUSBox in the
          Device Manager.

          To install the RS-232 driver:

          1.  Copy the following files to the
              C:\WINDOWS\SYSTEM folder:

              BTI1553.DLL
              BTI429.DLL
              BTI717.DLL
              BTICARD.DLL
              BTICSDB.DLL
              BTIKRNL.DLL
              BTISERIAL.DLL

          2.  Connect the BUSBox to a serial port on your
              computer using a straight through cable.

          3.  The correlation between the COM port number
              of your computer and the Card Number used
              in the CardOpen() function is:

              CardOpen() Card Number = COM Port - 1

              For example, the Card Number for COM1 is zero.



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
