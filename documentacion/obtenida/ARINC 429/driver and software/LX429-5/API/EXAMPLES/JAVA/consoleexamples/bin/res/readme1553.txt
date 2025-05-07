

                  USING THE BTI1553 JAVA DRIVER API AND EXAMPLES

              Copyright 2012 by Ballard Technology, Inc.


                                ------------


          This application implements a variety of examples that utilize the BTI1553
          API via Java. The calls are routed through static Java classes (e.g. BTI1553)
          and implemented as native functions through a JNI interface. The standard
          prefix (e.g. "BTI1553_") has been replaced with the class name so using the 
          prefix is not necessary. All Ballard API classes are within the com.ballardtech package. 

          The 1553 example source code is located within the com.ballardtech.examples.console
          package within the static class Examples1553. Here are descriptions of the various 
          examples, which are implemented as functions in the Examples1553 class:

          FUNCTION NAME	DESCRIPTION
          example1()	Example 1:  Simulating the BC - Unscheduled Messages
          example2()	Example 2:  Simulating the BC - Scheduled Messages
          example3()	Example 3:  Simulating an RT
          example4()	Example 4:  Monitoring the bus
          example5()	Example 5:  Simultaneous BC, RT, and monitor simulation
          example6()	Example 6:  Errors in BC Transmissions - Unscheduled Messages
          example7()	Example 7:  Errors in BC Transmissions - Scheduled Messages
          example8()	Example 8:  Errors in RT Transmissions
          example10()	Example 10: Polling the Event Log List
          example12()	Example 12: BC Transmission of Ramping Data Using a FIFO
          example15()	Example 15: IRIG Timer
          example16()	Example 16: RT Response Time

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The BTI1553 Java class depends on shared object library built
          for your platform that is the API for Ballard 1553 hardware 
          (e.g. libbti1553.so or bti1553.dll).  The BTI1553 API library 
          is dependent upon the BTICard API library.  Additionally, the 
          RPC mode driver is dependent on the BTIRPC library.  Finally,
          there is a JNI layer (Java Native Interface) that provides
          a thin wrapper over the API libraries that translates calls from
          Java to native calls. These libraries take the same name as the
          standard API library, but append a "g" to the end of the file name
          (e.g. bti1553g.dll). With these files, the user can write 
          applications utilizing Java that operate a BTIDriver compliant 
          MIL-STD-1553 device.

          The Driver API has been tested using GCC 3.3.1 for Android and 
          Visual Studio 2005 for Java on Windows.



     JAVA CLASS com.ballardtech.BTI1553

          Applications written in the Java language
          that use the BTI1553 Driver API library must
          import com.ballardtech.BTI1553 using the
          Java import statement.  Assuming the
          class file is within the Java class path, the 
          following line must be added to the top of the 
          application's source file:

          import com.ballardtech.BTI1553;



     EXAMPLE PROGRAMS

          Examples are provided as Java source code files and a Java-
          executable JAR file. For Android, the examples are built 
          into a single APK file which can be installed on an Android 3.1 
          or above device with USB Host support. Android example source
          code is also provided.



     FUNCTION OVERVIEW

          All functions are described in detail in the
          Ballard Technology MIL-STD-1553 API Reference Manual.



     CORRECTIONS, WARNINGS, AND ADDITIONAL INFORMATION

          There is no additional information.


                                ------------


          SAFETY WARNING:  Ballard products are of commercial
          grade and therefore are neither designed,
          manufactured, nor tested to standards required for
          use in critical applications where a failure or
          deficiency of the product may lead to injury,
          death, or damage to property.  Without prior
          specific approval in writing by the president of
          Ballard Technology, Inc., Ballard products are not
          authorized for use in such critical applications.

          This software is provided as a laboratory tool.
          For any application it is the responsibility of the
          user to verify the suitability, correctness, and
          safety of using this software or data derived
          therefrom.


                                ------------


     Ballard Technology would appreciate hearing your questions,
     comments, and suggestions concerning this product.

     Ballard Technology, Inc.
     www.ballardtech.com
     support@ballardtech.com
