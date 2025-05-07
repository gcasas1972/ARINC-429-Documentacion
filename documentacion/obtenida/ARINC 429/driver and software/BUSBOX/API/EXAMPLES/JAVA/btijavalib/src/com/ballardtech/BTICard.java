package com.ballardtech;

public final class BTICard
{
	static
	{
		try
		{
			if (System.getProperty("sun.arch.data.model").equals("64"))
				System.loadLibrary("bticard64");
			else
				System.loadLibrary("bticard");
				
	        System.loadLibrary("bticardg");
		}
		catch (UnsatisfiedLinkError rule)
		{
			// TODO Auto-generated catch block
			rule.printStackTrace();
		}
	}

	public static class StringRef
	{
	    public StringRef() { this.value = ""; }
	    public String getValue() { return value; }
	    public void setValue(String value) { this.value = value; }
	
	    private String value;
	}
	
	public static class LongRef
	{
	    public LongRef() { this.value = 0; }
	    public long getValue() { return value; }
	    public void setValue(long value) { this.value = value; }
	
	    private long value;
	}
	
	public static class IntRef
	{
	    public IntRef() { this.value = 0; }
	    public int getValue() { return value; }
	    public void setValue(int value) { this.value = value; }
	
	    private int value;
	}
	
	public static class ShortRef
	{
	    public ShortRef() { this.value = 0; }
	    public short getValue() { return value; }
	    public void setValue(short value) { this.value = value; }
	
	    private short value;
	}

	public static class CharRef
	{
	    public CharRef() { this.value = 0; }
	    public char getValue() { return value; }
	    public void setValue(char value) { this.value = value; }
	
	    private char value;
	}
	
	public static class BooleanRef
	{
	    public BooleanRef() { this.value = false; }
	    public boolean getValue() { return value; }
	    public void setValue(boolean value) { this.value = value; }
	
	    private boolean value;
	}	
	
	public static final class SEQRECORD1553 implements Cloneable
	{
		public char type = 0;               //Valid in all versions
		public int count = 0;               //Valid in all versions
		public long timestamp = 0;          //Valid in all versions
		public char activity = 0;           //Valid in all versions
		public char error = 0;              //Valid in all versions
		public char cwd1 = 0;               //Valid in all versions
		public char cwd2 = 0;               //Valid in all versions
		public char swd1 = 0;               //Valid in all versions
		public char swd2 = 0;               //Valid in all versions
		public int datacount = 0;          	//Valid in all versions
		public char[] data = new char[40];  //Variable length (don't exceed data[datacount-1])
	}	
	
	public static final class SEQRECORDMORE1553 implements Cloneable
	{
		public long timestamph = 0;         //Valid if version of base record (SEQRECORD1553) >= 1
		public int resptime1 = 0;           //Valid if version of base record (SEQRECORD1553) >= 1
		public int resptime2 = 0;           //Valid if version of base record (SEQRECORD1553) >= 1
	}
	
	public static final class SEQRECORD429 implements Cloneable
	{
		public char type = 0;               //Valid in all versions
		public int count = 0;               //Valid in all versions
		public long timestamp = 0;          //Valid in all versions
		public char activity = 0;           //Valid in all versions
		public int decgap = 0;              //Valid if version >= 1
		public long data = 0;               //Valid in all versions
		public long timestamph = 0;         //Valid if version >= 1
	}
	
	public static final class SEQFINDINFO implements Cloneable
	{
		public int pRecFirst = 0;
		public int pRecNext = 0;
		public int pRecLast = 0;
	}
	
	public static final class BTIIRIGTIME implements Cloneable
	{
		public int days;
		public int hours;
		public int min;
		public int sec;
		public int msec;
		public int usec;
	}
	
    public static native int CardClose(int handleval);
    public static native boolean CardIsRunning(int handleval);
    public static native int CardOpen(IntRef lpHandle, int cardnum);
    public static native String CardProductStr(int handleval);
    public static native void CardReset(int handleval);
    public static native int CardResume(int handleval);
    public static native int CardStart(int handleval);
    public static native boolean CardStop(int handleval);
    public static native int CardTest(int level, int handleval);
    public static native void CardTrigger(int handleval);
    public static native void CardTriggerEx(char trigmask, int handleval);
    public static native String CardTypeStr(int handleval);
    public static native int CoreOpen(IntRef lphCore, int corenum, int hCard);
    public static native String ErrDescStr(int errval, int handleval);
    public static native int EventLogConfig(char configval, int count, int handleval);
    public static native int EventLogRd(CharRef typeval, LongRef infoval, IntRef channel, int handleval);
    public static native int EventLogStatus(int handleval);
    public static native int ExtDIOMonConfig(char rise_edge, char fall_edge, int banknum, int handleval);
    public static native boolean ExtDIORd(int dionum, int handleval);
    public static native void ExtDIOWr(int dionum, boolean dioval, int handleval);
    public static native boolean ExtLEDRd(int handleval);
    public static native void ExtLEDWr(boolean ledval, int handleval);
    public static native void ExtStatusLEDRd(BooleanRef ledon, BooleanRef ledcolor, int handleval);
    public static native void ExtStatusLEDWr(boolean ledon, boolean ledcolor, int handleval);
    public static native int IRIGConfig(long configval, int handleval);
    public static native long IRIGFieldGetDays(long irigvalh, long irigvall);
    public static native long IRIGFieldGetHours(long irigvalh, long irigvall);
    public static native long IRIGFieldGetMicrosec(long irigvalh, long irigvall);
    public static native long IRIGFieldGetMillisec(long irigvalh, long irigvall);
    public static native long IRIGFieldGetMin(long irigvalh, long irigvall);
    public static native long IRIGFieldGetSec(long irigvalh, long irigvall);
    public static native void IRIGFieldPutDays(long value, LongRef irigvalh, LongRef irigvall);
    public static native void IRIGFieldPutHours(long value, LongRef irigvalh, LongRef irigvall);
    public static native void IRIGFieldPutMicrosec(long value, LongRef irigvalh, LongRef irigvall);
    public static native void IRIGFieldPutMillisec(long value, LongRef irigvalh, LongRef irigvall);
    public static native void IRIGFieldPutMin(long value, LongRef irigvalh, LongRef irigvall);
    public static native void IRIGFieldPutSec(long value, LongRef irigvalh, LongRef irigvall);
    public static native int IRIGInputThresholdGet(CharRef dacval, int handleval);
    public static native int IRIGInputThresholdSet(char dacval, int handleval);
    public static native int IRIGRd(BTIIRIGTIME irigtime, int handleval);   
    public static native boolean IRIGSyncStatus(int handleval);
    public static native void IRIGTimeBCDToBin(LongRef timevalh, LongRef timevall, long irigvalh, long irigvall);
    public static native void IRIGTimeBinToBCD(LongRef irigvalh, LongRef irigvall, long timevalh, long timevall);
    public static native int IRIGWr(BTIIRIGTIME irigtime, int handleval);
    public static native long MakeLong(char valh, char vall);
    public static native char MakeWord(byte valh, byte vall);    
    public static native long SeqBlkRd(char[] buf, int bufcount, LongRef blkcnt, int handleval);
    public static native int SeqCommRd(char[] buf, int bufcount, int handleval);
    public static native int SeqConfig(long configval, int handleval);
    public static native long SeqDMARd(char[] buf, long bufcount, int handleval);
    public static native boolean SeqFindCheckVersion(char[] pRecord, char version);
    public static native int SeqFindInit(char[] seqbuf, long seqbufsize, SEQFINDINFO sfinfo);
    public static native int SeqFindMore1553(SEQRECORDMORE1553 pRecMore, SEQRECORD1553 pRecBase);
    public static native int SeqFindNext1553(SEQRECORD1553 pRecord, SEQFINDINFO sfinfo);
    public static native int SeqFindNext429(SEQRECORD429 pRecord, SEQFINDINFO sfinfo);
    public static native int SeqFindNextEx(char[] pRecord, int recordcount, CharRef seqtype, SEQFINDINFO sfinfo);
    public static native int SeqInterval(int interval, int mode, int handleval);
    public static native boolean SeqIsRunning(int handleval);
    public static native int SeqLogFrequency(int logfreq, int handleval);
    public static native int SeqRdEx(char[] buf, int bufcount, int handleval);
    public static native boolean SeqResume(int handleval);
    public static native boolean SeqStart(int handleval);
    public static native boolean SeqStatus(int handleval);
    public static native boolean SeqStop(int handleval);
    public static native int Timer64Rd(LongRef valueh, LongRef valuel, int handleval);
    public static native void Timer64Wr(long valueh, long valuel, int handleval);
    public static native void TimerClear(int handleval);
    public static native long TimerRd(int handleval);
    public static native int TimerResolution(int timerresol, int handleval);
    public static native long TimerStatus(int handleval);
    public static native void TimerWr(long value, int handleval);
    public static native long ValFromAscii(String asciistr, int radixval);
    public static native long ValGetBits(int oldvalue, int startbit, int endbit);
    public static native long ValPutBits(int oldvalue, int newfld, int startbit, int endbit);
    public static native String ValToAscii(long value, StringRef asciistr, int numbits, int radixval);
    
    public static native int BJTestAssoc(int fd, String devicename);
	
	/**
	*
	*  Sequential Record configuration options
	*
	**/
	
	public static final int SEQCFG_DEFAULT     = 0x00000000;            //Select all default settings
	public static final int SEQCFG_FILLHALT    = 0x00000000;            //Enable sequential record in fill and halt mode (default)
	public static final int SEQCFG_DISABLE     = 0x00000001;            //Disable sequential record
	public static final int SEQCFG_CONTINUOUS  = 0x00000002;            //Enable sequential record in continuous mode
	public static final int SEQCFG_DMA         = 0x00000004;            //Enable monitor in dma mode
	public static final int SEQCFG_FREE        = 0x00000008;            //Enable sequential record in free mode
	public static final int SEQCFG_DELTA       = 0x00000010;            //Enable sequential record in delta mode
	public static final int SEQCFG_INTERVAL    = 0x00000020;            //Enable sequential record in interval mode
	public static final int SEQCFG_NOLOGFULL   = 0x00000000;            //Do not generate event log when sequential record is full (default)
	public static final int SEQCFG_LOGFULL     = 0x00001000;            //Generate event log when sequential record is full
	public static final int SEQCFG_NOLOGFREQ   = 0x00000000;            //Do not generate event logs at a user specified frequency (default)
	public static final int SEQCFG_LOGFREQ     = 0x00002000;            //Generate event logs at user specified frequency
	public static final int SEQCFG_16K         = 0x00000000;            //Allocate a 16K sequential record buffer (default)
	public static final int SEQCFG_ALLAVAIL    = 0x01000000;            //Allocate all available memory to a sequential record buffer
	public static final int SEQCFG_32K         = 0x02000000;            //Allocate a 32K sequential record buffer
	public static final int SEQCFG_64K         = 0x04000000;            //Allocate a 64K sequential record buffer
	public static final int SEQCFG_128K        = 0x08000000;            //Allocate a 128K sequential record buffer	


	/**
	*
	*  Sequential Record type fields
	*
	**/

	public static final char SEQTYPE_MASK       = 0x00FF;               //Sequential record type mask value
	public static final char SEQTYPE_429        = 0x0001;               //Sequential record type is ARINC 429
	public static final char SEQTYPE_717        = 0x0002;               //Sequential record type is ARINC 717
	public static final char SEQTYPE_1553       = 0x0003;               //Sequential record type is MIL-STD-1553
	public static final char SEQTYPE_708        = 0x0004;               //Sequential record type is ARINC 708
	public static final char SEQTYPE_USER       = 0x0005;               //Sequential record type is User Defined
	public static final char SEQTYPE_CSDB       = 0x0006;               //Sequential record type is CSDB
	public static final char SEQTYPE_DIO        = 0x0007;               //Sequential record type is DIO
	public static final char SEQTYPE_RESTART    = 0x00FF;               //Sequential record type is Restart

/**
*
*  Sequential Record version fields
*
**/

	public static final char SEQVER_MASK        = 0xFF00;               //Sequential record version mask value
	public static final char SEQVER_0           = 0x0000;               //Sequential record version number is 0
	public static final char SEQVER_1           = 0x0100;               //Sequential record version number is 1

/**
*
*  Event log list configuration options
*
**/

	public static final char LOGCFG_DEFAULT     = 0x0000;               //Select all default settings
	public static final char LOGCFG_ENABLE      = 0x0000;               //Enable event log list (default)
	public static final char LOGCFG_DISABLE     = 0x0001;               //Disable event log list

/**
*
*  IRIG timer configuration options
*
**/

	public static final int IRIGCFG_DEFAULT    = 0x00000000;            //Select all default settings
	public static final int IRIGCFG_ENABLE     = 0x00000000;            //Enable IRIG timer (default)
	public static final int IRIGCFG_DISABLE    = 0x00000001;            //Disable IRIG timer
	public static final int IRIGCFG_SPEEDB     = 0x00000000;            //Bit rate is IRIGB (default)
	public static final int IRIGCFG_SPEEDA     = 0x00000002;            //Bit rate is IRIGA
	public static final int IRIGCFG_INTERNAL   = 0x00000000;            //IRIG timer operates internally (default)
	public static final int IRIGCFG_EXTERNAL   = 0x00000004;            //IRIG timer operates externally
	public static final int IRIGCFG_SLAVE      = 0x00000000;            //IRIG timer is a slave  / receiver (default)
	public static final int IRIGCFG_MASTER     = 0x00000008;            //IRIG timer is a master / transmitter
	public static final int IRIGCFG_PPS        = 0x00000010;            //IRIG timer operates in PPS mode (rcv/xmt)
	public static final int IRIGCFG_PWM        = 0x00000000;            //IRIG timer uses pulse width modulated signaling (rcv/xmt) (default)
	public static final int IRIGCFG_AM         = 0x00000020;            //IRIG timer uses amplitude modulated signaling (rcv only, hw dependant)

/**
*
*  IRIG timer field definitions
*
**/

	public static final char IRIGFIELD_USECLSB  = 0x0000;               //Microseconds LSB in timestamp field
	public static final char IRIGFIELD_USECMSB  = 0x000B;               //Microseconds MSB in timestamp field
	public static final char IRIGFIELD_MSECLSB  = 0x000C;               //Milliseconds LSB in timestamp field
	public static final char IRIGFIELD_MSECMSB  = 0x0017;               //Milliseconds MSB in timestamp field
	public static final char IRIGFIELD_SECLSB   = 0x0018;               //Seconds LSB in timestamp field
	public static final char IRIGFIELD_SECMSB   = 0x001F;               //Seconds MSB in timestamp field

	public static final char IRIGFIELD_MINLSB   = 0x0000;               //Minutes LSB in timestamph field
	public static final char IRIGFIELD_MINMSB   = 0x0007;               //Minutes MSB in timestamph field
	public static final char IRIGFIELD_HRSLSB   = 0x0008;               //Hours LSB in timestamph field
	public static final char IRIGFIELD_HRSMSB   = 0x000F;               //Hours MSB in timestamph field
	public static final char IRIGFIELD_DAYLSB   = 0x0010;               //Days LSB in timestamph field
	public static final char IRIGFIELD_DAYMSB   = 0x001B;               //Days MSB in timestamph field

/**
*
*  Event types.
*
**/

	public static final char EVENTTYPE_1553MSG    = 0x0001;             //MIL-STD-1553 message
	public static final char EVENTTYPE_1553OPCODE = 0x0002;             //MIL-STD-1553 event log opcode
	public static final char EVENTTYPE_1553HALT   = 0x0003;             //MIL-STD-1553 schedule halt
	public static final char EVENTTYPE_1553PAUSE  = 0x0004;             //MIL-STD-1553 schedule pause
	public static final char EVENTTYPE_1553LIST   = 0x0005;             //MIL-STD-1553 list buffer empty/full
	public static final char EVENTTYPE_1553SERIAL = 0x0006;             //MIL-STD-1553 serial empty

	public static final char EVENTTYPE_429MSG     = 0x0011;             //ARINC 429 message
	public static final char EVENTTYPE_429OPCODE  = 0x0012;             //ARINC 429 event log opcode
	public static final char EVENTTYPE_429HALT    = 0x0013;             //ARINC 429 schedule halt
	public static final char EVENTTYPE_429PAUSE   = 0x0014;             //ARINC 429 schedule pause
	public static final char EVENTTYPE_429LIST    = 0x0015;             //ARINC 429 list buffer empty/full
	public static final char EVENTTYPE_429ERR     = 0x0016;             //ARINC 429 decoder error detected

	public static final char EVENTTYPE_717WORD    = 0x0021;             //ARINC 717 word received
	public static final char EVENTTYPE_717SUBFRM  = 0x0022;             //ARINC 717 sub frame completed
	public static final char EVENTTYPE_717SYNCERR = 0x0023;             //ARINC 717 receive channel lost synchronization

	public static final char EVENTTYPE_708MSG     = 0x0031;             //ARINC 708 message

	public static final char EVENTTYPE_SEQFULL    = 0x0041;             //Sequential record full
	public static final char EVENTTYPE_SEQFREQ    = 0x0042;             //Sequential record frequency

	public static final char EVENTTYPE_422TXTHRESHOLD  = 0x0051;        //RS-422 TX under threshold
	public static final char EVENTTYPE_422TXFIFO       = 0x0052;        //RS-422 TX underflow
	public static final char EVENTTYPE_422RXTHRESHOLD  = 0x0053;        //RS-422 RX over threshold
	public static final char EVENTTYPE_422RXFIFO       = 0x0054;        //RS-422 RX overflow
	public static final char EVENTTYPE_422RXERROR      = 0x0055;        //RS-422 RX error

	public static final char EVENTTYPE_CSDBMSG     = 0x0058;            //CSDB message
	public static final char EVENTTYPE_CSDBOPCODE  = 0x0059;            //CSDB event log opcode
	public static final char EVENTTYPE_CSDBHALT    = 0x005A;            //CSDB schedule halt
	public static final char EVENTTYPE_CSDBPAUSE   = 0x005B;            //CSDB schedule pause
	public static final char EVENTTYPE_CSDBLIST    = 0x005C;            //CSDB list buffer empty/full
	public static final char EVENTTYPE_CSDBERR     = 0x005D;            //CSDB decoder error detected
	public static final char EVENTTYPE_CSDBSYNCERR = 0x005E;            //CSDB receive channel lost synchronization

	public static final char EVENTTYPE_DIOEDGE     = 0x0060;            //DIO edge event
	public static final char EVENTTYPE_DIOFAULT    = 0x0061;            //DIO fault event

	public static final char EVENTTYPE_BITERROR    = 0x0071;            //Built-in Test error event

/**
*
*  Card Info types
*
**/

	public static final char INFOTYPE_PLAT      = 0x0001;               //Returns the platform type
	public static final char INFOTYPE_PROD      = 0x0002;               //Returns the product type
	public static final char INFOTYPE_GEN       = 0x0003;               //Returns the generation number
	public static final char INFOTYPE_1553COUNT = 0x0004;               //Returns the 1553 channel count
	public static final char INFOTYPE_1553SIZE  = 0x0005;               //Returns the 1553 channel size
	public static final char INFOTYPE_429COUNT  = 0x0006;               //Returns the 429 channel count
	public static final char INFOTYPE_429SIZE   = 0x0007;               //Returns the 429 channel size
	public static final char INFOTYPE_717COUNT  = 0x0008;               //Returns the 717 channel count
	public static final char INFOTYPE_717SIZE   = 0x0009;               //Returns the 717 channel size
	public static final char INFOTYPE_708COUNT  = 0x000A;               //Returns the 708 channel count
	public static final char INFOTYPE_708SIZE   = 0x000B;               //Returns the 708 channel size
	public static final char INFOTYPE_VERSION   = 0x000C;               //Returns the version number
	public static final char INFOTYPE_DATE      = 0x000D;               //Returns the version date
	public static final char INFOTYPE_CHINFO    = 0x000E;               //Returns the channel info
	public static final char INFOTYPE_422COUNT  = 0x000F;               //Returns the 422 port count
	public static final char INFOTYPE_422SIZE   = 0x0010;               //Returns the 422 port size
	public static final char INFOTYPE_CSDBCOUNT = 0x0011;               //Returns the CSDB channel count
	public static final char INFOTYPE_CSDBSIZE  = 0x0012;               //Returns the CSDB channel size
	public static final char INFOTYPE_DIOCOUNT  = 0x0013;               //Returns the DIO bank count
	public static final char INFOTYPE_DIOSIZE   = 0x0014;               //Returns the DIO bank size
	public static final char INFOTYPE_HWGEN     = 0x0015;               //Returns the Hardware Generation

/**
*
*  Trigger flags
*
**/

	public static final char TRIGMASK_TRIGA     = 0x0001;               //Selects trigger line A
	public static final char TRIGMASK_TRIGB     = 0x0002;               //Selects trigger line B
	public static final char TRIGMASK_TRIGC     = 0x0004;               //Selects trigger line C

	public static final char TRIGVAL_TRIGAOFF   = 0x0000;               //Tests for trigger line A inactive
	public static final char TRIGVAL_TRIGAON    = 0x0001;               //Tests for trigger line A active
	public static final char TRIGVAL_TRIGBOFF   = 0x0000;               //Tests for trigger line B inactive
	public static final char TRIGVAL_TRIGBON    = 0x0002;               //Tests for trigger line B active
	public static final char TRIGVAL_TRIGCOFF   = 0x0000;               //Tests for trigger line C inactive
	public static final char TRIGVAL_TRIGCON    = 0x0004;               //Tests for trigger line C active

	public static final char TRIGPOL_TRIGAL     = 0x0000;               //Sets active low polarity for trigger line A
	public static final char TRIGPOL_TRIGAH     = 0x0001;               //Sets active high polarity for trigger line A
	public static final char TRIGPOL_TRIGBL     = 0x0000;               //Sets active low polarity for trigger line B
	public static final char TRIGPOL_TRIGBH     = 0x0002;               //Sets active high polarity for trigger line B
	public static final char TRIGPOL_TRIGCL     = 0x0000;               //Sets active low polarity for trigger line C
	public static final char TRIGPOL_TRIGCH     = 0x0004;               //Sets active high polarity for trigger line C


/**
*
*  Sync flags
*
**/

	public static final char SYNCMASK_SYNCA     = 0x0001;               //Selects sync line A
	public static final char SYNCMASK_SYNCB     = 0x0002;               //Selects sync line B
	public static final char SYNCMASK_SYNCC     = 0x0004;               //Selects sync line C

	public static final char SYNCPOL_SYNCAL     = 0x0000;               //Sets active low polarity for sync line A
	public static final char SYNCPOL_SYNCAH     = 0x0001;               //Sets active high polarity for sync line A
	public static final char SYNCPOL_SYNCBL     = 0x0000;               //Sets active low polarity for sync line B
	public static final char SYNCPOL_SYNCBH     = 0x0002;               //Sets active high polarity for sync line B
	public static final char SYNCPOL_SYNCCL     = 0x0000;               //Sets active low polarity for sync line C
	public static final char SYNCPOL_SYNCCH     = 0x0004;               //Sets active high polarity for sync line C

/**
*
*  Timer resolutions.
*
**/

	public static final char TIMERRESOL_1US     = 1;                     //1us timer resolution, 1:11:34 range
	public static final char TIMERRESOL_16US    = 2;                     //16us timer resolution, 19:05:19 range
	public static final char TIMERRESOL_1024US  = 3;                     //1024us timer resolution, 50 day range

/**
*
*  Timer status.
*
**/

	public static final char TIMETAG_FORMAT_BIN = 0;                     //Timetag will be in binary format
	public static final char TIMETAG_FORMAT_BCD = 1;                     //Timetag will be in BCD format

/**
*
*  Interval calculation modes.
*
**/

	public static final char INTERVALMODE_CLOSEST  = 1;                  //Finds interval closest to value specified
	public static final char INTERVALMODE_LESS     = 2;                  //Finds closest interval less than value specified
	public static final char INTERVALMODE_GREATER  = 3;                  //Finds closest interval more than value specified

/**
*
*  Test flags.
*
**/

	public static final char TEST_LEVEL_0       = 0;                     //Test I/O interface
	public static final char TEST_LEVEL_1       = 1;                     //Test memory interface
	public static final char TEST_LEVEL_2       = 2;                     //Test communication process
	public static final char TEST_LEVEL_3       = 3;                     //Test bus transceiver

/**
*
*  Status flags.
*
**/

	public static final char STAT_EMPTY         = 0;                      //Buffer is empty
	public static final char STAT_PARTIAL       = 1;                      //Buffer is partially filled
	public static final char STAT_FULL          = 2;                      //Buffer is full
	public static final char STAT_OFF           = 3;                      //Buffer is off

/**
*
*  Other flags.
*
**/

	public static final boolean RCV     		= false;
	public static final boolean XMT    			= true;

/**
*
*  Error types.
*
**/

	public static final int ERR_NONE          =  0;                   	   //No error
	public static final int ERR_UNKNOWN       = -1;                        //An unexpected error occurred
	public static final int ERR_BADVER        = -2;                        //A bad version was encountered
	public static final int ERR_BADPTR        = -3;                        //A bad pointer was passed
	public static final int ERR_NOCORE        = -4;                        //The specified core number doesn't exist
	public static final int ERR_BADPARAMS     = -11;                       //CardOpen() called with bad parameters
	public static final int ERR_NOHANDLES     = -12;                       //CardOpen() already has allocated too many handles
	public static final int ERR_NOCARD        = -13;                       //CardOpen() could not find a L43 card at the specified address
	public static final int ERR_NOIO          = -14;                       //CardOpen() could not find the I/O ports
	public static final int ERR_NOMEM         = -15;                       //CardOpen() could not find the memory
	public static final int ERR_BAD16BIT      = -16;                       //Card is conflicting with another 16-bit card
	public static final int ERR_WRONGMODEL    = -17;                       //Card does not support this feature
	public static final int ERR_NOSEL         = -18;                       //CardOpen() could not allocate a memory selector
	public static final int ERR_LOCK          = -19;                       //The communication process is locked up
	public static final int ERR_TOOMANY       = -20;                       //Too many channels have been configured
	public static final int ERR_BADHANDLE     = -21;                       //A bad handle was specified
	public static final int ERR_GOODHANDLE    = -22;                       //The handle is still valid and should not be destroyed
	public static final int ERR_NOTCHAN       = -23;                       //Not a valid channel
	public static final int ERR_NOTXMT        = -24;                       //The Transmitter has not been configured
	public static final int ERR_NOTRCV        = -25;                       //The Receiver has not been configured
	public static final int ERR_NOTSEQ        = -26;                       //The Sequential Record has not been configured
	public static final int ERR_ALLOC         = -27;                       //There is not enough memory to allocate
	public static final int ERR_VXD           = -28;                       //An error occurred in the VXD
	public static final int ERR_BADLABEL      = -29;                       //The specified label value is not valid
	public static final int ERR_BADSDI        = -30;                       //The specified sdi value is not valid
	public static final int ERR_BADMSG        = -31;                       //The specified command block is not a message block
	public static final int ERR_BADSCHNDX     = -32;                       //Specified command index is out of range
	public static final int ERR_BUFSIZE       = -33;                       //Insufficient space in user buffer
	public static final int ERR_NOCONFIG      = -34;                       //The card has not been properly configured
	public static final int ERR_CONFLICTS     = -35;                       //Unable to resolve conflicts
	public static final int ERR_RANGE         = -36;                       //Schedule is out of range
	public static final int ERR_FACTOR        = -37;                       //A bad factor value was specified
	public static final int ERR_NOIOBOOT      = -40;                       //Could not talk to IO Boot port of DSP
	public static final int ERR_BOOTFULL      = -41;                       //No space to add boot code
	public static final int ERR_BOOTNUM       = -42;                       //There is no boot code with the specified number
	public static final int ERR_ACCESS        = -43;                       //Unable to write to access register
	public static final int ERR_ROMVERIFY     = -44;                       //Unable to verify the value written to the ROM
	public static final int ERR_COUNT         = -45;                       //An invalid count was specified
	public static final int ERR_CRC           = -46;                       //There was a bad checksum in the HEX file
	public static final int ERR_FNAME         = -47;                       //Bad filenames were specified
	public static final int ERR_FRDWR         = -48;                       //There was an error reading or writing the HEX file
	public static final int ERR_HEX           = -49;                       //There was a bad hex character in the HEX file
	public static final int ERR_INDEX         = -51;                       //The command block index was invalid or the schedule is full
	public static final int ERR_NOMSGS        = -52;                       //No messages specified
	public static final int ERR_TYPE          = -54;                       //There was a bad type value in the HEX file
	public static final int ERR_ZEROLEN       = -55;                       //Zero length was specified
	public static final int ERR_BADADDRESS    = -56;                       //A bad address was specified
	public static final int ERR_MSGNDX        = -57;                       //A bad message index was specified
	public static final int ERR_BADTA         = -60;                       //A bad terminal address was specified
	public static final int ERR_BADFRAME      = -61;                       //A bad frame time was specified
	public static final int ERR_NOTBC         = -62;                       //The BC has not been configured
	public static final int ERR_NOTRT         = -63;                       //The RT has not been configured
	public static final int ERR_NOTMON        = -64;                       //The monitor has not been configured
	public static final int ERR_SELFIOFAIL    = -71;                       //I/O selftest failed
	public static final int ERR_SELFMEMFAIL   = -72;                       //Memory selftest failed
	public static final int ERR_SELFCOMMFAIL  = -73;                       //Communication selftest failed
	public static final int ERR_SELFXMTFAIL   = -74;                       //Transmit selftest failed
	public static final int ERR_PLXBUG        = -75;                       //PLX bug is causing problems
	public static final int ERR_NOTSUPPORTED  = -76;                       //Base class does not support feature
	public static final int ERR_DLL           = -77;                       //A required DLL is missing
	public static final int ERR_SEQTYPE       = -80;                       //Invalid sequential record type value
	public static final int ERR_SEQNEXT       = -81;                       //Next sequential record does not exist
	public static final int ERR_SEQFINDINFO   = -82;                       //The SEQFINDINFO structure is not valid
	public static final int ERR_SEQBASEPTR    = -83;                       //The base pointer passed is invalid
	public static final int ERR_SEQMORE       = -84;                       //More (extended) record data does not exist
	public static final int ERR_TIMEOUT       = -90;                       //Function timed out waiting for data
	public static final int ERR_SUBFRMNUM     = -101;                      //Invalid SubFrame number was specified
	public static final int ERR_WORDNUM       = -102;                      //Invalid Word number was specified
	public static final int ERR_NOTINSYNC     = -103;                      //Not Synchronized to databus
	public static final int ERR_SUPERFRM      = -104;                      //SuperFrame not configured
	public static final int ERR_SUPERFRMNUM   = -105;                      //Invalid SuperFrame number was specified
}

