

                INSTALLING THE PC708-1 DRIVER UNDER WINDOWS 95

                               July 14, 2000

                Copyright 1998-2000 by Ballard Technology, Inc.

                                Version 1.3


                                ------------


          This subdirectory contains the following files:

           File Name                Description

          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P71W95.REG   Windows 95 Registry file
          P71W32.DLL   WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P71W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     INSTALLATION

          P71W95.REG installs the required registry keys to
          operate the PC708-1 32-bit Driver.  To install,
          open the folder containing this file and double
          click on it.  Windows will update the required
          registry keys.

          Next, copy the following files into the
          C:\WINDOWS\SYSTEM folder:

               BTIUNIV.VXD
               BTIKRNL.DLL
               P71W32.DLL

          Finally, restart the computer to complete the
          PC708-1 driver installation.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the "Device Manager" tab.

          4.  Expand the "Avionics Databus Interface" group.

          5.  Double-click the PC708-1 card.

          6.  Verify the "Device Status" box does not report
              any errors.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your PC708-1 by double-clicking the P71TST32.EXE
          program provided on this installation disk.  This
          program completes execution within several seconds.
          If the program does not detect any faults with the
          interface or the PC708-1 hardware, it displays the
          card resources and a "passed" test message.  The
          PC708-1 is now ready to be connected to the
          ARINC 708 / ARINC 453 databuses.

          If the P71TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the P71TST32.EXE
          utility.  Run it with the ? switch (i.e., P71TST32
          ?) to view your options.  If you need further
          assistance, call Ballard Technology at (800)
          829-1553.  A customer support engineer will
          interpret the fault and guide you through
          corrective steps.



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
