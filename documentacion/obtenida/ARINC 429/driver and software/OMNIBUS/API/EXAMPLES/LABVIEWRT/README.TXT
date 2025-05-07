

                     BTI DRIVER LABVIEW Real-Time DRIVERS

                                May 18, 2011

                Copyright 2009-2011 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIVI.DLL     BTIDriver VI LabVIEW RT shared library
          BTICARD.DLL   BTIDriver Card LabVIEW RT shared library
          BTI1553.DLL   BTIDriver MIL-STD-1553 LabVIEW RT shared library
          BTI422.DLL    BTIDriver ARINC 422 LabVIEW RT shared library
          BTI429.DLL    BTIDriver ARINC 429 LabVIEW RT shared library
          BTI708.DLL    BTIDriver ARINC 708 LabVIEW RT shared library
          BTI717.DLL    BTIDriver ARINC 717 LabVIEW RT shared library
          BTICSDB.DLL   BTIDriver CSDB LabVIEW RT shared library
          BTIDIO.DLL    BTIDriver DIO LabVIEW RT shared library
          PCI4G.INF     NI Visa INF file
          PCI4G.INI     NI Visa Module Description file
          PCI4G.CAT     Catalog file
          README.TXT    This document



     INTRODUCTION

          The *.DLL files are LabVIEW Real-Time shared
          libraries that allow LabVIEW Real-Time applications
          to operate a BTIDriver compliant device.



     INSTALLATION

          FTP all files in this folder, except for this
          README.TXT, to the target system.  The files should
          be coped to the ni-rt/system directory on the
          target system.



     INSTALLING THE VIs

          The LabVIEW VIs for operating BTIDriver compliant
          devices are not located in this folder.  They are
          located in the <LABVIEW> folder.  Refer to the
          README.TXT in the <LABVIEW> folder for information
          on installing the BTIDriver VIs on the host system.

          Note: LabVIEW VIs that run BTIDriver compliant
          devices on Windows can also run BTIDriver compliant
          devices on target systems running LabVIEW Real-Time.



     INTERRUPTS

          Interrupts have not been enabled on the shared libraries
          for LabVIEW Real-Time.  Please contact Ballard Technology
          for information on future implementation of interrupts.



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
