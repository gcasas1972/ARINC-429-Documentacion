using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 12  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP12 -- BC Transmission of Ramping Data Using a FIFO
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of one message.  The message is
*  transmitted at a frequency of 10Hz (or every 100ms).
*
*  A FIFO of 100 entries is configured for the message.
*  Before staring the card, the FIFO is filled with unique
*  sets of data words.  After the card is started, the
*  program continually pushes new sets of data into the FIFO
*  until the program stops.
*
**/

namespace EXAMP12
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp12
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 CMD = 0x0820;					/*Command word for message*/

        private const Int32 FRAMETIME = 100000;			/*Frame time in microseconds*/

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt32 BCList;
	        UInt16[] Data = new UInt16[32];
	        Int32 Result;
            Int32 j;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP12   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 12                                                *");
	        Console.Write("\n    *  \"BC Transmission of Ramping Data Using a FIFO\"                    *");
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
            *  Create the FIFO List Buffer.
            *
            **/

	        BCList = BTI1553.BTI1553_BCCreateList(
                BTI1553.LISTCRT1553_FIFO,			/*List creation flags*/
		        100,						/*List size*/
		        BTI1553.MSGCRT1553_DEFAULT,			/*Message creation flags*/
		        CMD,						/*Command Word 1*/
		        0,							/*Command Word 2*/
		        ref Data[0],						/*Initial data (if any)*/
		        hCore);						/*Device handle*/

            /**
            *
            *  Schedule the messages to create the desired bus controller
            *  schedule.
            *
            **/

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCList,     channum,hCore);

            /**
            *
            *  Fill the FIFO with the initial data.
            *
            **/

	        for (j=0;j<32;++j) Data[j]=0;

	        do
	        {
		        Console.Write("\nWrote data value {0:X4}H.",Data[0]);
                Result = BTI1553.BTI1553_ListDataWr(ref Data[0], 32, BCList, hCore);
		        ++Data[0];
	        } while(0 != Result);

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
		        do
		        {
                    Result = BTI1553.BTI1553_ListDataWr(ref Data[0], 32, BCList, hCore);
		        } while(0 == Result);

		        Console.Write("\nWrote data value {0:X4}H.  Press any key to exit.",Data[0]);

		        ++Data[0];
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
