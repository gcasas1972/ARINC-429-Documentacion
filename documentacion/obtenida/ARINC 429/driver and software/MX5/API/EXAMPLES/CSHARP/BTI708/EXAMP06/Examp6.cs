using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 6  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6 -- Header extraction example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first receive
*  channel to receive messages in a single message record.
*  This message is automatically assigned to message number
*  0.
*
*  An Event Log frequency of 0 is specified, which will
*  not generate any Event Log List entries for this channel.
*
*  The program will display the ARINC 708 header information
*  from the message record, until a key is pressed.
*
**/

namespace EXAMP6
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp6
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
	        UInt16[] Data = new UInt16[100];

            /**
            *
            *  Create a display window.
            *
            **/

	        Console.Clear();	/* Clear the console window. */

            Console.SetCursorPosition(0, 0);

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP6   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 6                                                  *");
	        Console.Write("\n    *  \"Header extraction example.\"                                      *");
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

            /**
            *
            *  Find the first ARINC 708 core with a receive channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (0 != BTI708.BTI708_ChIsRcv(rcvchan,hCore)) break;

		        if (rcvchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 708 receive channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\nUsing receive channel #{0}",rcvchan);
	        Console.Write("\n");

            /**
            *
            *  Configure receive channel.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_DEFAULT,rcvchan,hCore);

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
		        Console.Write("\n        channel #{0} on core #.",rcvchan,corenum);
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

            Console.SetCursorPosition(0, 15);

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit...");
	        Console.Write("\n");

	        while (0 == Win32Interop._kbhit())
	        {
		        BTI708.BTI708_MsgDataRd(ref Data[0],0,rcvchan,hCore);

                Console.Write("\nLabel:          {0:X2} (Hex)  {1:o} (Oct)", BTI708.BTI708_FieldGetLabel(ref Data[0]), BTI708.BTI708_FieldGetLabel(ref Data[0]));
                Console.Write("\nControl Accept: {0:X4} (Hex)", BTI708.BTI708_FieldGetControlAccept(ref Data[0]));
		        Console.Write("\nBits 16-11:     {0:X2} (Hex)",(Data[0] >> 10) & 0x003F);
		        Console.Write("\nBits 26-17:     {0:X3} (Hex)",Data[1] & 0x03FF);
                Console.Write("\nMode:           {0:X4} (Hex)", BTI708.BTI708_FieldGetMode(ref Data[0]));
                Console.Write("\nTilt:           {0:X4} (Hex)  {1:f} (Dec)", BTI708.BTI708_FieldGetTilt(ref Data[0]), BTI708.BTI708_FieldGetTiltFl(ref Data[0]));
                Console.Write("\nGain:           {0} (Dec)", BTI708.BTI708_FieldGetGain(ref Data[0]));
                Console.Write("\nRange:          {0} (Dec)", BTI708.BTI708_FieldGetRange(ref Data[0]));
		        Console.Write("\nBit 49:         {0:X1} (Hex)",Data[4] & 0x0001);
                Console.Write("\nData Accept:    {0:X1} (Hex)", BTI708.BTI708_FieldGetDataAccept(ref Data[0]));
                Console.Write("\nScan Angle:     {0:X3} (Hex)  {1:f} (Dec)", BTI708.BTI708_FieldGetAngle(ref Data[0]), BTI708.BTI708_FieldGetAngleFl(ref Data[0]));
		        Console.Write("\nBit 64:         {0:X1} (Hex)",(Data[4] >> 15) & 0x0001);

                Console.SetCursorPosition(0, 18);
	        }

            /**
            *
            *  Move to bottom of screen.
            *
            **/

            Console.SetCursorPosition(0, 31);

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
