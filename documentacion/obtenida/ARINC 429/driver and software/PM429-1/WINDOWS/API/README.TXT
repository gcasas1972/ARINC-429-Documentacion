

                  USING THE PM429-1 DRIVER API AND EXAMPLES

                            September 30, 2008

                Copyright 2001-2006 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This folder contains the following files:

          File Name                Description

          PM41UTIL.C   C/C++ language source file
          UTILASC.C    C/C++ language source file
          UTILBCD.C    C/C++ language source file
          UTILBIT.C    C/C++ language source file
          UTILBNR.C    C/C++ language source file
          UTILGET.C    C/C++ language source file
          UTILMANT.C   C/C++ language source file
          UTILMATH.C   C/C++ language source file
          UTILPUT.C    C/C++ language source file

          429UTIL.H    C/C++ language include file
          PM41.H       C/C++ language include file

          BTIKRNL.LIB  Universal Driver WIN32 import library

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The PM41UTIL.C and PM41.H files are the C/C++
          language header and source files for the PM429-1
          Driver API.  With these files, the user can write
          applications that operate the PM429-1 PC/104
          ARINC 429 card.  The Driver API has been tested
          using the Microsoft Visual C++ Compiler Version 6.0
          and the Borland C++ Compiler Version 5.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          5.5.


     429UTIL.H

          This file is internally used by PM41.H.  Applications
          for the PM429-1 Driver API do not need to explicitly
          include this file, but it must be available to the
          project.


     PM41.H

          Applications written in the C or C++ language
          that use the PM429-1 Driver API must
          incorporate the header file PM41.H using the
          #include preprocessor directive. Assuming the
          header file is in the current working directory
          or in the INCLUDE path, the following line must
          be added to the top of the application's
          source file:

          #include "PM41.H"


     PM41UTIL.C

          Applications written in the C or C++ language
          can access the PM429-1 Driver API by adding
          PM41UTIL.C to their project.  Once added to the
          project, Driver API functions can be called along
          with other user-defined functions.


     UTIL*.C

          This file is internally used by 429UTIL.H.  Applications
          for the PM429-1 Driver API do not need to explicitly
          include these files, but it must be available to the
          project.



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
