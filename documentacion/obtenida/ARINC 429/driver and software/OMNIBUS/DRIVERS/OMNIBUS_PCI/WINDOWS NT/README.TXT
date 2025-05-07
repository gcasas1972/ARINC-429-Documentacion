

             INSTALLING THE OmniBus PCI DRIVER UNDER WINDOWS NT

                               March 22, 2013

                Copyright 2009-2013 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTI1553.DLL    MIL-STD-1553 dynamic-link library
          BTI422.DLL     RS-422 dynamic-link library
          BTI429.DLL     ARINC 429 dynamic-link library
          BTI708.DLL     ARINC 708 dynamic-link library
          BTI717.DLL     ARINC 717 dynamic-link library
          BTICARD.DLL    Card dynamic-link library
          BTICSDB.DLL    CSDB dynamic-link library
          BTIDIO.DLL     DIO dynamic-link library
          BTIRPC.DLL     RPC Driver
          BTIKRNL.DLL    Kernel level Driver
          PCI4GWNT.REG   Windows NT Registry file
          BTIUNIV.SYS    Universal Device Driver

          <bticard_test> Test project

          README.TXT     Install instructions for Windows NT

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This file describes how to install the driver files
          needed for operating the OmniBus PCI on a Windows
          NT 4.0 system.



    MANUAL INSTALLATION

          Windows NT 4.0 is not a Plug-and-Play operating
          system, so the Omnibus PCI drivers must
          be manually installed.

          To manually install the drivers:

          1.  Open this folder on the driver disk and
              double-click the PCI4GWNT.REG file.  Windows will
              update the required registry keys.

          2.  Copy the following files from this folder into
              the C:\WINNT\SYSTEM32 folder:

                   BTI1553.DLL
                   BTI422.DLL
                   BTI429.DLL
                   BTI708.DLL
                   BTI717.DLL
                   BTICARD.DLL
                   BTICSDB.DLL
                   BTIDIO.DLL
                   BTIRPC.DLL
                   BTIKRNL.DLL

          3.  Copy the following file from this folder into
              the C:\WINNT\SYSTEM32\DRIVERS folder:

                   BTIUNIV.SYS

          4.  Restart the computer.



     TESTING THE INSTALLATION AND ASSIGNING CARD NUMBERS

          Please run bticard_test in the BTICARD C examples
          in the <API> folder of the OmniBus PCI distribution
          media.  This example will test the installation of
          the OmniBus PCI card.



     INSTALLING MULTIPLE OmniBus PCI CARDS

          The OmniBus PCI driver for Windows NT can
          operate multiple cards in the system.  Each card
          is automatically assigned a card number starting
          at 0.  The first card is assigned card number 0,
          the second card is assigned card number 1, etc.

          The method of assigning card numbers is dependent
          upon the particular system.  PCI slots have an
          inherent order.  This is the order the card
          numbers are assigned.



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
