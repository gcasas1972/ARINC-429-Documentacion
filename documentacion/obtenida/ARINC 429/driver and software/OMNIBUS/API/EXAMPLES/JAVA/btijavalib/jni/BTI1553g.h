/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class com_ballardtech_BTI1553 */

#ifndef _Included_com_ballardtech_BTI1553
#define _Included_com_ballardtech_BTI1553
#ifdef __cplusplus
extern "C" {
#endif

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfig
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfig
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfigEx
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfigEx
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCConfigMsg
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCConfigMsg
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCCreateList
 * Signature: (IIICC[CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCCreateList
  (JNIEnv *, jobject, jint, jint, jint, jchar, jchar, jcharArray, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCCreateMsg
 * Signature: (ICC[CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCCreateMsg
  (JNIEnv *, jobject, jint, jchar, jchar, jcharArray, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCPause
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BCPause
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCPauseCheck
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCPauseCheck
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCResume
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BCResume
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedAgain
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedAgain
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBranch
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBranch
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBranchUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBranchUpdate
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedBuild
 * Signature: (I[I[CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedBuild
  (JNIEnv *, jobject, jint, jintArray, jcharArray, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedCall
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedCall
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedCallUpdate
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedCallUpdate
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedEntry
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedEntry
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrame
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrame
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrameEnd
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrameEnd
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedFrameStart
 * Signature: (JII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedFrameStart
  (JNIEnv *, jobject, jlong, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedGap
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedGap
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedHalt
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedHalt
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedLog
 * Signature: (ICII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedLog
  (JNIEnv *, jobject, jint, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedMsg
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedMsg
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPause
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPause
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse0
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse0
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedPulse1
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedPulse1
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedRestart
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedRestart
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedRetry
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedRetry
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSchedReturn
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSchedReturn
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSetDefaultGap
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSetDefaultGap
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSetTimeout
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSetTimeout
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCSyncDefine
 * Signature: (ZCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCSyncDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCTransmitMsg
 * Signature: (Lballard/BTI1553/XMITFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCTransmitMsg
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BCTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BCTriggerDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BlkPtrRd
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_BlkPtrRd
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    BlkPtrWr
 * Signature: (IIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_BlkPtrWr
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChGetCount
 * Signature: (Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_ChGetCount
  (JNIEnv *, jobject, jobject, jobject, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChGetInfo
 * Signature: (CII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_ChGetInfo
  (JNIEnv *, jobject, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIs1553
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIs1553
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsA
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsA
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsB32
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsB32
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsB4
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsB4
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsBM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsBM
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsC
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsC
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsD
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsD
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsM
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsRM
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsRM
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsS
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsS
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChIsX
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChIsX
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChStart
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChStart
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ChStop
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ChStop
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdMaxLoopRd
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdMaxLoopRd
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdMaxLoopWr
 * Signature: (III)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_CmdMaxLoopWr
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdShotRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdShotRd
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdShotWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdShotWr
  (JNIEnv *, jobject, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdSkipRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdSkipRd
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdSkipWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdSkipWr
  (JNIEnv *, jobject, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdStepRd
 * Signature: (III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_CmdStepRd
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    CmdStepWr
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_CmdStepWr
  (JNIEnv *, jobject, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorCtrl
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorCtrl
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorDefine
 * Signature: (ICIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorDefine
  (JNIEnv *, jobject, jint, jchar, jint, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorSent
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ErrorSent
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTagBC
 * Signature: (ZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTagBC
  (JNIEnv *, jobject, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTagRT
 * Signature: (ZZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTagRT
  (JNIEnv *, jobject, jboolean, jboolean, jint, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ErrorTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ErrorTriggerDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListBlockRd
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListBlockRd
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListBlockWr
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListBlockWr
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListDataRd
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListDataRd
  (JNIEnv *, jobject, jcharArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListDataWr
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ListDataWr
  (JNIEnv *, jobject, jcharArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListMultiBlockRd
 * Signature: ([Lballard/BTI1553/MSGFIELDS1553;Lballard/BTICard/IntRef;II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ListMultiBlockRd
  (JNIEnv *, jobject, jobjectArray, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ListMultiBlockWr
 * Signature: ([Lballard/BTI1553/MSGFIELDS1553;III)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_ListMultiBlockWr
  (JNIEnv *, jobject, jobjectArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonConfig
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonConfig
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonFilterSA
 * Signature: (IIIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonFilterSA
  (JNIEnv *, jobject, jint, jint, jint, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MonFilterTA
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MonFilterTA
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgBlockRd
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgBlockRd
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgBlockWr
 * Signature: (Lballard/BTI1553/MSGFIELDS1553;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgBlockWr
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgDataRd
 * Signature: ([CIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgDataRd
  (JNIEnv *, jobject, jcharArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgDataWr
 * Signature: ([CIII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgDataWr
  (JNIEnv *, jobject, jcharArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgFieldRd
 * Signature: (CII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_MsgFieldRd
  (JNIEnv *, jobject, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgFieldWr
 * Signature: (JCII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTI1553_MsgFieldWr
  (JNIEnv *, jobject, jlong, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSkipRd
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTI1553_MsgSkipRd
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSkipWr
 * Signature: (ZII)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_MsgSkipWr
  (JNIEnv *, jobject, jboolean, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgSyncDefine
 * Signature: (ZCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgSyncDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    MsgTriggerDefine
 * Signature: (ZCCCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_MsgTriggerDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ParamAmplitudeConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ParamAmplitudeConfig
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ParamAmplitudeGet
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_ParamAmplitudeGet
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayConfig
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayStatus
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayStatus
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    PlayWr
 * Signature: ([CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_PlayWr
  (JNIEnv *, jobject, jcharArray, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTConfig
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTConfig
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTCreateList
 * Signature: (IIIZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTCreateList
  (JNIEnv *, jobject, jint, jint, jint, jboolean, jint, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTCreateMsg
 * Signature: (IZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTCreateMsg
  (JNIEnv *, jobject, jint, jboolean, jint, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTGetMsg
 * Signature: (ZIZIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTGetMsg
  (JNIEnv *, jobject, jboolean, jint, jboolean, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTReset
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTReset
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTResponseTimeSet
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTResponseTimeSet
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSetMode
 * Signature: (IIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSetMode
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSWDRd
 * Signature: (III)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTI1553_RTSWDRd
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSWDWr
 * Signature: (CIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSWDWr
  (JNIEnv *, jobject, jchar, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    RTSyncDefine
 * Signature: (ZCCIIIIIII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTI1553_RTSyncDefine
  (JNIEnv *, jobject, jboolean, jchar, jchar, jint, jint, jint, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ValPackCWD
 * Signature: (IIII)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTI1553_ValPackCWD
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTI1553
 * Method:    ValUnpackCWD
 * Signature: (CLballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;Lballard/BTICard/IntRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTI1553_ValUnpackCWD
  (JNIEnv *, jobject, jchar, jobject, jobject, jobject, jobject);

#ifdef __cplusplus
}
#endif
#endif
