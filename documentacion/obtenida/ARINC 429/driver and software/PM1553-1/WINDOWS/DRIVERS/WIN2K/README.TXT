


       INSTALLING THE UNIVERSAL DRIVER FOR THE PM1553-1 UNDER WINDOWS 2000

                               October 11, 2002

                  Copyright 2002 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIWDM.SYS   Ballard Technology's Universal WDM Driver
          BTIUNIV.VXD  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          PM11W2K.INF  Plug-and-play INF file

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file BTIKRNL.DLL is a dynamic-link library that
          controls Ballard Technology's Universal Driver.  It
          contains low-level functions that access all
          Ballard Technology hardware from WIN32
          applications.



     MANUAL INSTALLATION

          The PM1553-1 is not a Plug-and-Play device.  The
          Universal Driver must be manually installed before
          any WIN32 software can access the card.  The
          following steps must be performed for each PM1553-1
          card installed in the computer.

          To manually install the Universal Driver:

          1.  Install the PM1553-1 card as directed by the
              PM1553-1 User's Manual.

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

          10. Insert the media containing the PM1553-1
              installation files into the floppy or CD-ROM
              drive.

          11. In the 'Copy manufacturer's files from' field,
              type the path containing the driver files for
              the PM1553-1 (A:\DRIVERS\WIN2K for floppy disk
              installation).  Click 'OK'.

          12. Select the PM1553-1 from the 'Models' list and
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



     DEBUGGING GUIDELINES

          To verify that the Universal Driver is properly
          installed:

          1.  Click the 'Start' button, point to 'Settings'
              and click 'Control Panel'.

          2.  Double-click the 'System' icon.

          3.  Select the 'Hardware' tab.

          4.  Click the 'Device Manager' button.

          5.  Verify the 'Avionics Databus Interface' group
              is visible.

          6.  Expand the 'Avionics Databus Interface' group
              and verify the PM1553-1 device is visible.

          7.  Double-click on the PM1553-1 device to see the
              PM1553-1 property page.



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
