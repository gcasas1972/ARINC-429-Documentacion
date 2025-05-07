using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 10  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10 -- Parametrics example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first transmit channel on the first 708 Core to transmit
*  a sequence of 32 messages at a rate of 200Hz. The messages
*  are automatically assigned the numbers 0 through 31.
*
*  The user can then control the amplitude using the UP and
*  DOWN arrow keys.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

namespace EXAMP10
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Examp10
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32	FRAMEFREQ = 200;            /*Frame frequency of 200Hz*/
        private const Int32 LOGFREQ = 16;               /*Generate a Log Event after every 16th message*/
        private const Int32 FRAMECOUNT = 32;            /*Transmit a total of 32 messages*/

        private const UInt16 DAC_HIGH = 0x0FFF;
        private const UInt16 DAC_LOW = 0x0599;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 xmtchan = 0;
            Int32 j, jj;
	        UInt16[] Data = new UInt16[100];
            UInt16 dacval = 0x0FF0;		/* Amplitude */
            Int32 count = 0;
	        bool done;
	        char ch;

	        Console.Write("\n\t**********************************************************************");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  EXAMP10  (06/07/2011)                                             *");
	        Console.Write("\n\t*  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n\t*  All rights reserved.                                              *");
	        Console.Write("\n\t*  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  BTI708 Example 10                                                 *");
	        Console.Write("\n\t*  \"Parametrics example.\"                                            *");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t**********************************************************************");
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
            *  Find the first ARINC 708 core with a transmit channel that supports parametrics.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		        {
                    if (0 != BTI708.BTI708_ChIsXmt(xmtchan, hCore) && 0 != BTI708.BTI708_ChGetInfo((UInt16)BTI708.INFO708_PARAM, xmtchan, hCore)) break;
		        }

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 708 parametric transmit channels");
		        Console.Write("\n        present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\n\tUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\n\tUsing parametric transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure xmtchan
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_DEFAULT,xmtchan,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
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
            *  Configure Parametrics on xmtchan.
            *
            **/

	        dacval = (dacval>DAC_HIGH) ? DAC_HIGH:dacval;
	        dacval = (dacval<DAC_LOW) ? DAC_LOW:dacval;

            errval = BTI708.BTI708_ParamAmplitudeConfig(BTI708.PARAMCFG708_DEFAULT, dacval, xmtchan, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the amplitude on channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
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
            *  Change parametric values when arrow keys are pressed. Exit when ESC is pressed.
            *
            **/

	        Console.Write("\n\tOPTIONS:");
	        Console.Write("\n\tARROW UP    = Add 16 to dacval");
	        Console.Write("\n\tARROW DOWN  = Subtract 16 from dacval");
	        Console.Write("\n\tESC         = Exit program");
	        Console.Write("\n\n");

            done = false;
	        while (!done)
	        {
		        Console.Write("\r\tDacval: {0:X3}  ",dacval);

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

					        BTI708.BTI708_ChStop(xmtchan,hCore);

                            errval = BTI708.BTI708_ParamAmplitudeConfig(BTI708.PARAMCFG708_DEFAULT, dacval, xmtchan, hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        the amplitude on channel #{0} on core #{1}.",xmtchan,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
                                done = true;
					        }

					        BTI708.BTI708_ChStart(xmtchan,hCore);

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
