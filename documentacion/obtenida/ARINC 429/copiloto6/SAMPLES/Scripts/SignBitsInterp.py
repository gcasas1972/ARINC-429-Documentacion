"""	SignBitInterp.py : COPILOT PYTHON SCRIPT EXAMPLE

	Copyright 2008 Ballard Technology, Inc.

	ARINC 429 BNR interpreter that uses bits 30/31 (SSM) to indicate the sign

	Notes:		When the time-tag of Msg1 changes, this interpreter script is run.

			Bit30	Bit31	Meaning
			------------------------------
			0		0		Positive Value
			0		1		UNDEFINED
			1		0		UNDEFINED
			1		1		Negative Value

	Databuses:	ARINC-429
"""

#Globals
RESOLUTION = 1
STARTBIT = 9
ENDBIT= 29

from win32com.client import WithEvents

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
	print 'OnProjectStop'
	UninitEvents()

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

class Msg1_handler:
	def OnMsgUpdate(self, ValueRaw, activity, timetag, timetagh, mintime, maxtime):
		global RESOLUTION
		global STARTBIT
		global ENDBIT
		TestVal = RawToMyEngr(ValueRaw, STARTBIT, ENDBIT, RESOLUTION)
		#ToDo: Do something with TestVal such as setting a dummy (inactive) label value
		#Example: Msg2.ValueEngr = TestVal
		def RawToMyEngr(RawValue,StartBit,EndBit,Resolution):
		#Initialization
			bError = False
			bNegFlag = False
		#Input Error Checking
			if StartBit < 9:
				bError = True
			if EndBit > 31:
				bError = True
		#Resolution must be a power of 2 times a power of 10!
			if not IsPowerOf2And10(value):
				bError = True	#Resolution Error
		#Calculate Negative flag
			if (RawValue & 0x60000000) == 0x60000000:
				bNegFlag = True
		#Check for Errors
			elif (RawValue & 0x60000000) != 0:
				bError = True	#SSM value of 10 or 01 are undefined
			if bError == True:
				pass
			#Un-comment the following line(s) if you want to exit on errors
			#return [return value for Errors]
		#Extract Data Portion
		#Mask Off upper bits
			Mask = 0xFFFFFFFF/(2^(32-EndBit))
			RawValue = RawValue & Mask
		#Shift value over to starting bit
			RawValue = RawValue/(2^(StartBit-1))
		#Multiply the data portion by the resolution
			if bNegFlag:
				return -1 * RawValue * Resolution
			else:
				return RawValue * Resolution
		#Extra error checking
		def IsPowerOf2And10(value):
			IsPowerOf2And10 = False
		#Test if directly a power of 2 or 10
			if IsPowerOf2(value):
				return True
			elif IsPowerOf10(value):
				return True
			exp = 0
			while exp<=PWR_MAX:
				if value>=1:
					if IsPowerOf2(value / PowerOf10(exp)):
						return True
				else:
					if IsPowerOf2(value * PowerOf10(exp)):
						return True
				exp += 1
		def PowerOf2(exp):
			#ToDo: Enter your own Code Here to do this test!!!
			return True

		def PowerOf10(exp):
			#ToDo: Enter your own Code Here to do this test!!!
			return True

"""	Ballard Technology, Inc.
	(800) 829-1553
	www.ballardtech.com
	support@ballardtech.com
"""