package com.ballardtech;

import com.ballardtech.BTICard;

public final class BTI1553
{
	static
	{
		try
		{
			if (System.getProperty("sun.arch.data.model").equals("64"))
				System.loadLibrary("bti155364");
			else
				System.loadLibrary("bti1553");
			
	        System.loadLibrary("bti1553g");
		}
		catch (UnsatisfiedLinkError rule)
		{
			// TODO Auto-generated catch block
			rule.printStackTrace();
		}
	}

	public static final class XMITFIELDS1553 implements Cloneable
	{
		public int ctrlflags = 0;				//User writes message configuration options
		public char flag1 = 0;					//Card writes message flag 1
		public char flag2 = 0;					//Card writes message flag 2
		public char errflags = 0;				//Card writes error flags
		public char actflags = 0;				//Card writes activity flags
	    public int resptime1 = 0;				//Card writes response time 1
	    public int resptime2 = 0;				//Card writes response time 2
	    public char datacount = 0;				//Card writes data count
	    public char extflag = 0;				//Driver writes external flags
	    public long timetag = 0;				//Card writes time tag
	    public long elapsetime = 0;				//Card writes elapsed time
	    public int preaddr = 0;					//Driver writes pre-proc address
	    public int postaddr = 0;				//Driver writes post-proc address
	    public long timetagh = 0;				//Card writes extended timetag
	    public char resv18 = 0;					//Reserved field
	    public char resv19 = 0;					//Reserved field
	    public char cwd1 = 0;					//User writes command word 1
	    public char cwd2 = 0;					//User writes command word 2
	    public char swd1 = 0;					//Card writes status word 1
	    public char swd2 = 0;					//Card writes status word 2
	    public char[] data = new char[32];		//User writes data words
	    public char[] extra = new char[8];		//User writes extra words
	}	
	
	public static final class MSGFIELDS1553 implements Cloneable
	{
		public char msgflag = 0;             		//Driver writes message flags
		public char msgopt = 0;              		//Driver writes message options
		public char msgerr = 0;              		//Card writes message errors
		public char msgact = 0;              		//Card writes message activity
		public int resptime1 = 0;           		//Card writes response time 1
		public int resptime2 = 0;           		//Card writes response time 2
		public char datacount = 0;           		//Card writes data count
	    public char extflag = 0;             		//Driver writes external flags
	    public long timetag_hitcount = 0;        	//Card writes time tag or hit count
	    public long elapsetime_mintime_maxtime = 0; //Card writes elapsed time or mintime or maxtime
	    public int preaddr = 0;             		//Driver writes pre-proc address
	    public int postaddr = 0;           			//Driver writes post-proc address
	    public long timetagh = 0;           		//Card writes extended timetag
	    public char resv18 = 0;              		//Reserved field
	    public char resv19 = 0;              		//Reserved field
	    public char cwd1 = 0;                		//Card/User writes command word 1 (R/T)
	    public char cwd2 = 0;                		//Card/User writes command word 2 (R/T)
	    public char swd1 = 0;                		//Card writes status word 1
	    public char swd2 = 0;                		//Card writes status word 2
	    public char[] data = new char[32];      	//User/Card writes data words (R/T)
	    public char[] extra = new char[8];      	//User/Card writes extra words (R/T)
	}	
	
    public static native int BCConfig(int configval,int channum,int handleval);
    public static native int BCConfigEx(int configval,int count,int channum,int handleval);
    public static native int BCConfigMsg(int configval,int msgaddr,int handleval);
    public static native int BCCreateList(int listconfigval,int count,int msgconfigval,char cwd1,char cwd2,char[] data,int handleval);
    public static native int BCCreateMsg(int configval,char cwd1,char cwd2,char[] data,int handleval);
    public static native void BCPause(int channum,int handleval);
    public static native int BCPauseCheck(int channum,int handleval);
    public static native void BCResume(int channum,int handleval);
    public static native int BCSchedAgain(int index,int channum,int handleval);
    public static native int BCSchedBranch(int condition,int destindex,int channum,int handleval);
    public static native int BCSchedBranchUpdate(int destindex,int opcodeindex,int channum,int handleval);
    public static native int BCSchedBuild(int nummsgs,int[] msgaddr,char[] freq,int channum,int handleval);
    public static native int BCSchedCall(int condition,int destindex,int channum,int handleval);
    public static native int BCSchedCallUpdate(int destindex,int opcodeindex,int channum,int handleval);
    public static native int BCSchedEntry(int channum,int handleval);
    public static native int BCSchedFrame(int timeval,int channum,int handleval);
    public static native int BCSchedFrameEnd(int channum,int handleval);
    public static native int BCSchedFrameStart(long timeval,int channum,int handleval);
    public static native int BCSchedGap(int gapval,int channum,int handleval);
    public static native int BCSchedHalt(int channum,int handleval);
    public static native int BCSchedLog(int condition,char tagval,int channum,int handleval);
    public static native int BCSchedMsg(int msgaddr,int channum,int handleval);
    public static native int BCSchedPause(int channum,int handleval);
    public static native int BCSchedPulse(int dionum,int channum,int handleval);
    public static native int BCSchedPulse0(int dionum,int channum,int handleval);
    public static native int BCSchedPulse1(int dionum,int channum,int handleval);
    public static native int BCSchedRestart(int channum,int handleval);
    public static native int BCSchedRetry(int condition,int retries,int channum,int handleval);
    public static native int BCSchedReturn(int channum,int handleval);
    public static native int BCSetDefaultGap(int gapval,int channum,int handleval);
    public static native int BCSetTimeout(int timeoutval,int channum,int handleval);
    public static native int BCSyncDefine(boolean enableflag,char syncmask,char pinpolarity,int channum,int handleval);
    public static native int BCTransmitMsg(XMITFIELDS1553 xmitfields, int channum, int handleval);
    public static native int BCTriggerDefine(boolean enableflag,char trigmask,char trigval,char pinpolarity,int channum,int handleval);
    public static native int BlkPtrRd(int taval, int channum, int handleval);
    public static native int BlkPtrWr(int descaddr, int taval, int channum, int handleval);
    public static native void ChGetCount(BTICard.IntRef a_count,BTICard.IntRef b4_count,BTICard.IntRef b32_count,BTICard.IntRef c_count,int handleval);
    public static native long ChGetInfo(char infotype,int channum,int handleval);
    public static native int ChIs1553(int channum,int handleval);
    public static native boolean ChIsA(int channum,int handleval);
    public static native boolean ChIsB32(int channum,int handleval);
    public static native boolean ChIsB4(int channum,int handleval);
    public static native boolean ChIsBM(int channum,int handleval);
    public static native boolean ChIsC(int channum,int handleval);
    public static native boolean ChIsD(int channum,int handleval);
    public static native boolean ChIsM(int channum,int handleval);
    public static native boolean ChIsRM(int channum,int handleval);
    public static native boolean ChIsS(int channum,int handleval);
    public static native boolean ChIsX(int channum,int handleval);
    public static native boolean ChStart(int channum,int handleval);
    public static native boolean ChStop(int channum,int handleval);
    public static native int CmdMaxLoopRd(int channum,int handleval);
    public static native void CmdMaxLoopWr(int countval,int channum,int handleval);
    public static native boolean CmdShotRd(int index,int channum,int handleval);
    public static native int CmdShotWr(boolean value,int index,int channum,int handleval);
    public static native boolean CmdSkipRd(int index,int channum,int handleval);
    public static native int CmdSkipWr(boolean value,int index,int channum,int handleval);
    public static native boolean CmdStepRd(int index,int channum,int handleval);
    public static native int CmdStepWr(boolean value,int index,int channum,int handleval);
    public static native int ErrorCtrl(int ctrlval,int channum,int handleval);
    public static native int ErrorDefine(int defineval,char errvalue,int countval,int wordpos,int bitpos,int channum,int handleval);
    public static native boolean ErrorSent(int channum,int handleval);
    public static native int ErrorTagBC(boolean tagval,int msgaddr,int channum,int handleval);
    public static native int ErrorTagRT(boolean tagval,boolean mcflag,int taval,boolean trflag,int saval,int channum,int handleval);
    public static native int ErrorTriggerDefine(boolean enableflag,char trigmask,char trigval,char pinpolarity,int channum,int handleval);
    public static native int ListBlockRd(MSGFIELDS1553 msgfields,int listaddr,int handleval);
    public static native int ListBlockWr(MSGFIELDS1553 msgfields,int listaddr,int handleval);
    public static native int ListDataRd(char[] buf,int count,int listaddr,int handleval);
    public static native int ListDataWr(char[] buf,int count,int listaddr,int handleval);
    public static native boolean ListMultiBlockRd(MSGFIELDS1553[] msgfieldsarray,BTICard.IntRef blkcountptr,int listaddr,int handleval);
    public static native boolean ListMultiBlockWr(MSGFIELDS1553[] msgfieldsarray,int blkcount,int listaddr,int handleval);
    public static native int MonConfig(int configval,int channum,int handleval);
    public static native int MonFilterSA(int taval,int rcvsamask,int xmtsamask,int rcvmcmask,int xmtmcmask,int channum,int handleval);
    public static native int MonFilterTA(int tamask,int channum,int handleval);
    public static native int MsgBlockRd(MSGFIELDS1553 msgfields,int msgaddr,int handleval);
    public static native int MsgBlockWr(MSGFIELDS1553 msgfields,int msgaddr,int handleval);
    public static native void MsgDataRd(char[] buf,int count,int msgaddr,int handleval);
    public static native void MsgDataWr(char[] buf,int count,int msgaddr,int handleval);
    public static native long MsgFieldRd(char fieldtype,int msgaddr,int handleval);
    public static native long MsgFieldWr(long fieldval,char fieldtype,int msgaddr,int handleval);   
    public static native boolean MsgSkipRd(int msgaddr,int handleval);
    public static native void MsgSkipWr(boolean skip,int msgaddr,int handleval);
    public static native int MsgSyncDefine(boolean enableflag,char syncmask,char pinpolarity,int msgaddr,int handleval);
    public static native int MsgTriggerDefine(boolean enableflag,char trigmask,char trigval,char pinpolarity,int msgaddr,int handleval);
    public static native int ParamAmplitudeConfig(int configval,int dacval,int channum,int handleval);
    public static native int ParamAmplitudeGet(BTICard.IntRef dacval,int channum,int handleval);
    public static native int PlayConfig(int configval,int tamask,int channum,int handleval);
    public static native int PlayStatus(int channum,int handleval);
    public static native int PlayWr(char[] buf,int bufcount,int channum,int handleval);
    public static native int RTConfig(int configval,int taval,int channum,int handleval);
    public static native int RTCreateList(int listconfigval,int count,int msgconfigval,boolean mcflag,int taval,boolean trflag,int saval,int channum,int handleval);
    public static native int RTCreateMsg(int configval,boolean mcflag,int taval,boolean trflag,int saval,int channum,int handleval);
    public static native int RTGetMsg(boolean mcflag,int taval,boolean trflag,int saval,int channum,int handleval);
    public static native int RTReset(int taval,int channum,int handleval);
    public static native int RTResponseTimeSet(int resptime,int taval,int channum,int handleval);
    public static native int RTSetMode(int configval,int taval,int channum,int handleval);
    public static native char RTSWDRd(int taval,int channum,int handleval);
    public static native int RTSWDWr(char swdval,int taval,int channum,int handleval);
    public static native int RTSyncDefine(boolean enableflag,char syncmask,char pinpolarity,int taval,int rcvsamask,int xmtsamask,int rcvmcmask,int xmtmcmask,int channum,int handleval);
    public static native char ValPackCWD(int TAval,int TRflag,int SAval,int WCval);
    public static native void ValUnpackCWD(char CWDval,BTICard.IntRef TAval,BTICard.IntRef TRflag,BTICard.IntRef SAval,BTICard.IntRef WCval);
    
    /**
    *
    *  Channel number constants
    *
    **/
    
    public static final int CH0                    = 0x0000;          //Channel 0
    public static final int CH1                    = 0x0001;          //Channel 1
    public static final int CH2                    = 0x0002;          //Channel 2
    public static final int CH3                    = 0x0003;          //Channel 3
    public static final int CH4                    = 0x0004;          //Channel 4
    public static final int CH5                    = 0x0005;          //Channel 5
    public static final int CH6                    = 0x0006;          //Channel 6
    public static final int CH7                    = 0x0007;          //Channel 7

	/**
	*
	*  Bus controller configuration options
	*
	**/

	public static final int BCCFG1553_DEFAULT      = 0x00000000;      //Select all default settings
	public static final int BCCFG1553_ENABLE       = 0x00000000;      //Enable bus controller (default)
	public static final int BCCFG1553_DISABLE      = 0x00000001;      //Disable bus controller
	public static final int BCCFG1553_TRIGNONE     = 0x00000000;      //No trigger (default)
	public static final int BCCFG1553_TRIGEXT      = 0x00000010;      //Trigger external
	public static final int BCCFG1553_TRIGSTART    = 0x00000020;      //Trigger external start
	public static final int BCCFG1553_NOLOGHALT    = 0x00000000;      //Do not generate event log on halt (default)
	public static final int BCCFG1553_LOGHALT      = 0x00000100;      //Generate event log on halt
	public static final int BCCFG1553_NOLOGPAUSE   = 0x00000000;      //Do not generate event log on pause (default)
	public static final int BCCFG1553_LOGPAUSE     = 0x00000200;      //Generate event log on pause
	public static final int BCCFG1553_NOLOOPMAX    = 0x00000000;      //Disable maximum loop count (default)
	public static final int BCCFG1553_LOOPMAX      = 0x00001000;      //Enable maximum loop count
	public static final int BCCFG1553_NOSTEP       = 0x00000000;      //Disable single stepping (default)
	public static final int BCCFG1553_STEP         = 0x00002000;      //Enable single stepping
	public static final int BCCFG1553_MC01         = 0x00000000;      //Select SA=00000 or SA=11111 for mode codes (default)
	public static final int BCCFG1553_MC1          = 0x01000000;      //Select SA=11111 for mode codes
	public static final int BCCFG1553_MC0          = 0x02000000;      //Select SA=00000 for mode codes
	public static final int BCCFG1553_MCNONE       = 0x03000000;      //Disable mode codes
	public static final int BCCFG1553_TERMOFF      = 0x00000000;      //Direct coupled termination resistance off (Bus A & B) (default)
	public static final int BCCFG1553_TERMONA      = 0x04000000;      //Direct coupled termination resistance on  (Bus A)
	public static final int BCCFG1553_TERMONB      = 0x08000000;      //Direct coupled termination resistance on  (Bus B)
	public static final int BCCFG1553_TERMONAB     = 0x0C000000;      //Direct coupled termination resistance on  (Bus A & B)
	public static final int BCCFG1553_SYNCSEL      = 0x00000000;      //Selective sync (default)
	public static final int BCCFG1553_SYNCALL      = 0x40000000;      //Sync on all messages
	public static final int BCCFG1553_PAUSE        = 0x00000400;      //Mark channel as paused
	public static final int BCCFG1553_UNPAUSE      = 0x00000000;      //Mark channel as unpaused (default)
	public static final int BCCFG1553_SELFTEST     = 0x00800000;      //This channel will transmit/receive on the internal self-test bus
	public static final int BCCFG1553_SELFTESTOFF  = 0x00000000;      //This channel will transmit/receive on the operational bus (default)

	/**
	*
	*  Monitor configuration options
	*
	**/

	public static final int MONCFG1553_DEFAULT     = 0x00000000;      //Select all default settings
	public static final int MONCFG1553_ENABLE      = 0x00000000;      //Enable monitor
	public static final int MONCFG1553_DISABLE     = 0x00000001;      //Disable monitor
	public static final int MONCFG1553_NOBCAST     = 0x00000000;      //Disable broadcast (default)
	public static final int MONCFG1553_BCAST       = 0x00000100;      //Enable broadcast
	public static final int MONCFG1553_COMPLETE    = 0x00000000;      //Enable receiving complete words (default)
	public static final int MONCFG1553_INCOMPLETE  = 0x00010000;      //Enable receiving incomplete words
	public static final int MONCFG1553_MC01        = 0x00000000;      //Select SA=00000 or SA=11111 for mode codes (default)
	public static final int MONCFG1553_MC1         = 0x00100000;      //Select SA=11111 for mode codes
	public static final int MONCFG1553_MC0         = 0x00200000;      //Select SA=00000 for mode codes
	public static final int MONCFG1553_MCNONE      = 0x00300000;      //Disable mode codes
	public static final int MONCFG1553_TERMOFF     = 0x00000000;      //Direct coupled termination resistance off (Bus A & B) (default)
	public static final int MONCFG1553_TERMONA     = 0x04000000;      //Direct coupled termination resistance on  (Bus A)
	public static final int MONCFG1553_TERMONB     = 0x08000000;      //Direct coupled termination resistance on  (Bus B)
	public static final int MONCFG1553_TERMONAB    = 0x0C000000;      //Direct coupled termination resistance on  (Bus A & B)
	public static final int MONCFG1553_SELFTEST    = 0x00800000;      //This channel will transmit/receive on the internal self-test bus
	public static final int MONCFG1553_SELFTESTOFF = 0x00000000;      //This channel will transmit/receive on the operational bus (default)
	
	/**
	*
	*  Remote terminal configuration options
	*
	**/

	public static final int RTCFG1553_DEFAULT      = 0x00000000;      //Select all default settings
	public static final int RTCFG1553_SIMULATE     = 0x00000000;      //Enable RT simulation (default)
	public static final int RTCFG1553_DISABLE      = 0x00000001;      //Disable RT
	public static final int RTCFG1553_MONITOR      = 0x00000002;      //Enable RT monitor
	public static final int RTCFG1553_NOBCAST      = 0x00000000;      //Disable broadcast (default)
	public static final int RTCFG1553_BCAST        = 0x00000100;      //Enable broadcast
	public static final int RTCFG1553_NOAUTOBUSY   = 0x00000000;      //Disable auto busy (default)
	public static final int RTCFG1553_AUTOBUSY     = 0x00000200;      //Enable auto busy
	public static final int RTCFG1553_BUILD        = 0x00000000;      //Enable auto building (default)
	public static final int RTCFG1553_NOBUILD      = 0x00000400;      //Disable auto building
	public static final int RTCFG1553_STDB         = 0x00000000;      //Use MIL-STD-1553B standard (default)
	public static final int RTCFG1553_STDA         = 0x00400000;      //Use MIL-STD-1553A standard
	public static final int RTCFG1553_NODYNBC      = 0x00000000;      //Do not respond to dynamic BC mode code (default)
	public static final int RTCFG1553_DYNBC        = 0x00001000;      //Respond to dynamic BC mode code
	public static final int RTCFG1553_NOIMMCLR     = 0x00000000;      //Do not clear status word bits (default)
	public static final int RTCFG1553_IMMCLR       = 0x00002000;      //Status word bits are cleared immediately
	public static final int RTCFG1553_NOBCASTADDR  = 0x00000000;      //Disable broadcast handling for address (default)
	public static final int RTCFG1553_BCASTADDR    = 0x00004000;      //Enable broadcast handling for address
	public static final int RTCFG1553_CHANAB       = 0x00000000;      //Respond to both channels (default)
	public static final int RTCFG1553_CHANA        = 0x00020000;      //Respond to channel A
	public static final int RTCFG1553_CHANB        = 0x00010000;      //Respond to channel B
	public static final int RTCFG1553_CHANNONE     = 0x00030000;      //Respond to neither channel A nor B
	public static final int RTCFG1553_MC01         = 0x00000000;      //Select SA=00000 or SA=11111 for mode codes (default)
	public static final int RTCFG1553_MC1          = 0x01000000;      //Select SA=11111 for mode codes
	public static final int RTCFG1553_MC0          = 0x02000000;      //Select SA=00000 for mode codes
	public static final int RTCFG1553_MCNONE       = 0x03000000;      //Disable mode codes
	public static final int RTCFG1553_TERMOFF      = 0x00000000;      //Direct coupled termination resistance off (Bus A & B) (default)
	public static final int RTCFG1553_TERMONA      = 0x04000000;      //Direct coupled termination resistance on  (Bus A)
	public static final int RTCFG1553_TERMONB      = 0x08000000;      //Direct coupled termination resistance on  (Bus B)
	public static final int RTCFG1553_TERMONAB     = 0x0C000000;      //Direct coupled termination resistance on  (Bus A & B)
	public static final int RTCFG1553_SYNCSEL      = 0x00000000;      //Selective sync (default)
	public static final int RTCFG1553_SYNCALL      = 0x40000000;      //Sync on all messages
	public static final int RTCFG1553_WIPE         = 0x00000000;      //Enables message clear (default)
	public static final int RTCFG1553_NOWIPE       = 0x80000000;      //Disables message clear
	public static final int RTCFG1553_WIPE0        = 0x00000000;      //Initialize data with zeros (default)
	public static final int RTCFG1553_WIPE123      = 0x10000000;      //Initialize data with incrementing values
	public static final int RTCFG1553_WIPECWD      = 0x20000000;      //Initialize data with command word
	public static final int RTCFG1553_RESPONSEB    = 0x00000000;      //RT responds using MIL-STD-1553B response time
	public static final int RTCFG1553_RESPONSEA    = 0x00400000;      //RT responds using MIL-STD-1553A response time
	public static final int RTCFG1553_SELFTEST     = 0x00800000;      //This channel will transmit/receive on the internal self-test bus
	public static final int RTCFG1553_SELFTESTOFF  = 0x00000000;      //This channel will transmit/receive on the operational bus (default)

	/**
	*
	*  Playback configuration options
	*
	**/

	public static final int PLAYCFG1553_DEFAULT    = 0x00000000;      //Select all default settings
	public static final int PLAYCFG1553_ENABLE     = 0x00000000;      //Enable Playback mode
	public static final int PLAYCFG1553_DISABLE    = 0x00000001;      //Disable Playback mode
	public static final int PLAYCFG1553_16K        = 0x00000000;      //Allocate a 16K playback buffer (default)
	public static final int PLAYCFG1553_ALLAVAIL   = 0x00000010;      //Allocate all available memory to playback buffer
	public static final int PLAYCFG1553_32K        = 0x00000020;      //Allocate a 32K playback buffer
	public static final int PLAYCFG1553_64K        = 0x00000040;      //Allocate a 64K playback buffer
	public static final int PLAYCFG1553_128K       = 0x00000080;      //Allocate a 128K playback buffer
	public static final int PLAYCFG1553_MC01       = 0x00000000;      //Select SA=00000 or SA=11111 for mode codes (default)
	public static final int PLAYCFG1553_MC1        = 0x01000000;      //Select SA=11111 for mode codes
	public static final int PLAYCFG1553_MC0        = 0x02000000;      //Select SA=00000 for mode codes
	public static final int PLAYCFG1553_MCNONE     = 0x03000000;      //Disable mode codes
	public static final int PLAYCFG1553_TERMOFF    = 0x00000000;      //Direct coupled termination resistance off (Bus A & B) (default)
	public static final int PLAYCFG1553_TERMONA    = 0x04000000;      //Direct coupled termination resistance on  (Bus A)
	public static final int PLAYCFG1553_TERMONB    = 0x08000000;      //Direct coupled termination resistance on  (Bus B)
	public static final int PLAYCFG1553_TERMONAB   = 0x0C000000;      //Direct coupled termination resistance on  (Bus A & B)

	/**
	*
	*  Serial configuration options
	*
	**/

	public static final int SERCFG1553_DEFAULT      = 0x00000000;     //Select all default settings
	public static final int SERCFG1553_CONTINUOUS   = 0x00000000;     //Enable continuous mode (default)
	public static final int SERCFG1553_DISABLE      = 0x00000001;     //Disable free mode
	public static final int SERCFG1553_FREE         = 0x00000002;     //Enable free mode
	public static final int SERCFG1553_NOLOGEMPTY   = 0x00000000;     //Do not generate event log when empty (default)
	public static final int SERCFG1553_LOGEMPTY     = 0x00000010;     //Generate event log when empty

	/**
	*
	*  Error configuration options
	*
	**/

	public static final int ERRDEF1553_NONE        = 0x00000000;      //Disable error generation (default)
	public static final int ERRDEF1553_GAP         = 0x00010000;      //Generate preceding gap error
	public static final int ERRDEF1553_CNTWRDABS   = 0x00020000;      //Generate an absolute word count error
	public static final int ERRDEF1553_CNTWRDREL   = 0x00040000;      //Generate a relative count error
	public static final int ERRDEF1553_CNTBIT      = 0x00080000;      //Generate a bit count error
	public static final int ERRDEF1553_MAN1        = 0x00100000;      //Generate manchester error on first half of bit
	public static final int ERRDEF1553_MAN2        = 0x00200000;      //Generate manchester error on second half of bit
	public static final int ERRDEF1553_SYNC        = 0x00400000;      //Generate a sync error
	public static final int ERRDEF1553_PAR         = 0x00800000;      //Generate a parity error
	public static final int ERRDEF1553_ZEROX1      = 0x01000000;      //Generate zero crossing error on leading zero crossing (if exists)
	public static final int ERRDEF1553_ZEROX2      = 0x02000000;      //Generate zero crossing error on mid-bit zero crossing

	public static final int ERRDEF1553_DWD00       = 0x0000;          //Error will be generated in data word  0
	public static final int ERRDEF1553_DWD01       = 0x0001;          //Error will be generated in data word  1
	public static final int ERRDEF1553_DWD02       = 0x0002;          //Error will be generated in data word  2
	public static final int ERRDEF1553_DWD03       = 0x0003;          //Error will be generated in data word  3
	public static final int ERRDEF1553_DWD04       = 0x0004;          //Error will be generated in data word  4
	public static final int ERRDEF1553_DWD05       = 0x0005;          //Error will be generated in data word  5
	public static final int ERRDEF1553_DWD06       = 0x0006;          //Error will be generated in data word  6
	public static final int ERRDEF1553_DWD07       = 0x0007;          //Error will be generated in data word  7
	public static final int ERRDEF1553_DWD08       = 0x0008;          //Error will be generated in data word  8
	public static final int ERRDEF1553_DWD09       = 0x0009;          //Error will be generated in data word  9
	public static final int ERRDEF1553_DWD10       = 0x000A;          //Error will be generated in data word 10
	public static final int ERRDEF1553_DWD11       = 0x000B;          //Error will be generated in data word 11
	public static final int ERRDEF1553_DWD12       = 0x000C;          //Error will be generated in data word 12
	public static final int ERRDEF1553_DWD13       = 0x000D;          //Error will be generated in data word 13
	public static final int ERRDEF1553_DWD14       = 0x000E;          //Error will be generated in data word 14
	public static final int ERRDEF1553_DWD15       = 0x000F;          //Error will be generated in data word 15
	public static final int ERRDEF1553_DWD16       = 0x0010;          //Error will be generated in data word 16
	public static final int ERRDEF1553_DWD17       = 0x0011;          //Error will be generated in data word 17
	public static final int ERRDEF1553_DWD18       = 0x0012;          //Error will be generated in data word 18
	public static final int ERRDEF1553_DWD19       = 0x0013;          //Error will be generated in data word 19
	public static final int ERRDEF1553_DWD20       = 0x0014;          //Error will be generated in data word 20
	public static final int ERRDEF1553_DWD21       = 0x0015;          //Error will be generated in data word 21
	public static final int ERRDEF1553_DWD22       = 0x0016;          //Error will be generated in data word 22
	public static final int ERRDEF1553_DWD23       = 0x0017;          //Error will be generated in data word 23
	public static final int ERRDEF1553_DWD24       = 0x0018;          //Error will be generated in data word 24
	public static final int ERRDEF1553_DWD25       = 0x0019;          //Error will be generated in data word 25
	public static final int ERRDEF1553_DWD26       = 0x001A;          //Error will be generated in data word 26
	public static final int ERRDEF1553_DWD27       = 0x001B;          //Error will be generated in data word 27
	public static final int ERRDEF1553_DWD28       = 0x001C;          //Error will be generated in data word 28
	public static final int ERRDEF1553_DWD29       = 0x001D;          //Error will be generated in data word 29
	public static final int ERRDEF1553_DWD30       = 0x001E;          //Error will be generated in data word 30
	public static final int ERRDEF1553_DWD31       = 0x001F;          //Error will be generated in data word 31
	public static final int ERRDEF1553_CWD1        = 0x0100;          //Error will be generated in CWD1
	public static final int ERRDEF1553_CWD2        = 0x0101;          //Error will be generated in CWD2
	public static final int ERRDEF1553_SWD         = 0x0102;          //Error will be generated in SWD
	public static final int ERRDEF1553_SWD1        = 0x0102;          //Error will be generated in SWD
	public static final int ERRDEF1553_SWD2        = 0x0102;          //Error will be generated in SWD

	/**
	*
	*  Error control options
	*
	**/

	public static final int ERRCTRL1553_OFF        = 0x00000000;      //Disable error generation
	public static final int ERRCTRL1553_ON         = 0x00000001;      //Enable error generation
	public static final int ERRCTRL1553_ONCE       = 0x00000002;      //Enable error generation once
	public static final int ERRCTRL1553_EXTERNAL   = 0x00000003;      //Enable externally triggered error generation
	public static final int ERRCTRL1553_TAGMSG     = 0x00000000;      //Generate errors on tagged messages
	public static final int ERRCTRL1553_ANYMSG     = 0x80000000;      //Generate errors on any message


	/**
	*
	*  Message configuration options
	*
	**/

	public static final int MSGCRT1553_DEFAULT     = 0x00000000;      //Default settings
	public static final int MSGCRT1553_ENABLE      = 0x00000000;      //Enable subaddress (RT) (default)
	public static final int MSGCRT1553_DISABLE     = 0x00001000;      //Disable subaddress (RT)
	public static final int MSGCRT1553_RESP        = 0x00000000;      //Enable response (RT) (default)
	public static final int MSGCRT1553_NORESP      = 0x00002000;      //Disable response (RT)
	public static final int MSGCRT1553_NOWRAP      = 0x00000000;      //Disable data wrap (RT) (default)
	public static final int MSGCRT1553_WRAP        = 0x00004000;      //Enable data wrap (RT)
	public static final int MSGCRT1553_NOLOG       = 0x00000000;      //Message will not generate event log (default)
	public static final int MSGCRT1553_LOG         = 0x00000001;      //Message will generate event log
	public static final int MSGCRT1553_NOERR       = 0x00000000;      //No message error will be generated for message (default)
	public static final int MSGCRT1553_ERR         = 0x00000002;      //A message error will be generated for message
	public static final int MSGCRT1553_BUSA        = 0x00000000;      //Message will be transmitted on bus A (BC) (default)
	public static final int MSGCRT1553_BUSB        = 0x00000004;      //Message will be transmitted on bus B (BC)
	public static final int MSGCRT1553_BCRT        = 0x00000000;      //Message is a BC-RT transfer (BC) (default)
	public static final int MSGCRT1553_RTRT        = 0x00000008;      //Message is an RT-RT transfer (BC)
	public static final int MSGCRT1553_NOMON       = 0x00000000;      //Message will not be monitored (default)
	public static final int MSGCRT1553_MON         = 0x00000010;      //Message will be monitored
	public static final int MSGCRT1553_NOTIMETAG   = 0x00000000;      //Message will not record time-tag (default)
	public static final int MSGCRT1553_TIMETAG     = 0x00000040;      //Message will record time-tag
	public static final int MSGCRT1553_NOELAPSE    = 0x00000000;      //Message will not record elapse time (default)
	public static final int MSGCRT1553_ELAPSE      = 0x00000080;      //Message will record elapse time
	public static final int MSGCRT1553_NOMIN       = 0x00000000;      //Message will not record min time (default)
	public static final int MSGCRT1553_MIN         = 0x00000100;      //Message will record min time
	public static final int MSGCRT1553_NOMAX       = 0x00000000;      //Message will not record max time (default)
	public static final int MSGCRT1553_MAX         = 0x00000200;      //Message will record max time
	public static final int MSGCRT1553_NOHIT       = 0x00000000;      //Message will not record hit count (default)
	public static final int MSGCRT1553_HIT         = 0x00000400;      //Message will record hit count
	public static final int MSGCRT1553_NOSYNC      = 0x00000000;      //No sync will be generated for message (default)
	public static final int MSGCRT1553_SYNC        = 0x40000000;      //Sync will be generated for message
	public static final int MSGCRT1553_WIPE        = 0x00000000;      //Enables message clear (default)
	public static final int MSGCRT1553_NOWIPE      = 0x80000000;      //Disables message clear
	public static final int MSGCRT1553_WIPE0       = 0x00000000;      //Initialize data with zeros (default)
	public static final int MSGCRT1553_WIPE123     = 0x01000000;      //Initialize data with incrementing values
	public static final int MSGCRT1553_WIPECWD     = 0x02000000;      //Initialize data with command word	

	/**
	*
	*  List buffer options
	*
	**/

	public static final int LISTCRT1553_DEFAULT    = 0x00000000;      //Select all default settings
	public static final int LISTCRT1553_PINGPONG   = 0x00000000;      //Enable ping-pong mode (default)
	public static final int LISTCRT1553_FIFO       = 0x00000001;      //Enable FIFO mode
	public static final int LISTCRT1553_CIRCULAR   = 0x00000002;      //Enable circular mode
	public static final int LISTCRT1553_TRBIT      = 0x00000000;      //User will read or write depending upon T/R bit
	public static final int LISTCRT1553_READ       = 0x00000010;      //User will read from list buffer
	public static final int LISTCRT1553_WRITE      = 0x00000020;      //User will write to list buffer
	public static final int LISTCRT1553_NOTSKIP    = 0x00000000;      //Will not skip messages
	public static final int LISTCRT1553_SKIP       = 0x00000040;      //Enable message skipping
	public static final int LISTCRT1553_ASYNC      = 0x00000080;      //Asynchronous mode
	public static final int LISTCRT1553_NOLOG      = 0x00000000;      //Do not generate event log when list buffer empty/full (default)
	public static final int LISTCRT1553_LOG        = 0x00000100;      //Generate event log when list buffer empty/full
	public static final int LISTCRT1553_NOHIT      = 0x00000000;      //Do not generate event log when list is hit (default)
	public static final int LISTCRT1553_HIT        = 0x00000200;      //Generate event log when list is hit
	public static final int LISTCRT1553_NOLOGHALF  = 0x00000000;      //Do not generate event log on middle and last entries (default)
	public static final int LISTCRT1553_LOGHALF    = 0x00000400;      //Generate event log on middle and last entries

	/**
	*
	*  Condition flags.
	*
	**/

	public static final int COND1553_ALWAYS        = 0x00000000;       //Unconditional
	public static final int COND1553_FAIL          = 0x00000001;       //Condition when all retries have failed
	public static final int COND1553_SRQ           = 0x00000002;       //Condition on Service Request bit set in status word
	public static final int COND1553_INS           = 0x00000004;       //Condition on Instrumentation bit set in status word
	public static final int COND1553_SSF           = 0x00000008;       //Condition on Subsystem Fail bit set in status word
	public static final int COND1553_TF            = 0x00000010;       //Condition on Terminal Flag bit set in status word
	public static final int COND1553_BUSY          = 0x00000020;       //Condition on Busy bit set in status word
	public static final int COND1553_ME            = 0x00000040;       //Condition on Message Error bit set in status word
	public static final int COND1553_RESPERR       = 0x00000080;       //Condition on response error
	public static final int COND1553_NORESP        = 0x00000100;       //Condition on no response error
	public static final int COND1553_ALTBUS        = 0x00000200;       //Retries are performed on alternate bus
	public static final int COND1553_DIO1ACT       = 0x00001000;       //Condition on digital I/O #1 active
	public static final int COND1553_DIO1NACT      = 0x00002000;       //Condition on digital I/O #1 not active
	public static final int COND1553_DIO2ACT       = 0x00004000;       //Condition on digital I/O #2 active
	public static final int COND1553_DIO2NACT      = 0x00008000;       //Condition on digital I/O #2 not active
	public static final int COND1553_DIO3ACT       = 0x00010000;       //Condition on digital I/O #3 active
	public static final int COND1553_DIO3NACT      = 0x00020000;       //Condition on digital I/O #3 not active
	public static final int COND1553_DIO4ACT       = 0x00040000;       //Condition on digital I/O #4 active
	public static final int COND1553_DIO4NACT      = 0x00080000;       //Condition on digital I/O #4 not active

	/**
	*
	*  Bit fields of the status word
	*
	**/

	public static final char SWD1553_TAMASK         = 0xF800;           //Masks off RT address in the SWD
	public static final char SWD1553_ME             = 0x0400;           //Message error bit
	public static final char SWD1553_INST           = 0x0200;           //Instrumentation bit
	public static final char SWD1553_SRQ            = 0x0100;           //Service request bit
	public static final char SWD1553_BCAST          = 0x0010;           //Broadcast received bit
	public static final char SWD1553_BUSY           = 0x0008;           //Busy bit
	public static final char SWD1553_SSF            = 0x0004;           //Subsystem flag bit
	public static final char SWD1553_DBC            = 0x0002;           //Dynamic bus control acceptance bit
	public static final char SWD1553_TF             = 0x0001;           //Terminal flag bit

	/**
	*
	*  Bit fields of the message error flag
	*
	**/

	public static final char MSGERR1553_NORESP      = 0x8000;           //Set when we timeout waiting for response
	public static final char MSGERR1553_ANYERR      = 0x4000;           //Set when any error bit is set
	public static final char MSGERR1553_PROTOCOL    = 0x2000;           //General protocol error
	public static final char MSGERR1553_SYNC        = 0x1000;           //Set when we have the wrong sync
	public static final char MSGERR1553_DATACOUNT   = 0x0800;           //Set when improper number of data words
	public static final char MSGERR1553_MANCH       = 0x0020;           //Set when manchester error detected
	public static final char MSGERR1553_PARITY      = 0x0010;           //Set when parity error detected
	public static final char MSGERR1553_WORD        = 0x0008;           //Set when word error detected
	public static final char MSGERR1553_RETRY       = 0x0004;           //All retries failed
	public static final char MSGERR1553_SYSTEM      = 0x0002;           //An internal system error occurred
	public static final char MSGERR1553_HIT         = 0x0001;           //Always set

	/**
	*
	*  Bit fields of the message activity flag.
	*
	**/

	public static final char MSGACT1553_CHMASK      = 0xF000;           //Channel number mask value
	public static final char MSGACT1553_CHSHIFT     = 0x000C;           //Channel number shift value
	public static final char MSGACT1553_XMTCWD1     = 0x0800;           //Transmitted CWD1
	public static final char MSGACT1553_XMTCWD2     = 0x0400;           //Transmitted CWD2
	public static final char MSGACT1553_XMTSWD1     = 0x0200;           //Transmitted SWD1
	public static final char MSGACT1553_XMTSWD2     = 0x0100;           //Transmitted SWD2
	public static final char MSGACT1553_RCVCWD1     = 0x0080;           //Received CWD1
	public static final char MSGACT1553_RCVCWD2     = 0x0040;           //Received CWD2
	public static final char MSGACT1553_RCVSWD1     = 0x0020;           //Received SWD1
	public static final char MSGACT1553_RCVSWD2     = 0x0010;           //Received SWD2
	public static final char MSGACT1553_XMTDWD      = 0x0008;           //Transmitted DWD
	public static final char MSGACT1553_RCVDWD      = 0x0004;           //Received DWD
	public static final char MSGACT1553_BUS         = 0x0001;           //Bus A/B bit

	/**
	*
	*  Field types.
	*
	**/

	public static final char FIELD1553_CWD1         = 0x0000;           //CWD1 field
	public static final char FIELD1553_CWD2         = 0x0001;           //CWD2 field
	public static final char FIELD1553_SWD1         = 0x0002;           //SWD1 field
	public static final char FIELD1553_SWD2         = 0x0003;           //SWD2 field
	public static final char FIELD1553_TTAG         = 0x0004;           //Time tag field
	public static final char FIELD1553_ELAPSE       = 0x0005;           //Elapse time field
	public static final char FIELD1553_ERROR        = 0x0006;           //Error field
	public static final char FIELD1553_ACT          = 0x0007;           //Activity field
	public static final char FIELD1553_RESP1        = 0x0008;           //Response time 1 field
	public static final char FIELD1553_RESP2        = 0x0009;           //Response time 2 field
	public static final char FIELD1553_COUNT        = 0x000A;           //Data count field
	public static final char FIELD1553_FLAG1        = 0x000B;           //Flag 1 field
	public static final char FIELD1553_FLAG2        = 0x000C;           //Flag 2 field
	public static final char FIELD1553_EXTFLAG      = 0x000D;           //External flag field
	public static final char FIELD1553_TTAGH        = 0x000E;           //Extended time tag field

	/**
	*
	*  Channel info fields.
	*
	**/

	public static final char INFO1553_MODEL         = 0x0001;            //Channel model type
	public static final char INFO1553_MAXCOUNT      = 0x0002;            //Channel terminal count
	public static final char INFO1553_MULTIMODE     = 0x0003;            //Channel supports multi-mode
	public static final char INFO1553_ERRORGEN      = 0x0004;            //Channel supports error generation
	public static final char INFO1553_CONCURMON     = 0x0005;            //Channel supports concurrent monitor
	public static final char INFO1553_MONFILTER     = 0x0006;            //Channel supports filtering of monitor
	public static final char INFO1553_PARAM         = 0x0007;            //Channel supports parametric control
	public static final char INFO1553_RTRESPTIME    = 0x0008;            //Channel supports programmable RT response time
	public static final char INFO1553_PLAYBACK      = 0x0009;            //Channel supports hardware playback mode
	public static final char INFO1553_VER2CHOBJ     = 0x000A;            //Channel supports version 2 channel object
	public static final char INFO1553_BCDFLTGAP     = 0x000B;            //Channel supports programmable default gap time

	/**
	*
	*  Parametric configuration options
	*
	**/

	public static final int PARAMCFG1553_DEFAULT   = 0x00000000;         //Select all default settings (default)
	public static final int PARAMCFG1553_AMPLON    = 0x00000000;         //Enables parametric amplitude control (default)
	public static final int PARAMCFG1553_AMPLOFF   = 0x00000001;         //Disables parametric amplitude control

	/**
	*
	*  Other flags.
	*
	**/

	public static final boolean SUBADDRESS             = false;           //Selects Subaddress messages
	public static final boolean MODECODE               = true;            //Selects Modecode messages
}
