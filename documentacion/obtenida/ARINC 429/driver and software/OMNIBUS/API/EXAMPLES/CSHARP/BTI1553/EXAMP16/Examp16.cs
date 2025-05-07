using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 16  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP16 -- RT Response Time
*
**/

/**
*
*  This example configures Card Number 0 as an RT to receive
*  the BC-RT data transmitted by the bus controller in
*  Example 2. The programmable RT response time is set and then
*  controlled by the up and down arrow keys. The program runs
*  until the ESC key is pressed.
*
**/

namespace EXAMP16
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Examp16
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 MAX_RESPTIME = 255;
        private const Int32 MIN_RESPTIME = 77;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            Int32 resptime = 0;
	        bool done = false;
	        char ch;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP16   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 16                                                *");
	        Console.Write("\n    *  \"RT Response Time example.\"                                       *");
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
            *  Find the first MIL-STD-1553 core and channel that supports
            *  programmable RT response time.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (channum=0;channum<MAX_CHANNELS;channum++)
		        {
			        if (0 != BTI1553.BTI1553_ChIs1553(channum,hCore) )
			        {
                        if (0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_RTRESPTIME, channum, hCore)) break;
			        }
		        }

		        if (channum != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No 1553 channels that support programmable RT");
		        Console.Write("\n        response time present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing MIL-STD-1553 core #{0}",corenum);
	        Console.Write("\nUsing programmable RT response time 1553 channel #{0}",channum);
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
            *  Set the Programmable RT Response Time
            *
            **/

	        resptime = 80;
	        errval = BTI1553.BTI1553_RTResponseTimeSet(resptime,1,channum,hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while setting the",errval);
		        Console.Write("\n        RT response time on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Start the card to begin receiving messages.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Change response time values when arrow keys are pressed. Exit when ESC is pressed.
            *
            **/

	        Console.Write("\n\tOPTIONS:");
	        Console.Write("\n\tARROW UP    = Add 10 to resptime");
	        Console.Write("\n\tARROW DOWN  = Subtract 10 from resptime");
	        Console.Write("\n\tESC         = Exit program");
	        Console.Write("\n\n");

	        while (!done)
	        {
		        Console.Write("\r\tresptime: {0:X3} (Hex)",resptime);

		        if (0 != Win32Interop._kbhit())
		        {
                    ch = Win32Interop._getch();

                    if (ch == 0xE0) ch = Win32Interop._getch();	/* When reading arrow key _getch() must be called twice. */

			        switch ((int)ch)
			        {
				        case 27:	/* ESC */
				        {
                            done = true;
					        break;
				        }
				        case 72:	/* UP   */
				        case 80:	/* DOWN */
				        {
					        if (ch==72)	resptime = (resptime+10>MAX_RESPTIME) ? MAX_RESPTIME : resptime+10;
					        else        resptime = (resptime-10<MIN_RESPTIME) ? MIN_RESPTIME : resptime-10;

					        BTI1553.BTI1553_ChStop(channum,hCore);

					        errval = BTI1553.BTI1553_RTResponseTimeSet(resptime,1,channum,hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while setting the",errval);
						        Console.Write("\n        RT response time on channel #{0} on core #{1}.",channum,corenum);
						        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
						        Console.Write("\n");
                                done = true;
					        }

					        BTI1553.BTI1553_ChStart(channum,hCore);

					        break;
				        }
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
