using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 1  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1 -- Receiver example
*
**/

/**
*
*  This program opens Card Number 0, and configures the 
*  first BiPhase channel as a receiver.  After the 
*  channel gets in sync, the program displays the first 
*  word of each subframe (sync words).
*
**/

namespace EXAMP1
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp1
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
            UInt16 syncword1 = 0, syncword2 = 0, syncword3 = 0, syncword4 = 0;

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP1    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI717 Example 1                                                  *");
            Console.Write("\n    *  \"Program for receiver example.\"                                   *");
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
                Console.Write("\nError:  Either card number {0} is not present, or", CARDNUM);
                Console.Write("\n        an error occurred ({0}) opening the card.", errval);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 717 card #{0}", CARDNUM);

            /**
            *
            *  Find the first ARINC 717 core with a BiPhase receive channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);
                if (0 != errval) break;

                for (rcvchan = 0; rcvchan < MAX_CHANNELS; rcvchan++)
                {
                    if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASERCV, rcvchan, hCore)) break;
                }

                if (rcvchan != MAX_CHANNELS) break;
            }

            if (0 != errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
            {
                Console.Write("\nError:  No ARINC 717 BiPhase receive channels present in cardnum {0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 717 core #{0}", corenum);
            Console.Write("\nUsing BiPhase receive channel #{0}", rcvchan);
            Console.Write("\n");

            /**
            *
            *  Configure channel for auto speed detection.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);

            errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASERCV | BTI717.CHCFG717_AUTOSPEED, rcvchan, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring channel {1}.", errval, rcvchan);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCore));
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
            *  Display data on the screen.
            *
            **/

            Console.Write("\nPress any key to exit....\n\n");
            Console.Write("\nSynchronizing to bit stream....");

            while (0 == BTI717.BTI717_SyncTest(rcvchan, hCore) && 0 == Win32Interop._kbhit()) ;

            if (0 != BTI717.BTI717_SyncTest(rcvchan, hCore))
            {
                Console.Write("In Sync!\n\n");
                while (0 == Win32Interop._kbhit())
                {
                    BTI717.BTI717_SubFrmWordRd(ref syncword1, 1, 1, rcvchan, hCore);
                    BTI717.BTI717_SubFrmWordRd(ref syncword2, 2, 1, rcvchan, hCore);
                    BTI717.BTI717_SubFrmWordRd(ref syncword3, 3, 1, rcvchan, hCore);
                    BTI717.BTI717_SubFrmWordRd(ref syncword4, 4, 1, rcvchan, hCore);

                    Console.Write("\r");
                    Console.Write("Sync1={0} ", Convert.ToString(syncword1, 8));
                    Console.Write("Sync2={0} ", Convert.ToString(syncword2, 8));
                    Console.Write("Sync3={0} ", Convert.ToString(syncword3, 8));
                    Console.Write("Sync4={0} ", Convert.ToString(syncword4, 8));
                    Console.Write("(Octal)");
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
