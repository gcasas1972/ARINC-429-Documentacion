

                      THE PM429-1 WINDOWS CE 5.0 DRIVER

                               August 27, 2007

                   Copyright 2007 by Ballard Technology, Inc.


                                ------------


          This folder contains the following subfolders:

          Folder Name               Description

          <BTIISA>      Source for ISA Windows CE device driver
          <PM41DIO>     Source for DIO example
          <PM41RCV>     Source for receiver example
          <PM41TEST>    Source for test example
          <PM41XMT>     Source for transmitter example

          README.TXT   This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The PM429-1 is a PC/104-compliant interface card
          capable of communicating over ARINC 429 avionics
          databuses.  Embedded systems frequently use PC/104
          products because they are small (about four inches
          square), inexpensive, and easily integrated into an
          application.  In addition to the ARINC 429
          capability, the PM429-1 provides a general-purpose
          timer and optional input and output discretes.

          The PM429-1 is a PC/104 card that allows the user
          to communicate on an ARINC 429 databuses.  The
          folders listed above contain the source for the
          driver and examples for using the PM429-1 from a
          user application running under Windows CE 5.0.



     BUILDING THE DRIVER AND EXAMPLES

	      Each of the folders listed above contains a
	      Platform Builder project.  Insert the BTIISA device
	      driver project into your OS Design to include the
	      driver.  Insert one or more of the examples to
	      include them into the target image.



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
