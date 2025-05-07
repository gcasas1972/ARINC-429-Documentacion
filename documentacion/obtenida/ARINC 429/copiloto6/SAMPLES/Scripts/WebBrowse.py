"""	WebBrowse.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	This example opens an Internet Explorer object to the Ballard Technology Web Site.

	Notes:		Instead of the Ballard Technology Site, other web sites or documents
				(such as PDF, GIF, JPG, WAV, AVI, DOC, XLS, etc.) can be opened via Internet Explorer.

	Databuses:	All
"""

from win32com.client import Dispatch

#This function is called when a CoPilot Professional project is loaded if this is the master script
def OnProjectLoad():
	#Create the Internet Explorer object
	ie = Dispatch("InternetExplorer.application")
	#Display new web page
	ie.Navigate("www.ballardtech.com")
	ie.Visible = True

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""