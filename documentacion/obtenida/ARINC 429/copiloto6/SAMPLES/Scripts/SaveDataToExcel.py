"""	SaveDataToExcel.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	This is the simplest example of how to write CoPilot data to Microsoft Excel
	Importing this module and calling the SaveDataToExcel() function will write
	the current value of "Msg1" to the created Excel Spreadsheet

	Databuses:	All
"""

from win32com.client import Dispatch

def SaveDataToExcel():
	objExcel = Dispatch("Excel.Application")
	objExcel.UserControl = True
	#Create a spreadsheet
	ExcelSheet = Dispatch("Excel.Sheet")
	ExcelSheet.Application.Visible = True
	#Add data from CoPilot and save
	ExcelSheet.ActiveSheet.Cells(1,1).Value = Msg1.ValueEngr
	ExcelSheet.SaveAs(r"C:\COPILOT PROJECTS\EXAMPLE.XLS")
	#Close the Excel application
	ExcelSheet.Application.Quit()
	del objExcel
	del ExcelSheet

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""