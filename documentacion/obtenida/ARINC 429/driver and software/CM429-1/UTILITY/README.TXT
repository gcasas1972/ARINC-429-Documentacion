

                           USING THE 717 MONITOR

                                May 28, 1998

                   Copyright 1998 by Ballard Technology, Inc.

                                Version 1.2

                                ------------


          This disk contains the following files and subdirectories:

           File Name                Description

          C717MON.EXE     717 Monitor Executable for CM429-1
          717MON.HLP      Windows Help File
          README.TXT      This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The program 717MON.EXE is a 32-bit Windows 95 or
          Windows NT 4.0 programs developed by Ballard
          Technology Inc. to simplify the monitoring of an
          ARINC 717 databus.  This program is described below.



     717MON.EXE

          Ballard Technology's 717 Monitor allows you to
          observe the information being received on an ARINC
          717 databus.  You can specify the data you wish to
          observe by selecting a word, subframe, and/or
          superframe. You can also configure the monitor to
          match the speed of the bus being monitored.  Data may
          be recording to a file.

          If you need assistance, please see the Windows Help
          file or call Ballard Technology at the number listed
          at the end of this document.



     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION

          Version 1.2

               - Added record to file functionality.
               - Added ability to save preferences to the
                 registry.
               - Added support for viewing data in multiple
                 radix.
               - Added options to specify Superframe counter
                 at the bit level within a word.

          Version 1.1

               - Changed configuration dialog to display
                 sync words in octal.
               - Updating WPS automatically updates Superframe
                 word location to last word in subframe.
               - The Superframe counter logic was changed to
                 use a 0-index value.
                 SuperframeNumber = (Counter % FramesInSuperframe) +1

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
