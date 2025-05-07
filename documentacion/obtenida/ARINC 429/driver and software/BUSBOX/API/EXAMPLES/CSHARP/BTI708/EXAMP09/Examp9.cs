using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 9  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9 -- Multiple Core Example
*
**/

/**
*
*  This program opens Card Number 0 and configures all
*  ARINC 708 cores to transmit, receive, and monitor.
*  All transmit channels and all receive channels are
*  used. It also enables the sequential monitor to record
*  transmitted and received messages.
*
**/

namespace EXAMP9
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp9
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32	FRAMEFREQ = 200;          /*Frame frequency of 200Hz*/
        private const Int32 LOGFREQ = 16;           /*Generate a Log Event after every 16th message*/
        private const Int32 FRAMECOUNT = 32;           /*Transmit a total of 32 messages*/

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
	        UInt32[] hCores = new UInt32[MAX_CORES];
	        Int32 corecount, chan;
	        Int32 count = 0;
	        Int32 j,jj;
	        UInt16[] Data = new UInt16[100];
	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD708 pRec708 = new BTICARD.SEQRECORD708();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP9    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 9                                                  *");
	        Console.Write("\n    *  \"Program for multiple cores example.\"                             *");
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
            *  Find all ARINC 708 cores on the board
            *
            **/

	        corecount = 0;

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        UInt32 hCore = 0;
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (chan=0;chan<MAX_CHANNELS;chan++)
		        {
			        if (0 != BTI708.BTI708_ChIs708(chan,hCore))	break;
		        }

		        if (chan!=MAX_CHANNELS)
		        {
			        hCores[corecount] = hCore;
			        corecount++;
			        continue;
		        }
	        }

	        if (0 == corecount)
	        {
		        Console.Write("\nError:  Unable to find any ARINC 708 cores on card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing {0} ARINC 708 core(s) on card #{0}",corecount,CARDNUM);
	        Console.Write("\n");

            /**
            *
            *  Configure all transmit channels on all cores to send 32 messages at 200Hz
            *  Configure all receive channels on all cores to receive messages in a single message record per core.
            *  Configure each cores sequential record.
            *
            **/

	        for (corenum=0;corenum<corecount;corenum++)
	        {
		        BTICARD.BTICard_CardReset(hCores[corenum]);			/* Reset the core. */

		        for (chan=0;chan<MAX_CHANNELS;chan++)
		        {
			        if (0 != BTI708.BTI708_ChIsXmt(chan,hCores[corenum]))
			        {
				        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_SEQALL,chan,hCores[corenum]);	/*Configure channel*/
				        if (errval < 0)
				        {
					        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
					        Console.Write("\n        transmit channel #{0} on core #{1}.",chan,corenum);
					        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
					        BTICARD.BTICard_CardClose(hCard);
					        Environment.Exit(1);
				        }

				        errval = BTI708.BTI708_XmtBuild(BTI708.MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,chan,hCores[corenum]);
				        if (0 != errval)
				        {
					        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
					        Console.Write("\n        transmit channel #{0} on core #{1}.",chan,corenum);
					        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
					        Console.Write("\n");
					        BTICARD.BTICard_CardClose(hCard);
					        Environment.Exit(1);
				        }

				        for (j=0;j<FRAMECOUNT;j++)							/*Loop through all the messages*/
				        {
					        for (jj=0;jj<100;jj++) Data[jj] = (UInt16)(j + (count * FRAMECOUNT));
					        BTI708.BTI708_MsgDataWr(ref Data[0],j,chan,hCores[corenum]);	/*Write data to the Device*/
				        }
				        count++;
			        }
                    else if (0 != BTI708.BTI708_ChIsRcv(chan, hCores[corenum]))
			        {
				        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_DEFAULT,chan,hCores[corenum]);   /*Configure channel*/
				        if (errval < 0)
				        {
					        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
					        Console.Write("\n        receive channel #{0} on core #{1}.",chan,corenum);
					        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
					        BTICARD.BTICard_CardClose(hCard);
					        Environment.Exit(1);
				        }

				        errval = BTI708.BTI708_RcvBuild(BTI708.MSGCRT708_DEFAULT,0,1,chan,hCores[corenum]);
				        if (0 != errval)
				        {
					        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
					        Console.Write("\n        receive channel #{0} on core #.",chan,corenum);
					        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
					        Console.Write("\n");
					        BTICARD.BTICard_CardClose(hCard);
					        Environment.Exit(1);
				        }
			        }
		        }

                /* Configure the sequential record on each core for fill and halt mode (default). */
		        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCores[corenum]);

		        if (errval < 0)
		        {
			        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
			        Console.Write("\n        the sequential record on core #{0}.",corenum);
			        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
			        BTICARD.BTICard_CardClose(hCard);
			        Environment.Exit(1);
		        }
	        }

            /**
            *
            *  Start operation of the card.
            *
            **/

	        for (corenum=0;corenum<corecount;corenum++)
	        {
		        BTICARD.BTICard_CardStart(hCores[corenum]);
	        }

            /**
            *
            *  Display data on the screen.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        while(0 == Win32Interop._kbhit())
	        {
		        for (corenum=0;corenum<corecount;corenum++)
		        {
                    seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCores[corenum]);

                    BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                    while (0 == BTICARD.BTICard_SeqFindNext708Ex(ref pRec708, (UInt16)Marshal.SizeOf(pRec708), ref sfinfo))
                    {
				        Console.Write("\nCore:{0}   Ch:{1:d2}   Time Stamp:{2:X8}",
						        corenum,
						        ((int)(pRec708.activity & BTI708.MSGACT708_CHMASK) >> (int)(BTI708.MSGACT708_CHSHIFT)),
						        pRec708.timestamp);
			        }
		        }
	        }

            /**
            *
            *  Stop the card.
            *
            **/

	        for (corenum=0;corenum<corecount;corenum++)
	        {
		        BTICARD.BTICard_CardStop(hCores[corenum]);
	        }

            /**
            *
            *  The card MUST be closed before exiting the program.
            *
            **/

	        BTICARD.BTICard_CardClose(hCard);
        }
    }
}
