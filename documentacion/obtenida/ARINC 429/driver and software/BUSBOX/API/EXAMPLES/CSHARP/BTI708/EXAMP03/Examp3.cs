using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 3  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3 -- Sequential Monitor example
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
*  The program will display the data from the Sequential Record,
*  until a key is pressed.
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
            Int32 channum = 0;

            Int32 xmtchan = 0;
	        Int32 rcvchan = 0;
	        bool xmtfound = false;
	        bool rcvfound = false;
	        Int32  j,jj;
	        UInt16[] Data = new UInt16[100];

	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD708 pRec708 = new BTICARD.SEQRECORD708();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

            /**
            *
            *  Create a display window.
            *
            **/

	        Console.Clear();	/* Clear the console window. */

	        Console.SetCursorPosition(0, 0);

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP3   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 3                                                  *");
	        Console.Write("\n    *  \"Program for Sequential Monitor example.\"                         *");
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

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_SEQALL|BTI708.CHCFG708_SELFTEST,rcvchan,hCore);

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
            *  Configure the Sequential Monitor.
            *
            **/

	        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the sequential monitor on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
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
            *  Move to display window.
            *
            **/

	        Console.SetCursorPosition(0, 16);

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit.");
	        Console.Write("\n\n");

	        while (0 == Win32Interop._kbhit())
	        {
                seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

                BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                while (0 == BTICARD.BTICard_SeqFindNext708Ex(ref pRec708, (UInt16)Marshal.SizeOf(pRec708), ref sfinfo))
		        {
			        Console.Write("Time Stamp: {0:X8}\n",pRec708.timestamp);
			        Console.Write("Activity:   {0:X4}\n", pRec708.activity);

			        // Display extended header data if it exists
                    if (0 != BTICARD.BTICard_SeqFindCheckVersion(ref pRec708.typeval, (UInt16)BTICARD.SEQVER_1))
			        {
				        Console.Write("Bitcount:   {0:X3}\n", pRec708.bitcount);
			        }

			        for (j=0;j<(pRec708.datacount);++j)
			        {
				        if (0 == (j%10))
				        {
					        Console.Write("\n{0:d4} | ",j);
				        }
				        Console.Write("{0:X4} ",pRec708.data[j]);
			        }

			        Console.SetCursorPosition(0, 19);
		        }
	        }

            /**
            *
            *  Move to bottom of screen.
            *
            **/

	        Console.SetCursorPosition(0, 32);

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
