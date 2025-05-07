

               INSTALLING THE PC629-1 DRIVER UNDER WINDOWS NT 4.0

                                July 5, 2002

                Copyright 1999-2002 by Ballard Technology, Inc.

                                Version 1.1


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIUNIV.SYS  Ballard Technology's Universal Device Driver
          BTIKRNL.DLL  Ballard Technology's Kernel Driver
          P61W32.DLL   PC629-1 WIN32 dynamic-link library

          P61WNT0.REG  Registry file that does not call out an interrupt
          P61WNT1.REG  Registry file that calls out an interrupt

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file P61W32.DLL is a dynamic-link library
          containing the PC629-1 API Driver functions
          callable from WIN32 applications.  It has been
          tested using the Microsoft Visual C++ Compiler
          Version 4.0, Microsoft Visual C++ Compiler Version
          5.0, and Microsoft Visual C++ Compiler Version 6.0.



     INSTALLATION

          Both P61WNT0.REG and P61WNT1.REG install the
          required registry keys to operate the PC629-1
          32-bit Driver.  P61WNT0.REG configures the PC629-1
          with no interrupt allocated for the card, and
          P61WNT1.REG configures the PC629-1 with an
          interrupt.

          It is highly suggested that an interrupt NOT be
          allocated for the PC629-1 on the first install.
          Most Windows NT installations use a majority of the
          interrupts, requiring the user to manually assign
          an interrupt to the PC629-1.  The process for
          manually assigning resources is described in the
          next section.

          1)  To install required registry keys, open the
              folder containing the following file and double
              click on it.  Windows will update the required
              registry keys.

                   P61WNT0.REG

          2)  Copy the following files into the
              C:\WINNT\SYSTEM32 folder:

                   BTIKRNL.DLL
                   P61W32.DLL

          3)  Copy the following file into the
              C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4)  Restart the computer.



     START-UP PROBLEMS

          If a problem occurs starting the driver after
          restarting the computer, Windows NT displays a
          message indicating a service cannot be started.  To
          verify the PC629-1 driver is causing the problem,
          run the Event Viewer utility in the Administrative
          Tools group.  Any error messages from the driver
          will have a 'BTI' prefix.

          If a conflict with another device prevents the
          computer from restarting properly, the PC629-1
          driver can be started manually after the computer
          has booted.  Open the Devices applet in the Control
          Panel.  Select the 'Ballard Tech Universal Driver'
          device and click the 'Startup' button.  Change the
          'Startup Type' from Automatic to Manual.  Then
          reboot the computer.

          The next time the computer starts, the PC629-1
          driver will not be started.  To manually start the
          driver, return to the Devices applet, select the
          driver again, and click the 'Start' button.

          The most likely cause of start-up problems are
          resource conflicts with other devices in the
          computer.  Refer to the next section on how to
          change the resource assignments.



     CHANGING THE RESOURCE ASSIGNMENTS

          To modify the resources assigned to the PC629-1,
          run the Registry Editor program REGEDIT.EXE.  Then
          go to the following key:

          [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Ballard\Parameters\PC629-1]

          This key contains several value entries which
          specify hardware resources that the PC629-1
          requests from the operating system.  Since the
          PC629-1 is a legacy card, the registry entries
          must be manually configured to match the DIP switch
          settings on the card.  You may need to manually
          modify the following keys:

          MemoryBase
          IoBase
          IrqNumber

          Values should be chosen that do not overlap
          resource allocations of another devices.  To see
          the allocations for other devices, run the Windows
          NT Diagnostics program in the Administrative Tools
          folder.  Select the Resources tab to see the
          interrupt, I/O, and memory allocations.



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
