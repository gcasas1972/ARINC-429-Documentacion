#	ISOAlphaRx.py : COPILOT SCRIPT EXAMPLE
#
#	Copyright 1995-2011
#       
#	Ballard Technology, Inc.
#	11400 Airport Road
#	Everett WA 98204
#	USA
#	(800) 829-1553
#	(425) 339-0281
#	(425) 339-0915 FAX
#	www.ballardtech.com
#	support@ballardtech.com
#
#	Databuses:	ARINC 429
#	Description:	Receives an ISO Alpha No. 5 encoded message 
#	Notes:
# 	1. Requires:
#		a. ISOMsg    - ARINC 429 Label 356 (ISO Alphabet No. 5)
#		b. WordCount - Field (ISO#5 Char, bits  9-16)
#		c. Spares    - Field (ISO#5 Char, bits 17-22)
#		d. CH1       - Field (ISO#5 Char, bits  9-15)
#		e. CH2       - Field (ISO#5 Char, bits 16-22)
#		f. CH3       - Field (ISO#5 Char, bits 23-29)
#  		g. SSM	     - Field (ISO#5 Char, bits 30-31)		
# 	2. Each data word can hold up to 3 characters from the string 
# 	3. Convert sample to use Label 357 by:
#		a. Change Spares to UnitAddress
#		b. Set UnitAddress in SetStandBy function
#

#Constants
SSM_INTERMEDIATE = 0	#SSM for all data words except last
SSM_STX = 1             	#SSM for initial word   (Start Text)
SSM_ETX = 2              	#SSM for final word     (End Text)

#Globals
MyString = ""

def OnProjectLoad():
	"""This function is called when a CoPilot Professional project is loaded"""
	print 'OnProjectLoad'

def OnProjectRun():
	"""This function is called immediately after a CoPilot Professional project begins running.
	It is executed concurrently with the simulation of the project in its own separate thread."""
	InitEvents()
	print 'OnProjectRun'

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
	global ISOMsg_inst
	ISOMsg_inst = WithEvents(ISOMsg, ISOMsg_handler)

def UninitEvents():
	"""This function is responsible for uninitializing any event objects
	CoPilot will automatically add this code here when needed"""
	print 'Uninitializing event objects...'
	ISOMsg_inst.close()

class ISOMsg_handler:
	def OnMsgUpdate(self, ValueRaw, activity, timetag, timetagh, mintime, maxtime):
		global SSM_STX
		global SSM_ETX
		global MyString
		
		if timetag: 
			if (SSM_STX == SSM.ValueEngr):            
				MyString = ""
			else:
				#Read data from msg to string
				if CH1.ValueEngr:
					MyString = MyString + chr(CH1.ValueEngr)
					
				if CH2.ValueEngr:
					MyString = MyString + chr(CH2.ValueEngr)

				if CH3.ValueEngr:
					MyString = MyString + chr(CH3.ValueEngr)

				if (SSM_ETX == SSM.ValueEngr):
					print "String = " + MyString
