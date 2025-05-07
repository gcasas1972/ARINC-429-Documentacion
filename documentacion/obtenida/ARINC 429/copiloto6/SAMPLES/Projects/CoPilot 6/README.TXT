

                  BALLARD TECHNOLOGY COPILOT SAMPLE PROJECTS

                               January 4, 2012

                  Copyright 2002-2012 by Ballard Technology, Inc.


                                ------------


     This folder contains the following script examples:

        Sample Name                    Description
     ------------------------------------------------------------------
     4-StateButton      Uses VB scripting to interact with a button on a 
                        Control View. Pressing the button cycles through
                        the four different states.

     AirDynamicsSim     Uses Python scripting in CoPilot ATE to control autopilot 
     (Python)           inputs using an Aircraft View. The current altitude, longitude, 
                        latitude, roll, pitch, etc. respond accordingly.

     AirDynamicsSim     Uses VB scripting to control autopilot inputs using an
     (VBScript)         Aircraft View. The current altitude, longitude, 
                        latitude, roll, pitch, etc. respond accordingly.

     ConVersion429to1553_ABB
                        Uses Python scripting and an Avionics BusBox device to convert 
                        ARINC 429 data to MIL-STD-1553. Data is modified using data
                        generators on the ARINC side. A Control View displays both the 
                        ARINC 429 and MIL-STD-1553 in a simple form.

     ConVersion429to1553_Demo
                        Uses Python scripting and two Demonstration devices (Demo Cards) to
                        convert ARINC 429 data to MIL-STD-1553. Data is modified using data
                        generators on the ARINC side. A Control View displays both the 
                        ARINC 429 and MIL-STD-1553 in a simple form.

     Discrete Example   Uses Python scripting to control an OmniBus Discrete Module
                        And display the state of 8 discretes in a bank with an LED Control

     ISOAlphaRx         ARINC 429, Uses Python scripting to receive an
                        ISO Alphabet No.  5 string

     ISOAlphaTx         ARINC 429, Uses Python scripting to transmit
                        an ISO Alphabet No. 5 string

     ISOAlphaTx_Demo    ARINC 429, Uses Python scripting to transmit
                        an ISO Alphabet No. 5 string with a Demo Card

     Output429MonData   ARINC 429, Uses VB scripting loop through 
			recorded monitor data in the Sequential Monitor 
			Object (in the Hardware Explorer).

     PythonTkinterInput Uses Python scripting with Tkinter to demonstrate showing windows and
                        input boxes. The inputs are then displayed in a control view display.

     SimpleTestManager  Uses Python scripting with Test Manager to run tests.
                        A demonstration card is used for a sample test.

     WeatherRadarSystem ARINC 708 & 429, Contains UA1410 and UA1710 
                        USB devices. Has a Control Panel with links hooked
                        to the 2 429 control words for ARINC 708.  Also
                        has a 429-view to verify correct transmission
                        values of 429 fields.

     WilliamsburgSink   ARINC 429, Uses VB scripting to simulate a
                        sink during a bit-oriented file transfer 
                        (Williamsburg File Transfer Protocol).

     WilliamsburgSource ARINC 429, Uses VB scripting to simulate a
                        source during a bit-oriented file transfer 
                        (Williamsburg File Transfer Protocol).


     INTRODUCTION

          This folder contains sample projects for use with
          CoPilot version 6.00 or later.

          To use a sample project, open the project by
          double-clicking the .CPJ file in the folder or
          navigate to the .CPJ file from within CoPilot. These 
          sample projects are also available from 'Samples and
          Templates' on the Start Page under 'Samples.'


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
     (800) 829-1553
     www.ballardtech.com
     support@ballardtech.com
