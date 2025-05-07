

            INSTALLING THE LP708-1 OR LC708-1 DRIVER UNDER WINDOWS NT

                              January 19, 2001

                Copyright 1999-2001 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          L71WNT.REG   Windows NT Registry file
          L71W32.DLL   WIN32 dynamic-link library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file L71W32.DLL is a dynamic-link library
          containing Driver functions callable from WIN32
          applications.



     MANUAL INSTALLATION

          Windows NT 4.0 is not a Plug-and-Play operating
          system, so the LP708-1 and LC708-1 drivers must
          be manually installed.

          To manually install the drivers:

          1.  Open this folder on the driver disk and
              double-click the L71WNT.REG file.  Windows will
              update the required registry keys.

          2.  Copy the following files from this folder into
              the C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL
                   L71W32.DLL

          3.  Copy the following file from this folder into
              the C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4.  Restart the computer.



     TROUBLESHOOTING

          To verify installation of the driver, follow these
          steps:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'Devices' icon.

          3.  Scroll down the Devices list and verify that
              the status of the 'Ballard Tech Universal'
              driver is shown as 'Started'.

          If the driver is not started, then an error
          occurred loading the driver.  To see the error
          messages, follow these steps:

          1.  Click the 'Start' button, open the 'Programs'
              group, open the 'Administrative Toos' group,
              and click 'Event Viewer'.

          2.  Open the 'Log' menu and verify 'System' is
              selected.

          3.  Starting at the top of the list, double-click
              each entry tagged with a red X.  Any error
              messages from the Ballard Tech Universal driver
              will have the prefix BTI listed.



     TESTING THE INSTALLATION

          You can test the installation and functionality of
          your LP708-1 or LC708-1 by double-clicking the
          L71TST32.EXE program provided on this installation
          disk.  This program completes execution within
          several seconds.  If the program does not detect
          any faults with the interface or the LP708-1 or
          LC708-1 hardware, it displays the Card Number and
          a "passed" test message.  The LP708-1 or LC708-1
          is now ready to be connected to the ARINC 708
          databuses.

          If the L71TST32.EXE test detects a fault, it
          displays relevant fault information.  When the
          fault message displays, follow the instructions on
          screen.

          Other useful information such as the board model,
          channel configuration, memory size and firmware
          version can be determined through the L71TST32.EXE
          utility.  Run it with the ? switch (i.e., L71TST32
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
