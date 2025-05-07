using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 6  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6 -- Errors in BC Transmissions - Unscheduled Messages
*
**/

/**
*
*  This example requires a Ballard 1553 C version Device or higher.
*  It configures Card Number 0 as a BC and transmits a single
*  receive command containing a parity error in the command
*  word.
*
*  A No response is expected because of the parity error in the
*  command word.
*
**/

namespace EXAMP6
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
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
            Int32 channum = 0;

            BTI1553.XMITFIELDS1553 Msg = new BTI1553.XMITFIELDS1553();

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP6    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI1553 Example 6                                                 *");
            Console.Write("\n    *  \"Errors in BC Transmissions - Unscheduled Messages\"               *");
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

            Console.Write("\nUsing BTI1553 card #{0}", CARDNUM);

            /**
            *
            *  Find the first MIL-STD-1553 core and C or D version channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);
                if (0 != errval) break;

                for (channum = 0; channum < MAX_CHANNELS; channum++)
                {
                    if (0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_ERRORGEN, channum, hCore)) break;
                }

                if (channum != MAX_CHANNELS) break;
            }

            if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
            {
                Console.Write("\nError:  No MIL-STD-1553 version C or D channels present in cardnum {0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing MIL-STD-1553 core #{0}", corenum);
            Console.Write("\nUsing MIL-STD-1553 channel #{0}", channum);
            Console.Write("\n");

            /**
            *
            *  Configure the channel for bus controller mode.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);									/*Reset the core*/

            errval = BTI1553.BTI1553_BCConfig(BTI1553.BCCFG1553_DEFAULT, channum, hCore);	/*Configure the core*/

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring for", errval);
                Console.Write("\n        bus controller mode on channel #{0} on core #{1}.", channum, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Create an empty frame in the BC Schedule.
            *
            *  BTI1553.BTI1553_BCTransmitMsg uses an asynchronous Message Record
            *  that is transmitted at the end of every frame.  Therefore,
            *  even though we aren't scheduling messages, we must still
            *  schedule a frame.
            *
            **/

            BTI1553.BTI1553_BCSchedFrame(1000, channum, hCore);

            /**
            *
            *  Initialize the message command and data words, and select
            *  a BC->RT transfer.
            *
            **/

            Msg.ctrlflags = BTI1553.MSGCRT1553_BCRT;
            Msg.cwd1 = 0x0843;
            Msg.data = new UInt16[32];
            Msg.data[0] = 0x1234;
            Msg.data[1] = 0x5678;
            Msg.data[2] = 0x9ABC;

            /**
            *
            *  Define the type of error generation.
            *
            **/

            errval = BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_PAR, 0, 0, (UInt16)BTI1553.ERRDEF1553_CWD1, 0, channum, hCore);
            errval = BTI1553.BTI1553_ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_ANYMSG, channum, hCore);

            /**
            *
            *  Start the card.
            *
            **/

            BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Transmit the message.
            *
            **/

            errval = BTI1553.BTI1553_BCTransmitMsg(ref Msg, channum, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while transmitting", errval);
                Console.Write("\n        the message on channel #{0} on core #{1}.", channum, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Test for any error results. No response is the expected result.
            *
            **/

            if (0!= (Msg.errflags & BTI1553.MSGERR1553_NORESP))		/*Was there a response?*/
            {
                Console.Write("\nWarning:  No response was received from the RT.");
                Console.Write("\n          Refer to the documentation for a");
                Console.Write("\n          description of the error flags ({0:X}H).", Msg.errflags);
                Console.Write("\n");
            }
            else if (0!= (Msg.errflags & BTI1553.MSGERR1553_ANYERR))	/*Was there an error?*/
            {
                Console.Write("\nWarning:  An error occurred while receiving the response from the RT.");
                Console.Write("\n          Refer to the documentation for a");
                Console.Write("\n          description of the error flags ({0:X}H).", Msg.errflags);
                Console.Write("\n");
            }
            else									/*There were no errors*/
            {
                Console.Write("\nSuccess!  The message was completed successfully.");
                Console.Write("\n          The RT returned the status word {0:X}H.", Msg.swd1);
                Console.Write("\n");
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
