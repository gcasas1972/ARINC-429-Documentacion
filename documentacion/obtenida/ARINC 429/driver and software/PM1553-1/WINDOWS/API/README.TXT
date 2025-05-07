

                    USING THE PM1553-1 API AND EXAMPLES

                             September 30, 2008

                 Copyright 2002-2006 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

          File Name                Description

          BTIKRNL.LIB  Library for calling kernel drivers
          PM11.H       C/C++ language include file
          PM11.C       C/C++ language source file

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The PM11.C and PM11.H files are the C/C++ language
          header and source files for the PM1553-1 API.
          These file contain utility functions that the user
          can incorporate into applications to operate the
          PM1553-1 PC/104 MIL-STD-1553 card.

          To use these files, the PM11.H file must be
          included in the user's source code using the
          #include directive, and the BTIKRNL.LIB and PM11.C
          files must be compiled and linked with the user's
          application.

          Refer to the comments in each source file for an
          explanation of the utility functions.



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
