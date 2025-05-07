from time import time, sleep

def OnProjectLoad():
	"""This function is called when a CoPilot Professional project is loaded"""
	print 'OnProjectLoad'

def OnProjectRun():
	"""This function is called immediately after a CoPilot Professional project begins running
	It is executed concurrently with the simulation of the project"""
	print 'OnProjectRun'
	InitEvents()

	#Initialize the aircraft dynamics
	AircraftDynamics1.ASPositionNorth = 0			#latitude
	AircraftDynamics1.ASPositionEast = 0				#longitude
	AircraftDynamics1.ASHeading = 45					#Initial heading
	AircraftDynamics1.ACType = 2						#Aircraft Type: 2=B747

	#Autopilot settings
	AircraftDynamics1.APHeadingHoldEngage = True
	AircraftDynamics1.APHeadingHold = 45			#AutoPiot Initial Heading
	AircraftDynamics1.APRollLimit = 10     				#Autopilot Roll limit
	AircraftDynamics1.APAltitudeHold = 35100     		#Autopilot initial Altitude
	AircraftDynamics1.APAltitudeHoldEngage = True
	AircraftDynamics1.APPitchLimit = 7				#Autopilot Pitch Limit

	print "Heading Hold =", AircraftDynamics1.APHeadingHold

	#Code here adjusts the autopilot parameters
	prevtime = time()
	while (shell.Running):
		curtime = time()
		#Change the headding every 22 seconds
		if curtime - prevtime > 22:
			prevtime = curtime
			#Increment the heading by 45 degrees
			HeadingVal = AircraftDynamics1.APHeadingHold + 45
			if HeadingVal >= 360:
				HeadingVal = HeadingVal - 360
			AircraftDynamics1.APHeadingHold = HeadingVal

			print "Heading Hold =", AircraftDynamics1.APHeadingHold

			#Have 2 different flight levels 35100 for heading <=180 and 28000 otherwise
			if HeadingVal <= 180:
				AircraftDynamics1.APAltitudeHold = 35100     	#Autopilot Altitude
			else:
				AircraftDynamics1.APAltitudeHold = 28000     	#Autopilot Altitude
		sleep(1)

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

def UninitEvents():
	"""This function is responsible for uninitializing any event objects
	CoPilot will automatically add this code here when needed"""
	print 'Uninitializing event objects...'
