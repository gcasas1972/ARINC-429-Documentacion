
/**
*
*  BTICard TEST EXAMPLE  (02/26/2010)
*  Copyright (c) 2004-2010
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   bticard_test.c -- Tests installed cards
*
**/

/**
*
*  This example will open the specified card number, print useful
*  information about the card's configuration, and run a series
*  of diagnostic tests on the card.  If an error is encountered,
*  a message is displayed indicating the type of error that occurred.
*
**/

#include <BTICard.h>
#include <BTI1553.h>
#include <BTI429.h>
#include <BTI708.h>
#include <BTI717.h>
#include <BTI422.h>
#include <BTICSDB.h>
#include <BTIDIO.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define TRUE 1
#define FALSE 0

#define MAXCORES 4
#define MAXCHANS 64
#define CISSIZE  64

ERRVAL TEST_CardInfo(INT cardnum,HCARD hCard);
ERRVAL TEST_CoreInfo(INT corenum,HCORE hCore);

BOOL skipio   = FALSE;
BOOL skipmem  = FALSE;
BOOL skipcomm = FALSE;
BOOL skipbus  = FALSE;

USHORT crc8(USHORT crc,USHORT value)
{
	USHORT j;
	USHORT temp;
	const USHORT key = 0x008C;

	value &= 0x00FF;
	crc   &= 0x00FF;

	for (j=0;j<8;++j,value>>=1)
	{
		temp = crc & 1;
		crc  >>= 1;
		if (temp ^ (value & 1)) crc ^= key;
	}

	return(crc);
}

/**
*
*  This helper function checks for the help option on the
*  command line.
*
**/

int isarghelp(int argc,char *argv[])
{
	int j;

	for (j=0;j<argc;++j)
	{
		if (!strcmp(argv[j],"?") || !strcmp(argv[j],"-?") || !strcmp(argv[j],"/?"))
		{
			return(1);
		}
	}
	return(0);
}

/**
*
*  This helper function checks for options on the
*  command line.
*
**/

char *isargopt(int argc,char *argv[],const char *opts)
{
	USHORT j;

	for (j=0;j<argc;++j)
	{
		if ((*argv[j]=='-' || *argv[j]=='/') && !strncmp(opts,argv[j]+1,strlen(opts)))
		{
			return(argv[j]+strlen(opts)+1);
		}
	}
	return(NULL);
}

int main(INT argc,LPSTR *argv)
{
	CHAR *opts;
	INT cardnum = 0;
	HCARD hCard;
	HCORE hCore[MAXCORES];
	ERRVAL errval;
	ERRVAL core_results[MAXCORES];
	INT corecount;
	INT j;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICARD_TEST  (02/26/2010)                                        *");
	printf("\n    *  Copyright 2004-2010  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICARD Example                                                   *");
	printf("\n    *  \"Tests installed cards.\"                                          *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

	if (isarghelp(argc,argv))
	{
		printf("\nUsage:  bticard_test [options]");
		printf("\n");

		printf("\n-?                      Display help information");
		printf("\n-CARDNUM:<cardnum>      Card number.  Default 0.");
		printf("\n-NOIO                   Do not run I/O tests.");
		printf("\n-NOMEM                  Do not run memory tests.");
		printf("\n-NOCOMM                 Do not run comm process tests.");
		printf("\n-NOBUS                  Do not run databus tests.");
		printf("\n");

		exit(0);
	}

/**
*
*  Check for the -CARDNUM:<cardnum> option.
*
**/

	if ((opts = isargopt(argc,argv,"CARDNUM")) != NULL)
	{
		if (*opts++ != ':')
		{
			printf(	"\nError:  Semicolon is missing after option."
							"\n        Use the form -CARDNUM:<cardnum>.");
			printf( "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf( "\nError:  Card number is missing after option."
							"\n        Use the form -CARDNUM:<cardnum>.");
			printf( "\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&cardnum)!=1)
		{
			printf("\nError:  Card number is not a decimal number.");
			printf("\n        Use the form -CARDNUM:dd.");
			printf("\n");
			exit(1);
		}

		printf("\nUsing card number %u.",cardnum);
	}

/**
*
*  Check for other options.
*
**/

	if ((opts = isargopt(argc,argv,"NOIO"))    != NULL) skipio   = TRUE;
	if ((opts = isargopt(argc,argv,"NOMEM"))   != NULL) skipmem  = TRUE;
	if ((opts = isargopt(argc,argv,"NOCOMM"))  != NULL) skipcomm = TRUE;
	if ((opts = isargopt(argc,argv,"NOBUS"))   != NULL) skipbus  = TRUE;

/**
*
*  Open the card
*
**/

	errval = BTICard_CardOpen(&hCard,cardnum);

	if (errval)
	{
		printf("\nError:  Unable to request handle for card number %u.",cardnum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

/**
*
*  Get Core handles
*
**/

	for (corecount=0;corecount<MAXCORES;corecount++)
	{
		hCore[corecount] = 0;
		errval = BTICard_CoreOpen(&hCore[corecount],corecount,hCard);
		if (errval) break;
	}

/**
*
*  Get and print Main Board Production Info
*
**/

	errval = TEST_CardInfo(cardnum,hCard);

	if (errval)
	{
		printf("\nError:  Unable to get info for card number %u.",cardnum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
	}

/**
*
*  Get and print Core Production Info
*
**/

	for (j=0;j<corecount;j++)
	{
		errval = TEST_CoreInfo(j,hCore[j]);

		if (errval && (errval != ERR_SELFXMTFAIL))
		{
			printf("\nError:  An error occurred while testing Core %c.",'A'+j);
			printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
			printf("\n");
		}

		core_results[j] = errval;
	}

	printf("\n");

/**
*
*  Display the test results
*
**/

	printf("\n-------------------------------------------------------------------------------");
	printf("\nTest results for Card %d (%s):",cardnum,BTICard_CardTypeStr(hCard));

	for (j=0;j<corecount;j++)
	{
		printf("\n    Core %c: %s",'A'+j,(core_results[j]) ? "** FAILED **" : "** PASSED **");
	}

	printf("\n");

/**
*
*  Close the card
*
**/

	errval = BTICard_CardClose(hCard);

	if (errval)
	{
		printf("\nError:  Unable to release handle for card number %u.",cardnum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	exit(0);
	return(0);
}

ERRVAL TEST_CardInfo(INT cardnum,HCARD hCard)
{
	ERRVAL errval=ERR_NONE;
	CHAR name[32];
	ULONG ulVersion;
	ULONG ulPlat;
	ULONG ulDate;
	USHORT cisbuf[CISSIZE];
	USHORT ciscrc = 0;
	char str1[8],str2[8];
	char buf[256];
	ULONG boardnum = 0;
	INT j;
	ULONG pipecount;
	ULONG maxpktsize;

	enum {STATTYPE_PIPECOUNT  = 0x00000019};		//Number if pipes
	enum {STATTYPE_MAXPKTSIZE = 0x0000001A};		//Max packet size(pipe number)

	sprintf(name,"Card %u (%s)",cardnum,BTICard_CardTypeStr(hCard));

	printf("\n");
	printf("\nInformation from %s",name);
	printf("\n-------------------------------------------------------------------------------");

	printf("\nModel: %s", BTICard_CardProductStr(hCard));

/**
*
*  Read USB
*
**/

	errval = BTICard_HandleInfo(buf,NULL,NULL,NULL,hCard);		//Get card string

	if (!errval && (!strncmp(buf,"USB5G",5) || !strncmp(buf,"BUSBox",6)))	//If a USB device
	{
		errval = BTICard_KernStatus(&pipecount,STATTYPE_PIPECOUNT,hCard);

		if (!errval && pipecount)
		{
			errval = BTICard_KernStatus(&maxpktsize,STATTYPE_MAXPKTSIZE,hCard);

			if (!errval)
			{
				printf("\nSpeed: USB %s-speed",(512==maxpktsize) ? "high" : "full");
			}
		}
	}

/**
*
*  See if co-processor is present
*
**/

	errval = BTICard_CoProcGetInfo(&ulPlat,COPROCINFO_PLAT,hCard);

	if (!errval)
	{
		printf("\n");
		printf("\nCo-Processor present");

		switch (ulPlat)
		{
			default:
				printf("\n");
				printf("\nError:  Unknown co-processor firmware platform");
				break;

			case 0x4734:		//4GBoot Platform '4G'
				printf("\n4GBoot Firmware");
				break;

			case 0x4C4F:		//Platfrom 'OL'
				printf("\nOmniLinux");
				break;

			case 0x3741:		//Platfrom 'A7'
				printf("\nBTIApp7 Firmware");
				break;

			case 0x4735:		//5GUSB Platform '5G'
				printf("\nUSB5G Firmware");
				break;
		}

/**
*
*  Version
*
**/

		errval = BTICard_CoProcGetInfo(&ulVersion,COPROCINFO_VERSIONEX,hCard);

		if (errval)
		{
			printf("\n");
			printf("\nError:  Unable to read co-processor firmware version");
		}
		else if (!ulVersion)
		{
			errval = BTICard_CoProcGetInfo(&ulVersion,COPROCINFO_VERSION,hCard);

			if (errval)
			{
				printf("\n");
				printf("\nError:  Unable to read co-processor firmware version");
			}
			else
			{
				printf("\nVersion %u.%u",(ulVersion>>8) & 0xFF,(ulVersion>>0) & 0xFF);
			}
		}
		else
		{
			printf("\nVersion %u.%u.%u",(ulVersion>>16) & 0xFF,(ulVersion>>8) & 0xFF,(ulVersion>>0) & 0xFF);
		}

/**
*
*  Date
*
**/

		errval = BTICard_CoProcGetInfo(&ulDate,COPROCINFO_DATE,hCard);

		if (errval)
		{
			printf("\n");
			printf("\nError:  Unable to read co-processor platform");
		}
		else
		{
			printf("\nDate %02u/%02u/%04u",(ulDate>>8) & 0xFF,(ulDate>>0) & 0xFF,(ulDate>>16) & 0xFFFF);
		}
	}

/**
*
*  Read CIS information
*
**/

	errval = BTICard_CISRd(cisbuf,CISSIZE,CISTYPE_CARD,hCard);

	if (!errval && cisbuf[0x00]!=0xFFFF)
	{
		printf("\n");
		printf("\nMain board production information on %s.",name);
		printf("\n-------------------------------------------------------------------------------");

		for (j=0;j<CISSIZE-1;j++)
		{
			ciscrc = crc8(ciscrc,cisbuf[j] >> 0);
			ciscrc = crc8(ciscrc,cisbuf[j] >> 8);
		}

		printf("\nPCB Assembly #%05X",((((ULONG)cisbuf[0x00])<<16) + (((ULONG)cisbuf[0x01])<<0)) >> 12),
		printf("\nRevision %c",'@' + ((cisbuf[0x01]>>8) & 0x0F)),
		printf("\nOption #%02u",(cisbuf[0x01]>>0) & 0xFF),
		printf("\nModel #%04X",	  cisbuf[0x02]);
		printf("\nSerial #%04X",  cisbuf[0x03]);
		printf("\nDate %02X/%02X/%04X",(cisbuf[0x3C]>>8) & 0xFF,(cisbuf[0x3C]>>0) & 0xFF,(cisbuf[0x3D]>>0) & 0xFFFF);
		printf("\nVersion %04X",cisbuf[0x3E]);
		printf("\nCRC %04X",cisbuf[0x3F]);
		printf("\nExpected CRC %04X",ciscrc);

		sprintf(str1,"%3X",cisbuf[2]);
		errval = BTICard_CoProcGetInfo(&boardnum,COPROCINFO_PROD,hCard);
		sprintf(str2,"%3d",(INT)boardnum);

		if (strcmp(str1,str2) && (!errval))
		{
			printf("\n");
			printf("\nWarning: Main Board CIS does not match Firmware model!");
		}

		errval = ERR_NONE;
	}

	return(errval);
}

ERRVAL TEST_CoreInfo(INT corenum,HCORE hCore)
{
	ERRVAL errval=ERR_NONE;
	CHAR name[32];
	USHORT bufmodel[32];
	USHORT cisbuf[CISSIZE];
	USHORT ciscrc = 0;
	char str1[8],str2[8];
	BOOL module_match = FALSE;
	ULONG count1553;
	ULONG count429;
	ULONG count717;
	ULONG count708;
	ULONG count422;
	ULONG countCSDB;
	ULONG countDIO;
	ULONG chinfo;
	INT j;
	ULONG modelnum = 0;
	INT stroff;

	BOOL discin,discout,discseries,discshunt;
	CHAR buf[256];

	modelnum = BTICard_CardGetInfo(INFOTYPE_PROD,0,hCore);

	sprintf(name,"Core %c",corenum + 'A');

/**
*
*  Read CIS information
*
**/

	errval = BTICard_CISRd(cisbuf,CISSIZE,CISTYPE_IOMODULE,hCore);

	if (!errval && cisbuf[0x00]!=0xFFFF)
	{
		printf("\n");
		printf("\nI/O module production information on %s.",name);
		printf("\n-------------------------------------------------------------------------------");

		for (j=0;j<CISSIZE-1;j++)
		{
			ciscrc = crc8(ciscrc,cisbuf[j] >> 0);
			ciscrc = crc8(ciscrc,cisbuf[j] >> 8);
		}

		printf("\nPCB Assembly #%05X",((((ULONG)cisbuf[0x00])<<16) + (((ULONG)cisbuf[0x01])<<0)) >> 12),
		printf("\nRevision %c",'@' + ((cisbuf[0x01]>>8) & 0x0F)),
		printf("\nOption #%02u",(cisbuf[0x01]>>0) & 0xFF),
		printf("\nModel #%04X",	  cisbuf[0x02]);
		printf("\nSerial #%04X",  cisbuf[0x03]);
		printf("\nDate %02X/%02X/%04X",(cisbuf[0x3C]>>8) & 0xFF,(cisbuf[0x3C]>>0) & 0xFF,(cisbuf[0x3D]>>0) & 0xFFFF);
		printf("\nVersion %04X",cisbuf[0x3E]);
		printf("\nCRC %04X",cisbuf[0x3F]);
		printf("\nExpected CRC %04X",ciscrc);

		sprintf(str1,"%3X",cisbuf[2]);
		sprintf(str2,"%3d",(INT)modelnum);

		if (strcmp(str1,str2))
		{
			printf("\n");
			printf("\nWarning: I/O Module CIS does not match Firmware model!");
		}
		else
		{
			module_match = TRUE;
		}
	}
	else if (modelnum)
	{
		printf("\n");
		printf("\nERROR: I/O Module CIS not programmed!!!");
	}

/**
*
*  Survey protocols
*
**/

	printf("\n");
	printf("\nProtocols supported on %s.",name);
	printf("\n-------------------------------------------------------------------------------");

	count1553 = BTICard_CardGetInfo(INFOTYPE_1553COUNT,0,hCore);
	count429  = BTICard_CardGetInfo(INFOTYPE_429COUNT, 0,hCore);
	count717  = BTICard_CardGetInfo(INFOTYPE_717COUNT, 0,hCore);
	count708  = BTICard_CardGetInfo(INFOTYPE_708COUNT, 0,hCore);
	count422  = BTICard_CardGetInfo(INFOTYPE_422COUNT, 0,hCore);
	countCSDB = BTICard_CardGetInfo(INFOTYPE_CSDBCOUNT,0,hCore);
	countDIO  = BTICard_CardGetInfo(INFOTYPE_DIOCOUNT, 0,hCore);

	if (count1553) printf("\nMIL-STD-1553 - %d channel(s).",count1553);
	if (count429)  printf("\nARINC 429    - %d channel(s).",count429);
	if (count717)  printf("\nARINC 717    - %d channel(s).",count717);
	if (count708)  printf("\nARINC 708    - %d channel(s).",count708);
	if (count422)  printf("\nRS-422       - %d port(s).   ",count422);
	if (countCSDB) printf("\nCSDB         - %d channel(s).",countCSDB);
	if (countDIO)  printf("\nDIO          - %d bank(s).",countDIO);

/**
*
*  Get channel configuration
*
**/

	printf("\n");
	printf("\nChannel configuration of %s.",name);
	printf("\n-------------------------------------------------------------------------------");

	for (j=0;j<MAXCHANS;j++)
	{
		if (BTI1553_ChIs1553(j,hCore))
		{
			if (BTI1553_ChIsA(j,hCore))        printf("\nChannel %2d is a MIL-STD-1553 channel (Model A).",j);
			else if (BTI1553_ChIsB4(j,hCore))  printf("\nChannel %2d is a MIL-STD-1553 channel (Model B4).",j);
			else if (BTI1553_ChIsB32(j,hCore)) printf("\nChannel %2d is a MIL-STD-1553 channel (Model B32).",j);
			else if (BTI1553_ChIsC(j,hCore))   printf("\nChannel %2d is a MIL-STD-1553 channel (Model C).",j);
			else if (BTI1553_ChIsD(j,hCore))   printf("\nChannel %2d is a MIL-STD-1553 channel (Model D).",j);
			else if (BTI1553_ChIsM(j,hCore))   printf("\nChannel %2d is a MIL-STD-1553 channel (Model M).",j);
			else if (BTI1553_ChIsS(j,hCore))   printf("\nChannel %2d is a MIL-STD-1553 channel (Model S).",j);
			else if (BTI1553_ChIsBM(j,hCore))  printf("\nChannel %2d is a MIL-STD-1553 channel (Model BM).",j);
			else if (BTI1553_ChIsX(j,hCore))
			{
				printf("\nChannel %2d is a MIL-STD-1553 channel (Custom Model).",j);

				if (BTI1553_ChGetInfo(INFO1553_MULTIMODE,j,hCore))
				{
					chinfo = BTI1553_ChGetInfo(INFO1553_MAXCOUNT,j,hCore);
					if (!chinfo) chinfo = 32;
					printf("\n        Terminal Count: %d",chinfo);
				}
				else
				{
					printf("\n        Terminal Count: 1");
				}

				chinfo = BTI1553_ChGetInfo(INFO1553_ERRORGEN,j,hCore);
				printf("\n        Error Generation: %s",(chinfo) ? "Yes" : "No");

				chinfo = BTI1553_ChGetInfo(INFO1553_CONCURMON,j,hCore);
				printf("\n        Concurrent Monitor: %s",(chinfo) ? "Yes" : "No");

				chinfo = BTI1553_ChGetInfo(INFO1553_MONFILTER,j,hCore);
				printf("\n        Monitor Filtering: %s",(chinfo) ? "Yes" : "No");

				chinfo = BTI1553_ChGetInfo(INFO1553_PARAM,j,hCore);
				printf("\n        Parametric Control: %s",(chinfo) ? "Yes" : "No");
			}
		}

		if (BTI429_ChIsRcv(j,hCore)) printf("\nChannel %2d is an ARINC 429 Receive channel.",j);
		if (BTI429_ChIsXmt(j,hCore)) printf("\nChannel %2d is an ARINC 429 Transmit channel.",j);

		if (BTI717_ChIsSelEnc(j,hCore))
		{
			if (BTI717_ChIsRcv(j,hCore))      printf("\nChannel %2d is an ARINC 717 BiPhase/Bipolar selectable Receive channel.",j);
			if (BTI717_ChIsXmt(j,hCore))      printf("\nChannel %2d is an ARINC 717 BiPhase/Bipolar selectable Transmit channel.",j);
		}
		else if (BTI717_ChIsBiPhase(j,hCore)) printf("\nChannel %2d is an ARINC 717 Biphase (T/R configurable) channel.",j);
		else if (BTI717_ChIsRcv(j,hCore))     printf("\nChannel %2d is an ARINC 717 Bipolar Receive channel.",j);
		else if (BTI717_ChIsXmt(j,hCore))     printf("\nChannel %2d is an ARINC 717 Bipolar Transmit channel.",j);

		if (BTI708_ChIsRcv(j,hCore)) printf("\nChannel %2d is an ARINC 708 Receive channel.",j);
		if (BTI708_ChIsXmt(j,hCore)) printf("\nChannel %2d is an ARINC 708 Transmit channel.",j);

		if (BTI422_PortIs422(j,hCore)) printf("\nPort %2d is an RS-422 Transmit/Receive port.",j);

		if (BTICSDB_ChIsRcv(j,hCore)) printf("\nChannel %2d is a CSDB Receive channel.",j);
		if (BTICSDB_ChIsXmt(j,hCore)) printf("\nChannel %2d is a CSDB Transmit channel.",j);

		if (BTIDIO_BankIsDIO(j,hCore))
		{
			discin		= BTIDIO_BankGetInfo(INFODIO_INPUT,j,hCore);
			discout		= BTIDIO_BankGetInfo(INFODIO_OUTPUT,j,hCore);
			discseries	= BTIDIO_BankGetInfo(INFODIO_SERIES,j,hCore);
			discshunt	= BTIDIO_BankGetInfo(INFODIO_SHUNT,j,hCore);

			stroff = 0;

			sprintf(buf + stroff,"\nBank %2d is a Discrete bank. (%2d ",j,BTIDIO_DiscreteGetCount(j,hCore));
			stroff += 32;
			if (discin)
			{
				sprintf(buf + stroff,"I");
				stroff += 1;
			}
			if (discout)
			{
				sprintf(buf + stroff,"O");
				stroff += 1;
			}
			sprintf(buf + stroff,", ");
			stroff += 2;

			if (discseries && discshunt)
			{
				sprintf(buf + stroff,"Series/Shunt");
				stroff += 12;
			}
			else if (discseries)
			{
				sprintf(buf + stroff,"Series");
				stroff += 6;
			}
			else if (discshunt)
			{
				sprintf(buf + stroff,"Shunt");
				stroff += 5;
			}

			sprintf(buf + stroff,")");

			printf(buf);
		}

	}

/**
*
*  Other information
*
**/

	printf("\n");
	printf("\nAdditional information for %s.",name);
	printf("\n-------------------------------------------------------------------------------");
	if (BTICard_IDRegRd(0,hCore)) printf("\nIFGA   ID REG: %04X",BTICard_IDRegRd(0,hCore));
	if (BTICard_IDRegRd(1,hCore)) printf("\nEDGA 1 ID REG: %04X",BTICard_IDRegRd(1,hCore));
	if (BTICard_IDRegRd(2,hCore)) printf("\nEDGA 2 ID REG: %04X",BTICard_IDRegRd(2,hCore));

/**
*
*  Get FW version and date from core directly (for minor minor number)
*
**/

	BTICard_CardGetInfoEx(bufmodel,sizeof(bufmodel)/sizeof(bufmodel[0]),NULL,0,hCore);

	printf("\nFirmware Version: %1lu.%-1lu.%-1lu",
					  bufmodel[11] & 0xFF,
					  bufmodel[12] & 0xFF,
					  bufmodel[13] & 0xFF);

	printf("\nFirmware Date: %02lu/%02lu/%04lu",
					  bufmodel[15] & 0x00FF,
					  bufmodel[16] & 0x00FF,
					  bufmodel[14] & 0xFFFF);

/**
*
*  Run core tests
*
**/

	printf("\n");
	printf("\nRunning tests for %s.",name);
	printf("\n-------------------------------------------------------------------------------");

	if (!errval)
	{
		printf("\nRunning I/O tests: ");
		if (skipio) printf("SKIPPED");
		else
		{
			errval = BTICard_CardTest0(hCore);
			printf("%s",(errval) ? "FAILED" : "PASSED");
		}
	}

	if (!errval)
	{
		printf("\nRunning memory tests: ");
		if (skipmem) printf("SKIPPED");
		else
		{
			errval = BTICard_CardTest1(hCore);
			printf("%s",(errval) ? "FAILED" : "PASSED");
		}
	}

	if (!errval)
	{
		printf("\nRunning commproc tests: ");
		if (skipcomm) printf("SKIPPED");
		else
		{
			errval = BTICard_CardTest2(hCore);
			printf("%s",(errval) ? "FAILED" : "PASSED");
		}
	}

	if (!errval)
	{
		printf("\nRunning databus tests: ");
		if (skipbus) printf("SKIPPED");
		else if (!module_match)
		{
			printf("SKIPPED");
			printf("\n");
			printf("\nWarning:  I/O Module CIS does not match Firmware model!");
			printf("\nAs a result, the core databus tests are being skipped.");
		}
		else
		{
			errval = BTICard_CardTest3(hCore);

			if (errval == ERR_NOTRCV)
			{
				printf("SKIPPED");
				printf("\n");
				printf("\nWarning:  There are no receivers to perform a bus test.");
				printf("\nAs a result, the core databus tests are being skipped.");
				errval = ERR_NONE;
			}
			else if (errval == ERR_NOTXMT)
			{
				printf("SKIPPED");
				printf("\n");
				printf("\nWarning:  There are no transmitters to perform a bus test.");
				printf("\nAs a result, the core databus tests are being skipped.");
				errval = ERR_NONE;
			}
			else if (errval == ERR_SELFXMTFAIL)
			{
				printf("FAILED");
				printf("\n");
				printf("\nError:  The databus self-test failed.  Please verify that");
				printf("\nall channels are properly terminated and that no external.");
				printf("\ndevices are transmitting to them.");
			}
			else
			{
				printf("%s",(errval) ? "FAILED" : "PASSED");
			}
		}
	}

	return(errval);
}
