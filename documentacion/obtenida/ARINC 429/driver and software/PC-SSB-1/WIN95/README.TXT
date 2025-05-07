

                      USING THE PC-SSB-1 WINDOWS 95 DRIVER

                              December 31, 1999

                   Copyright 1999 by Ballard Technology, Inc.

                                Version 1.0


                                ------------


          This directory contains the following files:

           File Name                Description

          BTIUNIV.VXD	  Ballard Technology's Universal Device Driver.
          BTIKRNL.DLL	  Ballard Technology's Kernel Driver.
          PS1W32.DLL	  PC-SSB-1 WIN32 dynamic-link library.
          PS1W95.REG	  Registry file

          PS1W32.H        Include file.
          PS1W32VB.BAS    Visual Basic header file.
          PS1W32.LIB	  Visual C++ WIN32 import library.
          PS1W32BC.LIB	  Borland C++ WIN32 import library.
          OVERVIEW.TXT    Overview of driver functions.
          DEMOTX.C        Transmit demonstration C source code.
          DEMORV.C        Receive demonstration C source code.
          DEMOTX.EXE      Transmit demonstration program.
          DEMORV.EXE      Receive demonstration program.

          README.TXT      This document.

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The file PS1W32.DLL is a dynamic-link library
          containing the PS-SSB-1 driver functions callable
          from WIN32 applications.  It has been tested using
          the Microsoft Visual C++ Compiler Version 6.0.



     INSTALLATION

          PS1W95.REG installs the required registry keys to
          operate the PC-SSB-1 32-bit Driver.  To install,
          this file double click on it.  Windows will update
          the required registry keys.

          Next, copy the following files into the
          C:\WINDOWS\SYSTEM folder:

               BTIUNIV.VXD
               BTIKRNL.DLL
               PS1W32.DLL

          Finally, restart the computer and test the card by
          running the demo program DEMOTX.EXE located on this
          disk.

          To verify installation of the driver, run the
          System applet in the Control Panel.  Select the
          Device Manager and verify the Avionics Databus
          Interface group is visible.  Expand the Avionics
          Databus Interface group and verify that the
          PC-SSB-1 device is visible.  Double-click on the
          PC-SSB-1 device to see the PC-SSB-1 property page.



     PS1W32.H

          Applications using the PC-SSB-1 Driver must
          incorporate the header file PS1W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory,
          the following line must be added to the top of the
          application's source file:

          #include "ps1w32.h"



     PS1W32.LIB AND PS1W32BC.LIB

          The file PS1W32.LIB is the import library for the
          PC-SSB-1 WIN32 Driver usable by Microsoft Visual
          C++.  For users of Borland C++, use the import
          library PS1W32BC.LIB.



     EXAMPLE PROGRAMS DEMOTX.C & DEMORV.C

          The source files for the example application in
          Section 5 of the PC-SSB-1 manual are provided.  The
          files with the base name DEMOTX.* demonstrate a
          transmit example, and the files with the base name
          DEMORV.* demonstrate a receive example.

          To run these example applications, a PC-SSB-1 card
          must be installed in the computer and must be
          connected to a data bus as described in Section 2
          in the PC-SSB-1 manual.  An RT must be connected to
          the data bus to run the receive example.

          When the demonstration programs are executed, each
          will initiate a message transfer and then display
          the results.

          NOTE: The PC-SSB-1 WIN32 driver requires a call to
          the SSBT_CardOpen() function, instead of a call to
          the SSBT_SelectHW() function as required by the DOS
          version of the PC-SSB-1 driver.  The handle value
          returned by SSBT_CardOpen() is a required parameter
          for most of the driver funtions.  Refer to the file
          OVERVIEW.TXT for information on all of the driver
          functions.



     FUNCTION OVERVIEW

          Each function in the PC-SSB-1 WIN32 Driver are
          described in the file OVERVIEW.TXT.

          If you need assistance, please call Ballard
          Technology at the number listed at the end of this
          document.



     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION

          There is no additional information.


                                ------------


          SAFETY WARNING: Ballard products are of commercial
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
