#This sample project uses CoPilot ATE with Python scripting to control the discrete IO
#Available with the OmniBus Discrete Module. This will display a walking bit pattern
#On an LED control representing the state of 8 discretes in one of the discrete banks

from ctypes import *
from time import sleep

BANKCFGDIO_SHUNT = 0x00000004			#Select shunt mode (in)
BANKCFGDIO_INOUT = 0x00000002			#Select concurrent input and output mode (in & out)
BANKCFGDIO_POLIN_INV = 0x00000100L		#Enable polarity inversion for bank input (in)
THRESHOLDDIO_2_5V = 0x01B0				#Corresponds to a 2.5V switching threshold
SAMPLERATEDIO_MS = 0x8000				#Corresponds to a 1ms base sample clock

CARDNUM = 1
MAX_CORES = 4
MAX_BANKS = 4

#Get the dlls using windll from the ctypes module
bticard = windll.bticard
btidio = windll.btidio

#Create handles to card and core
hCard = c_int()
hCore = c_int()

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently with the simulation of the project
def OnProjectRun():
	InitEvents()

	err = bticard.BTICard_CardOpen(byref(hCard),CARDNUM)
	if err:
		print "Could not open card #", CARDNUM
		return

	corenum = 0
	banknum = 0
	#Find the first core with a DIO bank.
	while corenum < MAX_CORES:
		err = bticard.BTICard_CoreOpen(byref(hCore),corenum,hCard);
		if err:
			break
		while banknum <  MAX_BANKS:
			if btidio.BTIDIO_BankIsDIO(banknum,hCore):
				break
			banknum+=1
		if banknum != MAX_BANKS:
			break
		corenum+=1
		banknum=0

	if err or (corenum == MAX_CORES) or (banknum == MAX_BANKS):
		print  "Error:  No DIO banks present in card #", CARDNUM
		bticard.BTICard_CardClose(hCard);
		return

	print "Using DIO core #", corenum;
	print "Using Bank", banknum

	#Configure banknum as a shunt, input/output bank
	bankcfg = BANKCFGDIO_SHUNT | BANKCFGDIO_INOUT | BANKCFGDIO_POLIN_INV
	err = btidio.BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_2_5V,SAMPLERATEDIO_MS | 0x0001, banknum, hCore);

	if err:
		print "Error:	An error was encountered (%i) while configuring" % err
		print "	bank %i on core #%d." % (banknum,corenum)
		print "(%s)" % bticard.BTICard_ErrDescStr(err,hCard)
		return

	#Configure the LED control
	LEDCtrl1.Direction = 1		#Backwards
	LEDCtrl1.Mode = 1			#Bitwise mode
	LEDCtrl1.NumLEDs = 8		#8 LEDs
	LEDCtrl1.Orientation = 0	#Horizontal

	#Start operation of the card
	bticard.BTICard_CardStart(hCore);

	#Read Bank and Display the State of its Discretes every second
	output=0
	while shell.Running:
		output%=256
		btidio.BTIDIO_BankWr(output,banknum,hCore);
		input = btidio.BTIDIO_BankRd(banknum,hCore)
		LEDCtrl1.Value = input
		sleep(1)		#Wait for one second
		output+=1

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	#Stop the discrete core
	bticard.BTICard_CardStop(hCore);
	UninitEvents()

#This function is called when a CoPilot Professional project is closed
def OnProjectClose():
	print 'OnProjectClose'

#This function is responsible for initializing any event objects
#CoPilot will automatically add this code here when needed
def InitEvents():
	print 'Initializing event objects...'

#This function is responsible for uninitializing any event objects
#CoPilot will automatically add this code here when needed
def UninitEvents():
	print 'Uninitializing event objects...'