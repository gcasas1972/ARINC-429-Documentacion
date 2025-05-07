

                 USING THE Lx-AFDX-1 DRIVER API AND EXAMPLES

                               March 23, 2007

                Copyright 2005-2007 by Ballard Technology, Inc.

                                Version 1.4


                                ------------


          This folder contains the following files:

           File Name                Description

          AX1W32.LIB    WIN32 import library
          AX1W32.H      C/C++ language include file
          AX1W32VB.BAS  Visual Basic header file
          AX1W32NET.VB  VB.NET header file
          AX1W32BC.LIB  WIN32 import library

          EXAMP1.C     Example 1: Receive example
          EXAMP1.EXE
          EXAMP2.C     Example 2: Transmit example - Sampling port
          EXAMP2.EXE
          EXAMP3.C     Example 3: Transmit example - Queueing port
          EXAMP3.EXE
          EXAMP4.C     Example 4: Monitor example
          EXAMP4.EXE
          EXAMP5.C     Example 5: Transmit with explicit timing example
          EXAMP5.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The AX1W32.H and AX1W32.LIB files are the C/C++
          language header and import library for the
          Lx-AFDX-1 Driver API.  With these files, the user
          can write applications that operate the Lx-AFDX-1
          PCI AFDX card, the LC-AFDX-1 cPCI AFDX card, or the
          LM-AFDX-1 PMC AFDX card.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0.



     AX1W32.H

          WIN32 applications written in the C or C++ language
          that use the Lx-AFDX-1 Driver API library must
          incorporate the header file AX1W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "AX1W32.H"



     EXAMPLE PROGRAMS

          There are five examples included with the Lx-AFDX-1
          Driver.  These examples are provided both in C
          source code files and 32-bit console executable
          files.

          Refer to the comments in each example source file
          and to the discussion in the Lx-AFDX-1 User's
          Manual.  The section number of each example is
          shown below:

           FILE                   TITLE
          ------------------------------------------------------
          EXAMP1.C  Receive example
          EXAMP2.C  Transmit example - Sampling port
          EXAMP3.C  Transmit example - Queueing port
          EXAMP4.C  Monitor example
          EXAMP5.C  Transmit with explicit timing example

          The C source code is written for Visual C++
          Version 6.0.



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
