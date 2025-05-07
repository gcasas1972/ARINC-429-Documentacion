using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 3  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3 -- Monitor example
*
**/

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

namespace EXAMP3
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp3
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
            Int32 rcvchan = 0;
            Int32 xmtchan = 0;
	        bool rcvfound = false;
            bool xmtfound = false;
	        BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();
	        BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
	        UInt32[] msgaddr = new UInt32[3];
	        Int32[] min_intrvls = new Int32[3];
	        Int32[] max_intrvls = new Int32[3];
	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD429 pRec429 = new BTICARD.SEQRECORD429();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP3    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI429 Example 3                                                  *");
	        Console.Write("\n    *  \"Program for monitor example.\"                                    *");
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

	        Console.Write("\nUsing ARINC 429 card #{0}",CARDNUM);

            /**
            *
            *  Find the first ARINC 429 core with both a receive and a transmit channel.
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
			        rcvfound = 0 != BTI429.BTI429_ChIsRcv(rcvchan,hCore);
			        if (rcvfound) break;
		        }

		        if (rcvfound)
		        {
			        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			        {
				        xmtfound = 0 != BTI429.BTI429_ChIsXmt(xmtchan,hCore);
				        if (xmtfound) break;
			        }
		        }

		        if (rcvfound && xmtfound)	break;
	        }

	        if (0 != errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	        {
		        Console.Write("\nError:  No compatible ARINC 429 core present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 429 core #{0}",corenum);
	        Console.Write("\nUsing receive channel #{0}",rcvchan);
	        Console.Write("\nUsing transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure rcvchan for automatic speed detection.
            *  Configure xmtchan to transmit at low speed.
            *
            *  Record all of xmtchan data into the Sequential Record.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_AUTOSPEED | BTI429.CHCFG429_SEQALL, rcvchan, hCore);   /*Configure channel*/

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{0}.",rcvchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_DEFAULT, xmtchan, hCore);      /*Configure channel*/

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{0}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create a message for each of the labels we are transmitting.
            *
            **/

	        comp_airspeed.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
	        tot_air_temp.addr  = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
	        altitude_rate.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

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

	        BTI429.BTI429_SchedBuild(3,ref msgaddr[0],ref min_intrvls[0],ref max_intrvls[0],xmtchan,hCore);

            /**
            *
            *  Initialize the three Message Records.
            *
            **/

	        comp_airspeed.data = BTI429.BTI429_FldPutLabel(0,0x86);   /*Init label field*/
	        tot_air_temp.data  = BTI429.BTI429_FldPutLabel(0,0x89);
	        altitude_rate.data = BTI429.BTI429_FldPutLabel(0,0x8A);

	        comp_airspeed.data = BTI429.BTI429_BNRPutMant(comp_airspeed.data,0,14,0);   /*Init BNR data*/
	        tot_air_temp.data  = BTI429.BTI429_BNRPutMant(tot_air_temp.data,0,11,0);
	        altitude_rate.data = BTI429.BTI429_BNRPutMant(altitude_rate.data,0,16,0);

	        BTI429.BTI429_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
	        BTI429.BTI429_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
	        BTI429.BTI429_MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

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

	        msgdefault.addr = BTI429.BTI429_FilterDefault(BTI429.MSGCRT429_DEFAULT,rcvchan,hCore);
	        latitude.addr   = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_SEQ,0xC8,(Int32)BTI429.SDIALL,rcvchan,hCore);
            longitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_SEQ, 0xC9, (Int32)BTI429.SDIALL, rcvchan, hCore);

            /**
            *
            *  Configure the Sequential Monitor for fill and halt mode (default).
            *
            **/

            errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring the sequential record.",errval);
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
            *  Display data on the screen.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        while(0 == Win32Interop._kbhit())
	        {
                seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

		        BTICARD.BTICard_SeqFindInit(ref seqbuf[0],(UInt32)seqcount,ref sfinfo);

		        while(0 == BTICARD.BTICard_SeqFindNext429Ex(ref pRec429, (UInt16)Marshal.SizeOf(pRec429),ref sfinfo))
		        {
                    Console.Write("\nCore:{0}  Ch:{1:d2}  Data:{2:X8}  Time Stamp:{3:X8}",
				           corenum,
                           ((int)(pRec429.activity & BTI429.MSGACT429_CHMASK) >> (int)(BTI429.MSGACT429_CHSHIFT)),
				           pRec429.data,
				           pRec429.timestamp);

			        if (0 != BTICARD.BTICard_SeqFindCheckVersion(ref pRec429.typeval, (UInt16)BTICARD.SEQVER_1))
			        {
				        Console.Write("  decgap:{0:X}",pRec429.decgap);
			        }
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
