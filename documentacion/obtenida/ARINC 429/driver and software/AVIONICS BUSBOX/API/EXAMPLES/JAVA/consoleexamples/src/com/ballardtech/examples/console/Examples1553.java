package com.ballardtech.examples.console;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintStream;
import java.util.Date;
import java.util.GregorianCalendar;

import com.ballardtech.BTICard;
import com.ballardtech.BTI1553;

public final class Examples1553 {

	private static final int CARDNUM = 0;
	private static final int MAX_CORES = 4;
	private static final int MAX_CHANNELS = 32;
	private static InputStream _pin;
	private static PrintStream _ps;
	
	private static void printf(String format, Object... args)
	{
		_ps.format(format, args);
	}

	public static int RunExample(String examplestr, InputStream pin, OutputStream pout)
	{
		int retval = 1;
		_pin = pin;
        _ps = new PrintStream(pout);
		
		if (examplestr.compareTo("Example 1") == 0)
			retval = example1();
		else if (examplestr.compareTo("Example 2") == 0)
			retval = example2();
		else if (examplestr.compareTo("Example 3") == 0)
			retval = example3();
		else if (examplestr.compareTo("Example 4") == 0)
			retval = example4();
		else if (examplestr.compareTo("Example 5") == 0)
			retval = example5();
		else if (examplestr.compareTo("Example 6") == 0)
			retval = example6();
		else if (examplestr.compareTo("Example 7") == 0)
			retval = example7();
		else if (examplestr.compareTo("Example 8") == 0)
			retval = example8();
		else if (examplestr.compareTo("Example 10") == 0)
			retval = example10();
		else if (examplestr.compareTo("Example 12") == 0)
			retval = example12();
		else if (examplestr.compareTo("Example 15") == 0)
			retval = example15();
		else if (examplestr.compareTo("Example 16") == 0)
			retval = example16();
		
		printf("\n***Example finished execution with exit code %d***\n", retval);
		
		//Attempts to flush the input buffer
		try {
			_pin.skip(_pin.available());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//Attempts to flush the output buffer
		System.out.flush();
		
		return retval;
	}
	
	/**
	*
	*  This example configures Card Number 0 as a BC to transmit
	*  the receive command 0843H with data words 1234H, 5678H,
	*  and 9ABCH.  If the message is completed successfully, it
	*  displays the responding RT's status word.  Otherwise it
	*  displays the value of any errors.
	*
	**/
	
	private static int example1()
	{
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum = 0;			/*Channel number*/
		
		BTI1553.XMITFIELDS1553 Msg = new BTI1553.XMITFIELDS1553();			/*Message structure*/

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP1  (06/09/2011)                                              *");
		printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 1                                                 *");
		printf("\n    *  \"Simulating the BC - Unscheduled Messages\"                        *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%d) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/
		
		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if ((errval != 0) || (corenum == MAX_CORES) || (channum == MAX_CHANNELS))
		{
			printf("\nError:  No MIL-STD-1553 channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);									/*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%d) while configuring bus",errval);
			printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create an empty frame in the BC Schedule.
	*
	*  BTI1553.BCTransmitMsg uses an asynchronous Message Record
	*  that is transmitted at the end of every frame.  Therefore,
	*  even though we aren't scheduling messages, we must still
	*  schedule a frame.
	*
	**/

		BTI1553.BCSchedFrame(1000,channum,hCore);

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Initialize the message command and data words, and select
	*  a BC-RT transfer.  Then transmit the message.
	*
	**/

		Msg.ctrlflags = BTI1553.MSGCRT1553_BCRT;			/*Selects BC-RT transfer*/
		Msg.cwd1      = BTI1553.ValPackCWD(1,0,2,3);		/*Receive command word*/
		Msg.data[0]   = 0x1234;								/*Data word 0*/
		Msg.data[1]   = 0x5678;								/*Data word 1*/
		Msg.data[2]   = 0x9ABC;								/*Data word 2*/

		errval = BTI1553.BCTransmitMsg(Msg,channum,hCore);	/*Transmit the message*/

	/**
	*
	*  Test for any error results.
	*
	*  Note the distinction between card errors and bus errors.
	*  The returned value of BTI1553.BCTransmitMsg is a card error
	*  (if any occurred).  Errors related to the RT's response are
	*  returned in the (errflags) member of the message
	*  structure.
	*
	**/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%d) while transmitting the message.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		if ((Msg.errflags & BTI1553.MSGERR1553_NORESP) != 0)		/*Was there a response?*/
		{
			printf("\nWarning:  No response was received from the RT.");
			printf("\n          Refer to the documentation for a");
			printf("\n          description of the error flags (%04Xh).", (int) Msg.errflags);
			printf("\n");
		}
		else if ((Msg.errflags & BTI1553.MSGERR1553_ANYERR) != 0)	/*Was there an error?*/
		{
			printf("\nWarning:  An error occurred while receiving the response from the RT.");
			printf("\n          Refer to the documentation for a");
			printf("\n          description of the error flags (%04Xh).", (int) Msg.errflags);
			printf("\n");
		}
		else										/*There were no errors*/
		{
			printf("\nSuccess!  The message was completed successfully.");
			printf("\n          The RT returned the status word %04Xh.", (int) Msg.swd1);
			printf("\n");
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);
		
		return(0);
	}
	
	/**
	*
	*  This example configures Card Number 0 as a bus controller
	*  to transmit a schedule of three messages.  The schedule is
	*  created in such a way that the messages are transmitted at
	*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
	*  and 40ms, respectively).
	*
	*  The program watches the 'hit' bit associated with the 0842H
	*  BC-RT message.  When the message is transmitted and the
	*  bit is set, the program updates the data words.
	*
	**/

	private static int example2()
	{
		final char CMD0		= 0x0843;			/*Command word for first message*/
		final char CMD1		= 0x0821;			/*Command word for second message*/
		final char RCV_CMD2	= 0x0821;			/*Receive command of an RT-RT transfer*/
		final char XMT_CMD2	= 0x1C21;			/*Transmit command of an RT-RT transfer*/
		final int FRAMETIME	= 10000;			/*Frame time in microseconds*/
		
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum = 0;			/*Channel number*/

		int BCMsgs[] = new int[3];
		long MsgErrors;
		char Data[] = new char[3];

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP2  (06/09/2011)                                              *");
		printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 2                                                 *");
		printf("\n    *  \"Simulating the BC - Scheduled Messages\"                          *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%d) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/
		
		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if ((errval != 0) || (corenum == MAX_CORES) || (channum == MAX_CHANNELS))
		{
			printf("\nError:  No MIL-STD-1553 channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");


	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);									/*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

		if (errval != 0)
		{
			printf("\nError:  An error was encountered (%d) while configuring bus",errval);
			printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create the message records for each of the three messages.
	*
	**/

		Data[0] = 0;
		Data[1] = 0;
		Data[2] = 0;

		BCMsgs[0] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD0,    (char) 0,Data,hCore);
		BCMsgs[1] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD1,    (char) 0,null,hCore);
		BCMsgs[2] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,null,hCore);

	/**
	*
	*  Schedule the messages to create the desired bus controller
	*  schedule.
	*
	**/

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],  channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[1],  channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[2],  channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],  channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],  channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[1],  channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],  channum,hCore);

	/**
	*
	*  Start the card to begin transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/
		
		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);

	/**
	*
	*  Watch the 'hit' bit of the first message to see if it has
	*  been transmitted.  If it has, update the data words.
	*
	**/

				MsgErrors = BTI1553.MsgFieldRd(BTI1553.FIELD1553_ERROR,BCMsgs[0],hCore);

				if ((MsgErrors & BTI1553.MSGERR1553_HIT) != 0)
				{
					Data[0] += 2;											/*Calculate the new data words*/
					Data[1] += 4;
					Data[2] += 6;

					BTI1553.MsgDataWr(Data,3,BCMsgs[0],hCore);				/*Write the new data words*/

					BTI1553.MsgFieldWr(0,BTI1553.FIELD1553_ERROR,BCMsgs[0],hCore);	/*Clear the 'hit' bit*/

					printf("\rTransmitting data {%04Xh, %04Xh, %04Xh}",(int) Data[0],(int) Data[1],(int) Data[2]);
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);		
		
		return(0);
	}
	
	/**
	*
	*  This example configures Card Number 0 as an RT to receive
	*  the BC-RT data transmitted by the bus controller in
	*  Example 2.
	*
	*  It continuously receives and displays the data words.
	*
	**/

	private static int example3()
	{
		
		
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum = 0;			/*Channel number*/

		int RTMsg;
		char Data[] = new char[32];

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP3  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 3                                                 *");
		printf("\n    *  \"Simulating an RT example.\"                                       *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for remote terminal mode.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI1553.RTConfig(BTI1553.RTCFG1553_DEFAULT,1,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Get the message address for a receive subaddress.
	*
	**/

		RTMsg = BTI1553.RTGetMsg(BTI1553.SUBADDRESS,1,BTICard.RCV,2,channum,hCore);

	/**
	*
	*  Start the card to begin responding to transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");

		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				BTI1553.MsgDataRd(Data,3,RTMsg,hCore);	/*Read data received from the BC*/

				printf("\rReceived data {%04XH, %04XH, %04XH}",(int) Data[0],(int) Data[1],(int) Data[2]);
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);
	}
	
	/**
	*
	*  This example configures Card Number 0 as a Bus Monitor
	*  terminal.  It prints the time-tag, command words (if any),
	*  and status words (if any) for each monitor record.
	*
	**/
	
	private static int example4()
	{
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/

		char[] seqbuf = new char[2048];
		long  seqcount;
		BTICard.SEQRECORD1553 pRec1553 = new BTICard.SEQRECORD1553();
		BTICard.SEQRECORDMORE1553 pRecMore1553 = new BTICard.SEQRECORDMORE1553();
		BTICard.SEQFINDINFO sfinfo = new BTICard.SEQFINDINFO();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP4  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 4                                                 *");
		printf("\n    *  \"Monitoring the bus example.\"                                     *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for monitor mode.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI1553.MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        monitor mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Configure the sequential record.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_DEFAULT,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        the sequential record on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start the card to begin monitoring messages.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Read the entire contents of the monitor and display the results.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");

		BTICard.LongRef blkcntref = new BTICard.LongRef();
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				seqcount = BTICard.SeqBlkRd(seqbuf,seqbuf.length,blkcntref,hCore);

				BTICard.SeqFindInit(seqbuf,seqcount,sfinfo);

				while(BTICard.SeqFindNext1553(pRec1553,sfinfo) == 0)
				{
					printf("\n");

					printf(" Ch:%d",(pRec1553.activity & BTI1553.MSGACT1553_CHMASK) >> BTI1553.MSGACT1553_CHSHIFT);
					printf(" Time:%d",pRec1553.timestamp);

					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVCWD1) != 0) printf(" Cwd1:%04X",(int) pRec1553.cwd1);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVCWD2) != 0) printf(" Cwd2:%04X",(int) pRec1553.cwd2);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVSWD1) != 0) printf(" Swd1:%04X",(int) pRec1553.swd1);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVSWD2) != 0) printf(" Swd2:%04X",(int) pRec1553.swd2);

					if ((pRec1553.error & BTI1553.MSGERR1553_NORESP) != 0) printf(" No response!");
					if ((pRec1553.error & BTI1553.MSGERR1553_ANYERR) != 0) printf(" Error!");

					if ((pRec1553.type & BTICard.SEQVER_MASK) >= BTICard.SEQVER_1)
					{
						if (BTICard.SeqFindMore1553(pRecMore1553, pRec1553) == 0)
						{
							printf(" RespTime1:%d",pRecMore1553.resptime1);
						}
					}
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		printf("\n");

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);		
	}
	
	/**
	*
	*  This example requires a Ballard 1553 C version Device or higher.
	*  It configures Card Number 0 as a BC, an RT, and a Bus Monitor.
	*  The BC transmits one BC-RT message (command word 0843H).
	*  The RT is configured with terminal address 1, so the
	*  simulated RT receives the simulated BC's transmissions.
	*  The data words transmitted by the RT are incremented and
	*  displayed.  The data words received by the RT are read and
	*  also displayed.
	*
	**/
	
	private static int example5()
	{
		final int FRAMETIME = 10000;/*Frame time in microseconds*/
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum = 0;			/*Channel number*/
		
		int BCMsg;
		int RTMsg;
		char[] BCData = new char[3];
		char[] RTData = new char[3];

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP5  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 5                                                 *");
		printf("\n    *  \"Simultaneous BC, RT, and monitor simulation example.\"            *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core with level M, C or D capability.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553.ChGetInfo(BTI1553.INFO1553_MULTIMODE,channum,hCore) != 0) break;
			}

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 level M, C or D channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);                                       /*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);     /*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        bus controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a bus controller message and insert into the bus
	*  controller schedule.
	*
	**/

		BCMsg = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,(char) 0x0843,(char) 0,BCData,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsg,channum,hCore);

	/**
	*
	*  Configure the channel for remote terminal mode as shown in
	*  Example 3.
	*
	**/

		errval = BTI1553.RTConfig(BTI1553.RTCFG1553_DEFAULT,1,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Get the message address for a receive subaddress.
	*
	**/

		RTMsg = BTI1553.RTGetMsg(BTI1553.SUBADDRESS,1,BTICard.RCV,2,channum,hCore);

	/**
	*
	*  Configure the channel for monitor mode as shown in Example 4.
	*
	**/

		errval = BTI1553.MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        monitor mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI1553.MonFilterTA(0x00000002,channum,hCore);	/*Monitor RT address 1*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring the",errval);
			printf("\n        monitor filter on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Configure the sequential record.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_DEFAULT,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring the",errval);
			printf("\n        sequential record on on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start the card to begin transmitting, receiving and monitoring messages.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				printf("\r");

				BCData[0] += 2;		/*Update the data that the BC is transmitting*/
				BCData[1] += 4;
				BCData[2] += 6;

				printf("Transmitting data {%04XH, %04XH, %04XH} ",(int) BCData[0],(int) BCData[1],(int) BCData[2]);

				BTI1553.MsgDataWr(BCData,3,BCMsg,hCore);

				BTI1553.MsgDataRd(RTData,3,RTMsg,hCore);	/*Read the data received by the RT*/

				printf("Received data {%04XH, %04XH, %04XH} ",(int) RTData[0],(int) RTData[1],(int) RTData[2]);
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);	
	}
	
	/**
	*
	*  This example requires a Ballard 1553 C version Device or higher.
	*  It configures Card Number 0 as a BC and transmits a single
	*  receive command containing a parity error in the command
	*  word.
	*
	*  A No response is expected because of the parity error in the
	*  command word.
	*
	**/
	
	private static int example6()	
	{
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/

		BTI1553.XMITFIELDS1553 Msg = new BTI1553.XMITFIELDS1553();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP6  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 6                                                 *");
		printf("\n    *  \"Errors in BC Transmissions - Unscheduled Messages\"               *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and C or D version channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553.ChGetInfo(BTI1553.INFO1553_ERRORGEN,channum,hCore) != 0) break;
			}

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 version C or D channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);                                       /*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);     /*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        bus controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create an empty frame in the BC Schedule.
	*
	*  BTI1553.BCTransmitMsg uses an asynchronous Message Record
	*  that is transmitted at the end of every frame.  Therefore,
	*  even though we aren't scheduling messages, we must still
	*  schedule a frame.
	*
	**/

		BTI1553.BCSchedFrame(1000,channum,hCore);

	/**
	*
	*  Initialize the message command and data words, and select
	*  a BC->RT transfer.
	*
	**/

		Msg.ctrlflags	= BTI1553.MSGCRT1553_BCRT;
		Msg.cwd1		= 0x0843;
		Msg.data[0]		= 0x1234;
		Msg.data[1]		= 0x5678;
		Msg.data[2]		= 0x9ABC;

	/**
	*
	*  Define the type of error generation.
	*
	**/

		errval = BTI1553.ErrorDefine(BTI1553.ERRDEF1553_PAR,(char) 0,0,BTI1553.ERRDEF1553_CWD1,0,channum,hCore);
		errval = BTI1553.ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_ANYMSG,channum,hCore);

	/**
	*
	*  Start the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Transmit the message.
	*
	**/

		errval = BTI1553.BCTransmitMsg(Msg,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while transmitting",errval);
			printf("\n        the message on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Test for any error results. No response is the expected result.
	*
	**/

		if ((Msg.errflags & BTI1553.MSGERR1553_NORESP) != 0)           /*Was there a response?*/
		{
			printf("\nWarning:  No response was received from the RT.");
			printf("\n          Refer to the documentation for a");
			printf("\n          description of the error flags (%04XH).",(int) Msg.errflags);
			printf("\n");
		}
		else if ((Msg.errflags & BTI1553.MSGERR1553_ANYERR) != 0)      /*Was there an error?*/
		{
			printf("\nWarning:  An error occurred while receiving the response from the RT.");
			printf("\n          Refer to the documentation for a");
			printf("\n          description of the error flags (%04XH).",(int) Msg.errflags);
			printf("\n");
		}
		else                                            /*There were no errors*/
		{
			printf("\nSuccess!  The message was completed successfully.");
			printf("\n          The RT returned the status word %04XH.",(int) Msg.swd1);
			printf("\n");
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);	
	}

	/**
	*
	*  This example requires a Ballard 1553 C version Device or higher.
	*  It configures Card Number 0 as a BC and creates a schedule
	*  containing a receive command each for terminal address 1
	*  and terminal address 2.  Both receive commands send 2 data
	*  words to the remote terminal.  The example then alternates
	*  a bit count error between the first data word of both
	*  commands.
	*
	**/
	
	private static int example7()	
	{
		final int FRAMETIME = 10000;/*Frame time in microseconds*/
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/

		int[] BCMsgs = new int[2];
		int     ErrorCount = 0;
		char[]  InitialData1 = null;
		char[]  InitialData2 = null;

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP7  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 7                                                 *");
		printf("\n    *  \"Errors in BC Transmissions - Scheduled Messages\"                 *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and C or D version channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553.ChGetInfo(BTI1553.INFO1553_ERRORGEN,channum,hCore) != 0) break;
			}

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 version C or D channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);                                       /*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);     /*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        bus controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create the message records.
	*
	**/

		BCMsgs[0] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,(char) 0x0842,(char) 0,InitialData1,hCore);
		BCMsgs[1] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,(char) 0x1042,(char) 0,InitialData2,hCore);

	/**
	*
	*  Schedule the messages to create the desired bus controller
	*  schedule.
	*
	**/

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[1],channum,hCore);

	/**
	*
	*  Define the type of error generation.  One of the bus
	*  controller messages is tagged to generate errors once.
	*
	**/

		BTI1553.ErrorDefine(BTI1553.ERRDEF1553_CNTBIT,(char) 3,2,0,0,channum,hCore);
		BTI1553.ErrorTagBC(true,BCMsgs[0],channum,hCore);
		BTI1553.ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG,channum,hCore);

	/**
	*
	*  Start the card to begin transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
	/**
	*
	*  When the error is generated once, tag another message for
	*  error generation and enable another single error.
	*
	**/

				if (BTI1553.ErrorSent(channum,hCore) /*AND ANOTHER ERROR DESIRED*/)
				{
					if (((++ErrorCount) & 1) != 0)
					{
						BTI1553.ErrorTagBC(false,BCMsgs[0],channum,hCore);
						BTI1553.ErrorTagBC(true, BCMsgs[1],channum,hCore);
					}
					else
					{
						BTI1553.ErrorTagBC(true, BCMsgs[0],channum,hCore);
						BTI1553.ErrorTagBC(false,BCMsgs[1],channum,hCore);
					}

					BTI1553.ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG,channum,hCore);
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);
	}

	/**
	*
	*  This example requires a Ballard 1553 C version Device or higher.
	*  It configures Card Number 0 as an RT and configures a response
	*  time error for transmit commands of subaddress 2.  Each time the
	*  subaddress is accessed, the response time is incremented by
	*  0.1us.
	*
	**/
	
	private static int example8()	
	{
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/

		char GapLength;				/*Gap in units of 0.1us*/

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP8  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 8                                                 *");
		printf("\n    *  \"Errors in RT Transmissions\"                                      *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and C or D version channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553.ChGetInfo(BTI1553.INFO1553_ERRORGEN,channum,hCore) != 0) break;
			}

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 version C or D channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for remote terminal mode.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI1553.RTConfig(BTI1553.RTCFG1553_DEFAULT,1,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Define the type and location of the gap.
	*
	**/

		GapLength = 120;                    /*Set initial gap length to 12us (Each GapLength=0.1 microseconds)*/

		BTI1553.ErrorDefine(BTI1553.ERRDEF1553_GAP,    /*Generate a gap*/
							GapLength,         /*Set the length of the gap*/
							0,                 /*Unused parameter*/
							BTI1553.ERRDEF1553_SWD1,   /*Gap precedes the status word*/
							0,                 /*Unused parameter*/
							channum,           /*Channel number*/
							hCore);

		BTI1553.ErrorTagRT(true,BTI1553.SUBADDRESS,1,BTICard.XMT,2,channum,hCore);
		BTI1553.ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG,channum,hCore);

	/**
	*
	*  Start the card to begin responding to transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				if (BTI1553.ErrorSent(channum,hCore) /*AND ANOTHER ERROR DESIRED*/)
				{
					BTI1553.ErrorDefine(BTI1553.ERRDEF1553_GAP,   /*Change the length of the gap*/
									++GapLength,          /*Set the length of the new gap*/
									0,                    /*Unused parameter*/
									BTI1553.ERRDEF1553_SWD1,      /*Gap precedes the status word*/
									0,                    /*Unused parameter*/
									channum,              /*Channel number*/
									hCore);

					BTI1553.ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG,channum,hCore);
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);	
	}
	
	/**
	*
	*  This example configures Card Number 0 as a bus controller
	*  to transmit a schedule of three messages.  The schedule is
	*  created in such a way that the messages are transmitted at
	*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
	*  and 40ms, respectively).
	*
	*  The schedule is also configured to generate an Event Log List
	*  entry after each 10ms frame.  When an entry is read from the list,
	*  the data words associated with the 0843H BC-RT message is updated.
	*
	**/

	private static int example10()	
	{
		final char CMD0		= 0x0843;			/*Command word for first message*/
		final char CMD1		= 0x0821;			/*Command word for second message*/
		final char RCV_CMD2	= 0x0821;			/*Receive command of an RT-RT transfer*/
		final char XMT_CMD2	= 0x1C21;			/*Transmit command of an RT-RT transfer*/

		final int FRAMETIME = 10000;			/*Frame time in microseconds*/
		
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum = 0;			/*Channel number*/

		int[] BCMsgs = new int[3];
		char[] Data = new char[3];

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP10  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 10                                                *");
		printf("\n    *  \"Polling the Event Log List\"                                      *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);                                       /*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);     /*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring bus",errval);
			printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create the message records for each of the three messages.
	*
	**/

		Data[0] = 0;
		Data[1] = 0;
		Data[2] = 0;

		BCMsgs[0] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD0,    (char) 0,       Data,hCore);
		BCMsgs[1] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD1,    (char) 0,       null,hCore);
		BCMsgs[2] = BTI1553.BCCreateMsg(BTI1553.MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,		null,hCore);

	/**
	*
	*  Schedule the messages to create the desired bus controller
	*  schedule.  Also schedule an Event Log after each frame.
	*  Note the unique tag value associated with each Event Log
	*  that could be used to distinguish unique Events.
	*
	**/

		BTI1553.BCSchedFrame(FRAMETIME,           channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],             channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[1],             channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[2],             channum,hCore);
		BTI1553.BCSchedLog(BTI1553.COND1553_ALWAYS,(char) 0x1111,channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,           channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],             channum,hCore);
		BTI1553.BCSchedLog(BTI1553.COND1553_ALWAYS,(char) 0x2222,channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,           channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],             channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[1],             channum,hCore);
		BTI1553.BCSchedLog(BTI1553.COND1553_ALWAYS,(char) 0x3333,channum,hCore);

		BTI1553.BCSchedFrame(FRAMETIME,           channum,hCore);
		BTI1553.BCSchedMsg(BCMsgs[0],             channum,hCore);
		BTI1553.BCSchedLog(BTI1553.COND1553_ALWAYS,(char) 0x4444,channum,hCore);

	/**
	*
	*  Configure the Event Log list.
	*
	**/

		errval = BTICard.EventLogConfig(BTICard.LOGCFG_ENABLE,1024,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        event log list on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start the card to begin transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		printf("\nPress any key to exit....\n\n");
		
		BTICard.CharRef typeref = new BTICard.CharRef();
		BTICard.LongRef inforef = new BTICard.LongRef();
		BTICard.IntRef chanref = new BTICard.IntRef();

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				if (BTICard.EventLogRd(typeref,inforef,chanref,hCore) != 0)
				{
					/*Calculate the new data words*/
					Data[0] += 2;
					Data[1] += 4;
					Data[2] += 6;

					/*Write the new data words*/
					BTI1553.MsgDataWr(Data,3,BCMsgs[0],hCore);

					printf("\rTransmitting data {%04XH, %04XH, %04XH}",(int) Data[0],(int) Data[1],(int) Data[2]);
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);
	}
	
	/**
	*
	*  This example configures Card Number 0 as a bus controller
	*  to transmit a schedule of one message.  The message is
	*  transmitted at a frequency of 10Hz (or every 100ms).
	*
	*  A FIFO of 100 entries is configured for the message.
	*  Before staring the card, the FIFO is filled with unique
	*  sets of data words.  After the card is started, the
	*  program continually pushes new sets of data into the FIFO
	*  until the program stops.
	*
	**/
	
	private static int example12()	
	{
		final char CMD = 0x0820;				/*Command word for message*/

		final int FRAMETIME = 100000;			/*Frame time in microseconds*/
		
		int hCard;					/*Handle to card*/
		int hCore=0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/

		int BCList;
		char[] Data = new char[32];
		int Result;
		int j;

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP12  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 12                                                *");
		printf("\n    *  \"BC Transmission of Ramping Data Using a FIFO\"                    *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for bus controller mode.
	*
	**/

		BTICard.CardReset(hCore);                                       /*Reset the core*/

		errval = BTI1553.BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);     /*Configure the core*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring bus",errval);
			printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create the FIFO List Buffer.
	*
	**/

		BCList = BTI1553.BCCreateList(
			BTI1553.LISTCRT1553_FIFO,               /*List creation flags*/
			100,                                    /*List size*/
			BTI1553.MSGCRT1553_DEFAULT,             /*Message creation flags*/
			CMD,                                    /*Command Word 1*/
			(char) 0,                               /*Command Word 2*/
			null,                                   /*Initial data (if any)*/
			hCore);                                 /*Device handle*/

	/**
	*
	*  Schedule the messages to create the desired bus controller
	*  schedule.
	*
	**/

		BTI1553.BCSchedFrame(FRAMETIME,channum,hCore);
		BTI1553.BCSchedMsg(BCList,     channum,hCore);

	/**
	*
	*  Fill the FIFO with the initial data.
	*
	**/

		for (j=0;j<32;++j) Data[j]=0;

		do
		{
			printf("\nWrote data value %04XH.",(int) Data[0]);
			Result = BTI1553.ListDataWr(Data,32,BCList,hCore);
			++Data[0];
		} while(Result != 0);

	/**
	*
	*  Start the card to begin transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Loop until a key is hit.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");
	
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);

				do
				{
					Result = BTI1553.ListDataWr(Data,32,BCList,hCore);
				} while(Result != 0);

				printf("\nwrote data value %04XH.  Press any key to exit.",(int) Data[0]);

				++Data[0];
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);	
	}
	
	/**
	*
	*  This example configures Card Number 0 as a Bus Monitor
	*  terminal.  It prints the time-tag (in IRIG format),
	*  command words (if any), and status words (if any) for each
	*  monitor record.
	*
	**/	
	
	private static int example15()	
	{
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/
		boolean	timetagIsBCD;

		char[] seqbuf = new char[2048];
		long seqcount;
		BTICard.SEQRECORD1553 pRec1553 = new BTICard.SEQRECORD1553();
		BTICard.SEQRECORDMORE1553 pRecMore = new BTICard.SEQRECORDMORE1553();
		BTICard.SEQFINDINFO sfinfo = new BTICard.SEQFINDINFO();

		BTICard.BTIIRIGTIME irigtime = new BTICard.BTIIRIGTIME();
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP15  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2003-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 15                                                *");
		printf("\n    *  \"IRIG Timer example (bus monitor).\"                               *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
				if (BTI1553.ChIs1553(channum,hCore) != 0) break;

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No MIL-STD-1553 channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing MIL-STD-1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for monitor mode.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI1553.MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        monitor mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Configure the sequential record.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_DEFAULT,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        the sequential record on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/receiver)
	*  Sequential monitor will store IRIG time in sequential records
	*
	**/

		errval = BTICard.IRIGConfig(BTICard.IRIGCFG_DEFAULT,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        the IRIG timer on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		timetagIsBCD = (BTICard.TIMETAG_FORMAT_BCD == BTICard.TimerStatus(hCore)) ? true : false;
	
	/**
	*
	*  Synchronize the on core IRIG timer with the computer local time
	*
	**/

		GregorianCalendar gc = new GregorianCalendar();
		gc.setTime(new Date());

		irigtime.days  = gc.get(GregorianCalendar.DAY_OF_YEAR) - 1;	/* Day of year (0 - 365; January 1 = 0) */
		irigtime.hours = gc.get(GregorianCalendar.HOUR_OF_DAY);		/* Hours after midnight (0 - 23) */
		irigtime.min   = gc.get(GregorianCalendar.MINUTE);			/* Minutes after hour (0 - 59) */
		irigtime.sec   = gc.get(GregorianCalendar.SECOND);			/* Seconds after minute (0 - 59) */
		irigtime.msec  = 0;											/* The gc structure does not include milliseconds. */
		irigtime.usec  = 0;											/* The gc structure does not include microseconds. */

		errval = BTICard.IRIGWr(irigtime,hCore);
		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while writing",errval);
			printf("\n        the IRIG time on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\n\nStart Time:%02d:%02d %02d.%03d.%03d \n",
				irigtime.hours,
				irigtime.min,
				irigtime.sec,
				irigtime.msec,
				irigtime.usec);

	/**
	*
	*  Start the card to begin receiving messages.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Read the entire contents of the monitor and display the results.
	*
	**/

		BTICard.LongRef irigvalhref = new BTICard.LongRef(); 
		BTICard.LongRef irigvallref = new BTICard.LongRef();
		
		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");

		BTICard.LongRef blkcntref = new BTICard.LongRef();
		
		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);
				
				/* Empty entire contents of sequential monitor into a buffer. */
				seqcount = BTICard.SeqBlkRd(seqbuf,2048,blkcntref,hCore);

				BTICard.SeqFindInit(seqbuf,seqcount,sfinfo);

				while(BTICard.SeqFindNext1553(pRec1553,sfinfo) == 0)
				{
					/* Get extended data for this record. */
					BTICard.SeqFindMore1553(pRecMore,pRec1553);

					if (!timetagIsBCD)
					{
						//Convert binary timetag to BCD
						BTICard.IRIGTimeBinToBCD(irigvalhref,
												 irigvallref,
												 pRecMore.timestamph,
												 pRec1553.timestamp);
						
						pRecMore.timestamph = irigvalhref.getValue();
						pRec1553.timestamp = irigvallref.getValue();
					}

					printf("\n");

					printf(" Ch:%02d",(pRec1553.activity & BTI1553.MSGACT1553_CHMASK) >> BTI1553.MSGACT1553_CHSHIFT);
					printf(" Time:%02d:%02d %02d.%03d.%03d    ",
							BTICard.IRIGFieldGetHours(   pRecMore.timestamph, pRec1553.timestamp),
							BTICard.IRIGFieldGetMin(     pRecMore.timestamph, pRec1553.timestamp),
							BTICard.IRIGFieldGetSec(     pRecMore.timestamph, pRec1553.timestamp),
							BTICard.IRIGFieldGetMillisec(pRecMore.timestamph, pRec1553.timestamp),
							BTICard.IRIGFieldGetMicrosec(pRecMore.timestamph, pRec1553.timestamp));

					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVCWD1) != 0) printf(" Cwd1:%04X",(int) pRec1553.cwd1);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVCWD2) != 0) printf(" Cwd2:%04X",(int) pRec1553.cwd2);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVSWD1) != 0) printf(" Swd1:%04X",(int) pRec1553.swd1);
					if ((pRec1553.activity & BTI1553.MSGACT1553_RCVSWD2) != 0) printf(" Swd2:%04X",(int) pRec1553.swd2);

					if ((pRec1553.error & BTI1553.MSGERR1553_NORESP) != 0) printf(" No response!");
					if ((pRec1553.error & BTI1553.MSGERR1553_ANYERR) != 0) printf(" Error!");
				}
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);	
	}
	
	/**
	*
	*  This example configures Card Number 0 as an RT to receive
	*  the BC-RT data transmitted by the bus controller in
	*  Example 2. The programmable RT response time is set and then
	*  controlled by the up and down arrow keys. The program runs
	*  until the ESC key is pressed.
	*
	**/
	
	private static int example16()	
	{
		final int MAX_RESPTIME = 255;
		final int MIN_RESPTIME = 77;
		
		int hCard;					/*Handle to card*/
		int hCore = 0;				/*Handle to core*/
		int errval;					/*Error return value*/
		int corenum;				/*Core number*/
		int channum=0;				/*Channel number*/
		int ch;

		int resptime;
		boolean done;

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP16  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2003-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI1553 Example 16                                                *");
		printf("\n    *  \"RT Response Time example.\"                                       *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n");

	/**
	*
	*  Open the card with the specified card number.
	*  An error value is returned which is tested
	*  to determine if an error occurred.
	*
	**/

		BTICard.IntRef lpHandle = new BTICard.IntRef();
		errval = BTICard.CardOpen(lpHandle,CARDNUM);
		hCard = lpHandle.getValue();

		if (errval != 0)
		{
			printf("\nError:  Either card number %d is not present, or",CARDNUM);
			printf("\n        an error occurred (%i) opening the card.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			return(1);
		}

		printf("\nUsing BTI1553 card #%d",CARDNUM);

	/**
	*
	*  Find the first MIL-STD-1553 core and channel that supports
	*  programmable RT response time.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553.ChIs1553(channum,hCore) != 0)
				{
					if (BTI1553.ChGetInfo(BTI1553.INFO1553_RTRESPTIME,channum,hCore) != 0)	break;
				}
			}

			if (channum != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || channum == MAX_CHANNELS)
		{
			printf("\nError:  No 1553 channels that support programmable RT");
			printf("\n        response time present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing MIL-STD-1553 core #%d",corenum);
		printf("\nUsing programmable RT response time 1553 channel #%d",channum);
		printf("\n");

	/**
	*
	*  Configure the channel for remote terminal mode.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI1553.RTConfig(BTI1553.RTCFG1553_DEFAULT,1,channum,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring for",errval);
			printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Set the Programmable RT Response Time
	*
	**/

		resptime = 80;
		errval = BTI1553.RTResponseTimeSet(resptime,1,channum,hCore);
		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while setting the",errval);
			printf("\n        RT response time on channel #%d on core #%d.",channum,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start the card to begin receiving messages.
	*
	**/

		BTICard.CardStart(hCore);
		
	/**
	*
	*  Change response time values when arrow keys are pressed. Exit when ESC is pressed.
	*
	**/

		printf("\n\tOPTIONS:");
		printf("\n\tA  = Add 10 to resptime");
		printf("\n\tZ  = Subtract 10 from resptime");
		printf("\n\tQ  = exit program");
		printf("\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		for (done=false;!done;)
		{
			printf("\r\tresptime: %03X (Hex)",resptime);
			try {
				Thread.sleep(100);
				if (br.ready())
				{
					ch = br.read();

					switch (ch)
					{
						case 'Q':
						case 'q':
						{
							done=true;
							break;
						}
						case 'A':
							ch = 'a';
						case 'a':
						case 'Z':
						case 'z':
						{
							if (ch=='a')	resptime = (resptime+10>MAX_RESPTIME) ? MAX_RESPTIME : resptime+10;
							else        resptime = (resptime-10<MIN_RESPTIME) ? MIN_RESPTIME : resptime-10;

							BTI1553.ChStop(channum,hCore);

							errval = BTI1553.RTResponseTimeSet(resptime,1,channum,hCore);
							if (errval < 0)
							{
								printf("\nError:  An error was encountered (%i) while setting the",errval);
								printf("\n        RT response time on channel #%d on core #%d.",channum,corenum);
								printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
								printf("\n");
								done=true;
							}

							BTI1553.ChStart(channum,hCore);

							break;
						}
					}
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

	/**
	*
	*  Stop the card.
	*
	**/

		BTICard.CardStop(hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);
	}
}
