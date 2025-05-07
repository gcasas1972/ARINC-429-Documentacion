using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 8  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8 -- Errors in RT Transmissions
*
**/

/**
*
*  This example requires a Ballard 1553 C version Device or higher.
*  It configures Card Number 0 as an RT and configures a response
*  time error for transmit commands of subaddress 2.  Each time the
*  subaddress is accessed, the response time is incremented by
*  0.1us.
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

        private const Int32 TRUE = 1;
        private const Int32 FALSE = 0;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt16  GapLength;				/*Gap in units of 0.1us*/

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP8    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 8                                                 *");
	        Console.Write("\n    *  \"Errors in RT Transmissions\"                                      *");
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
		        Console.Write("\nError:  No MIL-STD-1553 version C or D channels present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing MIL-STD-1553 core #{0}",corenum);
	        Console.Write("\nUsing MIL-STD-1553 channel #{0}",channum);
	        Console.Write("\n");

            /**
            *
            *  Configure the channel for remote terminal mode.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI1553.BTI1553_RTConfig(BTI1553.RTCFG1553_DEFAULT,1,channum,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring for",errval);
		        Console.Write("\n        remote terminal mode on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Define the type and location of the gap.
            *
            **/

	        GapLength = 120;					/*Set initial gap length to 12us (Each GapLength=0.1 microseconds)*/

            BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_GAP, /*Generate a gap*/
						        GapLength, 		/*Set the length of the gap*/
						        0, 				/*Unused parameter*/
                                (UInt16) BTI1553.ERRDEF1553_SWD1,/*Gap precedes the status word*/
						        0,				/*Unused parameter*/
						        channum,		/*Channel number*/
						        hCore);

	        BTI1553.BTI1553_ErrorTagRT(TRUE,(Int32)BTI1553.SUBADDRESS,1,BTICARD.XMT,2,channum,hCore);
            BTI1553.BTI1553_ErrorCtrl(BTI1553.ERRCTRL1553_ONCE | BTI1553.ERRCTRL1553_TAGMSG, channum, hCore);

            /**
            *
            *  Start the card to begin responding to transmissions.
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
		        if (0 != BTI1553.BTI1553_ErrorSent(channum,hCore) /*AND ANOTHER ERROR DESIRED*/)
		        {
                    BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_GAP,	/*Change the length of the gap*/
							        ++GapLength,		/*Set the length of the new gap*/
							        0, 					/*Unused parameter*/
                                    (UInt16)BTI1553.ERRDEF1553_SWD1,	/*Gap precedes the status word*/
							        0,					/*Unused parameter*/
							        channum,			/*Channel number*/
							        hCore);

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
