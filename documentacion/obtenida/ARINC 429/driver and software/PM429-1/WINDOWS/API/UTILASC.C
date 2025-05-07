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

UINT PM41_ValAsciiPowers[32];

INT PM41_ValLenAscii(INT numbits,INT radixval)
{
	UINT j;
	INT digits;

	if (numbits ==0) return(0);
	if (radixval==0) return(0);
	if (radixval==1) return(0);

	j = (numbits>31) ? 0xFFFFFFFFL : (PM41_Shl(1L,numbits)-1L);
	for (digits=0;j;j=PM41_Div(j,radixval),++digits);
	return(digits);
}

UINT PM41_ValFromAscii(LPCSTR asciistr,INT radixval)
{
	INT	j;
	INT length;
	CHAR ch;
	UINT result;
	UINT power;
	UINT temp;
	USHORT value;

	if (asciistr==NULL) return(0L);
	if (radixval==0)    return(0L);
	if (radixval==1)    return(0L);

	for (length=0;length<256 && (asciistr[length]!='\0');++length);

	for (power=1L,result=0L,j=length-1;j>=0;--j)
	{
		ch = asciistr[j];

		if (ch >= '0' && ch <= '9')			//A numeric digit
			value = ch-'0';
		else if (ch >= 'A' && ch <= 'Z')	//An uppercase alphabetic digit
			value = ch-'A'+10;
		else if (ch >= 'a' && ch <= 'z') 	//A lowercase alphabetic digit
			value = ch-'a'+10;
		else
			value = 0;

		result = result + PM41_Mul(power,value);
		temp   = power;
		power  = PM41_Mul(power,radixval);
		if (power < temp) break;		//If we've exceeded the 2^32
	};

	return(result);
}

LPSTR PM41_ValToAscii(UINT value,LPSTR asciistr,INT numbits,INT radixval)
{
	INT j;
	INT digits;
	UINT coeff;

	if (0==numbits)
	{
		for (j=0;j<32;++j)
		{
			if (value & PM41_Shl(1,31-j))
			{
				numbits=32-j;
				break;
			}
		}
	}

	digits = PM41_ValLenAscii(numbits,radixval);

	for (j=0;j<=digits;++j)						//Zero-fill the output string
	{
		asciistr[j]='0';
	}

	for (PM41_ValAsciiPowers[0]=1,j=1;j<digits;++j)			//Calculate all relevant powers of radix
	{
		PM41_ValAsciiPowers[j-0] = PM41_Mul(radixval,PM41_ValAsciiPowers[j-1]);
	}

	for (j=digits-1;j>=0;--j)
	{
		coeff = PM41_Div(value,PM41_ValAsciiPowers[j]);

		if (coeff < 10)							//A numeric digit
			coeff += '0';
		else
			coeff += 'A'-10;					//An (uppercase) alphabetic digit

		asciistr[digits - (j+1)] = (CHAR)coeff;
		value = PM41_Mod(value,PM41_ValAsciiPowers[j]);
	}

	asciistr[digits] = '\0';

	return(asciistr);
}

LPSTR PM41_ValInccAscii(LPSTR asciistr)
{
	INT length;

	if (!asciistr) return(NULL);

	for (length=0;length<256 && (asciistr[length]!='\0');++length);

	if (asciistr[length]) return(NULL);

	++asciistr[length-1];

	return(asciistr);
}

LPSTR PM41_ValIncAscii(LPSTR asciistr)
{
	CHAR ch;
	INT j;
	INT length;

	if (!asciistr) return(NULL);

	for (length=0;length<256 && (asciistr[length]!='\0');++length);

	if (asciistr[length]) return(NULL);

	for (j=0;j<=length;++j)
	{
		ch = asciistr[length-1-j];

		if (ch>='0' && ch<='9')
		{
			if (ch=='9')
			{
				asciistr[length-1-j] = '0';
			}
			else
			{
				asciistr[length-1-j] = ch+1;
				break;
			}
		}
		else if (ch>='A' && ch<='Z')
		{
			if (ch=='Z')
			{
				asciistr[length-1-j] = 'A';
			}
			else
			{
				asciistr[length-1-j] = ch+1;
				break;
			}
		}
		else if (ch>='a' && ch<='z')
		{
			if (ch=='z')
			{
				asciistr[length-1-j] = 'a';
			}
			else
			{
				asciistr[length-1-j] = ch+1;
				break;
			}
		}
	}

	return(asciistr);
}

BOOL PM41_ValIsLower(INT value)
{
	return(value>=(INT)('a') && value<=(INT)('z'));
}

INT PM41_ValToUpper(INT value)
{
	return((PM41_ValIsLower(value)) ? value+(INT)('A')-(INT)('a') : value);
}

INT PM41_ValAsciiCmpi(LPSTR str1,LPSTR str2)
{
	INT value1;
	INT value2;

	if (str1 && str2)
	{
		while(*str1 && *str2)
		{
			value1 = PM41_ValToUpper(*str1);
			value2 = PM41_ValToUpper(*str2);
			if (value1 != value2)
			{
				break;
			}
			++str1;
			++str2;
		}

		value1 = PM41_ValToUpper(*str1);
		value2 = PM41_ValToUpper(*str2);

		if (!value1 && !value2)
		{
			return(0);
		}
		if (!value1)
		{
			return(-1);
		}
		if (!value2)
		{
			return(1);
		}
		if (value1 < value2)
		{
			return(-1);
		}
		if (value1 > value2)
		{
			return(1);
		}
	}
	return(0);
}

VOID PM41_ValAsciiTrimLead(LPSTR buf)
{
	INT j;
	LPSTR ptr;

	if (*buf==' ')
	{
		for (ptr=buf,j=512;*ptr==' ' && j;--j,++ptr);

		for (j=512;*ptr && j;--j,++buf,++ptr)
		{
			*buf=*ptr;
		}

		*buf='\0';
	}
}

VOID PM41_ValAsciiTrimTrail(LPSTR buf)
{
	LPSTR ptr;

	for (ptr=buf;*buf;++buf)
	{
		if (*buf!=' ')
		{
			ptr=buf;
		}
	}

	if (*ptr==' ')
	{
		*(ptr+0) = '\0';
	}
	else if (*ptr)
	{
		*(ptr+1) = '\0';
	}
}

LPSTR PM41_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count)
{
	INT j;

	for (j=0;j<count;++j)
	{
		strdest[j] = strsrc[j];
		if (!strsrc[j]) return(strdest);
	}

	return(strdest);
}
