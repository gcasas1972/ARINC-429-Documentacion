using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 5  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5 -- Simultaneous BC, RT, and monitor simulation
*
**/

/**
*
*  This example requires a Ballard 1553 C version Device or higher.
*  It configures Card Number 0 as a BC, an RT, and a Bus Monitor.
*  The BC transmits one BC-RT message (command word 0843H).
*  The RT is configured with terminal address 1, so the
*  simulated RT receives the simulated BC's transmissions.
*  The data words transmitted by the RT are incremented and
*  displayed.  The data words received by the RT are read and
*  also displayed.
*
**/

namespace EXAMP5
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp5
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 FRAMETIME = 10000;			/*Frame time in microseconds*/

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt32 BCMsg;
	        UInt32 RTMsg;
	        UInt16[] BCData = new UInt16[3] {0,0,0};
	        UInt16[] RTData = new UInt16[3] {0,0,0};

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP5    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 5                                                 *");
	        Console.Write("\n    *  \"Simultaneous BC, RT, and monitor simulation example.\"            *");
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
                    if (0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_MULTIMODE, channum, hCore)) break;
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
            *  Create a bus controller message and insert into the bus
            *  controller schedule.
            *
            **/

	        BCMsg = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,0x0843,0,ref BCData[0],hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsg,channum,hCore);

            /**
            *
            *  Configure the channel for remote terminal mode as shown in
            *  Example 3.
            *
            **/

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
            *  Get the message address for a receive subaddress.
            *
            **/

	        RTMsg = BTI1553.BTI1553_RTGetMsg((Int32)BTI1553.SUBADDRESS,1,BTICARD.RCV,2,channum,hCore);

            /**
            *
            *  Configure the channel for monitor mode as shown in Example 4.
            *
            **/

	        errval = BTI1553.BTI1553_MonConfig(BTI1553.MONCFG1553_DEFAULT,channum,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring for",errval);
		        Console.Write("\n        monitor mode on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        BTI1553.BTI1553_MonFilterTA(0x00000002,channum,hCore);	/*Monitor RT address 1*/

            /**
            *
            *  Configure the sequential record.
            *
            **/

	        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring the",errval);
		        Console.Write("\n        sequential record on on core #{1}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Start the card to begin transmitting, receiving and monitoring messages.
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
		        Console.Write("\r");

		        BCData[0] += 2;		/*Update the data that the BC is transmitting*/
		        BCData[1] += 4;
		        BCData[2] += 6;

		        Console.Write("Transmitting data {0:X4}H, {1:X4}H, {2:X4}H ",BCData[0],BCData[1],BCData[2]);

		        BTI1553.BTI1553_MsgDataWr(ref BCData[0],3,BCMsg,hCore);

		        BTI1553.BTI1553_MsgDataRd(ref RTData[0],3,RTMsg,hCore);	/*Read the data received by the RT*/

		        Console.Write("Received data {0:X4}H, {1:X4}H, {2:X4}H ",RTData[0],RTData[1],RTData[2]);
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
