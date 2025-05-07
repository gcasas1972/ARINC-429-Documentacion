"""	Export1553Mon2Excel.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008, 2010 Ballard Technology, Inc.

	Opens a Microsoft Excel worksheet, then stores MIL-STD-1553
	data from Field1 into the file. When the script is stopped Excel
	is sent a close command which prompts the user to save the file.

	Notes:		Field1 - a Mil-Std-1553 Field (renamed from MIL1553Field1)
				BCMsg1 - a Mil-Std-1553 BC Message

	Databuses:	MIL-STD-1553
"""

#Globals
objExcel = None
ExcelSheet = None
iRowCount = 0

from win32com.client import Dispatch

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	#InitEvents must be called to initialize events
	InitEvents()
	
	global objExcel
	global ExcelSheet
	global iRowCount
	
	Field1.ValueEngr = 0
	#Open Excel and make it visible
	objExcel = Dispatch("Excel.Application")

	#Create new workbook
	objExcel.Workbooks.Add()
	objExcel.Visible = True
	objExcel.UserControl = True

	#Delete the worksheets not being used
	objExcel.DisplayAlerts = False
	objExcel.Worksheets("Sheet2").Delete()
	objExcel.Worksheets("Sheet3").Delete()
	objExcel.DisplayAlerts = True

	#Rename the worksheet
	ExcelSheet = objExcel.ActiveSheet
	ExcelSheet.Name = "Data1"

	#Set column headers in worksheet
	iRowCount = 1
	ExcelSheet.Cells(iRowCount, 1).Value = "MsgTimeTag"
	ExcelSheet.Cells(iRowCount, 2).Value = "Data"
	ExcelSheet.Cells(iRowCount, 3).Value = "Delta Time (ms)"
	ExcelSheet.Cells(iRowCount, 4).Value = "Delta Value"

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	#UnInitEvents is called to uninitialize events
	UninitEvents()
	
	#Use the following line the close excel ... it will prompt for save!
	#ExcelSheet.Application.Quit()

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'OnProjectClose'

#This function is responsible for initializing any event objects
#CoPilot will automatically add this code here when needed
def InitEvents():
	global Msg1_inst
	Msg1_inst = WithEvents(Msg1, Msg1_handler)
	print 'Initializing event objects...'

#This function is responsible for uninitializing any event objects
#CoPilot will automatically add this code here when needed
def UninitEvents():
	print 'Uninitializing event objects...'
	Msg1_inst.close()

#Event Handler for update of Msg1 changes the data
class Msg1_handler:
	def OnMsgUpdate(self, datawords, cwd1, cwd2, swd1, swd2, errors, activity, timetag, timetagh, MsgRespTime1, MsgRespTime2):
		global objExcel
		global ExcelSheet
		global iRowCount
		iRowCount = iRowCount + 1
		ExcelSheet.Cells(iRowCount, 1).Value = timetag
		ExcelSheet.Cells(iRowCount, 2).Value = Field1.ValueEngr
		if iRowCount > 2:
			#Time
			ExcelSheet.Cells(iRowCount, 3).Value = "=(a" + str(iRowCount) + " - a" + str(iRowCount-1) + ")/1000"
			#Data
			ExcelSheet.Cells(iRowCount, 4).Value = "=b" + str(iRowCount) + " - b" + str(iRowCount-1)

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""