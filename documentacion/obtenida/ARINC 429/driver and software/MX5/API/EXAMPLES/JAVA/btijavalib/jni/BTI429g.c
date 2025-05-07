#ifdef _WIN32
#include <bti429.h>
#else
#include "../bti429/bti429.h"
#endif

#include "BTI429g.h"

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
 * Class:     com_ballardtech_BTI429
 * Method:    BCDGetData
 * Signature: (JSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDGetData
  (JNIEnv* env, jobject this, jlong msg, jshort msb, jshort lsb)
{
	return BTI429_BCDGetData(msg, msb, lsb);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDGetMant
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDGetMant
  (JNIEnv* env, jobject this, jlong msg, jshort sigdig)
{
	return BTI429_BCDGetMant(msg, sigdig);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDGetSign
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_BCDGetSign
  (JNIEnv* env, jobject this, jlong msg)
{
	return BTI429_BCDGetSign(msg);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDGetSSM
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_BCDGetSSM
  (JNIEnv* env, jobject this, jlong msg)
{
	return BTI429_BCDGetSSM(msg);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDGetVal
 * Signature: (Lballard/BTICard/StringRef;JSLjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_BCDGetVal
  (JNIEnv* env, jobject this, jobject buf, jlong msg, jshort sigdig, jstring resolstr)
{
	char cbuf[250];
	jclass cls;
	jmethodID methodID;
	jstring objstr;

	const char *cresolstr = (*env)->GetStringUTFChars(env, resolstr, 0);

	BTI429_BCDGetVal(cbuf, msg, sigdig, cresolstr);

	objstr = (*env)->NewStringUTF(env, cbuf);
	cls = (*env)->GetObjectClass(env, buf);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(Ljava/lang/String;)V");
	(*env)->CallVoidMethod(env, buf, methodID, objstr);

	(*env)->DeleteLocalRef(env, objstr);
	(*env)->ReleaseStringUTFChars(env, resolstr, cresolstr);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDPutData
 * Signature: (JJSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDPutData
  (JNIEnv* env, jobject this, jlong msg, jlong value, jshort msb, jshort lsb)
{
	return BTI429_BCDPutData(msg, value, msb, lsb);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDPutMant
 * Signature: (JJSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDPutMant
  (JNIEnv* env, jobject this, jlong msg, jlong value, jshort sigdig, jshort sign)
{
	return BTI429_BCDPutMant(msg, value, sigdig, sign);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDPutSign
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDPutSign
  (JNIEnv* env, jobject this, jlong msg, jshort sign)
{
	return BTI429_BCDPutSign(msg, sign);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDPutSSM
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDPutSSM
  (JNIEnv* env, jobject this, jlong msg, jshort value)
{
	return BTI429_BCDPutSSM(msg, value);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BCDPutVal
 * Signature: (Ljava/lang/String;JSLjava/lang/String;)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BCDPutVal
  (JNIEnv* env, jobject this, jstring buf, jlong msg, jshort sigdig, jstring resolstr)
{
	const char *cbuf = (*env)->GetStringUTFChars(env, buf, 0);
	const char *cresolstr = (*env)->GetStringUTFChars(env, resolstr, 0);
	UINT32 retval;

	retval = BTI429_BCDPutVal(cbuf, msg, sigdig, cresolstr);

	(*env)->ReleaseStringUTFChars(env, buf, cbuf);
	(*env)->ReleaseStringUTFChars(env, resolstr, cresolstr);

	return retval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRGetData
 * Signature: (JSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRGetData
  (JNIEnv* env, jobject this, jlong msg, jshort msb, jshort lsb)
{
	return BTI429_BNRGetData(msg, msb, lsb);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRGetMant
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRGetMant
  (JNIEnv* env, jobject this, jlong msg, jshort sigbit)
{
	return BTI429_BNRGetMant(msg, sigbit);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRGetSign
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_BNRGetSign
  (JNIEnv* env, jobject this, jlong msg)
{
	return BTI429_BNRGetSign(msg);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRGetSSM
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_BNRGetSSM
  (JNIEnv* env, jobject this, jlong msg)
{
	return BTI429_BNRGetSSM(msg);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRGetVal
 * Signature: (Lballard/BTICard/StringRef;JSLjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_BNRGetVal
  (JNIEnv* env, jobject this, jobject buf, jlong msg, jshort sigbit, jstring resolstr)
{
	char cbuf[250];
	jclass cls;
	jmethodID methodID;
	jstring objstr;

	const char *cresolstr = (*env)->GetStringUTFChars(env, resolstr, 0);

	BTI429_BCDGetVal(cbuf, msg, sigbit, cresolstr);

	objstr = (*env)->NewStringUTF(env, cbuf);
	cls = (*env)->GetObjectClass(env, buf);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(Ljava/lang/String;)V");
	(*env)->CallVoidMethod(env, buf, methodID, objstr);

	(*env)->DeleteLocalRef(env, objstr);
	(*env)->ReleaseStringUTFChars(env, resolstr, cresolstr);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRPutData
 * Signature: (JJSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRPutData
  (JNIEnv* env, jobject this, jlong msg, jlong value, jshort msb, jshort lsb)
{
	return BTI429_BNRPutData(msg, value, msb, lsb);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRPutMant
 * Signature: (JJSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRPutMant
  (JNIEnv* env, jobject this, jlong msg, jlong value, jshort sigbit, jshort twos)
{
	return BTI429_BNRPutMant(msg, value, sigbit, twos);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRPutSign
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRPutSign
  (JNIEnv* env, jobject this, jlong msg, jshort twos)
{
	return BTI429_BNRPutSign(msg, twos);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRPutSSM
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRPutSSM
  (JNIEnv* env, jobject this, jlong msg, jshort value)
{
	return BTI429_BNRPutSSM(msg, value);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    BNRPutVal
 * Signature: (Ljava/lang/String;JSLjava/lang/String;)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_BNRPutVal
  (JNIEnv* env, jobject this, jstring buf, jlong msg, jshort sigbit, jstring resolstr)
{
	const char *cbuf = (*env)->GetStringUTFChars(env, buf, 0);
	const char *cresolstr = (*env)->GetStringUTFChars(env, resolstr, 0);
	UINT32 retval;

	retval = BTI429_BNRPutVal(cbuf, msg, sigbit, cresolstr);

	(*env)->ReleaseStringUTFChars(env, buf, cbuf);
	(*env)->ReleaseStringUTFChars(env, resolstr, cresolstr);

	return retval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChClear
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ChClear
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChClear(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChConfig
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ChConfig
  (JNIEnv* env, jobject this, jint configval, jint channum, jint handleval)
{
	return BTI429_ChConfig(configval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChGetCount
 * Signature: (Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_ChGetCount
  (JNIEnv* env, jobject this, jobject rcvcount, jobject xmtcount, jint handleval)
{
	INT crcvcount, cxmtcount;
	jclass cls;
	jmethodID methodID;

	BTI429_ChGetCount(&crcvcount, &cxmtcount, handleval);

	cls = (*env)->GetObjectClass(env, rcvcount);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, rcvcount, methodID, (jint) crcvcount);

	cls = (*env)->GetObjectClass(env, xmtcount);
	methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
    (*env)->CallVoidMethod(env, xmtcount, methodID, (jint) cxmtcount);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChGetInfo
 * Signature: (SII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_ChGetInfo
  (JNIEnv* env, jobject this, jshort infotype, jint channum, jint handleval)
{
	return BTI429_ChGetInfo(infotype, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChIs429
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ChIs429
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChIs429(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChIsRcv
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ChIsRcv
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChIsRcv(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChIsXmt
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ChIsXmt
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChIsXmt(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChPause
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_ChPause
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	BTI429_ChPause(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChPauseCheck
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ChPauseCheck
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChPauseCheck(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChResume
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_ChResume
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	BTI429_ChResume(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChStart
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ChStart
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChStart(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChStop
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ChStop
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_ChStop(channum, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChSyncDefine
 * Signature: (ZSSII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ChSyncDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jshort syncmask, jshort pinpolarity, jint channum, jint handleval)
{
	return BTI429_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ChTriggerDefine
 * Signature: (ZSSSII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ChTriggerDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jshort trigmask, jshort trigval, jshort pinpolarity, jint channum, jint handleval)
{
	return BTI429_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    CmdAddr
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_CmdAddr
  (JNIEnv * env, jobject this, jint index, jint channum, jint handleval)
{
	return BTI429_CmdAddr(index, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    CmdCountRd
 * Signature: (II)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_CmdCountRd
  (JNIEnv * env, jobject this, jint channum, jint handleval)
{
	return BTI429_CmdCountRd(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    CmdRd
 * Signature: ([CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_CmdRd
  (JNIEnv * env, jobject this, jcharArray block, jint addrval, jint handleval)
{
	ERRVAL errval;

	jchar* cblock = (*env)->GetCharArrayElements(env, block, 0);

	errval = BTI429_CmdRd(cblock, addrval, handleval);

	(*env)->ReleaseCharArrayElements(env, block, cblock, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FilterClear
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_FilterClear
  (JNIEnv* env, jobject this, jint baseaddr, jint handleval)
{
	return BTI429_FilterClear(baseaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FilterDefault
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_FilterDefault
  (JNIEnv* env, jobject this, jint configval, jint channum, jint handleval)
{
	return BTI429_FilterDefault(configval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FilterRd
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_FilterRd
  (JNIEnv* env, jobject this, jint labelval, jint sdival, jint channum, jint handleval)
{
	return BTI429_FilterRd(labelval, sdival, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FilterSet
 * Signature: (IISII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_FilterSet
  (JNIEnv* env, jobject this, jint configval, jint labelval, jshort sdimask, jint channum, jint handleval)
{
	return BTI429_FilterSet(configval, labelval, sdimask, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FilterWr
 * Signature: (IIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_FilterWr
  (JNIEnv* env, jobject this, jint msgaddr, jint labelval, jint sdival, jint channum, jint handleval)
{
	return BTI429_FilterWr(msgaddr, labelval, sdival, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldGetData
 * Signature: (J)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldGetData
  (JNIEnv* env, jobject this, jlong msgval)
{
	return BTI429_FldGetData(msgval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldGetLabel
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_FldGetLabel
  (JNIEnv* env, jobject this, jlong msgval)
{
	return BTI429_FldGetLabel(msgval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldGetParity
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_FldGetParity
  (JNIEnv* env, jobject this, jlong msgval)
{
	return BTI429_FldGetParity(msgval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldGetSDI
 * Signature: (J)S
 */
JNIEXPORT jshort JNICALL Java_com_ballardtech_BTI429_FldGetSDI
  (JNIEnv* env, jobject this, jlong msgval)
{
	return BTI429_FldGetSDI(msgval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldGetValue
 * Signature: (JSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldGetValue
  (JNIEnv* env, jobject this, jlong msgval, jshort startbit, jshort endbit)
{
	return BTI429_FldGetValue(msgval, startbit, endbit);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldPutData
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldPutData
  (JNIEnv* env, jobject this, jlong msgval, jlong data)
{
	return BTI429_FldPutData(msgval, data);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldPutLabel
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldPutLabel
  (JNIEnv* env, jobject this, jlong msgval, jshort label)
{
	return BTI429_FldPutLabel(msgval, label);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldPutSDI
 * Signature: (JS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldPutSDI
  (JNIEnv* env, jobject this, jlong msgval, jshort sdi)
{
	return BTI429_FldPutSDI(msgval, sdi);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    FldPutValue
 * Signature: (JJSS)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_FldPutValue
  (JNIEnv* env, jobject this, jlong msgval, jlong dataval, jshort startbit, jshort endbit)
{
	return BTI429_FldPutValue(msgval, dataval, startbit, endbit);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListAsyncCreate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ListAsyncCreate
  (JNIEnv* env, jobject this, jint listconfigval, jint count, jint channum, jint handleval)
{
	return BTI429_ListAsyncCreate(listconfigval, count, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListDataRd
 * Signature: (II)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_ListDataRd
  (JNIEnv* env, jobject this, jint listaddr, jint handleval)
{
	return BTI429_ListDataRd(listaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListDataWr
 * Signature: (JII)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_ListDataWr
  (JNIEnv* env, jobject this, jlong value, jint listaddr, jint handleval)
{
	return BTI429_ListDataWr(value, listaddr, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListRcvCreate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ListRcvCreate
  (JNIEnv* env, jobject this, jint listconfigval, jint count, jint msgaddr, jint handleval)
{
	return BTI429_ListRcvCreate(listconfigval, count, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListStatus
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ListStatus
  (JNIEnv* env, jobject this, jint listaddr, jint handleval)
{
	return BTI429_ListStatus(listaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ListXmtCreate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ListXmtCreate
  (JNIEnv* env, jobject this, jint listconfigval, jint count, jint msgaddr, jint handleval)
{
	return BTI429_ListXmtCreate(listconfigval, count, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgBlockRd
 * Signature: (Lballard/BTI429/MSGFIELDS429;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_MsgBlockRd
  (JNIEnv* env, jobject this, jobject msgfields, jint msgaddr, jint handleval)
{
	MSGFIELDS429 cmsgfields;
	ERRVAL errval;
	jclass cls;
	jfieldID fid;

	errval = BTI429_MsgBlockRd(&cmsgfields, msgaddr, handleval);

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgopt);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.msgact);
	fid = (*env)->GetFieldID(env, cls, "msgdata_listptr", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.msgdata);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetag);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_maxtime", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.elapsetime);
	fid = (*env)->GetFieldID(env, cls, "mintime", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.mintime);
	fid = (*env)->GetFieldID(env, cls, "userptr", "I");
	(*env)->SetIntField(env, msgfields, fid, cmsgfields.userptr);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	(*env)->SetLongField(env, msgfields, fid, cmsgfields.timetagh);
	fid = (*env)->GetFieldID(env, cls, "decgap", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.decgap);
	fid = (*env)->GetFieldID(env, cls, "rsvd", "C");
	(*env)->SetCharField(env, msgfields, fid, cmsgfields.rsvd);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgBlockWr
 * Signature: (Lballard/BTI429/MSGFIELDS429;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_MsgBlockWr
  (JNIEnv* env, jobject this, jobject msgfields, jint msgaddr, jint handleval)
{
	MSGFIELDS429 cmsgfields;
	jclass cls;
	jfieldID fid;

	cls = (*env)->GetObjectClass(env, msgfields);
	fid = (*env)->GetFieldID(env, cls, "msgopt", "C");
	cmsgfields.msgopt = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgact", "C");
	cmsgfields.msgact = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "msgdata_listptr", "J");
	cmsgfields.msgdata = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetag_hitcount", "J");
	cmsgfields.timetag = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "elapsetime_maxtime", "J");
	cmsgfields.elapsetime = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "mintime", "J");
	cmsgfields.mintime = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "userptr", "I");
	cmsgfields.userptr = (*env)->GetIntField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "timetagh", "J");
	cmsgfields.timetagh = (*env)->GetLongField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "decgap", "C");
	cmsgfields.decgap = (*env)->GetCharField(env, msgfields, fid);
	fid = (*env)->GetFieldID(env, cls, "rsvd", "C");
	cmsgfields.rsvd = (*env)->GetCharField(env, msgfields, fid);


	return BTI429_MsgBlockWr(&cmsgfields, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgCreate
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_MsgCreate
  (JNIEnv* env, jobject this, jint configval, jint handleval)
{
	return BTI429_MsgCreate(configval, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgDataRd
 * Signature: (II)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI429_MsgDataRd
  (JNIEnv* env, jobject this, jint msgaddr, jint handleval)
{
	return BTI429_MsgDataRd(msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgDataWr
 * Signature: (JII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_MsgDataWr
  (JNIEnv* env, jobject this, jlong value, jint msgaddr, jint handleval)
{
	BTI429_MsgDataWr(value, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgGroupRd
 * Signature: ([I[III)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_MsgGroupRd
  (JNIEnv* env, jobject this, jintArray msgdataptr, jintArray msgaddrptr, jint nummsgs, jint handleval)
{
	jint* cmsgdataptr = (*env)->GetIntArrayElements(env, msgdataptr, 0);
	jint* cmsgaddrptr = (*env)->GetIntArrayElements(env, msgaddrptr, 0);

	BTI429_MsgGroupRd(cmsgdataptr, cmsgaddrptr, nummsgs, handleval);

	(*env)->ReleaseIntArrayElements(env, msgdataptr, cmsgdataptr, 0);
	(*env)->ReleaseIntArrayElements(env, msgaddrptr, cmsgaddrptr, 0);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgGroupWr
 * Signature: ([I[III)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_MsgGroupWr
  (JNIEnv* env, jobject this, jintArray msgdataptr, jintArray msgaddrptr, jint nummsgs, jint handleval)
{
	jint* cmsgdataptr = (*env)->GetIntArrayElements(env, msgdataptr, 0);
	jint* cmsgaddrptr = (*env)->GetIntArrayElements(env, msgaddrptr, 0);

	BTI429_MsgGroupWr(cmsgdataptr, cmsgaddrptr, nummsgs, handleval);

	(*env)->ReleaseIntArrayElements(env, msgdataptr, cmsgdataptr, 0);
	(*env)->ReleaseIntArrayElements(env, msgaddrptr, cmsgaddrptr, 0);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgIsAccessed
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_MsgIsAccessed
  (JNIEnv* env, jobject this, jint msgaddr, jint handleval)
{
	return BTI429_MsgIsAccessed(msgaddr, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgSkipRd
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI429_MsgSkipRd
  (JNIEnv* env, jobject this, jint msgaddr, jint handleval)
{
	return BTI429_MsgSkipRd(msgaddr, handleval) ? JNI_TRUE : JNI_FALSE;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgSkipWr
 * Signature: (ZII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI429_MsgSkipWr
  (JNIEnv* env, jobject this, jboolean skip, jint msgaddr, jint handleval)
{
	BTI429_MsgSkipWr(skip, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgSyncDefine
 * Signature: (ZCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_MsgSyncDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar syncmask, jchar pinpolarity, jint msgaddr, jint handleval)
{
	return BTI429_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    MsgTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_MsgTriggerDefine
  (JNIEnv* env, jobject this, jboolean enableflag, jchar trigmask, jchar trigval, jchar pinpolarity, jint msgaddr, jint handleval)
{
	return BTI429_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ParamAmplitudeConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ParamAmplitudeConfig
  (JNIEnv* env, jobject this, jint configval, jint dacval, jint channum, jint handleval)
{
	return BTI429_ParamAmplitudeConfig(configval, dacval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ParamAmplitudeGet
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ParamAmplitudeGet
  (JNIEnv* env, jobject this, jobject dacval, jint channum, jint handleval)
{
	jclass cls;
	jmethodID methodID;
	UINT16 cdacval;
	ERRVAL errval;

	errval = BTI429_ParamAmplitudeGet(&cdacval, channum, handleval);

	cls = (*env)->GetObjectClass(env, dacval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, dacval, methodID, (jint) cdacval);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ParamBitRateConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ParamBitRateConfig
  (JNIEnv* env, jobject this, jint configval, jint divval, jint channum, jint handleval)
{
	return BTI429_ParamBitRateConfig(configval, divval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    ParamBitRateGet
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_ParamBitRateGet
  (JNIEnv* env, jobject this, jobject divval, jint channum, jint handleval)
{
	jclass cls;
	jmethodID methodID;
	UINT16 cdivval;
	ERRVAL errval;

	errval = BTI429_ParamBitRateGet(&cdivval, channum, handleval);

	cls = (*env)->GetObjectClass(env, divval);
	 methodID = (*env)->GetMethodID(env, cls, "setValue", "(I)V");
	(*env)->CallVoidMethod(env, divval, methodID, (jint) cdivval);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedBranch
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedBranch
  (JNIEnv* env, jobject this, jint condition, jint destindex, jint channum, jint handleval)
{
	return BTI429_SchedBranch(condition, destindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedBranchUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedBranchUpdate
  (JNIEnv* env, jobject this, jint destindex, jint opcodeindex, jint channum, jint handleval)
{
	return BTI429_SchedBranchUpdate(destindex, opcodeindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedBuild
 * Signature: (I[I[I[III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedBuild
  (JNIEnv* env, jobject this, jint nummsgs, jintArray msgaddr, jintArray minperiod, jintArray maxperiod, jint channum, jint handleval)
{
	ERRVAL errval;

	jint* cmsgaddr = (*env)->GetIntArrayElements(env, msgaddr, 0);
	jint* cminperiod = (*env)->GetIntArrayElements(env, minperiod, 0);
	jint* cmaxperiod = (*env)->GetIntArrayElements(env, maxperiod, 0);

	errval = BTI429_SchedBuild(nummsgs, cmsgaddr, cminperiod, cmaxperiod, channum, handleval);

	(*env)->ReleaseIntArrayElements(env, msgaddr, cmsgaddr, 0);
	(*env)->ReleaseIntArrayElements(env, minperiod, cminperiod, 0);
	(*env)->ReleaseIntArrayElements(env, maxperiod, cmaxperiod, 0);

	return errval;
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedCall
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedCall
  (JNIEnv* env, jobject this, jint condition, jint destindex, jint channum, jint handleval)
{
	return BTI429_SchedCall(condition, destindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedCallUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedCallUpdate
  (JNIEnv* env, jobject this, jint destindex, jint opcodeindex, jint channum, jint handleval)
{
	return BTI429_SchedCallUpdate(destindex, opcodeindex, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedMode
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedMode
  (JNIEnv* env, jobject this, jint modeval)
{
	return BTI429_SchedMode(modeval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedEntry
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedEntry
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_SchedEntry(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedGap
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedGap
  (JNIEnv* env, jobject this, jint gapval, jint channum, jint handleval)
{
	return BTI429_SchedGap(gapval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedGapFixed
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedGapFixed
  (JNIEnv* env, jobject this, jint gapval, jint channum, jint handleval)
{
	return BTI429_SchedGapFixed(gapval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedGapList
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedGapList
  (JNIEnv* env, jobject this, jint gapval, jint listaddr, jint channum, jint handleval)
{
	return BTI429_SchedGapList(gapval, listaddr, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedHalt
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedHalt
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_SchedHalt(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedLog
 * Signature: (ICII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedLog
  (JNIEnv* env, jobject this, jint condition, jchar tagval, jint channum, jint handleval)
{
	return BTI429_SchedLog(condition, tagval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedMsg
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedMsg
  (JNIEnv* env, jobject this, jint msgaddr, jint channum, jint handleval)
{
	return BTI429_SchedMsg(msgaddr, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedMsgEx
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedMsgEx
  (JNIEnv* env, jobject this, jint msgaddr, jint gapval, jint channum, jint handleval)
{
	return BTI429_SchedMsgEx(msgaddr, gapval, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedPause
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedPause
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_SchedPause(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedPulse
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedPulse
  (JNIEnv* env, jobject this, jint dionum, jint channum, jint handleval)
{
	return BTI429_SchedPulse(dionum, channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedRestart
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedRestart
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_SchedRestart(channum, handleval);
}

/*
 * Class:     com_ballardtech_BTI429
 * Method:    SchedReturn
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI429_SchedReturn
  (JNIEnv* env, jobject this, jint channum, jint handleval)
{
	return BTI429_SchedReturn(channum, handleval);
}
