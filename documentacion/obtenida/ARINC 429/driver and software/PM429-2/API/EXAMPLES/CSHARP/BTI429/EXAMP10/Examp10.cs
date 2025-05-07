using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 10 (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10 -- Multiple Core Example
*
**/

/**
*
*  This program opens Card Number 0 and configures all
*  ARINC 429 cores to transmit, receive, and monitor.
*  All transmit channels and all receive channels are
*  used. It also enables the Sequential Monitor to record
*  transmitted and received messages.
*
**/

namespace EXAMP10
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp10
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;   /*Handle to card*/
            Int32 errval = 0;
					
	        UInt32[] hCores = new UInt32[MAX_CORES] {0,0,0,0};	/*Handle to cores*/
            bool[] b429Core = new bool[MAX_CORES] { false, false, false, false };    /*Flag indicating 429 core*/
	        Int32 corecount, corenum, chan;

	        BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD429 pRec429 = new BTICARD.SEQRECORD429();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP10    (06/07/2011)                                           *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI429 Example 10                                                 *");
	        Console.Write("\n    *  \"Program for multiple core example.\"                             *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n");

            /**
            *
            *  Open the card with the specified card number.
            *  An error value is returned, which is tested
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
            *  Find all ARINC 429 cores on the board
            *
            **/

	        corecount = 0;

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        b429Core[corenum] = false;
		        errval = BTICARD.BTICard_CoreOpen(ref hCores[corenum],corenum,hCard);
		        if (0 != errval) break;

		        for (chan=0;chan<MAX_CHANNELS;chan++)
		        {
			        if ( 0 != BTI429.BTI429_ChIsRcv(chan,hCores[corenum]) ||
				         0 != BTI429.BTI429_ChIsXmt(chan,hCores[corenum]) )
			        {
				        b429Core[corenum] = true;
				        corecount++;
				        break;
			        }
		        }
	        }

	        if (0 == corecount)
	        {
		        Console.Write("\nError:  Unable to find any ARINC 429 cores on card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing {0} ARINC 429 core(s) on card #{0}",corecount,CARDNUM);
	        Console.Write("\n");

            /**
            *
            *  Configure all transmit channels on all cores to transmit at low speed.
            *  Configure all receive channels on all cores for automatic speed detection.
            *  Configure the Sequential Monitor for each core.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        if (b429Core[corenum])
		        {
			        BTICARD.BTICard_CardReset(hCores[corenum]);			/* Reset the core. */

			        for (chan=0;chan<MAX_CHANNELS;chan++)
			        {
				        if (0 != BTI429.BTI429_ChIsXmt(chan,hCores[corenum]))
				        {
					        errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_SEQALL,chan,hCores[corenum]);	/*Configure channel*/

					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        channel #{0} on core #{0}.",chan,corenum);
						        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
						        BTICARD.BTICard_CardClose(hCard);
						        Environment.Exit(1);
					        }

					        /* Create a message for each of the synchronous labels we are transmitting. */
					        xmt_airspeed.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCores[corenum]);

					        /* Schedule the message */
					        BTI429.BTI429_SchedMsg(xmt_airspeed.addr,chan,hCores[corenum]);
					        BTI429.BTI429_SchedGap(1218,chan,hCores[corenum]);

					        /* Initialize the Message Record. */
					        xmt_airspeed.data = BTI429.BTI429_FldPutLabel(0,0x86);   /*Init label field*/
					        BTI429.BTI429_MsgDataWr(xmt_airspeed.data,xmt_airspeed.addr,hCores[corenum]);
				        }
				        else if (0 != BTI429.BTI429_ChIsRcv(chan,hCores[corenum]))
				        {
					        errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_SEQALL | BTI429.CHCFG429_AUTOSPEED,chan,hCores[corenum]);   /*Configure channel*/

					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        channel #{0} on core #{0}.",chan,corenum);
						        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
						        BTICARD.BTICard_CardClose(hCard);
						        Environment.Exit(1);
					        }

					        /* Create a default filter */
					        BTI429.BTI429_FilterDefault(BTI429.MSGCRT429_DEFAULT,chan,hCores[corenum]);
				        }
			        }

                    /* Configure the Sequential Monitor on each core for fill and halt mode (default). */
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
	        }

            /**
            *
            *  Start operation of the card.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        if (b429Core[corenum])	BTICARD.BTICard_CardStart(hCores[corenum]);
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

                    while (0 == BTICARD.BTICard_SeqFindNext429Ex(ref pRec429, (UInt16)Marshal.SizeOf(pRec429), ref sfinfo))
                    {
                        Console.Write("\nCore:{0}  Ch:{1:d2}  Data:{2:X8}  Time Stamp:{3:X8}",
						        corenum,
                                ((int)(pRec429.activity & BTI429.MSGACT429_CHMASK) >> (int)(BTI429.MSGACT429_CHSHIFT)),
						        pRec429.data,
						        pRec429.timestamp);
			        }
		        }
	        }

            /**
            *
            *  Stop the card.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
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
