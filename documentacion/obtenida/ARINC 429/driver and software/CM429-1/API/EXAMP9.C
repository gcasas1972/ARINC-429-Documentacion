
/**
*
*  CM429-1 DRIVER EXAMPLE 9  Version 1.0  (08/04/2004)
*  Copyright (c) 2004
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP14.C -- Example 9.
*                      "Program to get BNR from ARINC words"
*
**/

/**
*
*  This is a utility funcition example program and does not access
*  any Device hardware. This program will recreate Table 6-2 "BNR
*  DATA ENCODING EXAMPLES" from the ARINC SPECIFICATION 429, PART 1.
*  
**/

#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/********************************
*
*	BNR 
*
*********************************/

double C41_BNRGetValDbl(ULONG msg,USHORT sigbit,double dblResolution)
{
	double dblResult;

	dblResult = C41_BNRGetMant(msg, sigbit) * dblResolution;

	if (C41_BNRGetSign(msg))	dblResult = -dblResult;

	return(dblResult);
}

ULONG C41_BNRPutValDbl(double dblVal, ULONG msg,USHORT sigbit,double dblResolution)
{
	ULONG ulResult;
	ULONG mantissa;
	BOOL bNegative;

	bNegative = (0>dblVal) ? 1:0;									//Record if value is negative

	if (bNegative)	dblVal = -dblVal;								//If negative, make positive

	mantissa = (ULONG)(dblVal / dblResolution);						//Scale to remove decimal

	ulResult = C41_BNRPutMant(msg, mantissa, sigbit, bNegative);	//Fold in original message

	return(ulResult);
}

/********************************
*
*	BNR Angular
*
*********************************/

double C41_BNRAngularGetValDbl(ULONG msg, USHORT sigbit, BOOL bPlusMinus180)
{
	double dblResult;
	double dblResolution;

	dblResolution = 180.0;
	dblResolution /= (1<<sigbit);

	dblResult = C41_BNRGetValDbl(msg, sigbit, dblResolution);

	if (!bPlusMinus180 && 0>dblResult)	dblResult = dblResult + 360.0;

	return(dblResult);
}

ULONG C41_BNRAngularPutValDbl(double dblVal, ULONG msg, USHORT sigbit)
{
	ULONG ulResult;
	double dblResolution;

	dblResolution = 180.0;
	dblResolution /= (1<<sigbit);

	if (dblVal > 180)	dblVal = dblVal - 360;

	ulResult = C41_BNRPutValDbl(dblVal, msg, sigbit, dblResolution);

	return(ulResult);
}

/********************************
*
*	MAIN
*
*********************************/

void main(void)
{
	ULONG msg;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9    (08/04/2004)                                            *");
	printf("\n    *  Copyright 2004 Ballard Technology, Inc.  Everett, WA, USA.        *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  CM429-1 Example 9                                                 *");
	printf("\n    *  \"Program to get BNR from ARINC words\"                             *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n\n");

	printf("\t\t\t\tTable 6-2\n");
	printf("\t\t\tBNR DATA ENCODING EXAMPLES\n\n");

	printf("\tPARAMETER\t  (Label)\tMSG\t\tRESULT\n");
	printf("    ----------------------------------------------------------------------\n");

	msg = 0x60000002;
	printf(" %30s","Selected Course (100)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRAngularGetValDbl(msg, 12, 1));
	printf(" Deg.\n");

	msg = 0x6D550082;
	printf(" %30s","Selected Heading (101)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRAngularGetValDbl(msg, 12, 1));
	printf(" Deg.\n");

	msg = 0xEA028042;
	printf(" %30s","Selected Altitude (102)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 16, 1.0));
	printf(" Ft.\n");

	msg = 0x6D3800C2;
	printf(" %30s","Selected Airspeed (103)");
	printf("\t\t%08X",msg);
	printf("\t%.1f",C41_BNRGetValDbl(msg, 11, 0.25));
	printf(" Knots\n");
	
	msg = 0xFDD80022;
	printf(" %30s","Selected Vertical Speed (104)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 10, 16.0));
	printf(" Ft/Min\n");

	msg = 0xE3200062;
	printf(" %30s","Selected Mach (106)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 12, 1.0));
	printf(" m Mach.\n");
	
	msg = 0x78720032;
	printf(" %30s","Desired Track (114)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRAngularGetValDbl(msg, 12, 0));
	printf(" Deg.\n");
	
	msg = 0xE6600072;
	printf(" %30s","Cross Track Distance (116)");
	printf("\t\t%08X",msg);
	printf("\t%.1f",C41_BNRGetValDbl(msg, 15, 0.004));
	printf(" NM\n");
	
	msg = 0x64B000F2;
	printf(" %30s","Vertical Deviation (117)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 11, 1.0));
	printf(" Ft.\n");
	
	msg = 0xE2AB0006;
	printf(" %30s","Flight Director Roll (140)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRAngularGetValDbl(msg, 12, 1));
	printf(" Deg.\n");
	
	msg = 0xF0E40086;
	printf(" %30s","Flight Director Pitch (141)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRAngularGetValDbl(msg, 12, 1));
	printf(" Deg.\n");
	
	msg = 0x67800046;
	printf(" %30s","Fast/Slow (142)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 12, 0.008));
	printf(" Knots\n");
	
/*	msg = 0x6972A016;
	printf(" %30s","Greenwich Mean Time (150)");
	printf("\t\t%08X",msg);
	printf("\t(%f)",C41_BNRGetValDbl(msg, 12, 0.0178125));
	printf("\n");
*/
	msg = 0x64C9002E;
	printf(" %30s","Radio Height (164)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 16, 0.125));
	printf(" Ft.\n");
	
	msg = 0xE0D800DE;
	printf(" %30s","Localizer Deviation (173)");
	printf("\t\t%08X",msg);
	printf("\t%1.03f",C41_BNRGetValDbl(msg, 12, 0.0001));
	printf(" DDM\n");
	
	msg = 0xFD80003E;
	printf(" %30s","Glide Slope Deviation (174)");
	printf("\t\t%08X",msg);
	printf("\t%1.03f",C41_BNRGetValDbl(msg, 12, 0.0002));
	printf(" Deg.\n");
	
	msg = 0x680EE041;
	printf(" %30s","DME Distance (202)");
	printf("\t\t%08X",msg);
	printf("\t%1.2f",C41_BNRGetValDbl(msg, 16, 0.008));
	printf(" NM\n");
	
	msg = 0x657E40C1;
	printf(" %30s","Altitude (29.92) (203)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 17, 1.0));
	printf(" Ft.\n");
	
	msg = 0x634080A1;
	printf(" %30s","Mach (205)");
	printf("\t\t%08X",msg);
	printf("\t%1.4f",C41_BNRGetValDbl(msg, 16, 0.0000625));
	printf(" Mach\n");
	
	msg = 0xE6A40061;
	printf(" %30s","Computed Airspeed (206)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 14, 0.0625));
	printf(" Knots\n");
	
	msg = 0x646A0011;
	printf(" %30s","True Airspeed (210)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 15, 0.0625));
	printf(" Knots\n");
	
	msg = 0x606800D1;
	printf(" %30s","Static Air Temp (213)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 11, 0.25));
	printf(" Deg. C\n");
	
	msg = 0x7F320091;
	printf(" %30s","Total Air Temp (211)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 11, 0.25));
	printf(" Deg. C\n");
	
	msg = 0x788E0051;
	printf(" %30s","Altitude Rate (212)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 11, 16.0));
	printf(" Ft/Min\n");
	
	msg = 0xE73EA813;
	printf(" %30s","Present Pos. Lat. (310)");
	printf("\t\t%08X",msg);
	printf("\tN %.1f",C41_BNRGetValDbl(msg, 20, 0.000172));
	printf(" Deg\n");
	
	msg = 0x7716C093;
	printf(" %30s","Present Pos. Long. (311)");
	printf("\t\t%08X",msg);
	printf("\tW %.1f",C41_BNRGetValDbl(msg, 20, 0.000172));
	printf("\n");
	
	msg = 0xE28A0053;
	printf(" %30s","Ground Speed (312)");
	printf("\t\t%08X",msg);
	printf("\t%.0f",C41_BNRGetValDbl(msg, 15, 0.125));
	printf(" Knots\n");

	msg = 0x6A0500CB;
	printf(" %30s","Flight Path Accel (323)");
	printf("\t\t%08X",msg);
	printf("\t%1.2f",C41_BNRGetValDbl(msg, 12, 0.001));
	printf(" g\n");

	printf("\n\n");
}