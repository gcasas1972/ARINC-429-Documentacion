import pickle
import socket

client = None				#Global variable representing the connection

#Attempts to connect to the existing server socket
#Caller must provide the host name (or IP address) and port number
#This call will fail if the server isn't running
def Connect(host = 'localhost', portnum = 50007):
	global client
	#Create the connection
	client = socket.socket (socket.AF_INET, socket.SOCK_STREAM)
	client.settimeout(3)
	try:
		#Attempt to connect
		client.connect ((host, portnum))
		return "Client is connected!"
	except:
		return "Could not connect to server!"

#Attempts to read data from the existing connection
#If a connection doesn't exist or no data is ready, this call will fail
def Read():
	global client
	if not client:
		return "Connection not available!"
	else:
		#Attempt to retrieve and unpickle the list object:
		try:
			recvList =  pickle.loads (client.recv(1024))
			print "Client: received object", recvList
			client.send("ready")
		except:
			return "No data from server available, yet!"


def Disconnect():
	global client
	if client:
		print 'Disconnecting the client...'
		client.shutdown(socket.SHUT_RDWR)
		client.close()
	else:
		return "Connection not available!"