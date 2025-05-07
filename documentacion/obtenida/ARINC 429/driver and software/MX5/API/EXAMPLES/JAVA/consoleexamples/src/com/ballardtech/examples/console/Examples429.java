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
import com.ballardtech.BTI429;

public class Examples429 {
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
		else if (examplestr.compareTo("Example 8") == 0)
			retval = example8();
		else if (examplestr.compareTo("Example 12") == 0)
			retval = example12();
		else if (examplestr.compareTo("Example 13") == 0)
			retval = example13();
		else if (examplestr.compareTo("Example 14") == 0)
			retval = example14();
		else if (examplestr.compareTo("Example 15") == 0)
			retval = example15();
		else if (examplestr.compareTo("Example 16") == 0)
			retval = example16();
		else if (examplestr.compareTo("Example 17") == 0)
			retval = example17();
		
		printf("\n***Example finished execution with exit code %d***\n", retval);
		
		//Attempts to flush the input buffer
		try {
			_pin.skip(_pin.available());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return retval;
	}

	/**
	*
	*  This program opens Card Number 0, and configures the
	*  first compatible core to receive 2 GPS messages into
	*  separate Message Records, and receive all other
	*  messages into a default Message Record.
	*
	**/
	
	private static int example1()
	{
		int hCard;
		int hCore;
		int errval;
		int corenum;
		int rcvchan;
		BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP1  (06/09/2011)                                              *");
		printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 1                                                  *");
		printf("\n    *  \"Program for receiver example.\"                                   *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with a receive channel.
	*
	**/

		rcvchan=0;
		hCore=0;
		
		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTI429.ChIsRcv(rcvchan,hCore)) break;

			if (rcvchan != MAX_CHANNELS) break;
		}

		if ((errval != 0) || (corenum == MAX_CORES) || (rcvchan == MAX_CHANNELS))
		{
			printf("\nError:  No ARINC 429 receive channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\n");

	/**
	*
	*  Configure receiver channel for automatic speed detection.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED,rcvchan,hCore);

		if (errval != 0)
		{
			printf("\nError:  An error was encountered (%e) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  First, the default filter is
	*  created.  Then, two filters are set for the two messages
	*  of interest.
	*
	**/

		msgdefault.addr = BTI429.FilterDefault(BTI429.MSGCRT429_DEFAULT,rcvchan,hCore);
		latitude.addr   = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0310,BTI429.SDIALL,rcvchan,hCore);
		longitude.addr  = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0311,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);
				
				/*Read message records*/
				msgdefault.data = BTI429.MsgDataRd(msgdefault.addr,hCore);
				latitude.data   = BTI429.MsgDataRd(latitude.addr,hCore);
				longitude.data  = BTI429.MsgDataRd(longitude.addr,hCore);

				/*Display values*/
				printf("\r");
				printf("Default=%08X ",msgdefault.data);
				printf("Latitude=%08X ",latitude.data);
				printf("Longitude=%08X",longitude.data);
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
*  This program opens Card Number 0; and configures the
*  first compatible core to build a transmit schedule
*  using transmit interval information, and then transmit
*  the messages with changing data.
*
**/

	private static int example2()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int xmtchan=0;
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		long[] bnr_data = new long[3];

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP2  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 2                                                  *");
		printf("\n    *  \"Program for transmitter example.\"                                *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first 429 core with a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429.ChIsXmt(xmtchan,hCore))	break;

			if (xmtchan != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
		{
			printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure xmtchan to transmit at high speed.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_HIGHSPEED,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Initialize the three Message Records.
	*
	**/

		comp_airspeed.data = BTI429.FldPutLabel(0L,(short) 0206);     /*Init label field*/
		tot_air_temp.data  = BTI429.FldPutLabel(0L,(short) 0211);
		altitude_rate.data = BTI429.FldPutLabel(0L,(short) 0212);

		comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,0L,(short) 14,(short) 0);     /*Init BNR data*/
		tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,0L,(short) 11,(short) 0);
		altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,0L,(short) 16,(short) 0);

		BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
		BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

	/**
	*
	*  Start operation of the card.
	*
	**/

		errval = BTICard.CardStart(hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while starting",errval);
			printf("\n        card #%d / core #%d.",CARDNUM,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Change data until a key is pressed.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);
				
				comp_airspeed.data = BTI429.MsgDataRd(comp_airspeed.addr,hCore);   /*Read messages back*/
				tot_air_temp.data  = BTI429.MsgDataRd(tot_air_temp.addr,hCore);
				altitude_rate.data = BTI429.MsgDataRd(altitude_rate.addr,hCore);

				bnr_data[0] = BTI429.BNRGetMant(comp_airspeed.data,(short) 14);   /*Extract BNR data*/
				bnr_data[1] = BTI429.BNRGetMant(tot_air_temp.data,(short) 11);
				bnr_data[2] = BTI429.BNRGetMant(altitude_rate.data,(short) 16);

				++bnr_data[0];   /*Change BNR data*/
				++bnr_data[1];
				++bnr_data[2];

				comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,bnr_data[0],(short) 14,(short) 0);   /*Put BNR data*/
				tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,bnr_data[1],(short) 11,(short) 0);    /*back into*/
				altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,bnr_data[2],(short) 16,(short) 0);   /*messages*/

				BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);   /*Write new message values*/
				BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
				BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);
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
	*  This program opens Card Number 0, finds the first
	*  compatible core, builds a transmit schedule using
	*  transmit interval information, and creates filters
	*  for two receive messages.  It also enables the
	*  Sequential Monitor to record transmitted and
	*  received messages.
	*
	**/
	
	private static int example3()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		char[] seqbuf = new char[2048];
		long seqcount;
		BTICard.SEQRECORD429 pRec429 = new BTICard.SEQRECORD429();
		BTICard.SEQFINDINFO sfinfo = new BTICard.SEQFINDINFO();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP3  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 3                                                  *");
		printf("\n    *  \"Program for monitor example.\"                                    *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan for automatic speed detection.
	*  Configure xmtchan to transmit at low speed.
	*
	*  Record all of xmtchan data into the Sequential Record.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SEQALL,xmtchan,hCore);      /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Initialize the three Message Records.
	*
	**/

		comp_airspeed.data = BTI429.FldPutLabel(0L,(short) 0206);   /*Init label field*/
		tot_air_temp.data  = BTI429.FldPutLabel(0L,(short) 0211);
		altitude_rate.data = BTI429.FldPutLabel(0L,(short) 0212);

		comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,0L,(short) 14,(short) 0);   /*Init BNR data*/
		tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,0L,(short) 11,(short) 0);
		altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,0L,(short) 16,(short) 0);

		BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
		BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  First, the default filter is
	*  created.  Then, two filters are set for the two messages
	*  of interest.
	*
	*  Record the two filtered messages.
	*
	**/

		msgdefault.addr = BTI429.FilterDefault(BTI429.MSGCRT429_DEFAULT,rcvchan,hCore);
		latitude.addr   = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0310,BTI429.SDIALL,rcvchan,hCore);
		longitude.addr  = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0311,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Configure the Sequential Monitor for continuous mode.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_DEFAULT,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		BTICard.LongRef blkcntref = new BTICard.LongRef();
		
		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);

				seqcount = BTICard.SeqBlkRd(seqbuf,seqbuf.length,blkcntref,hCore);
				
				BTICard.SeqFindInit(seqbuf,seqcount,sfinfo);

				while(BTICard.SeqFindNext429(pRec429,sfinfo) == 0)
				{
					printf("\nCore:%d  Ch:%02d  Data:%08X  Time Stamp:%08X",
						   corenum,
						   ((pRec429.activity & BTI429.MSGACT429_CHMASK) >> BTI429.MSGACT429_CHSHIFT),
						   pRec429.data,
						   pRec429.timestamp);

					if ((pRec429.type & BTICard.SEQVER_MASK) >= BTICard.SEQVER_1)
					{
						printf("  decgap:%X",pRec429.decgap);
					}
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
	*  This program opens Card Number 0, finds the first
	*  compatible core, and builds a transmit schedule
	*  using explicit message timing. The self-test
	*  wraparound is enabled and filters are set to
	*  receive the messages.  The minimum and maximum elapsed
	*  time for each message is displayed.
	*
	**/
	
	private static int example4()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 xmt_altitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 rcv_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 rcv_altitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGFIELDS429 airspeed_record = new BTI429.MSGFIELDS429();
		BTI429.MSGFIELDS429 altitude_record = new BTI429.MSGFIELDS429();
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP4  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 4                                                  *");
		printf("\n    *  \"Program for explicit message timing.\"                            *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{

			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan to receive at low speed with the
	*  Min/Max Elapse Time option also enabled.
	*  Note that the self-test wraparound is also enabled.
	*
	*  Configure xmtchan to transmit at low speed.
	*  Note that the self-test wraparound is also enabled.
	*  The external line drivers are disabled, and xmtchan is
	*  connected internally to all the receive channels.
	*
	**/

		BTICard.CardReset(hCore);                   /*Reset the card*/

		errval = BTI429.ChConfig(BTI429.CHCFG429_MAXMIN|BTI429.CHCFG429_SELFTEST,rcvchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SELFTEST,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  Two filters are set for the
	*  two messages of interest.
	*
	**/

		rcv_airspeed.addr = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0206,BTI429.SDIALL,rcvchan,hCore);
		rcv_altitude.addr = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0212,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		xmt_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		xmt_altitude.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Next, a schedule is built by creating explicit message timing.
	*
	**/

		BTI429.SchedMsg(xmt_altitude.addr,xmtchan,hCore);
		BTI429.SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
		BTI429.SchedGap(495,xmtchan,hCore);
		BTI429.SchedMsg(xmt_altitude.addr,xmtchan,hCore);
		BTI429.SchedGap(531,xmtchan,hCore);

	/**
	*
	*  Those messages that are to be transmitted are initialized.
	*
	**/

		BTI429.MsgDataWr(0x0000008A,xmt_altitude.addr,hCore);
		BTI429.MsgDataWr(0x00000086,xmt_airspeed.addr,hCore);

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);

				BTI429.MsgBlockRd(airspeed_record,rcv_airspeed.addr,hCore);
				BTI429.MsgBlockRd(altitude_record,rcv_altitude.addr,hCore);

				printf("\r");

				printf("AirSpeed: min/max=%2dms/%2dms ",
				(airspeed_record.mintime / 1000),
				(airspeed_record.elapsetime_maxtime / 1000));

				printf("Altitude: min/max=%2dms/%2dms ",
				(altitude_record.mintime / 1000),
				(altitude_record.elapsetime_maxtime / 1000));

				printf("         ");
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
	*  This program opens the Card Number 0, finds the first
	*  compatible core, and configures transmit and receive
	*  list buffers.  The program transmits one message filled
	*  with ramping data in the associated list buffer.  The
	*  receive list buffer is read and displays the data to the
	*  screen.
	*
	**/
	
	private static int example5()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		long j;
		BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 rcv_airspeed = new BTI429.MSGSTRUCT429();
		int xmtlistaddr, rcvlistaddr;
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP5  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 5                                                  *");
		printf("\n    *  \"Program for transmit and receive list buffers.\"                  *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;
			
			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan for automatic speed detection with
	*  the self-test wraparound enabled.
	*  Configure xmtchan to transmit at low speed with
	*  the self-test wraparound enabled.
	*
	**/

		BTICard.CardReset(hCore);            /*Reset the card*/

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED|BTI429.CHCFG429_SELFTEST,rcvchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SELFTEST,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.
	*
	**/

		rcv_airspeed.addr = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0206,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		xmt_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Next, a schedule is built by creating explicit message timing.
	*
	**/

		BTI429.SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
		BTI429.SchedGap(1218,xmtchan,hCore);

	/**
	*
	*  Create the transmit and receive list buffers.
	*
	*  The transmit list buffer will be a circular buffer,
	*  which means it should be preloaded with data, and
	*  it will continuously transmit that data.
	*
	*  The receive list buffer will be a FIFO, which we will
	*  read out of and display to the screen.
	*
	**/

		xmtlistaddr = BTI429.ListXmtCreate(BTI429.LISTCRT429_CIRCULAR,256,xmt_airspeed.addr,hCore);
		rcvlistaddr = BTI429.ListRcvCreate(BTI429.LISTCRT429_FIFO,16,rcv_airspeed.addr,hCore);

	/**
	*
	*  Initialize the transmit list buffer.
	*
	**/

		for (j=0x00000;j<0x1000000;j+=0x10000)
		{
			BTI429.ListDataWr((0x00000086 | j),xmtlistaddr,hCore);
		}

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);

				rcv_airspeed.data = BTI429.ListDataRd(rcvlistaddr,hCore);

				if (rcv_airspeed.data != 0) printf("\rAirSpeed=%08X ",rcv_airspeed.data);
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
	*  This program opens the Card Number 0, finds the first
	*  compatible core, and configures an asynchronous transmit
	*  list buffer. The program transmits one label synchronously
	*  in a schedule, and transmits another label each time the
	*  spacebar is hit by the user.
	*
	**/
	
	private static int example6()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int xmtchan=0;
		boolean done;
		boolean xmtstat = false;
		int xmtcount = 0;
		BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
		int asynclistaddr;	
		int ch;
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP6  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 6                                                  *");
		printf("\n    *  \"Program for asynchronous list buffer.\"                           *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429.ChIsXmt(xmtchan,hCore))	break;

			if (xmtchan != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
		{
			printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure xmtchan to transmit at low speed.
	*
	**/

		BTICard.CardReset(hCore);							/*Reset the card*/

		errval = BTI429.ChConfig(BTI429.CHCFG429_DEFAULT,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the synchronous labels we are transmitting.
	*
	**/

		xmt_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Create the asynchronous list buffer.
	*
	**/

		asynclistaddr = BTI429.ListAsyncCreate(BTI429.LISTCRT429_FIFO,16,xmtchan,hCore);

	/**
	*
	*  Next, a schedule is built by creating explicit message timing.
	*  While creating a schedule we can still use the SchedGap() function
	*  to create our gap times.  This function will determine that an
	*  asynchronous list buffer has been created for the channel, and will
	*  internally call the SchedGapList() function with appropriate parameters.
	*  Alternatively, we could use the SchedGapList() function directly
	*  and specify the address value ourselves. This method is useful if
	*  more than one asynchronous list buffer is desired per channel.
	*
	**/

		BTI429.SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
		BTI429.SchedGap(1218,xmtchan,hCore);                            //This line, and
//		BTI429.SchedGapList(1218,asynclistaddr,xmtchan,hCore);          //this line, do the same thing.

	/**
	*
	*  The asynchronous message needs to be initialized.
	*
	**/

		BTI429.MsgDataWr(0x00000086,xmt_airspeed.addr,hCore);

	/**
	*
	*  Start operation of the card.
	*
	**/

		errval = BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress spacebar to transmit the asynchronous message, press Q to exit....\n\n");
		printf("\nAsynchronous transmission count: %4d",xmtcount);

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		for (done=false;!done;)
		{
			try {
				Thread.sleep(100);
				if (br.ready())
				{
					ch = br.read();
					
					switch(ch)
					{
						case ' ':
							xmtstat = BTI429.ListDataWr(0x0000008A,asynclistaddr,hCore);
							if (xmtstat) xmtcount++;
							printf("\rAsynchronous transmission count: %4d",xmtcount);
							break;
						case 'Q':
						case 'q':
							done=true;
							break;
						default:
							break;
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

	/**
	*
	*  This program opens Card Number 0, finds the first
	*  compatible core, and configures the first receive
	*  channel to receive 2 GPS messages into separate
	*  Message Records; and receive all other messages
	*  into a default Message Record.
	*
	*  Each of the messages is also configured to generate an
	*  Event Log List entry.  When an entry is read from the list,
	*  the associated data is read.
	*
	**/	
	
	private static int example8()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int msgaddr;
		BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP8  (10/23/2009)                                              *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 8                                                  *");
		printf("\n    *  \"Polling the Event Log List.\"                                     *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with a receive channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;
			
			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTI429.ChIsRcv(rcvchan,hCore)) break;

			if (rcvchan != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
		{
			printf("\nError:  No ARINC 429 receive channels present in cardnum %d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan for automatic speed detection.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

		if (errval != 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  First, the default filter is
	*  created.  Then, two filters are set for the two messages
	*  of interest.
	*
	*  Each message is configured to create Event Log list entries.
	*
	**/

		msgdefault.addr = BTI429.FilterDefault(BTI429.MSGCRT429_LOG,rcvchan,hCore);
		latitude.addr   = BTI429.FilterSet(BTI429.MSGCRT429_LOG,0310,BTI429.SDIALL,rcvchan,hCore);
		longitude.addr  = BTI429.FilterSet(BTI429.MSGCRT429_LOG,0311,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Initialize data values to zero.
	*
	**/

		msgdefault.data = 0;
		latitude.data   = 0;
		longitude.data  = 0;

	/**
	*
	*  Configure the Event Log list.
	*
	**/

		errval = BTICard.EventLogConfig(BTICard.LOGCFG_ENABLE,1024,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        the event log list on core #%d.",corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		printf("\nPress any key to exit....\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  

		BTICard.CharRef typeref = new BTICard.CharRef();
		BTICard.LongRef inforef = new BTICard.LongRef();
		BTICard.IntRef chanref = new BTICard.IntRef();

		try {
			while(br.ready() == false)
			{
				Thread.sleep(100);

				if (BTICard.EventLogRd(typeref,inforef,chanref,hCore) != 0)	//Read entry from Event Log list
				{
					msgaddr = (int) inforef.getValue();								//Info value is message address

					if (msgaddr == msgdefault.addr)
					{
						msgdefault.data = BTI429.MsgDataRd(msgaddr,hCore);
					}
					else if (msgaddr == latitude.addr)
					{
						latitude.data = BTI429.MsgDataRd(msgaddr,hCore);
					}
					else if (msgaddr == longitude.addr)
					{
						longitude.data = BTI429.MsgDataRd(msgaddr,hCore);
					}
				}

				printf("\r");
				printf("Default=%08X " ,msgdefault.data);
				printf("Latitude=%08X ",latitude.data);
				printf("Longitude=%08X",longitude.data);
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
	*  This program opens Card Number 0, finds the first
	*  compatible core, and enable the IRIG timer. A transmit
	*  schedule is built using explicit message timing. The
	*  self-test wraparound is enabled and filters are set to
	*  receive the messages. A time-tag, minimum and maximum elapsed
	*  time for each message is converted from the IRIG time and
	*  displayed.
	*
	**/
	
	private static int example12()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		boolean timetagIsBCD;
		BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 rcv_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGFIELDS429 airspeed_record = new BTI429.MSGFIELDS429();
		BTICard.BTIIRIGTIME irigtime = new BTICard.BTIIRIGTIME();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP12  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 12                                                 *");
		printf("\n    *  \"Program for IRIG timer example.\"                                 *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan to receive at low speed with the
	*  Min/Max Elapse Time option also enabled.
	*  Note that the self-test wraparound is also enabled.
	*
	*  Configure xmtchan to transmit at low speed.
	*  Note that the self-test wraparound is also enabled.
	*  The external line drivers are disabled, and xmtchan is
	*  connected internally to all the receive channels.
	*
	**/

		BTICard.CardReset(hCore);                   /*Reset the card*/

		errval = BTI429.ChConfig(BTI429.CHCFG429_MAXMIN|BTI429.CHCFG429_SELFTEST,rcvchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SELFTEST,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.
	*
	**/

		rcv_airspeed.addr = BTI429.FilterSet(BTI429.MSGCRT429_DEFAULT,0206,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		xmt_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Next, a schedule is built by creating explicit message timing.
	*
	**/

		BTI429.SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
		BTI429.SchedGap(1100,xmtchan,hCore);

	/**
	*
	*  Those messages that are to be transmitted are initialized.
	*
	**/

		BTI429.MsgDataWr(0x00000086,xmt_airspeed.addr,hCore);

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

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		BTICard.LongRef irigvalhref = new BTICard.LongRef(); 
		BTICard.LongRef irigvallref = new BTICard.LongRef();

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");

		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);

				BTI429.MsgBlockRd(airspeed_record,rcv_airspeed.addr,hCore);

				if (!timetagIsBCD)
				{
					//Convert binary timetag to BCD
					BTICard.IRIGTimeBinToBCD(irigvalhref,
							 				 irigvallref,
											 airspeed_record.timetagh,
											 airspeed_record.timetag_hitcount);
					
					airspeed_record.timetagh = irigvalhref.getValue();
					airspeed_record.timetag_hitcount = irigvallref.getValue();
				}

				printf("\r");

				printf("TT: %02d:%02d %02d.%03d.%03d    ",
						BTICard.IRIGFieldGetHours(airspeed_record.timetagh,airspeed_record.timetag_hitcount),
						BTICard.IRIGFieldGetMin(airspeed_record.timetagh,airspeed_record.timetag_hitcount),
						BTICard.IRIGFieldGetSec(airspeed_record.timetagh,airspeed_record.timetag_hitcount),
						BTICard.IRIGFieldGetMillisec(airspeed_record.timetagh,airspeed_record.timetag_hitcount),
						BTICard.IRIGFieldGetMicrosec(airspeed_record.timetagh,airspeed_record.timetag_hitcount));

				printf("AirSpeed: min/max=%02dms/%02dms ",
						BTICard.IRIGFieldGetMillisec(0x0000, airspeed_record.mintime),
						BTICard.IRIGFieldGetMillisec(0x0000, airspeed_record.elapsetime_maxtime));

				printf("    ");
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
	*  This program opens Card Number 0, finds the first
	*  compatible core, builds a transmit schedule using
	*  transmit interval information, and creates filters
	*  for two receive messages.  It also enables the
	*  Sequential Monitor to record transmitted and
	*  received messages using DMA mode.
	*
	**/
	
	private static int example13()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		char[] seqbuf = new char[32768];
		long seqcount;
		BTICard.SEQRECORD429 pRec429 = new BTICard.SEQRECORD429();
		BTICard.SEQFINDINFO sfinfo = new BTICard.SEQFINDINFO();

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP13  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2001-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 13                                                 *");
		printf("\n    *  \"Program for monitor DMA example.\"                                *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan for automatic speed detection.
	*  Configure xmtchan to transmit at low speed.
	*
	*  Record all of xmtchan data into the Sequential Record.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SEQALL,xmtchan,hCore);      /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Initialize the three Message Records.
	*
	**/

		comp_airspeed.data = BTI429.FldPutLabel(0L,(short) 0206);   /*Init label field*/
		tot_air_temp.data  = BTI429.FldPutLabel(0L,(short) 0211);
		altitude_rate.data = BTI429.FldPutLabel(0L,(short) 0212);

		comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,0L,(short) 14,(short) 0);   /*Init BNR data*/
		tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,0L,(short) 11,(short) 0);
		altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,0L,(short) 16,(short) 0);

		BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
		BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  First, the default filter is
	*  created.  Then, two filters are set for the two messages
	*  of interest.
	*
	*  Record the two filtered messages.
	*
	**/

		msgdefault.addr = BTI429.FilterDefault(BTI429.MSGCRT429_DEFAULT,rcvchan,hCore);
		latitude.addr   = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0310,BTI429.SDIALL,rcvchan,hCore);
		longitude.addr  = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0311,BTI429.SDIALL,rcvchan,hCore);

	/**
	*
	*  Configure the Sequential Monitor for continuous DMA mode.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_DEFAULT | BTICard.SEQCFG_DMA,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Start operation of the card.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Display data on the screen.
	*
	**/

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		printf("\nPress any key to exit....\n\n");

		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);

				seqcount = BTICard.SeqDMARd(seqbuf,seqbuf.length,hCore);

				BTICard.SeqFindInit(seqbuf,seqcount,sfinfo);

				while(BTICard.SeqFindNext429(pRec429,sfinfo) == 0)
				{
					printf("\nCore:%d  Ch:%02d  Data:%08X  Time Stamp:%08X",
						   corenum,
						   ((pRec429.activity & BTI429.MSGACT429_CHMASK) >> BTI429.MSGACT429_CHSHIFT),
						   pRec429.data,
						   pRec429.timestamp);

					if ((pRec429.type & BTICard.SEQVER_MASK) >= BTICard.SEQVER_1)
					{
						printf("  decgap:%X",pRec429.decgap);
					}
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
	*  This is a utility function example program and does not access
	*  any Device hardware. This program will recreate Table 6-2 "BNR
	*  DATA ENCODING EXAMPLES" from the ARINC SPECIFICATION 429, PART 1.
	*
	*  NOTE: This example is intended to recreate a specific page in the
	*  ARINC specification. As such, the ARINC data is presented verbatim.
	*  When operating Ballard hardware, the ARINC label should be
	*  presented in human readable order, NOT ARINC order as this table
	*  shows. See the BTI429 Programming Manual for more details.
	*
	**/
	
	private static int example14()
	{
		long msg;

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP14  (10/21/2009)                                             *");
		printf("\n    *  Copyright 2004-2009  Ballard Technology, Inc.  Everett, WA, USA.  *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 14                                                 *");
		printf("\n    *  \"Program to get BNR from ARINC words\"                             *");
		printf("\n    *                                                                    *");
		printf("\n    **********************************************************************");
		printf("\n\n");

		printf("\t\t\t\tTable 6-2\n");
		printf("\t\t\tBNR DATA ENCODING EXAMPLES\n\n");

		printf("\tPARAMETER\t  (Label)\tMSG\t\tRESULT\n");
		printf("    ----------------------------------------------------------------------\n");

		msg = 0x60000002l;
		printf(" %30s","Selected Course (100)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRAngularGetValDbl(msg, (short) 12, true));
		printf(" Deg.\n");

		msg = 0x6D550082l;
		printf(" %30s","Selected Heading (101)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRAngularGetValDbl(msg, (short) 12, true));
		printf(" Deg.\n");

		msg = 0xEA028042l;
		printf(" %30s","Selected Altitude (102)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 16, 1.0));
		printf(" Ft.\n");

		msg = 0x6D3800C2l;
		printf(" %30s","Selected Airspeed (103)");
		printf("\t\t%08X",msg);
		printf("\t%.1f",example14helpers.BNRGetValDbl(msg, (short) 11, 0.25));
		printf(" Knots\n");

		msg = 0xFDD80022l;
		printf(" %30s","Selected Vertical Speed (104)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 10, 16.0));
		printf(" Ft/Min\n");

		msg = 0xE3200062l;
		printf(" %30s","Selected Mach (106)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 12, 1.0));
		printf(" m Mach.\n");

		msg = 0x78720032l;
		printf(" %30s","Desired Track (114)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRAngularGetValDbl(msg, (short) 12, false));
		printf(" Deg.\n");

		msg = 0xE6600072l;
		printf(" %30s","Cross Track Distance (116)");
		printf("\t\t%08X",msg);
		printf("\t%.1f",example14helpers.BNRGetValDbl(msg, (short) 15, 0.004));
		printf(" NM\n");

		msg = 0x64B000F2l;
		printf(" %30s","Vertical Deviation (117)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 11, 1.0));
		printf(" Ft.\n");

		msg = 0xE2AB0006l;
		printf(" %30s","Flight Director Roll (140)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRAngularGetValDbl(msg, (short) 12, true));
		printf(" Deg.\n");

		msg = 0xF0E40086l;
		printf(" %30s","Flight Director Pitch (141)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRAngularGetValDbl(msg, (short) 12, true));
		printf(" Deg.\n");

		msg = 0x67800046l;
		printf(" %30s","Fast/Slow (142)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 12, 0.008));
		printf(" Knots\n");

	/*	msg = 0x6972A016l;
		printf(" %30s","Greenwich Mean Time (150)");
		printf("\t\t%08X",msg);
		printf("\t(%f)",example14helpers.BNRGetValDbl(msg, 12, 0.0178125));
		printf("\n");
	*/
		msg = 0x64C9002El;
		printf(" %30s","Radio Height (164)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 16, 0.125));
		printf(" Ft.\n");

		msg = 0xE0D800DEl;
		printf(" %30s","Localizer Deviation (173)");
		printf("\t\t%08X",msg);
		printf("\t%1.03f",example14helpers.BNRGetValDbl(msg, (short) 12, 0.0001));
		printf(" DDM\n");

		msg = 0xFD80003El;
		printf(" %30s","Glide Slope Deviation (174)");
		printf("\t\t%08X",msg);
		printf("\t%1.03f",example14helpers.BNRGetValDbl(msg, (short) 12, 0.0002));
		printf(" Deg.\n");

		msg = 0x680EE041;
		printf(" %30s","DME Distance (202)");
		printf("\t\t%08X",msg);
		printf("\t%1.2f",example14helpers.BNRGetValDbl(msg, (short) 16, 0.008));
		printf(" NM\n");

		msg = 0x657E40C1l;
		printf(" %30s","Altitude (29.92) (203)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 17, 1.0));
		printf(" Ft.\n");

		msg = 0x634080A1l;
		printf(" %30s","Mach (205)");
		printf("\t\t%08X",msg);
		printf("\t%1.4f",example14helpers.BNRGetValDbl(msg, (short) 16, 0.0000625));
		printf(" Mach\n");

		msg = 0xE6A40061l;
		printf(" %30s","Computed Airspeed (206)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 14, 0.0625));
		printf(" Knots\n");

		msg = 0x646A0011l;
		printf(" %30s","True Airspeed (210)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 15, 0.0625));
		printf(" Knots\n");

		msg = 0x606800D1l;
		printf(" %30s","Static Air Temp (213)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 11, 0.25));
		printf(" Deg. C\n");

		msg = 0x7F320091l;
		printf(" %30s","Total Air Temp (211)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 11, 0.25));
		printf(" Deg. C\n");

		msg = 0x788E0051l;
		printf(" %30s","Altitude Rate (212)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 11, 16.0));
		printf(" Ft/Min\n");

		msg = 0xE73EA813l;
		printf(" %30s","Present Pos. Lat. (310)");
		printf("\t\t%08X",msg);
		printf("\tN %.1f",example14helpers.BNRGetValDbl(msg, (short) 20, 0.000172));
		printf(" Deg\n");

		msg = 0x7716C093l;
		printf(" %30s","Present Pos. Long. (311)");
		printf("\t\t%08X",msg);
		printf("\tW %.1f",example14helpers.BNRGetValDbl(msg, (short) 20, 0.000172));
		printf("\n");

		msg = 0xE28A0053l;
		printf(" %30s","Ground Speed (312)");
		printf("\t\t%08X",msg);
		printf("\t%.0f",example14helpers.BNRGetValDbl(msg, (short) 15, 0.125));
		printf(" Knots\n");

		msg = 0x6A0500CBl;
		printf(" %30s","Flight Path Accel (323)");
		printf("\t\t%08X",msg);
		printf("\t%1.2f",example14helpers.BNRGetValDbl(msg, (short) 12, 0.001));
		printf(" g\n");

		printf("\n\n");

		return(0);
	}

	private static class example14helpers
	{
		/********************************
		*
		*	BNR
		*
		*********************************/

		static double BNRGetValDbl(long msg,short sigbit,double dblResolution)
		{
			double dblResult;

			dblResult = BTI429.BNRGetMant(msg, sigbit) * dblResolution;

			if (BTI429.BNRGetSign(msg) != 0)	dblResult = -dblResult;

			return(dblResult);
		}

		static long BNRPutValDbl(double dblVal, long msg,short sigbit,double dblResolution)
		{
			long ulResult;
			long mantissa;
			short bNegative;

			bNegative = (short) ((0>dblVal) ? 1:0);									//Record if value is negative

			if (bNegative != 0)	dblVal = -dblVal;							//If negative, make positive

			mantissa = (long) (dblVal / dblResolution);						//Scale to remove decimal

			ulResult = BTI429.BNRPutMant(msg, mantissa, sigbit, bNegative);	//Fold in original message

			return(ulResult);
		}

		/********************************
		*
		*	BNR Angular
		*
		*********************************/

		static double BNRAngularGetValDbl(long msg, short sigbit, boolean bPlusMinus180)
		{
			double dblResult;
			double dblResolution;

			dblResolution = 180.0;
			dblResolution /= (1<<sigbit);

			dblResult = example14helpers.BNRGetValDbl(msg, sigbit, dblResolution);

			if (!bPlusMinus180 && 0>dblResult)	dblResult = dblResult + 360.0;

			return(dblResult);
		}

		static long BNRAngularPutValDbl(double dblVal, long msg, short sigbit)
		{
			long ulResult;
			double dblResolution;

			dblResolution = 180.0;
			dblResolution /= (1<<sigbit);

			if (dblVal > 180)	dblVal = dblVal - 360;

			ulResult = example14helpers.BNRPutValDbl(dblVal, msg, sigbit, dblResolution);

			return(ulResult);
		}		
	}
	
	/**
	*
	*  This program opens Card Number 0 and configures the
	*  first compatible core to build a transmit schedule
	*  using transmit interval information, and then prints
	*  the schedule to the screen.
	*
	**/
	
	private static int example15()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int xmtchan=0;
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP15  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2009  Ballard Technology, Inc.  Everett, WA, USA.       *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 15                                                 *");
		printf("\n    *  \"Print a transmit schedule\"                                       *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first 429 core with a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429.ChIsXmt(xmtchan,hCore))	break;

			if (xmtchan != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
		{
			printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure xmtchan to transmit at high speed.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_HIGHSPEED,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Output the results of the Schedule Build operation
	*
	**/

		printf("\nARINC 429 schedule for channel #%d",xmtchan);
		printf("\n");
		printf("\nBEGIN");

		example15helpers.SchedDumpAll(xmtchan,hCore);

	/**
	*
	*  The card MUST be closed before exiting the program.
	*
	**/

		BTICard.CardClose(hCard);

		return(0);
	}

	private static class example15helpers
	{
	    public static final int OPCODE429_NOP = 0x0000;         	 //Halt
	    public static final int OPCODE429_MSG = 0x0001;  			//Message
	    public static final int OPCODE429_GAP = 0x0002;  			//Gap
	    public static final int OPCODE429_LIST = 0x0003;  			//Conditional Gap - do list buffer
	    public static final int OPCODE429_HALT = 0x0004;  			//Halt
	    public static final int OPCODE429_USER = 0x0005;  			//User code
	    public static final int OPCODE429_PULSE0 = 0x0006;  		//Clear DOUT
	    public static final int OPCODE429_PULSE1 = 0x0007;  		//Set DOUT
	    public static final int OPCODE429_PAUSE = 0x0008;  			//Pause
	    public static final int OPCODE429_RESTART = 0x0009;  		//Restart
	    public static final int OPCODE429_LOGCOND = 0x000A;  		//Log event on condition
	    public static final int OPCODE429_CALLCOND = 0x000B;  		//Call conditional
	    public static final int OPCODE429_RETURN = 0x000C;  		//Return from call
	    public static final int OPCODE429_BRANCHCOND = 0x000D;  	//Branch on condition
		
		/**
		*
		*  This helper function decodes a command block and
		*  prints the details.
		*
		**/

		static void SchedDump(char cmdblk[],int handleval)
		{
			int msgaddr;
			BTI429.MSGFIELDS429 msgfields = new BTI429.MSGFIELDS429();

			if ((cmdblk[0] & 0xFF) > OPCODE429_BRANCHCOND) return;

			switch(cmdblk[0] & 0xFF)
			{
				case OPCODE429_NOP:            printf("%-14s ","NOP");         break;	//Nothing
				case OPCODE429_MSG:            printf("%-14s ","MSG");         break;	//Message
				case OPCODE429_GAP:            printf("%-14s ","GAP");         break;	//Gap
				case OPCODE429_LIST:           printf("%-14s ","LIST");        break;	//List
				case OPCODE429_HALT:           printf("%-14s ","HALT");        break;	//Halt
				case OPCODE429_USER:           printf("%-14s ","USER");        break;	//Pause
				case OPCODE429_PULSE0:         printf("%-14s ","PULSE0");      break;	//Clear DIO
				case OPCODE429_PULSE1:         printf("%-14s ","PULSE1");      break;	//Set DIO
				case OPCODE429_PAUSE:          printf("%-14s ","PAUSE");       break;	//Pause
				case OPCODE429_RESTART:        printf("%-14s ","RESTART");     break;	//Restart
				case OPCODE429_LOGCOND:        printf("%-14s ","LOGCOND");     break;	//Event log conditional
				case OPCODE429_CALLCOND:       printf("%-14s ","CALLCOND");    break;	//Call conditional
				case OPCODE429_RETURN:         printf("%-14s ","RETURN");      break;	//Return from call
				case OPCODE429_BRANCHCOND:     printf("%-14s ","BRANCHCOND");  break;	//Branch conditional
				default: break;
			}

			if ((cmdblk[0] & 0x4000) != 0) printf("			 ");
			if ((cmdblk[0] & 0x2000) != 0) printf("SHOT ");

			switch(cmdblk[0] & 0xFF)
			{
				case OPCODE429_MSG:
				{
					printf("msgaddr=%04X%04X gap=%04X",(int) cmdblk[1],(int) cmdblk[2],(int)cmdblk[3]);
					msgaddr = (int) BTICard.MakeLong(cmdblk[1],cmdblk[2]);
					BTI429.MsgBlockRd(msgfields,msgaddr,handleval);
					printf(" data=%08X opt=%04X",msgfields.msgdata_listptr,(int) msgfields.msgopt);
					break;
				}
				case OPCODE429_GAP:        printf("gap=%04X",(int) cmdblk[1]); break;
				case OPCODE429_LIST:       printf("gap=%04X listaddr=%04X%04X ",(int) cmdblk[1],(int) cmdblk[6],(int) cmdblk[7]); break;
				case OPCODE429_CALLCOND:   printf("dest=%04X ",(int) cmdblk[7]); break;
				case OPCODE429_BRANCHCOND: printf("dest=%04X ",(int) cmdblk[7]); break;
			}

			printf("\n");
		}

		/**
		*
		*  This helper function loops through all command blocks
		*  in a channels schedule and sends them to the
		*  SchedDump(...) function to be decoded
		*
		**/

		static void SchedDumpAll(int channum,int handleval)
		{
			final int CMDSIZE=8;			//Size of a command block

			int j;
			char[] cmdblk = new char[CMDSIZE];

			int cmdcount = BTI429.CmdCountRd(channum,handleval);

			printf("\n");

			for (j=0;j<=cmdcount;++j)
			{
				BTI429.CmdRd(cmdblk,BTI429.CmdAddr(j,channum,handleval),handleval);
				example15helpers.SchedDump(cmdblk,handleval);
			}
		}
	}
	
	/**
	*
	*  This program opens Card Number 0 and configures the
	*  first compatible core to build a transmit schedule
	*  using transmit interval information, and then transmit
	*  the messages with changing data.
	*
	*  The skip state of the comp_airspeed label is controlled
	*  by keyboard input.
	*
	**/
	
	private static int example16()
	{
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int xmtchan=0;
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		long[] bnr_data = new long[3];
		boolean pause=false;
		boolean done;
		int ch;
		
		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP16  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2009  Ballard Technology, Inc.  Everett, WA, USA.       *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 16                                                 *");
		printf("\n    *  \"Transmit message skipping\"                                       *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first 429 core with a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429.ChIsXmt(xmtchan,hCore))	break;

			if (xmtchan != MAX_CHANNELS) break;
		}

		if (errval != 0 || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
		{
			printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure xmtchan to transmit at high speed.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_HIGHSPEED,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Initialize the three Message Records.
	*
	**/

		comp_airspeed.data = BTI429.FldPutLabel(0L,(short) 0206);     /*Init label field*/
		tot_air_temp.data  = BTI429.FldPutLabel(0L,(short) 0211);
		altitude_rate.data = BTI429.FldPutLabel(0L,(short) 0212);

		comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,0L,(short) 14,(short) 0);     /*Init BNR data*/
		tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,0L,(short) 11,(short) 0);
		altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,0L,(short) 16,(short) 0);

		BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
		BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

	/**
	*
	*  Start the card to begin transmissions.
	*
	**/

		BTICard.CardStart(hCore);

	/**
	*
	*  Continually change data.
	*  Change the state when keyboard keys are pressed. Exit when ESC is pressed.
	*
	**/

		printf("\n\tOPTIONS:");
		printf("\n\tP   = Pause (skip)");
		printf("\n\tU   = Unpause (unskip)");
		printf("\n\tQ   = Exit program");
		printf("\n\n");

		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  
		
		for (done=false;!done;)
		{
			printf("\r\tState: %s \t\t",(pause) ? "Pause (skip enabled)" : "Unpause (skip disabled)");

			comp_airspeed.data = BTI429.MsgDataRd(comp_airspeed.addr,hCore);   /*Read messages back*/
			tot_air_temp.data  = BTI429.MsgDataRd(tot_air_temp.addr,hCore);
			altitude_rate.data = BTI429.MsgDataRd(altitude_rate.addr,hCore);

			bnr_data[0] = BTI429.BNRGetMant(comp_airspeed.data,(short) 14);   /*Extract BNR data*/
			bnr_data[1] = BTI429.BNRGetMant(tot_air_temp.data,(short) 11);
			bnr_data[2] = BTI429.BNRGetMant(altitude_rate.data,(short) 16);

			++bnr_data[0];   /*Change BNR data*/
			++bnr_data[1];
			++bnr_data[2];

			comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,bnr_data[0],(short) 14,(short) 0);   /*Put BNR data*/
			tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,bnr_data[1],(short) 11,(short) 0);    /*back into*/
			altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,bnr_data[2],(short) 16,(short) 0);   /*messages*/

			BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);   /*Write new message values*/
			BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
			BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

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
							done = true;
							break;
						}
						case 'P':
						case 'p':
						{
							pause = true;
							break;
						}
						case 'U':
						case 'u':
						{
							pause = false;
							break;
						}
						default:
						{
							continue;
						}
					}
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			BTI429.MsgSkipWr(pause,comp_airspeed.addr,hCore);
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
	*  This program opens Card Number 0, finds the first
	*  compatible core, builds a transmit schedule using
	*  transmit interval information, and creates filters
	*  for two receive messages.  It also enables the
	*  Sequential Monitor to record transmitted and
	*  received messages. (See Example #3)
	*
	*  The sequential monitor is configured to add an
	*  entry in the event log list for each 32 records.
	*  When the program detects an entry in the event log
	*  list it reads the 32 records in a single buffer.
	*
	**/
	
	private static int example17()
	{
		final int SEQLOGFREQ = 32;
		int hCard;
		int hCore=0;
		int errval;
		int corenum;
		int rcvchan=0;
		int xmtchan=0;
		boolean rcvfound = false;
		boolean xmtfound = false;
		BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
		BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
		int[] msgaddr = new int[3];
		int[] min_intrvls = new int[3];
		int[] max_intrvls = new int[3];
		char[] seqbuf = new char[2048];
		long seqcount;

		printf("\n    **********************************************************************");
		printf("\n    *                                                                    *");
		printf("\n    *  EXAMP17  (10/23/2009)                                             *");
		printf("\n    *  Copyright 2009  Ballard Technology, Inc.  Everett, WA, USA.       *");
		printf("\n    *  All rights reserved.                                              *");
		printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
		printf("\n    *                                                                    *");
		printf("\n    *  BTI429 Example 17                                                 *");
		printf("\n    *  \"Sequential log frequency example\"                                *");
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

		printf("\nUsing ARINC 429 card #%d",CARDNUM);

	/**
	*
	*  Find the first ARINC 429 core with both a receive and a transmit channel.
	*
	**/

		for (corenum=0;corenum<MAX_CORES;corenum++)
		{
			errval = BTICard.CoreOpen(lpHandle,corenum,hCard);
			hCore = lpHandle.getValue();
			if (errval != 0) break;

			for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
			{
				rcvfound = BTI429.ChIsRcv(rcvchan,hCore);
				if (rcvfound) break;
			}

			if (rcvfound)
			{
				for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
				{
					xmtfound = BTI429.ChIsXmt(xmtchan,hCore);
					if (xmtfound) break;
				}
			}

			if (rcvfound && xmtfound)	break;
		}

		if (errval != 0 || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
		{
			printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
			printf("\n");
			BTICard.CardClose(hCard);
			return(1);
		}

		printf("\nUsing ARINC 429 core #%d",corenum);
		printf("\nUsing receive channel #%d",rcvchan);
		printf("\nUsing transmit channel #%d",xmtchan);
		printf("\n");

	/**
	*
	*  Configure rcvchan for automatic speed detection with
	*  the self-test wraparound enabled.
	*  Configure xmtchan to transmit at low speed with
	*  the self-test wraparound enabled.
	*
	**/

		BTICard.CardReset(hCore);

		errval = BTI429.ChConfig(BTI429.CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",rcvchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		errval = BTI429.ChConfig(BTI429.CHCFG429_SEQALL,xmtchan,hCore);      /*Configure channel*/

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Create a message for each of the labels we are transmitting.
	*
	**/

		comp_airspeed.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		tot_air_temp.addr  = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
		altitude_rate.addr = BTI429.MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

	/**
	*
	*  Set up the arrays of message addresses; and intervals
	*  needed to build the schedule.  Note that the nth element
	*  in each array correspond to each other.
	*
	**/

		msgaddr[0] = comp_airspeed.addr;
		min_intrvls[0] = 250;
		max_intrvls[0] = 500;

		msgaddr[1] = tot_air_temp.addr;
		min_intrvls[1] = 250;
		max_intrvls[1] = 500;

		msgaddr[2] = altitude_rate.addr;
		min_intrvls[2] = 100;
		max_intrvls[2] = 200;

	/**
	*
	*  Next, build a schedule using the minimum and maximum
	*  transmit intervals.
	*
	**/

		errval = BTI429.SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while building",errval);
			printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCard));
			BTICard.CardClose(hCard);
			return(1);
		}

	/**
	*
	*  Initialize the three Message Records.
	*
	**/

		comp_airspeed.data = BTI429.FldPutLabel(0L,(short) 0206);   /*Init label field*/
		tot_air_temp.data  = BTI429.FldPutLabel(0L,(short) 0211);
		altitude_rate.data = BTI429.FldPutLabel(0L,(short) 0212);

		comp_airspeed.data = BTI429.BNRPutMant(comp_airspeed.data,0L,(short) 14,(short) 0);   /*Init BNR data*/
		tot_air_temp.data  = BTI429.BNRPutMant(tot_air_temp.data,0L,(short) 11,(short) 0);
		altitude_rate.data = BTI429.BNRPutMant(altitude_rate.data,0L,(short) 16,(short) 0);

		BTI429.MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
		BTI429.MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		BTI429.MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

	/**
	*
	*  Before any messages can be received, filters must be set
	*  for the receive channel.  First, the default filter is
	*  created.  Then, two filters are set for the two messages
	*  of interest.
	*
	*  Record the two filtered messages.
	*
	**/

		msgdefault.addr = BTI429.FilterDefault(BTI429.MSGCRT429_DEFAULT,rcvchan,hCore);
		latitude.addr   = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0310,BTI429.SDIALL,rcvchan,hCore);
		longitude.addr  = BTI429.FilterSet(BTI429.MSGCRT429_SEQ,0311,BTI429.SDIALL,rcvchan,hCore);

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
	*  Configure the Sequential Monitor.
	*
	**/

		errval = BTICard.SeqConfig(BTICard.SEQCFG_LOGFREQ,hCore);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
			printf("\n        (%s)",BTICard.ErrDescStr(errval,hCore));
			BTICard.CardClose(hCard);
			return(1);
		}

		BTICard.SeqLogFrequency(SEQLOGFREQ,hCore);

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

		BTICard.LongRef blkcntref = new BTICard.LongRef();
		
		BufferedReader br = new BufferedReader(new InputStreamReader(_pin));  

		try {
			while (br.ready() == false)
			{
				Thread.sleep(100);

				if (BTICard.EventLogRd(typeref,inforef,chanref,hCore) != 0)
				{
					seqcount = BTICard.SeqBlkRd(seqbuf,seqbuf.length,blkcntref,hCore);

					printf("\nSeqBlkRd :: blkcnt=%d seqcount=%d",blkcntref.getValue(),seqcount);
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
}
