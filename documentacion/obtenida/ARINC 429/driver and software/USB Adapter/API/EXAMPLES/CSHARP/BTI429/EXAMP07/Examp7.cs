using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 7  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7 -- File transfer example
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and configures an asynchronous transmit
*  list buffer.  The program reads a data file and transmits
*  that data with a user-specified label.  If no data file
*  or label is specified by the user, the default values are
*  examp7.dat, and label 0172.
*
**/

namespace EXAMP7
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp7
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
            Int32 xmtchan = 0;

            System.IO.FileStream BinaryFile;
            System.IO.BinaryReader BinaryReader;
	        string opts;
            UInt32 label = 0172;
            string filename = "EXAMP7.DAT";

	        UInt32 asynclistaddr;
	        UInt32 Data;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP7    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI429 Example 7                                                  *");
	        Console.Write("\n    *  \"Program for file transfer.\"                                      *");
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
		        Console.Write("\nUsage:  EXAMP7 [options]");
		        Console.Write("\n");

		        Console.Write("\n-?                    Display help information");
		        Console.Write("\n-LABEL:ooo            Set the label (octal).  Default 0172.");
		        Console.Write("\n-FILENAME:<filename>  File to read data from. Default EXAMP7.DAT.");
		        Console.Write("\n");
                Environment.Exit(0);
	        }

	        Console.Write("\nFor help:  EXAMP7 ?");
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
            *  Check for the -LABEL:dd option.
            *
            **/

	        if ((opts = isargopt(args,"LABEL")) != null)
	        {
		        opts = opts.ToUpper();

                if (!opts.StartsWith(":"))
		        {
			        Console.Write(	"\nError:  Semicolon is missing after option." +
							        "\n        Use the form -LABEL:<label#>.");
			        Console.Write( "\n");
			        Environment.Exit(1);
		        }

                if (1 > opts.Length)
		        {
			        Console.Write(	"\nError:  The label number is missing after the option." +
							        "\n        Use the form -LABEL:<label#>.");
			        Console.Write( "\n");
			        Environment.Exit(1);
		        }

                opts = opts.Substring(1);

                label = Convert.ToUInt32(opts, 8);

		        if (0 == label)
		        {
			        Console.Write(	"\nError:  The label number is not an octal number." +
							        "\n        Use the form -LABEL:ooo.");
			        Console.Write( "\n");
			        Environment.Exit(1);
		        }

                Console.Write("\nUsing label {0}o.", opts);
	        }

            /**
            *
            *  Find the first ARINC 429 core with a transmit channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (0 != BTI429.BTI429_ChIsXmt(xmtchan,hCore))	break;

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 429 transmit channels present in card #{0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 429 core #{0}",corenum);
	        Console.Write("\nUsing transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure xmtchan to transmit at low speed.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);                          /*Reset the card*/

	        errval = BTI429.BTI429_ChConfig(BTI429.CHCFG429_DEFAULT,xmtchan,hCore);

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
            *  Create the asynchronous list buffer.
            *
            **/

	        asynclistaddr = BTI429.BTI429_ListAsyncCreate(BTI429.LISTCRT429_FIFO,8192,xmtchan,hCore);

	        if (0 == asynclistaddr)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the list buffer on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Next, a schedule is built by creating explicit message timing.
            *  While creating a schedule we can still use the SchedGap() function
            *  to create our gap times.  This function will determine that an
            *  asynchronous list buffer has been created for the channel, and will
            *  internally call the SchedGapList() function with appropriate parameters.
            *  Alternatively, we could use the SchedGapList() function directly
            *  and specify the address value ourselves. This method is useful if
            *  more than one asynchronous list buffer is desired per channel.
            *
            **/

	        BTI429.BTI429_SchedGap(1024,xmtchan,hCore);						    //This line, and
	        //BTI429.BTI429_SchedGapList(1024,asynclistaddr,xmtchan,hCore);		//this line, do the same thing.

            /**
            *
            *  Start operation of the card.
            *
            **/

	        BTICARD.BTICard_CardStart(hCore);

            /**
            *
            *  Open the data file for reading.
            *
            **/

            BinaryFile = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            BinaryReader = new System.IO.BinaryReader(BinaryFile);

            if (BinaryReader == null)
            {
                Console.Write("\nError:  Unable to open the data file {0}.", filename);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            BinaryFile.Seek(0, System.IO.SeekOrigin.Begin);

            /**
            *
            *  Transmit data until EOF or until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit....\n\n");

            while (0==Win32Interop._kbhit())
            {
                //Read the next word from file
                try
                {
                    Data = BinaryReader.ReadUInt32();
                }
                catch (Exception ex)
                {
                    //The end of the stream is reached. 
                    break;
                }

                Data = (UInt32)(Data & 0xFFFFFF00) | (UInt32)(label & 0x000000FFL);
                while (0 == BTI429.BTI429_ListDataWr(Data, asynclistaddr, hCore));
            }

	        Console.Write("\nFinished loading data on to the card.");
	        Console.Write("\nCard may still be transmitting.");
	        Console.Write("\n");
	        Console.Write("\n");

            /**
            *
            *  Close the data file.
            *
            **/

            BinaryFile.Close();

            /**
            *
            *  The card MUST be closed before exiting the program.
            *
            **/

	        BTICARD.BTICard_CardClose(hCard);
        }
    }
}
