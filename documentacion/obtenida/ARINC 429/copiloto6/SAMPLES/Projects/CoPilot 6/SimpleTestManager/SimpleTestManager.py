import win32gui
from time import sleep

#Note: This example contains additional code that runs the selected Automated Test Manager tests
# when CoPilot is started. Tests can also be run directly from the Automated Test Manager pane

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	"""The project load function can call initialization and/or test functions, however
	the atm object is not available until after the project is finished loading"""
	#Starts the shell in the running state... once started, the OnProjectRun function is called by CoPilot
	shell.Run()

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	print 'OnProjectRun() called'
	
	#run all selected tests in the test manager (using extra error handling in case tests are already running)
	try:
		atm.StartTests()
	except:
		print 'Selected atm Tests already running. Tests not run a second time.'

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	pass #does nothing

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	pass #does nothing

def DoSomethingBad():
	#DoSomethingBad() called... test will fail (see the Automated Test Manager pane).
	"""TODO: Erase the following lines and implement your test procedure"""
	atm.Fail("Failed Test!")
	print '*** ERROR *** DoSomethingBad() failed'
	
def DoSomethingGood():
	#DoSomethingGood() called... test will pass (see the Automated Test Manager pane).
	"""TODO: Erase the following lines and implement your test procedure"""
	atm.Pass("Passed Test!")
	print '++ SUCCESS ++ DoSomethingWithWarning() passed'

def DoSomethingWithWarning():
	#DoSomethingGood() called... test will pass with a warning (see the Automated Test Manager pane).
	"""TODO: Erase the following lines and implement your test procedure"""
	atm.PassWithWarning("This is a warning message")
	print '++ SUCCESS ++ DoSomethingWithWarning() passed with a warning'

def DoTest1():
	#DoTest1() called. See the Automated Test Manager pane for test results.

	"""This simple test runs CoPilot, sets the channel to pause, then tests that pause was set"""
	Test1Setup()
	
	#If test requires CoPilot to be running, verify CoPilot is still running,
	if (not shell.Running):
		shell.Run()

	#Set channel to pause... this can be changed to something more meaningful
	Chan0Rx.Pause = True

	#For this test, we want to verify the value is set after stopped
	#so, wait a several seconds (5)
	CopWait(5)
	#Stop CoPilot
	shell.Stop()
	
	#Check if test passed or failed -- Pause was actually set
	if (Chan0Rx.Pause != True):
		win32gui.MessageBox(0,"Test Failed","Test Done",0)
		atm.Fail("Failed Test (Channel was not paused)")
		print '*** ERROR *** DoTest1() failed, channel was not paused'
	else:
		atm.Pass("Passed Test!")
		print '++ SUCCESS ++ DoTest1() passed'
		
	#Return channel state to unpaused
	Chan0Rx.Pause = False
	
def Test1Setup():
	#Set up initial states
	Chan0Rx.Pause = False
	"""TODO: Add other initializations..."""

def CopWait(waitseconds):
	import time
	import pythoncom
	start = time.clock()
	while True:
		time.sleep(0)
		if (time.clock() - start) > waitseconds:
			# Time's up
			return False
		# Keep pumping
		pythoncom.PumpWaitingMessages()
