

                   USING THE PM429-1 16-BIT TEST UTILITY

                              October 31, 2001

                  Copyright 2001 by Ballard Technology, Inc.

                                Version 1.0


                                ------------


          This folder contains the following files:

          File Name                Description

          PM41TEST.C      PM429-1 Diagnostic program C source
          PM41TEST.EXE    PM429-1 16-bit Diagnostic program
          README.TXT      This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The program PM41TEST.EXE is a 16-bit DOS program
          that simplifies the installation of the PM429-1.



     PM41TEST.EXE

          PM41TEST.EXE performs diagnostic tests on the
          PM429-1.  It verifies that the PM429-1 is
          properly installed and accessible.  The
          installation procedure is described in
          Section 2.0 of the PM429-1 User's Manual.  To
          run the diagnostic tests, enter the following
          command line:

               PM41TEST <iobase> <irq>

          The optional iobase parameter specifies the I/O
          base address of the card in hexadecimal.  If not
          specified, the value of 2C0H is used.

          The optional irq parameter specifies the IRQ value
          of the card in decimal.  If not specified, the
          value of 0 is used, which disables testing of
          interrupts.

          The source for the program is included.  It uses
          the PM41.H and PM41UTIL.C files located in the API
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
