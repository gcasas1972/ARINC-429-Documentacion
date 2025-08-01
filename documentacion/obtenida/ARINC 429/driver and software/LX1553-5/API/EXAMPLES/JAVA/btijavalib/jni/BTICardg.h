/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class com_ballardtech_BTICard */
#ifndef _Included_com_ballardtech_BTICard
#define _Included_com_ballardtech_BTICard
#ifdef __cplusplus
extern "C" {
#endif

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardClose
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardClose
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardIsRunning
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_CardIsRunning
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardOpen
 * Signature: (Lballard/BTICard/IntRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardOpen
  (JNIEnv *, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardProductStr
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_CardProductStr
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardReset
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardReset
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardResume
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardResume
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardStart
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardStart
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardStop
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_CardStop
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTest
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CardTest
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTrigger
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardTrigger
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTriggerEx
 * Signature: (CI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_CardTriggerEx
  (JNIEnv *, jobject, jchar, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CardTypeStr
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_CardTypeStr
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    CoreOpen
 * Signature: (Lballard/BTICard/IntRef;II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_CoreOpen
  (JNIEnv *, jobject, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ErrDescStr
 * Signature: (II)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_ErrDescStr
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogConfig
 * Signature: (CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogConfig
  (JNIEnv *, jobject, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogRd
 * Signature: (Lballard/BTICard/CharRef;Lballard/BTICard/LongRef;Lballard/BTICard/IntRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogRd
  (JNIEnv *, jobject, jobject, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    EventLogStatus
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_EventLogStatus
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIOMonConfig
 * Signature: (CCII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_ExtDIOMonConfig
  (JNIEnv *, jobject, jchar, jchar, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIORd
 * Signature: (II)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_ExtDIORd
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtDIOWr
 * Signature: (IZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtDIOWr
  (JNIEnv *, jobject, jint, jboolean, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtLEDRd
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_ExtLEDRd
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtLEDWr
 * Signature: (ZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtLEDWr
  (JNIEnv *, jobject, jboolean, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtStatusLEDRd
 * Signature: (Lballard/BTICard/BooleanRef;Lballard/BTICard/BooleanRef;I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtStatusLEDRd
  (JNIEnv *, jobject, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ExtStatusLEDWr
 * Signature: (ZZI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_ExtStatusLEDWr
  (JNIEnv *, jobject, jboolean, jboolean, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGConfig
 * Signature: (JI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGConfig
  (JNIEnv *, jobject, jlong, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetDays
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetDays
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetHours
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetHours
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMicrosec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMicrosec
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMillisec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMillisec
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetMin
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetMin
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldGetSec
 * Signature: (JJ)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_IRIGFieldGetSec
  (JNIEnv *, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutDays
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutDays
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutHours
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutHours
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMicrosec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMicrosec
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMillisec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMillisec
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutMin
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutMin
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGFieldPutSec
 * Signature: (JLballard/BTICard/LongRef;Lballard/BTICard/LongRef;)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGFieldPutSec
  (JNIEnv *, jobject, jlong, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGInputThresholdGet
 * Signature: (Lballard/BTICard/CharRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGInputThresholdGet
  (JNIEnv *, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGInputThresholdSet
 * Signature: (CI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGInputThresholdSet
  (JNIEnv *, jobject, jchar, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGRd
 * Signature: (Lballard/BTICard/BTIIRIGTIME;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGRd
  (JNIEnv *, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGSyncStatus
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_IRIGSyncStatus
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGTimeBCDToBin
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;JJ)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGTimeBCDToBin
  (JNIEnv *, jobject, jobject, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGTimeBinToBCD
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;JJ)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_IRIGTimeBinToBCD
  (JNIEnv *, jobject, jobject, jobject, jlong, jlong);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    IRIGWr
 * Signature: (Lballard/BTICard/BTIIRIGTIME;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_IRIGWr
  (JNIEnv *, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    MakeLong
 * Signature: (CC)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_MakeLong
  (JNIEnv *, jobject, jchar, jchar);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    MakeWord
 * Signature: (BB)C
 */
JNIEXPORT jchar JNICALL Java_com_ballardtech_BTICard_MakeWord
  (JNIEnv *, jobject, jbyte, jbyte);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqBlkRd
 * Signature: ([CILballard/BTICard/LongRef;I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_SeqBlkRd
  (JNIEnv *, jobject, jcharArray, jint, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqCommRd
 * Signature: ([CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqCommRd
  (JNIEnv *, jobject, jcharArray, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqConfig
 * Signature: (JI)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqConfig
  (JNIEnv *, jobject, jlong, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqDMARd
 * Signature: ([CJI)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_SeqDMARd
  (JNIEnv *, jobject, jcharArray, jlong, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindCheckVersion
 * Signature: ([CC)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqFindCheckVersion
  (JNIEnv *, jobject, jcharArray, jchar);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindInit
 * Signature: ([CJLballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindInit
  (JNIEnv *, jobject, jcharArray, jlong, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindMore1553
 * Signature: (Lballard/BTICard/SEQRECORDMORE1553;Lballard/BTICard/SEQRECORD1553;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindMore1553
  (JNIEnv *, jobject, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNext1553
 * Signature: (Lballard/BTICard/SEQRECORD1553;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNext1553
  (JNIEnv *, jobject, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNext429
 * Signature: (Lballard/BTICard/SEQRECORD429;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNext429
  (JNIEnv *, jobject, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqFindNextEx
 * Signature: ([CILballard/BTICard/CharRef;Lballard/BTICard/SEQFINDINFO;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqFindNextEx
  (JNIEnv *, jobject, jcharArray, jint, jobject, jobject);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqInterval
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqInterval
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqIsRunning
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqIsRunning
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqLogFrequency
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqLogFrequency
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqRdEx
 * Signature: ([CII)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_SeqRdEx
  (JNIEnv *, jobject, jcharArray, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqResume
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqResume
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStart
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStart
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStatus
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStatus
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    SeqStop
 * Signature: (I)Z
 */
JNIEXPORT jboolean JNICALL Java_com_ballardtech_BTICard_SeqStop
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    Timer64Rd
 * Signature: (Lballard/BTICard/LongRef;Lballard/BTICard/LongRef;I)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_Timer64Rd
  (JNIEnv *, jobject, jobject, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    Timer64Wr
 * Signature: (JJI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_Timer64Wr
  (JNIEnv *, jobject, jlong, jlong, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerClear
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_TimerClear
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerRd
 * Signature: (I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_TimerRd
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerResolution
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_TimerResolution
  (JNIEnv *, jobject, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerStatus
 * Signature: (I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_TimerStatus
  (JNIEnv *, jobject, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    TimerWr
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_com_ballardtech_BTICard_TimerWr
  (JNIEnv *, jobject, jlong, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValFromAscii
 * Signature: (Ljava/lang/String;I)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValFromAscii
  (JNIEnv *, jobject, jstring, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValGetBits
 * Signature: (III)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValGetBits
  (JNIEnv *, jobject, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValPutBits
 * Signature: (IIII)J
 */
JNIEXPORT jlong JNICALL Java_com_ballardtech_BTICard_ValPutBits
  (JNIEnv *, jobject, jint, jint, jint, jint);

/*
 * Class:     com_ballardtech_BTICard
 * Method:    ValToAscii
 * Signature: (JLballard/BTICard/StringRef;II)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_com_ballardtech_BTICard_ValToAscii
  (JNIEnv *, jobject, jlong, jobject, jint, jint);

#ifndef WIN32
/*
 * Class:     com_ballardtech_BTICard
 * Method:    BJTestAssoc
 * Signature: (ILjava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_com_ballardtech_BTICard_BJTestAssoc
  (JNIEnv *, jobject, jint, jstring);
#endif

#ifdef __cplusplus
}
#endif
#endif
