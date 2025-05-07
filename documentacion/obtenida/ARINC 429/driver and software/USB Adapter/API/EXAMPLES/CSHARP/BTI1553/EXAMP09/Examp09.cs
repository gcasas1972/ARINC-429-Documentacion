using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using BALLARD;

/**
*
*  BTI1553 DRIVER EXAMPLE 9  (06/07/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Event Log using Interrupts
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The schedule is also configured to generate an Event Log List
*  entry after each 10ms frame.  An interrupt handler is installed
*  which enables the Event Log List to generate an interrupt when an
*  entry is made to the list.  Upon each interrupt, the data
*  words associated with the 0843H BC-RT message are updated.
*
**/

namespace EXAMP9
{
    // Win32Interop class contains the required calls into Win32 DLL 
    // files.
    public class Win32Interop
    {
        public const UInt32 WAIT_TIMEOUT = 258;

        [DllImport("crtdll.dll")]
        public static extern int _kbhit();

        [DllImport("kernel32", SetLastError = true)]
        internal static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateEvent(IntPtr lpSecurityAttributes, bool isManualReset, bool initialState, String name);

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        public static extern IntPtr CloseHandle(IntPtr hHandle);
    }

    // ThreadMailbox contains data that will be passed to the thread. 
    public class ThreadMailbox
    {
        public Boolean fStayAlive = true;
        public UInt32 hCore;
        public UInt32 Count = 0;
        public IntPtr hEvent = IntPtr.Zero;
        public Thread tThread;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public UInt32[] BCMsgs;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public UInt16[] Data;
    }

    // Examp9 class contains the MAIN and INTERUPT functions.
    public class Examp9
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        private const Int32 CMD0 = 0x0843;		    /*Command word for first message*/
        private const Int32 CMD1 = 0x0821;		    /*Command word for second message*/
        private const Int32 RCV_CMD2 = 0x0821;		/*Receive command of an RT-RT transfer*/
        private const Int32 XMT_CMD2 = 0x1C21;	    /*Transmit command of an RT-RT transfer*/

        private const Int32 FRAMETIME = 10000;		/*Frame time in microseconds*/

        /**
        *
        *  The following thread is spun off by the main application.
        *  It waits for the specified thread to be released when the
        *  card generates an interrupt.  It then resets the event to
        *  allow us to receive more events, reads an entry from the
        *  Event Log list, and waits for the next event.
        *
        **/
        static void EventLogInterruptThread(object obj)
        {
            UInt16 Type = 0;
            UInt32 Info = 0;
            Int32 Chan = 0;

            ThreadMailbox oMailbox = (ThreadMailbox)obj;

            oMailbox.fStayAlive = true;
            oMailbox.Count = 0;

            while (oMailbox.fStayAlive)
            {
                if (Win32Interop.WAIT_TIMEOUT == Win32Interop.WaitForSingleObject(oMailbox.hEvent, 200))
                {
                    //do nothing
                }
                else
                {
                    oMailbox.Count++;							//Increment counter

                    //Read entry from Event Log list
                    BTICARD.BTICard_EventLogRd(ref Type, ref Info, ref Chan, oMailbox.hCore);

                    oMailbox.Data[0] += 2;						//Calculate the new data words
                    oMailbox.Data[1] += 4;
                    oMailbox.Data[2] += 6;

                    //Write the new data words
                    BTI1553.BTI1553_MsgDataWr(ref oMailbox.Data[0], 3, oMailbox.BCMsgs[0], oMailbox.hCore);

                    BTICARD.BTICard_IntClear(oMailbox.hCore);	//Clear interrupt from card
                }
            }

            return;
        }

        // Main function
        static void Main(string[] args)
        {
            UInt32 hCard = 0;
            UInt32 hCore = 0;
            Int32 errval = 0;
            Int32 corenum = 0;
            Int32 channum = 0;

            ThreadMailbox oMailbox = new ThreadMailbox();
            oMailbox.Data = new UInt16[3];
            oMailbox.BCMsgs = new UInt32[3];

            Console.Write("\n    **********************************************************************");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP9    (06/07/2011)                                            *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
            Console.Write("\n    *  All rights reserved.                                              *");
            Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
            Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  BTI1553 Example 9                                                 *");
            Console.Write("\n    *   \"Event Log using Interrupts\"                                     *");
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

            errval = BTICARD.BTICard_CardOpen(ref hCard, CARDNUM);

            if (0 != errval)
            {
                Console.Write("\nError:  Either card number {0} is not present, or", CARDNUM);
                Console.Write("\n        an error occurred ({0}) opening the card.", errval);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                Environment.Exit(1);
            }

            Console.Write("\nUsing BTI1553 card #{0}", CARDNUM);

            /**
            *
            *  Find the first MIL-STD-1553 core and channel.
            *
            **/

            for (corenum = 0; corenum < MAX_CORES; corenum++)
            {
                errval = BTICARD.BTICard_CoreOpen(ref hCore, corenum, hCard);
                if (0 != errval) break;

                for (channum = 0; channum < MAX_CHANNELS; channum++)
                    if (0 != BTI1553.BTI1553_ChIs1553(channum, hCore)) break;

                if (channum != MAX_CHANNELS) break;
            }

            if (0 != errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
            {
                Console.Write("\nError:  No MIL-STD-1553 channels present in cardnum {0}.", CARDNUM);
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            Console.Write("\nUsing MIL-STD-1553 core #{0}", corenum);
            Console.Write("\nUsing MIL-STD-1553 channel #{0}", channum);
            Console.Write("\n");

            /**
            *
            *  Create an event object.
            *
            **/

            oMailbox.hEvent = Win32Interop.CreateEvent(IntPtr.Zero, true, false, "MyEvent");
            
            if (oMailbox.hEvent == IntPtr.Zero)
            {
                Console.Write("\nError:  Event creation failed");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Create a thread to run on the Mailbox function.
            *
            **/

            oMailbox.hCore = hCore;
            oMailbox.tThread = new Thread(EventLogInterruptThread);

            /**
            *
            *  Install the interrupt handler.
            *
            **/

            errval = BTICARD.BTICard_IntInstall(oMailbox.hEvent, hCore);
            
            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while installing", errval);
                Console.Write("\n        interrupt handler on core #{0}.", corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Win32Interop.CloseHandle(oMailbox.hEvent);
                oMailbox.tThread.Abort();
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Configure the channel for bus controller mode.
            *
            **/

            BTICARD.BTICard_CardReset(hCore);									/*Reset the core*/

            errval = BTI1553.BTI1553_BCConfig(BTI1553.BCCFG1553_DEFAULT, channum, hCore);	/*Configure the core*/

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring bus", errval);
                Console.Write("\n        controller mode on channel #{0} on core #{1}.", channum, corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Create the message records for each of the three messages.
            * 
            **/

            oMailbox.Data[0] = 0;
            oMailbox.Data[1] = 0;
            oMailbox.Data[2] = 0;

            oMailbox.BCMsgs[0] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT, CMD0, 0, ref oMailbox.Data[0], hCore);
            oMailbox.BCMsgs[1] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_DEFAULT, CMD1, 0, ref oMailbox.Data[1], hCore);
            oMailbox.BCMsgs[2] = BTI1553.BTI1553_BCCreateMsg(BTI1553.MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, ref oMailbox.Data[2], hCore);

            /**
            *
            *  Schedule the messages to create the desired bus controller
            *  schedule.  Also schedule an Event Log after each frame.
            *  Note the unique tag value associated with each Event Log
            *  that could be used to distinguish unique Events.
            *
            **/

            BTI1553.BTI1553_BCSchedFrame(FRAMETIME, channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[0], channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[1], channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[2], channum, hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x1111, channum, hCore);

            BTI1553.BTI1553_BCSchedFrame(FRAMETIME, channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[0], channum, hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x2222, channum, hCore);

            BTI1553.BTI1553_BCSchedFrame(FRAMETIME, channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[0], channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[1], channum, hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x3333, channum, hCore);

            BTI1553.BTI1553_BCSchedFrame(FRAMETIME, channum, hCore);
            BTI1553.BTI1553_BCSchedMsg(oMailbox.BCMsgs[0], channum, hCore);
            BTI1553.BTI1553_BCSchedLog(BTI1553.COND1553_ALWAYS, 0x4444, channum, hCore);

            /**
            * 
            *  Configure the Event Log list.
            * 
            **/

            errval = BTICARD.BTICard_EventLogConfig((UInt16)BTICARD.LOGCFG_ENABLE, 1024, hCore);

            if (errval < 0)
            {
                Console.Write("\nError:  An error was encountered ({0}) while configuring the", errval);
                Console.Write("\n        Event Log list on on core #{0}.", corenum);
                Console.Write("\n        ({0})", BTICARD.BTICard_ErrDescStr(errval, hCard));
                Console.Write("\n");
                BTICARD.BTICard_IntUninstall(hCard);
                Win32Interop.CloseHandle(oMailbox.hEvent);
                oMailbox.tThread.Abort();
                BTICARD.BTICard_CardClose(hCard);
                Environment.Exit(1);
            }

            /**
            *
            *  Start the tread.
            *  Pass in the mailbox object.
            *
            **/

            oMailbox.tThread.Start(oMailbox);

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

            Console.Write("\nPress any key to exit....\n\n");

            while (0 == Win32Interop._kbhit())
            {
                Console.Write("\rTransmitting data {0:X4}H, {1:X4}H, {2:X4}H", oMailbox.Data[0], oMailbox.Data[1], oMailbox.Data[2]);
            }

            /**
            *  Clear the flag keeping the thread alive and wait for the
            *  thread to quit.
            **/

            Console.Write("\nWaiting for the thread to quit.");

            oMailbox.fStayAlive = false;		//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

            Win32Interop.WaitForSingleObject(oMailbox.hEvent, 10000);
            
            /**
            *
            *  Stop the card.
            *
            **/

            BTICARD.BTICard_CardStop(hCore);
            BTICARD.BTICard_IntUninstall(hCore);
            Win32Interop.CloseHandle(oMailbox.hEvent);
            oMailbox.tThread.Abort();

            /**
            *
            *  The card MUST be closed before exiting the program.
            *
            **/

            BTICARD.BTICard_CardClose(hCard);
        }

    }
}
