

            BALLARD TECHNOLOGY DRIVERS, UTILITIES, APIs AND EXAMPLES

                               March 29, 2013
                             Version CD-WIN-027

                Copyright 1995-2013 by Ballard Technology, Inc.


                                ------------


          This folder contains the following subfolders:

          Folder Name               Description

          <AVIONICS BUSBOX>   Multi-Protocol ethernet interface box
          <BUSBox>            Multi-Protocol USB interface box
          <CM429-1>           ARINC 429 PCMCIA interface card
          <CM1553-1>          MIL-STD-1553 PCMCIA interface card (with UTMC SuMMIT)
          <CM1553-3>          MIL-STD-1553 PCMCIA interface card
          <Lx429-3>           ARINC 429 PCI/cPCI interface cards
          <Lx429-5>           ARINC 429 PCI/PCI Express interface cards
          <Lx708-1>           ARINC 708 PCI/cPCI interface cards
          <Lx1553-3>          MIL-STD-1553 PCI/cPCI interface cards
          <Lx1553-5>          MIL-STD-1553 PCI/PCI Express interface cards
          <Lx-AFDX-1>         AFDX PCI/cPCI/PMC interface card
          <Mx5>               Mx5 PMC/XMC interface card
          <OMNIBUS>           OmniBus interface products
          <PC429-2>           ARINC 429 PC ISA interface card
          <PC629-1>           ARINC 629 PC ISA interface card
          <PC708-1>           ARINC 708 PC ISA interface card
          <PC1553-3>          MIL-STD-1553 PC ISA interface card
          <PC-MDM-1>          Space Shuttle MDM PC ISA interface card
          <PC-SSB-1>          Space Shuttle MIA PC ISA interface card
          <PM429-1>           ARINC 429 PC/104 interface card
          <PM429-2>           ARINC 429/ARINC 717 PC/104+ interface card
          <PM1553-1>          MIL-STD-1553 PC/104 interface card
          <PM1553-5>          MIL-STD-1553 PC/104+ interface card
          <USB Adapter>       Multi-Protocol USB device

          <INSTALL32>         Driver installer for WIN32
          <INSTALL64>         Driver installer for WIN64

          LICENSED.TXT License agreement
          VERSIONS.TXT Version history
          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This disk contains the drivers, utilities, APIs and
          example programs for use with Ballard Technology's
          avionics test products.  To find the files for your
          product, open the corresponding folder, and review
          the README.TXT file in that folder.



     DRIVER INSTALLATION

          An automated installer application is provided to install
          Windows drivers for all products listed above.  Administrator
          privileges are needed to run the application.  The installer
          is located at:

          INSTALL32/INSTALL.EXE      32-bit Windows
          INSTALL64/INSTALL.EXE      64-bit Windows

          The application only installs the Windows drivers.  Other
          files, like examples, headers, and libraries, are located
          in the above folders.

          When run, the application will detect which products have
          been previously installed.  The drivers for these products
          will be selected, either to be installed for the first time,
          or to be upgraded.

          Drivers can also be preinstalled for hardware that has not
          yet been installed.  This adds the driver to the driver
          store.  The final installation will occur automatically when
          the hardware is installed, which can occur without
          administrator privileges.



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
