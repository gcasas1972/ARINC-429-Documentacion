/**
*
*  PM429-1 Example Utility Version 1.0  (07/01/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   429UTIL.H --  PM429-1 Example Utility Include Header File.
*
**/

/**
*
*	Conditional block to prevent multiple #defines	
*
**/

#ifndef _429UTIL_H
#define _429UTIL_H

/**
*
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*	Typedefs of data types.  Note that these may need to be changed depending upon 
*	compiler used.  Any compiler-dependent code will be marked with the comment
*	"// COMPILER_DEP".
*
**/

#ifndef NULL					// Null pointer definition
#ifdef __cplusplus
#define NULL    0
#else
#define NULL    ((void *)0)
#endif
#endif

#ifndef CHAR					// 8 bit signed value
typedef char CHAR;				// COMPILER_DEP
#endif

#ifndef LPUINT					// pointer to 32 bit value
typedef unsigned long * LPUINT;	// COMPILER_DEP
#endif

#ifndef LPCSTR					// pointer to const string
typedef const char * LPCSTR;	// COMPILER_DEP
#endif	

#ifndef LPSTR					// pointer to string
typedef char * LPSTR;			// COMPILER_DEP
#endif

#ifndef ERRVAL					// Error return used for handling
typedef int ERRVAL;				// errors generated in utility functions
#endif
/**
*
*	PM41 Math functions: UTILMATH.C
*
**/
UINT PM41_Mul(UINT mula,UINT mulb);
UINT PM41_Div(UINT diva,UINT divb);
UINT PM41_Mod(UINT moda,UINT modb);
UINT PM41_Mask(UINT dataval,USHORT cntval);
UINT PM41_Shl(UINT dataval,USHORT cntval);
UINT PM41_Shr(UINT dataval,USHORT cntval);
USHORT PM41_GetLow(UINT val);
USHORT PM41_GetHigh(UINT val);
UINT PM41_MakeLong(USHORT valh,USHORT vall);
USHORT PM41_Transpose12(USHORT val);

/**
*
*	PM41 Field Put functions: UTILPUT.C
*
**/
UINT PM41_FldPutData(UINT msgval,UINT data);	
UINT PM41_FldPutLabel(UINT msgval,USHORT label);	
UINT PM41_FldPutSDI(UINT msgval,USHORT sdi);	
UINT PM41_FldPutValue(UINT msgval,UINT dataval,USHORT startbit,USHORT endbit);	

/**
*
* PM41 Field Get Functions: UTILGET.C
*
**/
UINT PM41_FldGetData(UINT msgval);	
USHORT PM41_FldGetLabel(UINT msgval);	
USHORT PM41_FldGetParBit(UINT msgval);
UINT PM41_FldPutParBit(UINT msgval);
USHORT PM41_FldGetParity(UINT msgval);	
USHORT PM41_FldGetSDI(UINT msgval);	
UINT PM41_FldGetValue(UINT msgval,USHORT startbit,USHORT endbit);	

/**
*
*	PM41 BNR Utility functions: UTILBNR.C
*
**/
UINT PM41_BNRGetData(UINT msg,USHORT msb,USHORT lsb);	
USHORT PM41_BNRGetSSM(UINT msg);	
USHORT PM41_BNRGetSign(UINT msg);	
UINT PM41_BNRGetMant(UINT msg,USHORT sigbit);	
VOID PM41_BNRGetVal(LPSTR buf,UINT msg,USHORT sigbit,LPCSTR resolstr);	
UINT PM41_BNRPutData(UINT msg,UINT value,USHORT msb,USHORT lsb);	
UINT PM41_BNRPutSSM(UINT msg,USHORT value);	
UINT PM41_BNRPutSign(UINT msg,USHORT twos);	
UINT PM41_BNRPutMant(UINT msg,UINT value,USHORT sigbit,USHORT twos);	
UINT PM41_BNRPutVal(LPCSTR buf,UINT msg,USHORT sigbit,LPCSTR resolstr);	

/**
*
*	PM41 BCD Functions: UTILBCD.C
*
**/
UINT PM41_BCDGetData(UINT msg,USHORT msb,USHORT lsb);	
USHORT PM41_BCDGetSSM(UINT msg);	
USHORT PM41_BCDGetSign(UINT msg);	
UINT PM41_BCDGetMant(UINT msg,USHORT sigdig);	
VOID PM41_BCDGetVal(LPSTR buf,UINT msg,USHORT sigdig,LPCSTR resolstr);	
UINT PM41_BCDPutData(UINT msg,UINT value,USHORT msb,USHORT lsb);	
UINT PM41_BCDPutSSM(UINT msg,USHORT value);	
UINT PM41_BCDPutSign(UINT msg,USHORT sign);	
UINT PM41_BCDPutMant(UINT msg,UINT value,USHORT sigdig,USHORT sign);	
UINT PM41_BCDPutVal(LPCSTR buf,UINT msg,USHORT sigdig,LPCSTR resolstr);	

/**
*
*	PM41 ASCII Funtions: UTILASC.C
*
**/
INT PM41_ValLenAscii(INT numbits,INT radixval);
UINT PM41_ValFromAscii(LPCSTR asciistr,INT radixval);
LPSTR PM41_ValToAscii(UINT value,LPSTR asciistr,INT numbits,INT radixval);
LPSTR PM41_ValInccAscii(LPSTR asciistr);
LPSTR PM41_ValIncAscii(LPSTR asciistr);
BOOL PM41_ValIsLower(INT value);
INT PM41_ValToUpper(INT value);
INT PM41_ValAsciiCmpi(LPSTR str1,LPSTR str2);
VOID PM41_ValAsciiTrimLead(LPSTR buf);
VOID PM41_ValAsciiTrimTrail(LPSTR buf);
LPSTR PM41_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);

/**
*
*	PM41 Mantissa Functions: UTILMANT.C
*
**/
ERRVAL PM41_AsciiToMant(LPCSTR str,LPUINT mant,LPUINT exp);
LPSTR PM41_MantToAscii(LPSTR buf,long mant,int exp);
VOID PM41_NormalMant(LPUINT mant,LPUINT exp);
VOID PM41_ExpandMant(LPUINT mant,LPUINT exp);
VOID PM41_MaxMant(LPUINT mant,LPUINT exp);
USHORT PM41_SignMant(LPCSTR str);

#ifdef __cplusplus
}
#endif


#endif // _429UTIL_H
