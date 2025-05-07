

         INSTALLING THE OmniBus PMC DRIVER UNDER WINDOWS VISTA AND ABOVE

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
          PCI4G.INF     Plug-and-play INF file
          PCI4G.CAT     CAT file
          BTIWDM.SYS    Ballard Technology's Universal WDM Driver
          BTIWDM64.SYS  Ballard Technology's Universal 64-bit WDM Driver
          WDMSTUB.SYS   Windows 98/ME WDM Stub Driver
          BTIUNIV.VXD   Universal Device Driver

          README95.TXT  Install instructions for Windows 95
          README98.TXT  Install instructions for Windows 98
          READMEME.TXT  Install instructions for Windows ME
          README2K.TXT  Install instructions for Windows 2000
          READMEXP.TXT  Install instructions for Windows XP
          READMEVS.TXT  Install instructions for Windows Vista and above

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This file describes how to install the driver files
          needed for operating the OmniBus PMC from a host
          computer.



     AUTOMATIC INSTALLATION

          The OmniBus PMC is a plug-and-play device.  The
          first time Windows Vista boots with the OmniBus PMC
          installed in a PMC slot, the card is detected and
          the driver installation process begins
          automatically.

          When prompted to install the drivers, follow these
          steps:

          1.  Select the 'Locate and install driver software'
              option.

          2.  Insert the media containing the OmniBus PMC
              installation files into the floppy or CD-ROM
              drive and click 'Next'.  It will begin searching
              for the drivers.

          3.  Select 'Install' to approve installation
              of the driver.

          4.  Wait for the wizard to copy the files.  Click
              'Close' when the installation is complete.



     TESTING THE INSTALLATION AND ASSIGNING CARD NUMBERS

          Please refer to the README.TXT file in the <TEST>
          folder of the OmniBus PMC distribution media for
          information on testing the installation and
          assigning card numbers.



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
