

                     USING THE BTIDriver INCLUDE FILES

                               March 22, 2013

               Copyright 2001-2013 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTI1553.H      BTI1553 C/C++ language include file
          BTI1553NET.CS  BTI1553 C# module file
          BTI1553NET.VB  BTI1553 VB.NET module file
          BTI1553VB.BAS  BTI1553 Visual Basic header file
          BTI422.H       BTI422 C/C++ language include file
          BTI422NET.CS   BTI422 C# module file
          BTI422NET.VB   BTI422 VB.NET module file
          BTI422VB.BAS   BTI422 Visual Basic header file
          BTI429.H       BTI429 C/C++ language include file
          BTI429NET.CS   BTI429 C# module file
          BTI429NET.VB   BTI429 VB.NET module file
          BTI429VB.BAS   BTI429 Visual Basic header file
          BTI708.H       BTI708 C/C++ language include file
          BTI708NET.CS   BTI708 C# module file
          BTI708NET.VB   BTI708 VB.NET module file
          BTI708VB.BAS   BTI708 Visual Basic header file
          BTI717.H       BTI717 C/C++ language include file
          BTI717NET.CS   BTI717 C# module file
          BTI717NET.VB   BTI717 VB.NET module file
          BTI717VB.BAS   BTI717 Visual Basic header file
          BTICard.H      BTICard C/C++ language include file
          BTICardNET.CS  BTICard C# module file
          BTICardNET.VB  BTICard VB.NET module file
          BTICardVB.BAS  BTICard Visual Basic header file
          BTICSDB.H      BTICSDB C/C++ language include file
          BTICSDBNET.CS  BTICSDB C# module file
          BTICSDBNET.VB  BTICSDB VB.NET module file
          BTICSDBVB.BAS  BTICSDB Visual Basic header file
          BTIDIO.H       BTIDIO C/C++ language include file
          BTIDIONET.CS   BTIDIO C# module file
          BTIDIONET.VB   BTIDIO VB.NET module file
          BTIDIOVB.BAS   BTIDIO Visual Basic header file

          README.TXT    This document

          Refer to the end of this document for corrections,
          warnings, and additional information.



     INTRODUCTION

          These files are the C/C++ and VisualBasic language
          header files for the BTIDriver API.  With these
          files, the user can write applications that operate
          a BTIDriver compliant device.



     BTI1553.H, BTI422.H, BTI429.H, BTI708.H, BTI717.H,
     BTICSDB.H, BTIDIO.H, BTICARD.H

          WIN32 applications written in the C or C++ language
          that use the BTIDriver API library must incorporate
          the header files using the #include preprocessor
          directive.  Assuming the header file is in the
          current working directory or in the INCLUDE path,
          one or more of the following lines must be added to
          the top of the application's source file:

          #include "BTICARD.H"
          #include "BTI1553.H"
          #include "BTI422.H"
          #include "BTI429.H"
          #include "BTI708.H"
          #include "BTI717.H"
          #include "BTICSDB.H"
          #include "BTIDIO.H"

          Include BTICARD.H and one or more protocol header
          files as needed.



     BTI1553NET.CS, BTI422NET.CS, BTI429NET.CS,
     BTI708NET.CS, BTI717NET.CS, BTICARDNET.CS,
     BTICSDBNET.CS, BTIDIONET.CS

          WIN32 applications written in Microsoft Visual
          C# can access the BTIDriver API by adding
          one or more of the BTI*NET.CS files into the Visual
          C# project.  Once added to the project,
          Driver API functions contained within the driver
          modules can be called from user applications.



     BTI1553VB.BAS, BTI422VB.BAS, BTI429VB.BAS,
     BTI708VB.BAS, BTI717VB.BAS, BTICARDVB.BAS,
     BTICSDBVB.BAS, BTIDIOVB.BAS

          WIN32 applications written in Microsoft Visual
          Basic can access the BTIDriver API by adding one or
          more of the BTI*VB.BAS files into the VisualBasic
          project.  Once added to the project, Driver API
          functions can be called along with other
          user-defined functions.



     BTI1553NET.VB, BTI422NET.VB, BTI429NET.VB,
     BTI708NET.VB, BTI717NET.VB, BTICARDNET.VB,
     BTICSDBNET.VB, BTIDIONET.VB

          WIN32 applications written in Microsoft Visual
          Basic .NET can access the BTIDriver API by adding
          one or more of the BTI*NET.VB files into the Visual
          Basic .NET project.  Once added to the project,
          Driver API functions contained within the driver
          modules can be called from user applications.



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
