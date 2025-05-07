"""	MonitorControl.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	This Monitor Control sample script controls the pause state of a
	sequential record object (Mon1). The monitor object in the hardware
	tree must be active and configured to monitor data (i.e. "All").

	The recording state of the monitor is in turn controlled by Field1.
	When the data value of Field1 is Below the UPPERLIMIT the monitor
	is un-paused. When above UPPERLIMIT, recording is paused. Changing
	data values in Field1 trigger a change in the recording state of
	the monitor.

	Application:	Record all bus traffic on takeoff and landing -- while
					the Altitude is less than UPPERLIMIT.

	Notes:			ARINC 429 Labels can also be used in place of the "Field1" object.

	Databuses:	MIL-STD-1553, ARINC 429
"""

#Globals
UPPERLIMIT = 5000

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	#Make Sure the monitor is not set to pause
	Mon1.Pause = False

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	print 'OnProjectStop'
	UninitEvents()

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'OnProjectClose'

#This function is responsible for initializing any event objects
#CoPilot will automatically add this code here when needed
def InitEvents():
	global Field1_inst
	Field1_inst = WithEvents(Field1, Field1_handler)
	print 'Initializing event objects...'

#This function is responsible for uninitializing any event objects
#CoPilot will automatically add this code here when needed
def UninitEvents():
	print 'Uninitializing event objects...'
	Field1_inst.close()

class Field1_handler:
	def OnValueChange(self, varValue):
		global UPPERLIMIT
		if varValue <= UPPERLIMIT:
			Mon1.Pause = False
		else:
			Mon1.Pause = True

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""