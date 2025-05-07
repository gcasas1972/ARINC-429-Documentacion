
                       USING THE BTIDRIVER JAVA LIBRARY

                               June 21, 2012

                 Copyright 2012 by Ballard Technology, Inc.


                                ------------


          This folder contains the following folders:

           File Name                Description

          <.settings> Eclipse preferences
          <bin>       Compiled Java .class files and resources
          <jar>       Compiled Java .jar containing library
          <jni>       C source code and project that implements JNI layer
          <libs>      Various built JNI native libraries
          <src>       Java source code for the Java library

          .classpath  Class path information
          .project    Eclipse project settings
          README.TXT  This document


          Refer to the end of this document for corrections,
          warnings, and additional information.




     INTRODUCTION

          The BTIDriver Java library is a collection of classes inside of
          the com.ballardtech Java package.  These classes each implement
          a Java interface to the BTIDriver API. Inside Java code, the
          classes may be imported using the import statement, e.g.

          import com.ballardtech.BTI429;

          This provides access to Ballard hardware via the BTIDriver API.



     INSTALLATION

          To use the BTIDriver Java library, the Java virtual machine
          must be installed on your system. The latest version of Java can
          be found at java.sun.com

          To install the BTIDriver Java library, copy the BTI*.dll files
          from the ..\btijavalib\libs\win32 and ..\btijavalib\libs\win64

          On 64-bit systems, the win32 DLLs need to be copied to:

               C:\WINDOWS\SYSWOW64

          On 64-bit systems, the win64 DLLs need to be copied to:

               C:\WINDOWS\SYSTEM32

          On 32-bit systems, the win32 DLLs need to be copied to

               C:\WINDOWS\SYSTEM32

          These DLLs implement the JNI layer which translate Java calls to
          our native libraries.  In addition, the Ballard hardware drivers
          must also be installed.



     FUNCTION OVERVIEW

          All functions are described in detail in the various
          Ballard Technology API Reference Manuals.



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
