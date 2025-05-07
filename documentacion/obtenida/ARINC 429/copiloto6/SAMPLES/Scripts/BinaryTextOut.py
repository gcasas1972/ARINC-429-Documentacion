"""	AutomateControl.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Sample script for automating an LED control

	Databuses:	ALL
	Field1			= Any CoPilot field
	Mon1			= Any CoPilot monitor
	LEDCtrl1		= An LED control on a Control View Form
"""

#Globals
UPPERLIMIT = 5000

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'Hello OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	#Make Sure the monitor is not set to pause
	Mon1.Pause = False
	LEDCtrl1.Value = 1

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	Mon1.Pause = False
	LEDCtrl1.Value = 1
	UninitEvents()

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'Hello OnProjectClose'

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
			LEDCtrl1.Value = 1
		else:
			Mon1.Pause = True
			LEDCtrl1.Value = 0

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""