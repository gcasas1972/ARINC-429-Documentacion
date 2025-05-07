

                  USING THE CM1553-1 DRIVER API AND EXAMPLES

                               April 9, 1999

                Copyright 1997,1999 by Ballard Technology, Inc.

                                Version 1.2


                                ------------


          This subdirectory contains the following files:

           File Name                Description

          C11W32.LIB    CM1553-1 WIN32 import library
          C11W32.H      Include file
          C11W32VB.BAS  Visual Basic header file
          C11W32NET.VB  VB.NET header file
          C11W32NET.CS  C# header file
          C11W32BC.LIB  CM1553-1 WIN32 import library for Borland tools

          EXAMP1.C      Example 1: BC transmission of one message one time
          EXAMP1.EXE
          EXAMP2.C      Example 2: BC periodic transmission of messages
          EXAMP2.EXE
          EXAMP3.C      Example 3: BC transmission of a message schedule
          EXAMP3.EXE
          EXAMP4.C      Example 4: RT mode
          EXAMP4.EXE
          EXAMP5.C      Example 5: Monitor
          EXAMP5.EXE
          EXAMP6.C      Example 6: BC transmission of conditional messages
          EXAMP6.EXE
          EXAMP7.C      Example 7: RT list buffering with Notice II enabled
          EXAMP7.EXE
          EXAMP8.C      Example 8: Continuous monitor mode
          EXAMP8.EXE
          EXAMP9.C      Example 9: Bus controller interrupts
          EXAMP9.EXE
          EXAMP10.C     Example 10: Bus controller polled interrupts
          EXAMP10.EXE

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The C11W32.H and C11W32.LIB files are the C/C++
          language header and import library for the CM1553-1
          Driver API.  With these files, the user can write
          applications that operate the CM1553-1 PCMCIA
          MIL-STD-1553 card.  The Driver API has been tested
          using the Microsoft Visual C++ Compiler Version
          6.0 and the Borland C++ Compiler Version
          4.5.

          The examples files are written in C and have been
          tested using the Microsoft Visual C++ Compiler
          Version 6.0 and the Borland C++ Compiler Version
          4.5.



     C11W32.H

          WIN32 applications written in the C or C++ language
          that use the CM1553-1 Driver API library must
          incorporate the header file C11W32.H using the
          #include preprocessor directive.  Assuming the
          header file is in the current working directory or
          in the INCLUDE path, the following line must be
          added to the top of the application's source file:

          #include "C11W32.H"



     WARNING ABOUT C11_OpenCard()

          The description of the function C11_OpenCard() in
          Appendix A of the CM1553-1 User's Manual is not
          correct for the WIN32 driver.  When the function
          fails, it DOES NOT return a negative value.
          Instead, under the WIN32 environment, C11_OpenCard()
          returns a NULL handle if the function fails.



     C11W32VB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the CM1553-1 Driver API by adding
          C11W32VB.BAS into the Visual Basic project.  Once
          added to the project, Driver API functions can be
          called along with other user-defined functions.



     C11W32BC.LIB

          C and C++ language applications developed with
          Borland tools cannot use the Microsoft import
          library C11W32.LIB.  Instead, Borland users should
          use C11W32BC.LIB.



     EXAMPLE PROGRAMS

          There are nine examples discussed in the CM1553-1
          User's Manual.  Seven of the nine examples are
          provided both in C source code files and 32-bit
          console executable files.

          Refer to the comments in each example source file
          and to the discussion in the CM1553-1 User's
          Manual.  The section number of each example is
          shown below:

           FILE                   TITLE                      SECTION
          ---------------------------------------------------------------
          EXAMP1.C  BC transmission of one message one time   3.2.1
          EXAMP2.C  BC periodic transmission of messages      3.2.2
          EXAMP3.C  BC transmission of a message schedule     3.2.3
          EXAMP4.C  RT mode                                   3.3.1
          EXAMP5.C  Monitor                                   3.4.1
          EXAMP6.C  BC transmission of conditional messages   4.2.3
          EXAMP7.C  RT list buffering with Notice II enabled  4.3.5
          EXAMP8.C  Continuous monitor mode
          EXAMP9.C  Bus controller interrupts
          EXAMP10.C Bus controller polled interrupts

          The C source code is written for Visual C++
          Version 6.0.



     FUNCTION OVERVIEW

          Each function in the CM1553-1 Driver library are
          listed below.  All functions are described in
          detail in Appendix A of the CM1553-1 User's Manual.

          C11_BCBranchEnd   End the current service branch in the schedule.
          C11_BCCallFrame   Call frames within the cycle.
          C11_BCCheckMsg    Read the protocol error bit of a command block.
          C11_BCConfig      Configure the card for bus controller mode.
          C11_BCConfigEx    Configure card for bus controller mode with extra info.
          C11_BCDoAgain     Reinsert a message into the schedule.
          C11_BCDoGap       Insert an intermessage gap into the schedule.
          C11_BCDoGoto      Insert a jump into the schedule.
          C11_BCDoHalt      Insert a halt into the schedule.
          C11_BCDoInt       Insert an interrupt into the schedule.
          C11_BCDoMsg       Insert a BC-RT message into the schedule.
          C11_BCDoResv      Insert a reserved command block into the schedule.
          C11_BCDoRTRT      Insert an RT-RT message into the schedule.
          C11_BCDoSelfTest  Initiate a self-test within the schedule.
          C11_BCFrameEnd    End the current frame of the schedule.
          C11_BCFrameStart  Start a new frame in the schedule.
          C11_BCMsgBranch   Modify a message to perform a conditional branch.
          C11_BCMsgRetry    Modify a message to perform retries.
          C11_BCRdData      Read the data words associated with a command block.
          C11_BCRdSWD1      Read the first status word of a command block.
          C11_BCRdSWD2      Read the second status word of a command block.
          C11_BCWrData      Write the data words associated with a command block.
          C11_CloseAll      Close all CM1553-1 cards and release all handles.
          C11_CloseCard     Close a CM1553-1 card and release its handle.
          C11_GetBitFld     Get a bit field from a 16-bit value.
          C11_INTInstall    Install an interrupt handler.
          C11_INTRd         Read entries from the interrupt log list.
          C11_INTUninstall  Uninstall the interrupt handler.
          C11_INTUnmask     Write to the Summit Interrupt Mask Register.
          C11_Load          Load the contents of HEX files into the card.
          C11_MONConfig     Configure the card for monitor mode.
          C11_MONCount      Get the current number of messages in the monitor buffer.
          C11_MONRd         Read an entry in the monitor buffer.
          C11_MONTermAddr   Enable or disable monitoring of an RT address.
          C11_OpenCard      Open a CM1553-1 card and request a handle.
          C11_PackCWD       Create a MIL-STD-1553 command word from its fields.
          C11_PeekMem       Read a 16-bit word from the card memory.
          C11_PokeMem       Write a 16-bit word to the card memory.
          C11_PutBitFld     Put a bit field into a 16-bit value.
          C11_RdPort        Read a byte from an IFGA register.
          C11_Reset         Reset the CM1553-1.
          C11_Restart       Restart operation of the CM1553-1.
          C11_RTAccessed    Check if subaddress or mode code buffer was accessed.
          C11_RTConfig      Configure the card for remote terminal mode.
          C11_RTCountList   Return the number of entries in an RT list buffer.
          C11_RTIllegal     Illegalize a subaddress, mode code, or broadcast message.
          C11_RTInitList    Initialize an RT list buffer.
          C11_RTInt         Enable interrupts for a subaddress or mode code message.
          C11_RTMONConfig   Configure for simultaneous RT and monitor mode.
          C11_RTRdData      Read data from subaddress, mode code, broadcast buffer.
          C11_RTRdDataEx    Read an RT data buffer plus extra information.
          C11_RTRdList      Read a message in an RT list buffer.
          C11_RTRstList     Reset an RT list buffer.
          C11_RTWrData      Write data for subaddress or mode code buffer.
          C11_RTWrSWD       Write the status word response bits.
          C11_Save          Save the state of the card to HEX files.
          C11_SelfTest      Perform a self-test of the card.
          C11_Start         Start operation of the card.
          C11_Stop          Stop operation of the card.
          C11_TransmitMsg   Transmit a single BC-RT message.
          C11_TransmitRTRT  Transmit a single RT-RT message.
          C11_UnpackCWD     Extract fields from a MIL-STD-1553 command word.
          C11_WrPort        Write a byte to an IFGA register.



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
