/**
*
*  LP-AFDX-1 and LC-AFDX-1 WIN32 DRIVER  Version 1.5  (10/07/2010)
*  Copyright (c) 2005-2010
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   AX1W32.H -- Visual C++ 32-bit
*                      AFDX Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the AX1.  Applications
*  using the AX1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "AX1W32.H"
*
*  Refer to the Visual C++ manual for more information on
*  header files.
*
**/

/**
*
*  Conditional block to prevent multiple defines.
*
**/

#ifndef __AX1W32_H
#define __AX1W32_H

/**
*
*  Pragma to specify link library.
*
**/

#ifdef __BORLANDC__
#pragma comment(lib,"ax1w32bc.lib")
#else
#if defined(_WIN32)
#pragma comment(lib,"ax1w32.lib")
#endif
#endif

/**
*
*  Typedefs used by the AX1 Driver.
*
**/

#ifndef AX1W32API
#ifdef __BORLANDC__
#define AX1W32API
#else
#define AX1W32API __declspec(dllimport)
#endif
#endif

#ifndef VOID
typedef void VOID;
#endif

#ifndef LPVOID
typedef void * LPVOID;
#endif

#ifndef LPCVOID
typedef const void * LPCVOID;
#endif

#ifndef INT
typedef int INT;
#endif

#ifndef LPINT
typedef int * LPINT;
#endif

#ifndef BYTE
typedef unsigned char BYTE;
#endif

#ifndef LPBYTE
typedef unsigned char * LPBYTE;
#endif

#ifndef LPCBYTE
typedef const unsigned char * LPCBYTE;
#endif

#ifndef CHAR
typedef char CHAR;
#endif

#ifndef USHORT
typedef unsigned short USHORT;
#endif

#ifndef SHORT
typedef short SHORT;
#endif

#ifndef LPUSHORT
typedef unsigned short * LPUSHORT;
#endif

#ifndef UINT
typedef unsigned int UINT;
#endif

#ifndef ULONG
typedef unsigned long ULONG;
#endif

#ifndef LPULONG
typedef unsigned long * LPULONG;
#endif

#ifndef LONG
typedef long LONG;
#endif

#ifndef FLOAT
typedef float FLOAT;
#endif

#ifndef DOUBLE
typedef double DOUBLE;
#endif

#ifndef ULONGLONG
typedef unsigned __int64 ULONGLONG;
#endif

#ifndef LONGLONG
typedef __int64 LONGLONG;
#endif

#ifndef HVL
typedef unsigned long HVL;
#endif

#ifndef LPHVL
typedef unsigned long * LPHVL;
#endif

#ifndef HPORT
typedef unsigned long HPORT;
#endif

#ifndef LPHPORT
typedef unsigned long * LPHPORT;
#endif

#ifndef HSCHED
typedef unsigned long HSCHED;
#endif

#ifndef LPHSCHED
typedef unsigned long * LPHSCHED;
#endif

#ifndef HSCHEDITEM
typedef unsigned long HSCHEDITEM;
#endif

#ifndef LPHSCHEDITEM
typedef unsigned long * LPHSCHEDITEM;
#endif

#ifndef MSGADDR
typedef unsigned long MSGADDR;
#endif

#ifndef LPMSGADDR
typedef unsigned long * LPMSGADDR;
#endif

#ifndef BASEADDR
typedef unsigned long BASEADDR;
#endif

#ifndef LPCSTR
typedef const char * LPCSTR;
#endif

#ifndef LPSTR
typedef char * LPSTR;
#endif

#ifndef BOOL
typedef int BOOL;
#endif

#ifndef LPBOOL
typedef int * LPBOOL;
#endif

#ifndef TRUE
#define TRUE 1
#endif

#ifndef FALSE
#define FALSE 0
#endif

#ifndef HCARD
typedef int HCARD;
#endif

#ifndef LPHCARD
typedef HCARD * LPHCARD;
#endif

#ifndef ERRVAL
typedef int ERRVAL;
#endif

/**************************
*
*   Constants
*
**************************/

enum {	MAX_AFDXPAYLOAD    = 1471,                //Max Payload Size defined for valid AFDX Frames - not including RSN byte
		MIN_AFDXPAYLOAD    = 17,                  //Min Payload Size defined for valid AFDX Frames - not including RSN byte
		MAX_UDPPAYLOAD     = 1472,                //Max Payload Size defined for valid UDP Frames - includes RSN byte
		MIN_UDPPAYLOAD     = 18,                  //Min Payload Size defined for valid UDP Frames - includes RSN byte
		MAX_AFDXPACKETSIZE = 1514,                //Max size of VALID AFDX transmit/receive packets (in bytes)
		MIN_PACKETBUFSIZE  = 60,                  //Min size of buffer used to transmit packets (in bytes)
		MAX_SEQRDBUFSIZE   = 0xFD000,             //Max buffer size for SeqRd functions

		HEADERLEN_MAC = 14,                                         //MAC header length = Destination(6bytes)+Source(6)+Type(2)
		HEADERLEN_IP  = 20,                                         //IP header length  
		HEADERLEN_UDP = 8,                                          //UDP header length = SourcePort(2bytes)+DestPort(2)+Len(2)+CRC(2)
		HEADERLEN_ALL = (HEADERLEN_MAC+HEADERLEN_IP+HEADERLEN_UDP), //Length of all headers (14+20+8=42) for IPV4 UDP packets

		DESCOFFSET_PKT = 32,                      //Offset of packet in AFDX packet descriptor
		DESCOFFSET_HDR = 32,                      //Offset of header in AFDX packet descriptor header

		MACLOCALMULTICAST_MASK = 0x03000000       //Group and the locally administered bits (upper 32-byte mask - constant portion)
};

//Network ID

enum {	NETID_REDUND    = 0x00,             //AFDX Redundant Network
		NETID_INDEPENDA = 0x01,             //AFDX Network A
		NETID_INDEPENDB = 0x02              //AFDX Network B
};

//Bus Numbers

enum {	BUS_A = 0x00,                       //AFDX Bus A
		BUS_B = 0x01                        //AFDX Bus B
};

//Interface ID

enum {	INTID_DEFAULT = 0x00,               //Use the default Interface ID
		INTID_BUS_A   = 0x01,               //Interface ID Network A
		INTID_BUS_B   = 0x02                //Interface ID Network B
};

//Packet Byte Offsets

enum {	OFFSET_UDPDATA = 42,

		DSSTATUS_ND    = 0,
		DSSTATUS_NO    = 3,
		DSSTATUS_FT    = 12,
		DSSTATUS_NCD   = 48
};

/**
*
*   Triggers
*
**/

enum {	TRIGSINK_COUNT   = 8,

		TRIGID_1         = 0x0000,
		TRIGID_2         = 0x0001,
		TRIGID_3         = 0x0002,
		TRIGID_4         = 0x0003,
		TRIGID_5         = 0x0004,
		TRIGID_6         = 0x0005,
		TRIGID_7         = 0x0006,
		TRIGID_8         = 0x0007,

		TSOURCE_DISABLE  = 0x0000,
		TSOURCE_ENABLE   = 0x0001,
		TSOURCE_SET      = 0x0000,
		TSOURCE_CLEAR    = 0x0002,

		TSINK_DISABLE    = 0x0000,
		TSINK_ENABLE     = 0x0001,
		TSINK_SHOT       = 0x0002,

		PORTTRIG_DISABLE = 0x0000,
		PORTTRIG_ENABLE  = 0x0001
};

/**
*
*   Error Injection
*
**/

enum {	ERRCTRL_DISABLE        = 0x0000,      //Disable Control Errors
		ERRCTRL_ENABLE         = 0x0001,      //Enable Control Errors
		ERRCTRL_TRIGGER        = 0x0002,      //Use triggering
		ERRCTRL_INVERSEENABLEA = 0x0004,      //Invert the enable flag for network A
		ERRCTRL_INVERSEENABLEB = 0x0008,      //Invert the enable flag for network B
		ERRCTRL_INVERSEORDER   = 0x0010,      //Invert the transmit order of networks
		ERRCTRL_SINGLSHOT      = 0x0020,      //Transmit the error one time

		ERRNET_DISABLE         = 0x0000,      //Disable Error Injection for the network
		ERRNET_ENABLE          = 0x0001,      //Enable Error Injection for the network
		ERRNET_TRIGGER         = 0x0002,      //Use triggering

		ERRPKT_DISABLE         = 0x0000,      //Disable Packet Errors
		ERRPKT_ENABLE          = 0x0001,      //Enable Packet Errors
		ERRPKT_TRIGGER         = 0x0002,      //Use triggering
		ERRPKT_NOAUTOCRCIP     = 0x0004,      //Disable auto checksum calculations for the IP header
		ERRPKT_NOAUTOCRCUDP    = 0x0008,      //Disable auto checksum calculations for the UDP header
		ERRPKT_NOAUTOINTID     = 0x0010,      //Disable auto insertion of interface ID in MAC source address
		ERRPKT_BLEND           = 0x0020,      //Blend the result packet with the error packet
		ERRPKT_CRCIPERROR      = 0x0040,      //Force an IP checksum error
		ERRPKT_CRCUDPERROR     = 0x0080,      //Force a UDP checksum error
		ERRPKT_SINGLSHOT       = 0x0100,      //Transmit the error one time

		BLEND_NONE             = 0x0000,      //No blending
		BLEND_ERRMAC           = 0x0001,      //Result will contain the error packet MAC header 
		BLEND_ERRINTID         = 0x0002,      //Result will contain the error packet Interface ID
		BLEND_ERRIP            = 0x0004,      //Result will contain the error packet IP header
		BLEND_ERRIPLEN         = 0x0008,      //Result will contain the error packet IP length
		BLEND_ERRUDP           = 0x0010,      //Result will contain the error packet UDP header
		BLEND_ERRUDPLEN        = 0x0020,      //Result will contain the error packet UDP length
		BLEND_ERRDATA          = 0x0040,      //Result will contain the error packet AFDX payload data

		ERRRSN_DISABLE         = 0x0000,      //Disable RSN Error Injection
		ERRRSN_ENABLE          = 0x0001,      //Enable RSN Error Injection
		ERRRSN_TRIGGER         = 0x0002,      //Use triggering
		ERRRSN_STEP            = 0x0000,      //Adjust the RSN and change the sequence to continue from this new value
		ERRRSN_IMPULSE         = 0x0004,      //Adjust the RSN for this instance only
		ERRRSN_ABSOLUTE        = 0x0000,      //Use modifier as the RSN
		ERRRSN_RELATIVE        = 0x0008,      //Add modifier to the RSN
		ERRRSN_SINGLSHOT       = 0x0010,      //Transmit the error one time
		ERRRSN_MODE1           = 0x0006,      //SHOT+ABSOLUTE+IMPULSE
		ERRRSN_MODE2           = 0x000E,      //SHOT+RELATIVE+IMPULSE
		ERRRSN_MODE3           = 0x0002,      //SHOT+ABSOLUTE+STEP
		ERRRSN_MODE4           = 0x000A,      //SHOT+RELATIVE+STEP
		ERRRSN_MODE5           = 0x000C,      //RELATIVE+IMPULSE
		ERRRSN_MODE6           = 0x0004,      //ABSOLUTE+IMPULSE
		ERRRSN_MODE7           = 0x0008,      //RELATIVE+STEP
		ERRRSN_MODE8           = 0x0000,      //ABSOLUTE+STEP

		ERRXMT_DISABLE         = 0x0000,      //Disable transmit Error Injection
		ERRXMT_ENABLE          = 0x0001,      //Enable transmit Error Injection
		ERRXMT_TRIGGER         = 0x0002,      //Use triggering
		ERRXMT_STUTTER         = 0x0000,      //Send a duplicate packet immediately
		ERRXMT_REPEAT          = 0x0004,      //Send the next packet immediately
		ERRXMT_SINGLSHOT       = 0x0008      //Transmit the error one time
};

/**
*
*  Interframe Gap Flags
*
**/

enum {	FRAMEGAP_DEFAULT = 0x0000,
		FRAMEGAP_SETNEW  = 0x0001
};

/**
*
*  Parametric Frame Frequency
*
**/

enum {	PARAMFREQ_DISABLE = 0x0000,
		PARAMFREQ_ENABLE  = 0x0001
};

/**
*
*  MIB type constants
*
**/

enum {	MIBTYPE_EQUIP     = 0x0000,     //Equipment info
		MIBTYPE_MAC_UNDEF = 0x0001,     //Undefined MAC constant info
		MIBTYPE_REDERR    = 0x0002,     //Redundancy errors
		MIBTYPE_REDSTAT   = 0x0004,     //Redundancy statistics
		MIBTYPE_IP        = 0x0008,     //IP header info
		MIBTYPE_UDP       = 0x0010,     //UDP header info
		MIBTYPE_SCHED     = 0x0020,     //Transmit schedule info
		MIBTYPE_TCP       = 0x0040,     //TCP info
		MIBTYPE_ESFAIL    = 0x0080,     //End system failure info
		MIBTYPE_MAC_A     = 0x0100,     //MAC for channel A
		MIBTYPE_MAC_B     = 0x0200,     //MAC for channel B
		MIBTYPE_REDSTAT_A = 0x0400,     //Statistics for redundant channel A
		MIBTYPE_REDSTAT_B = 0x0800      //Statistics for redundant channel B
};

/**
*
*  Enumeration constants
*
**/

enum {	GETNEXT_ROOT           = 0x0001,
		GETNEXT_NEXT           = 0x0002
};

/**
*
*   Bit fields of the packet activity flags
*
**/

enum {	PKTACT_NETB            = 0x00000001,
		PKTACT_NOVL            = 0x00000002,
		PKTACT_MACMISMATCH     = 0x00000004,
		PKTACT_BAGVIOLATION    = 0x00000008,
		PKTACT_NOPORT          = 0x00000010,
		PKTACT_INTEGRITYFAIL   = 0x00000020,
		PKTACT_REDUNDANTREJECT = 0x00000040,
		PKTACT_TIMEOUT         = 0x00000080,
		PKTACT_DUPRSNALTNET    = 0x00000100,
		PKTACT_DUPRSNSAMENET   = 0x00000200,
		PKTACT_SEQRSNERR       = 0x00000400,
		PKTACT_PARKED          = 0x00000800,
		PKTACT_INTIDMISMATCH   = 0x00001000,
		PKTACT_UNICAST         = 0x00002000,
		PKTACT_TRANSMIT        = 0x00004000,
		PKTACT_SKEWMAXERR      = 0x00008000,
		PKTACT_AUTOCRC         = 0x00010000
};

/**
*
*   Bit fields of the packet error flags
*
**/

enum {	PKTERR_FRAMELENGTH     = 0x00000001,
		PKTERR_IPTYPE          = 0x00000002,
		PKTERR_IPVERSION       = 0x00000004,
		PKTERR_IPLENGTH        = 0x00000008,
		PKTERR_IPTOS           = 0x00000010,
		PKTERR_IPFRAG          = 0x00000020,
		PKTERR_IPPROTOCOL      = 0x00000040,
		PKTERR_IPCRC           = 0x00000080,
		PKTERR_IPSOURCE        = 0x00000100,
		PKTERR_IPDESTINATION   = 0x00000200,
		PKTERR_UDPLENGTH       = 0x00000400,
		PKTERR_UDPCRC          = 0x00000800,
		PKTERR_UDPSOURCE       = 0x00001000,
		PKTERR_MAC             = 0x00002000,
		PKTERR_XMTVL           = 0x00004000,
		PKTERR_OTHER           = 0x00008000,
		PKTERR_EMAC_INRANGE    = 0x00010000,
		PKTERR_EMAC_OUTRANGE   = 0x00020000,
		PKTERR_EMAC_CRC        = 0x00030000,
		PKTERR_TOOLONG         = 0x00040000,
		PKTERR_BADFCS          = 0x00080000,
		PKTERR_ALIGNMENT       = 0x00100000,
		PKTERR_SHORT           = 0x00200000,
		PKTERR_RUNT            = 0x00400000,
		PKTERR_BAD             = 0x00800000,
		PKTERR_PAUSE           = 0x01000000,
		PKTERR_OVERRUN         = 0x02000000,
		PKTERR_IPERRMASK       = (PKTERR_IPTYPE+PKTERR_IPVERSION+PKTERR_IPLENGTH+PKTERR_IPTOS+PKTERR_IPFRAG+PKTERR_IPPROTOCOL+PKTERR_IPCRC+PKTERR_IPSOURCE+PKTERR_IPDESTINATION),
		PKTERR_UDPERRMASK      = (PKTERR_UDPLENGTH+PKTERR_UDPCRC+PKTERR_UDPSOURCE)
};

/**
*
*   Sequential status flags.
*
**/

enum {	SEQSTAT_OFF     = 0x0001,			   //Sequential is off
		SEQSTAT_EMPTY   = 0x0002,			   //Sequential buffer is empty
		SEQSTAT_PARTIAL = 0x0004,			   //Sequential buffer is partially filled
		SEQSTAT_PAUSED  = 0x0008			   //Sequential buffer is paused
};

/**
*
*   Sequential record type
*
**/

enum{	SEQTYPE_UDPNOPAYLOAD = 0x0010,             //UDP record without UDP payload (MAC header + IP header + UDP header + RSN value) [43 BYTES recorded: 42 byte header + 1byte RSN]
		SEQTYPE_UDPFULL      = 0x0011,             //UDP record with full packet
		SEQTYPE_OTHERPARTIAL = 0x0020,             //Non-standard IPv4 Type (0x0800) packet - only the first 42 bytes recorded
		SEQTYPE_OTHERFULL    = 0x0021,             //Non-UDP records with full packet

		SEQTYPE_MASK         = 0x00FF
};

/**
*
*  Rendundant configuration options
*
**/
                                                    
enum {	RDNDCFG_DEFAULT   = 0x00000000L,         //Select all default settings
		RDNDCFG_REDUNDANT = 0x00000000L,         //Use redundant networks
		RNDDCFG_INDEPEND  = 0x00000001L          //Use independent networks
};

/**
*
*  Network configuration options
*
**/
                                                    
enum {	NETCFG_DEFAULT       = 0x00000000L,         //Select all default settings
		NETCFG_ACTIVE        = 0x00000000L,         //Enable network activity (default)
		NETCFG_INACTIVE      = 0x00000001L,         //Disable network activity 
		NETCFG_ACTREDUNDA    = 0x00000000L,         //Enable network activity for redundant network's Bus A (default)
		NETCFG_INACTREDUNDA  = 0x80000000L,         //Disable network activity for redundant network's Bus A (only applies to redundant networks)
		NETCFG_ACTREDUNDB    = 0x00000000L,         //Enable network activity for redundant network's Bus B (default)
		NETCFG_INACTREDUNDB  = 0x40000000L,         //Disable network activity for redundant network's Bus B (only applies to redundant networks)
		NETCFG_NOEVENTVLMISS = 0x00000000L,         //VL does not generate events when an unconfigured port is received
		NETCFG_EVENTVLMISS   = 0x00000002L,         //VL generates events when an unconfigured port is received
		NETCFG_SEQSEL        = 0x00000000L,         //Sequential record recording is enabled at the VL or Port level (default)
		NETCFG_SEQALL        = 0x00000004L,         //Record all packets in sequential monitor
		NETCFG_DEFMAC        = 0x00000000L,         //Use default network MAC constant
		NETCFG_USERMAC       = 0x00000010L          //Use user supplied MAC constant
};

/**
*
*  Network pause options
*
**/

enum {	NETPAUS_FALSE = 0x0000,
		NETPAUS_TRUE  = 0x0001
};

/**
*
*  Network speed options
*
**/

enum {	NETSPEED_AUTO          = 0,                   //Speed auto-detection is used (limited to 10/100 Mbits/sec)
		NETSPEED_AUTO10100     = 0,                   //Speed auto-detection is used (limited to 10/100 Mbits/sec)
		NETSPEED_AUTO101001000 = 1110,                //Speed auto-detection is used (10/100/1000)
		NETSPEED_AUTOALL       = 1110,                //Speed auto-detection is used (10/100/1000)
		NETSPEED_10            = 10,                  //10 Mbits/sec
		NETSPEED_100           = 100,                 //100 Mbits/sec
		NETSPEED_1000          = 1000                 //1000 Mbits/sec
};

/**
*
*  Sequential Record configuration options
*
**/

enum {	SEQCFG_DEFAULT      = 0x00000000L,        //Select all default settings
		SEQCFG_ENABLE       = 0x00000000L,        //Enable sequential record (default)
		SEQCFG_DISABLE      = 0x00000001L,        //Disable sequential record
		SEQCFG_SELECT       = 0x00000000L,        //Sequential record recording is enabled at the network  VL or port level (default)
		SEQCFG_ALL          = 0x00000002L,        //Record all packets to the sequential record
		SEQCFG_BOTHIN       = 0x00000000L,        //Record both redundant packets
		SEQCFG_FIRSTIN      = 0x00000004L,        //Record only first redundant packet
		SEQCFG_VALID        = 0x00000004L,        //Deprecated, use SEQCFG_FIRSTIN
		SEQCFG_REJINVALID   = 0x00000000L,        //Do not record packets with errors or no definitions
		SEQCFG_INCINVALID   = 0x00000008L,        //Also record packets with errors or no definitions
		SEQCFG_PAYLOAD      = 0x00000000L,        //Record entire packet (default)
		SEQCFG_NOPAYLOAD    = 0x00000080L,        //Only record the header info. Entire packet recorded for non-UDP packets
		SEQCFG_FILLHALT     = 0x00000000L,        //Enable fill and halt mode (default)
		SEQCFG_CONTINUOUS   = 0x00000100L,        //Keeps recording even if full
		SEQCFG_ANYPROT      = 0x00000000L,        //Any protocol (IP) is recorded (default)
		SEQCFG_IPPROTOFF    = 0x00001000L,        //IP protocol packets are NOT recorded
		SEQCFG_ICMPPROTOFF  = 0x00002000L,        //ICMP IP protocol packets are NOT recorded
		SEQCFG_IGMPPROTOFF  = 0x00004000L,        //IGMP IP protocol packets are NOT recorded
		SEQCFG_TCPPROTOFF   = 0x00008000L,        //TCP IP protocol packets are NOT recorded
		SEQCFG_UDPPROTOFF   = 0x00010000L,        //UDP IP protocol packets are NOT recorded
		SEQCFG_RAWPROTOFF   = 0x00020000L,        //RAW IP protocol packets are NOT recorded
		SEQCFG_OTHERPROTOFF = 0x00040000L,        //Non IP,ICMP,IGMP,TCP,UDP, or RAW IP protocol packets are NOT recorded
		SEQCFG_UNPAUSED     = 0x00000000L,        //Sequential record is unpaused
		SEQCFG_PAUSED       = 0x00100000L,        //Sequential record is paused
		SEQCFG_NODMA        = 0x00000000L,        //Keep sequential record on card
		SEQCFG_DMA          = 0x00200000L,        //Send sequential record to DMA
		SEQCFG_DMAFILE      = 0x00400000L         //Send sequential record to DMA file
};

/**
*
*  Virtual Link configuration options
*
**/

enum {  VLCFG_DEFAULT         = 0x00000000L,         //Select all default settings
        VLCFG_RCV             = 0x00000000L,         //Receive VL (default)
        VLCFG_TX              = 0x00000001L,         //Transmit VL
        VLCFG_REDUNON         = 0x00000000L,         //Set redundancy on (default)
        VLCFG_REDUNOFF        = 0x00000002L,         //Set redundancy off
        VLCFG_SEQSEL          = 0x00000000L,         //Sequential record recording is enabled at the port level (default) (default)
        VLCFG_SEQALL          = 0x00000004L,         //Record all packets in sequential monitor
        VLCFG_NETAON          = 0x00000000L,         //Network A is enabled (default)
        VLCFG_NETAOFF         = 0x00000008L,         //Network A is disabled
        VLCFG_NETBON          = 0x00000000L,         //Network B is enabled (default)
        VLCFG_NETBOFF         = 0x00000010L,         //Network B is disabled
        VLCFG_AUTORSN         = 0x00000000L,         //Updating sequence numbering is automaticaly done (default)
        VLCFG_NOAUTORSN       = 0x00000020L,         //Updating sequence numbering is the users responsibility
        VLCFG_INTEGAON        = 0x00000000L,         //Integrity checking is enabled on NET A (rx only) (default)
        VLCFG_INTEGAOFF       = 0x00000040L,         //Integrity checking is disabled on NET A (rx only)
        VLCFG_INTEGBON        = 0x00000000L,         //Integrity checking is enabled on NET B (rx only) (default)
        VLCFG_INTEGBOFF       = 0x00000080L,         //Integrity checking is disabled on NET B (rx only)
        VLCFG_SUBVLRR         = 0x00000000L,         //Schedule sub-VLs (Tx) using a Round Robin scheme, VL rep-rate (default)
        VLCFG_SUBVLFACTOR     = 0x00000100L,         //Schedule sub-VLs (Tx) individually using timing factors
        VLCFG_FRMERRENA       = 0x00000200L,         //Enable frame errors on network A
        VLCFG_FRMERRENB       = 0x00000400L,         //Enable frame errors on network B
        VLCFG_AUTOINTID       = 0x00000000L,         //Enable auto Interface ID in source MAC address
        VLCFG_NOAUTOINTID     = 0x00000800L,         //Disable auto Interface ID in source MAC address
        VLCFG_AUTOCRCIP       = 0x00000000L,         //Enable auto checksum calculations for IP header
        VLCFG_NOAUTOCRCIP     = 0x00001000L,         //Disable auto checksum calculations for IP header
        VLCFG_AUTOCRCUDP      = 0x00000000L,         //Enable auto checksum calculations for IP header
        VLCFG_NOAUTOCRCUDP    = 0x00002000L,         //Disable auto checksum calculations for IP header
        VLCFG_NOJITTERCALC    = 0x00000000L,         //Disable jitter calculations
        VLCFG_JITTERCALC      = 0x00004000L,         //Enable jitter calculations
        VLCFG_NOEVENTHIT      = 0x00000000L,         //VL does not generate events when hit
        VLCFG_EVENTHIT        = 0x00008000L,         //VL generates events when hit
        VLCFG_NOEVENTPORTMISS = 0x00000000L,         //VL does not generate events when an unconfigured port is received
        VLCFG_EVENTPORTMISS   = 0x00010000L          //VL generates events when an unconfigured port is received
};

/**
*
*  Port configuration options
*
**/
                                                    
enum {  PORTCFG_DEFAULT      = 0x00000000L,         //Select all default settings
        PORTCFG_ENABLE       = 0x00000000L,         //Port is enabled (default)
        PORTCFG_DISABLE      = 0x00000200L,         //Port is disabled (data is not written to rcv port, xmt port not scheduled)
        PORTCFG_AFDX         = 0x00000000L,         //Port will be AFDX (default)
        PORTCFG_SAP          = 0x00000001L,         //Port will be SAP
        PORTCFG_SAMPLE       = 0x00000000L,         //Port will use sampling (default)
        PORTCFG_QUEUE        = 0x00000002L,         //Port will use queueing
        PORTCFG_NETAON       = 0x00000000L,         //Network A will be enabled (default)
        PORTCFG_NETAOFF      = 0x00000004L,         //Network A will be disabled
        PORTCFG_NETBON       = 0x00000000L,         //Network B will be enabled (default)
        PORTCFG_NETBOFF      = 0x00000008L,         //Network B will be disabled
        PORTCFG_NOSEQ        = 0x00000000L,         //Packets will not be recorded to the sequential monitor (default)
        PORTCFG_SEQ          = 0x00000010L,         //Packets will be recorded to the sequential monitor
        PORTCFG_NOSKIP       = 0x00000000L,         //Port will not be skipped (tx only) (default)
        PORTCFG_SKIP         = 0x00000020L,         //Port will be set to skip (tx only)
        PORTCFG_NOTIMETAG    = 0x00000000L,         //Packets will not be time-taged  (default)
        PORTCFG_TIMETAG      = 0x00000040L,         //Packets will be time-taged
        PORTCFG_TXAB4B       = 0x00000000L,         //Network A will be sent before B when redundant (default)
        PORTCFG_TXBB4A       = 0x00000080L,         //Network A will be sent before B when redundant
        PORTCFG_SRCPORTCHK   = 0x00000000L,         //Source UDP port number is verified on receive packets (default)
        PORTCFG_NOSRCPORTCHK = 0x00000100L,         //Source UDP port number is not verified on receive packets
        PORTCFG_NOEVENTHIT   = 0x00000000L,         //Port does not generate events
        PORTCFG_EVENTHIT     = 0x00000400L,         //Port genereates events when hit
        PORTCFG_SUBVL0       = 0x00000000L,         //Schedule port in sub-VL 0
        PORTCFG_SUBVL1       = 0x00001000L,         //Schedule port in sub-VL 1
        PORTCFG_SUBVL2       = 0x00002000L,         //Schedule port in sub-VL 2
        PORTCFG_SUBVL3       = 0x00003000L          //Schedule port in sub-VL 3
};

/**
*
*  Default port configuration options
*
**/

enum {  DEFPORT_DEFAULT  = 0x00000000L,         //Select all default settings
        DEFPORT_INACTIVE = 0x00000000L,         //Disable default port (default)
        DEFPORT_ACTIVE   = 0x00000001L,         //Enable default port
        DEFPORT_ALL      = 0x00000002L,         //Handle all non-deliverable packets
        DEFPORT_MAC      = 0x00000004L,         //Handle packets with MAC erors
        DEFPORT_SAMPLE   = 0x00000000L,         //Port will use sampling (default)
        DEFPORT_QUEUE    = 0x00000008L          //Port will use queuing
};

/**
*
*  Event configuration options
*
**/

enum {  EVENTCFG_DEFAULT     = 0x00000000L,        //Select all default settings
        EVENTCFG_ENABLE      = 0x00000000L,        //Enable event recording (default)
        EVENTCFG_DISABLE     = 0x00000001L,        //Disable event recording
        EVENTCFG_NOPHYSTATUS = 0x00000000L,        //Disable events on changes to PHY status (default)
        EVENTCFG_PHYSTATUS   = 0x00000002L         //Enable events on changes to PHY status
};

/**
*
*  Info types
*
**/

enum {  INFOTYPE_PLAT         = 0x0001,           //Returns the AX1 platform type
        INFOTYPE_PROD         = 0x0002,           //Returns the AX1 product type
        INFOTYPE_DASH         = 0x0003,           //Returns the AX1 dash number
        INFOTYPE_VERSION      = 0x0004,           //Returns the AX1 version number
        INFOTYPE_DATE         = 0x0005,           //Returns the AX1 version date
        INFOTYPE_MODEL        = 0x0006,           //Returns the AX1 model number
        INFOTYPE_MAXCOUNT     = 0x0007,           //Returns the max channel count
        INFOTYPE_ERRORGEN     = 0x0008,           //Returns whether AX1 supports error generation
        INFOTYPE_CONCURMON    = 0x0009,           //Returns whether AX1 has a concurrent sequential monitor
        INFOTYPE_PHYSTAT      = 0x000A,           //Returns status of phys
        INFOTYPE_RCVOVER      = 0x000B,           //Returns number of receiver overruns
        INFOTYPE_RCVDROPPKT   = 0x000C,           //Returns number of packets dropped by receiver
        INFOTYPE_RCVDROPBYTE  = 0x000D,           //Returns number of bytes dropped by receiver
		INFOTYPE_DMABUSYCOUNT = 0x000E,           //Returns number of times DMA was busy
		INFOTYPE_PCAP         = 0x000F,           //Returns device is a Pcap device
		INFOTYPE_ADDRL        = 0x0010,           //Returns device low address
		INFOTYPE_ADDRH        = 0x0011,           //Returns device high address
		INFOTYPE_DESC         = 0x0012            //Returns device description
};

/**
*
*   Schedule Hook IDs
*   
**/

enum {  SCHEDHOOK_SCHEDSTART  = 0x0001,
        SCHEDHOOK_SCHEDEND    = 0x0002,
        SCHEDHOOK_SUBVLSTART  = 0x0003,
        SCHEDHOOK_SUBVLINSERT = 0x0004,
        SCHEDHOOK_SUBVLEND    = 0x0005,
        SCHEDHOOK_ROBINSTART  = 0x0006,
        SCHEDHOOK_ROBININSERT = 0x0007,
        SCHEDHOOK_ROBINEND    = 0x0008,
        SCHEDHOOK_FRAMESTART  = 0x0009,
        SCHEDHOOK_FRAMEINSERT = 0x000A,
        SCHEDHOOK_FRAMEEND    = 0x000B,
        SCHEDHOOK_DISPLAY     = 0x000C,
        SCHEDHOOK_PRINT       = 0x000D
};

/**
*
*   Phy status
*
**/

enum {  PHYSTAT_CHA_SETAUTO = 0x00000001,
        PHYSTAT_CHA_SET10   = 0x00000002,
        PHYSTAT_CHA_SET100  = 0x00000004,
        PHYSTAT_CHA_SET1000 = 0x00000008,
        PHYSTAT_CHA_GOT10   = 0x00000020,
        PHYSTAT_CHA_GOT100  = 0x00000040,
        PHYSTAT_CHA_GOT1000 = 0x00000080,
        PHYSTAT_CHA_GOTFDX  = 0x00000100,
        PHYSTAT_CHA_GOTLINK = 0x00000200,
        PHYSTAT_CHA_GOTAUTO = 0x00000400,
        PHYSTAT_CHB_SETAUTO = 0x00010000,
        PHYSTAT_CHB_SET10   = 0x00020000,
        PHYSTAT_CHB_SET100  = 0x00040000,
        PHYSTAT_CHB_SET1000 = 0x00080000,
        PHYSTAT_CHB_GOT10   = 0x00200000,
        PHYSTAT_CHB_GOT100  = 0x00400000,
        PHYSTAT_CHB_GOT1000 = 0x00800000,
        PHYSTAT_CHB_GOTFDX  = 0x01000000,
        PHYSTAT_CHB_GOTLINK = 0x02000000,
        PHYSTAT_CHB_GOTAUTO = 0x04000000
};

/**
*
*   DMA record types
*
**/

enum {  DMATYPE_SEQ    = 0x01,     //Sequential record
        DMATYPE_EVENT  = 0x02,     //Event
        DMATYPE_PACKET = 0x03      //Packet
};

/**
*
*   EVENT types
*
**/

enum {  EVENTTYPE_PHYSTATUS = 0x01,     //Change in PHY status
        EVENTTYPE_VLHIT     = 0x03,     //VL hit
        EVENTTYPE_PORTHIT   = 0x04,     //Port hit
        EVENTTYPE_VLMISS    = 0x02,     //VL missed
        EVENTTYPE_PORTMISS  = 0x04      //Port missed
};

/**
*
*   RPC Table
*
**/

enum {  RPC_CARDCHECK,
        RPC_CARDCLEAN,
        RPC_CARDISRUN,
        RPC_CARDSTART,
        RPC_CARDSTOP,
        RPC_DEFAULTPORTCONFIG,
        RPC_DEFAULTPORTGETHANDLE,
        RPC_DETECTPORT,
        RPC_DETECTVL,
        RPC_DETECTVLIGNORE,
        RPC_ERRCTRLCONFIG,
        RPC_ERRNETENABLE,
        RPC_ERRPKTCONFIG,
        RPC_ERRRSNCONFIG,
        RPC_ERRXMTCONFIG,
        RPC_FRAMEGAPCONFIG,
        RPC_MIBGETNETINFO,
        RPC_MIBGETPORTINFO,
        RPC_MIBGETVLINFO,
        RPC_NETCONFIG,
        RPC_NETGETCONFIG,
        RPC_NETGETVLCOUNT,
        RPC_NETSETCONFIG,
        RPC_NETSETINTERFACEID,
        RPC_PARAMFRAMEFREQ,
        RPC_PORTCONFIG,
        RPC_PORTDATARD,
        RPC_PORTDATAWR,
        RPC_PORTGETANY,
        RPC_PORTGETCONFIG,
        RPC_PORTGETHAND,
        RPC_PORTGETINFO,
        RPC_PORTGETNEXT,
        RPC_PORTGETQUEUECOUNT,
        RPC_PORTINFORD,
        RPC_PORTRAWRD,
        RPC_PORTRAWWR,
        RPC_PORTRD,
        RPC_PORTSETCONFIG,
        RPC_PORTSKIPCONFIG,
        RPC_PORTSTEPCONFIG,
        RPC_REDUNDCONFIG,
        RPC_ROBINADDPORT,
        RPC_SCHEDADDNOOP,
        RPC_SCHEDADDPORT,
        RPC_SCHEDADDSUB,
        RPC_SCHEDCLEAR,
        RPC_SCHEDCRTROBIN,
        RPC_SCHEDCRTSUB,
        RPC_SCHEDFRAMEEND,
        RPC_SCHEDFRAMESTART,
        RPC_SCHEDITEMUPDATE,
        RPC_SEQCLEAR,
        RPC_SEQCONFIG,
        RPC_SEQGETCONFIG,
        RPC_SEQRD,
        RPC_SEQSETCONFIG,
        RPC_SEQSETMONITOR,
        RPC_SEQSTATUS,
        RPC_SUBADDNOOP,
        RPC_SUBADDPORT,
        RPC_SUBADDROBIN,
        RPC_TRIGCLEARBITS,
        RPC_TRIGGETVAL,
        RPC_TRIGSETBITS,
        RPC_TRIGSETVAL,
        RPC_TRIGSINKCONFIG,
        RPC_VLCONFIG,
        RPC_VLCONFIGMAC,
        RPC_VLGETCONFIG,
        RPC_VLGETHANDLE,
        RPC_VLGETHANDLEMAC,
        RPC_VLGETINFO,
        RPC_VLGETNEXT,
        RPC_VLGETNEXTMAC,
        RPC_VLGETPORTCOUNT,
        RPC_VLSETCONFIG,
        RPC_FLASHOPEN,
        RPC_FLASHCLOSE,
        RPC_FLASHERASE,
        RPC_FLASHREAD,
        RPC_FLASHWRITE,
        RPC_MEMRDL,
        RPC_MEMWRL,
        RPC_DCRRDL,
        RPC_DCRWRL,
        RPC_SDRRDL,
        RPC_SDRWRL,
        RPC_IICRDL,
        RPC_IICWRL,
        RPC_INTTRIG,
        RPC_DMAPARAM,
        RPC_TEST1,
        RPC_TEST2,
        RPC_TEST3,
        RPC_TEST4,
        RPC_NETFLOOD,
        RPC_ERRNETGETENABLE,
        RPC_ERRRSNGETCONFIG,
        RPC_ERRXMTGETCONFIG,
        RPC_ERRPKTGETCONFIG,
        RPC_ERRPKTGETCONFIGEX,
        RPC_ERRCTRLGETCONFIG,
        RPC_VLGETJITTER,
        RPC_GETPARAMFRAMEFREQ,
        RPC_VLSETFACTOR,
        RPC_VLGETFACTOR,
        RPC_SCHEDADDROBIN,
        RPC_DEVICEINFORD,
		RPC_RCVHOSTENABLE,
		RPC_EVENTCONFIG,
		RPC_EVENTGETCONFIG,
		RPC_RCVHOSTGETENABLE
};

/**
*
*  Error Values.
*
**/

enum {  ERR_NONE         =  0,                 //No error
        ERR_UNKNOWN      = -1,                 //An unexpected error occurred
        ERR_BADVER       = -2,                 //A bad version was encountered
        ERR_BADPOINTER   = -3,                 //CardOpen() called with bad parameters
        ERR_BADSIG       = -5,                 //A bad card signature was encountered
        ERR_RUNNING      = -6,                 //Card is already running
        ERR_BADPARAMS    = -11,                //Function called with bad parameters
        ERR_NOHANDLES    = -12,                //CardOpen() already has allocated too many handles
        ERR_NOCARD       = -13,                //CardOpen() could not find an AX1 card
        ERR_NOMEM        = -15,                //CardOpen() could not find the memory
        ERR_WRONGMODEL   = -17,                //Card does not support this feature
        ERR_NOSEL        = -18,                //CardOpen() could not allocate a memory selector
        ERR_LOCK         = -19,                //The communication process is locked up
        ERR_TOOMANY      = -20,                //Too many channels have been configured
        ERR_BADHANDLE    = -21,                //A bad handle was specified
        ERR_NOTCHAN      = -23,                //Not a valid channel
        ERR_NOTSEQ       = -26,                //The Sequential Record has not been configured
        ERR_ALLOC        = -27,                //There is not enough memory to allocate
        ERR_VXD          = -28,                //An error occurred in the VXD
        ERR_BUFSIZE      = -33,                //Insufficient space in user buffer
        ERR_NOCONFIG     = -34,                //The card has not been properly configured
        ERR_CONFLICTS    = -35,                //Unable to resolve conflicts
        ERR_RANGE        = -36,                //Schedule is out of range
        ERR_BOOTNUM      = -42,                //There is no boot code with the specified number
        ERR_ROMVERIFY    = -44,                //Unable to verify the value written to the ROM
        ERR_COUNT        = -45,                //An invalid count was specified
        ERR_NOMSGS       = -52,                //No messages specified
        ERR_BADTYPE      = -54,                //A bad type parameter was specified
        ERR_ZEROLEN      = -55,                //Zero length was specified
        ERR_BADADDRESS   = -56,                //A bad address was specified
        ERR_BADCMD       = -91,                //A bad command was specified
        ERR_FINDNEXT     = -92,                //Find next function count not find anything
        ERR_NETID        = -93,                //Network ID out of range
        ERR_BUSNUM       = -94,                //Busnum out of range
        ERR_PAIRID       = -95,                //Pair ID out of range
        ERR_GETEMPTY     = -96,                //Get did not find anything
        ERR_DETECTEMPTY  = -97,                //Detect did not find anything
        ERR_VLUNDEF      = -110,               //Specified VL is undefined
        ERR_PORTUNDEF    = -111,               //Specified port is undefined
        ERR_SCHED        = -112,               //Error creating or finding schedule
        ERR_TXQPORT      = -113,               //Attempt to read a queue transmit port
        ERR_CONVERSION   = -114,               //Error while converting data
        ERR_DATAOVERFLOW = -115,               //Data overflow in packet
        ERR_NOPKT        = -116,               //No packet was available
        ERR_FULL         = -117                //Operation failed, structure full
};

/**
*
*  Structs used by the AX1 Driver.
*
**/

#ifndef AFDXPKTDESC
typedef struct
{
    USHORT type;               
    USHORT count;              
    ULONG  timestamp;         
    ULONG  timestamph;        
    ULONG  delay;          
    ULONG  delayh;         
    ULONG  activity;
    ULONG  errors;
    USHORT busnum;
    USHORT totalpktlen;     //Total packet length
    BYTE   packet[MAX_AFDXPACKETSIZE+64];
} AFDXPKTDESC;
#endif

#ifndef LPAFDXPKTDESC
typedef AFDXPKTDESC * LPAFDXPKTDESC;
#endif

#ifndef AFDXPKTDESCHDR
typedef struct
{
    USHORT type;
    USHORT count;
    ULONG  timestamp;
    ULONG  timestamph;
    ULONG  delay;
    ULONG  delayh;
    ULONG  activity;
    ULONG  errors;
    USHORT busnum;
    USHORT totalpktlen;  //Total packet length
    BYTE   header[42];   //42 bytes for UDP/ICMP, 34 bytes for IP only, 
    BYTE   rsn;
} AFDXPKTDESCHDR;
#endif

#ifndef LPAFDXPKTDESCHDR
typedef AFDXPKTDESCHDR * LPAFDXPKTDESCHDR;
#endif

#ifndef SEQFINDINFO
typedef struct
{
    LPBYTE pRecFirst;
    LPBYTE pRecNext;
    LPBYTE pRecLast;
} SEQFINDINFO;
#endif

#ifndef LPSEQFINDINFO
typedef SEQFINDINFO * LPSEQFINDINFO;
#endif

#ifndef FDSDESC
typedef struct 
{
    USHORT offset;
    USHORT ds1_len;
    USHORT ds2_len;
    USHORT ds3_len;
    USHORT ds4_len;
} FDSDESC;
#endif

#ifndef LPFDSDESC
typedef FDSDESC * LPFDSDESC;
#endif

#ifndef ADDRESS
    typedef struct
    {
        BYTE data[6];
    } ADDRESS;
#endif

#ifndef LPADDRESS
typedef ADDRESS * LPADDRESS;
#endif

#ifndef MIB_EQUIP
    typedef struct
    {
        char    EqDesignation[20];      /*Equipment Designation*/
        char    EqPN[15];               /*Equipment Part Number*/
        char    EqSN[10];               /*Equipment Serial Number*/
        char    EqLN[10];               /*Equipment Load Part Number*/
        INT     EqStatus;               /*Equipment Status: 1=Healthy,2=inFault*/
        char    EqLocation[10];         /*Equipment Location (side * position)*/
        ULONG   EqUpTime;               /*Equipment up time (time since initialization)*/
    } MIB_EQUIP;
#endif

#ifndef MIB_MAC
    typedef struct
    {
        INT         MACIndex;           /*physical ethernet port number (Bus A/B)*/
        ULONGLONG   MACAddress;         /*48-bit MAC address*/
        INT         MACStatus;          /*HW Status (1=healthy,2=lossOfLink,3=inFault*/
        ULONG       MACInOctets;        /*Total bytes Rx (AFDX payload + RSN + 42 bytes header... preamble&start frame not included)*/
        ULONG       MACOutOctets;       /*Total bytes Tx*/
        ULONG       MACInFrames;        /*Total frames Rx*/
        ULONG       MACOutFrames;       /*Total frames Tx*/
        ULONG       MACTotalInErrors;   /*Total Errors Rx only=DestErr+AlignErr+CRCErr+FrameLenErr+IntMACErr + xMACInIPTypeErrors*/
        ULONG       MACDestAddrErrors;  /*Discarded frames from erronous MAC destination address*/
        ULONG       MACAlignmentErrors; /*Received frames not integral number of bytes*/
        ULONG       MACCRCErrors;       /*Received frames that do not pass CRC check*/
        ULONG       MACFrameLengthErrors;/*Recived frames longer tham MAX or shorter than MIN frame size*/
        ULONG       MACIntMACRxErrors;  /*Discarded frames with internal MAC errors (Header: Preamble,Start Frame Delim)*/

        /*extras*/
        ULONG       exMACFrameLengthLongErr;    
        ULONG       exMACFrameLengthShortErr;   
        
        ULONG       exMACMulticastFrames;   /*Total Multicast frames*/
        ULONG       exMACBroadcastFrames;   /*Total Broadcast frames*/

        ULONG       exMACInIPTypeErrors;    /*Discarded frames with a MAC IP Type error (should be 0x0800)*/
        ULONG       exMACSupriseVL;         /*MAC address (VL) was seen for which a VL/MAC Table entry was NOT found.*/
        ULONG       exMACConstMismatch;     /*The constant portion of the MAC dest not match the expected AFDX constant (does not increment MACTotalInErrors)*/
        ULONG       exMACBagViolations;     /*Counts of VALID frames that violated the minnimum BAG time... time measured from first redundancy validated frame to next in-sequence */
        ULONG       exMACInQueuePortFull;   /*Count of how many times the oldest packet was dropped because a RX queuing port was full (not serviced)*/

        ULONG       exMACOutQueuedOctets;   /*Total Tx bytes loaded into TX queue... (less than or equal to MACOutOctets)*/
        ULONG       exMACOutQueuedFrames;   /*Total Tx frames loaded into TX queue... (less than or equal to MACOutFrames)*/

        /*status*/
        ULONGLONG   exMACLastInDestAddr;    /*Last received Destination Addr - only updated for unassigned VL's*/
        ULONGLONG   exMACLastTime;          /*(in us) recorded last time*/
        
        /*range config values*/
        ULONG       exMACRangeMidLowVal;
        ULONG       exMACRangeMidHighVal;
        /*range level counts*/
        ULONG       exMACFrameLengthRangeLow; /*Number of Frames received with Length in Low range - checked AFTER integrity/redundancy, but before IP*/
        ULONG       exMACFrameLengthRangeMid; /*Count of valid frames with the middle range data length - checked AFTER integrity/redundancy, but before IP*/
        ULONG       exMACFrameLengthRangeHigh;/*Count of valid frames with the high range data length - checked AFTER integrity/redundancy, but before IP*/

    } MIB_MAC;
#endif

#ifndef MIB_REDUNDERR
    typedef struct
    {
        INT         RedundPortIndex;            /*physical ethernet port number (Bus A/B)*/
        ULONG       RedundIntegrityCheckError;  /*Total number rx frames with Integrity RSN invalid (for the above port/bus)*/
    } MIB_REDUNDERR;
#endif

#ifndef MIB_REDUNDSTATS
    typedef struct
    {
        INT         RedundVLPortIndex;          /*physical ethernet port number (Bus A/B)*/
        ULONG       RedundVLMacAddress;         /*Multicast MAC address destination (of VL in Rx) using redundancy*/
        ULONG       RedundVLIntegrityCheckError;/*Total number rx frames with RSN invalid (for the above port/bus). Invremented by an ingegrity or a redundancy error*/
        ULONG       RedundVLFirstInFrames;      /*Valid rx frames passed to IP layer (only for the VL using redundancy - passed integrity and redundancy)*/

        /*extra*/
        ULONG       exIntegDupRSN;              /*Duplicate RSN*/
        ULONG       exIntegSeqRSN;              /*Sequence out-of-order RSN (including dropped frames from Alt bus)*/
        ULONG       exIntegDisableSkip;         /*Integrity checking skipped because it was disabled*/
        ULONG       exIntegRSNZeroIn;           /*RSN 0 received (reset)*/
        ULONG       exIntegRSNZeroConsecIn;     /*Consecutive RSN 0 received (reset)*/
        ULONG       exRedundDupRSNAltNet;       /*Duplicate RSN from alternate network (not technally an error, but packet dropped)*/
        ULONG       exRedundDupRSNSameNet;      /*Duplicate RSN from same network (error, packet dropped)*/
        ULONG       exRedundSeqRSN;             /*Sequence out-of-order RSN (error, packet dropped)*/
        ULONG       exRedundDisableSkip;        /*Redundancy checking skipped because it was disabled*/
        ULONG       exRedundTimeouts;           /*Count of how many times the redundancy checking timedout... next RSN accepted regardless ([timeout=skewMax if skewMax > bag]  ELSE  [timeout=skewMax + bag]*/
        ULONG       exRedundBagViolations;      /*Counts of VALID frames that violated the minnimum BAG time... time measured from first redundancy validated frame to next in-sequence*/
        ULONG       exRedundOverSkewMax;        /*Count skewMax was exceeded... note: packet only accepted if timeout was exceeded (see timeout above)*/
    } MIB_REDUNDSTATS;
#endif

#ifndef MIB_IP
    typedef struct
    {
        ULONG       IPInReceives;               /*Total num of datagrams received (including errors) = inTotalErrors+valid datagrams*/
        ULONG       IPOutRequests;              /*Total num of datagrams in output (including errors) = OutTotalErrors+valid datagrams*/
        ULONG       IPInTotalErrors;            /*Num of Rx datagrams with errors = ChkSumErrs + UnknownProtocols + InDiscards + ReasmFail*/
        ULONG       IPOutTotalErrsDiscrd;       /*Num of Tx datagrams DISCARDED due to errors*/
        ULONG       IPInChkSumErrors;           /*Num of Rx Check sum errors. (Packet discarded)*/
        ULONG       IPInUnknownProtos;          /*Num of (locally addressed) datagrams with an Unknown or Unsupported protocol. (Packet discarded)*/
        ULONG       IPInDiscards;               /*Num of datagrams with NO Problems, but were discarded.*/
        ULONG       IPOutDiscards;              /*Num of datagrams with NO Problems, but were discarded.*/
        ULONG       IPReasmFails;               /*Frag Error-Num of datagrams deleted by reassembly algorithm (for whatever reason:fragment id error, etc.)*/

        /*Extra counters*/
        ULONG       exIPInVersionErrors;        /*Num of Rx IP Version errors*/
        ULONG       exIPOutVersionErrors;       /*Num of Tx IP Version errors*/
        ULONG       exIPInHdrLenErrors;         /*Num of Rx IP Header Length errors*/
        ULONG       exIPOutHdrLenErrors;        /*Num of Tx IP Header Length errors*/
        ULONG       exIPInTypeOfService;        /*Num of Rx IP Type of service errors*/
        ULONG       exIPOutTypeOfService;       /*Num of Tx IP Type of service errors*/

        ULONG       exIPInDestErr;              /*Destination error*/
        ULONG       exIPInSourceErr;            /*Source error*/

        ULONG       exIPOutTotalErrorsSent;     /*Num of Tx datagrams SENT with errors (for error injection)*/
        ULONG       exIPOutChkSumErrors;        /*Num of Tx Check sum errors. (Packet discarded)*/
        ULONG       exIPOutUnknownProtos;       /*Num of (locally addressed) datagrams with an Unknown or Unsupported protocol. (Packet discarded)*/
        ULONG       exIPOutFragErrors;          /*Num of datagrams sent with Fragmentation errors*/

        ULONG       exIPInOctets;               /*Total num of bytes received*/
        ULONG       exIPOutOctets;              /*Total num of bytes output*/
    } MIB_IP;
#endif

#ifndef MIB_UDP
    typedef struct
    {
        ULONG       UDPInError;         /*count of input datagrams with an error (does not include 'UDPNoPorts')*/
        ULONG       UDPNoPorts;         /*Count of datagrams with no application at the dest port*/
        ULONG       exUDPInSrcInval;    /*count of UDP frames with invalid source address... depending on implementation 'UDPInError' MAY be incremented*/
        ULONG       exUDPInLengthError; /*receive Length errors (increments UDPInError)*/
        ULONG       exUDPInCRCError;    /*receive CRC errors (increments UDPInError)*/
    } MIB_UDP;
#endif

#ifndef MIB_SCHED
    typedef struct
    {
        ULONG       exSchedOutFrames;       /*Total Tx frames actually sent*/
        /*ULONG     exSchedOutLoadedOctets; Total Tx bytes loaded into TX queue... (greater than or equal to MACOutOctets)*/
        ULONG       exSchedOutLoadedFrames; /*Total Tx frames loaded into TX queue... (greater than or equal to MACOutFrames)*/
        ULONG       exSchedOutRRSchedNop;   /*Count of the times a Round Robin sched entry did no transmission*/
    } MIB_SCHED;
#endif

#ifndef MIB_TCP
    typedef struct
    {
        ULONG       TCPInError;
        ULONG       TCPNoPorts;         /*Total count received segments with no application at the dest port.*/
        ULONG       TCPInSegs;          /*segments delivered to TCP users*/
        ULONG       TCPOutSegs;         /*segments sent to the IP Layer*/
    } MIB_TCP;
#endif

#ifndef MIB_ESFAILURE
    typedef struct
    {
        ULONG       InLackOfBuffer;
        ULONG       OutLackOfBuffer;
    } MIB_ESFAILURE;
#endif

#ifndef MIB_PORT
    typedef struct
    {
        ULONG       exQueuePortFull;            /*Number of dropped packets due to queue overruns*/
        ULONG       exHitCount;                 /*Count of hits */
        ULONG       exByteCount;                /*Count of payload bytes through this message (IP payload only... not header)*/

        ULONG       exPortOutTotalFrames;       /*count of the Total number of frames transmitted on the bus*/
        ULONG       exPortOutRRFrames;          /*count of the number of frames encountered (for Round Robin sched) (xmission may be pending)*/
        ULONG       exPortOutRRSkipped;         /*count of the times the port was skipped (for Round Robin sched), either because of skip in the schedule item or the port setting*/
        ULONG       exPortOutRRQueueEmpty;      /*count of the times the port was skipped because the Queue was empty (for Round Robin sched)*/
        ULONG       exPortOutRRRedNetTxOff;     /*count of Xmt where Bus was configured for redundundancy but neither NetA nor NetB were enabled for TX (for Round Robin sched)*/
        ULONG       exPortOutRRIndNetAltNet;    /*count of times where network was configured as Independant, but tried to TX on Alt Net (for Round Robin sched)*/

        ULONG       exPortOutSkipped;           /*count of the times the port was skipped (not Round Robin sched), either because of skip in the schedule item or the port setting*/
        ULONG       exPortOutQueueEmpty;        /*count of the times the port was skipped because the Queue was empty (not Round Robin sched)*/
        ULONG       exPortOutRedNetTxOff;       /*count of Xmt where Bus was configured for redundundancy but neither NetA nor NetB were enabled for TX (not Round Robin sched)*/
        ULONG       exPortOutIndNetAltNet;      /*count of times where network was configured as Independant, but tried to TX on Alt Net (not Round Robin sched)*/
    } MIB_PORT;
#endif

/**
*
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*  AX1 Driver functions.
*
**/

AX1W32API ERRVAL __stdcall AX1_CardClose(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CardOpen(LPHCARD lpHandle,INT cardnum);
AX1W32API ERRVAL __stdcall AX1_CardReset(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CardStart(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CardStop(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrCtrlConfig(ULONG configval,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrNetEnable(ULONG configval,USHORT trigid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrPktConfig(ULONG configval,ULONG blendflags,USHORT trigid,LPBYTE packet,USHORT pktlen,USHORT errpadlen,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrRSNConfig(ULONG configval,USHORT trigid,INT modifier,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrXmtConfig(ULONG configval,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_EventConfig(ULONG configval,HCARD handleval);
AX1W32API ULONG __stdcall AX1_FDSGetBoolean(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API FLOAT __stdcall AX1_FDSGetFloat32(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API DOUBLE __stdcall AX1_FDSGetFloat64(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API USHORT __stdcall AX1_FDSGetOpaqueFix(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPBYTE outbuf,INT bufsize);
AX1W32API USHORT __stdcall AX1_FDSGetOpaqueVar(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPBYTE outbuf,INT bufsize);
AX1W32API LONG __stdcall AX1_FDSGetSigned32(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API LONGLONG __stdcall AX1_FDSGetSigned64(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API BYTE __stdcall AX1_FDSGetStatus(LPBYTE buf,FDSDESC fds_desc,INT ds_num);
AX1W32API USHORT __stdcall AX1_FDSGetString(LPBYTE buf,LPBYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPSTR outbuf,INT bufsize);
AX1W32API BYTE __stdcall AX1_FDSPutBoolean(ULONG putval,LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API BYTE __stdcall AX1_FDSPutFloat32(FLOAT putval,LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API BYTE __stdcall AX1_FDSPutFloat64(DOUBLE putval,LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API BYTE __stdcall AX1_FDSPutOpaqueFix(LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPBYTE inbuf,INT bufsize);
AX1W32API BYTE __stdcall AX1_FDSPutOpaqueVar(LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPBYTE inbuf,USHORT datalen,INT bufsize);
AX1W32API BYTE __stdcall AX1_FDSPutSigned32(LONG putval,LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API BYTE __stdcall AX1_FDSPutSigned64(LONGLONG putval,LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FDSPutStatus(LPBYTE buf,FDSDESC fds_desc,INT ds_num,BYTE status);
AX1W32API BYTE __stdcall AX1_FDSPutString(LPBYTE buf,BYTE status,FDSDESC fds_desc,INT ds_num,INT offset,LPSTR inbuf,INT bufsize);
AX1W32API ULONG __stdcall AX1_FldGetBoolean(LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API FLOAT __stdcall AX1_FldGetFloat32(LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API DOUBLE __stdcall AX1_FldGetFloat64(LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API USHORT __stdcall AX1_FldGetOpaqueFix(LPBYTE buf,INT offset,LPBYTE outbuf,INT bufsize);
AX1W32API USHORT __stdcall AX1_FldGetOpaqueVar(LPBYTE buf,INT offset,LPBYTE outbuf,INT bufsize);
AX1W32API LONG __stdcall AX1_FldGetSigned32(LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API LONGLONG __stdcall AX1_FldGetSigned64(LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API USHORT __stdcall AX1_FldGetString(LPBYTE buf,INT offset,LPSTR outbuf,INT bufsize);
AX1W32API VOID __stdcall AX1_FldPutBoolean(ULONG putval,LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FldPutFloat32(FLOAT putval,LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FldPutFloat64(DOUBLE putval,LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FldPutOpaqueFix(LPBYTE buf,INT offset,LPBYTE inbuf,INT bufsize);
AX1W32API VOID __stdcall AX1_FldPutOpaqueVar(LPBYTE buf,INT offset,LPBYTE inbuf,USHORT datalen,INT bufsize);
AX1W32API VOID __stdcall AX1_FldPutSigned32(LONG putval,LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FldPutSigned64(LONGLONG putval,LPBYTE buf,INT offset,BOOL byteswap);
AX1W32API VOID __stdcall AX1_FldPutString(LPBYTE buf,INT offset,LPSTR inbuf,INT bufsize);
AX1W32API USHORT __stdcall AX1_Hton16(USHORT val);
AX1W32API ULONG __stdcall AX1_Hton32(ULONG val);
AX1W32API ULONGLONG __stdcall AX1_Hton64(ULONGLONG val);
AX1W32API ULONG __stdcall AX1_MakeDstIP(USHORT vlid);
AX1W32API ULONG __stdcall AX1_MakeDstIPUnicast(USHORT domain,USHORT side,USHORT location,USHORT part);
AX1W32API ERRVAL __stdcall AX1_MakeDstMAC(USHORT vlid,LPADDRESS paddress);
AX1W32API ERRVAL __stdcall AX1_MakeDstMACEx(USHORT vlid,ULONG MACConst,LPADDRESS paddress);
AX1W32API ULONG __stdcall AX1_MakeSrcIP(USHORT domain,USHORT side,USHORT location,USHORT part);
AX1W32API ULONG __stdcall AX1_MakeSrcIPEx(USHORT userid,USHORT part);
AX1W32API ERRVAL __stdcall AX1_MakeSrcMAC(USHORT domain,USHORT side,USHORT location,USHORT intid,LPADDRESS paddress);
AX1W32API ERRVAL __stdcall AX1_MakeSrcMACEx(USHORT userid,USHORT intid,LPADDRESS paddress);
AX1W32API ERRVAL __stdcall AX1_MIBGetNetInfo(USHORT mibtype,LPBYTE data,USHORT busnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_MIBGetPortInfo(LPBYTE data,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_MIBGetVLInfo(USHORT mibtype,LPBYTE data,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetConfig(ULONG configval,ULONG macconst,USHORT speed,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetDefaultPortConfig(ULONG ctrlflags,USHORT depth,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetDefaultPortGetHandle(LPHPORT hport,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetFlood(BOOL bEnable,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetGetVLCount(LPUSHORT pvlcount,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetIFGConfig(ULONG configval,USHORT gapval,USHORT busnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetRedundConfig(ULONG configval,USHORT pairid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetSetInterfaceID(USHORT flags,USHORT idVal,USHORT netid,HCARD handleval);
AX1W32API USHORT __stdcall AX1_Ntoh16(USHORT val);
AX1W32API ULONG __stdcall AX1_Ntoh32(ULONG val);
AX1W32API ULONGLONG __stdcall AX1_Ntoh64(ULONGLONG val);
AX1W32API ERRVAL __stdcall AX1_ParamFrameFreq(ULONG configval,USHORT percent,USHORT netid,HCARD handleval);
AX1W32API USHORT __stdcall AX1_PktCalcCRCIP(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktCalcCRCUDP(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetCtrlFlag(LPBYTE pPkt);
AX1W32API BOOL __stdcall AX1_PktGetDstMac(LPBYTE pPkt,LPADDRESS pAddress);
AX1W32API USHORT __stdcall AX1_PktGetFragID(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetFragOff(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetIHL(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetInterfaceID(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetIPChecksum(LPBYTE pPkt);
AX1W32API ULONG __stdcall AX1_PktGetIPDest(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetIPLength(LPBYTE pPkt);
AX1W32API ULONG __stdcall AX1_PktGetIPSrc(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetProtocol(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetSeqNum(LPBYTE pPkt);
AX1W32API BOOL __stdcall AX1_PktGetSrcMac(LPBYTE pPkt,LPADDRESS pAddress);
AX1W32API USHORT __stdcall AX1_PktGetTOS(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetTTL(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetType(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetUDPChecksum(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetUDPLength(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetUDPPortDest(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetUDPPortSrc(LPBYTE pPkt);
AX1W32API USHORT __stdcall AX1_PktGetVersion(LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutCtrlFlag(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutDstMac(ADDRESS newMAC,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutFragID(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutFragOff(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutHeaderConstants(LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutIHL(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutInterfaceID(USHORT busnum,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutIPChecksum(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutIPDest(ULONG newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutIPLength(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutIPSrc(ULONG newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutLenFromFrame(USHORT frameSize,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutProtocol(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutSeqNum(USHORT newNum,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutSrcMac(ADDRESS newMAC,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutTOS(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutTTL(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutType(USHORT newType,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutUDPChecksum(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutUDPLength(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutUDPPortDest(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutUDPPortSrc(USHORT newVal,LPBYTE pPkt);
AX1W32API VOID __stdcall AX1_PktPutVersion(USHORT newVal,LPBYTE pPkt);
AX1W32API ERRVAL __stdcall AX1_PortConfig(ULONG configval,USHORT dstid,USHORT srcid,USHORT depth,LPHPORT portptr,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortDataRd(LPBYTE data,LPUSHORT lengthptr,LPBYTE rsnptr,LPULONG timetaghptr,LPULONG timetagptr,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortDataWr(BYTE rsn,LPBYTE data,USHORT length,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetHandle(USHORT portnum,LPHPORT hport,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetInfo(LPULONG configval,LPUSHORT vlid,LPUSHORT dstport,LPUSHORT srcport,LPUSHORT depth,LPUSHORT reprate,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetNext(USHORT flag,LPUSHORT nextPort,USHORT lastPort,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetQueueCount(LPUSHORT queuecount,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortInfoRd(LPULONG timetaghptr,LPULONG timetagptr,LPULONG activityptr,LPULONG errorptr,LPBYTE rsnptr,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortRawRd(LPBYTE packet,LPUSHORT lengthptr,LPULONG timetaghptr,LPULONG timetagptr,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortRawWr(LPBYTE packet,USHORT length,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortRd(LPAFDXPKTDESC pktdesc,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortSkipConfig(ULONG ctrlflags,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortStepConfig(ULONG ctrlflags,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RcvHostEnable(BOOL enableval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RobinSchedPort(BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,HPORT hport,LPHSCHEDITEM hscheditem,HSCHED hrobin,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedBuild(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedCrtRobin(LPHSCHED hrobin,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedCrtSub(LPHSCHED hsub,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedFrameEnd(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedFrameStart(ULONG usframetime,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedItemUpdate(BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,HSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedNoop(BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedPort(BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,HPORT hport,LPHSCHEDITEM hscheditem,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedRobin(BOOL bSkip,BOOL bShot,HSCHED hrobin,LPHSCHEDITEM hscheditem,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedSub(BOOL bSkip,BOOL bShot,HSCHED hsub,LPHSCHEDITEM hscheditem,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqClear(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqConfig(ULONG configval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqFindCheckValidType(USHORT seqtype);
AX1W32API ERRVAL __stdcall AX1_SeqFindInit(LPBYTE seqbuf,INT seqbufsize,LPSEQFINDINFO sfinfo);
AX1W32API ERRVAL __stdcall AX1_SeqFindNext(LPBYTE* pRecord,LPUSHORT seqtype,LPSEQFINDINFO sfinfo);
AX1W32API ERRVAL __stdcall AX1_SeqFindNextEx(LPBYTE pRecord,INT recordcount,LPUSHORT seqtype,LPSEQFINDINFO sfinfo);
AX1W32API ERRVAL __stdcall AX1_SeqPause(HCARD handleval);
AX1W32API INT __stdcall AX1_SeqRd(LPBYTE bufptr,LPULONG bufcountptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqRestart(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqResume(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqSetMonitor(BOOL bmonitor,USHORT vlid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqStatus(LPUSHORT statusptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SubSchedNoop(BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HSCHED hsub,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SubSchedPort(BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,HPORT hport,LPHSCHEDITEM hscheditem,HSCHED hsub,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SubSchedRobin(BOOL bSkip,BOOL bShot,HSCHED hrobin,LPHSCHEDITEM hscheditem,HSCHED hsub,HCARD handleval);
AX1W32API BOOL __stdcall AX1_TimeGetDelta(ULONG tth1,ULONG ttl1,ULONG tth2,ULONG ttl2,LPULONG sec,LPULONG usec);
AX1W32API BOOL __stdcall AX1_TimeGetSeconds(ULONG tth,ULONG ttl,LPULONG sec,LPULONG usec);
AX1W32API ERRVAL __stdcall AX1_TrigClearBits(ULONG bits,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_TrigGetVal(LPULONG trigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_TrigSetBits(ULONG bits,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_TrigSetVal(ULONG trigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_TrigSinkConfig(ULONG ctrlflags,USHORT trigid,ULONG ulComp,ULONG ulMask,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLConfig(ULONG configval,USHORT vlid,USHORT bag,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLConfigMAC(ULONG configval,ADDRESS macdst,USHORT bag,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetHandle(USHORT vlid,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetHandleMAC(LPADDRESS pmacdst,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetInfo(LPULONG configval,LPUSHORT vlid,LPADDRESS pmacdst,LPADDRESS pmacsrc,LPULONG ipdst,LPULONG ipsrc,LPULONG bag,LPULONG skew,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetJitter(BOOL bReset,LPULONG pJitA,LPULONG pJitB,LPULONG pMaxJitA,LPULONG pMaxJitB,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetNext(USHORT flag,LPUSHORT nextVL,USHORT lastVL,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetNextMAC(USHORT flag,LPADDRESS pnextMAC,ADDRESS lastMAC,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetPortCount(LPUSHORT portcnt,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLSetFactors(INT factor0,INT factor1,INT factor2,INT factor3,HVL hvl,HCARD handleval);

/**
*
*  Internal functions used by the AX1 Driver.
*
**/

AX1W32API ERRVAL __stdcall AX1_CardCheck(HCARD handleval);
AX1W32API ULONG __stdcall AX1_CardGetInfo(INT infotype,HCARD handleval);
AX1W32API LPCSTR __stdcall AX1_CardGetInfoName(HCARD handleval);
AX1W32API LPSTR __stdcall AX1_CardGetInfoStr(INT infotype,LPSTR buf,INT bufsize,HCARD handleval);
AX1W32API VOID __stdcall AX1_CardInit(VOID);
AX1W32API BOOL __stdcall AX1_CardIsHardware(HCARD handleval);
AX1W32API BOOL __stdcall AX1_CardIsHostRcv(HCARD handleval);
AX1W32API BOOL __stdcall AX1_CardIsRunning(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CardOpenEx(LPHCARD lpHandle,LPCSTR cardname,INT cardnum);
AX1W32API ERRVAL __stdcall AX1_CardOpenExx(LPHCARD lpHandle,LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
AX1W32API ERRVAL __stdcall AX1_CardResetEx(HCARD handleval);
AX1W32API VOID __stdcall AX1_CardResetExx(HCARD handleval);
AX1W32API USHORT __stdcall AX1_Checksum(BYTE msb,BYTE lsb,USHORT sum);
AX1W32API ERRVAL __stdcall AX1_CommRpcArgStart(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcArgStop(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcCall(INT rpcnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcCallEx(INT rpcnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcInParam(LPCVOID parg,INT argsize,BOOL ptrflag,BOOL copyflag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcInParamPtr(LPCVOID parg,INT argsize,BOOL copyflag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcInParamVal(LPCVOID parg,INT argsize,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommRpcOutParamPtr(INT index,LPVOID parg,INT argsize,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_CommTrigger(INT waittype,INT trignum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DetectPort(LPUSHORT portnum,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DetectVL(LPUSHORT vlid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DetectVLIgnore(USHORT vlid,USHORT netid,HCARD handleval);
AX1W32API ULONG __stdcall AX1_Div(ULONG diva,ULONG divb);
AX1W32API INT __stdcall AX1_DllUsageCount(VOID);
AX1W32API ERRVAL __stdcall AX1_DMAInstall(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAInstallEx(ULONG size,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAPipeClose(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAPipeOpen(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAUninstall(HCARD handleval);
AX1W32API UINT __stdcall AX1_DMAWorkerEntry(LPVOID lpParam);
AX1W32API ULONG __stdcall AX1_DMAWorkerGetBusyCount(HCARD handleval);
AX1W32API BOOL __stdcall AX1_DMAWorkerIsPause(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAWorkerPause(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAWorkerStart(LPVOID pVirt,INT sizeval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAWorkerStop(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_DMAWorkerUnpause(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrCtrlGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,HPORT hport,HCARD handleval);
AX1W32API LPCSTR __stdcall AX1_ErrDesc(INT errval);
AX1W32API LPCSTR __stdcall AX1_ErrDescStr(INT errval);
AX1W32API LPCSTR __stdcall AX1_ErrName(INT errval);
AX1W32API ERRVAL __stdcall AX1_ErrNetGetEnable(LPULONG pconfigval,LPUSHORT ptrigid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrPktGetConfig(LPULONG pconfigval,LPULONG pblendflags,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrPktGetConfigEx(LPULONG pconfigval,LPULONG pblendflags,LPUSHORT ptrigid,LPBYTE packet,USHORT pktlen,LPUSHORT ptotallen,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrRSNGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,LPINT pmodifier,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ErrXmtGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_EventGetConfig(LPULONG pconfigval,HCARD handleval);
AX1W32API VOID __stdcall AX1_ExpandMant(LPULONG mant,LPINT exp);
AX1W32API INT __stdcall AX1_FDSCalcOffset(LPBYTE buf,FDSDESC fds_desc,INT ds_num);
AX1W32API BYTE __stdcall AX1_FDSStatusPriority(BYTE prevstatus,BYTE status);
AX1W32API VOID __stdcall AX1_FileClose();
AX1W32API BOOL __stdcall AX1_FileErr(VOID);
AX1W32API VOID __stdcall AX1_FileErrClr(VOID);
AX1W32API VOID __stdcall AX1_FileErrSet(VOID);
AX1W32API LPVOID __stdcall AX1_FileOpenRead(LPCSTR filename);
AX1W32API LPVOID __stdcall AX1_FileOpenWrite(LPCSTR filename);
AX1W32API BOOL __stdcall AX1_FileRead(LPVOID buffer,USHORT count);
AX1W32API BOOL __stdcall AX1_FileSeek(ULONG offset);
AX1W32API ULONG __stdcall AX1_FileTell();
AX1W32API BOOL __stdcall AX1_FileWrite(LPVOID buffer,USHORT count);
AX1W32API USHORT __stdcall AX1_GetHigh(ULONG val);
AX1W32API USHORT __stdcall AX1_GetLow(ULONG val);
AX1W32API ERRVAL __stdcall AX1_HandleClose(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleDel(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleGet(LPULONG addr0,LPULONG addr1,LPINT cardnum,LPINT devnum,LPULONG sizval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleIns(LPHCARD lpHandle,LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
AX1W32API BOOL __stdcall AX1_HandleOkay(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleOpen(LPCSTR cardname,INT cardnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleOpenWin95(LPCSTR cardname,INT cardnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleOpenWinNT(LPCSTR cardname,INT cardnum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_HandleVer(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernBegin(LPVOID* vxdptr,LPSTR cardstr,LPCSTR cardname,INT busnum,INT devnum,INT funcnum);
AX1W32API ERRVAL __stdcall AX1_KernDev(LPINT valueptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernEnd(LPVOID vxdptr);
AX1W32API ERRVAL __stdcall AX1_KernIntClear(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernIntInstall(LPVOID hEvent,ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernIntStatus(LPINT valueptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernIntUninstall(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernIORdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernIOWrW(USHORT value,INT addrval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMFillW(USHORT value,INT addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMRdB(LPBYTE valueptr,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMRdL(LPULONG valueptr,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMRdsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMRdsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMRdW(LPUSHORT valueptr,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMWrB(BYTE value,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMWrL(ULONG value,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMWrsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMWrsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernMEMWrW(USHORT value,INT addrval,INT bustype,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernQuick(BOOL flag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernStatus(LPULONG valueptr,ULONG type,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
AX1W32API ULONG __stdcall AX1_MakeLong(USHORT valh,USHORT vall);
AX1W32API ERRVAL __stdcall AX1_MantFromAscii(LPCSTR str,LPULONG mant,LPINT exp);
AX1W32API LPSTR __stdcall AX1_MantToAscii(LPSTR buf,INT mant,INT exp);
AX1W32API ULONG __stdcall AX1_Mask(ULONG dataval,INT cntval);
AX1W32API VOID __stdcall AX1_MaxMant(LPULONG mant,LPINT exp);
AX1W32API VOID __stdcall AX1_MEMWINFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
AX1W32API BYTE __stdcall AX1_MEMWINRdB(ULONG addrval,INT bustype,HCARD handleval);
AX1W32API ULONG __stdcall AX1_MEMWINRdL(ULONG addrval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINRdsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API USHORT __stdcall AX1_MEMWINRdW(ULONG addrval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINWrB(BYTE value,ULONG addrval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINWrsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
AX1W32API VOID __stdcall AX1_MEMWINWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
AX1W32API ULONG __stdcall AX1_Mod(ULONG moda,ULONG modb);
AX1W32API ULONG __stdcall AX1_Mul(ULONG mula,ULONG mulb);
AX1W32API ERRVAL __stdcall AX1_NetGetConfig(LPULONG pconfigval,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_NetSetConfig(ULONG configval,USHORT netid,HCARD handleval);
AX1W32API VOID __stdcall AX1_NormalMant(LPULONG mant,LPINT exp);
AX1W32API ERRVAL __stdcall AX1_ParamGetFrameFreq(LPULONG pconfigval,LPUSHORT ppercent,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PcapBegin(LPVOID* vxdptr,LPULONG addrlptr,LPULONG addrhptr,LPSTR cardstr,INT cardstrlen,INT devnum);
AX1W32API ERRVAL __stdcall AX1_PcapCheck();
AX1W32API ERRVAL __stdcall AX1_PcapCount(LPINT pcount);
AX1W32API ERRVAL __stdcall AX1_PcapEnd(LPVOID vxdptr);
AX1W32API ERRVAL __stdcall AX1_PcapStart(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PcapStop(HCARD handleval);
AX1W32API UINT __stdcall AX1_PcapWorkerEntry(LPVOID lpParam);
AX1W32API ERRVAL __stdcall AX1_PortConfigEx(ULONG configval,USHORT dstid,USHORT srcid,USHORT depth,USHORT reprate,LPHPORT portptr,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetAny(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortGetConfig(LPULONG pconfigval,HPORT hport,HCARD handleval);
AX1W32API BOOL __stdcall AX1_PortIsHostRcv(HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_PortSetConfig(ULONG configval,HPORT hport,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
AX1W32API BYTE __stdcall AX1_RAMRdB(ULONG addrval,HCARD handleval);
AX1W32API ULONG __stdcall AX1_RAMRdL(ULONG addrval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
AX1W32API USHORT __stdcall AX1_RAMRdW(ULONG addrval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWipe(HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWipeEx(USHORT value,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWrB(BYTE value,ULONG addrval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
AX1W32API VOID __stdcall AX1_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RcvHostGetEnable(LPBOOL penableval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RevArray32(LPBYTE data,ULONG length);
AX1W32API ERRVAL __stdcall AX1_RevWord64(LPBYTE data,ULONG offset);
AX1W32API ERRVAL __stdcall AX1_ROMInfoRd(LPBYTE buf,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_ROMInfoWr(LPBYTE buf,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardCheck(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardClean(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardDeviceInfoRd(ULONG index,LPULONG valueptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardIsRunning(LPBOOL bRunning,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardStart(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_CardStop(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DcrRdL(LPULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DcrWrL(ULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DefaultPortConfig(ULONG ctrlflags,USHORT netid,USHORT depth,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DefaultPortGetHandle(USHORT netid,LPHPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DetectPort(LPUSHORT portnum,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DetectVL(LPUSHORT vlid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DetectVLIgnore(USHORT vlid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_DmaParam(ULONG addrh,ULONG addrl,ULONG sizeattr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrCtrlConfig(ULONG configval,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrCtrlGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrNetEnable(USHORT netid,ULONG configval,USHORT trigid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrNetGetEnable(LPULONG pconfigval,LPUSHORT ptrigid,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrPktConfig(ULONG configval,ULONG blendflags,USHORT trigid,LPBYTE packet,USHORT pktlen,USHORT totallen,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrPktGetConfig(LPULONG pconfigval,LPULONG pblendflags,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrPktGetConfigEx(LPULONG pconfigval,LPULONG pblendflags,LPUSHORT ptrigid,LPBYTE packet,USHORT pktlen,LPUSHORT ptotallen,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrRSNConfig(ULONG configval,USHORT trigid,USHORT modifier,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrRSNGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,LPINT pmodifier,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrXmtConfig(ULONG configval,USHORT trigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ErrXmtGetConfig(LPULONG pconfigval,LPUSHORT ptrigid,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_EventConfig(ULONG configval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_EventGetConfig(LPULONG pconfigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FlashClose(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FlashErase(ULONG blocknum,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FlashOpen(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FlashRead(LPBYTE buf,ULONG addrval,ULONG length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FlashWrite(LPBYTE buf,ULONG addrval,ULONG length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_FrameGapConfig(ULONG configval,USHORT busnum,USHORT gapval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_IicRdL(LPVOID data,BYTE devaddr,ULONG count,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_IicWrL(LPVOID data,BYTE devaddr,ULONG count,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_IntTrig(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MemRdL(LPULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MemRdsB(ULONG addr,ULONG length,LPBYTE data,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MemRdsL(ULONG addr,ULONG length,LPULONG data,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MemWrL(ULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MIBGetNetInfo(USHORT mibtype,USHORT busnum,LPBYTE data,ULONG length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MIBGetPortInfo(HPORT hport,LPBYTE data,ULONG length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_MIBGetVLInfo(HVL hvl,USHORT mibtype,LPBYTE data,ULONG length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetConfig(ULONG configval,USHORT netid,ULONG macconst,USHORT speed,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetFlood(BOOL bEnable,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetGetConfig(LPULONG pconfigval,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetGetVLCount(USHORT netid,LPUSHORT pvlcount,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetSetConfig(ULONG configval,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_NetSetInterfaceID(USHORT netid,USHORT idVal,USHORT flags,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ParamFrameFreq(ULONG configval,USHORT percent,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_ParamGetFrameFreq(LPULONG pconfigval,LPUSHORT ppercent,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortConfig(ULONG configval,HVL hvl,USHORT dstid,USHORT srcid,USHORT depth,USHORT reprate,LPHPORT portptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortDataRd(HPORT hport,LPBYTE data,LPUSHORT lengthptr,LPBYTE rsnptr,LPULONG timetaghptr,LPULONG timetagptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortDataWr(HPORT hport,LPBYTE data,USHORT length,BYTE rsn,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetAny(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetConfig(LPULONG pconfigval,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetHandle(HVL hvl,USHORT portnum,LPHPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetInfo(HPORT hport,LPULONG configval,LPUSHORT vlid,LPUSHORT dstport,LPUSHORT srcport,LPUSHORT depth,LPUSHORT reprate,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetNext(HVL hvl,LPUSHORT nextPort,USHORT lastPort,USHORT flag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortGetQueueCount(HPORT hport,LPUSHORT queuecount,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortInfoRd(LPULONG timetaghptr,LPULONG timetagptr,LPULONG activityptr,LPULONG errorptr,LPBYTE rsnptr,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortRawRd(HPORT hport,LPBYTE packet,LPUSHORT lengthptr,LPULONG timetaghptr,LPULONG timetagptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortRawWr(HPORT hport,LPBYTE packet,USHORT length,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortRd(HPORT hport,LPAFDXPKTDESC pktdesc,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortSetConfig(ULONG configval,HPORT hport,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortSkipConfig(HPORT hport,ULONG ctrlflags,USHORT trigid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_PortStepConfig(HPORT hport,ULONG ctrlflags,USHORT trigid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_RcvHostEnable(BOOL enableval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_RcvHostGetEnable(LPBOOL penableval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_RedundConfig(ULONG configval,USHORT pairid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_RobinAddPort(HSCHED hrobin,HPORT hport,BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedAddNoop(USHORT netid,BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedAddPort(USHORT netid,HPORT hport,BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedAddRobin(USHORT netid,HSCHED hsub,BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedAddSub(USHORT netid,HSCHED hsub,BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedClear(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedCrtRobin(LPHSCHED hrobin,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedCrtSub(LPHSCHED hsub,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedFrameEnd(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedFrameStart(USHORT netid,ULONG usframetime,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SchedItemUpdate(HSCHEDITEM hscheditem,BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SdrRdL(LPULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SdrWrL(ULONG data,ULONG addr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqClear(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqConfig(ULONG configval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqGetConfig(LPULONG pconfigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqRd(LPBYTE buf,LPULONG bufcount,LPINT reccount,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqSetConfig(ULONG configval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqSetMonitor(USHORT netid,USHORT vlid,BOOL bmonitor,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SeqStatus(LPUSHORT statusptr,LPULONG headptr,LPULONG tailptr,LPULONG configptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SubAddNoop(HSCHED hsub,BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SubAddPort(HSCHED hsub,HPORT hport,BOOL bSkip,BOOL bShot,BOOL bTxA,BOOL bTxB,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_SubAddRobin(HSCHED hsub,HSCHED hrobin,BOOL bSkip,BOOL bShot,LPHSCHEDITEM hscheditem,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_Test1(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_Test2(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_Test3(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_Test4(HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_TrigClearBits(ULONG bits,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_TrigGetVal(LPULONG trigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_TrigSetBits(ULONG bits,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_TrigSetVal(ULONG trigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_TrigSinkConfig(USHORT trigid,ULONG ctrlflags,ULONG ulComp,ULONG ulMask,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLConfig(ULONG configval,USHORT netid,USHORT vlid,ADDRESS macsrc,ULONG ipdst,ULONG ipsrc,ULONG bag,ULONG skewmax,LPHVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLConfigMAC(ULONG configval,USHORT netid,ADDRESS macdst,ADDRESS macsrc,ULONG ipdst,ULONG ipsrc,ULONG bag,ULONG skewmax,LPHVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetConfig(LPULONG pconfigval,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetFactor(LPINT pfactor0,LPINT pfactor1,LPINT pfactor2,LPINT pfactor3,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetHandle(USHORT netid,USHORT vlid,LPHVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetHandleMAC(USHORT netid,LPADDRESS pmacdst,LPHVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetInfo(HVL hvl,LPUSHORT vlid,LPADDRESS pmacdst,LPADDRESS pmacsrc,LPULONG pconfigval,LPULONG ipdst,LPULONG ipsrc,LPULONG bag_us,LPULONG skewmax,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetJitter(BOOL bReset,LPULONG pJitA,LPULONG pJitB,LPULONG pMaxJitA,LPULONG pMaxJitB,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetNext(USHORT netid,LPUSHORT nextVL,USHORT lastVL,USHORT flag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetNextMAC(USHORT netid,LPADDRESS nextMAC,ADDRESS lastMAC,USHORT flag,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLGetPortCount(HVL hvl,LPUSHORT portcnt,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLSetConfig(ULONG configval,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_RPC_VLSetFactor(INT factor0,INT factor1,INT factor2,INT factor3,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedBuildEx(INT vlcount,LPBOOL vlrobins,LPHVL hvls,LPINT vlperiods_us,LPINT vlfactors,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedCalc(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedClear(USHORT netid,HCARD handleval);
AX1W32API VOID __stdcall AX1_SchedDebug(BOOL debug);
AX1W32API VOID __stdcall AX1_SchedDisplay(ULONG nummsgs,LPULONG count,LPULONG* data);
AX1W32API ERRVAL __stdcall AX1_SchedDoFrameEnd(ULONG frametime_us,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoFrameInsert(INT index,HSCHED hsub,HVL hvl,ULONG frametime_us,ULONG eventindex,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoFrameStart(ULONG frametime_us,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoRobinEnd(HSCHED hsub,HSCHED hrobin,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoRobinInsert(HSCHED hsub,HSCHED hrobin,INT index,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoRobinStart(LPHSCHED phsub,LPHSCHED phrobin,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoSchedEnd(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoSchedStart(USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoSubVLEnd(HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoSubVLInsert(HSCHED hsub,LPHSCHED hrobins,ULONG eventindex,ULONG preveventindex,INT index,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedDoSubVLStart(LPHSCHED phsub,LPHSCHED hrobins,LPINT vlfactors,LPINT vlmods,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SchedFactor(LPHSCHED phsub,LPINT vlfactors,HVL hvl,HCARD handleval);
AX1W32API VOID __stdcall AX1_SchedHook(INT index,VOID (*ptr)());
AX1W32API ULONG __stdcall AX1_SchedMaxval(LPULONG array,ULONG arraycount);
AX1W32API ULONG __stdcall AX1_SchedMinval(LPULONG array,ULONG arraycount);
AX1W32API VOID __stdcall AX1_SchedModval(LPINT vlfactors,LPINT vlmods);
AX1W32API VOID __stdcall AX1_SchedPrint(LPSTR str,...);
AX1W32API INT __stdcall AX1_SeqDMARd(LPBYTE bufptr,LPULONG bufcountptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqDMARdEx(LPBYTE bufptr,LPULONG bufcountptr,LPINT reccountptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqGetConfig(LPULONG pconfigval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqRdEx(LPBYTE bufptr,LPULONG bufcountptr,LPINT reccountptr,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqSetConfig(ULONG configval,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_SeqStatusEx(LPUSHORT statusptr,LPULONG headptr,LPULONG tailptr,LPULONG configptr,HCARD handleval);
AX1W32API ULONG __stdcall AX1_Shl(ULONG dataval,INT cntval);
AX1W32API ULONG __stdcall AX1_Shr(ULONG dataval,INT cntval);
AX1W32API USHORT __stdcall AX1_SignMant(LPCSTR str);
AX1W32API USHORT __stdcall AX1_Transpose12(USHORT val);
AX1W32API INT __stdcall AX1_ValAsciiCmpi(LPSTR str1,LPSTR str2);
AX1W32API LPSTR __stdcall AX1_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
AX1W32API VOID __stdcall AX1_ValAsciiTrimLead(LPSTR buf);
AX1W32API VOID __stdcall AX1_ValAsciiTrimTrail(LPSTR buf);
AX1W32API ULONG __stdcall AX1_ValFromAscii(LPCSTR asciistr,INT radixval);
AX1W32API ULONG __stdcall AX1_ValGetBits(ULONG oldvalue,INT startbit,INT endbit);
AX1W32API LPSTR __stdcall AX1_ValIncAscii(LPSTR asciistr);
AX1W32API LPSTR __stdcall AX1_ValInccAscii(LPSTR asciistr);
AX1W32API BOOL __stdcall AX1_ValIsLower(INT value);
AX1W32API INT __stdcall AX1_ValLenAscii(INT numbits,INT radixval);
AX1W32API ULONG __stdcall AX1_ValPutBits(ULONG oldvalue,ULONG newfld,INT startbit,INT endbit);
AX1W32API LPSTR __stdcall AX1_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
AX1W32API INT __stdcall AX1_ValToUpper(INT value);
AX1W32API ERRVAL __stdcall AX1_VLConfigEx(ULONG configval,USHORT vlid,ULONG bag_us,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLConfigExx(ULONG configval,USHORT vlid,ADDRESS macsrc,ULONG ipdst,ULONG ipsrc,ULONG bag_us,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLConfigMACEx(ULONG configval,ADDRESS macdst,ULONG bag_us,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLConfigMACExx(ULONG configval,ADDRESS macdst,ADDRESS macsrc,ULONG ipdst,ULONG ipsrc,ULONG bag_us,ULONG skewmax,LPHVL hvl,USHORT netid,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetConfig(LPULONG pconfigval,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetFactors(LPINT pfactor0,LPINT pfactor1,LPINT pfactor2,LPINT pfactor3,HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLGetInfoEx(LPULONG configval,LPUSHORT vlid,LPADDRESS pmacdst,LPADDRESS pmacsrc,LPULONG ipdst,LPULONG ipsrc,LPULONG bag_us,LPULONG skew,HVL hvl,HCARD handleval);
AX1W32API BOOL __stdcall AX1_VLIsHostRcv(HVL hvl,HCARD handleval);
AX1W32API ERRVAL __stdcall AX1_VLSetConfig(ULONG configval,HVL hvl,HCARD handleval);

#ifdef __cplusplus
}
#endif

#endif /* #ifndef __AX1W32_H */
