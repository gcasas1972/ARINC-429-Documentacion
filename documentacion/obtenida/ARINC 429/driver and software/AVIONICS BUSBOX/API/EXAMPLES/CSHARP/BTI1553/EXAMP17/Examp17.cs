using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 17  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP17 -- Parametrics Example
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
*  The program uses the up and down arrow keys to control the
*  frequency output on the bus. The left and right arrow keys
*  are used to control the offset associated with the mid-bit
*  crossing.
*
**/

namespace EXAMP17
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Program
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 CMD0 = 0x0843;			/*Command word for first message*/
        private const Int32 CMD1 = 0x0821;			/*Command word for second message*/
        private const Int32 RCV_CMD2 = 0x0821;			/*Receive command of an RT-RT transfer*/
        private const Int32 XMT_CMD2 = 0x1C21;			/*Transmit command of an RT-RT transfer*/

        private const Int32	FRAMETIME = 10000;			/*Frame time in microseconds*/

        private const UInt16 DAC_HIGH = 0x0FFF;
        private const UInt16 DAC_LOW = 0x0599;
        private const UInt16 OFFSET_HIGH = 0x0064;
        private const UInt16 OFFSET_LOW = 0x0000;

        private const Int32 TRUE = 1;
        private const Int32 FALSE = 0;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            UInt32[] BCMsgs = new UInt32[3];
	        UInt16[] Data = new UInt16[3] {0,0,0};
	        UInt16 dacval = 0x0FF0;		/*Amplitude*/
	        UInt16 offset = 0x0032;		/*Mid-Bit crossing offset (error)*/
	        bool done = false;
	        char ch = 'a';

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP17   (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI1553 Example 17                                                *");
	        Console.Write("\n    *  \"Parametrics Example\"                                             *");
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
            *  Find the first MIL-STD-1553 core and channel that supports parametrics and
            *  error generation.
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
                        if (0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_PARAM, channum, hCore) &&
					        0 != BTI1553.BTI1553_ChGetInfo((UInt16)BTI1553.INFO1553_ERRORGEN,channum,hCore) )	break;
			        }
		        }

		        if (channum != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No 1553 channels that support parametrics and");
		        Console.Write("\n        error generation in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing MIL-STD-1553 core #{0}",corenum);
	        Console.Write("\nUsing parametric 1553 channel #{0}",channum);
	        Console.Write("\n");

            /**
            *
            *  Configure the channel for bus controller mode.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);									/*Reset the core*/

	        errval = BTI1553.BTI1553_BCConfig(BTI1553.BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	        if (0 != errval)
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
	        BCMsgs[1] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT,CMD1,0,ref Data[1],hCore);
            BCMsgs[2] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, ref Data[2], hCore);

            /**
            *
            *  Schedule the messages to create the desired bus controller
            *  schedule.
            *
            **/

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[2],  channum,hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);

	        BTI1553.BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	        BTI1553.BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);

            /**
            *
            *  Configure Parametrics on channum
            *
            **/

	        dacval = (dacval>DAC_HIGH) ? DAC_HIGH : dacval;
	        dacval = (dacval<DAC_LOW)  ? DAC_LOW : dacval;

            errval = BTI1553.BTI1553_ParamAmplitudeConfig(BTI1553.PARAMCFG1553_DEFAULT, dacval, channum, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the amplitude on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Define the type of error generation.  One of the bus
            *  controller messages is tagged to generate errors.
            *
            **/

	        offset = (offset>OFFSET_HIGH) ? OFFSET_HIGH:offset;
	        offset = (offset<OFFSET_LOW)  ? OFFSET_LOW:offset;

            errval = BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while defining",errval);
		        Console.Write("\n        the error on channel #{0} on core #{1}.",channum,corenum);
		        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        BTI1553.BTI1553_ErrorTagBC(TRUE,BCMsgs[0],channum,hCore);
            BTI1553.BTI1553_ErrorCtrl(BTI1553.ERRCTRL1553_ON | BTI1553.ERRCTRL1553_TAGMSG, channum, hCore);

            /**
            *
            *  Start the card to begin receiving messages.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Change parametric values when arrow keys are pressed. Exit when ESC is pressed.
            *
            **/

	        Console.Write("\n\tOPTIONS:");
	        Console.Write("\n\tARROW UP    = Add 16 to dacval");
	        Console.Write("\n\tARROW DOWN  = Subtract 16 from dacval");
	        Console.Write("\n\tARROW RIGHT = Increment offset");
	        Console.Write("\n\tARROW LEFT  = Decrement offset");
	        Console.Write("\n\tESC         = Exit program");
	        Console.Write("\n\n");

	        while (false == done)
	        {
                Console.Write("\r\tDacval: {0:X3} (Hex)   Offset: {1:X3} (Hex)", dacval, offset);

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
                            if (ch == 72) dacval = ((UInt16)(dacval + 16) > DAC_HIGH) ? DAC_HIGH : (UInt16)(dacval + 16);
                            else dacval = ((UInt16)(dacval - 16) < DAC_LOW) ? DAC_LOW : (UInt16)(dacval - 16);

					        BTI1553.BTI1553_ChStop(channum,hCore);

                            errval = BTI1553.BTI1553_ParamAmplitudeConfig(BTI1553.PARAMCFG1553_DEFAULT, dacval, channum, hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        Amplitude on channel #{0} on core #{1}.",channum,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
                                done = true;
					        }

					        BTI1553.BTI1553_ChStart(channum,hCore);

					        break;
				        }
				        case 75:	/* LEFT  */
				        case 77:	/* RIGHT */
				        {
					        if (ch==77)	offset = ((UInt16)(offset+1)>OFFSET_HIGH) ? OFFSET_HIGH : (UInt16)(offset+1);
					        else		offset = ((UInt16)(offset-1)<OFFSET_LOW)  ? OFFSET_LOW  : (UInt16)(offset-1);

					        BTI1553.BTI1553_ChStop(channum,hCore);

                            errval = BTI1553.BTI1553_ErrorDefine(BTI1553.ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while defining",errval);
						        Console.Write("\n        the error on channel #{0} on core #{1}.",channum,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
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
