using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 1  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1 -- Transmitter example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first transmit
*  channel to transmit a sequence of 32 messages at a
*  rate of 200Hz.  The messages are automatically
*  assigned the numbers 0 through 31.
*
*  An Event Log frequency of 16 is specified, which will
*  cause the channel to issue an Event Log List entry
*  every 16th message (message numbers 15, and 31).
*  The program uses these events to update he data for
*  the half of messages that were just transmitted.
*
*  The program continues in this manner until a key is
*  pressed.
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

        private const UInt16 FRAMEFREQ = 200;          /*Frame frequency of 200Hz*/
        private const UInt16 LOGFREQ = 16;           /*Generate a Log Event after every 16th message*/
        private const UInt16 FRAMECOUNT = 32;           /*Transmit a total of 32 messages*/

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;

            Int32 xmtchan = 0;
            UInt16 j, jj;
	        UInt16[] Data = new UInt16[100];
	        UInt16 Type = 0;
	        UInt32 Info = 0;
            Int32 Chan = 0;
	        UInt16 framenum = 0;
            UInt16 count = 0;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP1   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 1                                                  *");
	        Console.Write("\n    *  \"Program for transmitter example.\"                                *");
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

            /**
            *
            *  Find the first ARINC 708 core with a transmit channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (0 != BTI708.BTI708_ChIsXmt(xmtchan,hCore)) break;

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 708 transmit channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\nUsing transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure transmit channel.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_DEFAULT,xmtchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Build the transmit channel messages.
            *
            **/

	        errval = BTI708.BTI708_XmtBuild(BTI708.MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,xmtchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create and write the data for the messages.
            *
            **/

	        for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
	        {
		        for (jj=0;jj<100;jj++) Data[jj] = (UInt16)(j + (count * FRAMECOUNT));
		        BTI708.BTI708_MsgDataWr(ref Data[0],j,xmtchan,hCore);	/*Write data to the Device*/
	        }
	        count++;

            /**
            *
            *  Configure the Event Log list.
            *
            **/

	        errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE,1024,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the event log list on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
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
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit...");
	        Console.Write("\n\n");

	        while (0 == Win32Interop._kbhit())
	        {
		        if (0 != BTICARD.BTICard_EventLogRd(ref Type,ref Info,ref Chan, hCore))	//Read entry from Event Log list
		        {
			        framenum = (UInt16)Info;

			        if (framenum == ((FRAMECOUNT/2)-1))			//First half transmitted
			        {
				        Console.Write("\rUpdating frames 0 - {0}",framenum);
				        for (j=0;j<=(FRAMECOUNT/2)-1;j++)
				        {
					        for (jj=0;jj<100;jj++) Data[jj] = (UInt16)(j + (count * FRAMECOUNT));
					        BTI708.BTI708_MsgDataWr(ref Data[0],j,xmtchan,hCore);
				        }
			        }
			        else if (framenum == (FRAMECOUNT-1))		//Second half transmitted
			        {
				        Console.Write("\rUpdating frames {0} - {0}",(FRAMECOUNT/2),framenum);
				        for (j=(FRAMECOUNT/2);j<=framenum;j++)
				        {
					        for (jj=0;jj<100;jj++) Data[jj] = (UInt16)(j + (count * FRAMECOUNT));
					        BTI708.BTI708_MsgDataWr(ref Data[0],j,xmtchan,hCore);
				        }
				        count++;
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
