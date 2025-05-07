

          INSTALLING THE BUSBox DRIVER UNDER WINDOWS VISTA AND ABOVE

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
          needed for operating the BUSBox from a host
          computer.  If you want to communicate with the
          BUSBox via a USB port, follow the instructions in
          the "AUTOMATIC" installation section.  Otherwise,
          if you want to use the BUSBox in the RS-232 mode,
          follow the instructions in the "RS-232"
          installation section.



     AUTOMATIC INSTALLATION

          The BUSBox is a Plug-and-Play device.  The first
          time the BUSBox is plugged into a USB port and
          powered on, the device is detected and the driver
          installation process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Locate and install driver software'
              option.

          2.  Insert this disk into the floppy or CD-ROM
              drive and click 'Next'.  It will begin searching
              for the drivers.

          3.  Select 'Install' to approve installation
              of the driver.

          4.  Wait for the wizard to copy the files.  Click
              'Close' when the installation is complete.



     TESTING THE INSTALLATION

          Please refer to the README.TXT file in the <TEST>
          folder of the BUSBox distribution media for
          information on testing the installation.



     CARD NUMBER ASSIGNMENTS

          Each installed BUSBox device is assigned a unique
          Card Number to distinguish it from the other BUSBox
          devices.  In Windows XP, the Card Number is
          associated with the USB port that the BUSBox was
          plugged into when installed.  Any BUSBox plugged
          into this USB port will be assigned this Card
          Number.  This Card Number can be changed in the
          Device Manager.

          If you plug the BUSBox into a different USB port on
          your computer, the system will install the BUSBox
          on that new port and assign a new Card Number for
          it.

          To change the Card Number assignment for Windows XP:

          1.  Connect the BUSBox to a USB port on your
              computer and turn power on to the BUSBox.

          2.  Run the 'Device Manager' applet in the Control
              Panel.  It may be in the 'System and Maintenance'
              category.

          3.  Verify the 'Avionics Databus Interface' group
              is visible.

          4.  Expand the 'Avionics Databus Interface' group
              and verify the BUSBox device is visible.

          5.  Double-click on the BUSBox device to see the
              BUSBox property page.

          6.  Select the Ballard property page tab.

          7.  Change the Card Number assignment to a new
              number.  Click 'OK'.



     RS-232 INSTALLATION

          The RS-232 driver is not a kernel mode driver,
          and therefore will not display the BUSBox in the
          Device Manager.

          To install the RS-232 driver:

          1.  Copy the following files to the
              C:\WINNT\SYSTEM32 or C:\WINDOWS\SYSTEM32
              folder:

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
