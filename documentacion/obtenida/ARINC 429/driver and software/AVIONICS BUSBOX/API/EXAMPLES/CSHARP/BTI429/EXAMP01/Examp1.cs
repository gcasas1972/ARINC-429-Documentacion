using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 1  (06/07/2011)
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
*  first compatible core to receive 2 GPS messages into
*  separate Message Records, and receive all other
*  messages into a default Message Record.
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
            BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP1    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI429 Example 1                                                  *");
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

            Console.Write("\nUsing ARINC 429 card #{0}", CARDNUM);

            /**
            *
            *  Find the first ARINC 429 core with a receive channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);
                if (0 != errval) break;

                for (rcvchan = 0; rcvchan < MAX_CHANNELS; rcvchan++) if (0 != BTI429.BTI429_ChIsRcv(rcvchan, hCore)) break;

                if (rcvchan != MAX_CHANNELS) break;
            }

            if (0 != errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
            {
                Console.Write("\nError:  No ARINC 429 receive channels present in cardnum {0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing ARINC 429 core #{0}", corenum);
            Console.Write("\nUsing receive channel #{0}", rcvchan);
            Console.Write("\n");

            /**
            *
            *  Configure receiver channel for automatic speed detection.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_AUTOSPEED, rcvchan, hCore);

            if (0 != errval)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring", errval);
                Console.Write("\n        channel #{0} on core #{0}.", rcvchan, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Before any messages can be received, filters must be set
            *  for the receive channel.  First, the default filter is
            *  created.  Then, two filters are set for the two messages
            *  of interest.
            *
            **/

            msgdefault.addr = BTI429.BTI429_FilterDefault(BTI429.MSGCRT429_DEFAULT, rcvchan, hCore);
            latitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_DEFAULT, 0xC8, (int)BTI429.SDIALL, rcvchan, hCore);
            longitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_DEFAULT, 0xC9, (int)BTI429.SDIALL, rcvchan, hCore);

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
                /*Read message records*/
                msgdefault.data = BTI429.BTI429_MsgDataRd(msgdefault.addr, hCore);
                latitude.data = BTI429.BTI429_MsgDataRd(latitude.addr, hCore);
                longitude.data = BTI429.BTI429_MsgDataRd(longitude.addr, hCore);

                /*Display values*/
                Console.Write("\r");
                Console.Write("Default={0:X8} ", msgdefault.data);
                Console.Write("Latitude={0:X8} ", latitude.data);
                Console.Write("Longitude={0:X8}", longitude.data);
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
