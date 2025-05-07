/**
*
*  PM429-1 Example Utilities Version 1.0  (07/01/2002)
*  Copyright (c) 20002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
**/


#include "PM41.h"
#include "429util.h"

USHORT PM41_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit)
{
	INT temp;
	INT fldlen;
	USHORT maskvalue;

	if (startbit > endbit)
	{
		temp     = endbit;
		endbit   = startbit;
		startbit = temp;
	}

	fldlen = endbit - startbit + 1;
	maskvalue = (((1 << fldlen) - 1) << startbit);
	return((oldvalue & (~maskvalue)) | ((newfld << startbit) & maskvalue));
}

USHORT PM41_ValGetBits(USHORT oldvalue,INT startbit,INT endbit)
{
	INT temp;
	INT fldlen;
	USHORT maskvalue;

	if (startbit > endbit)
	{
		temp     = endbit;
		endbit   = startbit;
		startbit = temp;
	}

	fldlen = endbit - startbit + 1;
	maskvalue = ((1 << fldlen) - 1);
	return((oldvalue >> startbit) & maskvalue);
}
