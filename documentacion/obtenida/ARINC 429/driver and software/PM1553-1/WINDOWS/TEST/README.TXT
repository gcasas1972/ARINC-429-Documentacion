

                   USING THE PM1553-1 16-BIT TEST UTILITY

                              October 11, 2002

                  Copyright 2002 by Ballard Technology, Inc.

                                Version 1.0


                                ------------


          This folder contains the following files:

          File Name                Description

          PM11TEST.C      PM1553-1 Diagnostic program C source
          PM11TEST.EXE    PM1553-1 32-bit WIN32 Diagnostic program
          README.TXT      This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The program PM11TEST.EXE is a 32-bit WIN32 program
          that simplifies the installation of the PM1553-1.



     PM11TEST.EXE

          PM11TEST.EXE performs diagnostic tests on the
          PM1553-1.  It verifies that the PM1553-1 is
          properly installed and accessible.  The
          installation procedure is described in Section 2.0
          of the PM1553-1 User's Manual.  To run the
          diagnostic tests, enter the following command line:

               PM11TEST <iobase> <irq>

          The optional iobase parameter specifies the I/O
          base address of the card in hexadecimal.  If not
          specified, the value of 2C0H is used.

          The optional irq parameter specifies the IRQ value
          of the card in decimal.  If not specified, the
          value of 0 is used, which disables testing of
          interrupts.

          The source for the program is included.  It uses
          the PM11.H and PM11.C files located in the API
          folder.

          If you need assistance, please call Ballard
          Technology at the number listed at the end of this
          document.



     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION


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
