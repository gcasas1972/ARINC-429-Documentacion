

                INSTALLING THE PC1553-3 DRIVER UNDER WINDOWS 98

                             February 20, 1998

                Copyright 1995-1998 by Ballard Technology, Inc.

                                Version 1.4


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P13W98.REG   Registry file
          P13W32.DLL   PC1553-3 WIN32 dynamic link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P13W32.DLL is a dynamic-link library
          containing the PC1553-3 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 4.0, Microsoft Visual C++ Compiler Version
          5.0, and Microsoft Visual C++ Compiler Version 6.0.



     MANUAL INSTALLATION

          The PC1553-3 is not a Plug-and-Play device.  The
          drivers must be manually installed before any
          software can access the card.

          To manually install the drivers:

          1.  Open this folder and double click on the
              following file to update the required registry
              keys.

                   P13W98.REG

          2.  Copy the following files into the
              C:\WINDOWS\SYSTEM folder:

                   BTIUNIV.VXD
                   BTIKRNL.DLL
                   P13W32.DLL

          3.  Restart the computer.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your PC1553-3 by double-clicking the P13TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the PC1553-3 hardware, it displays the
          Card Number and a "passed" test message.  The
          PC1553-3 is now ready to be connected to the
          MIL-STD-1553 databus.

          If the P13TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the P13TST32.EXE
          utility.  Run it with the ? switch (i.e., P13TST32 ?)
          to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



     CHANGING THE RESOURCE ASSIGNMENTS

          To change the resources assigned to the PC1553-3:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the 'Hardware' tab.

          4.  Click the 'Device Manager' button.

          5.  Verify the 'Avionics Databus Interface' group
              is visible.

          6.  Expand the 'Avionics Databus Interface' group
              and verify the PC1553-3 device is visible.

          7.  Double-click on the PC1553-3 device to see the
              PC1553-3 property page.

          8.  Select the 'Resources' tab.

          9.  Double click the resource type to change.  If a
              resource assignment is locked, change the
              'Setting based on' configuration to a
              configuration that allows the resources to be
              edited.



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
