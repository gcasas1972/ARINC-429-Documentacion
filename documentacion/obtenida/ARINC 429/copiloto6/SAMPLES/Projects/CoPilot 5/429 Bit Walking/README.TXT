

                  BALLARD TECHNOLOGY COPILOT SAMPLE PROJECT

                              July 07, 2011

                  Copyright 2006-2011 by Ballard Technology, Inc.

                                ------------
429 Bit Walking

Notes:
This project was updated for use with CoPilot 5.30 or later.

Description:
This project is a sample that should illustrate the concepts of changing
data based on a state with the use of scripting. A timer is used to advance
to the next state which walks a single bit from bit 11 to bit 29.

Operation:
The message (label) scheduled in the hardware tree is transmitted at the rate
specified by the transmit interval of the message. The message update is 
triggered by a timer event. When the timer fires the current bit number is 
advanced and the appropriate bit is set on the message. This continues to 
walk all data bits then resets to the beginning and starts again. The output
prints the current bit number and the current value of the message. 

