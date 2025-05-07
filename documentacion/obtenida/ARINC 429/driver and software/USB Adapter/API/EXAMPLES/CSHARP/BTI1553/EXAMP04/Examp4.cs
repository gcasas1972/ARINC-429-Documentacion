using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 4  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4 -- Monitoring the bus
*
**/

/**
*
*  This example configures Card Number 0 as a Bus Monitor
*  terminal.  It prints the time-tag, command words (if any),
*  and status words (if any) for each monitor record.
*
**/

namespace EXAMP4
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp4
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        unsafe static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt16[] seqbuf = new UInt16[2048];
	        UInt32  seqcount = 0;
	        UInt32  blkcnt = 0;
	        BTICARD.SEQRECORD1553 pRec1553 = new BTICARD.SEQRECORD1553();
	        BTICARD.SEQRECORDMORE1553 pRecMore1553 = new BTICARD.SEQRECORDMORE1553();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP4    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 4                                                 *");
	        Console.Write("\n    *  \"Monitoring the bus example.\"                                     *");
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
		        Console.Write("\nError:  No MIL-STD-1553 channels present in cardnum {0}.",CARDNUM);
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
            *  Start the card to begin monitoring messages.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Read the entire contents of the monitor and display the results.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

            while (0 == Win32Interop._kbhit())
            {
                seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

                BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                while (0 == BTICARD.BTICard_SeqFindNext1553Ex(ref pRec1553, (UInt16) Marshal.SizeOf(pRec1553), ref sfinfo))
                {
                    Console.Write("\n");

                    Console.Write(" Ch:{0}", (int)(pRec1553.activity & BTI1553.MSGACT1553_CHMASK) >> (int)BTI1553.MSGACT1553_CHSHIFT);
                    Console.Write(" Time:{0}", pRec1553.timestamp);

                    if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD1)) Console.Write(" Cwd1:{0:X}", pRec1553.cwd1);
                    if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD2)) Console.Write(" Cwd2:{0:X}", pRec1553.cwd2);
                    if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD1)) Console.Write(" Swd1:{0:X}", pRec1553.swd1);
                    if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD2)) Console.Write(" Swd2:{0:X}", pRec1553.swd2);

                    if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_NORESP)) Console.Write(" No response!");
                    if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_ANYERR)) Console.Write(" Error!");

                    if (0 != BTICARD.BTICard_SeqFindCheckVersion(ref pRec1553.typeval, (UInt16)BTICARD.SEQVER_1))
                    {
                        if (0 != BTICARD.BTICard_SeqFindMore1553Ex(ref pRecMore1553, (UInt16)Marshal.SizeOf(pRecMore1553), ref pRec1553))
                        {
                            Console.Write(" RespTime1:{0}", pRecMore1553.resptime1);
                        }
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
