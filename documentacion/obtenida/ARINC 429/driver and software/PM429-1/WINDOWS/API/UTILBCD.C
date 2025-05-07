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

UINT PM41_BCDGetData(UINT msg,USHORT msb,USHORT lsb)	
{
	USHORT j;
	UINT result=0L;
	UINT temp=0L;

	msb = (msb > 29) ? 29 : (msb < 9) ? 9 : msb;
	lsb = (lsb > 29) ? 29 : (lsb < 9) ? 9 : lsb;

	if (msb<lsb)
	{
		j=lsb;
		lsb=msb;
		msb=j;
	}

	msg = PM41_Shr(msg,lsb-1);
	msg = PM41_Mask(msg,msb+1-lsb);

	for (j=0;j<8;++j)
	{
		temp   = PM41_Shr(msg,4*(7-j));
		temp   = PM41_Mask(temp,4);
		result = PM41_Shl(result,3) + PM41_Shl(result,1) + temp;
	}

	return(result);
}

UINT PM41_BCDGetMant(UINT msg,USHORT sigdig)	
{
	USHORT numbits;
	USHORT startbit;
	USHORT endbit;

	numbits  = (sigdig==6) ? 21 : (sigdig==5) ? 19 : (sigdig==4) ? 15 : (sigdig==3) ? 11 : 21;
	startbit = (sigdig==6) ?  9 : (sigdig==5) ? 11 : (sigdig==4) ? 15 : (sigdig==3) ? 19 :  9;
	endbit   = 29;

	if (endbit-startbit+1 != numbits)
	{
		return(0L);
	}

	msg = PM41_BCDGetData(msg,endbit,startbit);

	return(msg);
}

USHORT PM41_BCDGetSSM(UINT msg)	
{
	msg = PM41_FldGetData(msg);
	msg = PM41_Shr(msg,21);
	msg = PM41_Mask(msg,2);
	return((USHORT)msg);
}

USHORT PM41_BCDGetSign(UINT msg)	
{
	msg = (UINT)PM41_BCDGetSSM(msg);
	return(msg == 3L);
}



VOID PM41_BCDGetVal(LPSTR buf,UINT msg,USHORT sigdig,LPCSTR resolstr)	
{
	long mant;
	int resolexp;
	long resolmant;

	*buf = '\0';

	mant = PM41_BCDGetMant(msg,sigdig);

	if (PM41_AsciiToMant(resolstr,&resolmant,&resolexp))
	{
		return;
	}

	PM41_NormalMant(&resolmant,&resolexp);
	PM41_NormalMant(&mant,&resolexp);
	resolmant = PM41_Mul(resolmant,mant);
	PM41_NormalMant(&resolmant,&resolexp);

	if (PM41_BCDGetSign(msg))
	{
		resolmant = -resolmant;
	}

	PM41_MantToAscii(buf,resolmant,resolexp);
}

UINT PM41_BCDPutData(UINT msg,UINT value,USHORT msb,USHORT lsb)	
{
	USHORT len;
	USHORT j;
	UINT pssm;
	UINT label;
	UINT temp;
	UINT result=0L;

	msb = (msb > 29) ? 29 : (msb < 9) ? 9 : msb;
	lsb = (lsb > 29) ? 29 : (lsb < 9) ? 9 : lsb;

	if (msb<lsb)
	{
		j=lsb;
		lsb=msb;
		msb=j;
	}

	len = msb - lsb + 1;

	for (j=0;j<8;++j)
	{
		temp    = PM41_Mod(value,10L);
		value   = PM41_Div(value,10L);
		temp    = PM41_Shl(temp,4*j);
		result |= temp;
	}

	label  = PM41_Mask(msg,lsb-1);
	pssm   = PM41_Shl(PM41_Shr(msg,msb),msb);

	result  = PM41_Mask(result,len);
	result  = PM41_Shl(result,lsb-1);
	result |= pssm;
	result |= label;

	return(result);
}

UINT PM41_BCDPutSSM(UINT msg,USHORT value)	
{
	UINT data;
	data  = PM41_FldGetData(msg);
	data  = PM41_Mask(data,21);
	data |= PM41_Shl(PM41_Mask((UINT)value,2),21);
	msg   = PM41_FldPutData(msg,data);
	return(msg);
}

UINT PM41_BCDPutSign(UINT msg,USHORT sign)	
{
	USHORT ssm;	
	ssm  = PM41_BCDGetSSM(msg);
	ssm &= 0x00;
	ssm |= (sign) ? 0x03 : 0x00;
	msg  = PM41_BCDPutSSM(msg,ssm);
	return(msg);
}

UINT PM41_BCDPutMant(UINT msg,UINT value,USHORT sigdig,USHORT sign)	
{
	USHORT numbits;
	USHORT startbit;
	USHORT endbit;

	numbits  = (sigdig==6) ? 21 : (sigdig==5) ? 19 : (sigdig==4) ? 15 : (sigdig==3) ? 11 : 21;
	startbit = (sigdig==6) ?  9 : (sigdig==5) ? 11 : (sigdig==4) ? 15 : (sigdig==3) ? 19 :  9;
	endbit   = 29;

	msg = PM41_BCDPutSign(msg,sign);
	return(PM41_BCDPutData(msg,value,endbit,startbit));
}

UINT PM41_BCDPutVal(LPCSTR buf,UINT msg,USHORT sigdig,LPCSTR resolstr)	
{
	long mant=0L;
	int exp=0;
	int resolexp=0;
	long resolmant=0L;
	USHORT issign;

	if (PM41_AsciiToMant(buf,&mant,&exp))
	{
		return(msg);
	}

	if (PM41_AsciiToMant(resolstr,&resolmant,&resolexp))
	{
		return(msg);
	}

	if (resolmant<0)
	{
		return(msg);
	}

	issign = PM41_SignMant(buf);

	if (issign)
	{
		mant = -mant;
	}

	PM41_NormalMant(&mant,&exp);
	PM41_NormalMant(&resolmant,&resolexp);
	PM41_MaxMant(&mant,&exp);

	mant = PM41_Div(mant,resolmant);
	exp  = exp - resolexp;

	PM41_NormalMant(&mant,&exp);
	PM41_ExpandMant(&mant,&exp);

	return(PM41_BCDPutMant(msg,mant,sigdig,issign));
}
