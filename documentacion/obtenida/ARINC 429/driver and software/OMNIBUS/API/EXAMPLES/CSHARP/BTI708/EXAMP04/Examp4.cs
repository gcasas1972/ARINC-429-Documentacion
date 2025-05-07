using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 4  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4 -- Record to file example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first receive
*  channel to record it's data to the Sequential Monitor.
*  The program then writes the data to a file (EXAMP4.DAT).
*
*  An Event Log frequency of 0 is specified, which will
*  not generate any Event Log List entries for these channels.
*
*  The program will continue to record data to the file
*  until a key is pressed.
*
*  Note: Running this program for a long time could cause the file
*  being written to become very large.  Please be cautious while
*  running this example.
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

        /**
        *
        *  This helper function checks for the help option on the
        *  command line.
        *
        **/

        static bool isarghelp(string[] args)
        {
	        for (int j=0;j<args.Length;++j)
	        {
                if (args[j].Contains("?"))
		        {
			        return(true);
		        }
	        }
	        return(false);
        }

        /**
        *
        *  This helper function checks for options on the
        *  command line.
        *
        **/

        static string isargopt(string[] args, string opts)
        {
            string strReturn = null;

	        for (int j=0;j<args.Length;++j)
	        {
                if ((args[j].StartsWith("-") || args[j].StartsWith("/")) && args[j].Substring(1).ToLower().StartsWith(opts.ToLower()))
                {
			        return(args[j].Substring(opts.Length + 1));
		        }
	        }
            return (strReturn);
        }


        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 rcvchan = 0;
            Int32 cursor = 0;
            Int32 j;
            System.IO.FileStream BinaryFile;
            System.IO.BinaryWriter BinaryWriter;
	        string opts;
            string filename = "EXAMP4.DAT";

	        UInt16[] seqbuf = new UInt16[2048];
	        UInt32 seqcount = 0;
	        UInt32 blkcnt = 0;
	        BTICARD.SEQRECORD708 pRec708 = new BTICARD.SEQRECORD708();
	        BTICARD.SEQFINDINFO sfinfo = new BTICARD.SEQFINDINFO();

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP4   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 4                                                  *");
	        Console.Write("\n    *  \"Record to file example.\"                                         *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n");

            /**
            *
            *  Check if we should display the help information.
            *
            **/

	        if (isarghelp(args))
	        {
		        Console.Write("\nUsage:  EXAMP4 [options]");
		        Console.Write("\n");

		        Console.Write("\n-?                    Display help information");
		        Console.Write("\n-FILENAME:<filename>  File to write data to.  Default EXAMP4.DAT.");
		        Console.Write("\n");
		        Environment.Exit(0);
	        }

	        Console.Write("\nFor help:  EXAMP4 ?");
	        Console.Write("\n");

            /**
            *
            *  Check for the -FILENAME:<filename> option.
            *
            **/

	        if ((opts = isargopt(args,"FILENAME")) != null)
	        {
		        opts = opts.ToUpper();

		        if (!opts.StartsWith(":"))
		        {
			        Console.Write(	"\nError:  Semicolon is missing after option." +
							        "\n        Use the form -FILENAME:<filename>.");
			        Console.Write( "\n");
			        Environment.Exit(1);
		        }

		        if (1 > opts.Length)
		        {
			        Console.Write( "\nError:  Filename is missing after option." +
							        "\n        Use the form -FILENAME:<filename>.");
			        Console.Write( "\n");
			        Environment.Exit(1);
		        }

		        filename = opts.Substring(1);

		        Console.Write("\nUsing the filename {0}.",filename);
	        }

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

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_SEQALL,rcvchan,hCore);

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
            *  Configure the Sequential Monitor.
            *
            **/

	        errval = BTICARD.BTICard_SeqConfig(BTICARD.SEQCFG_DEFAULT,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the sequential monitor on core #.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Open the data file for writing.
            *
            **/

            BinaryFile = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            BinaryWriter = new System.IO.BinaryWriter(BinaryFile);
	        
	        if (BinaryWriter == null)
	        {
		        Console.Write("\nError:  Unable to open the data file {0}.",filename);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            BinaryFile.Seek(0, System.IO.SeekOrigin.Begin);

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

	        Console.Write("\nPress any key to exit...");
	        Console.Write("\n");
	        Console.Write("\nWriting...  ");

	        while (0 == Win32Interop._kbhit())
	        {
		        seqcount = BTICARD.BTICard_SeqBlkRd(ref seqbuf[0], (UInt32)seqbuf.Length, ref blkcnt, hCore);

                BTICARD.BTICard_SeqFindInit(ref seqbuf[0], (UInt32)seqcount, ref sfinfo);

                while (0 == BTICARD.BTICard_SeqFindNext708Ex(ref pRec708, (UInt16)Marshal.SizeOf(pRec708), ref sfinfo))
		        {
			        if      (cursor==1) Console.Write("\b|");
			        else if (cursor==2) Console.Write("\b/");
			        else if (cursor==3) Console.Write("\b-");
			        else
			        {
				        Console.Write("\b\\");
				        cursor = 0;
			        }
			        cursor++;

                    for (j = 0; j < pRec708.data.Length; j++)
                    {
                        BinaryWriter.Write(pRec708.data[j]);
                    }
		        }
	        }

	        Console.Write("\bDone.\n\n");

            /**
            *
            *  Close the data file.
            *
            **/

            BinaryFile.Close();

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
