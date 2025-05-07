"""	ChangeCounter.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Increments a counter each time a field value changes

	Databuses:	MIL-STD-1553, ARINC 429
"""

#Globals
bInitialized	= False				#bool Initialized flag
dOldValEngr = 0					#double Previous Data Value
lChangeCounter = 0				#long Change Counter counts the # of times the value changes

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()
	#Initialization of Constants
	bInitialized = False
	dOldValEngr = 0
	lChangeCounter = 0

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	print 'OnProjectClose'
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
		global bInitialized
		global dOldValEngr
		global lChangeCounter
		if bInitialized == False:
			bInitialized = True
		if dOldValEngr != varValue:
			lChangeCounter+=1
			#Store new value
			dOldValEngr = varValue
			#Output New Count
			print "lChangeCounter= " + lChangeCounter

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""