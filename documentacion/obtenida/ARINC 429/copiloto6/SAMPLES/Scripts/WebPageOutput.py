"""	WebPageOutput.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Notes:		This example creates an HTML file.
				Add event handlers to test your project and write to the HTML file.
				The file is displayed in a browser.

	Databuses:	All
"""

#Globals
strOutputFileName = r"c:\copilot projects\CoPilotScriptReport.html"

import webbrowser

#This function is called when a CoPilot Professional project is loaded if this is a master script
def OnProjectLoad():
	#Open file for writing
	f = open(strOutputFileName, "w")
	#Write HTML markup to a file
	f.write("<HTML>")
	f.write(" <HEAD>")
	f.write(" <TITLE>Python Scripting Example</TITLE>")
	f.write(" </HEAD>")
	f.write("<BODY>")
	f.write("<H1>Text and Markup A</H1>")
	f.write("\n")		#blank line
	f.write("<P>Text and Markup B</P>")
	f.write("\n")		#blank line
	f.write("<P>Cool Link   ")
	f.write(r'<A href="http://www.ballardtech.com">Ballard Technology</A>')
	f.write("</P>")
	f.write("</BODY>")
	f.write("</HTML>")
	f.close()
	#Display new web page
	webbrowser.open(strOutputFileName)

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""