
                 USING THE BTIDRIVER JAVA CONSOLE EXAMPLES

                               June 21, 2012

                 Copyright 2012 by Ballard Technology, Inc.


                                ------------


          This folder contains the following folders:

           File Name                Description

          <.settings> Eclipse preferences
          <bin>       Compiled Java .class files and resources
          <jar>       Compiled Java .jar containing example
          <src>       Example source code

          .classpath  Class path information
          .project    Eclipse project settings
          README.TXT  This document


          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          This directory is an Eclipse Java project contain an example
          utilizing the BTIDriver Java library. It is implemented as a Java GUI
          application utilizing the Swing UI toolkit, which implements
          a virtual console containing Java code that implements a selection
          of Ballard native API examples. A description of these examples
          can be found in the \src\res directory on a per-protocol basis.



     INSTALLATION

          To use the Java examples, the Java virtual machine must be
          installed on your system. The latest version of Java can be found
          at java.sun.com

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



     RUNNING THE EXAMPLE

          Navigate to the \jar directory and execute the command:

               java -jar consoleexamples.jar

          For this command to work, the Java Runtime Environment must be
          installed and on your system's PATH. Minimum JRE version 7.



     MODIFYING THE EXAMPLE AND CUSTOM JAVA APPLICATIONS

          The Ballard BTIDriver Java library was developed using the Eclipse
          Classic IDE version 3.7.2. Our Java example was built and developed
          in this environment. If you wish to modify the example and run
          it from the Eclipse IDE, you must install Eclipse on your system
          from www.eclipse.org/downloads

          Inside the Eclipse IDE, create or open your workspace, right-click
          inside the Package Explorer Pane and select "Import." Under the
          "General" tab select "Existing Projects into Workspace." Click
          "Browse" and browse to the parent of this directory and click OK.
          Select both "btijavalib" and "consoleexamples" and now both the Java
          library project and the example project are in your workspace.

          At this point, new Eclipse Java projects can also be created in the
          Eclipse IDE. To utilize the Ballard Java library, make sure your new
          projects reference the btijavalib project (Right-click the project,
          select "Properties," click "Java Build Path," click "Libraries," and
          either Add the class folder (btijavalib/bin) or the jar file
          (btijavalib/jar).


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
