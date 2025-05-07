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


UINT PM41_FldPutData(UINT msgval,UINT data)
{
	return(PM41_FldPutValue(msgval,data,8,31));
}

UINT PM41_FldPutLabel(UINT msgval,USHORT label)
{
	return(PM41_FldPutValue(msgval,label,0,7));
}

UINT PM41_FldPutSDI(UINT msgval,USHORT sdi)
{
	return(PM41_FldPutValue(msgval,sdi,8,9));
}

UINT PM41_FldPutValue(UINT msgval,UINT dataval,USHORT startbit,USHORT endbit)
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

	maskvalue = PM41_Mask(0xFFFFFFFF,fldlen);
	maskvalue = PM41_Shl(maskvalue,startbit);

	dataval = PM41_Shl(dataval,startbit);

	msgval  = msgval  & (~maskvalue);
	dataval = dataval &   maskvalue;

	return(msgval | dataval);
}
