using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 2  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2 -- Transmitter example
*
**/

/**
*
*  This program opens Card Number 0, and configures the 
*  first BiPhase channel as a transmitter.  The transmit 
*  channel is loaded with incrementing data.
*
**/

namespace EXAMP2
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp2
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;

            Int32 xmtchan = 0;
	        Int32 wps = 256;
	        UInt16[] sfblock = new UInt16[8200];
	        UInt16[] chstatus = new UInt16[8];
            Int32 j, jj;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP2    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI717 Example 2                                                  *");
	        Console.Write("\n    *  \"Program for Transmitter example.\"                                *");
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

	        Console.Write("\nUsing ARINC 717 card #{0}",CARDNUM);

            /**
            *
            *  Find the first ARINC 717 core with a BiPhase transmit channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		        {
			        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASEXMT, xmtchan, hCore))	break;
		        }

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 717 BiPhase transmit channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 717 core #{0}",corenum);
	        Console.Write("\nUsing BiPhase transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure transmitter channel at specified words per second.
            *
            **/

	        if      (wps == 64)   errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_64WPS,                          xmtchan,hCore);
	        else if (wps == 128)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_128WPS,                         xmtchan,hCore);
	        else if (wps == 256)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_256WPS,                         xmtchan,hCore);
	        else if (wps == 512)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_512WPS,                         xmtchan,hCore);
	        else if (wps == 1024) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_1024WPS,                        xmtchan,hCore);
	        else if (wps == 2048) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_2048WPS | BTI717.CHCFG717_XMTSLOPEHIGH,xmtchan,hCore);
	        else if (wps == 4096) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_4096WPS | BTI717.CHCFG717_XMTSLOPEHIGH,xmtchan,hCore);
	        else if (wps == 8192) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_8192WPS | BTI717.CHCFG717_XMTSLOPEHIGH,xmtchan,hCore);

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
		        BTI717.BTI717_SubFrmBlkRd(ref sfblock[0],j,xmtchan,hCore);
		        for (jj=2;jj<=wps;jj++) sfblock[jj+7] = (UInt16)(((0x0100*j)+jj) & 0x0FFF);
                BTI717.BTI717_SubFrmBlkWr(ref sfblock[0], j, xmtchan, hCore);
	        }

            /**
            *
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Wait for key press to exit.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");
	        Console.Write("\nTransmitting data....\n");

	        while(0 == Win32Interop._kbhit())
	        {
		        // Add code here to change data, show status, etc.

		        BTI717.BTI717_ChStatus(ref chstatus[0],xmtchan,hCore);
		        Console.Write("\rSubframe:{0} Word:{1:d4}",chstatus[2],chstatus[1]);
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
