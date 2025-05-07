"""	ChangingDataSinGen.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Sets a data value to a sinusoidal value (between MINAMP and MAXAMP), with
	adjustable period, for each transmission.

	Notes:	The period is assigned by the PERIOD constant in milliseconds (10000ms = 10s).

			In this example Msg1 is a ARINC 429 Message (label).
			This can be modified for MIL-STD-1553 by making the
			following changes:
			1. Rename your 1553 BCMsg object to Msg1 in the Object Browser pane
			2. Change the def OnMsgUpdate(self, ValueRaw, activity, timetag, timetagh, mintime, maxtime)
						to def OnMsgUpdate(self, datawords, cwd1, cwd2, swd1, swd2, errors, activity, timetag, timetagh, MsgRespTime1, MsgRespTime2)
			3. Change the "Msg1.ValueEngr = Value" line to work with a field...
					such as "Field1.ValueEngr = Value"

	Databuses:	MIL-STD-1553, ARINC 429
"""

#Globals
MAXAMP = 100.0			#Max Amplitude
MINAMP = -100.0			#Min Amplitude
PERIOD = 10000.0		#Period in milliseconds
MyStartTime = 0

from math import sin, pi

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	MyStartTime = 0

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	print 'OnProjectStop'

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'OnProjectClose'

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

#Event Handler for update of Msg1 changes the data
class Msg1_handler:
	def OnMsgUpdate(self, ValueRaw, activity, timetag, timetagh, mintime, maxtime):
		#Globals referenced within event handlers must be declared before use
		global MyStartTime
		global MINAMP
		global MAXAMP
		global PERIOD
		if MyStartTime == 0:
			MyStartTime = Msg1.timetag
			Angle = 0.0
		else:
			deltaMiliSec = (Msg1.timetag - MyStartTime)  / 1000.0
			deltaMiliSec = deltaMiliSec % PERIOD
			Angle = (deltaMiliSec/PERIOD) * 2.0 * pi				#The angle increases linearly over the PERIOD Like a Saw-tooth wave
		Value = (MINAMP+MAXAMP) + (MAXAMP-MINAMP)/2.0 * sin(Angle)
		Msg1.ValueEngr = Value
		print Value

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""