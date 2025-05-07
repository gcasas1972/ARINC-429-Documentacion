package com.ballardtech;

import com.ballardtech.BTICard;

public final class BTI429 
{
	static
	{
		try
		{
			if (System.getProperty("sun.arch.data.model").equals("64"))
				System.loadLibrary("bti42964");
			else
				System.loadLibrary("bti429");
			
	        System.loadLibrary("bti429g");
		}
		catch (UnsatisfiedLinkError rule)
		{
			// TODO Auto-generated catch block
			rule.printStackTrace();
		}
	}
	
	public static final class MSGSTRUCT429 implements Cloneable
	{
		public int	addr = 0;
		public long data = 0;
	}

	public static final class MSGFIELDS429 implements Cloneable
	{
		public char msgopt = 0;             		//Driver writes message options
		public char msgact = 0;              		//Card writes message activity
	    public long msgdata_listptr = 0;        	//Card/User writes message data or Driver writes list buffer pointer
	    public long timetag_hitcount = 0;        	//Card writes time tag or hit count
	    public long elapsetime_maxtime = 0; 		//Card writes elapsed time or maxtime
	    public long mintime = 0;           			//Card writes min time
		public int userptr = 0;           			//Driver writes user code pointer
		public long timetagh = 0;           		//Card writes extended timetag
	    public char decgap = 0;              		//Card writes measured decoder gap time (rsvd for xmt msg)
	    public char rsvd = 0;              			//Reserved
	}	
	
	public static native long BCDGetData(long msg,short msb,short lsb);
	public static native long BCDGetMant(long msg,short sigdig);
	public static native short BCDGetSign(long msg);
	public static native short BCDGetSSM(long msg);
	public static native void BCDGetVal(BTICard.StringRef buf,long msg,short sigdig,String resolstr);
	public static native long BCDPutData(long msg,long value,short msb,short lsb);
	public static native long BCDPutMant(long msg,long value,short sigdig,short sign);
	public static native long BCDPutSign(long msg,short sign);
	public static native long BCDPutSSM(long msg,short value);
	public static native long BCDPutVal(String buf,long msg,short sigdig,String resolstr);
	public static native long BNRGetData(long msg,short msb,short lsb);
	public static native long BNRGetMant(long msg,short sigbit);
	public static native short BNRGetSign(long msg);
	public static native short BNRGetSSM(long msg);
	public static native void BNRGetVal(BTICard.StringRef buf,long msg,short sigbit,String resolstr);
	public static native long BNRPutData(long msg,long value,short msb,short lsb);
	public static native long BNRPutMant(long msg,long value,short sigbit,short twos);
	public static native long BNRPutSign(long msg,short twos);
	public static native long BNRPutSSM(long msg,short value);
	public static native long BNRPutVal(String buf,long msg,short sigbit,String resolstr);
	public static native int ChClear(int channum,int handleval);
	public static native int ChConfig(int configval,int channum,int handleval);
	public static native void ChGetCount(BTICard.IntRef rcvcount,BTICard.IntRef xmtcount,int handleval);
	public static native long ChGetInfo(short infotype,int channum,int handleval);
	public static native boolean ChIs429(int channum,int handleval);
	public static native boolean ChIsRcv(int channum,int handleval);
	public static native boolean ChIsXmt(int channum,int handleval);
	public static native void ChPause(int channum,int handleval);
	public static native int ChPauseCheck(int channum,int handleval);
	public static native void ChResume(int channum,int handleval);
	public static native boolean ChStart(int channum,int handleval);
	public static native boolean ChStop(int channum,int handleval);
	public static native int ChSyncDefine(boolean enableflag,short syncmask,short pinpolarity,int channum,int handleval);
	public static native int ChTriggerDefine(boolean enableflag,short trigmask,short trigval,short pinpolarity,int channum,int handleval);
	public static native int CmdAddr(int index,int channum,int handleval);
	public static native int CmdCountRd(int channum,int handleval);
	public static native int CmdRd(char[] block,int channum,int handleval);
	public static native int FilterClear(int baseaddr,int handleval);
	public static native int FilterDefault(int configval,int channum,int handleval);
	public static native int FilterRd(int labelval,int sdival,int channum,int handleval);
	public static native int FilterSet(int configval,int labelval,short sdimask,int channum,int handleval);
	public static native int FilterWr(int msgaddr,int labelval,int sdival,int channum,int handleval);
	public static native long FldGetData(long msgval);
	public static native short FldGetLabel(long msgval);
	public static native short FldGetParity(long msgval);
	public static native short FldGetSDI(long msgval);
	public static native long FldGetValue(long msgval,short startbit,short endbit);
	public static native long FldPutData(long msgval,long data);
	public static native long FldPutLabel(long msgval,short label);
	public static native long FldPutSDI(long msgval,short sdi);
	public static native long FldPutValue(long msgval,long dataval,short startbit,short endbit);
	public static native int ListAsyncCreate(int listconfigval,int count,int channum,int handleval);
	public static native long ListDataRd(int listaddr,int handleval);
	public static native boolean ListDataWr(long value,int listaddr,int handleval);
	public static native int ListRcvCreate(int listconfigval,int count,int msgaddr,int handleval);
	public static native int ListStatus(int listaddr,int handleval);
	public static native int ListXmtCreate(int listconfigval,int count,int msgaddr,int handleval);
	public static native int MsgBlockRd(MSGFIELDS429 msgfields,int msgaddr,int handleval);
	public static native int MsgBlockWr(MSGFIELDS429 msgfields,int msgaddr,int handleval);
	public static native int MsgCreate(int configval,int handleval);
	public static native long MsgDataRd(int msgaddr,int handleval);
	public static native void MsgDataWr(long value,int msgaddr,int handleval);
	public static native void MsgGroupRd(int[] msgdataptr,int[] msgaddrptr,int nummsgs,int handleval);
	public static native void MsgGroupWr(int[] msgdataptr,int[] msgaddrptr,int nummsgs,int handleval);
	public static native boolean MsgIsAccessed(int msgaddr,int handleval);
	public static native boolean MsgSkipRd(int msgaddr,int handleval);
	public static native void MsgSkipWr(boolean skip,int msgaddr,int handleval);
	public static native int MsgSyncDefine(boolean enableflag,char syncmask,char pinpolarity,int msgaddr,int handleval);
	public static native int MsgTriggerDefine(boolean enableflag,char trigmask,char trigval,char pinpolarity,int msgaddr,int handleval);
	public static native int ParamAmplitudeConfig(int configval,int dacval,int channum,int handleval);
	public static native int ParamAmplitudeGet(BTICard.IntRef dacval,int channum,int handleval);
	public static native int ParamBitRateConfig(int configval,int divval,int channum,int handleval);
	public static native int ParamBitRateGet(BTICard.IntRef divval,int channum,int handleval);
	public static native int SchedBranch(int condition,int destindex,int channum,int handleval);
	public static native int SchedBranchUpdate(int destindex,int opcodeindex,int channum,int handleval);
	public static native int SchedBuild(int nummsgs,int[] msgaddr,int[] minperiod,int[] maxperiod,int channum,int handleval);
	public static native int SchedCall(int condition,int destindex,int channum,int handleval);
	public static native int SchedCallUpdate(int destindex,int opcodeindex,int channum,int handleval);
	public static native int SchedMode(int modeval);
	public static native int SchedEntry(int channum,int handleval);
	public static native int SchedGap(int gapval,int channum,int handleval);
	public static native int SchedGapFixed(int gapval,int channum,int handleval);
	public static native int SchedGapList(int gapval,int listaddr,int channum,int handleval);
	public static native int SchedHalt(int channum,int handleval);
	public static native int SchedLog(int condition,char tagval,int channum,int handleval);
	public static native int SchedMsg(int msgaddr,int channum,int handleval);
	public static native int SchedMsgEx(int msgaddr,int gapval,int channum,int handleval);
	public static native int SchedPause(int channum,int handleval);
	public static native int SchedPulse(int dionum,int channum,int handleval);
	public static native int SchedRestart(int channum,int handleval);
	public static native int SchedReturn(int channum,int handleval);	

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
    public static final int	CH8                    = 0x0008;          //Channel 8
    public static final int	CH9	                   = 0x0009;          //Channel 9
    public static final int	CH10 	               = 0x000A;          //Channel 10
    public static final int	CH11 	               = 0x000B;          //Channel 11
    public static final int	CH12 	               = 0x000C;          //Channel 12
    public static final int	CH13 	               = 0x000D;          //Channel 13
    public static final int	CH14 	               = 0x000E;          //Channel 14
    public static final int	CH15 	               = 0x000F;          //Channel 15
    public static final int	CH16 	               = 0x0010;          //Channel 16
    public static final int	CH17 	               = 0x0011;          //Channel 17
    public static final int	CH18 	               = 0x0012;          //Channel 18
    public static final int	CH19 	               = 0x0013;          //Channel 19
    public static final int	CH20 	               = 0x0014;          //Channel 20
    public static final int	CH21 	               = 0x0015;          //Channel 21
    public static final int	CH22 	               = 0x0016;          //Channel 22
    public static final int	CH23 	               = 0x0017;          //Channel 23
    public static final int	CH24 	               = 0x0018;          //Channel 24
    public static final int	CH25 	               = 0x0019;          //Channel 25
    public static final int	CH26 	               = 0x001A;          //Channel 26
    public static final int	CH27 	               = 0x001B;          //Channel 27
    public static final int	CH28 	               = 0x001C;          //Channel 28
    public static final int	CH29 	               = 0x001D;          //Channel 29
    public static final int	CH30 	               = 0x001E;          //Channel 30
    public static final int	CH31 	               = 0x001F;          //Channel 31  
    
	/**
	*
	*  SDI selection constants
	*
	**/

    public static final short SDI00                 = 0x0001;          //Enable SDI00
    public static final short SDI01                 = 0x0002;          //Enable SDI01
    public static final short SDI10                 = 0x0004;          //Enable SDI10
    public static final short SDI11                 = 0x0008;          //Enable SDI11
    public static final short SDIALL                = 0x000F;          //Enable all SDIs
    
    /**
    *
    *  Channel configuration options
    *
    **/

    public static final int CHCFG429_DEFAULT      = 0x00000000;       //Select all default settings (XMT & RCV) (default)
    public static final int CHCFG429_HIGHSPEED    = 0x00000001;       //Select high speed (XMT & RCV)
    public static final int CHCFG429_AUTOSPEED    = 0x00000002;       //Select auto speed detection (RCV)
    public static final int CHCFG429_LOWSPEED     = 0x00000000;       //Select low speed (XMT & RCV) (default)
    public static final int CHCFG429_SELFTEST     = 0x00000004;       //Enable internal wraparound (XMT & RCV)
    public static final int CHCFG429_SELFTESTOFF  = 0x00000000;       //Disable internal wraparound (XMT & RCV) (default)
    public static final int CHCFG429_SYNC         = 0x00000008;       //Sync Enable (XMT & RCV)
    public static final int CHCFG429_SYNCOFF      = 0x00000000;       //Disable sync output (XMT & RCV) (default)
    public static final int CHCFG429_PARODD       = 0x00000000;       //Parity odd (XMT & RCV) (default)
    public static final int CHCFG429_PAREVEN      = 0x00000010;       //Parity even (XMT & RCV)
    public static final int CHCFG429_PARDATA      = 0x00000020;       //Parity bit as data (XMT & RCV)
    public static final int CHCFG429_ACTIVE       = 0x00000000;       //Enable channel activity (XMT & RCV) (default)
    public static final int CHCFG429_INACTIVE     = 0x00000040;       //Disable channel activity (XMT & RCV)
    public static final int CHCFG429_EXTTRIG      = 0x00000080;       //Enable external trigger for all messages (XMT)
    public static final int CHCFG429_EXTOFF       = 0x00000000;       //External trigger is enabled on message level (XMT) (default)
    public static final int CHCFG429_PARERR       = 0x00000100;       //Enable parity error for all messages (XMT)
    public static final int CHCFG429_NOERR        = 0x00000000;       //Errors are enabled on message level (XMT) (default)
    public static final int CHCFG429_HIT          = 0x00000200;       //Hit counter is enabled for all messages
    public static final int CHCFG429_NOHIT        = 0x00000000;       //Hit counter is enabled on message level (default)
    public static final int CHCFG429_TIMETAG      = 0x00000400;       //Enable time-tag for all message records
    public static final int CHCFG429_TIMETAGOFF   = 0x00000000;       //Time-tag is enabled on message level (default)
    public static final int CHCFG429_ELAPSE       = 0x00000800;       //Enable elapse time for all messages
    public static final int CHCFG429_ELAPSEOFF    = 0x00000000;       //Elapse time is enabled on message level (default)
    public static final int CHCFG429_MAX          = 0x00001000;       //Enable max repetition rate monitoring for all messages
    public static final int CHCFG429_MIN          = 0x00002000;       //Enable min repetition rate monitoring for all messages
    public static final int CHCFG429_MAXMIN       = 0x00003000;       //Enable max and min repetition rate monitoring for all messages
    public static final int CHCFG429_MAXMINOFF    = 0x00000000;       //Repetition rate monitoring is enabled on message level (default)
    public static final int CHCFG429_SEQALL       = 0x00080000;       //Record entire channel in sequential record
    public static final int CHCFG429_SEQSEL       = 0x00000000;       //Sequential record recording is enabled at message level (default)
    public static final int CHCFG429_LOOPMAX      = 0x00100000;       //Enable schedule maximum loop count
    public static final int CHCFG429_NOLOOPMAX    = 0x00000000;       //Disable schedule maximum loop count (default)
    public static final int CHCFG429_LOGHALT      = 0x00200000;       //Enable event log on schedule halt
    public static final int CHCFG429_NOLOGHALT    = 0x00000000;       //No event log on schedule halt (default)
    public static final int CHCFG429_LOGPAUSE     = 0x00400000;       //Enable event log on schedule pause
    public static final int CHCFG429_NOLOGPAUSE   = 0x00000000;       //No event log on schedule pause (default)
    public static final int CHCFG429_LOGERR       = 0x00800000;       //Enable event log on decoder errors.
    public static final int CHCFG429_NOLOGERR     = 0x00000000;       //No event log on decoder errors (default)
    public static final int CHCFG429_PAUSE        = 0x01000000;       //Mark channel as paused
    public static final int CHCFG429_UNPAUSE      = 0x00000000;       //Mark channel as unpaused (default)

    /**
    *
    *  Message configuration options
    *
    **/

    public static final int MSGCRT429_DEFAULT     = 0x00000000;       //Default settings
    public static final int MSGCRT429_NOSEQ       = 0x00000000;       //Message will not be recorded in sequential record (default)
    public static final int MSGCRT429_SEQ         = 0x00000001;       //Message will be recorded in sequential record
    public static final int MSGCRT429_NOLOG       = 0x00000000;       //Message will not generate event log (default)
    public static final int MSGCRT429_LOG         = 0x00000002;       //Message will generate event log
    public static final int MSGCRT429_NOSKIP      = 0x00000000;       //Message will not be skipped (default)
    public static final int MSGCRT429_SKIP        = 0x00000008;       //Message will be skipped
    public static final int MSGCRT429_NOTIMETAG   = 0x00000000;       //Message will not record time-tag (default)
    public static final int MSGCRT429_TIMETAG     = 0x00000010;       //Message will record time-tag
    public static final int MSGCRT429_NOELAPSE    = 0x00000000;       //Message will not record elapse time (default)
    public static final int MSGCRT429_ELAPSE      = 0x00000020;       //Message will record elapse time
    public static final int MSGCRT429_NOMAXMIN    = 0x00000000;       //Message will not record min/max time (default)
    public static final int MSGCRT429_MAX         = 0x00000040;       //Message will record max time
    public static final int MSGCRT429_MIN         = 0x00000080;       //Message will record min time
    public static final int MSGCRT429_MAXMIN      = 0x000000C0;       //Message will record min/max time
    public static final int MSGCRT429_NOSYNC      = 0x00000000;       //No sync will be generated for message (default)
    public static final int MSGCRT429_SYNC        = 0x00000100;       //Sync will be generated for message
    public static final int MSGCRT429_NOERR       = 0x00000000;       //No error will be generated for message (default)
    public static final int MSGCRT429_PARERR      = 0x00000200;       //Parity error will be generated for message
    public static final int MSGCRT429_NOHIT       = 0x00000000;       //Message will not record hit count (default)
    public static final int MSGCRT429_HIT         = 0x00000400;       //Message will record hit count
    public static final int MSGCRT429_NOEXTRIG    = 0x00000000;       //Message will not be externally triggered (default)
    public static final int MSGCRT429_EXTRIG      = 0x00001000;       //Message will be externally triggered
    public static final int MSGCRT429_WIPE        = 0x00000000;       //Enables message clear (default)
    public static final int MSGCRT429_NOWIPE      = 0x80000000;       //Disables message clear
    public static final int MSGCRT429_WIPE0       = 0x00000000;       //Initialize data with zeros (default)
    public static final int MSGCRT429_WIPE1       = 0x40000000;       //Initialize data with ones

    /**
    *
    *  List buffer options
    *
    **/

    public static final int LISTCRT429_DEFAULT    = 0x00000000;       //Select all default settings
    public static final int LISTCRT429_FIFO       = 0x00000000;       //Enable FIFO mode (default)
    public static final int LISTCRT429_PINGPONG   = 0x00000001;       //Enable ping-pong mode
    public static final int LISTCRT429_CIRCULAR   = 0x00000002;       //Enable circular mode
    public static final int LISTCRT429_RCV        = 0x00000010;       //User will read from list buffer
    public static final int LISTCRT429_XMT        = 0x00000020;       //User will write to list buffer
    public static final int LISTCRT429_ASYNC      = 0x00000040;       //Asynchronous mode
    public static final int LISTCRT429_NOLOG      = 0x00000000;       //Do not generate event log when list buffer empty/full (default)
    public static final int LISTCRT429_LOG        = 0x00000100;       //Generate event log when list buffer empty/full

    /**
    *
    *  Parametric configuration options
    *
    **/

    public static final int PARAMCFG429_DEFAULT    = 0x00000000;      //Select all default settings (default)
    public static final int PARAMCFG429_AMPLON     = 0x00000000;      //Enables parametric amplitude control (default)
    public static final int PARAMCFG429_AMPLOFF    = 0x00000001;      //Disables parametric amplitude control
    public static final int PARAMCFG429_BITRATEON  = 0x00000000;      //Enables parametric bit rate control (default)
    public static final int PARAMCFG429_BITRATEOFF = 0x00000002;      //Disables parametric bit rate control

    /**
    *
    *  Scheduling conditions.
    *
    **/

    public static final int COND429_ALWAYS        = 0x00000000;       //Unconditional
    public static final int COND429_DIO1ACT       = 0x00000001;       //Condition on digital I/O #1 active
    public static final int COND429_DIO1NACT      = 0x00000002;       //Condition on digital I/O #1 not active
    public static final int COND429_DIO2ACT       = 0x00000004;       //Condition on digital I/O #2 active
    public static final int COND429_DIO2NACT      = 0x00000008;       //Condition on digital I/O #2 not active
    public static final int COND429_DIO3ACT       = 0x00000010;       //Condition on digital I/O #3 active
    public static final int COND429_DIO3NACT      = 0x00000020;       //Condition on digital I/O #3 not active
    public static final int COND429_DIO4ACT       = 0x00000040;       //Condition on digital I/O #4 active
    public static final int COND429_DIO4NACT      = 0x00000080;       //Condition on digital I/O #4 not active
    public static final int COND429_DIO5ACT       = 0x00000100;       //Condition on digital I/O #5 active
    public static final int COND429_DIO5NACT      = 0x00000200;       //Condition on digital I/O #5 not active
    public static final int COND429_DIO6ACT       = 0x00000400;       //Condition on digital I/O #6 active
    public static final int COND429_DIO6NACT      = 0x00000800;       //Condition on digital I/O #6 not active
    public static final int COND429_DIO7ACT       = 0x00001000;       //Condition on digital I/O #7 active
    public static final int COND429_DIO7NACT      = 0x00002000;       //Condition on digital I/O #7 not active
    public static final int COND429_DIO8ACT       = 0x00004000;       //Condition on digital I/O #8 active
    public static final int COND429_DIO8NACT      = 0x00008000;       //Condition on digital I/O #8 not active

    /**
    *
    *  Bit fields of the message activity flag.
    *
    **/

    public static final char MSGACT429_CHMASK      = 0xFF00;           //Channel number mask value
    public static final char MSGACT429_CHSHIFT     = 0x0008;           //Channel number shift value
    public static final char MSGACT429_SPD         = 0x0080;           //Bus speed
    public static final char MSGACT429_ERR         = 0x0040;           //Error bit
    public static final char MSGACT429_GAP         = 0x0020;           //Gap error bit
    public static final char MSGACT429_PAR         = 0x0010;           //Parity error bit
    public static final char MSGACT429_LONG        = 0x0008;           //Long word error bit
    public static final char MSGACT429_BIT         = 0x0004;           //Bit time error bit
    public static final char MSGACT429_TO          = 0x0002;           //Time out error bit
    public static final char MSGACT429_HIT         = 0x0001;           //Always set

    /**
    *
    *  Channel info fields.
    *
    **/

    public static final char INFO429_PARAM         = 0x0001;           //Channel supports parametric control

    /**
    *
    *  Scheduling algorithm options
    *
    **/

    public static final char SCHEDMODE_DEFAULT        = 0x0000;         //Select all default settings
    public static final char SCHEDMODE_METHOD_NORMAL  = 0x0000;         //Choose the normal scheduling method
    public static final char SCHEDMODE_METHOD_QUICK   = 0x0001;         //Choose the quick scheduling method
    public static final char SCHEDMODE_METHOD_BOTH    = 0x0002;         //Use the quick method first, if fail, then use the normal method
    public static final char SCHEDMODE_METHOD_MASK    = 0x000F;         //Mask for method setting
    public static final char SCHEDMODE_MILLISEC       = 0x0000;         //Specify periods in milliseconds
    public static final char SCHEDMODE_MICROSEC       = 0x0010;         //Specify periods in microseconds
    public static final char SCHEDMODE_REMOTE         = 0x0000;         //Perform calculations remotely, if applicable
    public static final char SCHEDMODE_LOCAL          = 0x0020;         //Perform calculations locally, if applicable

    //Deprecated options
    public static final char SCHEDMODE_DEFAULT_ALGOR  = 0x0000;         //Choose the default algorithm
    public static final char SCHEDMODE_QUICK_ALGOR    = 0x0001;         //Choose the quick algorithm
    public static final char SCHEDMODE_BOTH_ALGOR     = 0x0002;         //Use the quick algorithm first, if fail, then use the normal algorithm
    public static final char SCHEDMODE_ALGOR_MASK     = 0x000F;         //Mask for algorithm setting   
}
