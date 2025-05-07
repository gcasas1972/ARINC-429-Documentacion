using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 6  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6 -- Asynchronous List Buffer example
*
**/

/**
*
*  This program opens the Card Number 0, finds the first
*  compatible core, and configures an asynchronous transmit
*  list buffer. The program transmits one label synchronously
*  in a schedule, and transmits another label each time the
*  spacebar is hit by the user.
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
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 xmtchan = 0;
            char ch;
            bool done = false;
            bool xmtstat;
            Int32 xmtcount = 0;
            BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
            UInt32 asynclistaddr;

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP6    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI429 Example 6                                                  *");
            Console.Write("\n    *  \"Program for asynchronous list buffer.\"                           *");
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
                Console.Write("\n        an error occurred ({0}) opening the card.", hCard);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 429 card #{0}", CARDNUM);

            /**
            *
            *  Find the first ARINC 429 core with a transmit channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);
                if (0 != errval) break;

                for (xmtchan = 0; xmtchan < MAX_CHANNELS; xmtchan++) if (0 != BTI429.BTI429_ChIsXmt(xmtchan, hCore)) break;

                if (xmtchan != MAX_CHANNELS) break;
            }

            if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
            {
                Console.Write("\nError:  No ARINC 429 transmit channels present in card #{0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 429 core #{0}", corenum);
            Console.Write("\nUsing transmit channel #{0}", xmtchan);
            Console.Write("\n");

            /**
            *
            *  Configure xmtchan to transmit at low speed.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);							/*Reset the card*/

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_DEFAULT, xmtchan, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring", errval);
                Console.Write("\n        channel #{0} on core #{0}.", xmtchan, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Create a message for each of the synchronous labels we are transmitting.
            *
            **/

            xmt_airspeed.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT, hCore);

            /**
            *
            *  Create the asynchronous list buffer.
            *
            **/

            asynclistaddr = BTI429.BTI429_ListAsyncCreate(BTI429.LISTCRT429_FIFO, 16, xmtchan, hCore);

            /**
            *
            *  Next, a schedule is built by creating explicit message timing.
            *  While creating a schedule we can still use the SchedGap() function
            *  to create our gap times.  This function will determine that an
            *  asynchronous list buffer has been created for the channel, and will
            *  internally call the SchedGapList() function with appropriate parameters.
            *  Alternatively, we could use the SchedGapList() function directly
            *  and specify the address value ourselves. This method is useful if
            *  more than one asynchronous list buffer is desired per channel.
            *
            **/

            BTI429.BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore);
            BTI429.BTI429_SchedGap(1218, xmtchan, hCore);						//This line, and
            //	BTI429.BTI429_SchedGapList(1218,asynclistaddr,xmtchan,hCore);		//this line, do the same thing.

            /**
            *
            *  The synchronous message needs to be initialized.
            *
            **/

            BTI429.BTI429_MsgDataWr(0x00000086, xmt_airspeed.addr, hCore);

            /**
            *
            *  Start operation of the card.
            *
            **/

            errval = BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Display data on the screen.
            *
            **/

            Console.Write("\nPress spacebar to transmit the asynchronous message, press ESC to exit....\n\n");
            Console.Write("\nAsynchronous transmission count: {0:d4}", xmtcount);

            while (!done)
            {
                if (0 != Win32Interop._kbhit())
                {
                    ch = Win32Interop._getch();

                    if (ch == ' ')
                    {
                        xmtstat = 0 != BTI429.BTI429_ListDataWr(0x0000008A, asynclistaddr, hCore);
                        if (xmtstat) xmtcount++;
                        Console.Write("\rAsynchronous transmission count: {0:d4}", xmtcount);
                    }

                    if ((int)ch == 27)
                    {
                        done = true;
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
