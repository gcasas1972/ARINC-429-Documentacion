using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 7  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7 -- Parametrics example
*
**/

/**
*
*  The user can then control the amplitude using the UP and
*  DOWN arrow keys and the frequency using the LEFT and RIGHT
*  arrow keys.
*
**/

namespace EXAMP7
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
        [DllImport("crtdll.dll")]
        public static extern char _getch();
    }

    class Examp7
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const UInt16 DAC_HIGH = 0x0FF0;
        private const UInt16 DAC_LOW = 0x0600;	

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;

            Int32 xmtchan = 0;

	        Int32 wps = 256;
            UInt32 superfrmaddr;
	        UInt16[] sfblock = new UInt16[8200];
            Int32 j, jj;

	        bool done;
            UInt16 dacval = 0x0FF0;		// Amplitude
	        char ch;

	        Console.Write("\n\t**********************************************************************");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  EXAMP7  (06/07/2011)                                              *");
	        Console.Write("\n\t*  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n\t*  All rights reserved.                                              *");
	        Console.Write("\n\t*  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  BTI717 Example 7                                                  *");
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

	        Console.Write("\nUsing ARINC 717 card #{0}",CARDNUM);

            /**
            *
            *  Find the first ARINC 717 core with a BiPhase transmit channel that supports parametrics.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		        {
			        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASEXMT, xmtchan, hCore))
			        {
                        if (0 != BTI717.BTI717_ChGetInfo((UInt16)BTI717.INFO717_PARAM, xmtchan, hCore)) break;
			        }
		        }

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 717 BiPhase parametric transmit channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 717 core #{0}",corenum);
	        Console.Write("\nUsing BiPhase parametric transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure transmitter channel at specified words per second.
            *  Use the internal wrap around.
            *
            **/

	        if      (wps == 64)   errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_64WPS,  xmtchan,hCore);
	        else if (wps == 128)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_128WPS, xmtchan,hCore);
	        else if (wps == 256)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_256WPS, xmtchan,hCore);
	        else if (wps == 512)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_512WPS, xmtchan,hCore);
	        else if (wps == 1024) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_1024WPS,xmtchan,hCore);
	        else if (wps == 2048) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_2048WPS,xmtchan,hCore);
	        else if (wps == 4096) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_4096WPS,xmtchan,hCore);
	        else if (wps == 8192) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_8192WPS,xmtchan,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring channel {1}.",errval,xmtchan);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Init subframe data.
            *
            **/

	        for (j=1;j<=4;j++)
	        {
                BTI717.BTI717_SubFrmBlkRd(ref sfblock[0], j, xmtchan, hCore);
                for (jj = 2; jj <= wps; jj++) sfblock[jj + 7] = (UInt16)(((0x0100 * j) + jj) & 0x0FFF);
                BTI717.BTI717_SubFrmBlkWr(ref sfblock[0], j, xmtchan, hCore);
	        }

            /**
            *
            *  Create some SuperFrame structures.
            *
            **/

	        BTI717.BTI717_SuperFrmConfig(10,16,xmtchan,hCore);

            /**
            *
            *  Define SF2, W10 to be SuperFrame Data.
            *  Init superframe data.
            *
            **/

            superfrmaddr = BTI717.BTI717_SuperFrmDefine(2, 10, xmtchan, hCore);
            for (j = 1; j <= 16; j++) BTI717.BTI717_SuperFrmWordWr((UInt16)(0x0500 + j), j, superfrmaddr, xmtchan, hCore);

            /**
            *
            *  Set superframe counter position.
            *
            **/

	        BTI717.BTI717_SuperFrmCounterPos(1,wps,xmtchan,hCore);

            /**
            *
            *  Configure Parametrics on xmtchan
            *
            **/

	        dacval = (dacval>DAC_HIGH) ? DAC_HIGH:dacval;
	        dacval = (dacval<DAC_LOW) ? DAC_LOW:dacval;

            errval = BTI717.BTI717_ParamAmplitudeConfig(BTI717.PARAMCFG717_DEFAULT, dacval, xmtchan, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the amplitude on channel #{0} on core #{0}.",xmtchan,corenum);
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
		        Console.Write("\r\tDacval: {0:X3} (Hex)",dacval);

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

					        BTI717.BTI717_ChStop(xmtchan,hCore);

                            errval = BTI717.BTI717_ParamAmplitudeConfig(BTI717.PARAMCFG717_DEFAULT, dacval, xmtchan, hCore);				
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        Amplitude on channel #{0} on core #{1}.",xmtchan,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
                                done = true;
					        }

					        BTI717.BTI717_ChStart(xmtchan,hCore);

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
