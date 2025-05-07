"""	SaveLoadFileDialog.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Open a File Common Dialog
	This common dialog can be used for browsing when loading or saving files

	Databuses:	N.A.
"""

import win32ui
import win32con

#Create an OpenFileDialog using win32ui.CreateFileDialog in order to get a file name
def GetFileName():
	dlg = win32ui.CreateFileDialog(1,
									None,
									None,
									win32con.OFN_FILEMUSTEXIST|
									win32con.OFN_EXPLORER|
									win32con.OFN_HIDEREADONLY,
									'All Files (*.*)|*.*|Text Files (*.txt)|*.txt')
	dlg.SetOFNTitle('My Dialog Title')
	testvalue = dlg.DoModal()
	filename = dlg.GetPathName()
	if (testvalue == win32con.IDOK) and filename:
		print filename + " file was selected for opening."
		#ToDo: Now open the file name specified by openedFile
		print "Add code to do something with this file!"
	else:
		print "No File was selected!"

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""