

                  USING THE BTI429 JAVA DRIVER API AND EXAMPLES

              Copyright 2012 by Ballard Technology, Inc.


                                ------------


          This application implements a variety of examples that utilize the BTI429
          API via Java. The calls are routed through static Java classes (e.g. BTI429)
          and implemented as native functions through a JNI interface. The standard
          prefix (e.g. "BTI429_") has been replaced with the class name so using the 
          prefix is not necessary. All Ballard API classes are within the com.ballardtech package. 

          The 429 example source code is located within the com.ballardtech.examples.console
          package within the static class Examples429. Here are descriptions of the various 
          examples, which are implemented as functions in the Examples429 class:

          Function Name  Description

          example1()     Example 1: Receiver example
          example2()     Example 2: Transmitter example
          example3()     Example 3: Sequential monitor example
          example4()     Example 4: Explicit message timing example
          example5()     Example 5: Transmit and receive list buffers example
          example6()     Example 6: Asynchronous list buffer example
          example8()     Example 8: Polling the event log list
          example12()    Example 12: IRIG Timer example
          example13()    Example 13: Monitor DMA example
          example14()    Example 14: BNR/BCD example
          example15()    Example 15: Print a transmit schedule
          example16()    Example 16: Transmit message skipping
          example17()    Example 17: Sequential log frequency example

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          The BTI429 Java class depends on shared object library built
          for your platform that is the API for Ballard 429 hardware 
          (e.g. libbti429.so or bti429.dll).  The BTI429 API library 
          is dependent upon the BTICard API library.  Additionally, the 
          RPC mode driver is dependent on the BTIRPC library.  Finally,
          there is a JNI layer (Java Native Interface) that provides
          a thin wrapper over the API libraries that translates calls from
          Java to native calls. These libraries take the same name as the
          standard API library, but append a "g" to the end of the file name
          (e.g. bti429g.dll). With these files, the user can write 
          applications utilizing Java that operate a BTIDriver compliant 
          ARINC 429 device.

          The Driver API has been tested using GCC 3.3.1 for Android and 
          Visual Studio 2005 for Java on Windows.



     JAVA CLASS com.ballardtech.BTI429

          Applications written in the Java language
          that use the BTI429 Driver API library must
          import com.ballardtech.BTI429 using the
          Java import statement.  Assuming the
          class file is within the Java class path, the 
          following line must be added to the top of the 
          application's source file:

          import com.ballardtech.BTI429;



     EXAMPLE PROGRAMS

          Examples are provided as Java source code files and a Java-
	  executable JAR file. For Android, the examples are built 
          into a single APK file which can be installed on an Android 3.1 
          or above device with USB Host support. Android example source
          code is also provided.



     FUNCTION OVERVIEW

          All functions are described in detail in the
          Ballard Technology ARINC 429 API Reference Manual.



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
