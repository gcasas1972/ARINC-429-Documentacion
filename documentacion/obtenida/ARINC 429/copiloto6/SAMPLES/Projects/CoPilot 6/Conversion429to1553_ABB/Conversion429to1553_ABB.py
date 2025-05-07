import math
import time
	
def OnProjectLoad():
	"""This function is called when a CoPilot Professional project is loaded"""
	print 'OnProjectLoad'

def OnProjectRun():
	"""This function is called immediately after a CoPilot Professional project begins running.
	It is executed concurrently with the simulation of the project in its own separate thread."""
	InitEvents()
	print 'OnProjectRun'
	
	#This will update the values of the SA every 2 seconds (useful if this is run without the proper hardware)
	while (shell.Running):
		UpdateSA()
		time.sleep(2)

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
	global SA_inst
	SA_inst = WithEvents(SA, SA_handler)

def UninitEvents():
	"""This function is responsible for uninitializing any event objects
	CoPilot will automatically add this code here when needed"""
	print 'Uninitializing event objects...'
	SA_inst.close()

def UpdateSA():
	"""This function updates the fields of the subaddress from the ARINC 429 RECEIVE messages"""
	print "a:  " + str(VelocityVert_429.ValueEngr)
	
	#Set angle degrees to semicircles
	Angle_1553.ValueEngr = Angle_429.ValueEngr / 180

	#Set longitude and latitude without any conversions
	Lat_1553.ValueEngr = Lat_429.ValueEngr
	Lon_1553.ValueEngr = Lon_429.ValueEngr

	#1553 Velocity = sqtr(x^2 + y^2)
	Velocity_1553.ValueEngr = math.sqrt((VelocityEW_429.ValueEngr)*(VelocityEW_429.ValueEngr) + (VelocityNS_429.ValueEngr)*(VelocityNS_429.ValueEngr))
	
	#Convert from ft/min to ft/sec
	VelocityVert_1553.ValueEngr = VelocityVert_429.ValueEngr / 60
	print "  b:" + str(VelocityVert_1553.ValueEngr)
	
class SA_handler:
	def OnSAUpdate(self, datawords, cwd1, cwd2, swd1, swd2, errors, activity, timetag, timetagh, MsgRespTime1, MsgRespTime2):
		#TODO: add your code here, then delete the following 'raise NotImplementedError' line.
		UpdateSA()

