using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI708 DRIVER EXAMPLE 5  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5 -- Transmitter file playback example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first transmit
*  channel to transmit a sequence of 64 messages at a
*  rate of 200Hz.  The messages are automatically assigned
*  the numbers 0 through 63.
*
*  A data file is used to source the data to transmit
*  on the bus.
*
*  An Event Log frequency of 32 is specified, which will
*  cause the channel to issue an Event Log List entry
*  every 32nd message (message numbers 31, and 63).
*  The program uses these events to update he data for
*  the half of messages that were just transmitted.
*
*  Data from the data file are read until the end of the file
*  is reached.  Once reached, the program will seek to the
*  start of the file and transmit the file again.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

namespace EXAMP5
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp5
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
            for (int j = 0; j < args.Length; ++j)
            {
                if (args[j].Contains("?"))
                {
                    return (true);
                }
            }
            return (false);
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

            for (int j = 0; j < args.Length; ++j)
            {
                if ((args[j].StartsWith("-") || args[j].StartsWith("/")) && args[j].Substring(1).ToLower().StartsWith(opts.ToLower()))
                {
                    return (args[j].Substring(opts.Length + 1));
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
	        Int32 j, jj;
	        UInt16[] Data = new UInt16[100];
	        UInt16 Type = 0;
	        UInt32 Info = 0;
            Int32 Chan = 0;
	        UInt16 framenum;
            System.IO.FileStream BinaryFile;
            System.IO.BinaryReader BinaryReader;
	        string opts;
            string filename = "EXAMP5.DAT";

            UInt16 framefreq   = 200;           /*Frame frequency of 200Hz*/
            UInt16 blocksize   = 32;            /*Generate an Event Log List entry on every 32nd frame*/
            UInt16 framecount  = 64;            /*Transmit a total of 64 frames*/

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  EXAMP5   (06/07/2011)                                             *");
	        Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI708 Example 5                                                  *");
	        Console.Write("\n    *  \"Transmitter file playback example.\"                              *");
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
		        Console.Write("\nUsage:  EXAMP5 [options]");
		        Console.Write("\n");

		        Console.Write("\n-?                    Display help information");
		        Console.Write("\n-FREQ:dd              Set the frequency.  Default 200Hz.");
		        Console.Write("\n-BLOCKSIZE:dd         Set the block size.  Default 32 frames.");
		        Console.Write("\n-FILENAME:<filename>  File to read data from.  Default EXAMP5.DAT.");
		        Console.Write("\n-AUTO                 Loads two blocks of data from file, starts card,");
		        Console.Write("\n                      and exits the program, allowing the card to");
		        Console.Write("\n                      continuously transmit the data.");
		        Console.Write("\n");
		        Environment.Exit(0);
	        }

	        Console.Write("\nFor help:  EXAMP5 ?");
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
            *  Check for the -BLOCKSIZE:dd option.
            *
            **/

	        if ((opts = isargopt(args,"BLOCKSIZE")) != null)
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

                opts = opts.Substring(1);

                blocksize = Convert.ToUInt16(opts, 10);

		        if (0 == blocksize)
		        {
			        Console.Write("\nError:  The block size is not a decimal number." +
							        "\n        Use the form -BLOCKSIZE:dd.");
			        Console.Write("\n");
			        Environment.Exit(1);
		        }

		        framecount = (UInt16)(blocksize * 2);

		        Console.Write("\nUsing a block size of {0} frames and a total of {0} frames.",blocksize,framecount);
	        }

            /**
            *
            *  Check for the -FREQ:dd option.
            *
            **/

	        if ((opts = isargopt(args,"FREQ")) != null)
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

                opts = opts.Substring(1);

                framefreq = Convert.ToUInt16(opts, 10);

		        if (0 == framefreq)
		        {
			        Console.Write("\nError:  The frequency is not a decimal number." +
							        "\n        Use the form -FREQ:dd.");
			        Console.Write("\n");
			        Environment.Exit(1);
		        }

		        Console.Write("\nUsing a frequency of {0}Hz.",framefreq);
	        }

            /**
            *
            *  Find the first ARINC 708 core with a transmit channel.
            *
            **/

	        for (corenum=0;corenum<MAX_CORES;corenum++)
	        {
		        errval = BTICARD.BTICard_CoreOpen(ref hCore,corenum,hCard);
		        if (0 != errval) break;

		        for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (0 != BTI708.BTI708_ChIsXmt(xmtchan,hCore)) break;

		        if (xmtchan != MAX_CHANNELS) break;
	        }

	        if (0 != errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	        {
		        Console.Write("\nError:  No ARINC 708 transmit channels present in cardnum {0}.",CARDNUM);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

	        Console.Write("\nUsing ARINC 708 core #{0}",corenum);
	        Console.Write("\nUsing transmit channel #{0}",xmtchan);
	        Console.Write("\n");

            /**
            *
            *  Configure transmit channel.
            *
            **/

	        BTICARD.BTICard_CardReset(hCore);

	        errval = BTI708.BTI708_ChConfig(BTI708.CHCFG708_DEFAULT,xmtchan,hCore);

	        if (0 != errval)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        channel #{0} on core #{1}.",xmtchan,corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Build the transmit channel messages.
            *
            **/

	        errval = BTI708.BTI708_XmtBuild(BTI708.MSGCRT708_DEFAULT,framefreq,blocksize,framecount,xmtchan,hCore);

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
            *  Open the data file for reading.
            *
            **/

            BinaryFile = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            BinaryReader = new System.IO.BinaryReader(BinaryFile);

            if (BinaryReader == null)
	        {
		        Console.Write("\nError:  Unable to open the data file {0}.",filename);
		        Console.Write("\n");
		        BTICARD.BTICard_CardClose(hCard);
		        Environment.Exit(1);
	        }

            /**
            *
            *  Preload two blocks of data from the file to the card.
            *
            **/

	        for (j=0;j<framecount;++j)						//Loop through each of the frames
	        {
                for (jj = 0; jj < Data.Length; jj++)
                {
                    try
                    {
                        Data[jj] = BinaryReader.ReadUInt16();
                    }
                    catch (Exception ex)
                    {
                        //At end of file
                        Console.Write("\nResetting data file {0}", filename);
                        BinaryFile.Seek(0, System.IO.SeekOrigin.Begin); //Seek to beginning of file
                        Data[jj] = BinaryReader.ReadUInt16();   
                    }
                }

                BTI708.BTI708_MsgDataWr(ref Data[0], j, xmtchan, hCore);	//Write the data for frame
	        }

            /**
            *
            *  Configure the Event Log list.
            *
            **/

	        errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE,1024,hCore);

	        if (errval < 0)
	        {
		        Console.Write("\nError:  An error was encountered ({0}) while configuring",errval);
		        Console.Write("\n        the event log list on core #{0}.",corenum);
		        Console.Write("\n        ({0})",BTICARD.BTICard_ErrDescStr(errval,hCard));
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
            *  Check for the -AUTO option.
            *
            **/

	        if ((opts = isargopt(args,"AUTO")) != null)
	        {
		        Console.Write("\nExiting program.");
		        Console.Write("\nDevice is now transmitting static data.");
                             
		        BTICARD.BTICard_CardClose(hCard);               //Close the card
                Environment.Exit(0);
	        }

            /**
            *
            *  Loop until a key is hit.
            *
            **/

	        Console.Write("\nPress any key to exit...");
	        Console.Write("\n");

	        while (0 == Win32Interop._kbhit())
	        {
		        if (0 != BTICARD.BTICard_EventLogRd(ref Type,ref Info,ref Chan,hCore))	//Read entry from Event Log list
		        {
			        framenum = (UInt16)Info;

			        if (framenum == ((framecount/2)-1))			//First half transmitted
			        {
				        for (j=0;j<=framenum;j++)
				        {
                            for (jj = 0; jj < Data.Length; jj++)
                            {
                                try
                                {
                                    Data[jj] = BinaryReader.ReadUInt16();
                                }
                                catch (Exception ex)
                                {
                                    //At end of file
                                    Console.Write("\nResetting data file {0}", filename);
                                    BinaryFile.Seek(0, System.IO.SeekOrigin.Begin); //Seek to beginning of file
                                    Data[jj] = BinaryReader.ReadUInt16();
                                }
                            }

                            BTI708.BTI708_MsgDataWr(ref Data[0], j, xmtchan, hCore);	//Write the data for frame
				        }

				        Console.Write("\nUpdated frames {0} to {0}.",0,framenum);
			        }
			        else if (framenum == (framecount-1))		//Second half transmitted
			        {
				        for (j=(framecount/2);j<=framenum;j++)
				        {
                            for (jj = 0; jj < Data.Length; jj++)
                            {
                                try
                                {
                                    Data[jj] = BinaryReader.ReadUInt16();
                                }
                                catch (Exception ex)
                                {
                                    //At end of file
                                    Console.Write("\nResetting data file {0}", filename);
                                    BinaryFile.Seek(0, System.IO.SeekOrigin.Begin); //Seek to beginning of file
                                    Data[jj] = BinaryReader.ReadUInt16();
                                }
                            }

                            BTI708.BTI708_MsgDataWr(ref Data[0], j, xmtchan, hCore);	//Write the data for frame
				        }

				        Console.Write("\nUpdated frames {0} to {0}.",framecount/2,framenum);
			        }
		        }
	        }

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
