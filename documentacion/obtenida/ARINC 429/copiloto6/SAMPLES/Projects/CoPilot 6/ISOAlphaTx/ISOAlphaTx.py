#	ISOAlphaTx.txt : COPILOT SCRIPT EXAMPLE
#
#	Copyright 1995-2011
#       
#	Ballard Technology, Inc.
#	11400 Airport Road Suite 201
#	Everett WA 98204
#	USA
#	(800) 829-1553
#	(425) 339-0281
#	(425) 339-0915 FAX
#	www.ballardtech.com
#	support@ballardtech.com
#
#	Databuses:	ARINC 429
#	Description:	Encodes user supplied strings into ISO
#			Alphabet No. 5 Messages 
#	Notes:
# 	1. Requires:
#		a. ISOMsg    - ARINC 429 Label 356 (ISO Alphabet No. 5)
#		b. WordCount - Field (ISO#5 Char, bits  9-16)
#		c. Spares    - Field (ISO#5 Char, bits 17-22)
#		d. CH1       - Field (ISO#5 Char, bits  9-15)
#		e. CH2       - Field (ISO#5 Char, bits 16-22)
#		f. CH3       - Field (ISO#5 Char, bits 23-29)
#  		g. SSM	     - Field (ISO#5 Char, bits 30-31)		
# 	2. Use a timer to allow other threads to run between messages
# 	3. Each data word can hold up to 3 characters from the string 
# 	4. Convert sample to use Label 357 by:
#		a. Change Spares to UnitAddress
#		b. Set UnitAddress in SetStandBy function
#

#Constants
SSM_INTERMEDIATE = 0   	#SSM for all data words except last
SSM_STX = 1               		#SSM for initial word   (Start Text)
SSM_ETX = 2               		#SSM for final word     (End Text)

#Globals
nWords = 0
nIndex = 0
nCount = 0
bDone = False
bTransmitting = False
Default = "<Enter Your String Here>"
Message = "Enter string to send or press Cancel to exit"
Title   = "CoPilot Script ISO Alphabet No. 5 Input"

#Initialize the test string to send
MyString = "Test ISO string to send. AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!"
 
#Functions
def SetStandBy():
	global SSM_STX
	WordCount.ValueEngr = 0
	Spares.ValueEngr    = 0  
	CH3.ValueEngr		= 2		#ASCII Character code for "STX" 
	SSM.ValueEngr       = SSM_STX

def BeginTx():
	global SSM_STX
	global MyString
	global nIndex
	global nWords
	global bTransmitting
	
	print "Sending: " + MyString
	nIndex = 0
	
	#Calc number of words needed to Tx MyString
	if (len(MyString) % 3):
		nWords = (len(MyString) / 3) + 1
	else:
		nWords = (len(MyString) / 3)

	#Temp Output
	print  "    String Length = " + str(len(MyString))
	print  "    Num Words     = " + str(nWords)

	#Format first message in transimision
	WordCount.ValueEngr = nWords
	Spares.ValueEngr	= 0 #always zero for Label 356
	CH3.ValueEngr		= 2 #ASCII Character code for "STX" 
	SSM.ValueEngr		= SSM_STX
	               
	#The next transmision will flag a start of text with WordCount = nWords
	bTransmitting = True

def OnProjectLoad():
	"""This function is called when a CoPilot Professional project is loaded"""
	print 'OnProjectLoad'

from time import time
def OnProjectRun():
	"""This function is called immediately after a CoPilot Professional project begins running.
	It is executed concurrently with the simulation of the project in its own separate thread."""
	InitEvents()
	print  ("BEGIN - script") 
	
	#Init message to stand-by mode 
	SetStandBy()
	   
	#Init others
	global bTransmitting
	bTransmitting = False
	global bDone  
	bDone = False
	global nWords 
	nWords = 0
	global nIndex 
	nIndex = 0
	global nCount
	global Default
	global MyString
	
	prevtime = time()
	while shell.Running:
		if (not bDone and not bTransmitting):
			#Input box disabled... MyString = InputBox(Message, Title, Default)
			MyString = MyString + str(nCount)
			nCount = nCount + 1
			if len(MyString):
				Default = MyString
				BeginTx()
			else:
				bDone = True
				print "DONE"
		CopWait(1)

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
		global SSM_ETX
		global SSM_INTERMEDIATE
		global bTransmitting
		global MyString
		global nIndex
		if timetag:
			if (SSM_ETX == SSM.ValueEngr):
				bTransmitting = False
				SetStandBy()
				return
			
			if bTransmitting:
				#write 3 characters to the data word 
				for i in range(1,4):
					charVal = ''
					if (nIndex < len(MyString)):
						charVal = MyString[nIndex:nIndex+1]
					else:
						charVal = '\0'
						
					if (i == 1):
						CH1.ValueEngr = ord(charVal)
					elif (i == 2):
						CH2.ValueEngr = ord(charVal)
					else:
						CH3.ValueEngr = ord(charVal)
						
					nIndex = nIndex + 1
			
				#set SSM    
				if (nIndex >= len(MyString)):
					#Tag for end of text
					SSM.ValueEngr = SSM_ETX
				else:
					SSM.ValueEngr = SSM_INTERMEDIATE

def CopWait(waitseconds):
	import time
	import pythoncom
	start = time.clock()
	while True:
		time.sleep(0)
		if (time.clock() - start) > waitseconds:
			return
		else:
			pythoncom.PumpWaitingMessages()