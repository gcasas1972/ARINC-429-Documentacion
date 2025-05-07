using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 15  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP15 -- IRIG Timer example (bus monitor).
*
**/

/**
*
*  This example configures Card Number 0 as a Bus Monitor
*  terminal.  It prints the time-tag (in IRIG format),
*  command words (if any), and status words (if any) for each
*  monitor record.
*
**/

namespace EXAMP15
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp15
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD1553 pRec1553 = new BTICARD.SEQRECORD1553();
	        BTICARD.SEQRECORDMORE1553 pRecMore = new BTICARD.SEQRECORDMORE1553();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        BTICARD.BTIIRIGTIME irigtime = new BTICARD.BTIIRIGTIME();
	        DateTime date;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP15   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 15                                                *");
	        Console.Write("\n    *  \"IRIG Timer example (bus monitor).\"                               *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n");

            /**
            *
            *  Open the card with the specified card number.
            *  An error value is returned which is tested
            *  to determine if an error occurred.
            *
            **/

            errval = BTICARD.BTICard_CardOpen(ref hCard,CARDNUM);

	if (0 != errval)
	{
		Console.Write("\nError:  Either card number {0} is not present, or",CARDNUM);
		Console.Write("\n        an error occurred ({0}) opening the card.",errval);
		Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		Console.Write("\n");
		Environment.Exit(1);
	}

	Console.Write("\nUsing BTI1553 card #{0}",CARDNUM);

/**
*
*  Find the first MIL-STD-1553 core and channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		if (0 != errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
			if (0 != BTI1553.BTI1553_ChIs1553(channum,hCore)) break;

		if (channum != MAX_CHANNELS) break;
	}

	if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	{
		Console.Write("\nError:  No MIL-STD-1553 channels present in card #{0}.",CARDNUM);
		Console.Write("\n");
		BTICARD.BTICard_CardClose(hCard);
		Environment.Exit(1);
	}

	Console.Write("\nUsing MIL-STD-1553 core #{0}",corenum);
	Console.Write("\nUsing MIL-STD-1553 channel #{0}",channum);
	Console.Write("\n");

/**
*
*  Configure the channel for monitor mode.
*
**/

	BTICARD.BTICard_CardReset(hCore);

	errval = BTI1553.BTI1553_MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCore);

	if (errval < 0)
	{
		Console.Write("\nError:  An error was encountered ({0}) while configuring for",errval);
		Console.Write("\n        monitor mode on channel #{0} on core #{1}.",channum,corenum);
		Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		Console.Write("\n");
		BTICARD.BTICard_CardClose(hCard);
		Environment.Exit(1);
	}

/**
*
*  Configure the sequential record.
*
**/

	errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		Console.Write("\n        the sequential record on core #{1}.",corenum);
		Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		BTICARD.BTICard_CardClose(hCard);
		Environment.Exit(1);
	}

/**
*
*  Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/receiver)
*  Sequential monitor will store IRIG time in sequential records
*
**/

    errval = BTICARD.BTICard_IRIGConfig(BTICARD.IRIGCFG_DEFAULT, hCore);

	if (errval < 0)
	{
		Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		Console.Write("\n        the IRIG timer on core #{0}.",corenum);
		Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		BTICARD.BTICard_CardClose(hCard);
		Environment.Exit(1);
	}

/**
*
*  Synchronize the on core IRIG timer with the computer local time
*
**/

    date = DateTime.Now;

    irigtime.days  = (UInt16)date.DayOfYear;	/* Day of year (0 - 365; January 1 = 0) */
    irigtime.hours = (UInt16)date.Hour;		    /* Hours after midnight (0 - 23)		*/
	irigtime.min   = (UInt16)date.Minute;		/* Minutes after hour (0 - 59)			*/
	irigtime.sec   = (UInt16)date.Second;		/* Seconds after minute (0 - 59)		*/
    irigtime.msec  = (UInt16)date.Millisecond;	/* Milliseconds after second (0 - 1000) */
    irigtime.usec = 0;					        /* The DateTime structure does not include microseconds.	*/

	errval = BTICARD.BTICard_IRIGWr(ref irigtime, hCore);
	if (errval < 0)
	{
		Console.Write("\nError:  An error was encountered ({0}) while writing",errval);
		Console.Write("\n        the IRIG time on core #{1}.",corenum);
		Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		BTICARD.BTICard_CardClose(hCard);
		Environment.Exit(1);
	}

    Console.Write("\n\nStart Time:{0:d2}:{1:d2} {2:d2}.{3:d3}.{4:d3} \n",
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

	BTICARD.BTICard_CardStart(hCore);

/**
*
*  Read the entire contents of the monitor and display the results.
*
**/

	Console.Write("\nPress any key to exit....\n\n");

	while(0 == Win32Interop._kbhit())
	{
		/* Empty entire contents of sequential monitor into a buffer. */
		seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0],(UInt32)seqbuf.Length,ref blkcnt,hCore);

        BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

		while(0 == BTICARD.BTICard_SeqFindNext1553Ex(ref pRec1553,(UInt16)Marshal.SizeOf(pRec1553) ,ref sfinfo))
		{
			/* Get extended data for this record. */
			BTICARD.BTICard_SeqFindMore1553Ex(ref pRecMore, (UInt16)Marshal.SizeOf(pRecMore) ,ref pRec1553);

			Console.Write("\n");

            Console.Write(" Ch:{0}", (int)(pRec1553.activity & BTI1553.MSGACT1553_CHMASK) >> (int)BTI1553.MSGACT1553_CHSHIFT);
            Console.Write(" Time:{0:d2}:{1:d2} {2:d2}.{3:d3}.{4:d3}    ",
					BTICARD.BTICard_IRIGFieldGetHours(   pRecMore.timestamph, pRec1553.timestamp),
					BTICARD.BTICard_IRIGFieldGetMin(     pRecMore.timestamph, pRec1553.timestamp),
					BTICARD.BTICard_IRIGFieldGetSec(     pRecMore.timestamph, pRec1553.timestamp),
					BTICARD.BTICard_IRIGFieldGetMillisec(pRecMore.timestamph, pRec1553.timestamp),
					BTICARD.BTICard_IRIGFieldGetMicrosec(pRecMore.timestamph, pRec1553.timestamp));

			if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD1)) Console.Write(" Cwd1:{0:X}",pRec1553.cwd1);
            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD2)) Console.Write(" Cwd2:{0:X}", pRec1553.cwd2);
            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD1)) Console.Write(" Swd1:{0:X}", pRec1553.swd1);
            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD2)) Console.Write(" Swd2:{0:X}", pRec1553.swd2);

			if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_NORESP)) Console.Write(" No response!");
            if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_ANYERR)) Console.Write(" Error!");
		}
	}

/**
*
*  Stop the card.
*
**/

	BTICARD.BTICard_CardStop(hCore);


/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICARD.BTICard_CardClose(hCard);
        }
    }
}
