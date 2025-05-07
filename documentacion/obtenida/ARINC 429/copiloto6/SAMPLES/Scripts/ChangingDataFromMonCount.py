"""	ChangingDataFromMonCount.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Sets a data value equal to the count in the monitor each time
	the monitor count changes

	Databuses:	MIL-STD-1553, ARINC 429
"""

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	print 'OnProjectRun'

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	print "There were " + str(Mon1.Count) + " items recorded."

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
		#Set the data value of Field1
		Field1.ValueEngr = Count

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""