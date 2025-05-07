using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 7  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7 -- Errors in BC Transmissions - Scheduled Messages
*
**/

/**
*
*  This example requires a Ballard 1553 C version Device or higher.
*  It configures Card Number 0 as a BC and creates a schedule
*  containing a receive command each for terminal address 1
*  and terminal address 2.  Both receive commands send 2 data
*  words to the remote terminal.  The example then alternates
*  a bit count error between the first data word of both
*  commands.
*
**/

namespace EXAMP7
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp7
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 FRAMETIME = 10000;			/*Frame time in microseconds*/

        private const Int32 TRUE = 1;
        private const Int32 FALSE = 0;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt32[] BCMsgs = new UInt32[2];
	        Int32 ErrorCount = 0;
	        UInt16 InitialData1 = 0;
	        UInt16 InitialData2 = 0;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP7    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 7                                                 *");
	        Console.Write("\n    *  \"Errors in BC Transmissions - Scheduled Messages\"                 *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    **********************************************************************");

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
            *  Find the first MIL-STD-1553 core and C or D version channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (channum=0;channum<MAX_CHANNELS;channum++)
		        {
			        if ( 0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_ERRORGEN,channum,hCore) ) break;
		        }

		        if (channum != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No MIL-STD-1553 version C or D channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing MIL-STD-1553 core #{0}",corenum);
	        Console.Write("\nUsing MIL-STD-1553 channel #{0}",channum);
	        Console.Write("\n");

            /**
            *
            *  Configure the channel for bus controller mode.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);									/*Reset the core*/

	        errval = BTI1553.BTI1553_BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring for",errval);
		        Console.Write("\n        bus controller mode on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create the message records.
            *
            **/

	        BCMsgs[0] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,0x0842,0,ref InitialData1,hCore);
	        BCMsgs[1] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,0x1042,0,ref InitialData2,hCore);

            /**
            *
            *  Schedule the messages to create the desired bus controller
            *  schedule.
            *
            **/

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[1],channum,hCore);

            /**
            *
            *  Define the type of error generation.  One of the bus
            *  controller messages is tagged to generate errors once.
            *
            **/

	        BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_CNTBIT,3,2,0,0,channum,hCore);
	        BTI1553.BTI1553_ErrorTagBC(TRUE,BCMsgs[0],channum,hCore);
            BTI1553.BTI1553_ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG, channum, hCore);

            /**
            *
            *  Start the card to begin transmissions.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        while (0 == Win32Interop._kbhit())
	        {

                /**
                *
                *  When the error is generated once, tag another message for
                *  error generation and enable another single error.
                *
                **/

		        if (0 != BTI1553.BTI1553_ErrorSent(channum,hCore) /*AND ANOTHER ERROR DESIRED*/)
		        {
			        if (0 != ((++ErrorCount) & 1))
			        {
				        BTI1553.BTI1553_ErrorTagBC(FALSE,BCMsgs[0],channum,hCore);
				        BTI1553.BTI1553_ErrorTagBC(TRUE, BCMsgs[1],channum,hCore);
			        }
			        else
			        {
				        BTI1553.BTI1553_ErrorTagBC(TRUE, BCMsgs[0],channum,hCore);
				        BTI1553.BTI1553_ErrorTagBC(FALSE,BCMsgs[1],channum,hCore);
			        }

                    BTI1553.BTI1553_ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG, channum, hCore);
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
