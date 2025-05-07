

          INSTALLING THE OmniBusBox DRIVER UNDER WINDOWS VISTA AND ABOVE

                               March 22, 2013

                Copyright 2001-2013 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          SETUP.EXE      Installer program for OmniBusBox Drivers
          SETUP.INI
          INSTMSIA.EXE   Windows Installer files
          INSTMSIW.EXE
          OMNIBUSBOX.MSI
          OMNIBUSBOX.INF USB installation files
          RNDISMPY.SYS   RNDIS installation files
          USB8023Y.SYS

          BTI1553.DLL    MIL-STD-1553 32-bit dynamic-link library
          BTI155364.DLL  MIL-STD-1553 64-bit dynamic-link library
          BTI422.DLL     RS-422 32-bit dynamic-link library
          BTI42264.DLL   RS-422 64-bit dynamic-link library
          BTI429.DLL     ARINC 429 32-bit dynamic-link library
          BTI42964.DLL   ARINC 429 64-bit dynamic-link library
          BTI708.DLL     ARINC 708 32-bit dynamic-link library
          BTI70864.DLL   ARINC 708 64-bit dynamic-link library
          BTI717.DLL     ARINC 717 32-bit dynamic-link library
          BTI71764.DLL   ARINC 717 64-bit dynamic-link library
          BTICARD.DLL    Card 32-bit dynamic-link library
          BTICARD64.DLL  Card 64-bit dynamic-link library
          BTICSDB.DLL    CSDB 32-bit dynamic-link library
          BTICSDB64.DLL  CSDB 64-bit dynamic-link library
          BTIDIO.DLL     DIO 32-bit dynamic-link library
          BTIDIO64.DLL   DIO 64-bit dynamic-link library
          BTIKRNL.DLL    Kernel level 32-bit Driver
          BTIKRNL64.DLL  Kernel level 64-bit Driver
          BTIRPC.DLL     RPC 32-bit Driver
          BTIRPC64.DLL   RPC 64-bit Driver
          BTIPROP.DLL    Property Page Driver
          BTITST32.EXE   Ballard Technology 32-bit Diagnostic program

          README2K.TXT  Install instructions for Windows 2000
          READMEXP.TXT  Install instructions for Windows XP
          READMEVS.TXT  Install instructions for Windows Vista and above

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The OmniBusBox is a device that allows the user to
          communicate with multiple avionics databuses.
          These avionics databus interfaces include
          MIL-STD-1553, ARINC 429, ARINC 717, and ARINC 708.
          The folder listed above contains the drivers and
          setup program for using the OmniBusBox from a user
          application.

          Please perform the following steps.

          1.  Run the installation program SETUP.EXE in this
              folder.  The program will install the
              high-level driver files and the BTITST32 test
              program.

          2.  If the OmniBusBox is to be operated as an
              Ethernet device, connect the OmniBusBox to your
              network as described in the OmniBusBox User's
              Manual and perform the steps in the "ASSIGNING
              CARD NUMBERS" section below.

          3.  If the OmniBusBox is to be operated over a USB
              port, connect the device as described in the
              OmniBusBox User's Manual and perform the steps
              in the "AUTOMATIC USB INSTALLATION" section
              below.



     AUTOMATIC USB INSTALLATION

          The OmniBusBox is detected as a Plug-and-Play
          device when installed on a USB port.  The first
          time the OmniBusBox is plugged in and powered on,
          the device is detected and the driver installation
          process begins automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Locate and install driver software'
              option.

          2.  Insert this disk into the disk drive of the
              computer and click 'Next'.  It will begin
              searching for the drivers.

          3.  Select 'Install' to approve installation
              of the driver.

          4.  Wait for the wizard to copy the files.  Click
              'Close' when the installation is complete.

          5.  Perform the steps in the "ASSIGNING CARD
              NUMBERS" section below.

          6.  Go to the <API> folder to copy the headers and
              libraries for writing applications to operate
              the OmniBusBox, and the example programs that
              exercise the various features of the
              OmniBusBox.



     ASSIGNING CARD NUMBERS

          OmniBusBox devices are addressed using card numbers
          assigned by the user.  When an OmniBusBox is first
          installed, there is no card number assigned to the
          device.  You must assign a card number in BTITST32.

          From the Start menu, run the BTITST32 program in
          the OmniBusBox program group.  Expand the
          Unassigned Network Devices node and right-click the
          OmniBusBox in the tree to display the card's
          context menu.  Select the Change Card Number
          command to display the Change Card Number dialog.
          Enter the desired card number in the edit box.

          If you need assistance, please call Ballard
          Technology at the number listed at the end of this
          document.



     DISTINGUISHING BETWEEN CARDS

          When two of the same type of cards are installed in
          the computer it can be difficult to determine which
          card is which.  The BTITST32 program can set and
          clear the card's LED (if availible) to distinguish
          it from the other cards.  To set/clear the LED,
          right-click on the card object in the left most
          column.  Then select the 'LED' option from the
          pop-up menu.  Repeat this operation for each card
          in your system to uniquely identify each card.



     TESTING THE INSTALLATION

          BTITST32 also performs diagnostic tests on devices
          installed in the computer or over a network.  It
          verifies that the devices are properly installed
          and do not conflict with other devices.  It also
          tests each core on the device to verify basic
          functionality.

          To run the diagnostic tests, go to the Start menu
          and run the BTITST32 program in the OmniBusBox
          program group.  Click the Run Tests button.

          Test results and other information for each device
          and core can be viewed by clicking on each device
          and core object in the tree window.

          If you need assistance, please call Ballard
          Technology at the number listed at the end of this
          document.



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
