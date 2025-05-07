using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 14  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP14 -- Multiple Cores - Monitor all channels on all cores
*
**/

/**
*
*  This example configures all 1553 channels on all cores of Card Number 0
*  as Bus Monitor terminals. It prints the channel number, time-tag, command
*  words (if any), and status words (if any) for each monitor record.
*
**/

namespace EXAMP14
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp14
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32[] hCores = new UInt32[MAX_CORES] {0,0,0,0};
            bool[] b1553Core = new bool[MAX_CORES] {false, false, false, false};
            Int32 corecount;
            Int32 errval = 0;
            Int32 channum = 0;

	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD1553 pRec1553 = new BTICARD.SEQRECORD1553();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();
	        Int32 j;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP14   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 14                                                *");
	        Console.Write("\n    *  \"Multi Core - Monitor all channels on all cores\"                  *");
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
            *  Find all MIL-STD-1553 cores.
            *
            **/
	        corecount = 0;

	        for (j=0; j<MAX_CORES; j++)
	        {
		        b1553Core[j] = false;
		        errval = BTICARD.BTICard_CoreOpen(ref hCores[j],j,hCard);
		        if (0 != errval) break;

		        for (channum=0;channum<MAX_CHANNELS;channum++)
		        {
			        if (0 != BTI1553.BTI1553_ChIs1553(channum,hCores[j]))
			        {
				        b1553Core[j] = true;
				        corecount++;
				        break;
			        }
		        }
	        }

	        if (0==corecount)
	        {
		        Console.Write("\nError:  No MIL-STD-1553 cores present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing {0} MIL-STD-1553 core(s)",corecount);
	        Console.Write("\n");

            /**
            *
            *  Configure the sequential record on each 1553 core.
            *  Configure all 1553 channels for monitor mode.
            *
            **/

	        for (j=0; j<MAX_CORES; j++)
	        {
		        if (b1553Core[j])
		        {
			        BTICARD.BTICard_CardReset(hCores[j]);	/*First reset the core*/

			        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCores[j]);
			        if (errval < 0)
			        {
				        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
				        Console.Write("\n        the sequential record on core #{1}.",j);
				        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
				        BTICARD.BTICard_CardClose(hCard);
				        Environment.Exit(1);
			        }

			        for (channum=0;channum<MAX_CHANNELS;channum++)
			        {
				        if (0 != BTI1553.BTI1553_ChIs1553(channum,hCores[j]))
				        {
					        errval = BTI1553.BTI1553_MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCores[j]);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring for",errval);
						        Console.Write("\n        monitor mode on channel #{0} on core #{1}.",channum,j);
						        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
						        Console.Write("\n");
						        BTICARD.BTICard_CardClose(hCard);
						        Environment.Exit(1);
					        }
				        }
			        }
		        }
	        }

            /**
            *
            *  Start each 1553 core to begin
            *
            **/

	        for (j=0; j<MAX_CORES; j++)
	        {
		        if (b1553Core[j])	BTICARD.BTICard_CardStart(hCores[j]);
	        }

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        while (0 == Win32Interop._kbhit())
	        {
		        for (j=0; j<MAX_CORES; j++)
		        {
			        if (b1553Core[j])
			        {
                        seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], 2048, ref blkcnt, hCores[j]);

				        BTICARD.BTICard_SeqFindInit(ref seqbuf[0],(UInt32)seqcount,ref sfinfo);

				        while(0 == BTICARD.BTICard_SeqFindNext1553Ex(ref pRec1553, (UInt16)Marshal.SizeOf(pRec1553),ref sfinfo))
				        {
					        Console.Write("\n");

					        Console.Write(" Core:%02d",j);
                            Console.Write(" Ch:{0}", (int)(pRec1553.activity & BTI1553.MSGACT1553_CHMASK) >> (int)BTI1553.MSGACT1553_CHSHIFT);
                            Console.Write(" Time:{0}", pRec1553.timestamp);

                            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD1)) Console.Write(" Cwd1:{0:X}", pRec1553.cwd1);
                            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVCWD2)) Console.Write(" Cwd2:{0:X}", pRec1553.cwd2);
                            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD1)) Console.Write(" Swd1:{0:X}", pRec1553.swd1);
                            if (0 != (pRec1553.activity & BTI1553.MSGACT1553_RCVSWD2)) Console.Write(" Swd2:{0:X}", pRec1553.swd2);

                            if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_NORESP)) Console.Write(" No response!");
                            if (0 != (pRec1553.errorval & BTI1553.MSGERR1553_ANYERR)) Console.Write(" Error!");
				        }
			        }
		        }
	        }

            /**
            *
            *  Stop all cores.
            *
            **/

	        for (j=0; j<MAX_CORES; j++)
	        {
		        BTICARD.BTICard_CardStop(hCores[j]);
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
