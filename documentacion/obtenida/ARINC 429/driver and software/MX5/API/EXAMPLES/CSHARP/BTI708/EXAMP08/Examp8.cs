using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 8  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8 -- IRIG timer example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first receive
*  channel and the first transmit channel to operate on
*  the self-test bus.  The transmitter is configured
*  with 128 messages that are initialized with
*  incrementing data.  The receive channel is configured
*  to record it's data to the Sequential Monitor.
*
*  An Event Log frequency of 0 is specified, which will
*  not generate any Event Log List entries for these channels.
*
*  The program will display the IRIG time and elapsed time from
*  receive message structure 0, until a key is pressed.
*
**/

namespace EXAMP8
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp8
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
            Int32 xmtchan = 0;
	        Int32 rcvchan = 0;
	        bool rcvfound = false;
	        bool xmtfound = false;
            bool timetagIsBCD = false;
            UInt32 temp = 0;
	        Int32  j,jj;
	        UInt16[] Data = new UInt16[100];
	        BTI708.MSGFIELDS708 msgfields = new BTI708.MSGFIELDS708();
            BTICARD.BTIIRIGTIME irigtime = new BTICARD.BTIIRIGTIME();
            DateTime date;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP8   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 8                                                  *");
	        Console.Write("\n    *  \"Program for IRIG timer example.\"                                 *");
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

	        errval = BTICARD.BTICard_CardOpen(ref hCard, CARDNUM);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  Either card number {0} is not present, or",CARDNUM);
		        Console.Write("\n        an error occurred ({0}) opening the card.",errval);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        Environment.Exit(1);
	        }

            /**
            *
            *  Find the first ARINC 708 core with both a receive and a transmit channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        rcvfound = false;
		        xmtfound = false;

		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);	/* Open a handle to the core. */
		        if (0 != errval) break;

		        for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
		        {
			        rcvfound = 0 != BTI708.BTI708_ChIsRcv(rcvchan,hCore);
			        if (rcvfound) break;
		        }

		        if (rcvfound)
		        {
			        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			        {
				        xmtfound = 0 != BTI708.BTI708_ChIsXmt(xmtchan,hCore);
				        if (xmtfound) break;
			        }
		        }

		        if (rcvfound && xmtfound)	break;
	        }

	        if (0 != errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	        {
		        Console.Write("\nError:  No compatible ARINC 708 core present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\nUsing receive channel #{0}",rcvchan);
	        Console.Write("\nUsing transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure receive channel.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

            errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_ELAPSE | BTI708.CHCFG708_SELFTEST, rcvchan, hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",rcvchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure transmit channel.
            *
            **/

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_SELFTEST,xmtchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Build the receive channel messages.
            *
            **/

	        errval = BTI708.BTI708_RcvBuild(BTI708.MSGCRT708_DEFAULT,0,1,rcvchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",rcvchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Build the transmit channel messages.
            *
            **/

	        errval = BTI708.BTI708_XmtBuild(BTI708.MSGCRT708_DEFAULT,200,0,128,xmtchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create and write the data for the messages.
            *
            **/

	        for (j=0;j<128;j++)							/*Loop through all the messages*/
	        {
		        for (jj=0;jj<100;jj++) Data[jj] = (UInt16)((j << 8) + jj);
		        BTI708.BTI708_MsgDataWr(ref Data[0],j,xmtchan,hCore);	/*Write data to the Device*/
	        }

            /**
            *
            *  Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
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

            timetagIsBCD = (BTICARD.TIMETAG_FORMAT_BCD == BTICARD.BTICard_TimerStatus(hCore)) ? true : false;

            /**
            *
            *  Synchronize the on core IRIG timer with the computer local time
            *
            **/

	        date = DateTime.Now;

            irigtime.days = (UInt16)date.DayOfYear;	    /* Day of year (0 - 365; January 1 = 0) */
            irigtime.hours = (UInt16)date.Hour;		    /* Hours after midnight (0 - 23)		*/
            irigtime.min = (UInt16)date.Minute;		    /* Minutes after hour (0 - 59)			*/
            irigtime.sec = (UInt16)date.Second;		    /* Seconds after minute (0 - 59)		*/
            irigtime.msec = (UInt16)date.Millisecond;	/* Milliseconds after second (0 - 1000) */
            irigtime.usec = 0;					        /* The DateTime structure does not include microseconds.	*/

            errval = BTICARD.BTICard_IRIGWr(ref irigtime, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while writing",errval);
		        Console.Write("\n        the IRIG time on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit.");
	        Console.Write("\n");
	        Console.Write("\n");

	        while (0 == Win32Interop._kbhit())
	        {
		        BTI708.BTI708_MsgBlockRd(ref msgfields, 0, rcvchan, hCore);

                if (!timetagIsBCD)
                {
                    //Convert binary timetag to BCD
                    BTICARD.BTICard_IRIGTimeBinToBCD(ref msgfields.timetagh,
                                                     ref msgfields.timetag_hitcount,
                                                     msgfields.timetagh,
                                                     msgfields.timetag_hitcount);

                    //Convert binary elapsetime to BCD
                    BTICARD.BTICard_IRIGTimeBinToBCD(ref temp,
                                                     ref msgfields.elapsetime_maxtime_mintime,
                                                     temp,
                                                     msgfields.elapsetime_maxtime_mintime);
                }

		        Console.Write("\r");

                Console.Write("TT: {0:d2}:{1:d2} {2:d2}.{3:d3}.{4:d3}    ",
                        BTICARD.BTICard_IRIGFieldGetHours(msgfields.timetagh, msgfields.timetag_hitcount),
                        BTICARD.BTICard_IRIGFieldGetMin(msgfields.timetagh, msgfields.timetag_hitcount),
                        BTICARD.BTICard_IRIGFieldGetSec(msgfields.timetagh, msgfields.timetag_hitcount),
                        BTICARD.BTICard_IRIGFieldGetMillisec(msgfields.timetagh, msgfields.timetag_hitcount),
                        BTICARD.BTICard_IRIGFieldGetMicrosec(msgfields.timetagh, msgfields.timetag_hitcount));

                Console.Write("Elapse Time: {0:d2}ms ", BTICARD.BTICard_IRIGFieldGetMillisec(0x0000, msgfields.elapsetime_maxtime_mintime));

		        Console.Write("    ");
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
