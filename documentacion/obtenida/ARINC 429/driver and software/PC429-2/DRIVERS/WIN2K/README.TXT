

               INSTALLING THE PC429-1/2 DRIVER UNDER WINDOWS 2000

                               March 31, 1999

                Copyright 1997-1999 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIWDM.SYS   Ballard Technology's Universal WDM Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P42W2K.INF   Plug-and-play INF file
          P42W32.DLL   PC429-1/2 WIN32 dynamic link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P42W32.DLL is a dynamic-link library
          containing the PC429-1/2 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 4.0, Microsoft Visual C++ Compiler Version
          5.0, and Microsoft Visual C++ Compiler Version 6.0.



     MANUAL INSTALLATION

          The PC429-1/2 is not a Plug-and-Play device.  The
          drivers must be manually installed before any
          software can access the card.  The following steps
          must be performed for each PC429-1/2 card installed
          in the computer.

          To manually install the drivers:

          1.  Install the PC429-1/2 card as directed by the
              PC429-1/2 User's Manual.

          2.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          3.  Double-click the 'Add/Remove Hardware' icon.

          4.  Click 'Next' to start the 'Add/Remove Hardware
              Wizard'.

          5.  Select the 'Add/Troubleshoot a Device' option
              and click 'Next'.

          6.  Select 'Add a new device' from the list of
              devices and click 'Next'.

          7.  Select the 'No, I want to select the hardware
              from a list' option and click 'Next'.

          8.  Select 'Other devices' from the 'Hardware
              types' list and click 'Next'.

          9.  Click the 'Have Disk' button.

          10. Insert the media containing the PC429-1/2
              installation files into the floppy or CD-ROM
              drive.

          11. In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the PC429-1/2 (A:\DRIVERS\WIN2K for floppy disk
              installation).  Click 'OK'.

          12. Select the PC429-1/2 from the 'Models' list and
              click 'Next'.

          13. Click 'Next' to start the installation
              process.

          14. Click the 'Resources' button and manually
              change the resource assignments if a conflict
              is present.  If a resource is locked, change
              the 'Setting based on' selection to pick a
              configuration that can be manually changed.
              When the resources are properly assigned, click
              'OK'.

          15. Click the 'Finish' button to complete the
              installation.

          16. Shut down the computer and verify the DIP
              switch and jumper settings match the manual
              resource assignments.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your PC429-1/2 by double-clicking the P42TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the PC429-1/2 hardware, it displays the
          Card Number and a "passed" test message.  The
          PC429-1/2 is now ready to be connected to the
          ARINC 429 databus.

          If the P42TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the P42TST32.EXE
          utility.  Run it with the ? switch (i.e., P42TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     DEBUGGING GUIDELINES

          To verify that the PC429-1/2 drivers are properly
          installed:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the 'Hardware' tab.

          4.  Click the 'Device Manager' button.

          5.  Verify the 'Avionics Databus Interface' group
              is visible.

          6.  Expand the 'Avionics Databus Interface' group
              and verify the PC429-1/2 device is visible.

          7.  Double-click on the PC429-1/2 device to see the
              PC429-1/2 property page.



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
