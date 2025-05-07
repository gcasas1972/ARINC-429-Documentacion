

             USING THE LP429-3 AND LC429-3 DRIVER API AND EXAMPLES

                              August 4, 2004

                Copyright 1998-2003 by Ballard Technology, Inc.

                                Version 2.0


                                ------------


          This folder contains the following files:

           File Name                Description

          <LABVIEW>     VI files for LabVIEW

          L43W32.LIB    WIN32 import library
          L43W32.H      C/C++ language include file
          L43W32VB.BAS  Visual Basic header file
          L43W32NET.VB  VB.NET header file
          L43W32NET.CS  C# header file
          L43W32BC.LIB  WIN32 import library for Borland tools

          EXAMP1.C     Example 1: Receiver example
          EXAMP1.EXE
          EXAMP2.C     Example 2: Transmitter example
          EXAMP2.EXE
          EXAMP3.C     Example 3: Sequential monitor example
          EXAMP3.EXE
          EXAMP4.C     Example 4: Explicit message timing example
          EXAMP4.EXE
          EXAMP5.C     Example 5: Transmit and receive list buffers example
          EXAMP5.EXE
          EXAMP6.C     Example 6: Asynchronous list buffer example
          EXAMP6.EXE
          EXAMP7.C     Example 7: File transfer example
          EXAMP7.DAT
          EXAMP7.EXE
          EXAMP8.C     Example 8: Receiver interrupt example
          EXAMP8.EXE
          EXAMP9.C     Example 9: Transmitter interrupt example
          EXAMP9.EXE
          EXAMP10.C    Example 10: Monitor to file example
          EXAMP10.EXE
          EXAMP11.C    Example 11: Receiver interrupt polling example
          EXAMP11.EXE
          EXAMP12.C    Example 12: ARINC 717 receiver example
          EXAMP12.EXE
          EXAMP13.C    Example 13: ARINC 717 transmitter example
          EXAMP13.EXE
          EXAMP14.C    Example 14: ARINC 717 SuperFrame data example
          EXAMP14.EXE
          EXAMP15.C    Example 15: ARINC 717 Sequential Record example
          EXAMP15.EXE
          EXAMP16.C    Example 16: BNR/BCD example
          EXAMP16.EXE

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The L43W32.H and L43W32.LIB files are the C/C++
          language header and import library for the LP429-3
          and LC429-3 Driver API.  With these files, the user
          can write applications that operate the LP429-3 PCI
          ARINC 429 card and the LC429-3 cPCI ARINC 429 card.
          The Driver API has been tested using the Microsoft
          Visual C++ Compiler Version 6.0 and the Borland C++
          Compiler Version 5.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          5.5.



     L43W32.H

          WIN32 applications written in the C or C++ language
          that use the LP429-3 and LC429-3 Driver API
          library must incorporate the header file L43W32.H
          using the #include preprocessor directive.
          Assuming the header file is in the current working
          directory or in the INCLUDE path, the following
          line must be added to the top of the application's
          source file:

          #include "L43W32.H"



     L43W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the LP429-3 and LC429-3 Driver
          API by adding L43W32VB.BAS to the Visual Basic
          project.  Once added to the project, Driver API
          functions can be called along with other
          user-defined functions.



     L43W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library L43W32.LIB.  Instead, Borland users should
          use L43W32BC.LIB.



     EXAMPLE PROGRAMS

          There are four examples discussed in the LP429-3
          and LC429-3 User's Manual.  These examples, and
          others, are provided both in C source code files
          and 32-bit console executable files.

          Refer to the comments in each example source file
          and to the discussion in the LP429-3 and LC429-3
          User's Manual.  The section number of each example
          is shown below:

           FILE                   TITLE                              SECTION
          -------------------------------------------------------------------
          EXAMP1.C  Receiver example                                   3.4
          EXAMP2.C  Transmitter example                                3.5
          EXAMP3.C  Sequential monitor example                         3.6
          EXAMP4.C  Explicit message timing example                    4.4
          EXAMP5.C  Transmit and receive list buffers example
          EXAMP6.C  Asynchronous list buffer example
          EXAMP7.C  File transfer example
          EXAMP8.C  Receiver interrupt example
          EXAMP9.C  Transmitter interrupt example
          EXAMP10.C Monitor to file example
          EXAMP11.C Receiver interrupt polling example
          EXAMP12.C ARINC 717 receiver example
          EXAMP13.C ARINC 717 transmitter example
          EXAMP14.C ARINC 717 SuperFrame data example
          EXAMP15.C ARINC 717 Sequential Record example

          The C source code is written for Visual C++
          Version 6.0.



     FUNCTION OVERVIEW

          All functions are described in detail in Appendix A
          of the LP429-3 and LC429-3 User's Manual.



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
