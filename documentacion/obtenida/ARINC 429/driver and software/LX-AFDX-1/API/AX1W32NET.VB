Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices

Module AX1W32VB

    '**
    '*
    '*  Lx-AFDX-1 WIN32 DRIVER  Version 1.4  (01/15/2009)
    '*  Copyright (c) 2005-2009
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   AX1W32NET.VB -- Visual Basic .NET
    '*                          Lx-AFDX-1 Driver Header File.
    '*
    '**

    '**
    '*
    '*  This file defines the functions and subroutines provided
    '*  by the 32-bit Driver Library for the Lx-AFDX-1.  Visual Basic
    '*  applications using the Lx-AFDX-1 Driver Library must
    '*  incorporate this text file into the Visual Basic project.
    '*
    '**

    '/**************************
    '*
    '*   Constants
    '*
    '**************************/

    Public Const MAX_AFDXPAYLOAD As Integer = 1471                'Max Payload Size defined for valid AFDX Frames - not including RSN byte
    Public Const MIN_AFDXPAYLOAD As Integer = 17                  'Min Payload Size defined for valid AFDX Frames - not including RSN byte
    Public Const MAX_UDPPAYLOAD As Integer = 1472                'Max Payload Size defined for valid UDP Frames - includes RSN byte
    Public Const MIN_UDPPAYLOAD As Integer = 18                  'Min Payload Size defined for valid UDP Frames - includes RSN byte
    Public Const MAX_AFDXPACKETSIZE As Integer = 1514                'Max size of VALID AFDX transmit/receive packets (in bytes)
    Public Const MIN_PACKETBUFSIZE As Integer = 60                  'Min size of buffer used to transmit packets (in bytes)
    Public Const MAX_SEQRDBUFSIZE As Integer = &HFD000             'Max buffer size for SeqRd functions

    Public Const HEADERLEN_MAC As Integer = 14                                         'MAC header length = Destination(6bytes)+Source(6)+Type(2)
    Public Const HEADERLEN_IP As Integer = 20                                         'IP header length
    Public Const HEADERLEN_UDP As Integer = 8                                          'UDP header length = SourcePort(2bytes)+DestPort(2)+Len(2)+CRC(2)
    Public Const HEADERLEN_ALL As Integer = (HEADERLEN_MAC + HEADERLEN_IP + HEADERLEN_UDP) 'Length of all headers (14+20+8=42) for IPV4 UDP packets

    Public Const DESCOFFSET_PKT As Integer = 32                      'Offset of packet in AFDX packet descriptor
    Public Const DESCOFFSET_HDR As Integer = 32                      'Offset of header in AFDX packet descriptor header

    Public Const MACLOCALMULTICAST_MASK As Integer = &H3000000         'Group and the locally administered bits (upper 32-byte mask - constant portion)

    'Network ID

    Public Const NETID_REDUND As Integer = &H0             'AFDX Redundant Network
    Public Const NETID_INDEPENDA As Integer = &H1             'AFDX Network A
    Public Const NETID_INDEPENDB As Integer = &H2             'AFDX Network B

    'Bus Numbers

    Public Const BUS_A As Integer = &H0                        'AFDX Bus A
    Public Const BUS_B As Integer = &H1                        'AFDX Bus B

    'Interface ID

    Public Const INTID_DEFAULT As Integer = &H0                'Use the default Interface ID
    Public Const INTID_BUS_A As Integer = &H1                'Interface ID Network A
    Public Const INTID_BUS_B As Integer = &H2                'Interface ID Network B

    'Packet Byte Offsets

    Public Const OFFSET_UDPDATA As Integer = 42
    Public Const DSSTATUS_ND As Integer = 0
    Public Const DSSTATUS_NO As Integer = 3
    Public Const DSSTATUS_FT As Integer = 12
    Public Const DSSTATUS_NCD As Integer = 48

    '/**
    '*
    '*   Triggers
    '*
    '**/

    Public Const TRIGSINK_COUNT As Integer = 8

    Public Const TRIGID_1 As Integer = &H0
    Public Const TRIGID_2 As Integer = &H1
    Public Const TRIGID_3 As Integer = &H2
    Public Const TRIGID_4 As Integer = &H3
    Public Const TRIGID_5 As Integer = &H4
    Public Const TRIGID_6 As Integer = &H5
    Public Const TRIGID_7 As Integer = &H6
    Public Const TRIGID_8 As Integer = &H7

    Public Const TSOURCE_DISABLE As Integer = &H0
    Public Const TSOURCE_ENABLE As Integer = &H1
    Public Const TSOURCE_SET As Integer = &H0
    Public Const TSOURCE_CLEAR As Integer = &H2

    Public Const TSINK_DISABLE As Integer = &H0
    Public Const TSINK_ENABLE As Integer = &H1
    Public Const TSINK_SHOT As Integer = &H2

    Public Const PORTTRIG_DISABLE As Integer = &H0
    Public Const PORTTRIG_ENABLE As Integer = &H1

    '/**
    '*
    '*   Error Injection
    '*
    '**/

    Public Const ERRCTRL_DISABLE As Integer = &H0      'Disable Control Errors
    Public Const ERRCTRL_ENABLE As Integer = &H1      'Enable Control Errors
    Public Const ERRCTRL_TRIGGER As Integer = &H2      'Use triggering
    Public Const ERRCTRL_INVERSEENABLEA As Integer = &H4      'Invert the enable flag for network A
    Public Const ERRCTRL_INVERSEENABLEB As Integer = &H8      'Invert the enable flag for network B
    Public Const ERRCTRL_INVERSEORDER As Integer = &H10     'Invert the transmit order of networks
    Public Const ERRCTRL_SINGLSHOT As Integer = &H20     'Transmit the error one time

    Public Const ERRNET_DISABLE As Integer = &H0      'Disable Error Injection for the network
    Public Const ERRNET_ENABLE As Integer = &H1      'Enable Error Injection for the network
    Public Const ERRNET_TRIGGER As Integer = &H2      'Use triggering

    Public Const ERRPKT_DISABLE As Integer = &H0      'Disable Packet Errors
    Public Const ERRPKT_ENABLE As Integer = &H1      'Enable Packet Errors
    Public Const ERRPKT_TRIGGER As Integer = &H2      'Use triggering
    Public Const ERRPKT_NOAUTOCRCIP As Integer = &H4      'Disable auto checksum calculations for the IP header
    Public Const ERRPKT_NOAUTOCRCUDP As Integer = &H8      'Disable auto checksum calculations for the UDP header
    Public Const ERRPKT_NOAUTOINTID As Integer = &H10     'Disable auto insertion of interface ID in MAC source address
    Public Const ERRPKT_BLEND As Integer = &H20     'Blend the result packet with the error packet
    Public Const ERRPKT_CRCIPERROR As Integer = &H40     'Force an IP checksum error
    Public Const ERRPKT_CRCUDPERROR As Integer = &H80     'Force a UDP checksum error
    Public Const ERRPKT_SINGLSHOT As Integer = &H100    'Transmit the error one time

    Public Const BLEND_NONE As Integer = &H0      'No blending
    Public Const BLEND_ERRMAC As Integer = &H1      'Result will contain the error packet MAC header
    Public Const BLEND_ERRINTID As Integer = &H2      'Result will contain the error packet Interface ID
    Public Const BLEND_ERRIP As Integer = &H4      'Result will contain the error packet IP header
    Public Const BLEND_ERRIPLEN As Integer = &H8      'Result will contain the error packet IP length
    Public Const BLEND_ERRUDP As Integer = &H10     'Result will contain the error packet UDP header
    Public Const BLEND_ERRUDPLEN As Integer = &H20     'Result will contain the error packet UDP length
    Public Const BLEND_ERRDATA As Integer = &H40     'Result will contain the error packet AFDX payload data

    Public Const ERRRSN_DISABLE As Integer = &H0      'Disable RSN Error Injection
    Public Const ERRRSN_ENABLE As Integer = &H1      'Enable RSN Error Injection
    Public Const ERRRSN_TRIGGER As Integer = &H2      'Use triggering
    Public Const ERRRSN_STEP As Integer = &H0      'Adjust the RSN and change the sequence to continue from this new value
    Public Const ERRRSN_IMPULSE As Integer = &H4      'Adjust the RSN for this instance only
    Public Const ERRRSN_ABSOLUTE As Integer = &H0      'Use modifier as the RSN
    Public Const ERRRSN_RELATIVE As Integer = &H8      'Add modifier to the RSN
    Public Const ERRRSN_SINGLSHOT As Integer = &H10     'Transmit the error one time
    Public Const ERRRSN_MODE1 As Integer = &H6      'SHOT+ABSOLUTE+IMPULSE
    Public Const ERRRSN_MODE2 As Integer = &HE      'SHOT+RELATIVE+IMPULSE
    Public Const ERRRSN_MODE3 As Integer = &H2      'SHOT+ABSOLUTE+STEP
    Public Const ERRRSN_MODE4 As Integer = &HA      'SHOT+RELATIVE+STEP
    Public Const ERRRSN_MODE5 As Integer = &HC      'RELATIVE+IMPULSE
    Public Const ERRRSN_MODE6 As Integer = &H4      'ABSOLUTE+IMPULSE
    Public Const ERRRSN_MODE7 As Integer = &H8      'RELATIVE+STEP
    Public Const ERRRSN_MODE8 As Integer = &H0      'ABSOLUTE+STEP

    Public Const ERRXMT_ENABLE As Integer = &H1      'Enable transmit Error Injection
    Public Const ERRXMT_TRIGGER As Integer = &H2      'Use triggering
    Public Const ERRXMT_STUTTER As Integer = &H0      'Send a duplicate packet immediately
    Public Const ERRXMT_REPEAT As Integer = &H4      'Send the next packet immediately
    Public Const ERRXMT_SINGLSHOT As Integer = &H8      'Transmit the error one time

    '/**
    '*
    '*  Interframe Gap Flags
    '*
    '**/

    Public Const FRAMEGAP_DEFAULT As Integer = &H0
    Public Const FRAMEGAP_SETNEW As Integer = &H1

    '/**
    '*
    '*  Parametric Frame Frequency
    '*
    '**/

    Public Const PARAMFREQ_DISABLE As Integer = &H0
    Public Const PARAMFREQ_ENABLE As Integer = &H1

    '/**
    '*
    '*  MIB type constants
    '*
    '**/

    Public Const MIBTYPE_EQUIP As Integer = &H0     'Equipment info
    Public Const MIBTYPE_MAC_UNDEF As Integer = &H1     'Undefined MAC constant info
    Public Const MIBTYPE_REDERR As Integer = &H2     'Redundancy errors
    Public Const MIBTYPE_REDSTAT As Integer = &H4     'Redundancy statistics
    Public Const MIBTYPE_IP As Integer = &H8     'IP header info
    Public Const MIBTYPE_UDP As Integer = &H10    'UDP header info
    Public Const MIBTYPE_SCHED As Integer = &H20    'Transmit schedule info
    Public Const MIBTYPE_TCP As Integer = &H40    'TCP info
    Public Const MIBTYPE_ESFAIL As Integer = &H80    'End system failure info
    Public Const MIBTYPE_MAC_A As Integer = &H100   'MAC for channel A
    Public Const MIBTYPE_MAC_B As Integer = &H200   'MAC for channel B
    Public Const MIBTYPE_REDSTAT_A As Integer = &H400   'Statistics for redundant channel A
    Public Const MIBTYPE_REDSTAT_B As Integer = &H800   'Statistics for redundant channel B

    '/**
    '*
    '*  Enumeration constants
    '*
    '**/

    Public Const GETNEXT_ROOT As Integer = &H1
    Public Const GETNEXT_NEXT As Integer = &H2

    '/**
    '*
    '*   Bit fields of the packet activity flags
    '*
    '**/

    Public Const PKTACT_NETB As Integer = &H1
    Public Const PKTACT_NOVL As Integer = &H2
    Public Const PKTACT_MACMISMATCH As Integer = &H4
    Public Const PKTACT_BAGVIOLATION As Integer = &H8
    Public Const PKTACT_NOPORT As Integer = &H10
    Public Const PKTACT_INTEGRITYFAIL As Integer = &H20
    Public Const PKTACT_REDUNDANTREJECT As Integer = &H40
    Public Const PKTACT_TIMEOUT As Integer = &H80
    Public Const PKTACT_DUPRSNALTNET As Integer = &H100
    Public Const PKTACT_DUPRSNSAMENET As Integer = &H200
    Public Const PKTACT_SEQRSNERR As Integer = &H400
    Public Const PKTACT_PARKED As Integer = &H800
    Public Const PKTACT_INTIDMISMATCH As Integer = &H1000
    Public Const PKTACT_UNICAST As Integer = &H2000
    Public Const PKTACT_TRANSMIT As Integer = &H4000
    Public Const PKTACT_SKEWMAXERR As Integer = &H8000

    '/**
    '*
    '*   Bit fields of the packet error flags
    '*
    '**/

    Public Const PKTERR_FRAMELENGTH As Integer = &H1
    Public Const PKTERR_IPTYPE As Integer = &H2
    Public Const PKTERR_IPVERSION As Integer = &H4
    Public Const PKTERR_IPLENGTH As Integer = &H8
    Public Const PKTERR_IPTOS As Integer = &H10
    Public Const PKTERR_IPFRAG As Integer = &H20
    Public Const PKTERR_IPPROTOCOL As Integer = &H40
    Public Const PKTERR_IPCRC As Integer = &H80
    Public Const PKTERR_IPSOURCE As Integer = &H100
    Public Const PKTERR_IPDESTINATION As Integer = &H200
    Public Const PKTERR_UDPLENGTH As Integer = &H400
    Public Const PKTERR_UDPCRC As Integer = &H800
    Public Const PKTERR_UDPSOURCE As Integer = &H1000
    Public Const PKTERR_MAC As Integer = &H2000
    Public Const PKTERR_XMTVL As Integer = &H4000
    Public Const PKTERR_IPERRMASK As Integer = (PKTERR_IPTYPE + PKTERR_IPVERSION + PKTERR_IPLENGTH + PKTERR_IPTOS + PKTERR_IPFRAG + PKTERR_IPPROTOCOL + PKTERR_IPCRC + PKTERR_IPSOURCE + PKTERR_IPDESTINATION)
    Public Const PKTERR_UDPERRMASK As Integer = (PKTERR_UDPLENGTH + PKTERR_UDPCRC + PKTERR_UDPSOURCE)

    '/**
    '*
    '*   Sequential status flags.
    '*
    '**/

    Public Const SEQSTAT_OFF As Integer = &H1              'Sequntial is off
    Public Const SEQSTAT_EMPTY As Integer = &H2              'Sequntial buffer is empty
    Public Const SEQSTAT_PARTIAL As Integer = &H4              'Sequntial buffer is partially filled
    Public Const SEQSTAT_PAUSED As Integer = &H8              'Sequntial buffer is paused

    '/**
    '*
    '*   Sequential record type
    '*
    '**/

    Public Const SEQTYPE_UDPNOPAYLOAD As Integer = &H10             'UDP record without UDP payload (MAC header + IP header + UDP header + RSN value) [43 BYTES recorded: 42 byte header + 1byte RSN]
    Public Const SEQTYPE_UDPFULL As Integer = &H11             'UDP record with full packet
    Public Const SEQTYPE_OTHERPARTIAL As Integer = &H20             'Non-standard IPv4 Type (&H0800) packet - only the first 42 bytes recorded
    Public Const SEQTYPE_OTHERFULL As Integer = &H21             'Non-UDP records with full packet

    Public Const SEQTYPE_MASK As Integer = &HFF

    '/**
    '*
    '*  Rendundant configuration options
    '*
    '**/

    Public Const RDNDCFG_DEFAULT As Integer = &H0         'Select all default settings
    Public Const RDNDCFG_REDUNDANT As Integer = &H0         'Use redundant networks
    Public Const RNDDCFG_INDEPEND As Integer = &H1         'Use independent networks

    '/**
    '*
    '*  Network configuration options
    '*
    '**/

    Public Const NETCFG_DEFAULT As Integer = &H0         'Select all default settings
    Public Const NETCFG_ACTIVE As Integer = &H0         'Enable network activity (default)
    Public Const NETCFG_INACTIVE As Integer = &H1         'Disable network activity
    Public Const NETCFG_ACTREDUNDA As Integer = &H0         'Enable network activity for redundant network's Bus A (default)
    Public Const NETCFG_INACTREDUNDA As Integer = &H80000000  'Disable network activity for redundant network's Bus A (only applies to redundant networks)
    Public Const NETCFG_ACTREDUNDB As Integer = &H0         'Enable network activity for redundant network's Bus B (default)
    Public Const NETCFG_INACTREDUNDB As Integer = &H40000000  'Disable network activity for redundant network's Bus B (only applies to redundant networks)
    Public Const NETCFG_NOEVENTVLMISS As Integer = &H0         'VL does not generate events when an unconfigured port is received
    Public Const NETCFG_EVENTVLMISS As Integer = &H2         'VL generates events when an unconfigured port is received
    Public Const NETCFG_SEQSEL As Integer = &H0         'Sequential record recording is enabled at the VL or Port level (default)
    Public Const NETCFG_SEQALL As Integer = &H4         'Record all packets in sequential monitor
    Public Const NETCFG_DEFMAC As Integer = &H0         'Use default network MAC constant
    Public Const NETCFG_USERMAC As Integer = &H10        'Use user supplied MAC constant

    '/**
    '*
    '*  Network pause options
    '*
    '**/

    Public Const NETPAUS_FALSE As Integer = &H0
    Public Const NETPAUS_TRUE As Integer = &H1

    '/**
    '*
    '*  Network speed options
    '*
    '**/

    Public Const NETSPEED_AUTO As Integer = 0                   'Speed auto-detection is used (limited to 10/100 Mbits/sec)
    Public Const NETSPEED_AUTO10100 As Integer = 0                   'Speed auto-detection is used (limited to 10/100 Mbits/sec)
    Public Const NETSPEED_AUTO101001000 As Integer = 1110                'Speed auto-detection is used (10/100/1000)
    Public Const NETSPEED_AUTOALL As Integer = 1110                'Speed auto-detection is used (10/100/1000)
    Public Const NETSPEED_10 As Integer = 10                  '10 Mbits/sec
    Public Const NETSPEED_100 As Integer = 100                 '100 Mbits/sec
    Public Const NETSPEED_1000 As Integer = 1000                '1000 Mbits/sec

    '/**
    '*
    '*  Sequential Record configuration options
    '*
    '**/

    Public Const SEQCFG_DEFAULT As Integer = &H0        'Select all default settings
    Public Const SEQCFG_ENABLE As Integer = &H0        'Enable sequential record (default)
    Public Const SEQCFG_DISABLE As Integer = &H1        'Disable sequential record
    Public Const SEQCFG_SELECT As Integer = &H0        'Sequential record recording is enabled at the network  VL or port level (default)
    Public Const SEQCFG_ALL As Integer = &H2        'Record all packets to the sequential record
    Public Const SEQCFG_BOTHIN As Integer = &H0        'Record both redundant packets
    Public Const SEQCFG_FIRSTIN As Integer = &H4        'Record only first redundant packet
    Public Const SEQCFG_VALID As Integer = &H4        'Deprecated, use SEQCFG_FIRSTIN
    Public Const SEQCFG_REJINVALID As Integer = &H0        'Do not record packets with errors or no definitions
    Public Const SEQCFG_INCINVALID As Integer = &H8        'Also record packets with errors or no definitions
    Public Const SEQCFG_PAYLOAD As Integer = &H0        'Record entire packet (default)
    Public Const SEQCFG_NOPAYLOAD As Integer = &H80       'Only record the header info. Entire packet recorded for non-UDP packets
    Public Const SEQCFG_FILLHALT As Integer = &H0        'Enable fill and halt mode (default)
    Public Const SEQCFG_CONTINUOUS As Integer = &H100      'Keeps recording even if full
    Public Const SEQCFG_ANYPROT As Integer = &H0        'Any protocol (IP) is recorded (default)
    Public Const SEQCFG_IPPROTOFF As Integer = &H1000     'IP protocol packets are NOT recorded
    Public Const SEQCFG_ICMPPROTOFF As Integer = &H2000     'ICMP IP protocol packets are NOT recorded
    Public Const SEQCFG_IGMPPROTOFF As Integer = &H4000     'IGMP IP protocol packets are NOT recorded
    Public Const SEQCFG_TCPPROTOFF As Integer = &H8000     'TCP IP protocol packets are NOT recorded
    Public Const SEQCFG_UDPPROTOFF As Integer = &H10000    'UDP IP protocol packets are NOT recorded
    Public Const SEQCFG_RAWPROTOFF As Integer = &H20000    'RAW IP protocol packets are NOT recorded
    Public Const SEQCFG_OTHERPROTOFF As Integer = &H40000    'Non IP,ICMP,IGMP,TCP,UDP, or RAW IP protocol packets are NOT recorded
    Public Const SEQCFG_UNPAUSED As Integer = &H0        'Sequential record is unpaused
    Public Const SEQCFG_PAUSED As Integer = &H100000   'Sequential record is paused
    Public Const SEQCFG_DMA As Integer = &H200000   'Send sequential record to DMA

    '/**
    '*
    '*  Virtual Link configuration options
    '*
    '**/

    Public Const VLCFG_DEFAULT As Integer = &H0         'Select all default settings
    Public Const VLCFG_RCV As Integer = &H0         'Receive VL (default)
    Public Const VLCFG_TX As Integer = &H1         'Transmit VL
    Public Const VLCFG_REDUNON As Integer = &H0         'Set redundancy on (default)
    Public Const VLCFG_REDUNOFF As Integer = &H2         'Set redundancy off
    Public Const VLCFG_SEQSEL As Integer = &H0         'Sequential record recording is enabled at the port level (default) (default)
    Public Const VLCFG_SEQALL As Integer = &H4         'Record all packets in sequential monitor
    Public Const VLCFG_NETAON As Integer = &H0         'Network A is enabled (default)
    Public Const VLCFG_NETAOFF As Integer = &H8         'Network A is disabled
    Public Const VLCFG_NETBON As Integer = &H0         'Network B is enabled (default)
    Public Const VLCFG_NETBOFF As Integer = &H10        'Network B is disabled
    Public Const VLCFG_AUTORSN As Integer = &H0         'Updating sequence numbering is automaticaly done (default)
    Public Const VLCFG_NOAUTORSN As Integer = &H20        'Updating sequence numbering is the users responsibility
    Public Const VLCFG_INTEGAON As Integer = &H0         'Integrity checking is enabled on NET A (rx only) (default)
    Public Const VLCFG_INTEGAOFF As Integer = &H40        'Integrity checking is disabled on NET A (rx only)
    Public Const VLCFG_INTEGBON As Integer = &H0         'Integrity checking is enabled on NET B (rx only) (default)
    Public Const VLCFG_INTEGBOFF As Integer = &H80        'Integrity checking is disabled on NET B (rx only)
    Public Const VLCFG_SUBVLRR As Integer = &H0         'Schedule sub-VLs (Tx) using a Round Robin scheme, VL rep-rate (default)
    Public Const VLCFG_SUBVLFACTOR As Integer = &H100       'Schedule sub-VLs (Tx) individually using timing factors
    Public Const VLCFG_FRMERRENA As Integer = &H200       'Enable frame errors on network A
    Public Const VLCFG_FRMERRENB As Integer = &H400       'Enable frame errors on network B
    Public Const VLCFG_AUTOINTID As Integer = &H0         'Enable auto Interface ID in source MAC address
    Public Const VLCFG_NOAUTOINTID As Integer = &H800       'Disable auto Interface ID in source MAC address
    Public Const VLCFG_AUTOCRCIP As Integer = &H0         'Enable auto checksum calculations for IP header
    Public Const VLCFG_NOAUTOCRCIP As Integer = &H1000      'Disable auto checksum calculations for IP header
    Public Const VLCFG_AUTOCRCUDP As Integer = &H0         'Enable auto checksum calculations for IP header
    Public Const VLCFG_NOAUTOCRCUDP As Integer = &H2000      'Disable auto checksum calculations for IP header
    Public Const VLCFG_NOJITTERCALC As Integer = &H0         'Disable jitter calculations
    Public Const VLCFG_JITTERCALC As Integer = &H4000      'Enable jitter calculations
    Public Const VLCFG_NOEVENTHIT As Integer = &H0         'VL does not generate events when hit
    Public Const VLCFG_EVENTHIT As Integer = &H8000      'VL generates events when hit
    Public Const VLCFG_NOEVENTPORTMISS As Integer = &H0         'VL does not generate events when an unconfigured port is received
    Public Const VLCFG_EVENTPORTMISS As Integer = &H10000     'VL generates events when an unconfigured port is received

    '/**
    '*
    '*  Port configuration options
    '*
    '**/

    Public Const PORTCFG_DEFAULT As Integer = &H0         'Select all default settings
    Public Const PORTCFG_ENABLE As Integer = &H0         'Port is enabled (default)
    Public Const PORTCFG_DISABLE As Integer = &H200       'Port is disabled (data is not written to rcv port, xmt port not scheduled)
    Public Const PORTCFG_AFDX As Integer = &H0         'Port will be AFDX (default)
    Public Const PORTCFG_SAP As Integer = &H1         'Port will be SAP
    Public Const PORTCFG_SAMPLE As Integer = &H0         'Port will use sampling (default)
    Public Const PORTCFG_QUEUE As Integer = &H2         'Port will use queueing
    Public Const PORTCFG_NETAON As Integer = &H0         'Network A will be enabled (default)
    Public Const PORTCFG_NETAOFF As Integer = &H4         'Network A will be disabled
    Public Const PORTCFG_NETBON As Integer = &H0         'Network B will be enabled (default)
    Public Const PORTCFG_NETBOFF As Integer = &H8         'Network B will be disabled
    Public Const PORTCFG_NOSEQ As Integer = &H0         'Packets will not be recorded to the sequential monitor (default)
    Public Const PORTCFG_SEQ As Integer = &H10        'Packets will be recorded to the sequential monitor
    Public Const PORTCFG_NOSKIP As Integer = &H0         'Port will not be skipped (tx only) (default)
    Public Const PORTCFG_SKIP As Integer = &H20        'Port will be set to skip (tx only)
    Public Const PORTCFG_NOTIMETAG As Integer = &H0         'Packets will not be time-taged  (default)
    Public Const PORTCFG_TIMETAG As Integer = &H40        'Packets will be time-taged
    Public Const PORTCFG_TXAB4B As Integer = &H0         'Network A will be sent before B when redundant (default)
    Public Const PORTCFG_TXBB4A As Integer = &H80        'Network A will be sent before B when redundant
    Public Const PORTCFG_SRCPORTCHK As Integer = &H0         'Source UDP port number is verified on receive packets (default)
    Public Const PORTCFG_NOSRCPORTCHK As Integer = &H100       'Source UDP port number is not verified on receive packets
    Public Const PORTCFG_NOEVENTHIT As Integer = &H0         'Port does not generate events
    Public Const PORTCFG_EVENTHIT As Integer = &H400       'Port genereates events when hit
    Public Const PORTCFG_SUBVL0 As Integer = &H0         'Schedule port in sub-VL 0
    Public Const PORTCFG_SUBVL1 As Integer = &H1000      'Schedule port in sub-VL 1
    Public Const PORTCFG_SUBVL2 As Integer = &H2000      'Schedule port in sub-VL 2
    Public Const PORTCFG_SUBVL3 As Integer = &H3000      'Schedule port in sub-VL 3

    '/**
    '*
    '*  Default port configuration options
    '*
    '**/

    Public Const DEFPORT_DEFAULT As Integer = &H0         'Select all default settings
    Public Const DEFPORT_INACTIVE As Integer = &H0         'Disable default port (default)
    Public Const DEFPORT_ACTIVE As Integer = &H1         'Enable default port
    Public Const DEFPORT_ALL As Integer = &H2         'Handle all non-deliverable packets
    Public Const DEFPORT_MAC As Integer = &H4         'Handle packets with MAC erors
    Public Const DEFPORT_SAMPLE As Integer = &H0         'Port will use sampling (default)
    Public Const DEFPORT_QUEUE As Integer = &H8         'Port will use queuing

    '/**
    '*
    '*  Event configuration options
    '*
    '**/

    Public Const EVENTCFG_DEFAULT As Integer = &H0        'Select all default settings
    Public Const EVENTCFG_ENABLE As Integer = &H0        'Enable event recording (default)
    Public Const EVENTCFG_DISABLE As Integer = &H1        'Disable event recording
    Public Const EVENTCFG_NOPHYSTATUS As Integer = &H0        'Disable events on changes to PHY status (default)
    Public Const EVENTCFG_PHYSTATUS As Integer = &H2        'Enable events on changes to PHY status

    '/**
    '*
    '*  Info types
    '*
    '**/

    Public Const INFOTYPE_PLAT As Integer = &H1           'Returns the AX1 platform type
    Public Const INFOTYPE_PROD As Integer = &H2           'Returns the AX1 product type
    Public Const INFOTYPE_DASH As Integer = &H3           'Returns the AX1 dash number
    Public Const INFOTYPE_VERSION As Integer = &H4           'Returns the AX1 version number
    Public Const INFOTYPE_DATE As Integer = &H5           'Returns the AX1 version date
    Public Const INFOTYPE_MODEL As Integer = &H6           'Returns the AX1 model number
    Public Const INFOTYPE_MAXCOUNT As Integer = &H7           'Returns the max channel count
    Public Const INFOTYPE_ERRORGEN As Integer = &H8           'Returns whether AX1 supports error generation
    Public Const INFOTYPE_CONCURMON As Integer = &H9           'Returns whether AX1 has a concurrent sequential monitor
    Public Const INFOTYPE_PHYSTAT As Integer = &HA           'Returns status of phys
    Public Const INFOTYPE_RCVOVER As Integer = &HB           'Returns number of receiver overruns

    '/**
    '*
    '*   Phy status
    '*
    '**/

    Public Const PHYSTAT_CHA_SETAUTO As Integer = &H1
    Public Const PHYSTAT_CHA_SET10 As Integer = &H2
    Public Const PHYSTAT_CHA_SET100 As Integer = &H4
    Public Const PHYSTAT_CHA_SET1000 As Integer = &H8
    Public Const PHYSTAT_CHA_GOT10 As Integer = &H20
    Public Const PHYSTAT_CHA_GOT100 As Integer = &H40
    Public Const PHYSTAT_CHA_GOT1000 As Integer = &H80
    Public Const PHYSTAT_CHA_GOTFDX As Integer = &H100
    Public Const PHYSTAT_CHA_GOTLINK As Integer = &H200
    Public Const PHYSTAT_CHA_GOTAUTO As Integer = &H400
    Public Const PHYSTAT_CHB_SETAUTO As Integer = &H10000
    Public Const PHYSTAT_CHB_SET10 As Integer = &H20000
    Public Const PHYSTAT_CHB_SET100 As Integer = &H40000
    Public Const PHYSTAT_CHB_SET1000 As Integer = &H80000
    Public Const PHYSTAT_CHB_GOT10 As Integer = &H200000
    Public Const PHYSTAT_CHB_GOT100 As Integer = &H400000
    Public Const PHYSTAT_CHB_GOT1000 As Integer = &H800000
    Public Const PHYSTAT_CHB_GOTFDX As Integer = &H1000000
    Public Const PHYSTAT_CHB_GOTLINK As Integer = &H2000000
    Public Const PHYSTAT_CHB_GOTAUTO As Integer = &H4000000

    '/**
    '*
    '*   DMA record types
    '*
    '**/

    Public Const DMATYPE_SEQ As Integer = &H1     'Sequential record
    Public Const DMATYPE_EVENT As Integer = &H2     'Event
    Public Const DMATYPE_PACKET As Integer = &H3     'Packet

    '/**
    '*
    '*   EVENT types
    '*
    '**/

    Public Const EVENTTYPE_PHYSTATUS As Integer = &H1     'Change in PHY status
    Public Const EVENTTYPE_VLHIT As Integer = &H3     'VL hit
    Public Const EVENTTYPE_PORTHIT As Integer = &H4     'Port hit
    Public Const EVENTTYPE_VLMISS As Integer = &H2     'VL missed
    Public Const EVENTTYPE_PORTMISS As Integer = &H4     'Port missed

    '/**
    '*
    '*  Error Values.
    '*
    '**/

    Public Const ERR_NONE As Integer = 0                 'No error
    Public Const ERR_UNKNOWN As Integer = -1                 'An unexpected error occurred
    Public Const ERR_BADVER As Integer = -2                 'A bad version was encountered
    Public Const ERR_BADPOINTER As Integer = -3                 'CardOpen() called with bad parameters
    Public Const ERR_BADSIG As Integer = -5                 'A bad card signature was encountered
    Public Const ERR_RUNNING As Integer = -6                 'Card is already running
    Public Const ERR_BADPARAMS As Integer = -11                'Function called with bad parameters
    Public Const ERR_NOHANDLES As Integer = -12                'CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Integer = -13                'CardOpen() could not find an AX1 card
    Public Const ERR_NOMEM As Integer = -15                'CardOpen() could not find the memory
    Public Const ERR_WRONGMODEL As Integer = -17                'Card does not support this feature
    Public Const ERR_NOSEL As Integer = -18                'CardOpen() could not allocate a memory selector
    Public Const ERR_LOCK As Integer = -19                'The communication process is locked up
    Public Const ERR_TOOMANY As Integer = -20                'Too many channels have been configured
    Public Const ERR_BADHANDLE As Integer = -21                'A bad handle was specified
    Public Const ERR_NOTCHAN As Integer = -23                'Not a valid channel
    Public Const ERR_NOTSEQ As Integer = -26                'The Sequential Record has not been configured
    Public Const ERR_ALLOC As Integer = -27                'There is not enough memory to allocate
    Public Const ERR_VXD As Integer = -28                'An error occurred in the VXD
    Public Const ERR_BUFSIZE As Integer = -33                'Insufficient space in user buffer
    Public Const ERR_NOCONFIG As Integer = -34                'The card has not been properly configured
    Public Const ERR_CONFLICTS As Integer = -35                'Unable to resolve conflicts
    Public Const ERR_RANGE As Integer = -36                'Schedule is out of range
    Public Const ERR_BOOTNUM As Integer = -42                'There is no boot code with the specified number
    Public Const ERR_ROMVERIFY As Integer = -44                'Unable to verify the value written to the ROM
    Public Const ERR_COUNT As Integer = -45                'An invalid count was specified
    Public Const ERR_NOMSGS As Integer = -52                'No messages specified
    Public Const ERR_BADTYPE As Integer = -54                'A bad type parameter was specified
    Public Const ERR_ZEROLEN As Integer = -55                'Zero length was specified
    Public Const ERR_BADADDRESS As Integer = -56                'A bad address was specified
    Public Const ERR_BADCMD As Integer = -91                'A bad command was specified
    Public Const ERR_FINDNEXT As Integer = -92                'Find next function count not find anything
    Public Const ERR_NETID As Integer = -93                'Network ID out of range
    Public Const ERR_BUSNUM As Integer = -94                'Busnum out of range
    Public Const ERR_PAIRID As Integer = -95                'Pair ID out of range
    Public Const ERR_GETEMPTY As Integer = -96                'Get did not find anything
    Public Const ERR_DETECTEMPTY As Integer = -97                'Detect did not find anything
    Public Const ERR_VLUNDEF As Integer = -110               'Specified VL is undefined
    Public Const ERR_PORTUNDEF As Integer = -111               'Specified port is undefined
    Public Const ERR_SCHED As Integer = -112               'Error creating or finding schedule
    Public Const ERR_TXQPORT As Integer = -113               'Attempt to read a queue transmit port
    Public Const ERR_CONVERSION As Integer = -114               'Error while converting data
    Public Const ERR_DATAOVERFLOW As Integer = -115               'Data overflow in packet
    Public Const ERR_NOPKT As Integer = -116               'No packet was available
    Public Const ERR_FULL As Integer = -117               'Operation failed, structure full

    '/**
    '*
    '*  Structs used by the AX1 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure AFDXPKTDESC
        Public typeval As Short
        Public count As Short
        Public timestamp As Integer
        Public timestamph As Integer
        Public delay As Integer
        Public delayh As Integer
        Public activity As Integer
        Public errors As Integer
        Public busnum As Short
        Public totalpktlen As Short    'Total packet length
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_AFDXPACKETSIZE + 64)> Public packet() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure AFDXPKTDESCHDR
        Public typeval As Short
        Public count As Short
        Public timestamp As Integer
        Public timestamph As Integer
        Public delay As Integer
        Public delayh As Integer
        Public activity As Integer
        Public errors As Integer
        Public busnum As Short
        Public totalpktlen As Short   'Total packet length
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=42)> Public header() As Byte   '42 bytes for UDP/ICMP, 34 bytes for IP only
        Public rsn As Byte
    End Structure

    'Changed pointers from LPBYTE to Long
    <StructLayout(LayoutKind.Sequential)> Public Structure SEQFINDINFO
        Public pRecFirst As Integer
        Public pRecNext As Integer
        Public pRecLast As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure FDSDESC
        Public offset As Short
        Public ds1_len As Short
        Public ds2_len As Short
        Public ds3_len As Short
        Public ds4_len As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure ADDRESS
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public data() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_EQUIP
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> Public EqDesignation() As Byte 'Equipment Designation
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=15)> Public EqPN() As Byte          'Equipment Part Number
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public EqSN() As Byte           'Equipment Serial Number
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public EqLN() As Byte           'Equipment Load Part Number
        Public EqStatus As Integer                'Equipment Status: 1=Healthy,2=inFault
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public EqLocation() As Byte     'Equipment Location (side * position)
        Public EqUpTime As Integer                'Equipment up time (time since initialization)
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_MAC
        Public MACIndex As Integer              'physical ethernet port number (Bus A/B)
        Public MACAddressHi As Integer          '16 most sig bits of MAC
        Public MACAddressLo As Integer          '32 least sig bits of MAC
        Public MACStatus As Integer             'HW Status (1=healthy,2=lossOfLink,3=inFault
        Public MACInOctets As Integer           'Total bytes Rx (AFDX payload + RSN + 42 bytes header... preamble&start frame not included)
        Public MACOutOctets As Integer          'Total bytes Tx
        Public MACInFrames As Integer           'Total frames Rx
        Public MACOutFrames As Integer          'Total frames Tx
        Public MACTotalInErrors As Integer      'Total Errors Rx only=DestErr+AlignErr+CRCErr+FrameLenErr+IntMACErr + xMACInIPTypeErrors
        Public MACDestAddrErrors As Integer     'Discarded frames from erronous MAC destination address
        Public MACAlignmentErrors As Integer    'Received frames not integral number of bytes
        Public MACCRCErrors As Integer          'Received frames that do not pass CRC check
        Public MACFrameLengthErrors As Integer  'Recived frames longer tham MAX or shorter than MIN frame size
        Public MACIntMACRxErrors As Integer     'Discarded frames with internal MAC errors (Header: Preamble,Start Frame Delim)

        'extras
        Public exMACFrameLengthLongErr As Integer
        Public exMACFrameLengthShortErr As Integer

        Public exMACMulticastFrames As Integer    'Total Multicast frames
        Public exMACBroadcastFrames As Integer    'Total Broadcast frames

        Public exMACInIPTypeErrors As Integer     'Discarded frames with a MAC IP Type error (should be 0x0800)*/
        Public exMACSupriseVL As Integer          'MAC address (VL) was seen for which a VL/MAC Table entry was NOT found.
        Public exMACConstMismatch As Integer      'The constant portion of the MAC dest not match the expected AFDX constant (does not increment MACTotalInErrors)
        Public exMACBagViolations As Integer      'Counts of VALID frames that violated the minnimum BAG time... time measured from first redundancy validated frame to next in-sequence
        Public exMACInQueuePortFull As Integer    'Count of how many times the oldest packet was dropped because a RX queuing port was full (not serviced)

        Public exMACOutQueuedOctets As Integer    'Total Tx bytes loaded into TX queue... (less than or equal to MACOutOctets)
        Public exMACOutQueuedFrames As Integer    'Total Tx frames loaded into TX queue... (less than or equal to MACOutFrames)

        'status
        Public exMACLastInDestAddrHi As Integer     'High 16 bits Last received Destination Addr - only updated for unassigned VL's
        Public exMACLastInDestAddrLo As Integer     'Low 32 bits
        Public exMACLastTimeHi As Integer           'High 32 bits (in us) recorded last time
        Public exMACLastTimeLo As Integer           'Low 32 bits

        'range config values
        Public exMACRangeMidLowVal As Integer
        Public exMACRangeMidHighVal As Integer

        'range level counts
        Public exMACFrameLengthRangeLow As Integer   'Number of Frames received with Length in Low range - checked AFTER integrity/redundancy, but before IP
        Public exMACFrameLengthRangeMid As Integer   'Count of valid frames with the middle range data length - checked AFTER integrity/redundancy, but before IP
        Public exMACFrameLengthRangeHigh As Integer  'Count of valid frames with the high range data length - checked AFTER integrity/redundancy, but before IP
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_REDUNDERR
        Public RedundPortIndex As Integer             'physical ethernet port number (Bus A/B)
        Public RedundIntegrityCheckError As Integer   'Total number rx frames with Integrity RSN invalid (for the above port/bus)
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_REDUNDSTATS
        Public RedundVLPortIndex As Integer           'physical ethernet port number (Bus A/B)
        Public RedundVLMacAddress As Integer          'Multicast MAC address destination (of VL in Rx) using redundancy
        Public RedundVLIntegrityCheckError As Integer 'Total number rx frames with RSN invalid (for the above port/bus). Invremented by an ingegrity or a redundancy error
        Public RedundVLFirstInFrames As Integer       'Valid rx frames passed to IP layer (only for the VL using redundancy - passed integrity and redundancy)

        Public exIntegDupRSN As Integer               'Duplicate RSN
        Public exIntegSeqRSN As Integer               'Sequence out-of-order RSN (including dropped frames from Alt bus)
        Public exIntegDisableSkip As Integer          'Integrity checking skipped because it was disabled
        Public exIntegRSNZeroIn As Integer            'RSN 0 received (reset)
        Public exIntegRSNZeroConsecIn As Integer      'Consecutive RSN 0 received (reset)
        Public exRedundDupRSNAltNet As Integer        'Duplicate RSN from alternate network (not technally an error, but packet dropped)
        Public exRedundDupRSNSameNet As Integer       'Duplicate RSN from same network (error, packet dropped)
        Public exRedundSeqRSN As Integer              'Sequence out-of-order RSN (error, packet dropped)
        Public exRedundDisableSkip As Integer         'Redundancy checking skipped because it was disabled
        Public exRedundTimeouts As Integer            'Count of how many times the redundancy checking timedout... next RSN accepted regardless ([timeout=skewMax if skewMax > bag]  ELSE  [timeout=skewMax + bag]
        Public exRedundBagViolations As Integer       'Counts of VALID frames that violated the minnimum BAG time... time measured from first redundancy validated frame to next in-sequence
        Public exRedundOverSkewMax As Integer         'Count skewMax was exceeded... note: packet only accepted if timeout was exceeded (see timeout above)
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_IP
        Public IPInReceives As Integer                'Total num of datagrams received (including errors) = inTotalErrors+valid datagrams*/
        Public IPOutRequests As Integer               'Total num of datagrams in output (including errors) = OutTotalErrors+valid datagrams*/
        Public IPInTotalErrors As Integer             'Num of Rx datagrams with errors = ChkSumErrs + UnknownProtocols + InDiscards + ReasmFail*/
        Public IPOutTotalErrsDiscrd As Integer        'Num of Tx datagrams DISCARDED due to errors*/
        Public IPInChkSumErrors As Integer            'Num of Rx Check sum errors. (Packet discarded)*/
        Public IPInUnknownProtos As Integer           'Num of (locally addressed) datagrams with an Unknown or Unsupported protocol. (Packet discarded)*/
        Public IPInDiscards As Integer                'Num of datagrams with NO Problems, but were discarded.*/
        Public IPOutDiscards As Integer               'Num of datagrams with NO Problems, but were discarded.*/
        Public IPReasmFails As Integer                'Frag Error-Num of datagrams deleted by reassembly algorithm (for whatever reason:fragment id error, etc.)*/

        'Extra counters
        Public exIPInVersionErrors As Integer         'Num of Rx IP Version errors
        Public exIPOutVersionErrors As Integer        'Num of Tx IP Version errors
        Public exIPInHdrLenErrors As Integer          'Num of Rx IP Header Length errors
        Public exIPOutHdrLenErrors As Integer         'Num of Tx IP Header Length errors
        Public exIPInTypeOfService As Integer         'Num of Rx IP Type of service errors
        Public exIPOutTypeOfService As Integer        'Num of Tx IP Type of service errors

        Public exIPInDestErr As Integer               'Destination error
        Public exIPInSourceErr As Integer             'Source error

        Public exIPOutTotalErrorsSent As Integer      'Num of Tx datagrams SENT with errors (for error injection)
        Public exIPOutChkSumErrors As Integer         'Num of Tx Check sum errors. (Packet discarded)
        Public exIPOutUnknownProtos As Integer        'Num of (locally addressed) datagrams with an Unknown or Unsupported protocol. (Packet discarded)
        Public exIPOutFragErrors As Integer           'Num of datagrams sent with Fragmentation errors

        Public exIPInOctets As Integer                'Total num of bytes received
        Public exIPOutOctets As Integer               'Total num of bytes output
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_UDP
        Public UDPInError As Integer          'count of input datagrams with an error (does not include 'UDPNoPorts')
        Public UDPNoPorts As Integer          'Count of datagrams with no application at the dest port
        Public exUDPInSrcInval As Integer     'count of UDP frames with invalid source address... depending on implementation 'UDPInError' MAY be incremented
        Public exUDPInLengthError As Integer  'receive Length errors (increments UDPInError)
        Public exUDPInCRCError As Integer     'receive CRC errors (increments UDPInError)
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_SCHED
        Public exSchedOutFrames As Integer        'Total Tx frames actually sent
        Public exSchedOutLoadedFrames As Integer  'Total Tx frames loaded into TX queue... (greater than or equal to MACOutFrames)
        Public exSchedOutRRSchedNop As Integer    'Count of the times a Round Robin sched entry did no transmission
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_TCP
        Public TCPInError As Integer
        Public TCPNoPorts As Integer          'Total count received segments with no application at the dest port.
        Public TCPInSegs As Integer           'segments delivered to TCP users
        Public TCPOutSegs As Integer          'segments sent to the IP Layer
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_ESFAILURE
        Public InLackOfBuffer As Integer
        Public OutLackOfBuffer As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MIB_PORT
        Public exQueuePortFull As Integer             'Number of dropped packets due to queue overruns
        Public exHitCount As Integer                  'Count of hits
        Public exByteCount As Integer                 'Count of payload bytes through this message (IP payload only... not header)

        Public exPortOutTotalFrames As Integer        'count of the Total number of frames transmitted on the bus
        Public exPortOutRRFrames As Integer           'count of the number of frames encountered (for Round Robin sched) (xmission may be pending)
        Public exPortOutRRSkipped As Integer          'count of the times the port was skipped (for Round Robin sched), either because of skip in the schedule item or the port setting
        Public exPortOutRRQueueEmpty As Integer       'count of the times the port was skipped because the Queue was empty (for Round Robin sched)
        Public exPortOutRRRedNetTxOff As Integer      'count of Xmt where Bus was configured for redundundancy but neither NetA nor NetB were enabled for TX (for Round Robin sched)
        Public exPortOutRRIndNetAltNet As Integer     'count of times where network was configured as Independant, but tried to TX on Alt Net (for Round Robin sched)

        Public exPortOutSkipped As Integer            'count of the times the port was skipped (not Round Robin sched), either because of skip in the schedule item or the port setting
        Public exPortOutQueueEmpty As Integer         'count of the times the port was skipped because the Queue was empty (not Round Robin sched)
        Public exPortOutRedNetTxOff As Integer        'count of Xmt where Bus was configured for redundundancy but neither NetA nor NetB were enabled for TX (not Round Robin sched)
        Public exPortOutIndNetAltNet As Integer       'count of times where network was configured as Independant, but tried to TX on Alt Net (not Round Robin sched)
    End Structure

    Public Declare Function AX1_CardClose Lib "AX1W32.DLL" Alias "_AX1_CardClose@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardOpen Lib "AX1W32.DLL" Alias "_AX1_CardOpen@8" (ByRef lpHandle As Integer, ByVal cardnum As Integer) As Integer
    Public Declare Function AX1_CardReset Lib "AX1W32.DLL" Alias "_AX1_CardReset@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardStart Lib "AX1W32.DLL" Alias "_AX1_CardStart@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardStop Lib "AX1W32.DLL" Alias "_AX1_CardStop@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrCtrlConfig Lib "AX1W32.DLL" Alias "_AX1_ErrCtrlConfig@16" (ByVal configval As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrNetEnable Lib "AX1W32.DLL" Alias "_AX1_ErrNetEnable@16" (ByVal configval As Integer, ByVal trigid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrPktConfig Lib "AX1W32.DLL" Alias "_AX1_ErrPktConfig@32" (ByVal configval As Integer, ByVal blendflags As Integer, ByVal trigid As Short, ByRef packet As Byte, ByVal pktlen As Short, ByVal errpadlen As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrRSNConfig Lib "AX1W32.DLL" Alias "_AX1_ErrRSNConfig@20" (ByVal configval As Integer, ByVal trigid As Short, ByVal modifier As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrXmtConfig Lib "AX1W32.DLL" Alias "_AX1_ErrXmtConfig@16" (ByVal configval As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_EventConfig Lib "AX1W32.DLL" Alias "_AX1_EventConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_FDSGetBoolean Lib "AX1W32.DLL" Alias "_AX1_FDSGetBoolean@32" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Integer
    Public Declare Function AX1_FDSGetFloat32 Lib "AX1W32.DLL" Alias "_AX1_FDSGetFloat32@32" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Single
    Public Declare Function AX1_FDSGetFloat64 Lib "AX1W32.DLL" Alias "_AX1_FDSGetFloat64@32" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Double
    Public Declare Function AX1_FDSGetOpaqueFix Lib "AX1W32.DLL" Alias "_AX1_FDSGetOpaqueFix@36" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByRef outbuf As Byte, ByVal bufsize As Integer) As Short
    Public Declare Function AX1_FDSGetOpaqueVar Lib "AX1W32.DLL" Alias "_AX1_FDSGetOpaqueVar@36" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByRef outbuf As Byte, ByVal bufsize As Integer) As Short
    Public Declare Function AX1_FDSGetSigned32 Lib "AX1W32.DLL" Alias "_AX1_FDSGetSigned32@32" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Integer
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Function AX1_FDSGetSigned64 Lib "AX1W32.DLL" Alias "_AX1_FDSGetSigned64@32" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Long
    Public Declare Function AX1_FDSGetStatus Lib "AX1W32.DLL" Alias "_AX1_FDSGetStatus@20" (ByRef buf As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer) As Byte
    Public Declare Function AX1_FDSGetString Lib "AX1W32.DLL" Alias "_AX1_FDSGetString@36" (ByRef buf As Byte, ByRef status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal outbuf As String, ByVal bufsize As Integer) As Short
    Public Declare Function AX1_FDSPutBoolean Lib "AX1W32.DLL" Alias "_AX1_FDSPutBoolean@36" (ByVal putval As Integer, ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Byte
    Public Declare Function AX1_FDSPutFloat32 Lib "AX1W32.DLL" Alias "_AX1_FDSPutFloat32@36" (ByVal putval As Single, ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Byte
    Public Declare Function AX1_FDSPutFloat64 Lib "AX1W32.DLL" Alias "_AX1_FDSPutFloat64@40" (ByVal putval As Double, ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Byte
    Public Declare Function AX1_FDSPutOpaqueFix Lib "AX1W32.DLL" Alias "_AX1_FDSPutOpaqueFix@36" (ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByRef inbuf As Byte, ByVal bufsize As Integer) As Byte
    Public Declare Function AX1_FDSPutOpaqueVar Lib "AX1W32.DLL" Alias "_AX1_FDSPutOpaqueVar@40" (ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByRef inbuf As Byte, ByVal datalen As Short, ByVal bufsize As Integer) As Byte
    Public Declare Function AX1_FDSPutSigned32 Lib "AX1W32.DLL" Alias "_AX1_FDSPutSigned32@36" (ByVal putval As Integer, ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Byte
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Function AX1_FDSPutSigned64 Lib "AX1W32.DLL" Alias "_AX1_FDSPutSigned64@40" (ByVal putval As Long, ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal byteswap As Integer) As Byte
    Public Declare Sub AX1_FDSPutStatus Lib "AX1W32.DLL" Alias "_AX1_FDSPutStatus@24" (ByRef buf As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal status As Byte)
    Public Declare Function AX1_FDSPutString Lib "AX1W32.DLL" Alias "_AX1_FDSPutString@36" (ByRef buf As Byte, ByVal status As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer, ByVal offset As Integer, ByVal inbuf As String, ByVal bufsize As Integer) As Byte
    Public Declare Function AX1_FldGetBoolean Lib "AX1W32.DLL" Alias "_AX1_FldGetBoolean@12" (ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer) As Integer
    Public Declare Function AX1_FldGetFloat32 Lib "AX1W32.DLL" Alias "_AX1_FldGetFloat32@12" (ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer) As Single
    Public Declare Function AX1_FldGetFloat64 Lib "AX1W32.DLL" Alias "_AX1_FldGetFloat64@12" (ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer) As Double
    Public Declare Function AX1_FldGetOpaqueFix Lib "AX1W32.DLL" Alias "_AX1_FldGetOpaqueFix@16" (ByRef buf As Byte, ByVal offset As Integer, ByRef outbuf As Byte, ByVal bufsize As Integer) As Short
    Public Declare Function AX1_FldGetOpaqueVar Lib "AX1W32.DLL" Alias "_AX1_FldGetOpaqueVar@16" (ByRef buf As Byte, ByVal offset As Integer, ByRef outbuf As Byte, ByVal bufsize As Integer) As Short
    Public Declare Function AX1_FldGetSigned32 Lib "AX1W32.DLL" Alias "_AX1_FldGetSigned32@12" (ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer) As Integer
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Function AX1_FldGetSigned64 Lib "AX1W32.DLL" Alias "_AX1_FldGetSigned64@12" (ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer) As Long
    Public Declare Function AX1_FldGetString Lib "AX1W32.DLL" Alias "_AX1_FldGetString@16" (ByRef buf As Byte, ByVal offset As Integer, ByVal outbuf As String, ByVal bufsize As Integer) As Short
    Public Declare Sub AX1_FldPutBoolean Lib "AX1W32.DLL" Alias "_AX1_FldPutBoolean@16" (ByVal putval As Integer, ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer)
    Public Declare Sub AX1_FldPutFloat32 Lib "AX1W32.DLL" Alias "_AX1_FldPutFloat32@16" (ByVal putval As Single, ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer)
    Public Declare Sub AX1_FldPutFloat64 Lib "AX1W32.DLL" Alias "_AX1_FldPutFloat64@20" (ByVal putval As Double, ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer)
    Public Declare Sub AX1_FldPutOpaqueFix Lib "AX1W32.DLL" Alias "_AX1_FldPutOpaqueFix@16" (ByRef buf As Byte, ByVal offset As Integer, ByRef inbuf As Byte, ByVal bufsize As Integer)
    Public Declare Sub AX1_FldPutOpaqueVar Lib "AX1W32.DLL" Alias "_AX1_FldPutOpaqueVar@20" (ByRef buf As Byte, ByVal offset As Integer, ByRef inbuf As Byte, ByVal datalen As Short, ByVal bufsize As Integer)
    Public Declare Sub AX1_FldPutSigned32 Lib "AX1W32.DLL" Alias "_AX1_FldPutSigned32@16" (ByVal putval As Integer, ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer)
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Sub AX1_FldPutSigned64 Lib "AX1W32.DLL" Alias "_AX1_FldPutSigned64@20" (ByVal putval As Long, ByRef buf As Byte, ByVal offset As Integer, ByVal byteswap As Integer)
    Public Declare Sub AX1_FldPutString Lib "AX1W32.DLL" Alias "_AX1_FldPutString@16" (ByRef buf As Byte, ByVal offset As Integer, ByVal inbuf As String, ByVal bufsize As Integer)
    Public Declare Function AX1_Hton16 Lib "AX1W32.DLL" Alias "_AX1_Hton16@4" (ByVal val As Short) As Short
    Public Declare Function AX1_Hton32 Lib "AX1W32.DLL" Alias "_AX1_Hton32@4" (ByVal val As Integer) As Integer
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Function AX1_Hton64 Lib "AX1W32.DLL" Alias "_AX1_Hton64@8" (ByVal val As Long) As Long
    Public Declare Function AX1_MakeDstIP Lib "AX1W32.DLL" Alias "_AX1_MakeDstIP@4" (ByVal vlid As Short) As Integer
    Public Declare Function AX1_MakeDstIPUnicast Lib "AX1W32.DLL" Alias "_AX1_MakeDstIPUnicast@16" (ByVal domain As Short, ByVal side As Short, ByVal location As Short, ByVal part As Short) As Integer
    Public Declare Function AX1_MakeDstMAC Lib "AX1W32.DLL" Alias "_AX1_MakeDstMAC@8" (ByVal vlid As Short, ByRef paddress As ADDRESS) As Integer
    Public Declare Function AX1_MakeDstMACEx Lib "AX1W32.DLL" Alias "_AX1_MakeDstMACEx@12" (ByVal vlid As Short, ByVal MACConst As Integer, ByRef paddress As ADDRESS) As Integer
    Public Declare Function AX1_MakeSrcIP Lib "AX1W32.DLL" Alias "_AX1_MakeSrcIP@16" (ByVal domain As Short, ByVal side As Short, ByVal location As Short, ByVal part As Short) As Integer
    Public Declare Function AX1_MakeSrcIPEx Lib "AX1W32.DLL" Alias "_AX1_MakeSrcIPEx@8" (ByVal userid As Short, ByVal part As Short) As Integer
    Public Declare Function AX1_MakeSrcMAC Lib "AX1W32.DLL" Alias "_AX1_MakeSrcMAC@20" (ByVal domain As Short, ByVal side As Short, ByVal location As Short, ByVal intid As Short, ByRef paddress As ADDRESS) As Integer
    Public Declare Function AX1_MakeSrcMACEx Lib "AX1W32.DLL" Alias "_AX1_MakeSrcMACEx@12" (ByVal userid As Short, ByVal intid As Short, ByRef paddress As ADDRESS) As Integer
    Public Declare Function AX1_MIBGetNetInfo Lib "AX1W32.DLL" Alias "_AX1_MIBGetNetInfo@16" (ByVal mibtype As Short, ByRef data As Byte, ByVal busnum As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_MIBGetPortInfo Lib "AX1W32.DLL" Alias "_AX1_MIBGetPortInfo@12" (ByRef data As Byte, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_MIBGetVLInfo Lib "AX1W32.DLL" Alias "_AX1_MIBGetVLInfo@16" (ByVal mibtype As Short, ByRef data As Byte, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetConfig Lib "AX1W32.DLL" Alias "_AX1_NetConfig@20" (ByVal configval As Integer, ByVal macconst As Integer, ByVal speed As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetDefaultPortConfig Lib "AX1W32.DLL" Alias "_AX1_NetDefaultPortConfig@16" (ByVal ctrlflags As Integer, ByVal depth As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetDefaultPortGetHandle Lib "AX1W32.DLL" Alias "_AX1_NetDefaultPortGetHandle@12" (ByRef hport As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetGetVLCount Lib "AX1W32.DLL" Alias "_AX1_NetGetVLCount@12" (ByRef pvlcount As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetIFGConfig Lib "AX1W32.DLL" Alias "_AX1_NetIFGConfig@16" (ByVal configval As Integer, ByVal gapval As Short, ByVal busnum As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetRedundConfig Lib "AX1W32.DLL" Alias "_AX1_NetRedundConfig@12" (ByVal configval As Integer, ByVal pairid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetSetInterfaceID Lib "AX1W32.DLL" Alias "_AX1_NetSetInterfaceID@16" (ByVal flags As Short, ByVal idVal As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_Ntoh16 Lib "AX1W32.DLL" Alias "_AX1_Ntoh16@4" (ByVal val As Short) As Short
    Public Declare Function AX1_Ntoh32 Lib "AX1W32.DLL" Alias "_AX1_Ntoh32@4" (ByVal val As Integer) As Integer
    'Note: The following function uses a data type not supported in VB6.
    Public Declare Function AX1_Ntoh64 Lib "AX1W32.DLL" Alias "_AX1_Ntoh64@8" (ByVal val As Long) As Long
    Public Declare Function AX1_ParamFrameFreq Lib "AX1W32.DLL" Alias "_AX1_ParamFrameFreq@16" (ByVal configval As Integer, ByVal percent As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PktCalcCRCIP Lib "AX1W32.DLL" Alias "_AX1_PktCalcCRCIP@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktCalcCRCUDP Lib "AX1W32.DLL" Alias "_AX1_PktCalcCRCUDP@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetCtrlFlag Lib "AX1W32.DLL" Alias "_AX1_PktGetCtrlFlag@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetDstMac Lib "AX1W32.DLL" Alias "_AX1_PktGetDstMac@8" (ByRef pPkt As Byte, ByRef pAddress As ADDRESS) As Integer
    Public Declare Function AX1_PktGetFragID Lib "AX1W32.DLL" Alias "_AX1_PktGetFragID@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetFragOff Lib "AX1W32.DLL" Alias "_AX1_PktGetFragOff@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetIHL Lib "AX1W32.DLL" Alias "_AX1_PktGetIHL@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetInterfaceID Lib "AX1W32.DLL" Alias "_AX1_PktGetInterfaceID@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetIPChecksum Lib "AX1W32.DLL" Alias "_AX1_PktGetIPChecksum@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetIPDest Lib "AX1W32.DLL" Alias "_AX1_PktGetIPDest@4" (ByRef pPkt As Byte) As Integer
    Public Declare Function AX1_PktGetIPLength Lib "AX1W32.DLL" Alias "_AX1_PktGetIPLength@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetIPSrc Lib "AX1W32.DLL" Alias "_AX1_PktGetIPSrc@4" (ByRef pPkt As Byte) As Integer
    Public Declare Function AX1_PktGetProtocol Lib "AX1W32.DLL" Alias "_AX1_PktGetProtocol@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetSeqNum Lib "AX1W32.DLL" Alias "_AX1_PktGetSeqNum@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetSrcMac Lib "AX1W32.DLL" Alias "_AX1_PktGetSrcMac@8" (ByRef pPkt As Byte, ByRef pAddress As ADDRESS) As Integer
    Public Declare Function AX1_PktGetTOS Lib "AX1W32.DLL" Alias "_AX1_PktGetTOS@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetTTL Lib "AX1W32.DLL" Alias "_AX1_PktGetTTL@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetType Lib "AX1W32.DLL" Alias "_AX1_PktGetType@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetUDPChecksum Lib "AX1W32.DLL" Alias "_AX1_PktGetUDPChecksum@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetUDPLength Lib "AX1W32.DLL" Alias "_AX1_PktGetUDPLength@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetUDPPortDest Lib "AX1W32.DLL" Alias "_AX1_PktGetUDPPortDest@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetUDPPortSrc Lib "AX1W32.DLL" Alias "_AX1_PktGetUDPPortSrc@4" (ByRef pPkt As Byte) As Short
    Public Declare Function AX1_PktGetVersion Lib "AX1W32.DLL" Alias "_AX1_PktGetVersion@4" (ByRef pPkt As Byte) As Short
    Public Declare Sub AX1_PktPutCtrlFlag Lib "AX1W32.DLL" Alias "_AX1_PktPutCtrlFlag@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutDstMac Lib "AX1W32.DLL" Alias "_AX1_PktPutDstMac@12" (ByVal newMAC As ADDRESS, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutFragID Lib "AX1W32.DLL" Alias "_AX1_PktPutFragID@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutFragOff Lib "AX1W32.DLL" Alias "_AX1_PktPutFragOff@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutHeaderConstants Lib "AX1W32.DLL" Alias "_AX1_PktPutHeaderConstants@4" (ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutIHL Lib "AX1W32.DLL" Alias "_AX1_PktPutIHL@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutInterfaceID Lib "AX1W32.DLL" Alias "_AX1_PktPutInterfaceID@8" (ByVal busnum As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutIPChecksum Lib "AX1W32.DLL" Alias "_AX1_PktPutIPChecksum@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutIPDest Lib "AX1W32.DLL" Alias "_AX1_PktPutIPDest@8" (ByVal newVal As Integer, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutIPLength Lib "AX1W32.DLL" Alias "_AX1_PktPutIPLength@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutIPSrc Lib "AX1W32.DLL" Alias "_AX1_PktPutIPSrc@8" (ByVal newVal As Integer, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutLenFromFrame Lib "AX1W32.DLL" Alias "_AX1_PktPutLenFromFrame@8" (ByVal frameSize As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutProtocol Lib "AX1W32.DLL" Alias "_AX1_PktPutProtocol@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutSeqNum Lib "AX1W32.DLL" Alias "_AX1_PktPutSeqNum@8" (ByVal newNum As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutSrcMac Lib "AX1W32.DLL" Alias "_AX1_PktPutSrcMac@12" (ByVal newMAC As ADDRESS, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutTOS Lib "AX1W32.DLL" Alias "_AX1_PktPutTOS@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutTTL Lib "AX1W32.DLL" Alias "_AX1_PktPutTTL@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutType Lib "AX1W32.DLL" Alias "_AX1_PktPutType@8" (ByVal newType As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutUDPChecksum Lib "AX1W32.DLL" Alias "_AX1_PktPutUDPChecksum@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutUDPLength Lib "AX1W32.DLL" Alias "_AX1_PktPutUDPLength@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutUDPPortDest Lib "AX1W32.DLL" Alias "_AX1_PktPutUDPPortDest@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutUDPPortSrc Lib "AX1W32.DLL" Alias "_AX1_PktPutUDPPortSrc@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Sub AX1_PktPutVersion Lib "AX1W32.DLL" Alias "_AX1_PktPutVersion@8" (ByVal newVal As Short, ByRef pPkt As Byte)
    Public Declare Function AX1_PortConfig Lib "AX1W32.DLL" Alias "_AX1_PortConfig@28" (ByVal configval As Integer, ByVal dstid As Short, ByVal srcid As Short, ByVal depth As Short, ByRef portptr As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortDataRd Lib "AX1W32.DLL" Alias "_AX1_PortDataRd@28" (ByRef data As Byte, ByRef lengthptr As Short, ByRef rsnptr As Byte, ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortDataWr Lib "AX1W32.DLL" Alias "_AX1_PortDataWr@20" (ByVal rsn As Byte, ByRef data As Byte, ByVal length As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetHandle Lib "AX1W32.DLL" Alias "_AX1_PortGetHandle@16" (ByVal portnum As Short, ByRef hport As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetInfo Lib "AX1W32.DLL" Alias "_AX1_PortGetInfo@32" (ByRef configval As Integer, ByRef vlid As Short, ByRef dstport As Short, ByRef srcport As Short, ByRef depth As Short, ByRef reprate As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetNext Lib "AX1W32.DLL" Alias "_AX1_PortGetNext@20" (ByVal flag As Short, ByRef nextPort As Short, ByVal lastPort As Short, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetQueueCount Lib "AX1W32.DLL" Alias "_AX1_PortGetQueueCount@12" (ByRef queuecount As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortInfoRd Lib "AX1W32.DLL" Alias "_AX1_PortInfoRd@28" (ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByRef activityptr As Integer, ByRef errorptr As Integer, ByRef rsnptr As Byte, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortRawRd Lib "AX1W32.DLL" Alias "_AX1_PortRawRd@24" (ByRef packet As Byte, ByRef lengthptr As Short, ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortRawWr Lib "AX1W32.DLL" Alias "_AX1_PortRawWr@16" (ByRef packet As Byte, ByVal length As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortRd Lib "AX1W32.DLL" Alias "_AX1_PortRd@12" (ByRef pktdesc As AFDXPKTDESC, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortSkipConfig Lib "AX1W32.DLL" Alias "_AX1_PortSkipConfig@16" (ByVal ctrlflags As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortStepConfig Lib "AX1W32.DLL" Alias "_AX1_PortStepConfig@16" (ByVal ctrlflags As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RcvHostEnable Lib "AX1W32.DLL" Alias "_AX1_RcvHostEnable@8" (ByVal enableval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RobinSchedPort Lib "AX1W32.DLL" Alias "_AX1_RobinSchedPort@32" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByVal hport As Integer, ByRef hscheditem As Integer, ByVal hrobin As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedBuild Lib "AX1W32.DLL" Alias "_AX1_SchedBuild@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedCrtRobin Lib "AX1W32.DLL" Alias "_AX1_SchedCrtRobin@8" (ByRef hrobin As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedCrtSub Lib "AX1W32.DLL" Alias "_AX1_SchedCrtSub@8" (ByRef hsub As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedFrameEnd Lib "AX1W32.DLL" Alias "_AX1_SchedFrameEnd@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedFrameStart Lib "AX1W32.DLL" Alias "_AX1_SchedFrameStart@12" (ByVal usframetime As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedItemUpdate Lib "AX1W32.DLL" Alias "_AX1_SchedItemUpdate@24" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByVal hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedNoop Lib "AX1W32.DLL" Alias "_AX1_SchedNoop@20" (ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedPort Lib "AX1W32.DLL" Alias "_AX1_SchedPort@32" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByVal hport As Integer, ByRef hscheditem As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedRobin Lib "AX1W32.DLL" Alias "_AX1_SchedRobin@24" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal hrobin As Integer, ByRef hscheditem As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedSub Lib "AX1W32.DLL" Alias "_AX1_SchedSub@24" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal hsub As Integer, ByRef hscheditem As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqClear Lib "AX1W32.DLL" Alias "_AX1_SeqClear@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqConfig Lib "AX1W32.DLL" Alias "_AX1_SeqConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqFindCheckValidType Lib "AX1W32.DLL" Alias "_AX1_SeqFindCheckValidType@4" (ByVal seqtype As Short) As Integer
    Public Declare Function AX1_SeqFindInit Lib "AX1W32.DLL" Alias "_AX1_SeqFindInit@12" (ByRef seqbuf As Byte, ByVal seqbufsize As Integer, ByRef sfinfo As SEQFINDINFO) As Integer
    Public Declare Function AX1_SeqFindNextEx Lib "AX1W32.DLL" Alias "_AX1_SeqFindNextEx@16" (ByRef pRecord As Byte, ByVal recordcount As Integer, ByRef seqtype As Short, ByRef sfinfo As SEQFINDINFO) As Integer
    Public Declare Function AX1_SeqPause Lib "AX1W32.DLL" Alias "_AX1_SeqPause@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqRd Lib "AX1W32.DLL" Alias "_AX1_SeqRd@12" (ByRef bufptr As Byte, ByRef bufcountptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqRestart Lib "AX1W32.DLL" Alias "_AX1_SeqRestart@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqResume Lib "AX1W32.DLL" Alias "_AX1_SeqResume@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqSetMonitor Lib "AX1W32.DLL" Alias "_AX1_SeqSetMonitor@16" (ByVal bmonitor As Integer, ByVal vlid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqStatus Lib "AX1W32.DLL" Alias "_AX1_SeqStatus@8" (ByRef statusptr As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SubSchedNoop Lib "AX1W32.DLL" Alias "_AX1_SubSchedNoop@20" (ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal hsub As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SubSchedPort Lib "AX1W32.DLL" Alias "_AX1_SubSchedPort@32" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByVal hport As Integer, ByRef hscheditem As Integer, ByVal hsub As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SubSchedRobin Lib "AX1W32.DLL" Alias "_AX1_SubSchedRobin@24" (ByVal bSkip As Integer, ByVal bShot As Integer, ByVal hrobin As Integer, ByRef hscheditem As Integer, ByVal hsub As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_TimeGetDelta Lib "AX1W32.DLL" Alias "_AX1_TimeGetDelta@24" (ByVal tth1 As Integer, ByVal ttl1 As Integer, ByVal tth2 As Integer, ByVal ttl2 As Integer, ByRef sec As Integer, ByRef usec As Integer) As Integer
    Public Declare Function AX1_TimeGetSeconds Lib "AX1W32.DLL" Alias "_AX1_TimeGetSeconds@16" (ByVal tth As Integer, ByVal ttl As Integer, ByRef sec As Integer, ByRef usec As Integer) As Integer
    Public Declare Function AX1_TrigClearBits Lib "AX1W32.DLL" Alias "_AX1_TrigClearBits@8" (ByVal bits As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_TrigGetVal Lib "AX1W32.DLL" Alias "_AX1_TrigGetVal@8" (ByRef trigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_TrigSetBits Lib "AX1W32.DLL" Alias "_AX1_TrigSetBits@8" (ByVal bits As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_TrigSetVal Lib "AX1W32.DLL" Alias "_AX1_TrigSetVal@8" (ByVal trigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_TrigSinkConfig Lib "AX1W32.DLL" Alias "_AX1_TrigSinkConfig@20" (ByVal ctrlflags As Integer, ByVal trigid As Short, ByVal ulComp As Integer, ByVal ulMask As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLConfig Lib "AX1W32.DLL" Alias "_AX1_VLConfig@28" (ByVal configval As Integer, ByVal vlid As Short, ByVal bag As Short, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLConfigMAC Lib "AX1W32.DLL" Alias "_AX1_VLConfigMAC@32" (ByVal configval As Integer, ByVal macdst As ADDRESS, ByVal bag As Short, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetHandle Lib "AX1W32.DLL" Alias "_AX1_VLGetHandle@16" (ByVal vlid As Short, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetHandleMAC Lib "AX1W32.DLL" Alias "_AX1_VLGetHandleMAC@16" (ByRef pmacdst As ADDRESS, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetInfo Lib "AX1W32.DLL" Alias "_AX1_VLGetInfo@40" (ByRef configval As Integer, ByRef vlid As Short, ByRef pmacdst As ADDRESS, ByRef pmacsrc As ADDRESS, ByRef ipdst As Integer, ByRef ipsrc As Integer, ByRef bag As Integer, ByRef skew As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetNext Lib "AX1W32.DLL" Alias "_AX1_VLGetNext@20" (ByVal flag As Short, ByRef nextVL As Short, ByVal lastVL As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetNextMAC Lib "AX1W32.DLL" Alias "_AX1_VLGetNextMAC@24" (ByVal flag As Short, ByRef pnextMAC As ADDRESS, ByVal lastMAC As ADDRESS, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetPortCount Lib "AX1W32.DLL" Alias "_AX1_VLGetPortCount@12" (ByRef portcnt As Short, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLSetFactors Lib "AX1W32.DLL" Alias "_AX1_VLSetFactors@24" (ByVal factor0 As Integer, ByVal factor1 As Integer, ByVal factor2 As Integer, ByVal factor3 As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardCheck Lib "AX1W32.DLL" Alias "_AX1_CardCheck@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardGetInfo Lib "AX1W32.DLL" Alias "_AX1_CardGetInfo@8" (ByVal infotype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardGetInfoName Lib "AX1W32.DLL" Alias "_AX1_CardGetInfoName@4" (ByVal handleval As Integer) As String
    Public Declare Sub AX1_CardInit Lib "AX1W32.DLL" Alias "_AX1_CardInit@0" ()
    Public Declare Function AX1_CardIsHostRcv Lib "AX1W32.DLL" Alias "_AX1_CardIsHostRcv@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardIsRunning Lib "AX1W32.DLL" Alias "_AX1_CardIsRunning@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CardOpenEx Lib "AX1W32.DLL" Alias "_AX1_CardOpenEx@12" (ByRef lpHandle As Integer, ByVal cardname As String, ByVal cardnum As Integer) As Integer
    Public Declare Function AX1_CardOpenExx Lib "AX1W32.DLL" Alias "_AX1_CardOpenExx@20" (ByRef lpHandle As Integer, ByVal cardname As String, ByVal cardnum As Integer, ByRef hAppWnd As Integer, ByVal uiRemovalMsg As Short) As Integer
    Public Declare Function AX1_CardResetEx Lib "AX1W32.DLL" Alias "_AX1_CardResetEx@4" (ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_CardResetExx Lib "AX1W32.DLL" Alias "_AX1_CardResetExx@4" (ByVal handleval As Integer)
    Public Declare Function AX1_Checksum Lib "AX1W32.DLL" Alias "_AX1_Checksum@12" (ByVal msb As Byte, ByVal lsb As Byte, ByVal sum As Short) As Short
    Public Declare Function AX1_CommRpcArgStart Lib "AX1W32.DLL" Alias "_AX1_CommRpcArgStart@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcArgStop Lib "AX1W32.DLL" Alias "_AX1_CommRpcArgStop@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcCall Lib "AX1W32.DLL" Alias "_AX1_CommRpcCall@8" (ByVal rpcnum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcCallEx Lib "AX1W32.DLL" Alias "_AX1_CommRpcCallEx@8" (ByVal rpcnum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcInParam Lib "AX1W32.DLL" Alias "_AX1_CommRpcInParam@20" (ByRef parg As Integer, ByVal argsize As Integer, ByVal ptrflag As Integer, ByVal copyflag As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcInParamPtr Lib "AX1W32.DLL" Alias "_AX1_CommRpcInParamPtr@16" (ByRef parg As Integer, ByVal argsize As Integer, ByVal copyflag As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcInParamVal Lib "AX1W32.DLL" Alias "_AX1_CommRpcInParamVal@12" (ByRef parg As Integer, ByVal argsize As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommRpcOutParamPtr Lib "AX1W32.DLL" Alias "_AX1_CommRpcOutParamPtr@16" (ByVal index As Integer, ByRef parg As Integer, ByVal argsize As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_CommTrigger Lib "AX1W32.DLL" Alias "_AX1_CommTrigger@12" (ByVal waittype As Integer, ByVal trignum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DetectPort Lib "AX1W32.DLL" Alias "_AX1_DetectPort@12" (ByRef portnum As Short, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DetectVL Lib "AX1W32.DLL" Alias "_AX1_DetectVL@12" (ByRef vlid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DetectVLIgnore Lib "AX1W32.DLL" Alias "_AX1_DetectVLIgnore@12" (ByVal vlid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_Div Lib "AX1W32.DLL" Alias "_AX1_Div@8" (ByVal diva As Integer, ByVal divb As Integer) As Integer
    Public Declare Function AX1_DllUsageCount Lib "AX1W32.DLL" Alias "_AX1_DllUsageCount@0" () As Integer
    Public Declare Function AX1_DMAInstall Lib "AX1W32.DLL" Alias "_AX1_DMAInstall@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAInstallEx Lib "AX1W32.DLL" Alias "_AX1_DMAInstallEx@8" (ByVal size As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAPipeClose Lib "AX1W32.DLL" Alias "_AX1_DMAPipeClose@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAPipeOpen Lib "AX1W32.DLL" Alias "_AX1_DMAPipeOpen@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAUninstall Lib "AX1W32.DLL" Alias "_AX1_DMAUninstall@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerEntry Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerEntry@4" (ByRef lpParam As Integer) As Integer
    Public Declare Function AX1_DMAWorkerGetBusyCount Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerGetBusyCount@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerIsPause Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerIsPause@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerPause Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerPause@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerStart Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerStart@12" (ByRef pVirt As Integer, ByVal sizeval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerStop Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerStop@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_DMAWorkerUnpause Lib "AX1W32.DLL" Alias "_AX1_DMAWorkerUnpause@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrCtrlGetConfig Lib "AX1W32.DLL" Alias "_AX1_ErrCtrlGetConfig@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrDesc Lib "AX1W32.DLL" Alias "_AX1_ErrDesc@4" (ByVal errval As Integer) As String
    Public Declare Function AX1_ErrDescStr Lib "AX1W32.DLL" Alias "_AX1_ErrDescStr@4" (ByVal errval As Integer) As String
    Public Declare Function AX1_ErrName Lib "AX1W32.DLL" Alias "_AX1_ErrName@4" (ByVal errval As Integer) As String
    Public Declare Function AX1_ErrNetGetEnable Lib "AX1W32.DLL" Alias "_AX1_ErrNetGetEnable@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrPktGetConfig Lib "AX1W32.DLL" Alias "_AX1_ErrPktGetConfig@16" (ByRef pconfigval As Integer, ByRef pblendflags As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrPktGetConfigEx Lib "AX1W32.DLL" Alias "_AX1_ErrPktGetConfigEx@32" (ByRef pconfigval As Integer, ByRef pblendflags As Integer, ByRef ptrigid As Short, ByRef packet As Byte, ByVal pktlen As Short, ByRef ptotallen As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrRSNGetConfig Lib "AX1W32.DLL" Alias "_AX1_ErrRSNGetConfig@20" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByRef pmodifier As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_ErrXmtGetConfig Lib "AX1W32.DLL" Alias "_AX1_ErrXmtGetConfig@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_EventGetConfig Lib "AX1W32.DLL" Alias "_AX1_EventGetConfig@8" (ByRef pconfigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_ExpandMant Lib "AX1W32.DLL" Alias "_AX1_ExpandMant@8" (ByRef mant As Integer, ByRef exp As Integer)
    Public Declare Function AX1_FDSCalcOffset Lib "AX1W32.DLL" Alias "_AX1_FDSCalcOffset@20" (ByRef buf As Byte, ByVal fds_desc As FDSDESC, ByVal ds_num As Integer) As Integer
    Public Declare Function AX1_FDSStatusPriority Lib "AX1W32.DLL" Alias "_AX1_FDSStatusPriority@8" (ByVal prevstatus As Byte, ByVal status As Byte) As Byte
    Public Declare Sub AX1_FileClose Lib "AX1W32.DLL" Alias "_AX1_FileClose@0" ()
    Public Declare Function AX1_FileErr Lib "AX1W32.DLL" Alias "_AX1_FileErr@0" () As Integer
    Public Declare Sub AX1_FileErrClr Lib "AX1W32.DLL" Alias "_AX1_FileErrClr@0" ()
    Public Declare Sub AX1_FileErrSet Lib "AX1W32.DLL" Alias "_AX1_FileErrSet@0" ()
    Public Declare Function AX1_FileOpenRead Lib "AX1W32.DLL" Alias "_AX1_FileOpenRead@4" (ByVal filename As String) As Integer
    Public Declare Function AX1_FileOpenWrite Lib "AX1W32.DLL" Alias "_AX1_FileOpenWrite@4" (ByVal filename As String) As Integer
    Public Declare Function AX1_FileRead Lib "AX1W32.DLL" Alias "_AX1_FileRead@8" (ByRef buffer As Integer, ByVal count As Short) As Integer
    Public Declare Function AX1_FileSeek Lib "AX1W32.DLL" Alias "_AX1_FileSeek@4" (ByVal offset As Integer) As Integer
    Public Declare Function AX1_FileTell Lib "AX1W32.DLL" Alias "_AX1_FileTell@0" () As Integer
    Public Declare Function AX1_FileWrite Lib "AX1W32.DLL" Alias "_AX1_FileWrite@8" (ByRef buffer As Integer, ByVal count As Short) As Integer
    Public Declare Function AX1_GetHigh Lib "AX1W32.DLL" Alias "_AX1_GetHigh@4" (ByVal val As Integer) As Short
    Public Declare Function AX1_GetLow Lib "AX1W32.DLL" Alias "_AX1_GetLow@4" (ByVal val As Integer) As Short
    Public Declare Function AX1_HandleClose Lib "AX1W32.DLL" Alias "_AX1_HandleClose@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleDel Lib "AX1W32.DLL" Alias "_AX1_HandleDel@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleGet Lib "AX1W32.DLL" Alias "_AX1_HandleGet@24" (ByRef addr0 As Integer, ByRef addr1 As Integer, ByRef cardnum As Integer, ByRef devnum As Integer, ByRef sizval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleIns Lib "AX1W32.DLL" Alias "_AX1_HandleIns@20" (ByRef lpHandle As Integer, ByVal cardname As String, ByVal cardnum As Integer, ByRef hAppWnd As Integer, ByVal uiRemovalMsg As Short) As Integer
    Public Declare Function AX1_HandleOkay Lib "AX1W32.DLL" Alias "_AX1_HandleOkay@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleOpen Lib "AX1W32.DLL" Alias "_AX1_HandleOpen@12" (ByVal cardname As String, ByVal cardnum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleOpenWin95 Lib "AX1W32.DLL" Alias "_AX1_HandleOpenWin95@12" (ByVal cardname As String, ByVal cardnum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleOpenWinNT Lib "AX1W32.DLL" Alias "_AX1_HandleOpenWinNT@12" (ByVal cardname As String, ByVal cardnum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_HandleVer Lib "AX1W32.DLL" Alias "_AX1_HandleVer@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernDev Lib "AX1W32.DLL" Alias "_AX1_KernDev@8" (ByRef valueptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernEnd Lib "AX1W32.DLL" Alias "_AX1_KernEnd@4" (ByRef vxdptr As Integer) As Integer
    Public Declare Function AX1_KernIntClear Lib "AX1W32.DLL" Alias "_AX1_KernIntClear@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernIntInstall Lib "AX1W32.DLL" Alias "_AX1_KernIntInstall@36" (ByRef hEvent As Integer, ByVal clraddr As Integer, ByVal clrwidth As Integer, ByVal clrvalue As Integer, ByVal stataddr As Integer, ByVal statwidth As Integer, ByVal statvalue As Integer, ByVal statmask As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernIntStatus Lib "AX1W32.DLL" Alias "_AX1_KernIntStatus@8" (ByRef valueptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernIntUninstall Lib "AX1W32.DLL" Alias "_AX1_KernIntUninstall@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernIORdW Lib "AX1W32.DLL" Alias "_AX1_KernIORdW@12" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernIOWrW Lib "AX1W32.DLL" Alias "_AX1_KernIOWrW@12" (ByVal value As Short, ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMFillW Lib "AX1W32.DLL" Alias "_AX1_KernMEMFillW@20" (ByVal value As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMRdB Lib "AX1W32.DLL" Alias "_AX1_KernMEMRdB@16" (ByRef valueptr As Byte, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMRdL Lib "AX1W32.DLL" Alias "_AX1_KernMEMRdL@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMRdsL Lib "AX1W32.DLL" Alias "_AX1_KernMEMRdsL@20" (ByRef bufptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMRdsW Lib "AX1W32.DLL" Alias "_AX1_KernMEMRdsW@20" (ByRef bufptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMRdW Lib "AX1W32.DLL" Alias "_AX1_KernMEMRdW@16" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMWrB Lib "AX1W32.DLL" Alias "_AX1_KernMEMWrB@16" (ByVal value As Byte, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMWrL Lib "AX1W32.DLL" Alias "_AX1_KernMEMWrL@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMWrsL Lib "AX1W32.DLL" Alias "_AX1_KernMEMWrsL@20" (ByRef bufptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMWrsW Lib "AX1W32.DLL" Alias "_AX1_KernMEMWrsW@20" (ByRef bufptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernMEMWrW Lib "AX1W32.DLL" Alias "_AX1_KernMEMWrW@16" (ByVal value As Short, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernQuick Lib "AX1W32.DLL" Alias "_AX1_KernQuick@8" (ByVal flag As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernStatus Lib "AX1W32.DLL" Alias "_AX1_KernStatus@12" (ByRef valueptr As Integer, ByVal type As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_KernStatusEx Lib "AX1W32.DLL" Alias "_AX1_KernStatusEx@16" (ByRef valueptr As Integer, ByVal type As Integer, ByVal index As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_MakeLong Lib "AX1W32.DLL" Alias "_AX1_MakeLong@8" (ByVal valh As Short, ByVal vall As Short) As Integer
    Public Declare Function AX1_MantFromAscii Lib "AX1W32.DLL" Alias "_AX1_MantFromAscii@12" (ByVal str As String, ByRef mant As Integer, ByRef exp As Integer) As Integer
    Public Declare Function AX1_MantToAscii Lib "AX1W32.DLL" Alias "_AX1_MantToAscii@12" (ByVal buf As String, ByVal mant As Integer, ByVal exp As Integer) As String
    Public Declare Function AX1_Mask Lib "AX1W32.DLL" Alias "_AX1_Mask@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Sub AX1_MaxMant Lib "AX1W32.DLL" Alias "_AX1_MaxMant@8" (ByRef mant As Integer, ByRef exp As Integer)
    Public Declare Sub AX1_MEMWINFillW Lib "AX1W32.DLL" Alias "_AX1_MEMWINFillW@20" (ByVal value As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_MEMWINRdB Lib "AX1W32.DLL" Alias "_AX1_MEMWINRdB@12" (ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Byte
    Public Declare Function AX1_MEMWINRdL Lib "AX1W32.DLL" Alias "_AX1_MEMWINRdL@12" (ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_MEMWINRdsL Lib "AX1W32.DLL" Alias "_AX1_MEMWINRdsL@20" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_MEMWINRdsW Lib "AX1W32.DLL" Alias "_AX1_MEMWINRdsW@20" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_MEMWINRdW Lib "AX1W32.DLL" Alias "_AX1_MEMWINRdW@12" (ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer) As Short
    Public Declare Sub AX1_MEMWINWrB Lib "AX1W32.DLL" Alias "_AX1_MEMWINWrB@16" (ByVal value As Byte, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_MEMWINWrL Lib "AX1W32.DLL" Alias "_AX1_MEMWINWrL@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_MEMWINWrsL Lib "AX1W32.DLL" Alias "_AX1_MEMWINWrsL@20" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_MEMWINWrsW Lib "AX1W32.DLL" Alias "_AX1_MEMWINWrsW@20" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_MEMWINWrW Lib "AX1W32.DLL" Alias "_AX1_MEMWINWrW@16" (ByVal value As Short, ByVal addrval As Integer, ByVal bustype As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_Mod Lib "AX1W32.DLL" Alias "_AX1_Mod@8" (ByVal moda As Integer, ByVal modb As Integer) As Integer
    Public Declare Function AX1_Mul Lib "AX1W32.DLL" Alias "_AX1_Mul@8" (ByVal mula As Integer, ByVal mulb As Integer) As Integer
    Public Declare Function AX1_NetGetConfig Lib "AX1W32.DLL" Alias "_AX1_NetGetConfig@12" (ByRef pconfigval As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_NetSetConfig Lib "AX1W32.DLL" Alias "_AX1_NetSetConfig@12" (ByVal configval As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_NormalMant Lib "AX1W32.DLL" Alias "_AX1_NormalMant@8" (ByRef mant As Integer, ByRef exp As Integer)
    Public Declare Function AX1_ParamGetFrameFreq Lib "AX1W32.DLL" Alias "_AX1_ParamGetFrameFreq@16" (ByRef pconfigval As Integer, ByRef ppercent As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortConfigEx Lib "AX1W32.DLL" Alias "_AX1_PortConfigEx@32" (ByVal configval As Integer, ByVal dstid As Short, ByVal srcid As Short, ByVal depth As Short, ByVal reprate As Short, ByRef portptr As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetAny Lib "AX1W32.DLL" Alias "_AX1_PortGetAny@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortGetConfig Lib "AX1W32.DLL" Alias "_AX1_PortGetConfig@12" (ByRef pconfigval As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortIsHostRcv Lib "AX1W32.DLL" Alias "_AX1_PortIsHostRcv@8" (ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_PortSetConfig Lib "AX1W32.DLL" Alias "_AX1_PortSetConfig@12" (ByVal configval As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_RAMFill Lib "AX1W32.DLL" Alias "_AX1_RAMFill@16" (ByVal value As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_RAMRdB Lib "AX1W32.DLL" Alias "_AX1_RAMRdB@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Byte
    Public Declare Function AX1_RAMRdL Lib "AX1W32.DLL" Alias "_AX1_RAMRdL@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_RAMRdsL Lib "AX1W32.DLL" Alias "_AX1_RAMRdsL@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMRdsW Lib "AX1W32.DLL" Alias "_AX1_RAMRdsW@16" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_RAMRdW Lib "AX1W32.DLL" Alias "_AX1_RAMRdW@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Short
    Public Declare Sub AX1_RAMWipe Lib "AX1W32.DLL" Alias "_AX1_RAMWipe@4" (ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWipeEx Lib "AX1W32.DLL" Alias "_AX1_RAMWipeEx@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWrB Lib "AX1W32.DLL" Alias "_AX1_RAMWrB@12" (ByVal value As Byte, ByVal addrval As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWrL Lib "AX1W32.DLL" Alias "_AX1_RAMWrL@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWrsL Lib "AX1W32.DLL" Alias "_AX1_RAMWrsL@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWrsW Lib "AX1W32.DLL" Alias "_AX1_RAMWrsW@16" (ByRef valueptr As Short, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Integer)
    Public Declare Sub AX1_RAMWrW Lib "AX1W32.DLL" Alias "_AX1_RAMWrW@12" (ByVal value As Short, ByVal addrval As Integer, ByVal handleval As Integer)
    Public Declare Function AX1_RcvHostGetEnable Lib "AX1W32.DLL" Alias "_AX1_RcvHostGetEnable@8" (ByRef penableval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RevArray32 Lib "AX1W32.DLL" Alias "_AX1_RevArray32@8" (ByRef data As Byte, ByVal length As Integer) As Integer
    Public Declare Function AX1_RevWord64 Lib "AX1W32.DLL" Alias "_AX1_RevWord64@8" (ByRef data As Byte, ByVal offset As Integer) As Integer
    Public Declare Function AX1_RPC_CardCheck Lib "AX1W32.DLL" Alias "_AX1_RPC_CardCheck@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_CardClean Lib "AX1W32.DLL" Alias "_AX1_RPC_CardClean@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_CardDeviceInfoRd Lib "AX1W32.DLL" Alias "_AX1_RPC_CardDeviceInfoRd@12" (ByVal index As Integer, ByRef valueptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_CardIsRunning Lib "AX1W32.DLL" Alias "_AX1_RPC_CardIsRunning@8" (ByRef bRunning As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_CardStart Lib "AX1W32.DLL" Alias "_AX1_RPC_CardStart@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_CardStop Lib "AX1W32.DLL" Alias "_AX1_RPC_CardStop@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DcrRdL Lib "AX1W32.DLL" Alias "_AX1_RPC_DcrRdL@12" (ByRef data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DcrWrL Lib "AX1W32.DLL" Alias "_AX1_RPC_DcrWrL@12" (ByVal data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DefaultPortConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_DefaultPortConfig@16" (ByVal ctrlflags As Integer, ByVal netid As Short, ByVal depth As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DefaultPortGetHandle Lib "AX1W32.DLL" Alias "_AX1_RPC_DefaultPortGetHandle@12" (ByVal netid As Short, ByRef hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DetectPort Lib "AX1W32.DLL" Alias "_AX1_RPC_DetectPort@12" (ByRef portnum As Short, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DetectVL Lib "AX1W32.DLL" Alias "_AX1_RPC_DetectVL@12" (ByRef vlid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DetectVLIgnore Lib "AX1W32.DLL" Alias "_AX1_RPC_DetectVLIgnore@12" (ByVal vlid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_DmaParam Lib "AX1W32.DLL" Alias "_AX1_RPC_DmaParam@16" (ByVal addrh As Integer, ByVal addrl As Integer, ByVal sizeattr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrCtrlConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrCtrlConfig@16" (ByVal configval As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrCtrlGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrCtrlGetConfig@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrNetEnable Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrNetEnable@16" (ByVal netid As Short, ByVal configval As Integer, ByVal trigid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrNetGetEnable Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrNetGetEnable@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrPktConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrPktConfig@32" (ByVal configval As Integer, ByVal blendflags As Integer, ByVal trigid As Short, ByRef packet As Byte, ByVal pktlen As Short, ByVal totallen As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrPktGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrPktGetConfig@16" (ByRef pconfigval As Integer, ByRef pblendflags As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrPktGetConfigEx Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrPktGetConfigEx@32" (ByRef pconfigval As Integer, ByRef pblendflags As Integer, ByRef ptrigid As Short, ByRef packet As Byte, ByVal pktlen As Short, ByRef ptotallen As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrRSNConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrRSNConfig@20" (ByVal configval As Integer, ByVal trigid As Short, ByVal modifier As Short, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrRSNGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrRSNGetConfig@20" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByRef pmodifier As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrXmtConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrXmtConfig@16" (ByVal configval As Integer, ByVal trigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ErrXmtGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_ErrXmtGetConfig@16" (ByRef pconfigval As Integer, ByRef ptrigid As Short, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_EventConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_EventConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_EventGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_EventGetConfig@8" (ByRef pconfigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FlashClose Lib "AX1W32.DLL" Alias "_AX1_RPC_FlashClose@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FlashErase Lib "AX1W32.DLL" Alias "_AX1_RPC_FlashErase@8" (ByVal blocknum As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FlashOpen Lib "AX1W32.DLL" Alias "_AX1_RPC_FlashOpen@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FlashRead Lib "AX1W32.DLL" Alias "_AX1_RPC_FlashRead@16" (ByRef buf As Byte, ByVal addrval As Integer, ByVal length As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FlashWrite Lib "AX1W32.DLL" Alias "_AX1_RPC_FlashWrite@16" (ByRef buf As Byte, ByVal addrval As Integer, ByVal length As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_FrameGapConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_FrameGapConfig@16" (ByVal configval As Integer, ByVal busnum As Short, ByVal gapval As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_IicRdL Lib "AX1W32.DLL" Alias "_AX1_RPC_IicRdL@16" (ByRef data As Integer, ByVal devaddr As Byte, ByVal count As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_IicWrL Lib "AX1W32.DLL" Alias "_AX1_RPC_IicWrL@16" (ByRef data As Integer, ByVal devaddr As Byte, ByVal count As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_IntTrig Lib "AX1W32.DLL" Alias "_AX1_RPC_IntTrig@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MemRdL Lib "AX1W32.DLL" Alias "_AX1_RPC_MemRdL@12" (ByRef data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MemRdsB Lib "AX1W32.DLL" Alias "_AX1_RPC_MemRdsB@16" (ByVal addr As Integer, ByVal length As Integer, ByRef data As Byte, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MemRdsL Lib "AX1W32.DLL" Alias "_AX1_RPC_MemRdsL@16" (ByVal addr As Integer, ByVal length As Integer, ByRef data As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MemWrL Lib "AX1W32.DLL" Alias "_AX1_RPC_MemWrL@12" (ByVal data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MIBGetNetInfo Lib "AX1W32.DLL" Alias "_AX1_RPC_MIBGetNetInfo@20" (ByVal mibtype As Short, ByVal busnum As Short, ByRef data As Byte, ByVal length As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MIBGetPortInfo Lib "AX1W32.DLL" Alias "_AX1_RPC_MIBGetPortInfo@16" (ByVal hport As Integer, ByRef data As Byte, ByVal length As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_MIBGetVLInfo Lib "AX1W32.DLL" Alias "_AX1_RPC_MIBGetVLInfo@20" (ByVal hvl As Integer, ByVal mibtype As Short, ByRef data As Byte, ByVal length As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_NetConfig@20" (ByVal configval As Integer, ByVal netid As Short, ByVal macconst As Integer, ByVal speed As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetFlood Lib "AX1W32.DLL" Alias "_AX1_RPC_NetFlood@12" (ByVal bEnable As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_NetGetConfig@12" (ByRef pconfigval As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetGetVLCount Lib "AX1W32.DLL" Alias "_AX1_RPC_NetGetVLCount@12" (ByVal netid As Short, ByRef pvlcount As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetSetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_NetSetConfig@12" (ByVal configval As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_NetSetInterfaceID Lib "AX1W32.DLL" Alias "_AX1_RPC_NetSetInterfaceID@16" (ByVal netid As Short, ByVal idVal As Short, ByVal flags As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ParamFrameFreq Lib "AX1W32.DLL" Alias "_AX1_RPC_ParamFrameFreq@16" (ByVal configval As Integer, ByVal percent As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_ParamGetFrameFreq Lib "AX1W32.DLL" Alias "_AX1_RPC_ParamGetFrameFreq@16" (ByRef pconfigval As Integer, ByRef ppercent As Short, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_PortConfig@32" (ByVal configval As Integer, ByVal hvl As Integer, ByVal dstid As Short, ByVal srcid As Short, ByVal depth As Short, ByVal reprate As Short, ByRef portptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortDataRd Lib "AX1W32.DLL" Alias "_AX1_RPC_PortDataRd@28" (ByVal hport As Integer, ByRef data As Byte, ByRef lengthptr As Short, ByRef rsnptr As Byte, ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortDataWr Lib "AX1W32.DLL" Alias "_AX1_RPC_PortDataWr@20" (ByVal hport As Integer, ByRef data As Byte, ByVal length As Short, ByVal rsn As Byte, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetAny Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetAny@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetConfig@12" (ByRef pconfigval As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetHandle Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetHandle@16" (ByVal hvl As Integer, ByVal portnum As Short, ByRef hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetInfo Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetInfo@32" (ByVal hport As Integer, ByRef configval As Integer, ByRef vlid As Short, ByRef dstport As Short, ByRef srcport As Short, ByRef depth As Short, ByRef reprate As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetNext Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetNext@20" (ByVal hvl As Integer, ByRef nextPort As Short, ByVal lastPort As Short, ByVal flag As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortGetQueueCount Lib "AX1W32.DLL" Alias "_AX1_RPC_PortGetQueueCount@12" (ByVal hport As Integer, ByRef queuecount As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortInfoRd Lib "AX1W32.DLL" Alias "_AX1_RPC_PortInfoRd@28" (ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByRef activityptr As Integer, ByRef errorptr As Integer, ByRef rsnptr As Byte, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortRawRd Lib "AX1W32.DLL" Alias "_AX1_RPC_PortRawRd@24" (ByVal hport As Integer, ByRef packet As Byte, ByRef lengthptr As Short, ByRef timetaghptr As Integer, ByRef timetagptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortRawWr Lib "AX1W32.DLL" Alias "_AX1_RPC_PortRawWr@16" (ByVal hport As Integer, ByRef packet As Byte, ByVal length As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortRd Lib "AX1W32.DLL" Alias "_AX1_RPC_PortRd@12" (ByVal hport As Integer, ByRef pktdesc As AFDXPKTDESC, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortSetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_PortSetConfig@12" (ByVal configval As Integer, ByVal hport As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortSkipConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_PortSkipConfig@16" (ByVal hport As Integer, ByVal ctrlflags As Integer, ByVal trigid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_PortStepConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_PortStepConfig@16" (ByVal hport As Integer, ByVal ctrlflags As Integer, ByVal trigid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_RcvHostEnable Lib "AX1W32.DLL" Alias "_AX1_RPC_RcvHostEnable@8" (ByVal enableval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_RcvHostGetEnable Lib "AX1W32.DLL" Alias "_AX1_RPC_RcvHostGetEnable@8" (ByRef penableval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_RedundConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_RedundConfig@12" (ByVal configval As Integer, ByVal pairid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_RobinAddPort Lib "AX1W32.DLL" Alias "_AX1_RPC_RobinAddPort@32" (ByVal hrobin As Integer, ByVal hport As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedAddNoop Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedAddNoop@20" (ByVal netid As Short, ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedAddPort Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedAddPort@32" (ByVal netid As Short, ByVal hport As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedAddRobin Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedAddRobin@24" (ByVal netid As Short, ByVal hsub As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedAddSub Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedAddSub@24" (ByVal netid As Short, ByVal hsub As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedClear Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedClear@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedCrtRobin Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedCrtRobin@8" (ByRef hrobin As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedCrtSub Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedCrtSub@8" (ByRef hsub As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedFrameEnd Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedFrameEnd@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedFrameStart Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedFrameStart@12" (ByVal netid As Short, ByVal usframetime As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SchedItemUpdate Lib "AX1W32.DLL" Alias "_AX1_RPC_SchedItemUpdate@24" (ByVal hscheditem As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SdrRdL Lib "AX1W32.DLL" Alias "_AX1_RPC_SdrRdL@12" (ByRef data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SdrWrL Lib "AX1W32.DLL" Alias "_AX1_RPC_SdrWrL@12" (ByVal data As Integer, ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqClear Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqClear@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqGetConfig@8" (ByRef pconfigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqRd Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqRd@16" (ByRef buf As Byte, ByRef bufcount As Integer, ByRef reccount As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqSetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqSetConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqSetMonitor Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqSetMonitor@16" (ByVal netid As Short, ByVal vlid As Short, ByVal bmonitor As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SeqStatus Lib "AX1W32.DLL" Alias "_AX1_RPC_SeqStatus@20" (ByRef statusptr As Short, ByRef headptr As Integer, ByRef tailptr As Integer, ByRef configptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SubAddNoop Lib "AX1W32.DLL" Alias "_AX1_RPC_SubAddNoop@20" (ByVal hsub As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SubAddPort Lib "AX1W32.DLL" Alias "_AX1_RPC_SubAddPort@32" (ByVal hsub As Integer, ByVal hport As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByVal bTxA As Integer, ByVal bTxB As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_SubAddRobin Lib "AX1W32.DLL" Alias "_AX1_RPC_SubAddRobin@24" (ByVal hsub As Integer, ByVal hrobin As Integer, ByVal bSkip As Integer, ByVal bShot As Integer, ByRef hscheditem As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_Test1 Lib "AX1W32.DLL" Alias "_AX1_RPC_Test1@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_Test2 Lib "AX1W32.DLL" Alias "_AX1_RPC_Test2@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_Test3 Lib "AX1W32.DLL" Alias "_AX1_RPC_Test3@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_Test4 Lib "AX1W32.DLL" Alias "_AX1_RPC_Test4@4" (ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_TrigClearBits Lib "AX1W32.DLL" Alias "_AX1_RPC_TrigClearBits@8" (ByVal bits As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_TrigGetVal Lib "AX1W32.DLL" Alias "_AX1_RPC_TrigGetVal@8" (ByRef trigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_TrigSetBits Lib "AX1W32.DLL" Alias "_AX1_RPC_TrigSetBits@8" (ByVal bits As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_TrigSetVal Lib "AX1W32.DLL" Alias "_AX1_RPC_TrigSetVal@8" (ByVal trigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_TrigSinkConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_TrigSinkConfig@20" (ByVal trigid As Short, ByVal ctrlflags As Integer, ByVal ulComp As Integer, ByVal ulMask As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_VLConfig@44" (ByVal configval As Integer, ByVal netid As Short, ByVal vlid As Short, ByVal macsrc As ADDRESS, ByVal ipdst As Integer, ByVal ipsrc As Integer, ByVal bag As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLConfigMAC Lib "AX1W32.DLL" Alias "_AX1_RPC_VLConfigMAC@48" (ByVal configval As Integer, ByVal netid As Short, ByVal macdst As ADDRESS, ByVal macsrc As ADDRESS, ByVal ipdst As Integer, ByVal ipsrc As Integer, ByVal bag As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetConfig@12" (ByRef pconfigval As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetFactor Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetFactor@24" (ByRef pfactor0 As Integer, ByRef pfactor1 As Integer, ByRef pfactor2 As Integer, ByRef pfactor3 As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetHandle Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetHandle@16" (ByVal netid As Short, ByVal vlid As Short, ByRef hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetHandleMAC Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetHandleMAC@16" (ByVal netid As Short, ByRef pmacdst As ADDRESS, ByRef hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetInfo Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetInfo@40" (ByVal hvl As Integer, ByRef vlid As Short, ByRef pmacdst As ADDRESS, ByRef pmacsrc As ADDRESS, ByRef pconfigval As Integer, ByRef ipdst As Integer, ByRef ipsrc As Integer, ByRef bag_us As Integer, ByRef skewmax As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetJitter Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetJitter@28" (ByVal bReset As Integer, ByRef pJitA As Integer, ByRef pJitB As Integer, ByRef pMaxJitA As Integer, ByRef pMaxJitB As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetNext Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetNext@20" (ByVal netid As Short, ByRef nextVL As Short, ByVal lastVL As Short, ByVal flag As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetNextMAC Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetNextMAC@24" (ByVal netid As Short, ByRef nextMAC As ADDRESS, ByVal lastMAC As ADDRESS, ByVal flag As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLGetPortCount Lib "AX1W32.DLL" Alias "_AX1_RPC_VLGetPortCount@12" (ByVal hvl As Integer, ByRef portcnt As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLSetConfig Lib "AX1W32.DLL" Alias "_AX1_RPC_VLSetConfig@12" (ByVal configval As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_RPC_VLSetFactor Lib "AX1W32.DLL" Alias "_AX1_RPC_VLSetFactor@24" (ByVal factor0 As Integer, ByVal factor1 As Integer, ByVal factor2 As Integer, ByVal factor3 As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedBuildEx Lib "AX1W32.DLL" Alias "_AX1_SchedBuildEx@28" (ByVal vlcount As Integer, ByRef vlrobins As Integer, ByRef hvls As Integer, ByRef vlperiods_us As Integer, ByRef vlfactors As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedCalc Lib "AX1W32.DLL" Alias "_AX1_SchedCalc@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedClear Lib "AX1W32.DLL" Alias "_AX1_SchedClear@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Sub AX1_SchedDebug Lib "AX1W32.DLL" Alias "_AX1_SchedDebug@4" (ByVal debug As Integer)
    Public Declare Function AX1_SchedDoFrameEnd Lib "AX1W32.DLL" Alias "_AX1_SchedDoFrameEnd@12" (ByVal frametime_us As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoFrameInsert Lib "AX1W32.DLL" Alias "_AX1_SchedDoFrameInsert@28" (ByVal index As Integer, ByVal hsub As Integer, ByVal hvl As Integer, ByVal frametime_us As Integer, ByVal eventindex As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoFrameStart Lib "AX1W32.DLL" Alias "_AX1_SchedDoFrameStart@12" (ByVal frametime_us As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoRobinEnd Lib "AX1W32.DLL" Alias "_AX1_SchedDoRobinEnd@16" (ByVal hsub As Integer, ByVal hrobin As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoRobinInsert Lib "AX1W32.DLL" Alias "_AX1_SchedDoRobinInsert@20" (ByVal hsub As Integer, ByVal hrobin As Integer, ByVal index As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoRobinStart Lib "AX1W32.DLL" Alias "_AX1_SchedDoRobinStart@16" (ByRef phsub As Integer, ByRef phrobin As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoSchedEnd Lib "AX1W32.DLL" Alias "_AX1_SchedDoSchedEnd@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoSchedStart Lib "AX1W32.DLL" Alias "_AX1_SchedDoSchedStart@8" (ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoSubVLEnd Lib "AX1W32.DLL" Alias "_AX1_SchedDoSubVLEnd@8" (ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoSubVLInsert Lib "AX1W32.DLL" Alias "_AX1_SchedDoSubVLInsert@28" (ByVal hsub As Integer, ByRef hrobins As Integer, ByVal eventindex As Integer, ByVal preveventindex As Integer, ByVal index As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedDoSubVLStart Lib "AX1W32.DLL" Alias "_AX1_SchedDoSubVLStart@24" (ByRef phsub As Integer, ByRef hrobins As Integer, ByRef vlfactors As Integer, ByRef vlmods As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedFactor Lib "AX1W32.DLL" Alias "_AX1_SchedFactor@16" (ByRef phsub As Integer, ByRef vlfactors As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SchedMaxval Lib "AX1W32.DLL" Alias "_AX1_SchedMaxval@8" (ByRef array As Integer, ByVal arraycount As Integer) As Integer
    Public Declare Function AX1_SchedMinval Lib "AX1W32.DLL" Alias "_AX1_SchedMinval@8" (ByRef array As Integer, ByVal arraycount As Integer) As Integer
    Public Declare Sub AX1_SchedModval Lib "AX1W32.DLL" Alias "_AX1_SchedModval@8" (ByRef vlfactors As Integer, ByRef vlmods As Integer)
    Public Declare Function AX1_SeqDMARd Lib "AX1W32.DLL" Alias "_AX1_SeqDMARd@12" (ByRef bufptr As Byte, ByRef bufcountptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqDMARdEx Lib "AX1W32.DLL" Alias "_AX1_SeqDMARdEx@16" (ByRef bufptr As Byte, ByRef bufcountptr As Integer, ByRef reccountptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqGetConfig Lib "AX1W32.DLL" Alias "_AX1_SeqGetConfig@8" (ByRef pconfigval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqRdEx Lib "AX1W32.DLL" Alias "_AX1_SeqRdEx@16" (ByRef bufptr As Byte, ByRef bufcountptr As Integer, ByRef reccountptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqSetConfig Lib "AX1W32.DLL" Alias "_AX1_SeqSetConfig@8" (ByVal configval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_SeqStatusEx Lib "AX1W32.DLL" Alias "_AX1_SeqStatusEx@20" (ByRef statusptr As Short, ByRef headptr As Integer, ByRef tailptr As Integer, ByRef configptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_Shl Lib "AX1W32.DLL" Alias "_AX1_Shl@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Function AX1_Shr Lib "AX1W32.DLL" Alias "_AX1_Shr@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Function AX1_SignMant Lib "AX1W32.DLL" Alias "_AX1_SignMant@4" (ByVal str As String) As Short
    Public Declare Function AX1_Transpose12 Lib "AX1W32.DLL" Alias "_AX1_Transpose12@4" (ByVal val As Short) As Short
    Public Declare Function AX1_ValAsciiCmpi Lib "AX1W32.DLL" Alias "_AX1_ValAsciiCmpi@8" (ByVal str1 As String, ByVal str2 As String) As Integer
    Public Declare Function AX1_ValAsciiCpy Lib "AX1W32.DLL" Alias "_AX1_ValAsciiCpy@12" (ByVal strdest As String, ByVal strsrc As String, ByVal count As Integer) As String
    Public Declare Sub AX1_ValAsciiTrimLead Lib "AX1W32.DLL" Alias "_AX1_ValAsciiTrimLead@4" (ByVal buf As String)
    Public Declare Sub AX1_ValAsciiTrimTrail Lib "AX1W32.DLL" Alias "_AX1_ValAsciiTrimTrail@4" (ByVal buf As String)
    Public Declare Function AX1_ValFromAscii Lib "AX1W32.DLL" Alias "_AX1_ValFromAscii@8" (ByVal asciistr As String, ByVal radixval As Integer) As Integer
    Public Declare Function AX1_ValGetBits Lib "AX1W32.DLL" Alias "_AX1_ValGetBits@12" (ByVal oldvalue As Integer, ByVal startbit As Integer, ByVal endbit As Integer) As Integer
    Public Declare Function AX1_ValIncAscii Lib "AX1W32.DLL" Alias "_AX1_ValIncAscii@4" (ByVal asciistr As String) As String
    Public Declare Function AX1_ValInccAscii Lib "AX1W32.DLL" Alias "_AX1_ValInccAscii@4" (ByVal asciistr As String) As String
    Public Declare Function AX1_ValIsLower Lib "AX1W32.DLL" Alias "_AX1_ValIsLower@4" (ByVal value As Integer) As Integer
    Public Declare Function AX1_ValLenAscii Lib "AX1W32.DLL" Alias "_AX1_ValLenAscii@8" (ByVal numbits As Integer, ByVal radixval As Integer) As Integer
    Public Declare Function AX1_ValPutBits Lib "AX1W32.DLL" Alias "_AX1_ValPutBits@16" (ByVal oldvalue As Integer, ByVal newfld As Integer, ByVal startbit As Integer, ByVal endbit As Integer) As Integer
    Public Declare Function AX1_ValToAscii Lib "AX1W32.DLL" Alias "_AX1_ValToAscii@16" (ByVal value As Integer, ByVal asciistr As String, ByVal numbits As Integer, ByVal radixval As Integer) As String
    Public Declare Function AX1_ValToUpper Lib "AX1W32.DLL" Alias "_AX1_ValToUpper@4" (ByVal value As Integer) As Integer
    Public Declare Function AX1_VLConfigEx Lib "AX1W32.DLL" Alias "_AX1_VLConfigEx@28" (ByVal configval As Integer, ByVal vlid As Short, ByVal bag_us As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLConfigExx Lib "AX1W32.DLL" Alias "_AX1_VLConfigExx@44" (ByVal configval As Integer, ByVal vlid As Short, ByVal macsrc As ADDRESS, ByVal ipdst As Integer, ByVal ipsrc As Integer, ByVal bag_us As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLConfigMACEx Lib "AX1W32.DLL" Alias "_AX1_VLConfigMACEx@32" (ByVal configval As Integer, ByVal macdst As ADDRESS, ByVal bag_us As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLConfigMACExx Lib "AX1W32.DLL" Alias "_AX1_VLConfigMACExx@48" (ByVal configval As Integer, ByVal macdst As ADDRESS, ByVal macsrc As ADDRESS, ByVal ipdst As Integer, ByVal ipsrc As Integer, ByVal bag_us As Integer, ByVal skewmax As Integer, ByRef hvl As Integer, ByVal netid As Short, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetConfig Lib "AX1W32.DLL" Alias "_AX1_VLGetConfig@12" (ByRef pconfigval As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetFactors Lib "AX1W32.DLL" Alias "_AX1_VLGetFactors@24" (ByRef pfactor0 As Integer, ByRef pfactor1 As Integer, ByRef pfactor2 As Integer, ByRef pfactor3 As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLGetInfoEx Lib "AX1W32.DLL" Alias "_AX1_VLGetInfoEx@40" (ByRef configval As Integer, ByRef vlid As Short, ByRef pmacdst As ADDRESS, ByRef pmacsrc As ADDRESS, ByRef ipdst As Integer, ByRef ipsrc As Integer, ByRef bag_us As Integer, ByRef skew As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLIsHostRcv Lib "AX1W32.DLL" Alias "_AX1_VLIsHostRcv@8" (ByVal hvl As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function AX1_VLSetConfig Lib "AX1W32.DLL" Alias "_AX1_VLSetConfig@12" (ByVal configval As Integer, ByVal hvl As Integer, ByVal handleval As Integer) As Integer

End Module
