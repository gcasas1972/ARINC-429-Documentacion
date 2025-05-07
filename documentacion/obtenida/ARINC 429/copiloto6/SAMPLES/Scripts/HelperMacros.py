def PauseAll429Chans():
	'''Pause all 429 channels in the current project'''
	for card in shell.Cards:
		for chan429 in card.Chan429s:
			chan429.Pause = True

def PauseAll1553Chans():
	'''Pause all 1553 channels in the current project'''
	for card in shell.Cards:
		for chan1553 in card.Chan1553s:
			chan1553.Stop = True

def UnpauseAll429Chans():
	'''Unpause all 429 channels in the current project'''
	for card in shell.Cards:
		for chan429 in card.Chan429s:
			chan429.Pause = False

def UnpauseAll1553Chans():
	'''Unpause all 1553 channels in the current project'''
	for card in shell.Cards:
		for chan1553 in card.Chan1553s:
			chan1553.Stop = False

def PauseAllDataGenViews():
	'''Pause all Data Generators in the current project'''
	for view in shell.Views:
		if view.Description == u'DataGen View':
			view.PauseAll(True)

def UnpauseAllDataGenViews():
	'''Unpause all Data Generators in the current project'''
	for view in shell.Views:
		if view.Description == u'DataGen View':
			view.PauseAll(False)

def TransmitAllBCMsgs():
	'''Transmits all BC Messages in the current project and displays status words'''
	from time import sleep
	if not shell.Running:
		shell.Run()
	for card in shell.Cards:
		for chan1553 in card.Chan1553s:
			BC = chan1553.BC
			BC.Pause = True
			for BCMsg in BC.BCMsgs:
				BCMsg.TransmitMsg()
			sleep(2)
			for BCMsg in BC.BCMsgs:
				print "Message:", BCMsg.Name
				print "SW1:", str(BCMsg.MsgSwd1)
				if BCMsg.RTRTOpt:
					print "SW2:", str(BCMsg.MsgSwd2)
			BC.Pause = False
	shell.Stop()