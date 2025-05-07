"""	MonitorCount.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	This Monitor Count sample script records MAXCOUNT number of records then
	pauses the sequential record object (Mon1). The monitor object in the
	hardware tree must be active and configured to monitor data (i.e. "All").

	The recording state of the monitor is controlled by "Mon1.Count".
	When the count (number of records) is EQUAL or ABOVE the MAXCOUNT Mon1
	is paused.

	Databuses:	MIL-STD-1553, ARINC 429
"""

#Globals
MAXCOUNT = 500

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	#Make Sure the monitor is not set to pause on start
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
	global Mon1_inst
	Mon1_inst = WithEvents(Mon1, Mon1_handler)
	print 'Initializing event objects...'

#This function is responsible for uninitializing any event objects
#CoPilot will automatically add this code here when needed
def UninitEvents():
	print 'Uninitializing event objects...'
	Mon1_inst.close()

class Mon1_handler:
	def OnCountChange(self, Count):
		global MAXCOUNT
		if Count >= MAXCOUNT:
			Mon1.Pause = True		#Pause the monitor when above MAXCOUNT

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""