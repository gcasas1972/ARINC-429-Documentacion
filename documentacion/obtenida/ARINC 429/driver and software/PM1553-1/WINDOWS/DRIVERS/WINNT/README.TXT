

     INSTALLING THE UNIVERSAL DRIVER FOR THE PM1553-1 UNDER WINDOWS NT 4.0

                               October 11, 2002

                  Copyright 2002 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

          File Name     Description
          BTIUNIV.SYS   Ballard Technology's Universal Device Driver
          BTIKRNL.DLL   Ballard Technology's Kernel Driver
          PM11WNT0.REG  Registry file that does not call out an interrupt
          PM11WNT1.REG  Registry file that calls out an interrupt

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file BTIKRNL.DLL is a dynamic-link library that
          controls Ballard Technology's Universal Driver.  It
          contains low-level functions that access all
          Ballard Technology hardware from WIN32
          applications.



     INSTALLATION

          Both PM11WNT0.REG and PM11WNT1.REG install the
          required registry keys that configure the Universal
          Driver to operate the PM1553-1.  PM11WNT0.REG
          configures the PM1553-1 with no interrupt allocated
          for the card, and PM11WNT1.REG configures the
          PM1553-1 with an interrupt.

          It is highly suggested that an interrupt NOT be
          allocated for the PM1553-1 on the first install.
          Most Windows NT installations use a majority of the
          interrupts, requiring the user to manually assign
          an interrupt to the PM1553-1.  The process for
          manually assigning resources is described in the
          next section.

          1.  Open this folder and double click on the
              following file to update the required registry
              keys.

                   PM11WNT0.REG

          2.  Copy the following files into the
              C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL

          3.  Copy the following file into the
              C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4.  Restart the computer.



     START-UP PROBLEMS

          If Windows NT displays a message indicating a
          service cannot be started, most likely the
          resources called out by the PM1553-1 device are
          conflicting with other devices in the computer.

          To see the resources being assigned to the
          PM1553-1, run the Registry Editor program
          REGEDIT.EXE.  Then go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ballard\Parameters\PM1553-1]

          This key contains several value entries which
          specify hardware resources that the PM1553-1
          requests from the operating system.  Since the
          PM1553-1 is a legacy card, the registry entries must
          be manually configured to match the DIP switch
          settings on the card.  You may need to manually
          modify the following keys:

          IrqNumber
          IoBase

          Values should be chosen that do not overlap
          resource allocations of another devices.  To see
          the allocations for other devices, run the Windows
          NT Diagnostics program in the Administrative Tools
          folder.  Select the Resources tab to see the
          interrupt and I/O allocations.



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
