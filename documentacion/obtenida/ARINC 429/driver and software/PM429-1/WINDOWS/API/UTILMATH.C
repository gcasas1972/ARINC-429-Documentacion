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

UINT PM41_Mul(UINT mula,UINT mulb)
{
	return(mula*mulb);
}

UINT PM41_Div(UINT diva,UINT divb)
{
	return(diva/divb);
}

UINT PM41_Mod(UINT moda,UINT modb)
{
	return(moda%modb);
}

UINT PM41_Mask(UINT dataval,USHORT cntval)
{
	return(dataval & (PM41_Shl(1L,cntval) - 1L));
}

UINT PM41_Shl(UINT dataval,USHORT cntval)
{
	return((cntval>31) ? 0L:dataval<<cntval);
}

UINT PM41_Shr(UINT dataval,USHORT cntval)
{
	return((cntval>31) ? 0L:dataval>>cntval);
}

USHORT PM41_GetLow(UINT val)
{
	return((USHORT)PM41_Mask(PM41_Shr(val,0),16));
}

USHORT PM41_GetHigh(UINT val)
{
	return((USHORT)PM41_Mask(PM41_Shr(val,16),16));
}

UINT PM41_MakeLong(USHORT valh,USHORT vall)
{
	return(PM41_Shl((UINT)valh,16) | PM41_Shl((UINT)vall,0));
}

USHORT PM41_Transpose12(USHORT val)
{
	USHORT temp;

	temp = val & 0x0FFF;
	val = 0;

	if (temp & 0x0800) val |= 0x0001;
	if (temp & 0x0400) val |= 0x0002;
	if (temp & 0x0200) val |= 0x0004;
	if (temp & 0x0100) val |= 0x0008;
	if (temp & 0x0080) val |= 0x0010;
	if (temp & 0x0040) val |= 0x0020;
	if (temp & 0x0020) val |= 0x0040;
	if (temp & 0x0010) val |= 0x0080;
	if (temp & 0x0008) val |= 0x0100;
	if (temp & 0x0004) val |= 0x0200;
	if (temp & 0x0002) val |= 0x0400;
	if (temp & 0x0001) val |= 0x0800;

	return(val);
}
