using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 3  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3 -- Sequential Monitor example
*
**/

/**
*
*  This program opens Card Number 0, and configures the 
*  first BiPhase channel as a receiver.  The second 
*  BiPhase channel is configured as a transmitter.  Both
*  channels operate on the self-test bus to electrically connect
*  them. The transmit channel is loaded with incrementing data, 
*  and various words are configured for entry into the 
*  Sequential Monitor.  The program will read out of the 
*  Sequential Record and display the data to the screen.
*
**/

namespace EXAMP3
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp3
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
	        Int32 j,jj;

	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD717 pRec717 = new BTICARD.SEQRECORD717();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP3    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI717 Example 3                                                  *");
	        Console.Write("\n    *  \"Program for Sequential Monitor example.\"                         *");
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
                
                for (jj = 2; jj <= wps; jj++)
                {
                    sfblock[jj + 7] &= 0xF000;      //Keep option bits, clear data
                    sfblock[jj + 7] |= (UInt16)(((0x0100 * j) + jj) & 0x0FFF);
                }
                
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

	        superfrmaddr = BTI717.BTI717_SuperFrmDefine(2,10,xmtchan,hCore);
	        for (j=1;j<=16;j++) BTI717.BTI717_SuperFrmWordWr((UInt16)(0x0500+j),j,superfrmaddr,xmtchan,hCore);

            /**
            *
            *  Set superframe counter position.
            *
            **/

	        BTI717.BTI717_SuperFrmCounterPos(1,wps,rcvchan,hCore);
	        BTI717.BTI717_SuperFrmCounterPos(1,wps,xmtchan,hCore);

            /**
            *
            *  Configure the Sequential Monitor.
            *
            **/

	        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring the Sequential Monitor.",errval);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure word options.
            *
            **/

	        //Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor

	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,1,1,rcvchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,2,1,rcvchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,3,1,rcvchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,4,1,rcvchan,hCore);

	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,1,1,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,2,1,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,3,1,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SEQ,4,1,xmtchan,hCore);

	        //Mark the word at SPF 4 of our superframe word (word 10, SF 2) 
	        //for the Sequential Monitor

	        BTI717.BTI717_SuperFrmWordConfig(BTI717.WRDCFG717_SEQ,4,superfrmaddr,xmtchan,hCore);

            /**
            *
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Read the Sequential Record and display to screen.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

	        while(0 == Win32Interop._kbhit())
	        {
                seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

                BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                while (0 == BTICARD.BTICard_SeqFindNext717Ex(ref pRec717, (UInt16)Marshal.SizeOf(pRec717), ref sfinfo))
		        {
			        Console.Write("\nCh:{0} Word:{1} SF:{2} SPF:{3} Value:{4} (Octal) TimeStamp:",
				        ((int)(pRec717.activity & BTI717.MSGACT717_CHMASK) >> (int)(BTI717.MSGACT717_CHSHIFT)),
				        pRec717.wordnum,
				        pRec717.subframe,
				        (pRec717.superframe % 16) + 1,
				        Convert.ToString(pRec717.data, 8));

			        // Display timestamph value if supported
                    if (0 != BTICARD.BTICard_SeqFindCheckVersion(ref pRec717.typeval, (UInt16)BTICARD.SEQVER_1))
			        {
				        Console.Write("{0:X8} ",pRec717.timestamph);
			        }

			        // Always display timestamp value
			        Console.Write("{0:X8}",pRec717.timestamp);
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
