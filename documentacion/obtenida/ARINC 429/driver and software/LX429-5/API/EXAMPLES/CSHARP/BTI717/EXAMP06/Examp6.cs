using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 6  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6 -- Multiple Core Example
*
**/

/**
*
*  This program opens Card Number 0 and configures all
*  ARINC 717 cores to receive on all BiPhase channels.
*  Program reports when each BiPhase channel is in sync.
*
**/

namespace EXAMP6
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Examp6
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            Int32 errval = 0;

	        UInt32[] hCores = new UInt32[MAX_CORES] {0,0,0,0};	    /*Handle to cores*/
	        bool[] b717Core = new bool[MAX_CORES] {false, false, false, false};  /*Flag indicating 717 core*/
	        Int32 corecount = 0, corenum = 0, chan = 0;
            char ch;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP6    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI429 Example 6                                                 *");
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

            /**
            *
            *  Find all ARINC 717 cores on the board with a BiPhase receive channel.
            *
            **/

	        corecount = 0;

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        b717Core[corenum] = false;
		        errval = BTICARD.BTICard_CoreOpen(ref hCores[corenum],corenum,hCard);
		        if (0 != errval) break;

		        for (chan=0;chan<MAX_CHANNELS;chan++)
		        {
			        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASERCV, chan, hCores[corenum]))
			        {
				        b717Core[corenum] = true;
				        corecount++;
				        break;
			        }
		        }
	        }

	        if (0 == corecount)
	        {
		        Console.Write("\nError:  Unable to find any ARINC 717 cores on card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing {0} ARINC 717 core(s) on card #{1}",corecount,CARDNUM);
	        Console.Write("\n");

            /**
            *
            *  Configure all receive channels  for auto speed detection.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        if (b717Core[corenum])
		        {
			        BTICARD.BTICard_CardReset(hCores[corenum]);			/* Reset the core. */

			        for (chan=0;chan<MAX_CHANNELS;chan++)
			        {
				        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASERCV, chan, hCores[corenum]))
				        {
					        errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASERCV | BTI717.CHCFG717_AUTOSPEED,chan,hCores[corenum]);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring channel {1}.",errval,chan);
						        Console.Write("\n        on core {0} ({1})",corenum,BTICARD.BTICard_ErrDescStr(errval,hCard));
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
            *   Start each 717 core to begin
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        if (b717Core[corenum])	BTICARD.BTICard_CardStart(hCores[corenum]);
	        }

            /**
            *
            *  Display data on the screen.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        if (b717Core[corenum])
		        {
			        for (chan=0;chan<MAX_CHANNELS;chan++)
			        {
				        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASERCV, chan, hCores[corenum]))
				        {
					        Console.Write("\nSynchronizing channel {0} on core {1} to bit stream....",chan,corenum);

					        while (0 == BTI717.BTI717_SyncTest(chan,hCores[corenum]) && 0 == Win32Interop._kbhit());

                            ch = Win32Interop._getch();

					        if (0 != BTI717.BTI717_SyncTest(chan,hCores[corenum]))	Console.Write("In Sync!\n");
				        }
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
