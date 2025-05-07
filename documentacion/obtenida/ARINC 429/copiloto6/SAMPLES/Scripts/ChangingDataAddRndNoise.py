"""	ChangingDataAddRndNoise.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Reads a Value and Add Random Noise, then Transmit the new Value

	Notes:	Msg1 contains the original data. The current value of Msg1 with the noise
			is written to Msg2.
			This example assumes Msg1 and Msg2 are ARINC 429 labels.
			To apply this example to a 1553 Field, use any data value as the source
			in place of Msg1. "Msg2" would be renamed to your field object name. Also,
			a 1553 BC Message could be used as the event handler object.

	Databuses:	MIL-STD-1553, ARINC 429
"""

#Globals
ERRORVAL = 50

import random

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'ProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	Msg2.ValueEngr = 0				#Initialized to 0

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	print 'ProjectStop'
	UninitEvents()

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'ProjectClose'

#This function is responsible for initializing any event objects
#CoPilot will automatically add this code here when needed
def InitEvents():
	global Msg1_inst
	Msg1_inst = WithEvents(Msg1, Msg1_handler)
	print 'Initializing event objects...'

#This function is responsible for uninitializing any event objects
#CoPilot will automatically add this code here when needed
def UninitEvents():
	print 'Uninitializing event objects...'
	Msg1_inst.close()

class Msg1_handler:
	def OnMsgUpdate(self, ValueRaw, activity, timetag, timetagh, mintime, maxtime):
		global ERRORVAL
		Value = random.uniform(-ERRORVAL, ERRORVAL)		#Random Number between +/-ERRORVAL
		Msg2.ValueEngr = Value + Msg1.ValueEngr

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""