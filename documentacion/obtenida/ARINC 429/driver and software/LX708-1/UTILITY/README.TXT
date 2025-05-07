

                  USING THE LP708-1/LC708-1 UTILITY SOFTWARE

                               July 14, 2000

                Copyright 1999-2000 by Ballard Technology, Inc.

                                Version 1.1


                                ------------


          This disk contains the following files:

           File Name                Description

          L71UTIL.EXE   LP708-1/LC708-1 Executable Program
          BTIPATRN.DAT Data file generated using L71 Driver
          TSTPAT20.DAT Data file with recorded data from customer

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          L71UTIL.EXE is a 32-bit Windows application that
          simplifies the recording, playing back, and viewing
          of ARINC 708 / ARINC 453 data.



     INSTALLATION

          Copy the contents of this disk to a folder on your hard drive.
          Unzip the file 708DATA.ZIP if you would like some sample
          .DAT files to use with the software.



     L71UTIL.EXE

          The L71 utility software is a compilation of three of
          Ballard Technology's example programs for the L71 cards.
          The easy to use interface consists of three action buttons,
          a configure button, and a display window.  The three action
          buttons correspond with the three operations the utility
          software can perform: "Record", "Playback", and "File View".


          RECORD

          After pressing the "Record" button, the software will prompt
          the user for a filename in which to store the received data.
          The software will then start the hardware and continue recording
          until the user presses the same button which now reads
          "Stop Recording".  Recording of data will continue for as long
          as the host PC can service the incoming messages.  If the monitor
          buffer on the board is about to overrun itself, data collection
          is halted.  The number of received ARINC 708 data words
          is displayed for convenience.  If an error is detected while
          receiving data words, it is also displayed.  The error codes
          are as follows:

          Error         Description
          -----         ---------------------------------------
          TO            A time out condition occured while receiving
                        ARINC 708 data.  This is usually caused by a
                        break in the transmitting source.

          MAN           A manchester timing error was detected.  This
                        error can be caused by a bad transmitter source,
                        bad cabling, or improper termination.

          DS            A data sync was not detected at the end of the
                        ARINC 708 word.  This error can be caused by
                        improper termination which distorts the ending
                        sync pattern.


          PLAYBACK

          After pressing the "Playback" button, the software will prompt
          the user for a filename from which to transmit data on the bus.
          The software will then start the hardware and continue transmitting
          until the user presses the same button which now reads
          "Stop Playback".  The number of transmitted ARINC 708 data words
          and number of loops through the file are displayed for convenience.


          FILE VIEW

          After pressing the "File View" button, the software will prompt
          the user for a filename from which to display the data on the screen.
          The file viewing function has three different views:
          "ARINC 708 Format View", "Hexadecimal Table View", and
          "Binary Header View".  These views allow for a broad range of
          applications, and can be toggled between them by pressing the
          view button (will have name of current view on it).  Each view
          displays only one ARINC 708 data word at a time.  The horizontal
          scroll bar will move between ARINC 708 data words.  The current
          data word being viewed is displayed for convenience.


          CONFIGURE

          The "Configure" button is used to configure hardware options.
          The L71 card number can be set in the configure dialog box.
          Other hardware options include: bus selection, transmission
          frequency, and block size.  A new option has been added that
          allows the P71 to receive data from the non-standard Collins
          TWR-850 weather radar.  When this option is enabled, the P71
          will be configured to a more tolerant timing mode.  This mode
          was not present on the original P71 decoder.  Therefore, a
          message is displayed when recording whether or not the feature
          is availible.



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
