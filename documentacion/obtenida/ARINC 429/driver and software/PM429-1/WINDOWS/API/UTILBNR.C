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

/**
*
*  Extracts the data field for the specified BNR message.  No
*  other conversions are made.  The bits to extract are
*  delimited by the specified bit positions.  The result is
*  right justified.
*
**/

UINT PM41_BNRGetData(UINT msg,USHORT msb,USHORT lsb)	
{
	USHORT j;

	msb = (msb > 28) ? 28 : (msb < 9) ? 9 : msb;
	lsb = (lsb > 28) ? 28 : (lsb < 9) ? 9 : lsb;

	if (msb<lsb)
	{
		j=lsb;
		lsb=msb;
		msb=j;
	}

	msg = PM41_Shr(msg,lsb-1);
	msg = PM41_Mask(msg,msb+1-lsb);

	return(msg);
}

/**
*
*  Extracts the 3 bit SSM field from the specified BNR message.  No
*  other conversions are made.  The bits to extract are
*  specified in the ARINC 429 standard.
*
**/

USHORT PM41_BNRGetSSM(UINT msg)	
{
	msg = PM41_FldGetData(msg);
	msg = PM41_Shr(msg,20);
	msg = PM41_Mask(msg,3);
	return((USHORT)msg);
}

/**
*
*  Tests the 3 bit SSM field of the specified BNR message and
*  returns a non-zero value if the sign is negative.  The
*  criteria is specified in the ARINC 429 standard.
*
**/

USHORT PM41_BNRGetSign(UINT msg)	
{
	msg = (UINT)PM41_BNRGetSSM(msg);
	msg = PM41_Mask(msg,1);
	return((USHORT)msg);
}

/**
*
*  Retrieves the data field of the specified BNR message and
*  performs 2s complement conversion if needed.
*
**/

UINT PM41_BNRGetMant(UINT msg,USHORT sigbit)	
{
	USHORT twos;

	twos = PM41_BNRGetSign(msg);
	msg  = PM41_BNRGetData(msg,28,28+1-sigbit);

	if (twos)
	{
		msg=~msg;
		++msg;
		msg = PM41_Mask(msg,sigbit);
	}

	return(msg);
}

/**
*
*  Creates a decimal string representing the data field of
*  the specified BNR message.
*
**/

VOID PM41_BNRGetVal(LPSTR buf,UINT msg,USHORT sigbit,LPCSTR resolstr)	
{
	long mant=0L;
	int exp=0;
	int resolexp=0;
	long resolmant=0L;

	*buf = '\0';

	mant = PM41_BNRGetMant(msg,sigbit);

	if (PM41_AsciiToMant(resolstr,&resolmant,&resolexp))
	{
		return;
	}

	if (resolmant<0)
	{
		return;
	}

	PM41_NormalMant(&resolmant,&resolexp);
	PM41_NormalMant(&mant,&exp);
	mant = PM41_Mul(mant,resolmant);
	exp  = exp + resolexp;
	PM41_NormalMant(&mant,&exp);

	if (PM41_BNRGetSign(msg))
	{
		mant = -mant;
	}

	PM41_MantToAscii(buf,mant,exp);
}

/**
*
*  Inserts the data field for the specified BNR message.  No
*  other conversions are made.  The bits to insert are
*  delimited by the specified bit positions.
*
**/

UINT PM41_BNRPutData(UINT msg,UINT value,USHORT msb,USHORT lsb)	
{
	USHORT len;
	UINT pssm;
	UINT label;

	msb = (msb > 28) ? 28 : (msb < 9) ? 9 : msb;
	lsb = (lsb > 28) ? 28 : (lsb < 9) ? 9 : lsb;

	if (msb<lsb)
	{
		len=lsb;
		lsb=msb;
		msb=len;
	}

	len = msb - lsb + 1;

	label = PM41_Mask(msg,lsb-1);
	pssm  = PM41_Shl(PM41_Shr(msg,msb),msb);

	value  = PM41_Mask(value,len);
	value  = PM41_Shl(value,lsb-1);
	value |= pssm;
	value |= label;

	return(value);
}

/**
*
*  Inserts the 3 bit SSM field into the specified BNR message.  No
*  other conversions are made.  The bits to insert are
*  specified in the ARINC 429 standard.
*
**/

UINT PM41_BNRPutSSM(UINT msg,USHORT value)	
{
	UINT data;
	data  = PM41_FldGetData(msg);
	data  = PM41_Mask(data,20);
	data |= PM41_Shl(PM41_Mask((UINT)value,3),20);
	msg   = PM41_FldPutData(msg,data);
	return(msg);
}

/**
*
*  Inserts the 3 bit SSM field into the specified BNR message
*  and returns the value of the message.  The SSM is negative
*  depending upon the 2s complement parameter specified.
*
**/

UINT PM41_BNRPutSign(UINT msg,USHORT twos)	
{
	USHORT ssm;	
	ssm  = PM41_BNRGetSSM(msg);
	ssm &= 0x06;
	ssm |= (twos) ? 1 : 0;
	msg  = PM41_BNRPutSSM(msg,ssm);
	return(msg);
}

/**
*
*  Puts the data field into the specified BNR message and
*  performs 2s complement conversion if needed.
*
**/

UINT PM41_BNRPutMant(UINT msg,UINT value,USHORT sigbit,USHORT twos)	
{
	msg = PM41_BNRPutSign(msg,twos);

	if (twos)
	{
		value=~value;
		++value;
	}

	msg = PM41_BNRPutData(msg,value,28,28+1-sigbit);

	return(msg);
}

/**
*
*  Takes the specified decimal string and writes the value to
*  the data field of the specified BNR message.
*
**/

UINT PM41_BNRPutVal(LPCSTR buf,UINT msg,USHORT sigbit,LPCSTR resolstr)	
{
	long mant=0L;
	int exp=0;
	int resolexp=0;
	long resolmant=0L;
	USHORT twos;

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

	twos = PM41_SignMant(buf);

	if (twos)
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

	return(PM41_BNRPutMant(msg,mant,sigbit,twos));
}
