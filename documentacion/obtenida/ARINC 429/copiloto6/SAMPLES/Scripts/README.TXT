

                  BALLARD TECHNOLOGY COPILOT SCRIPT EXAMPLES

                                January 04, 2012

                  Copyright 2002-2012 by Ballard Technology, Inc.


                                ------------


     This folder contains the following script examples (the used scripting language is indicated in parentheses following the description):

     Example Name                 Description
     --------------------------------------------------------------------
     AFDXFrom429.txt              Uses the script timer to transfer data from an AFDX field to an ARINC 429 message (VBScript)
     AFDXMonPause.txt             Uses the script timer to toggle the Monitor pause state every five seconds (VBScript)
     AFDXTo429.txt                Uses the script timer to transfer data from an ARINC 429 message to an AFDX field (VBScript)
     AutomateControl.py           Automate an LED control on a Control View (Python Script)
     AutomateControl.txt          Automate an LED control on a Control View (VBScript)
     BC_Pause.txt                 Pause and unpause the bus controler (VBScript)
     BinaryTextOut.py             Convert a value to a binary string (Python Script)
     BinaryTextOut.txt            Convert a value to a binary string (VBScript)
     CalcTimerInt.txt             Calculate the minimal acceptable timer interval (VBScript)
     ChangeCounter.txt            Increment a counter when a value changes (Python Script)
     ChangeCounter.txt            Increment a counter when a value changes (VBScript)
     ChangingDataAddRndNoise.py   Add random noise to a data value for each transmission (Python Script)
     ChangingDataAddRndNoise.txt  Add random noise to a data value for each transmission (VBScript)
     ChangingDataFromMonCount.py  Set a data value equal to the count in the monitor each time the monitor count changes (Python Script)
     ChangingDataFromMonCount.txt Set a data value equal to the count in the monitor each time the monitor count changes (VBScript)
     ChangingDataRndGen.py        Set a data value to a random value (between MINVAL and MAXVAL) for each transmission (Python Script)
     ChangingDataRndGen.txt       Set a data value to a random value (between MINVAL and MAXVAL) for each transmission (VBScript)
     ChangingDataSinGen.py        Set a data value to a sinusoidal value (between MINAMP and MAXAMP), with adjustable period, for each transmission  (Python Script)
     ChangingDataSinGen.txt       Set a data value to a sinusoidal value (between MINAMP and MAXAMP), with adjustable period, for each transmission  (VBScript)
     ChangingDataWord.txt         After each transmition of BCMsg1 the first data word is incremented  (VBScript)
     CommonFunctions.txt          Common tasks used in scripting: Load/save files, ShiftRight, ShiftLeft, Pow2, Error Checking, etc. (VBScript)
     CreateReport.txt             Collect information during a run and create a report when the project is stopped  (VBScript)
     DiscreteInOuts_BusBox.txt    Controls onboard discretes for the BusBox (some signals may not be accesssable for all models) (VBScript)
     ErrLog1553.txt               Report errors from a BC message (VBScript)
     ErrLog429.txt                Report errors from an ARINC 429 message (VBScript)
     Errorhandling.txt            Performs error checking of individual procedures and subroutines (VBScript)
     ExcelReport.txt              After running, create a Microsoft Excel report form (VBScript)
     Export1553Mon2Excel.py       Save MIL-STD-1553 monitor data directly to Microsoft Excel (Python Script)
     Export1553Mon2Excel.txt      Save MIL-STD-1553 monitor data directly to Microsoft Excel (VBScript)
     Export429Mon2Excel.txt       Save ARINC 429 monitor data directly to Microsoft Excel (VBScript)
     FileReadWrite.py             Read and write to an external file (Python Script)
     FileReadWrite.txt            Read and write to an external file (VBScript)
     HelperMacros.py              Some example common tasks that can be run as macros to automate repetitive processes (Python Script)
     InputOutputControl.txt       InputOutput Control to show script-safe message and input boxes (VBScript)
     ISOAlphaRx.txt               Receive an ISO Alpha No. 5 encoded message (VBScript)
     ISOAlphaTx.txt               Encode user supplied strings into an ISO Alphabet No. 5 message  (VBScript)
     LabView1.txt                 Open a sample LabView file (ScriptTest.vi), set input parameters, and read data (VBScript)
     MessageSkipping1553.txt      Poll RT for a "no response" and skip the message if true (VBScript)
     MonitorControl.py            Filter the monitor based on a data value (Python Script)
     MonitorControl.txt           Filter the monitor based on a data value (VBScript)
     MonitorCount.py              Limit the monitor to MAXCOUNT records (Python Script)
     MonitorCount.txt             Limit the monitor to MAXCOUNT records (VBScript)
     MonStopConditions.txt        List and demonstrate various conditions that may be used to control the sequential monitor (VBScript)
     MultipleExport.txt           Exports data from a connected Monitor View every 10 seconds and restarts recording - Requires CoPilot 4.1 (VBScript)
     OpenCoPilotFromExcel.txt     Control CoPilot through OLE automation from a third-party application (Excel)  (VBScript)
     SamplLabelColl_Msg.txt       Sample data from a collection of ARINC 429 messages - triggered by a message timetag change (VBScript)
     SamplLabelColl_TimerCtrl.txt Sample data from a collection of ARINC 429 messages - triggered by a timer control (VBScript)
     SamplRTColl.txt              Sample data from a collection of MIL-STD-1553 SAs - triggered by a timer control (VBScript)
     SaveDataToExcel.py           Save data to Microsoft Excel (Python Script)
     SaveDataToExcel.txt          Save data to Microsoft Excel (VBScript)
     SaveLoadFileDialog.py        Demonstrate the use of Common Dialog Boxes (Python Script)
     SaveLoadFileDialog.txt       Demonstrate the use of Common Dialog Boxes (VBScript)
     ScriptCollectionInfo.txt     Collection example starts with the CoPilot Shell and outputs information about all cards (VBScript)
     SeqMonTimedStart.txt         Start the Sequencial Monitor based on simulation run time (VBScript)
     SignBitsInterp.py            Demonstrate an ARINC 429 BNR interpreter that uses bits 30/31 to indicate the sign (Python Script)
     SignBitsInterp.txt           Demonstrate an ARINC 429 BNR interpreter that uses bits 30/31 to indicate the sign (VBScript)
     SocketClient.py              A Python client that can be run outside of CoPilot to consume data presented by the server in the "SocketServer.py" module  (Python Script)
     SocketServer.py              A Berkeley Socket server that takes data and packages it for consumption by a client, possibly on a different computer and outside CoPilot (Python Script)
     SoundScript.txt              Create an audible sound when a data value has an operating limit error (VBScript)
     SpredshtCtrlLoadSave.txt     Load/Save data from/to the Microsoft Office Spreadsheat 9.0 Control (Excel web component) (VBScript)
     StopBCOnErr.txt              Stop/pause the BC when an error is detected (VBScript)
     TimerControl.txt             Simple timer control example that outputs the current time every timer interval (VBScript)
     TimerEvent.txt               Demonstrate the use of CoPilot Script timer events (VBScript)
     TimeToMessage.txt            Puts the current system time into the data portion of a message (VBScript)
     WebBrowse.py                 Open a web browser from within CoPilot (Python Script)
     WebBrowse.txt                Open a web browser from within CoPilot (VBScript)
     WebPageOutput.py             Create a report in HTML format and display it in a browser when CoPilot is stopped (Python Script)
     WebPageOutput.txt            Create a report in HTML format and display it in a browser when CoPilot is stopped (VBScript)
     WilliamsburgSource.txt       Send a binary file using a Williamsburg protocol file transfer (VBScript)
     WilliamsburgSink.txt         Receive a binary file using a Williamsburg protocol file transfer (VBScript)


     INTRODUCTION

          This folder contains sample scripts for use with
          CoPilot version 4.0 and above

          To use a "Python" sample script in CoPilot 5 or 6:

          1) Create a CoPilot project.  Open the 'New Hardware or View'
             dialog and insert a Python Editor View from
             the 'Professional Views' tab.

          2) Delete the entire contents of the Script
             View's code pane.

          3) Copy the entire text from the sample script file
             into the code pane of the Script View.

          4) Drag & drop any appropriate objects into the
             Object Browser Pane (accessed from the toolbar panes|Object Browser.)
             The required objects are listed in the comment section of the sample.

          5) Rename objects, if needed, in order to
             correspond to the object names in the sample.

          6) Run the project.


          To use a "VBScript" sample script in CoPilot 4, 5 or 6:

          1) Create a CoPilot project.  Open the 'New
             Component' dialog and insert a Script View from
             the 'Professional Views' tab.

          2) Delete the entire contents of the Script
             View's code pane.

          3) Copy the entire text from the sample script file
             into the code pane of the Script View.

          4) Drag & drop any appropriate objects into the
             Script View object pane.  The required objects are
             listed in the comment section of the sample.

          5) Rename objects, if needed, in order to
             correspond to the object names in the sample.

          6) Run the project.


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
