#ifdef _WIN32
#include <bticard.h>
#else
#include "../bticard/bticard.h"
#endif

#include "BTICardg.h"
#include <string.h>
//#include <android/log.h>

#ifdef _WIN32
#ifndef UINT16
#define UINT16 unsigned short
#endif

#ifndef LPUINT16
#define LPUINT16 unsigned short *
#endif

#ifndef UINT32
#define UINT32 unsigned int
#endif

#ifndef LPUINT32
#define LPUINT32 unsigned int *
#endif
#endif

#define DEBUG_TAG "BTICardg"

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardClose
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardClose
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_CardClose(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardIsRunning
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_CardIsRunning
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_CardIsRunning(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardOpen
 * Signature: (Lballard/BTICard/IntRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardOpen
  (JNIEnv* env, jobject this, jobject lpHandle, jint cardnum)
{
	ERRVAL errval;
	HCARD hCard;
	jclass cls;
	jmethodID methodID;

    errval = BTICard_CardOpen(&hCard, cardnum);

	cls = (*env)->GetObjectClass(env, lpHandle);
    methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, lpHandle, methodID, (jint) hCard);
    return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardProductStr
 * Signature: (I)Ljava/lang/String
{
}
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_CardProductStr
  (JNIEnv* env, jobject this, jint handleval)
{
	LPCSTR str = BTICard_CardProductStr(handleval);
	return (*env)->NewStringUTF(env, str);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardReset
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardReset
  (JNIEnv* env, jobject this, jint handleval)
{
	BTICard_CardReset(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardResume
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardResume
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_CardResume(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardStart
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardStart
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_CardStart(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardStop
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_CardStop
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_CardStop(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTest
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardTest
  (JNIEnv* env, jobject this, jint level, jint handleval)
{
	return BTICard_CardTest(level, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTrigger
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardTrigger
  (JNIEnv* env, jobject this, jint handleval)
{
	BTICard_CardTrigger(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTriggerEx
 * Signature: (CI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardTriggerEx
  (JNIEnv* env, jobject this, jchar trigmask, jint handleval)
{
	BTICard_CardTriggerEx(trigmask, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTypeStr
 * Signature: (I)Ljava/lang/String
{
}
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_CardTypeStr
  (JNIEnv* env, jobject this, jint handleval)
{
	LPCSTR str = BTICard_CardTypeStr(handleval);
	return (*env)->NewStringUTF(env, str);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CoreOpen
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CoreOpen
  (JNIEnv* env, jobject this, jobject lphCore, jint corenum, jint cardnum)
{
	ERRVAL errval;
	HCORE hCore;
	jclass cls;
	jmethodID methodID;

	errval = BTICard_CoreOpen(&hCore, corenum, cardnum);

	cls = (*env)->GetObjectClass(env, lphCore);
    methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, lphCore, methodID, (jint) hCore);

    return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ErrDescStr
 * Signature: (II)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_ErrDescStr
  (JNIEnv* env, jobject this, jint errval, jint handleval)
{
	LPCSTR str = BTICard_ErrDescStr(errval, handleval);
	return (*env)->NewStringUTF(env, str);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogConfig
 * Signature: (CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogConfig
  (JNIEnv* env, jobject this, jchar configval, jint count, jint handleval)
{
	return BTICard_EventLogConfig(configval, count, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogRd
 * Signature: (Lballard/BTICard/CharRef;Lballard/BTICard/LongRef;Lballard/BTICard/IntRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogRd
  (JNIEnv* env, jobject this, jobject typeval, jobject infoval, jobject channel, jint handleval)
{
	UINT16 ctypeval;
	UINT32 cinfoval;
	INT cchannel;
	ERRVAL errval;
	jclass cls;
	jmethodID methodID;

	errval = BTICard_EventLogRd(&ctypeval, &cinfoval, &cchannel, handleval);
    //__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "EventLogRd ctypeval %i, cinfoval %i, cchannel %i", ctypeval, cinfoval, cchannel);

	cls = (*env)->GetObjectClass(env, typeval);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(C)V");
    (*env)->CallVoidMethod(env, typeval, methodID, (jchar) ctypeval);

	cls = (*env)->GetObjectClass(env, infoval);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, infoval, methodID, (jlong) cinfoval);

	cls = (*env)->GetObjectClass(env, channel);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, channel, methodID, (jint) cchannel);

    return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogStatus
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogStatus
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_EventLogStatus(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIOMonConfig
 * Signature: (CCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_ExtDIOMonConfig
  (JNIEnv* env, jobject this, jchar rise_edge, jchar fall_edge, jint banknum, jint handleval)
{
	return BTICard_ExtDIOMonConfig(rise_edge, fall_edge, banknum, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIORd
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_ExtDIORd
  (JNIEnv* env, jobject this, jint dionum, jint handleval)
{
	return BTICard_ExtDIORd(dionum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIOWr
 * Signature: (IZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtDIOWr
  (JNIEnv* env, jobject this, jint dionum, jboolean dioval, jint handleval)
{
	BTICard_ExtDIOWr(dionum, dioval, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtLEDRd
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_ExtLEDRd
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_ExtLEDRd(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtLEDWr
 * Signature: (ZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtLEDWr
  (JNIEnv* env, jobject this, jboolean ledval, jint handleval)
{
	BTICard_ExtLEDWr(ledval, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtStatusLEDRd
 * Signature: (Lballard/BTICard/BooleanRef;Lballard/BTICard/BooleanRef;I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtStatusLEDRd
  (JNIEnv* env, jobject this, jobject ledon, jobject ledcolor, jint handleval)
{
	BOOL cledon;
	BOOL cledcolor;
	jclass cls;
	jmethodID methodID;

	BTICard_ExtStatusLEDRd(&cledon, &cledcolor, handleval);

	cls = (*env)->GetObjectClass(env, ledon);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(Z)V");
    (*env)->CallVoidMethod(env, ledon, methodID, (jboolean) cledon);

	cls = (*env)->GetObjectClass(env, ledcolor);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(Z)V");
    (*env)->CallVoidMethod(env, ledcolor, methodID, (jboolean) cledcolor);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtStatusLEDWr
 * Signature: (ZZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtStatusLEDWr
  (JNIEnv* env, jobject this, jboolean ledon, jboolean ledcolor, jint handleval)
{
	BTICard_ExtStatusLEDWr(ledon, ledcolor, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGConfig
 * Signature: (JI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGConfig
  (JNIEnv* env, jobject this, jlong configval, jint handleval)
{
	return BTICard_IRIGConfig(configval, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetDays
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetDays
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetDays(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetHours
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetHours
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetHours(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMicrosec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMicrosec
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetMicrosec(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMillisec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMillisec
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetMillisec(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMin
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMin
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetMin(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetSec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetSec
  (JNIEnv* env, jobject this, jlong irigvalh, jlong irigvall)
{
	return BTICard_IRIGFieldGetSec(irigvalh, irigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutDays
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutDays
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutDays(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutHours
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutHours
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutHours(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMicrosec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMicrosec
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutMicrosec(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMillisec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMillisec
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutMillisec(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMin
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMin
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutMin(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutSec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutSec
  (JNIEnv* env, jobject this, jlong value, jobject irigvalh, jobject irigvall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGFieldPutSec(value, &cirigvalh, &cirigvall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGInputThresholdGet
 * Signature: (Lballard/BTICard/CharRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGInputThresholdGet
  (JNIEnv* env, jobject this, jobject dacval, jint handleval)
{
	UINT16 cdacval;
	ERRVAL errval;
	jclass cls;
	jmethodID methodID;

	errval = BTICard_IRIGInputThresholdGet(&cdacval, handleval);

	cls = (*env)->GetObjectClass(env, dacval);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(C)V");
    (*env)->CallVoidMethod(env, dacval, methodID, (jchar) cdacval);

    return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGInputThresholdSet
 * Signature: (CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGInputThresholdSet
  (JNIEnv* env, jobject this, jchar dacval, jint handleval)
{
	return BTICard_IRIGInputThresholdSet(dacval, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGRd
 * Signature: (Lballard/BTICard/BTIIRIGTIME;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGRd
  (JNIEnv* env, jobject this, jobject irigtime, jint handleval)
{
	BTIIRIGTIME cirigtime;
	jclass cls;
	jfieldID fid;
	ERRVAL errval;

	errval = BTICard_IRIGRd(&cirigtime, handleval);

	cls = (*env)->GetObjectClass(env, irigtime);
	fid = (*env)->GetFieldID(env, cls, "days", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.days);
	fid = (*env)->GetFieldID(env, cls, "hours", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.hours);
	fid = (*env)->GetFieldID(env, cls, "min", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.min);
	fid = (*env)->GetFieldID(env, cls, "sec", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.sec);
	fid = (*env)->GetFieldID(env, cls, "msec", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.msec);
	fid = (*env)->GetFieldID(env, cls, "usec", "I");
	(*env)->SetIntField(env, irigtime, fid, cirigtime.usec);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGSyncStatus
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_IRIGSyncStatus
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_IRIGSyncStatus(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGTimeBCDToBin
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;JJ)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGTimeBCDToBin
  (JNIEnv* env, jobject this, jobject timevalh, jobject timevall, jlong irigvalh, jlong irigvall)
{
	UINT32 ctimevalh;
	UINT32 ctimevall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGTimeBCDToBin(&ctimevalh, &ctimevall, irigvalh, irigvall);

	cls = (*env)->GetObjectClass(env, timevalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, timevalh, methodID, (jlong) ctimevalh);

	cls = (*env)->GetObjectClass(env, timevall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, timevall, methodID, (jlong) ctimevall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGTimeBinToBCD
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;JJ)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGTimeBinToBCD
  (JNIEnv* env, jobject this, jobject irigvalh, jobject irigvall, jlong timevalh, jlong timevall)
{
	UINT32 cirigvalh;
	UINT32 cirigvall;
	jclass cls;
	jmethodID methodID;

	BTICard_IRIGTimeBinToBCD(&cirigvalh, &cirigvall, timevalh, timevall);
    //__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "IRIGTimeBinToBCD cirigvalh %i, cirigvall %i, timevalh %i, timevall %i", cirigvalh, cirigvall, timevalh, timevall);

	cls = (*env)->GetObjectClass(env, irigvalh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvalh, methodID, (jlong) cirigvalh);

	cls = (*env)->GetObjectClass(env, irigvall);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, irigvall, methodID, (jlong) cirigvall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGWr
 * Signature: (Lballard/BTICard/BTIIRIGTIME;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGWr
  (JNIEnv* env, jobject this, jobject irigtime, jint handleval)
{
	BTIIRIGTIME cirigtime;
	jclass cls;
	jfieldID fid;

	cls = (*env)->GetObjectClass(env, irigtime);
	fid = (*env)->GetFieldID(env, cls, "days", "I");
	cirigtime.days = (*env)->GetIntField(env, irigtime, fid);
	fid = (*env)->GetFieldID(env, cls, "hours", "I");
	cirigtime.hours = (*env)->GetIntField(env, irigtime, fid);
	fid = (*env)->GetFieldID(env, cls, "min", "I");
	cirigtime.min = (*env)->GetIntField(env, irigtime, fid);
	fid = (*env)->GetFieldID(env, cls, "sec", "I");
	cirigtime.sec = (*env)->GetIntField(env, irigtime, fid);
	fid = (*env)->GetFieldID(env, cls, "msec", "I");
	cirigtime.msec = (*env)->GetIntField(env, irigtime, fid);
	fid = (*env)->GetFieldID(env, cls, "usec", "I");
	cirigtime.usec = (*env)->GetIntField(env, irigtime, fid);

	return BTICard_IRIGWr(&cirigtime, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    MakeLong
 * Signature: (CC)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_MakeLong
  (JNIEnv * env, jobject this, jchar valh, jchar vall)
{
	return BTICard_MakeLong(valh, vall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    MakeWord
 * Signature: (BB)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTICard_MakeWord
  (JNIEnv * env, jobject this, jbyte valh, jbyte vall)
{
	return BTICard_MakeWord(valh, vall);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqBlkRd
 * Signature: ([CILballard/BTICard/LongRef;I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_SeqBlkRd
  (JNIEnv* env, jobject this, jcharArray buf, jint bufcount, jobject blkcnt, jint handleval)
{
	UINT32 cblkcnt;
	UINT32 retval;
	jclass cls;
	jmethodID methodID;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	retval = BTICard_SeqBlkRd(bufPtr, bufcount, &cblkcnt, handleval);

	//__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "BTICard_SeqBlkRd cblkcnt = %i", cblkcnt);

	cls = (*env)->GetObjectClass(env, blkcnt);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, blkcnt, methodID, (jlong) cblkcnt);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return retval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqCommRd
 * Signature: ([CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqCommRd
  (JNIEnv* env, jobject this, jcharArray buf, jint bufcount, jint handleval)
{
	ERRVAL errval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	errval = BTICard_SeqCommRd(bufPtr, bufcount, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqConfig
 * Signature: (JI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqConfig
  (JNIEnv* env, jobject this, jlong configval, jint handleval)
{
	return BTICard_SeqConfig(configval, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqDMARd
 * Signature: ([CJI)j
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_SeqDMARd
  (JNIEnv* env, jobject this, jcharArray buf, jlong bufcount, jint handleval)
{
	UINT32 retval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	retval = BTICard_SeqDMARd(bufPtr, bufcount, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return retval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindCheckVersion
 * Signature: ([CC)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqFindCheckVersion
  (JNIEnv* env, jobject this, jcharArray pRecord, jchar version)
{
	jboolean retval;

	jchar* pRecordPtr = (*env)->GetCharArrayElements(env, pRecord, 0);

	retval = BTICard_SeqFindCheckVersion(pRecordPtr, version) ? JNI_TRUE : JNI_FALSE;

	(*env)->ReleaseCharArrayElements(env, pRecord, pRecordPtr, 0);

	return retval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindInit
 * Signature: ([CJLballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindInit
  (JNIEnv* env, jobject this, jcharArray seqbuf, jlong seqbufsize, jobject sfinfo)
{
	SEQFINDINFO csfinfo;
	jclass cls;
	jfieldID fid;
	ERRVAL errval;

	jchar* seqbufPtr = (*env)->GetCharArrayElements(env, seqbuf, 0);

	errval = BTICard_SeqFindInit(seqbufPtr, seqbufsize, &csfinfo);
	//__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "BTICard_SeqFindInit pRecFirst = %04x, pRecNext = %04x, pRecLast = %04x", csfinfo.pRecFirst, csfinfo.pRecNext, csfinfo.pRecLast);

	cls = (*env)->GetObjectClass(env, sfinfo);
	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecFirst);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecNext);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecLast);

	(*env)->ReleaseCharArrayElements(env, seqbuf, seqbufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindMore1553
 * Signature: (Lballard/BTICard/SEQRECORDMORE1553;Lballard/BTICard/SEQRECORD1553;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindMore1553
  (JNIEnv* env, jobject this, jobject pRecMore, jobject pRecBase)
{
	LPSEQRECORDMORE1553 pcrecmore;
	SEQRECORD1553 crecbase;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	ERRVAL errval;

	cls = (*env)->GetObjectClass(env, pRecBase);
	fid = (*env)->GetFieldID(env, cls, "type", "C");
	crecbase.type = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "count", "I");
	crecbase.count = (*env)->GetIntField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "timestamp", "J");
	crecbase.timestamp = (*env)->GetLongField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "activity", "C");
	crecbase.activity = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "error", "C");
	crecbase.error = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	crecbase.cwd1 = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	crecbase.cwd2 = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	crecbase.swd1 = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	crecbase.swd2 = (*env)->GetCharField(env, pRecBase, fid);
	fid = (*env)->GetFieldID(env, cls, "datacount", "I");
	crecbase.datacount = (*env)->GetIntField(env, pRecBase, fid);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, pRecBase, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy((void *) crecbase.data, (void *) dataArrayPtr, sizeof(crecbase.data));

	errval = BTICard_SeqFindMore1553(&pcrecmore, &crecbase);
	if (errval) return errval;

	cls = (*env)->GetObjectClass(env, pRecMore);
	fid = (*env)->GetFieldID(env, cls, "timestamph", "J");
	(*env)->SetLongField(env, pRecMore, fid, pcrecmore->timestamph);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	(*env)->SetIntField(env, pRecMore, fid, pcrecmore->resptime1);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	(*env)->SetIntField(env, pRecMore, fid, pcrecmore->resptime2);

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNext1553
 * Signature: (Lballard/BTICard/SEQRECORD1553;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNext1553
  (JNIEnv* env, jobject this, jobject pRecord, jobject sfinfo)
{
	SEQFINDINFO csfinfo;
	LPSEQRECORD1553 pcRecord;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	ERRVAL errval;

	cls = (*env)->GetObjectClass(env, sfinfo);
	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	csfinfo.pRecFirst = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	csfinfo.pRecNext = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	csfinfo.pRecLast = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);

	//__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "SeqFindNext1553 pRecFirst = %04x, pRecNext = %04x, pRecLast = %04x", csfinfo.pRecFirst, csfinfo.pRecNext, csfinfo.pRecLast);
	errval = BTICard_SeqFindNext1553(&pcRecord, &csfinfo);
	//__android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "SeqFindNext1553 returned %i", errval);
	if (errval) return errval;

	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecFirst);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecNext);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecLast);

	cls = (*env)->GetObjectClass(env, pRecord);
	fid = (*env)->GetFieldID(env, cls, "type", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->type);
	fid = (*env)->GetFieldID(env, cls, "count", "I");
	(*env)->SetIntField(env, pRecord, fid, pcRecord->count);
	fid = (*env)->GetFieldID(env, cls, "timestamp", "J");
	(*env)->SetLongField(env, pRecord, fid, pcRecord->timestamp);
	fid = (*env)->GetFieldID(env, cls, "activity", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->activity);
	fid = (*env)->GetFieldID(env, cls, "error", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->error);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->cwd1);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->cwd2);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->swd1);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->swd2);
	fid = (*env)->GetFieldID(env, cls, "datacount", "I");
	(*env)->SetIntField(env, pRecord, fid, pcRecord->datacount);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, pRecord, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy((void *) dataArrayPtr, (void *) pcRecord->data, sizeof(pcRecord->data));

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNext429
 * Signature: (Lballard/BTICard/SEQRECORD429;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNext429
  (JNIEnv* env, jobject this, jobject pRecord, jobject sfinfo)
{
	SEQFINDINFO csfinfo;
	LPSEQRECORD429 pcRecord;
	jclass cls;
	jfieldID fid;
	ERRVAL errval;

	cls = (*env)->GetObjectClass(env, sfinfo);
	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	csfinfo.pRecFirst = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	csfinfo.pRecNext = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	csfinfo.pRecLast = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);

	errval = BTICard_SeqFindNext429(&pcRecord, &csfinfo);
	if (errval) return errval;

	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecFirst);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecNext);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecLast);

	cls = (*env)->GetObjectClass(env, pRecord);
	fid = (*env)->GetFieldID(env, cls, "type", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->type);
	fid = (*env)->GetFieldID(env, cls, "count", "I");
	(*env)->SetIntField(env, pRecord, fid, pcRecord->count);
	fid = (*env)->GetFieldID(env, cls, "timestamp", "J");
	(*env)->SetLongField(env, pRecord, fid, pcRecord->timestamp);
	fid = (*env)->GetFieldID(env, cls, "activity", "C");
	(*env)->SetCharField(env, pRecord, fid, pcRecord->activity);
	fid = (*env)->GetFieldID(env, cls, "decgap", "I");
	(*env)->SetIntField(env, pRecord, fid, pcRecord->decgap);
	fid = (*env)->GetFieldID(env, cls, "data", "J");
	(*env)->SetLongField(env, pRecord, fid, pcRecord->data);
	fid = (*env)->GetFieldID(env, cls, "timestamph", "J");
	(*env)->SetLongField(env, pRecord, fid, pcRecord->timestamph);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNextEx
 * Signature: ([CILballard/BTICard/CharRef;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNextEx
  (JNIEnv* env, jobject this, jcharArray pRecord, jint recordcount, jobject seqtype, jobject sfinfo)
{
	UINT16 cseqtype;
	SEQFINDINFO csfinfo;
	jclass cls;
	jmethodID methodID;
	jfieldID fid;
	jclass clscharref;
	ERRVAL errval;

	jchar* pRecordPtr = (*env)->GetCharArrayElements(env, pRecord, 0);

	cls = (*env)->GetObjectClass(env, sfinfo);
	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	csfinfo.pRecFirst = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	csfinfo.pRecNext = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	csfinfo.pRecLast = (LPUINT16) (*env)->GetIntField(env, sfinfo, fid);

	errval = BTICard_SeqFindNextEx(pRecordPtr, recordcount, &cseqtype, &csfinfo);
	if (errval) return errval;

	fid = (*env)->GetFieldID(env, cls, "pRecFirst", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecFirst);
	fid = (*env)->GetFieldID(env, cls, "pRecNext", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecNext);
	fid = (*env)->GetFieldID(env, cls, "pRecLast", "I");
	(*env)->SetIntField(env, sfinfo, fid, (jint) csfinfo.pRecLast);

	clscharref = (*env)->GetObjectClass(env, seqtype);
	methodID = (*env)->GetMethodID(env, clscharref, "setValue", "(C)V");
    (*env)->CallVoidMethod(env, seqtype, methodID, cseqtype);

	(*env)->ReleaseCharArrayElements(env, pRecord, pRecordPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqInterval
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqInterval
  (JNIEnv* env, jobject this, jint interval, jint mode, jint handleval)
{
	return BTICard_SeqInterval(interval, mode, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqIsRunning
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqIsRunning
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_SeqIsRunning(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqLogFrequency
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqLogFrequency
  (JNIEnv* env, jobject this, jint logfreq, jint handleval)
{
	return BTICard_SeqLogFrequency(logfreq, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqRdEx
 * Signature: ([CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqRdEx
  (JNIEnv* env, jobject this, jcharArray buf, jint bufcount, jint handleval)
{
	ERRVAL errval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	errval = BTICard_SeqRdEx(bufPtr, bufcount, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqResume
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqResume
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_SeqResume(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStart
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStart
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_SeqStart(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStatus
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStatus
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_SeqStatus(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStop
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStop
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_SeqStop(handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    Timer64Rd
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_Timer64Rd
  (JNIEnv* env, jobject this, jobject valueh, jobject valuel, jint handleval)
{
	jclass cls;
	jmethodID methodID;
	UINT32 cvalueh;
	UINT32 cvaluel;
	ERRVAL errval;

	errval = BTICard_Timer64Rd(&cvalueh, &cvaluel, handleval);

	cls = (*env)->GetObjectClass(env, valueh);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, valueh, methodID, (jlong) cvalueh);

	cls = (*env)->GetObjectClass(env, valuel);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(J)V");
    (*env)->CallVoidMethod(env, valuel, methodID, (jlong) cvaluel);

    return errval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    Timer64Wr
 * Signature: (JJI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_Timer64Wr
  (JNIEnv* env, jobject this, jlong valueh, jlong valuel, jint handleval)
{
	BTICard_Timer64Wr(valueh, valuel, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerClear
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_TimerClear
  (JNIEnv* env, jobject this, jint handleval)
{
	BTICard_TimerClear(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerRd
 * Signature: (I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_TimerRd
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_TimerRd(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerResolution
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_TimerResolution
  (JNIEnv* env, jobject this, jint timerresol, jint handleval)
{
	return BTICard_TimerResolution(timerresol, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerStatus
 * Signature: (I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_TimerStatus
  (JNIEnv* env, jobject this, jint handleval)
{
	return BTICard_TimerStatus(handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerWr
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_TimerWr
  (JNIEnv* env, jobject this, jlong value, jint handleval)
{
	BTICard_TimerWr(value, handleval);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValFromAscii
 * Signature: (Ljava/lang/String;I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValFromAscii
  (JNIEnv* env, jobject this, jstring asciistr, jint radixval)
{
	UINT32 retval;
	const char *casciistr = (*env)->GetStringUTFChars(env, asciistr, 0);

	retval = BTICard_ValFromAscii(casciistr, radixval);

	(*env)->ReleaseStringUTFChars(env, asciistr, casciistr);

	return retval;
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValGetBits
 * Signature: (III)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValGetBits
  (JNIEnv* env, jobject this, jint oldvalue, jint startbit, jint endbit)
{
	return BTICard_ValGetBits(oldvalue, startbit, endbit);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValPutBits
 * Signature: (IIII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValPutBits
  (JNIEnv* env, jobject this, jint oldvalue, jint newfld, jint startbit, jint endbit)
{
	return BTICard_ValPutBits(oldvalue, newfld, startbit, endbit);
}

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValToAscii
 * Signature: (JLballard/BTICard/StringRef;II)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_ValToAscii
  (JNIEnv* env, jobject this, jlong value, jobject asciistr, jint numbits, jint radixval)
{
	char casciistr[250];
	jclass cls;
	jstring objstr;
	jmethodID methodID;

	BTICard_ValToAscii(value, casciistr, numbits, radixval);

	objstr = (*env)->NewStringUTF(env, casciistr);
	cls = (*env)->GetObjectClass(env, asciistr);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(Ljava/lang/String;)V");
	(*env)->CallVoidMethod(env, asciistr, methodID, objstr);

	return objstr;
}

#ifndef WIN32
/*
 * Class:     com_ballardtech_BTICard
 * Method:    BJTestAssoc
 * Signature: (ILjava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_BJTestAssoc
  (JNIEnv* env, jobject this, jint fd, jstring devicename)
{
	const char *cdevname = (*env)->GetStringUTFChars(env, devicename, 0);
	BTIHAL_BJTestAssoc(fd, cdevname);
	(*env)->ReleaseStringUTFChars(env, devicename, cdevname);
}
#endif