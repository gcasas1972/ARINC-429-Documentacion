using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 8  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8 -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and configures the first receive
*  channel to receive 2 GPS messages into separate
*  Message Records; and receive all other messages
*  into a default Message Record.
*
*  Each of the messages is also configured to generate an
*  Event Log List entry.  When an entry is read from the list,
*  the associated data is read.
*
**/

namespace EXAMP8
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp8
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
            UInt16 Type = 0;
            UInt32 Info = 0;
            Int32 Chan = 0;
            UInt32 msgaddr;
            BTI429.MSGSTRUCT429 msgdefault = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 latitude = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 longitude = new BTI429.MSGSTRUCT429();

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP8    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI429 Example 8                                                  *");
            Console.Write("\n    *  \"Polling the Event Log List.\"                                     *");
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
            *  Configure rcvchan for automatic speed detection.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);

            errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_AUTOSPEED, rcvchan, hCore);   /*Configure channel*/

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
            *  Each message is configured to create Event Log list entries.
            *
            **/

            msgdefault.addr = BTI429.BTI429_FilterDefault(BTI429.MSGCRT429_LOG, rcvchan, hCore);
            latitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_LOG, 0xC8, (Int32)BTI429.SDIALL, rcvchan, hCore);
            longitude.addr = BTI429.BTI429_FilterSet(BTI429.MSGCRT429_LOG, 0xC9, (Int32)BTI429.SDIALL, rcvchan, hCore);

            /**
            *
            *  Initialize data values to zero.
            *
            **/

            msgdefault.data = 0;
            latitude.data = 0;
            longitude.data = 0;

            /**
            *
            *  Configure the Event Log list.
            *
            **/

            errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE, 1024, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring", errval);
                Console.Write("\n        the event log list on core #{0}.", corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
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

            while (0 == Win32Interop._kbhit())
            {
                if (0 != BTICARD.BTICard_EventLogRd(ref Type, ref Info, ref Chan, hCore))	//Read entry from Event Log list
                {
                    msgaddr = Info;								//Info value is message address

                    if (msgaddr == msgdefault.addr)
                    {
                        msgdefault.data = BTI429.BTI429_MsgDataRd(msgaddr, hCore);
                    }
                    else if (msgaddr == latitude.addr)
                    {
                        latitude.data = BTI429.BTI429_MsgDataRd(msgaddr, hCore);
                    }
                    else if (msgaddr == longitude.addr)
                    {
                        longitude.data = BTI429.BTI429_MsgDataRd(msgaddr, hCore);
                    }
                }

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
