using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 11  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP11 -- Parametrics example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first transmit channel on the first 429 Core to build
*  a transmit schedule using transmit interval information.
*  The user can then control the amplitude using the UP and
*  DOWN arrow keys and the frequency using the LEFT and RIGHT
*  arrow keys.
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

        private const UInt16 DAC_HIGH = 0x0FFF;
        private const UInt16 DAC_LOW = 0x0599;
        private const UInt16 DIV_HIGH = 0x00FF;
        private const UInt16 DIV_LOW = 0x0000;

        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 xmtchan = 0;
	        BTI429.MSGSTRUCT429 comp_airspeed = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 tot_air_temp = new BTI429.MSGSTRUCT429();
            BTI429.MSGSTRUCT429 altitude_rate = new BTI429.MSGSTRUCT429();
	        UInt32[] msgaddr = new UInt32[3];
	        Int32[] min_intrvls = new Int32[3];
	        Int32[] max_intrvls = new Int32[3];
            UInt32[] bnr_data = new UInt32[3];
	        bool done;
	        UInt16 dacval = 0x0FF0;		// Amplitude
            UInt16 divval = 0x0027;		// Frequency
	        char ch;

	        Console.Write("\n\t**********************************************************************");
	        Console.Write("\n\t*                                                                    *");
            Console.Write("\n\t*  EXAMP11  (06/07/2011)                                             *");
            Console.Write("\n\t*  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n\t*  All rights reserved.                                              *");
	        Console.Write("\n\t*  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n\t*                                                                    *");
	        Console.Write("\n\t*  BTI429 Example 11                                                 *");
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

	        Console.Write("\nUsing ARINC 429 card #{0}",CARDNUM);

            /**
            *
            *  Find the first ARINC 429 core with a transmit channel that supports parametrics.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		        {
			        if (0 != BTI429.BTI429_ChIsXmt(xmtchan,hCore) && 0 != BTI429.BTI429_ChGetInfo((UInt16)BTI429.INFO429_PARAM,xmtchan,hCore))	break;
		        }

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 429 parametric transmit channels");
		        Console.Write("\n        present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\n\tUsing ARINC 429 core #{0}",corenum);
	        Console.Write("\n\tUsing parametric transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure xmtchan to transmit at high speed.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_HIGHSPEED,xmtchan,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{0}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Configure Parametrics on xmtchan
            *
            **/

	        dacval = (dacval>DAC_HIGH) ? DAC_HIGH:dacval;
	        dacval = (dacval<DAC_LOW) ? DAC_LOW:dacval;

	        errval = BTI429.BTI429_ParamAmplitudeConfig(BTI429.PARAMCFG429_DEFAULT,dacval,xmtchan,hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the amplitude on channel #{0} on core #{0}.",xmtchan,corenum);
		        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        divval = (divval>DIV_HIGH) ? DIV_HIGH:divval;
	        divval = (divval<DIV_LOW)  ? DIV_LOW:divval;

            errval = BTI429.BTI429_ParamBitRateConfig(BTI429.PARAMCFG429_DEFAULT, divval, xmtchan, hCore);
	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the bit rate on channel #{0} on core #{0}.",xmtchan,corenum);
		        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Create a message for each of the labels we are transmitting.
            *
            **/

	        comp_airspeed.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
	        tot_air_temp.addr  = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);
	        altitude_rate.addr = BTI429.BTI429_MsgCreate(BTI429.MSGCRT429_DEFAULT,hCore);

            /**
            *
            *  Setup the arrays of message addresses, and intervals
            *  needed to build the schedule.  Note that the nth element
            *  in each array correspond to each other.
            *
            **/

	        msgaddr[0] = comp_airspeed.addr;
	        min_intrvls[0] = 250;
	        max_intrvls[0] = 500;

	        msgaddr[1] = tot_air_temp.addr;
	        min_intrvls[1] = 250;
	        max_intrvls[1] = 500;

	        msgaddr[2] = altitude_rate.addr;
	        min_intrvls[2] = 100;
	        max_intrvls[2] = 200;

            /**
            *
            *  Next, build a schedule using the minimum and maximum
            *  transmit intervals.
            *
            **/

	        BTI429.BTI429_SchedBuild(3,ref msgaddr[0],ref min_intrvls[0],ref max_intrvls[0],xmtchan,hCore);

            /**
            *
            *  Initialize the three Message Records.
            *
            **/

	        comp_airspeed.data = BTI429.BTI429_FldPutLabel(0,0x86);     /*Init label field*/
	        tot_air_temp.data  = BTI429.BTI429_FldPutLabel(0,0x89);
	        altitude_rate.data = BTI429.BTI429_FldPutLabel(0,0x8A);

	        comp_airspeed.data = BTI429.BTI429_BNRPutMant(comp_airspeed.data,0,14,0);     /*Init BNR data*/
	        tot_air_temp.data  = BTI429.BTI429_BNRPutMant(tot_air_temp.data,0,11,0);
	        altitude_rate.data = BTI429.BTI429_BNRPutMant(altitude_rate.data,0,16,0);

	        BTI429.BTI429_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
	        BTI429.BTI429_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
	        BTI429.BTI429_MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

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
	        Console.Write("\n\tARROW RIGHT = Increment divval");
	        Console.Write("\n\tARROW LEFT  = Decrement divval");
	        Console.Write("\n\tESC         = Exit program");
	        Console.Write("\n\n");

            done = false;

	        while (!done)
	        {
		        Console.Write("\r\tDacval: {0:X3} (Hex)   Divval: {1:X3} (Hex)",dacval,divval);

		        if (0 != Win32Interop._kbhit())
		        {
			        ch = Win32Interop._getch();

			        if (ch==0xE0)	ch = Win32Interop._getch();	/* When reading arrow key _Win32Interop.getch() must be called twice. */

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

					        BTI429.BTI429_ChStop(xmtchan,hCore);

					        errval = BTI429.BTI429_ParamAmplitudeConfig(BTI429.PARAMCFG429_DEFAULT,dacval,xmtchan,hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        Amplitude on channel #{0} on core #{1}.",xmtchan,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
                                done = true;
					        }

					        BTI429.BTI429_ChStart(xmtchan,hCore);

					        break;
				        }
				        case 75:	/* LEFT  */
				        case 77:	/* RIGHT */
				        {
					        if (ch==77)	divval = ((UInt16)(divval+1)>DIV_HIGH) ? DIV_HIGH : (UInt16)(divval+1);
					        else		divval = ((UInt16)(divval-1)<DIV_LOW)  ? DIV_LOW  : (UInt16)(divval-1);

					        BTI429.BTI429_ChStop(xmtchan,hCore);

					        errval = BTI429.BTI429_ParamBitRateConfig(BTI429.PARAMCFG429_DEFAULT,divval,xmtchan,hCore);
					        if (errval < 0)
					        {
						        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
						        Console.Write("\n        the bit rate on channel #{0} on core #{0}.",xmtchan,corenum);
						        Console.Write("\n        ({0})\n\n",BTICARD.BTICard_ErrDescStr(errval,hCard));
                                done = true;
					        }

					        BTI429.BTI429_ChStart(xmtchan,hCore);

					        break;
				        }
			        }
		        }

		        comp_airspeed.data = BTI429.BTI429_MsgDataRd(comp_airspeed.addr,hCore);   /*Read messages back*/
		        tot_air_temp.data  = BTI429.BTI429_MsgDataRd(tot_air_temp.addr,hCore);
		        altitude_rate.data = BTI429.BTI429_MsgDataRd(altitude_rate.addr,hCore);

		        bnr_data[0] = BTI429.BTI429_BNRGetMant(comp_airspeed.data,14);   /*Extract BNR data*/
		        bnr_data[1] = BTI429.BTI429_BNRGetMant(tot_air_temp.data,11);
		        bnr_data[2] = BTI429.BTI429_BNRGetMant(altitude_rate.data,16);

		        ++bnr_data[0];   /*Change BNR data*/
		        ++bnr_data[1];
		        ++bnr_data[2];

		        comp_airspeed.data = BTI429.BTI429_BNRPutMant(comp_airspeed.data,bnr_data[0],14,0);   /*Put BNR data*/
		        tot_air_temp.data  = BTI429.BTI429_BNRPutMant(tot_air_temp.data,bnr_data[1],11,0);    /*back into*/
		        altitude_rate.data = BTI429.BTI429_BNRPutMant(altitude_rate.data,bnr_data[2],16,0);   /*messages*/

		        BTI429.BTI429_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);   /*Write new message values*/
		        BTI429.BTI429_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
		        BTI429.BTI429_MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);
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
