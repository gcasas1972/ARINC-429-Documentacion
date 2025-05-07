"""	FileReadWrite.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	Sample file reading and writing
	All file access is done from the OutputToFileTest function
	It uses CoPilot's output object to create a new stream for output
	Then writes to this stream and exports it to a file
	Then the file is open and read using a Python file object

	Databuses:	All
"""

from time import localtime, strftime

def OutputToFileTest(filename):
	streamID = output.CreateStream("TestOutput")
	#Output text to the stream
	output.OutputToStream(streamID, "CoPilot Script Output File")
	output.OutputToStream(streamID, "\n")		#Creates a blank line
	output.OutputToStream(streamID, strftime("%a, %d %b %Y %H:%M:%S", localtime()))
	output.OutputToStream(streamID, "Hello World")
	output.ExportStreamToFile(streamID, filename)
	#Delete the stream
	output.DeleteStream(streamID)
	#Now read the file back
	f = file(filename)
	#Return a list of lines in the file
	return f.readlines()

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""