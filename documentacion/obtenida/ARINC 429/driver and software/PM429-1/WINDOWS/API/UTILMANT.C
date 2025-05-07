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
*  Reads the specified string and passes back a mantissa and
*  exponent value representing the string.
*
**/

ERRVAL PM41_AsciiToMant(LPCSTR str,LPUINT mant,LPUINT exp)
{
	USHORT j;
	LPCSTR ptr;

	char intstrbuf[10];
	char decstrbuf[10];
	char expstrbuf[10];
	char bufbuf[30];

	LPSTR intstr;
	LPSTR decstr;
	LPSTR expstr;
	LPSTR buf;

	USHORT intsign=0;
	USHORT expsign=0;

	USHORT strlen=0;
	USHORT buflen=0;
	USHORT intlen=0;
	USHORT declen=0;
	USHORT explen=0;

	long mantval=0L;
	int expval=0;

	intstr = intstrbuf;
	decstr = decstrbuf;
	expstr = expstrbuf;
	buf = bufbuf;

	if (mant) *mant = 0L;
	if (exp)  *exp  = 0;

	buf[buflen]='\0';
	intstr[intlen]='\0';
	decstr[declen]='\0';
	expstr[explen]='\0';

	if (!str)
	{
		return(ERR_UNKNOWN);
	}

	for (ptr=str,strlen=0;ptr && *ptr;++ptr,++strlen);

	if (!strlen)
	{
		return(ERR_UNKNOWN);
	}

	for (j=0;j<strlen;++j)
	{
		if (str[j]!=' ')
		{
			break;
		}
	}

	for (;j<=strlen;++j,++buflen)
	{
		buf[buflen]=str[j];
	}

	--buflen;

	while(buflen && buf[buflen-1]==' ')
	{
		buf[buflen-1]='\0';
		--buflen;
	}

	if (!buflen)
	{
		return(ERR_UNKNOWN);
	}

	j=0;

	if (buf[j]=='+' || buf[j]=='-')
	{
		intsign = (buf[j]=='-');
		++j;
	}

	if (buf[j]>='0' && buf[j]<='9')
	{
		while(buf[j]>='0' && buf[j]<='9')
		{
			intstr[intlen+0]=buf[j];
			intstr[intlen+1]='\0';
			++intlen;
			++j;
		}
	}

	if (buf[j]=='.')
	{
		++j;
		while(buf[j]>='0' && buf[j]<='9')
		{
			decstr[declen+0]=buf[j];
			decstr[declen+1]='\0';
			++declen;
			++j;
		}
	}

	if (buf[j]=='e' || buf[j]=='E')
	{
		++j;
		if (buf[j]=='+' || buf[j]=='-')
		{
			expsign = (buf[j]=='-');
			++j;
		}
		if (!(buf[j]>='0' && buf[j]<='9'))
		{
			return(ERR_UNKNOWN);
		}
		while(buf[j]>='0' && buf[j]<='9')
		{
			expstr[explen+0]=buf[j];
			expstr[explen+1]='\0';
			++explen;
			++j;
		}
	}

	if (!intlen && !declen && !explen)
	{
		return(ERR_UNKNOWN);
	}

	if (j!=buflen)
	{
		return(ERR_UNKNOWN);
	}

	if (declen)
	{
		while(declen>1 && decstr[declen-1]=='0')
		{
			decstr[declen-1]='\0';
			--declen;
		}
		for (j=0;j<declen;++j)
		{
			intstr[j+intlen+0]=decstr[j];
			intstr[j+intlen+1]='\0';
		}
		intlen += declen;
	}

	if (explen)
	{
		expval = (int)PM41_ValFromAscii(expstr,10);
	}
	else
	{
		expval = 0;
	}

	if (expsign)
	{
		expval = -expval;
	}

	expval -= declen;

	if (intlen)
	{
		while(intlen && intstr[intlen-1]=='0')
		{
			intstr[intlen-1]='\0';
			++expval;
			--intlen;
		}
		mantval = PM41_ValFromAscii(intstr,10);
	}
	else
	{
		return(ERR_UNKNOWN);
	}

	if (intsign)
	{
		mantval = -mantval;
	}

	if (!mantval)
	{
		expval=0;
	}

	if (mant) *mant = mantval;
	if (exp)  *exp  = expval;

	return(ERR_NONE);
}

/**
*
*  Takes the specified mantissa and exponent and creates a
*  string representing the value.
*
**/

LPSTR PM41_MantToAscii(LPSTR buf,long mant,int exp)
{
	int j,jj,jjj;
	USHORT sign=FALSE;
	USHORT buflen;
	
	if (!buf) return(NULL);

	if (mant < 0L)
	{
		sign = TRUE;
		mant = -mant;
	}

	PM41_ValToAscii(mant,buf,0,10);

	for (buflen=0;buf[buflen];++buflen);

	if (mant && exp<0)
	{
		exp = -exp;
		if (exp>buflen)
		{
			jjj = exp-buflen+1;
			for (j=exp+1;j>=jjj;--j)
			{
				buf[j]=buf[j-jjj];
			}
			for (j=jjj-1;j>0;--j)
			{
				buf[j]='0';
			}
			buf[0] = '.';
			buflen = exp+1;
		}
		else
		{
			for (j=buflen+1;j>buflen-exp;--j)
			{
				buf[j]=buf[j-1];
			}
			buf[buflen-exp]='.';
			++buflen;
		}
	}
	else if (mant && exp>0)
	{
		for (j=0;j<exp;++j)
		{
			buf[buflen+0] = '0';
			buf[buflen+1] = '\0';
			++buflen;
		}
	}

	if (sign && buf[0]!='0')
	{
		jj = buflen+1;
		for (j=jj;j>0;--j)
		{
			buf[j]=buf[j-1];
		}
		buf[0] = '-';
	}
	return(buf);
}

/**
*
*  Takes the specified mantissa, removes any trailing zeros,
*  and adjusts the exponent accordingly.
*
**/
VOID PM41_NormalMant(LPUINT mant,LPUINT exp)
{
	if (!mant || !exp) return;

	while(*mant && !PM41_Mod(*mant,10L))
	{
		*mant = PM41_Div(*mant,10L);
		++(*exp);
	}
}

/**
*
*  Takes the specified exponent and brings it to zero while
*  adjusting the mantissa accordingly.
*
**/

VOID PM41_ExpandMant(LPUINT mant,LPUINT exp)
{
	if (!mant || !exp) return;

	if ((*exp)>0)
	{
		for (;(*exp)!=0;--(*exp))
		{
			*mant = PM41_Mul(*mant,10L);
		}
	}
	else if ((*exp)<0)
	{
		for (;(*exp)!=0;++(*exp))
		{
			*mant = PM41_Div(*mant,10L);
		}
	}
}

/**
*
*  Adjusts the mantissa and exponent such that all non-zero
*  digits in the mantissa are to the left of the decimal
*  place.
*
**/

VOID PM41_MaxMant(LPUINT mant,LPUINT exp)
{
	USHORT done=FALSE;
	long newmant;
	long keymant;
	long tempmant;
	int tempexp;

	if (!mant || !exp) return;

	PM41_NormalMant(mant,exp);

	keymant = *mant;
	newmant = *mant;

	while(!done)
	{
		tempmant = newmant;
		tempexp  = *exp;

		PM41_NormalMant(&tempmant,&tempexp);

		if (tempmant != keymant)
		{
			++(*exp);
			return;
		}

		*mant   = newmant;
		newmant = PM41_Mul(*mant,10L);
		--(*exp);
	}
}

/**
*
*  Returns the sign of the specified string.
*
**/

USHORT PM41_SignMant(LPCSTR str)
{
	USHORT j;
	USHORT strlen;
	LPCSTR ptr;

	if (!str) return(FALSE);

	for (ptr=str,strlen=0;*ptr;++ptr,++strlen);

	if (!strlen)
	{
		return(FALSE);
	}

	for (j=0;j<strlen;++j)
	{
		if (str[j]!=' ')
		{
			break;
		}
	}

	if (str[j] == '-')
	{
		return(TRUE);
	}

	return(FALSE);
}
