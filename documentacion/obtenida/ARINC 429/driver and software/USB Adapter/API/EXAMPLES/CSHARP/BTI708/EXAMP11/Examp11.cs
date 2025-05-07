using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 11  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP11 -- Variable Bit Length example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first transmit channel on the first 708 Core to transmit
*  a sequence of 32 messages at a rate of 200Hz. The messages
*  are automatically assigned the numbers 0 through 31.
*
*  The transmitted and received bit lengths are displayed on
*  the console.
*
*  The user can then control the bit length using the LEFT and
*  RIGHT arrow keys.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

namespace EXAMP11
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Examp11
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32	FRAMEFREQ = 200;            /*Frame frequency of 200Hz*/
        private const Int32 LOGFREQ = 16;               /*Generate a Log Event after every 16th message*/
        private const Int32 FRAMECOUNT = 32;            /*Transmit a total of 32 messages*/

        private const UInt16 BIT_HIGH = 1856;
        private const UInt16 BIT_LOW = 1;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 xmtchan = 0;
	        Int32 rcvchan = 0;
            bool xmtfound = false;
            bool rcvfound = false;
	        UInt32 cfgflag;
	        Int32 j,jj;
	        UInt16[] Data = new UInt16[116];
	        UInt16 bitlength = 1600;
	        bool done;
	        char ch;

	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD708 pRec708 = new BTICARD.SEQRECORD708();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

            /**
            *
            *  Create a display window.
            *
            **/

	        Console.Clear();	/* Clear the console window. */

	        Console.SetCursorPosition(0, 0);

	        Console.Write("\n\t**********************************************************************");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  EXAMP11  (06/07/2011)                                             *");
	        Console.Write("\n\t*  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n\t*  All rights reserved.                                              *");
	        Console.Write("\n\t*  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  BTI708 Example 11                                                 *");
	        Console.Write("\n\t*  \"Program for variable bit length example.\"                        *");
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
            *  Find the first ARINC 708 core with a receive and transmit channel that supports variable bit length.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        rcvfound = false;
		        xmtfound = false;

		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);	/* Open a handle to the core. */
		        if (0 != errval) break;

		        for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
		        {
			        rcvfound = 0 != BTI708.BTI708_ChIsRcv(rcvchan,hCore);
			        if (rcvfound) break;
		        }

		        if (rcvfound)
		        {
			        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			        {
                        xmtfound = (0 != BTI708.BTI708_ChIsXmt(xmtchan, hCore) && 0 != BTI708.BTI708_ChGetInfo((UInt16)BTI708.INFO708_VARBIT, xmtchan, hCore));
				        if (xmtfound) break;
			        }
		        }

		        if (rcvfound && xmtfound)	break;
	        }

	        if (0 != errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	        {
		        Console.Write("\nError:  No compatible ARINC 708 core present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\n\tUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\n\tUsing receive channel #{0}",rcvchan);
	        Console.Write("\n\tUsing variable bit length transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure receive channel.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

            cfgflag = BTI708.CHCFG708_DEFAULT | BTI708.CHCFG708_SEQALL | BTI708.CHCFG708_SELFTEST | BTI708.CHCFG708_VARBIT;

	        errval = BTI708.BTI708_ChConfig(cfgflag,rcvchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",rcvchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Build the receive channel messages.
            *
            **/

	        errval = BTI708.BTI708_RcvBuild(BTI708.MSGCRT708_DEFAULT,0,1,rcvchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while building",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",rcvchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure xmtchan for variable bit length and self test
            *
            **/

            cfgflag = BTI708.CHCFG708_DEFAULT /*| BTI708.CHCFG708_SELFTEST*/ | BTI708.CHCFG708_VARBIT;

	        errval = BTI708.BTI708_ChConfig(cfgflag,xmtchan,hCore);

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

	        /* Initialize the data array */
	        for (jj=0;jj<116;jj++) Data[jj] = (UInt16)(jj);

	        bitlength = (bitlength>BIT_HIGH) ? BIT_HIGH : bitlength;
	        bitlength = (bitlength<BIT_LOW)  ? BIT_LOW  : bitlength;

	        for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
	        {
		        /* Write the variable length data to the device */
		        errval = BTI708.BTI708_MsgVarDataWr(ref Data[0],bitlength,j,xmtchan,hCore);
		        if (0 != errval)
		        {
			        Console.Write("\nError:  An error was encountered ({0}) while writing variable",errval);
			        Console.Write("\n        bit length data on channel #{0} on core #{1}.",xmtchan,corenum);
			        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
			        Console.Write("\n");
			        BTICARD.BTICard_CardClose(hCard);
			        Environment.Exit(1);
		        }
	        }

            /**
            *
            *  Configure the Sequential Monitor.
            *
            **/

	        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the sequential monitor on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
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
            *  Move to display window.
            *
            **/

	        Console.SetCursorPosition(0, 16);

            /**
            *
            *  Change bitlength values when arrow keys are pressed. Exit when ESC is pressed.
            *
            **/

	        Console.Write("\n\tOPTIONS:");
	        Console.Write("\n\tARROW RIGHT = Add 1 to Transmit bit length");
	        Console.Write("\n\tARROW LEFT  = Subtract 1 from Transmit bit length");
	        Console.Write("\n\tESC         = Exit program");
	        Console.Write("\n\n");

            done = false;
	        while(!done)
	        {
                seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

                BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                while (0 == BTICARD.BTICard_SeqFindNext708Ex(ref pRec708, (UInt16)Marshal.SizeOf(pRec708), ref sfinfo))
                {
			        Console.Write("\tTime Stamp: {0:X8}\n",pRec708.timestamp);
			        Console.Write("\tActivity:   {0:X4}\n", pRec708.activity);

                    Console.Write("\n\t(Tx) Bit Length: {0:d4}", bitlength);
                    Console.Write("\n\t(Rx) Bit Length: {0:d4}", pRec708.bitcount);

			        Console.SetCursorPosition(0, 22);
		        }

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
				        case 75:	/* LEFT  */
				        case 77:	/* RIGHT */
				        {
					        if (ch==77)	bitlength = ((UInt16)(bitlength+1)>BIT_HIGH) ? BIT_HIGH : (UInt16)(bitlength+1);
                            else bitlength = ((UInt16)(bitlength - 1) < BIT_LOW) ? BIT_LOW : (UInt16)(bitlength - 1);

					        for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
					        {
						        /* Write the variable length data to the device */
						        errval = BTI708.BTI708_MsgVarDataWr(ref Data[0],bitlength,j,xmtchan,hCore);
						        if (0 != errval)
						        {
							        Console.Write("\nError:  An error was encountered ({0}) while writing variable",errval);
							        Console.Write("\n        bit length data on channel #{0} on core #{1}.",xmtchan,corenum);
							        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
							        Console.Write("\n");
							        BTICARD.BTICard_CardClose(hCard);
							        Environment.Exit(1);
						        }
					        }

					        break;
				        }
			        }
		        }
	        }

            /**
            *
            *  Move to bottom of screen.
            *
            **/

	        Console.SetCursorPosition(0, 32);

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
