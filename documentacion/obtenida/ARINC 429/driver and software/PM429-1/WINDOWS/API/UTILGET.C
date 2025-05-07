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

#include "pm41.h"
#include "429util.h"

UINT PM41_FldGetData(UINT msgval)	
{
	return(PM41_FldGetValue(msgval,8,31));
}

USHORT PM41_FldGetLabel(UINT msgval)	
{
	return((USHORT)PM41_FldGetValue(msgval,0,7));
}

USHORT PM41_FldGetParBit(UINT msgval)
{
	INT j;
	INT total;

	for (total=0,j=0;j<=30;++j)
	{
		total += (INT)(PM41_Mask(PM41_Shr(msgval,j),1));
	}

	return((total & 1) ? FALSE:TRUE);
}

UINT PM41_FldPutParBit(UINT msgval)
{
	msgval = PM41_Mask(msgval,31);

	msgval |= PM41_Shl(PM41_FldGetParBit(msgval) ? 1L:0L,31);

	return(msgval);
}

USHORT PM41_FldGetParity(UINT msgval)	
{
	return((USHORT)PM41_FldGetValue(msgval,31,31));
}

USHORT PM41_FldGetSDI(UINT msgval)	
{
	return((USHORT)PM41_FldGetValue(msgval,8,9));
}

UINT PM41_FldGetValue(UINT msgval,USHORT startbit,USHORT endbit)	
{
	INT temp;
	INT fldlen;
	UINT maskvalue;

	if (startbit > endbit)
	{
		temp     = endbit;
		endbit   = startbit;
		startbit = temp;
	}

	fldlen = endbit - startbit + 1;

	maskvalue = PM41_Mask(0xFFFFFFFFL,fldlen);
	msgval    = PM41_Shr(msgval,startbit);

	return(msgval & maskvalue);
}
