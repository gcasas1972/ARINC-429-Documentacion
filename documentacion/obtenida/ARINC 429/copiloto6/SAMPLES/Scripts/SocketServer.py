import pickle
import socket

HOST = ''					#Symbolic name meaning the local host
PORT = 50007				#Arbitrary non-privileged port
listener = None			#Global variable representing listener socket
connection = None		#Global variable representing client connection
readytowrite = False		#Global sentinel variable to control read/write flow

#This function is called when a CoPilot Professional project is loaded
def OnProjectLoad():
	print 'OnProjectLoad'

#This function is called immediately after a CoPilot Professional project begins running
#It is executed concurrently (own thread) with the simulation of the project
def OnProjectRun():
	global listener
	global connection
	global readytowrite

	InitEvents()

	#Set up the server
	print "Setting up server listener..."
	listener = socket.socket ( socket.AF_INET, socket.SOCK_STREAM )
	listener.bind((HOST, PORT))
	listener.listen(1)

	#Have the server serve "forever" while simulation is running
	print "Listening for a connection..."
	while shell.Running:
		if not connection:
			try:
				#Try to accept connection
				connection, details = listener.accept()
				print "Received connection:", details[0]
				readytowrite = True
			except:
				pass
		else:
			try:
				#Get client's response
				resp = connection.recv(1024)
				print "Server: client response is", resp
				readytowrite = True
			except:
				print "Server: client disconnected, shutting down..."
				connection.close()
				connection = None

#This function is called immediately after a CoPilot Professional project has stopped
def OnProjectStop():
	global connection
	global listener
	UninitEvents()
	if connection:
		print 'Killing the connection...'
		connection.shutdown(socket.SHUT_RDWR)
		connection.close()

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
	def OnMsgUpdate(self, datawords, cwd1, cwd2, swd1, swd2, errors, activity, timetag, timetagh, MsgRespTime1, MsgRespTime2):
		global readytowrite
		#If we have an open connection and it's ready to receive data, write to the socket
		if connection and readytowrite:
			sendList = [timetag,cwd1]
			pickledList = pickle.dumps(sendList)
			connection.send(pickledList)
			print "Server: sent object", sendList
			readytowrite = False