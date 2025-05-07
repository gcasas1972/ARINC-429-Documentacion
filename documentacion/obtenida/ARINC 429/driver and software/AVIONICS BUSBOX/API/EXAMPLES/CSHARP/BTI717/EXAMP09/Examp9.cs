using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 9  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9 -- Transmitter with SuperFrame data example
*
**/

/**
*
*  NOTE: This example was previously released as EXAMP2
*
*  This program opens Card Number 0, and configures the 
*  first BiPhase channel as a receiver.  The second 
*  BiPhase channel is configured as a transmitter.  Both
*  channels operate on the self-test bus to electrically connect
*  them. The transmit channel is loaded with incrementing data, 
*  and SubFrame 2, Word 10, is defined as SuperFrame data.  
*  The SuperFrame data is loaded with incrementing data as well.
*  For this example, the receive channel does not define any
*  words as SuperFrame data.  The program will display the
*  what is received in SubFrame 2, Word 10.
*
**/

namespace EXAMP9
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp9
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
            Int32 rcvchan = 0;
	        Int32 xmtchan = 0;
	        Int32 wps = 256;
            UInt32 superfrmaddr;
	        UInt16[] sfblock = new UInt16[8200];
            UInt16 data = 0;
	        Int32 j,jj;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP9    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI717 Example 9                                                  *");
	        Console.Write("\n    *  \"Program for Transmitter with SuperFrame data example.\"           *");
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
            *  Find the first ARINC 717 core with both BiPhase receive and transmit channels.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        // Search for receive
		        for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)
		        {
			        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASERCV, rcvchan, hCore))	break;
		        }

		        // Search for transmit
		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		        {
			        if ( xmtchan == rcvchan ) continue;

			        if (0 != BTI717.BTI717_ChIsType(BTI717.CHCFG717_BIPHASEXMT, xmtchan, hCore))	break;
		        }

		        if ( (rcvchan != MAX_CHANNELS) && (xmtchan != MAX_CHANNELS) ) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 717 BiPhase receive and transmit channel pair present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 717 core #{0}",corenum);
	        Console.Write("\nUsing BiPhase receive channel #{0}",rcvchan);
	        Console.Write("\nUsing BiPhase transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure receiver channel for auto speed detection.
            *  Use the internal wrap around.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASERCV | BTI717.CHCFG717_AUTOSPEED | BTI717.CHCFG717_SELFTEST,rcvchan,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring channel {1}.",errval,rcvchan);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure transmitter channel at specified words per second.
            *  Use the internal wrap around.
            *
            **/

	        if      (wps == 64)   errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_64WPS,  xmtchan,hCore);
	        else if (wps == 128)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_128WPS, xmtchan,hCore);
	        else if (wps == 256)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_256WPS, xmtchan,hCore);
	        else if (wps == 512)  errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_512WPS, xmtchan,hCore);
	        else if (wps == 1024) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_1024WPS,xmtchan,hCore);
	        else if (wps == 2048) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_2048WPS,xmtchan,hCore);
	        else if (wps == 4096) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_4096WPS,xmtchan,hCore);
	        else if (wps == 8192) errval = BTI717.BTI717_ChConfig(BTI717.CHCFG717_BIPHASEXMT | BTI717.CHCFG717_SELFTEST | BTI717.CHCFG717_8192WPS,xmtchan,hCore);

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
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Display SF2, W10 on screen.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");
	        Console.Write("\nSynchronizing to bit stream....");

	        while (0 == BTI717.BTI717_SyncTest(rcvchan,hCore) && 0 == Win32Interop._kbhit());

	        if (0 != BTI717.BTI717_SyncTest(rcvchan,hCore))
	        {
		        Console.Write("In Sync!\n\n");
		        while(0 == Win32Interop._kbhit())
		        {
			        BTI717.BTI717_SubFrmWordRd(ref data,2,10,rcvchan,hCore);

			        Console.Write("\rChannel {0} (@{1} wps) - SuperFrame Data: {2:X4} (Hex)",
				        xmtchan,
				        wps,
				        data);
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
