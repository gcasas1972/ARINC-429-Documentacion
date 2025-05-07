using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI717 DRIVER EXAMPLE 4  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4 -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0, and configures the 
*  first BiPhase channel as a transmitter.  The channel
*  is loaded with initial data.  An Event Log List is
*  configured and the last word in each SF is tagged to
*  generate an Event Log List entry.  The program polls
*  for these events and updates the data in the SF that
*  caused the event.
*
**/

namespace EXAMP4
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp4
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
	        Int32 j,jj;

	        UInt16 Type = 0;
	        UInt32 Info = 0;
            Int32 Chan = 0;
	        UInt16 sfnum = 0;
            Int32 count = 0;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP4    (06/07/2011)                                            *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI717 Example 4                                                  *");
	        Console.Write("\n    *  \"Polling the Event Log List example.\"                             *");
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
            *  Find the first ARINC 717 core with a BiPhase receive channel.
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
            *  Use the internal wrap around.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

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
	        count++;

            /**
            *
            *  Configure the Event Log list.
            *
            **/

	        errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE,1024,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring the event log list.",errval);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCore));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure word options.
            *
            **/

	        //Mark last word of SFs 1, 2, 3, and 4 for Event Logging

	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SFLOG,1,wps,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SFLOG,2,wps,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SFLOG,3,wps,xmtchan,hCore);
	        BTI717.BTI717_SubFrmWordConfig(BTI717.WRDCFG717_SFLOG,4,wps,xmtchan,hCore);

            /**
            *
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit.");
	        Console.Write("\n");
        	
	        while (0 == Win32Interop._kbhit())
	        {
		        if (0 != BTICARD.BTICard_EventLogRd(ref Type,ref Info,ref Chan,hCore))	//Read entry from Event Log list
		        {
			        sfnum = (UInt16)Info;						//Info is subframe number

			        BTI717.BTI717_SubFrmBlkRd(ref sfblock[0],sfnum,xmtchan,hCore);
			        for (jj=2;jj<=wps;jj++) 
			        {
				        sfblock[jj+7] &= 0xF000;				//Keep option bits, clear data
				        sfblock[jj+7] |= (UInt16)(((count * wps)+jj) & 0x0FFF);	//Set new data
			        }
			        BTI717.BTI717_SubFrmBlkWr(ref sfblock[0],sfnum,xmtchan,hCore);

			        Console.Write("\nUpdated data for SF{0:d1}.",sfnum);

			        if (sfnum == 4) count++;
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
