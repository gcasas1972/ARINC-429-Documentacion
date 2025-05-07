using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 4  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4 -- Explicit message timing
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and builds a transmit schedule
*  using explicit message timing. The self-test
*  wraparound is enabled and filters are set to
*  receive the messages.  The minimum and maximum elapsed
*  time for each message is displayed.
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
            BTI429.MSGSTRUCT429 xmt_airspeed = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 xmt_altitude = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 rcv_airspeed = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 rcv_altitude = new BTI429.MSGSTRUCT429();
            BTI429.MSGFIELDS429 airspeed_record = new BTI429.MSGFIELDS429();
            BTI429.MSGFIELDS429 altitude_record = new BTI429.MSGFIELDS429();

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP4    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI429 Example 4                                                  *");
            Console.Write("\n    *  \"Program for explicit message timing.\"                            *");
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
            *  Find the first ARINC 429 core with both a receive and a transmit channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                rcvfound = false;
                xmtfound = false;

                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);	/* Open a handle to the core. */
                if (0 != errval) break;

                for (rcvchan = 0; rcvchan < MAX_CHANNELS; rcvchan++)		/* Search for receive channel. */
                {
                    rcvfound = 0 != BTI429.BTI429_ChIsRcv(rcvchan, hCore);
                    if (rcvfound) break;
                }

                if (rcvfound)
                {
                    for (xmtchan = 0; xmtchan < MAX_CHANNELS; xmtchan++)	/* Search for transmit channel. */
                    {
                        xmtfound = 0 != BTI429.BTI429_ChIsXmt(xmtchan, hCore);
                        if (xmtfound) break;
                    }
                }

                if (rcvfound && xmtfound) break;
            }

            if (0 != errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
            {
                Console.Write("\nError:  No compatible ARINC 429 core present in card #{0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 429 core #{0}", corenum);
            Console.Write("\nUsing receive channel #{0}", rcvchan);
            Console.Write("\nUsing transmit channel #{0}", xmtchan);
            Console.Write("\n");

            /**
            *
            *  Configure rcvchan to receive at low speed with the
            *  Min/Max Elapse Time option also enabled.
            *  Note that the self-test wraparound is also enabled.
            *
            *  Configure xmtchan to transmit at low speed.
            *  Note that the self-test wraparound is also enabled.
            *  The external line drivers are disabled, and xmtchan is
            *  connected internally to all the receive channels.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);                   /*Reset the card*/

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_MAXMIN | BTI429.CHCFG429_SELFTEST, rcvchan, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring", errval);
                Console.Write("\n        channel #{0} on core #{1}.", rcvchan, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCore));
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_SELFTEST, xmtchan, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring", errval);
                Console.Write("\n        channel #{0} on core #{1}.", xmtchan, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCore));
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Before any messages can be received, filters must be set
            *  for the receive channel.  Two filters are set for the
            *  two messages of interest.
            *
            **/

            rcv_airspeed.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_DEFAULT, 0x86, (Int32)BTI429.SDIALL, rcvchan, hCore);
            rcv_altitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_DEFAULT, 0x8A, (Int32)BTI429.SDIALL, rcvchan, hCore);

            /**
            *
            *  Create a message for each of the labels we are transmitting.
            *
            **/

            xmt_airspeed.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT, hCore);
            xmt_altitude.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT, hCore);

            /**
            *
            *  Next, a schedule is built by creating explicit message timing.
            *
            **/

            BTI429.BTI429_SchedMsg(xmt_altitude.addr, xmtchan, hCore);
            BTI429.BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore);
            BTI429.BTI429_SchedGap(495, xmtchan, hCore);
            BTI429.BTI429_SchedMsg(xmt_altitude.addr, xmtchan, hCore);
            BTI429.BTI429_SchedGap(531, xmtchan, hCore);

            /**
            *
            *  Those messages that are to be transmitted are initialized.
            *
            **/

            BTI429.BTI429_MsgDataWr(0x0000008A, xmt_altitude.addr, hCore);
            BTI429.BTI429_MsgDataWr(0x00000086, xmt_airspeed.addr, hCore);

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

            while (0 == Win32Interop._kbhit())
            {
                BTI429.BTI429_MsgBlockRd(ref airspeed_record, rcv_airspeed.addr, hCore);
                BTI429.BTI429_MsgBlockRd(ref altitude_record, rcv_altitude.addr, hCore);

                Console.Write("\r");

                Console.Write("AirSpeed: min/max={0:d2}ms/{1:d2}ms ",
                (airspeed_record.mintime / 1000),
                (airspeed_record.maxtime_elapsetime / 1000));

                Console.Write("Altitude: min/max={0:d2}ms/{1:d2}ms ",
                (altitude_record.mintime / 1000),
                (altitude_record.maxtime_elapsetime / 1000));

                Console.Write("        ");
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
