import InputDialog
from Tkinter import *

def OnProjectLoad():
	"""This function is called when a CoPilot Professional project is loaded"""
	print 'OnProjectLoad'

def OnProjectRun():
	"""This function is called immediately after a CoPilot Professional project begins running.
	It is executed concurrently with the simulation of the project in its own separate thread."""
	print 'Starting project'
	InitEvents()
	
	shell.ShowPaneWindow("Hardware Explorer",True)
	
	#clear previous values
	CopilotLabelCtrl2.Caption = ""
	CopilotLabelCtrl4.Caption = ""
	CopilotLabelCtrl6.Caption = ""
	
	print 'pre-Run input prompts'
	#create a root TK window
	root = Tk()
	#hide the root window
	root.withdraw()
	
	#open Input Dialog for Input1
	d = InputDialog.MyDialog(root,"Input1")
	root.wait_window(d.top)
	print InputDialog.instring
	CopilotLabelCtrl2.Caption = InputDialog.instring
	
	#open Input Dialog for Input1
	d = InputDialog.MyDialog(root,"Input2")
	root.wait_window(d.top)
	print InputDialog.instring
	CopilotLabelCtrl4.Caption = InputDialog.instring
	
	#open Input Dialog for Input1
	d = InputDialog.MyDialog(root,"Input3")
	root.wait_window(d.top)
	print InputDialog.instring
	CopilotLabelCtrl6.Caption = InputDialog.instring

	print 'OnProjectRun() finished'

def OnProjectStop():
	"""This function is called immediately after a CoPilot Professional project has stopped"""
	print 'OnProjectStop'
	UninitEvents()

def OnProjectClose():
	"""This function is called when a CoPilot Professional project is closed"""
	print 'OnProjectClose'

def InitEvents():
	"""This function is responsible for initializing any event objects
	CoPilot will automatically add this code here when needed"""
	print 'Initializing event objects...'

def UninitEvents():
	"""This function is responsible for uninitializing any event objects
	CoPilot will automatically add this code here when needed"""
	print 'Uninitializing event objects...'
