using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 10  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10 -- Polling the Event Log List
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The schedule is also configured to generate an Event Log List
*  entry after each 10ms frame.  When an entry is read from the list,
*  the data words associated with the 0843H BC-RT message is updated.
*
**/

namespace EXAMP10
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp10
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 CMD0 = 0x0843;			/*Command word for first message*/
        private const Int32 CMD1 = 0x0821;			/*Command word for second message*/
        private const Int32 RCV_CMD2 = 0x0821;			/*Receive command of an RT-RT transfer*/
        private const Int32 XMT_CMD2 = 0x1C21;			/*Transmit command of an RT-RT transfer*/

        private const Int32 FRAMETIME = 10000;			/*Frame time in microseconds*/

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt32[] BCMsgs = new UInt32[3];
	        UInt16[] Data = new UInt16[3] {0,0,0};
	        UInt16 type = 0;
	        UInt32 info = 0;
            Int32 chan = 0;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP10   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 10                                                *");
	        Console.Write("\n    *  \"Polling the Event Log List\"                                      *");
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
            *  Find the first MIL-STD-1553 core and channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (channum=0;channum<MAX_CHANNELS;channum++)
			        if (0 != BTI1553.BTI1553_ChIs1553(channum,hCore)) break;

		        if (channum != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No MIL-STD-1553 channels present in card #{0}.",CARDNUM);
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
		        Console.Write("\nError:  An error was encountered ({0}) while configuring bus",errval);
		        Console.Write("\n        controller mode on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create the message records for each of the three messages.
            *
            **/

	        Data[0] = 0;
	        Data[1] = 0;
	        Data[2] = 0;

	        BCMsgs[0] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD0,0,ref Data[0],hCore);
            BCMsgs[1] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT, CMD1, 0, ref Data[1], hCore);
            BCMsgs[2] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_RTRT,RCV_CMD2,XMT_CMD2,ref Data[2], hCore);

            /**
            *
            *  Schedule the messages to create the desired bus controller
            *  schedule.  Also schedule an Event Log after each frame.
            *  Note the unique tag value associated with each Event Log
            *  that could be used to distinguish unique Events.
            *
            **/

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],             channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[1],             channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[2],             channum,hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x1111, channum, hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],             channum,hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x2222, channum, hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],             channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[1],             channum,hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x3333, channum, hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],             channum,hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x4444, channum, hCore);

            /**
            *
            *  Configure the Event Log list.
            *
            **/

            errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE, 1024, hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        event log list on core #{1}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

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
		        if (0 != BTICARD.BTICard_EventLogRd(ref type,ref info,ref chan, hCore))
		        {
			        /*Calculate the new data words*/
			        Data[0] += 2;
			        Data[1] += 4;
			        Data[2] += 6;

			        /*Write the new data words*/
			        BTI1553.BTI1553_MsgDataWr(ref Data[0],3,BCMsgs[0],hCore);

			        Console.Write("\rTransmitting data {0:X4}H, {0:X4}H, {0:X4}H",Data[0],Data[1],Data[2]);
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
