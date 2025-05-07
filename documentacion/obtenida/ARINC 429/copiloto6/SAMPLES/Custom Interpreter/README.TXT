

              BALLARD TECHNOLOGY COPILOT CUSTOM INTERPRETER EXAMPLES

                              January 16, 2004

                Copyright 2002-2004 by Ballard Technology, Inc.


                                ------------


     This folder contains the following script examples:

     Example Name                   Description
     -------------------------------------------------------------
     Default.txt                    The default custom interpreter

     Scalar.txt                     A sample scalar custom interpreter

     AltitudeVariableReduction.txt  A sample to convert ARINC
                                    429 Label 206 (Altitude
                                    with Variable Reduction)
                                    to engineering units

     BinString.txt                  A sample that Outputs a value
                                    as a binary string

     RevBinString.txt               A sample that Outputs a value as a
                                    binary string with the bits reversed

     ScalarWithOffset.txt           A sample scalar custom interpreter with an offset



     INTRODUCTION

          This folder contains sample custom interpreter
          scripts for use with CoPilot version 4.0.

          To use a sample custom interpreter script:

          1) Create an ARINC 429 label or a MIL-STD-1553
             field with a custom interpreter type.

          2) Open the sample script file.

          3) Open the properties of the object (label or
             field) and go to the "Custom Interpreter" tab.

          4) Delete the contents from each of the 4 tabs:
             "Value -> Double", "Double->Value", etc.

          5) Copy the code from each section of the
             sample and paste it into the appropriate tab of
             the interpreter, the global information (if any)
             can go into any of the four tabs.

          6) Set your desired ranges and operating limits


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
