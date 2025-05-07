#ifdef _WIN32
#include <bti1553.h>
#else
#include "../bti1553/bti1553.h"
#endif

#include "BTI1553g.h"
#include <stdlib.h>
#include <string.h>
//#include <android/log.h>

#define DEBUG_TAG "BTI1553g"

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

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfig
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfig
  (JNIEnv* env, jobject this, jint configval, jint channum, jint handleval)
{
	return BTI1553_BCConfig(configval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfigEx
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfigEx
  (JNIEnv* env, jobject this, jint configval, jint count, jint channum, jint handleval)
{
	return BTI1553_BCConfigEx(configval, count, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfigMsg
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfigMsg
  (JNIEnv* env, jobject this, jint configval, jint msgaddr, jint handleval)
{
	return BTI1553_BCConfigMsg(configval, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCCreateList
 * Signature: (IIICC[CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCCreateList
  (JNIEnv* env, jobject this, jint listconfigval, jint count, jint msgconfigval, jchar cwd1, jchar cwd2, jcharArray data, jint handleval)
{
	ERRVAL errval;

	jchar* dataArrayPtr = data ? (*env)->GetCharArrayElements(env, data, 0) : NULL;

	errval = BTI1553_BCCreateList(listconfigval, count, msgconfigval, cwd1, cwd2, dataArrayPtr, handleval);

	if (data) (*env)->ReleaseCharArrayElements(env, data, dataArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCCreateMsg
 * Signature: (ICC[CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCCreateMsg
  (JNIEnv* env, jobject this, jint configval, jchar cwd1, jchar cwd2, jcharArray data, jint handleval)
{
	MSGADDR msgaddr;

	jchar* dataArrayPtr = data ? (*env)->GetCharArrayElements(env, data, 0) : NULL;

	msgaddr = BTI1553_BCCreateMsg(configval, cwd1, cwd2, dataArrayPtr, handleval);

	if (data) (*env)->ReleaseCharArrayElements(env, data, dataArrayPtr, 0);

	return msgaddr;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCPause
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BCPause
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	BTI1553_BCPause(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCPauseCheck
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCPauseCheck
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCPauseCheck(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCResume
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BCResume
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	BTI1553_BCResume(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedAgain
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedAgain
  (JNIEnv* env, jobject this, jint index, jint channum, jint handleval)
{
	return BTI1553_BCSchedAgain(index, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBranch
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBranch
  (JNIEnv* env, jobject this, jint condition, jint destindex, jint channum, jint handleval)
{
	return BTI1553_BCSchedBranch(condition, destindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBranchUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBranchUpdate
  (JNIEnv* env, jobject this, jint destindex, jint opcodeindex, jint channum, jint handleval)
{
	return BTI1553_BCSchedBranchUpdate(destindex, opcodeindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBuild
 * Signature: (I[I[CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBuild
  (JNIEnv* env, jobject this, jint nummsgs, jintArray msgaddr, jcharArray freq, jint channum, jint handleval)
{
	jint* msgaddrPtr;
	jchar* freqPtr;
	ERRVAL errval;

	msgaddrPtr = msgaddr ? (*env)->GetIntArrayElements(env, msgaddr, 0) : NULL;
	freqPtr = freq ? (*env)->GetCharArrayElements(env, freq, 0) : NULL;

	errval = BTI1553_BCSchedBuild(nummsgs, msgaddrPtr, freqPtr, channum, handleval);

	if (msgaddr) (*env)->ReleaseIntArrayElements(env, msgaddr, msgaddrPtr, 0);
	if (freq) (*env)->ReleaseCharArrayElements(env, freq, freqPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedCall
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedCall
  (JNIEnv* env, jobject this, jint condition, jint destindex, jint channum, jint handleval)
{
	return BTI1553_BCSchedCall(condition, destindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedCallUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedCallUpdate
  (JNIEnv* env, jobject this, jint destindex, jint opcodeindex, jint channum, jint handleval)
{
	return BTI1553_BCSchedCallUpdate(destindex, opcodeindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedEntry
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedEntry
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedEntry(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrame
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrame
  (JNIEnv* env, jobject this, jint timeval, jint channum, jint handleval)
{
	return BTI1553_BCSchedFrame(timeval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrameEnd
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrameEnd
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedFrameEnd(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrameStart
 * Signature: (JII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrameStart
  (JNIEnv* env, jobject this, jlong timeval, jint channum, jint handleval)
{
	return BTI1553_BCSchedFrameStart(timeval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedGap
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedGap
  (JNIEnv* env, jobject this, jint gapval, jint channum, jint handleval)
{
	return BTI1553_BCSchedGap(gapval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedHalt
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedHalt
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedHalt(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedLog
 * Signature: (ICII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedLog
  (JNIEnv* env, jobject this, jint condition, jchar tagval, jint channum, jint handleval)
{
	return BTI1553_BCSchedLog(condition, tagval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedMsg
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedMsg
  (JNIEnv* env, jobject this, jint msgaddr, jint channum, jint handleval)
{
	return BTI1553_BCSchedMsg(msgaddr, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPause
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPause
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedPause(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse
  (JNIEnv* env, jobject this, jint dionum, jint channum, jint handleval)
{
	return BTI1553_BCSchedPulse(dionum, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse0
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse0
  (JNIEnv* env, jobject this, jint dionum, jint channum, jint handleval)
{
	return BTI1553_BCSchedPulse0(dionum, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse1
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse1
  (JNIEnv* env, jobject this, jint dionum, jint channum, jint handleval)
{
	return BTI1553_BCSchedPulse1(dionum, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedRestart
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedRestart
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedRestart(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedRetry
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedRetry
  (JNIEnv* env, jobject this, jint condition, jint retries, jint channum, jint handleval)
{
	return BTI1553_BCSchedRetry(condition, retries, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedReturn
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedReturn
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_BCSchedReturn(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSetDefaultGap
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSetDefaultGap
  (JNIEnv* env, jobject this, jint gapval, jint channum, jint handleval)
{
	return BTI1553_BCSetDefaultGap(gapval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSetTimeout
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSetTimeout
  (JNIEnv* env, jobject this, jint timeoutval, jint channum, jint handleval)
{
	return BTI1553_BCSetTimeout(timeoutval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSyncDefine
 * Signature: (ZCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSyncDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar syncmask, jchar pinpolarity, jint channum, jint handleval)
{
	return BTI1553_BCSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCTransmitMsg
 * Signature: (Lballard/BTI1553/XMITFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCTransmitMsg
  (JNIEnv* env, jobject this, jobject xmitfields, jint channum, jint handleval)
{
	XMITFIELDS1553 cxmitfields;
	ERRVAL errval;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;

	cls = (*env)->GetObjectClass(env, xmitfields);
	fid = (*env)->GetFieldID(env, cls, "ctrlflags", "I");
	cxmitfields.ctrlflags = (*env)->GetIntField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "flag1", "C");
	cxmitfields.flag1 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "flag2", "C");
	cxmitfields.flag2 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "errflags", "C");
	cxmitfields.errflags = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "actflags", "C");
	cxmitfields.actflags = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	cxmitfields.resptime1 = (*env)->GetIntField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	cxmitfields.resptime2 = (*env)->GetIntField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	cxmitfields.datacount = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	cxmitfields.extflag = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetag", "J");
	cxmitfields.timetag = (*env)->GetLongField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "elapsetime", "J");
	cxmitfields.elapsetime = (*env)->GetLongField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	cxmitfields.preaddr = (*env)->GetIntField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	cxmitfields.postaddr = (*env)->GetIntField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	cxmitfields.timetagh = (*env)->GetLongField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	cxmitfields.resv18 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	cxmitfields.resv19 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	cxmitfields.cwd1 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	cxmitfields.cwd2 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	cxmitfields.swd1 = (*env)->GetCharField(env, xmitfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	cxmitfields.swd2 = (*env)->GetCharField(env, xmitfields, fid);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, xmitfields, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy(cxmitfields.data, dataArrayPtr, sizeof(cxmitfields.data));

	fid = (*env)->GetFieldID(env, cls, "extra", "[C");
	extraArray = (jcharArray) (*env)->GetObjectField(env, xmitfields, fid);
	extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
	memcpy(cxmitfields.extra, extraArrayPtr, sizeof(cxmitfields.extra));

	errval = BTI1553_BCTransmitMsg(&cxmitfields, channum, handleval);

	fid = (*env)->GetFieldID(env, cls, "ctrlflags", "I");
	(*env)->SetIntField(env, xmitfields, fid, cxmitfields.ctrlflags);
	fid = (*env)->GetFieldID(env, cls, "flag1", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.flag1);
	fid = (*env)->GetFieldID(env, cls, "flag2", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.flag2);
	fid = (*env)->GetFieldID(env, cls, "errflags", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.errflags);
	fid = (*env)->GetFieldID(env, cls, "actflags", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.actflags);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	(*env)->SetIntField(env, xmitfields, fid, cxmitfields.resptime1);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	(*env)->SetIntField(env, xmitfields, fid, cxmitfields.resptime2);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.datacount);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.extflag);
	fid = (*env)->GetFieldID(env, cls, "timetag", "J");
	(*env)->SetLongField(env, xmitfields, fid, cxmitfields.timetag);
	fid = (*env)->GetFieldID(env, cls, "elapsetime", "J");
	(*env)->SetLongField(env, xmitfields, fid, cxmitfields.elapsetime);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	(*env)->SetIntField(env, xmitfields, fid, cxmitfields.preaddr);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	(*env)->SetIntField(env, xmitfields, fid, cxmitfields.postaddr);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	(*env)->SetLongField(env, xmitfields, fid, cxmitfields.timetagh);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.resv18);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.resv19);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.cwd1);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.cwd2);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.swd1);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	(*env)->SetCharField(env, xmitfields, fid, cxmitfields.swd2);

	memcpy(dataArrayPtr, cxmitfields.data, sizeof(cxmitfields.data));
	memcpy(extraArrayPtr, cxmitfields.extra, sizeof(cxmitfields.extra));

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
	(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCTriggerDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar trigmask, jchar trigval, jchar pinpolarity, jint channum, jint handleval)
{
	return BTI1553_BCTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BlkPtrRd
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BlkPtrRd
  (JNIEnv * env, jobject this, jint taval, jint channum, jint handleval)
{
	return BTI1553_BlkPtrRd(taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BlkPtrWr
 * Signature: (IIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BlkPtrWr
  (JNIEnv * env, jobject this, jint descaddr, jint taval, jint channum, jint handleval)
{
	BTI1553_BlkPtrWr(descaddr, taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChGetCount
 * Signature: (Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_ChGetCount
  (JNIEnv* env, jobject this, jobject a_count, jobject b4_count, jobject b32_count, jobject c_count, jint handleval)
{
	INT ca_count, cb4_count, cb32_count, cc_count;
	jclass cls;
	jmethodID methodID;

	BTI1553_ChGetCount(&ca_count, &cb4_count, &cb32_count, &cc_count, handleval);

	cls = (*env)->GetObjectClass(env, a_count);
    methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, a_count, methodID, (jint) ca_count);

	cls = (*env)->GetObjectClass(env, b4_count);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, b4_count, methodID, (jint) cb4_count);

	cls = (*env)->GetObjectClass(env, b32_count);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, b32_count, methodID, (jint) cb32_count);

	cls = (*env)->GetObjectClass(env, c_count);
	  methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, c_count, methodID, (jint) cc_count);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChGetInfo
 * Signature: (CII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_ChGetInfo
  (JNIEnv* env, jobject this, jchar infotype, jint channum, jint handleval)
{
	return BTI1553_ChGetInfo(infotype, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIs1553
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIs1553
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIs1553(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsA
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsA
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsA(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsB32
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsB32
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsB32(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsB4
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsB4
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsB4(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsBM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsBM
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsBM(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsC
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsC
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsC(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsD
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsD
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsD(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsM
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsM(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsRM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsRM
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsRM(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsS
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsS
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsS(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsX
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsX
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChIsX(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChStart
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChStart
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChStart(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChStop
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChStop
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ChStop(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdMaxLoopRd
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdMaxLoopRd
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_CmdMaxLoopRd(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdMaxLoopWr
 * Signature: (III)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_CmdMaxLoopWr
  (JNIEnv* env, jobject this, jint countval, jint channum, jint handleval)
{
	BTI1553_CmdMaxLoopWr(countval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdShotRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdShotRd
  (JNIEnv* env, jobject this, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdShotRd(index, channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdShotWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdShotWr
  (JNIEnv* env, jobject this, jboolean value, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdShotWr(value, index, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdSkipRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdSkipRd
  (JNIEnv* env, jobject this, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdSkipRd(index, channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdSkipWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdSkipWr
  (JNIEnv* env, jobject this, jboolean value, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdSkipWr(value, index, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdStepRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdStepRd
  (JNIEnv* env, jobject this, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdStepRd(index, channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdStepWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdStepWr
  (JNIEnv* env, jobject this, jboolean value, jint index, jint channum, jint handleval)
{
	return BTI1553_CmdStepWr(value, index, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorCtrl
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorCtrl
  (JNIEnv* env, jobject this, jint ctrlval, jint channum, jint handleval)
{
	return BTI1553_ErrorCtrl(ctrlval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorDefine
 * Signature: (ICIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorDefine
  (JNIEnv* env, jobject this, jint defineval, jchar errvalue, jint countval, jint wordpos, jint bitpos, jint channum, jint handleval)
{
	return BTI1553_ErrorDefine(defineval, errvalue, countval, wordpos, bitpos, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorSent
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ErrorSent
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_ErrorSent(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTagBC
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTagBC
  (JNIEnv* env, jobject this, jboolean tagval, jint msgaddr, jint channum, jint handleval)
{
	return BTI1553_ErrorTagBC(tagval, msgaddr, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTagRT
 * Signature: (ZZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTagRT
  (JNIEnv* env, jobject this, jboolean tagval, jboolean mcflag, jint taval, jboolean trflag, jint saval, jint channum, jint handleval)
{
	return BTI1553_ErrorTagRT(tagval, mcflag, taval, trflag, saval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTriggerDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar trigmask, jchar trigval, jchar pinpolarity, jint channum, jint handleval)
{
	return BTI1553_ErrorTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListBlockRd
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListBlockRd
  (JNIEnv* env, jobject this, jobject msgfields, jint listaddr, jint handleval)
{
	MSGFIELDS1553 cmsgfields;
	ERRVAL errval;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;

	errval = BTI1553_ListBlockRd((LPUINT16) &cmsgfields, listaddr, handleval);

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgflag);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgopt);
	fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgerr);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgact);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.resptime1);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.resptime2);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.datacount);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.extflag);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetag);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.elapsetime);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.preaddr);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.postaddr);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetagh);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.resv18);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.resv19);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.cwd1);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.cwd2);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.swd1);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.swd2);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy(dataArrayPtr, cmsgfields.data, sizeof(cmsgfields.data));

	fid = (*env)->GetFieldID(env, cls, "extra", "[C");
	extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
	memcpy(extraArrayPtr, cmsgfields.extra, sizeof(cmsgfields.extra));

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
	(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListBlockWr
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListBlockWr
  (JNIEnv* env, jobject this, jobject msgfields, jint listaddr, jint handleval)
{
	MSGFIELDS1553 cmsgfields;
	ERRVAL errval;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
	cmsgfields.msgflag = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	cmsgfields.msgopt = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
	cmsgfields.msgerr = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	cmsgfields.msgact = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	cmsgfields.resptime1 = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	cmsgfields.resptime2 = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	cmsgfields.datacount = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	cmsgfields.extflag = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	cmsgfields.timetag = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
	cmsgfields.elapsetime = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	cmsgfields.preaddr = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	cmsgfields.postaddr = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	cmsgfields.timetagh = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	cmsgfields.resv18 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	cmsgfields.resv19 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	cmsgfields.cwd1 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	cmsgfields.cwd2 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	cmsgfields.swd1 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	cmsgfields.swd2 = (*env)->GetCharField(env, msgfields, fid);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy(cmsgfields.data, dataArrayPtr, sizeof(cmsgfields.data));

	fid = (*env)->GetFieldID(env, cls, "extra", "[C");
	extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
	memcpy(cmsgfields.extra, extraArrayPtr, sizeof(cmsgfields.extra));

	errval = BTI1553_ListBlockWr((LPUINT16) &cmsgfields, listaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
	(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListDataRd
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListDataRd
  (JNIEnv* env, jobject this, jcharArray buf, jint count, jint listaddr, jint handleval)
{
	ERRVAL errval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	errval = BTI1553_ListDataRd(bufPtr, count, listaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListDataWr
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListDataWr
  (JNIEnv* env, jobject this, jcharArray buf, jint count, jint listaddr, jint handleval)
{
	ERRVAL errval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	errval = BTI1553_ListDataWr(bufPtr, count, listaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListMultiBlockRd
 * Signature: ([Lballard/BTI1553/MSGFIELDS1553;Lballard/BTICard/IntRef;II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ListMultiBlockRd
  (JNIEnv* env, jobject this, jobjectArray msgfieldsarray, jobject blkcountptr, jint listaddr, jint handleval)
{
	MSGFIELDS1553* cmsgfields;
	INT cblkcount;
	jboolean retval;
	jclass cls;
	jfieldID fid;
	jmethodID methodID;
	jobject msgfields;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;
	INT j;

	cls = (*env)->GetObjectClass(env, blkcountptr);
    methodID = (*env)->GetMethodID(env, cls, "getValue", "(V)I");
    cblkcount = (*env)->CallIntMethod(env, blkcountptr, methodID);

	cmsgfields = (MSGFIELDS1553*) malloc(sizeof(MSGFIELDS1553) * cblkcount);

	retval = BTI1553_ListMultiBlockRd((LPUINT16) &cmsgfields, &cblkcount, listaddr, handleval) ? JNI_TRUE : JNI_FALSE;

	for (j = 0; j < cblkcount; j++)
	{
		msgfields = (*env)->GetObjectArrayElement(env,msgfieldsarray, j);

		fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].msgflag);
		fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].msgopt);
		fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].msgerr);
		fid = (*env)->GetFieldID(env, cls, "msgact", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].msgact);
		fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
		(*env)->SetIntField(env, msgfields, fid, cmsgfields[j].resptime1);
		fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
		(*env)->SetIntField(env, msgfields, fid, cmsgfields[j].resptime2);
		fid = (*env)->GetFieldID(env, cls, "datacount", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].datacount);
		fid = (*env)->GetFieldID(env, cls, "extflag", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].extflag);
		fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
		(*env)->SetLongField(env, msgfields, fid, cmsgfields[j].timetag);
		fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
		(*env)->SetLongField(env, msgfields, fid, cmsgfields[j].elapsetime);
		fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
		(*env)->SetIntField(env, msgfields, fid, cmsgfields[j].preaddr);
		fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
		(*env)->SetIntField(env, msgfields, fid, cmsgfields[j].postaddr);
		fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
		(*env)->SetLongField(env, msgfields, fid, cmsgfields[j].timetagh);
		fid = (*env)->GetFieldID(env, cls, "resv18", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].resv18);
		fid = (*env)->GetFieldID(env, cls, "resv19", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].resv19);
		fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].cwd1);
		fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].cwd2);
		fid = (*env)->GetFieldID(env, cls, "swd1", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].swd1);
		fid = (*env)->GetFieldID(env, cls, "swd2", "C");
		(*env)->SetCharField(env, msgfields, fid, cmsgfields[j].swd2);

		fid = (*env)->GetFieldID(env, cls, "data", "[C");
		dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
		dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
		memcpy(dataArrayPtr, cmsgfields[j].data, sizeof(cmsgfields[j].data));

		fid = (*env)->GetFieldID(env, cls, "extra", "[C");
		extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
		extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
		memcpy(extraArrayPtr, cmsgfields[j].extra, sizeof(cmsgfields[j].extra));

		(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
		(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);
	}

	cls = (*env)->GetObjectClass(env, blkcountptr);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, blkcountptr, methodID, (jint) cblkcount);

	free(cmsgfields);

	return retval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListMultiBlockWr
 * Signature: ([Lballard/BTI1553/MSGFIELDS1553;III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ListMultiBlockWr
  (JNIEnv* env, jobject this, jobjectArray msgfieldsarray, jint blkcount, jint listaddr, jint handleval)
{
	MSGFIELDS1553* cmsgfields;
	jboolean retval;
	jclass cls;
	jfieldID fid;
	jobject msgfields;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;
	INT j;

	cmsgfields = (MSGFIELDS1553*) malloc(sizeof(MSGFIELDS1553) * blkcount);

	for (j = 0; j < blkcount; j++)
	{
		msgfields = (*env)->GetObjectArrayElement(env,msgfieldsarray, j);

		cls = (*env)->GetObjectClass(env, msgfields);
		fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
		cmsgfields[j].msgflag = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
		cmsgfields[j].msgopt = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
		cmsgfields[j].msgerr = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "msgact", "C");
		cmsgfields[j].msgact = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
		cmsgfields[j].resptime1 = (*env)->GetIntField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
		cmsgfields[j].resptime2 = (*env)->GetIntField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "datacount", "C");
		cmsgfields[j].datacount = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "extflag", "C");
		cmsgfields[j].extflag = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
		cmsgfields[j].timetag = (*env)->GetLongField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
		cmsgfields[j].elapsetime = (*env)->GetLongField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
		cmsgfields[j].preaddr = (*env)->GetIntField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
		cmsgfields[j].postaddr = (*env)->GetIntField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
		cmsgfields[j].timetagh = (*env)->GetLongField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "resv18", "C");
		cmsgfields[j].resv18 = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "resv19", "C");
		cmsgfields[j].resv19 = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
		cmsgfields[j].cwd1 = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
		cmsgfields[j].cwd2 = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "swd1", "C");
		cmsgfields[j].swd1 = (*env)->GetCharField(env, msgfields, fid);
		fid = (*env)->GetFieldID(env, cls, "swd2", "C");
		cmsgfields[j].swd2 = (*env)->GetCharField(env, msgfields, fid);

		fid = (*env)->GetFieldID(env, cls, "data", "[C");
		dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
		dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
		memcpy(cmsgfields[j].data, dataArrayPtr, sizeof(cmsgfields[j].data));

		fid = (*env)->GetFieldID(env, cls, "extra", "[C");
		extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
		extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
		memcpy(cmsgfields[j].extra, extraArrayPtr, sizeof(cmsgfields[j].extra));

		(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
		(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);
	}

	retval = BTI1553_ListMultiBlockWr((LPUINT16) &cmsgfields, blkcount, listaddr, handleval) ? JNI_TRUE : JNI_FALSE;

	free(cmsgfields);

	return retval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonConfig
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonConfig
  (JNIEnv* env, jobject this, jint configval, jint channum, jint handleval)
{
	return BTI1553_MonConfig(configval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonFilterSA
 * Signature: (IIIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonFilterSA
  (JNIEnv* env, jobject this, jint taval, jint rcvsamask, jint xmtsamask, jint rcvmcmask, jint xmtmcmask, jint channum, jint handleval)
{
	return BTI1553_MonFilterSA(taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonFilterTA
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonFilterTA
  (JNIEnv* env, jobject this, jint tamask, jint channum, jint handleval)
{
	return BTI1553_MonFilterTA(tamask, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgBlockRd
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgBlockRd
  (JNIEnv* env, jobject this, jobject msgfields, jint msgaddr, jint handleval)
{
	MSGFIELDS1553 cmsgfields;
	ERRVAL errval;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;

	errval = BTI1553_MsgBlockRd(&cmsgfields, msgaddr, handleval);

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgflag);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgopt);
	fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgerr);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgact);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.resptime1);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.resptime2);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.datacount);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.extflag);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetag);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.elapsetime);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.preaddr);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.postaddr);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetagh);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.resv18);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.resv19);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.cwd1);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.cwd2);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.swd1);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.swd2);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy(dataArrayPtr, cmsgfields.data, sizeof(cmsgfields.data));

	fid = (*env)->GetFieldID(env, cls, "extra", "[C");
	extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
	memcpy(extraArrayPtr, cmsgfields.extra, sizeof(cmsgfields.extra));

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
	(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgBlockWr
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgBlockWr
  (JNIEnv* env, jobject this, jobject msgfields, jint msgaddr, jint handleval)
{
	MSGFIELDS1553 cmsgfields;
	jclass cls;
	jfieldID fid;
	jcharArray dataArray;
	jchar* dataArrayPtr;
	jcharArray extraArray;
	jchar* extraArrayPtr;
	ERRVAL errval;

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgflag", "C");
	cmsgfields.msgflag = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	cmsgfields.msgopt = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgerr", "C");
	cmsgfields.msgerr = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	cmsgfields.msgact = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime1", "I");
	cmsgfields.resptime1 = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resptime2", "I");
	cmsgfields.resptime2 = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "datacount", "C");
	cmsgfields.datacount = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "extflag", "C");
	cmsgfields.extflag = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	cmsgfields.timetag = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_mintime_maxtime", "J");
	cmsgfields.elapsetime = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "preaddr", "I");
	cmsgfields.preaddr = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "postaddr", "I");
	cmsgfields.postaddr = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	cmsgfields.timetagh = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv18", "C");
	cmsgfields.resv18 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "resv19", "C");
	cmsgfields.resv19 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd1", "C");
	cmsgfields.cwd1 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "cwd2", "C");
	cmsgfields.cwd2 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd1", "C");
	cmsgfields.swd1 = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "swd2", "C");
	cmsgfields.swd2 = (*env)->GetCharField(env, msgfields, fid);

	fid = (*env)->GetFieldID(env, cls, "data", "[C");
	dataArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	dataArrayPtr = (*env)->GetCharArrayElements(env, dataArray, 0);
	memcpy(cmsgfields.data, dataArrayPtr, sizeof(cmsgfields.data));

	fid = (*env)->GetFieldID(env, cls, "extra", "[C");
	extraArray = (jcharArray) (*env)->GetObjectField(env, msgfields, fid);
	extraArrayPtr = (*env)->GetCharArrayElements(env, extraArray, 0);
	memcpy(cmsgfields.extra, extraArrayPtr, sizeof(cmsgfields.extra));

	errval = BTI1553_MsgBlockWr(&cmsgfields, msgaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, dataArray, dataArrayPtr, 0);
	(*env)->ReleaseCharArrayElements(env, extraArray, extraArrayPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgDataRd
 * Signature: ([CIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgDataRd
  (JNIEnv* env, jobject this, jcharArray buf, jint count, jint msgaddr, jint handleval)
{
	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	BTI1553_MsgDataRd(bufPtr, count, msgaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgDataWr
 * Signature: ([CIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgDataWr
  (JNIEnv* env, jobject this, jcharArray buf, jint count, jint msgaddr, jint handleval)
{
	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	BTI1553_MsgDataWr(bufPtr, count, msgaddr, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgFieldRd
 * Signature: (CII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_MsgFieldRd
  (JNIEnv* env, jobject this, jchar fieldtype, jint msgaddr, jint handleval)
{
	return BTI1553_MsgFieldRd(fieldtype, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgFieldWr
 * Signature: (JCII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_MsgFieldWr
  (JNIEnv* env, jobject this, jlong fieldval, jchar fieldtype, jint msgaddr, jint handleval)
{
	return BTI1553_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSkipRd
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_MsgSkipRd
  (JNIEnv* env, jobject this, jint msgaddr, jint handleval)
{
	return BTI1553_MsgSkipRd(msgaddr, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSkipWr
 * Signature: (ZII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgSkipWr
  (JNIEnv* env, jobject this, jboolean skip, jint msgaddr, jint handleval)
{
	BTI1553_MsgSkipWr(skip, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSyncDefine
 * Signature: (ZCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgSyncDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar syncmask, jchar pinpolarity, jint msgaddr, jint handleval)
{
	return BTI1553_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgTriggerDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar trigmask, jchar trigval, jchar pinpolarity, jint msgaddr, jint handleval)
{
	return BTI1553_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ParamAmplitudeConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ParamAmplitudeConfig
  (JNIEnv* env, jobject this, jint configval, jint dacval, jint channum, jint handleval)
{
	return BTI1553_ParamAmplitudeConfig(configval, dacval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ParamAmplitudeGet
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ParamAmplitudeGet
  (JNIEnv* env, jobject this, jobject dacval, jint channum, jint handleval)
{
	jclass cls;
	jmethodID methodID;
	UINT16 cdacval;
	ERRVAL errval;

	errval = BTI1553_ParamAmplitudeGet(&cdacval, channum, handleval);

	cls = (*env)->GetObjectClass(env, dacval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, dacval, methodID, (jint) cdacval);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayConfig
  (JNIEnv* env, jobject this, jint configval, jint tamask, jint channum, jint handleval)
{
	return BTI1553_PlayConfig(configval, tamask, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayStatus
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayStatus
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI1553_PlayStatus(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayWr
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayWr
  (JNIEnv* env, jobject this, jcharArray buf, jint bufcount, jint channum, jint handleval)
{
	ERRVAL errval;

	jchar* bufPtr = (*env)->GetCharArrayElements(env, buf, 0);

	errval =  BTI1553_PlayWr(bufPtr, bufcount, channum, handleval);

	(*env)->ReleaseCharArrayElements(env, buf, bufPtr, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTConfig
  (JNIEnv* env, jobject this, jint configval, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTConfig(configval, taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTCreateList
 * Signature: (IIIZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTCreateList
  (JNIEnv* env, jobject this, jint listconfigval, jint count, jint msgconfigval, jboolean mcflag, jint taval, jboolean trflag, jint saval, jint channum, jint handleval)
{
	return BTI1553_RTCreateList(listconfigval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTCreateMsg
 * Signature: (IZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTCreateMsg
  (JNIEnv* env, jobject this, jint configval, jboolean mcflag, jint taval, jboolean trflag, jint saval, jint channum, jint handleval)
{
	return BTI1553_RTCreateMsg(configval, mcflag, taval, trflag, saval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTGetMsg
 * Signature: (ZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTGetMsg
  (JNIEnv* env, jobject this, jboolean mcflag, jint taval, jboolean trflag, jint saval, jint channum, jint handleval)
{
	return BTI1553_RTGetMsg(mcflag, taval, trflag, saval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTReset
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTReset
  (JNIEnv* env, jobject this, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTReset(taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTResponseTimeSet
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTResponseTimeSet
  (JNIEnv* env, jobject this, jint resptime, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTResponseTimeSet(resptime, taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSetMode
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSetMode
  (JNIEnv* env, jobject this, jint configval, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTSetMode(configval, taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSWDRd
 * Signature: (III)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTI1553_RTSWDRd
  (JNIEnv* env, jobject this, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTSWDRd(taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSWDWr
 * Signature: (CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSWDWr
  (JNIEnv* env, jobject this, jchar swdval, jint taval, jint channum, jint handleval)
{
	return BTI1553_RTSWDWr(swdval, taval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSyncDefine
 * Signature: (ZCCIIIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSyncDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar syncmask, jchar pinpolarity, jint taval, jint rcvsamask, jint xmtsamask, jint rcvmcmask, jint xmtmcmask, jint channum, jint handleval)
{
	return BTI1553_RTSyncDefine(enableflag, syncmask, pinpolarity, taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ValPackCWD
 * Signature: (IIII)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTI1553_ValPackCWD
  (JNIEnv* env, jobject this, jint TAval, jint TRflag, jint SAval, jint WCval)
{
	return BTI1553_ValPackCWD(TAval, TRflag, SAval, WCval);
}

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ValUnpackCWD
 * Signature: (CLballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_ValUnpackCWD
  (JNIEnv* env, jobject this, jchar CWDval, jobject TAval, jobject TRflag, jobject SAval, jobject WCval)
{
	INT cTAval, cTRflag, cSAval, cWCval;
	jclass cls;
	jmethodID methodID;

	BTI1553_ValUnpackCWD(CWDval, &cTAval, &cTRflag, &cSAval, &cWCval);

	cls = (*env)->GetObjectClass(env, TAval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, TAval, methodID, (jint) cTAval);

	cls = (*env)->GetObjectClass(env, TRflag);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, TRflag, methodID, (jint) cTRflag);

	cls = (*env)->GetObjectClass(env, SAval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, SAval, methodID, (jint) cSAval);

	cls = (*env)->GetObjectClass(env, WCval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, WCval, methodID, (jint) cWCval);
}
