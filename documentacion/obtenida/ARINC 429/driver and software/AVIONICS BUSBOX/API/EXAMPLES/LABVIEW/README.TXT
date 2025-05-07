

                        BTI DRIVER LABVIEW LIBRARIES

                               April 26, 2012

                Copyright 2002-2012 by Ballard Technology, Inc.


                                ------------


          This folder contains the following files:

           File Name                Description

          BTIVI_8.6.ZIP    BTIDriver LabVIEW library ZIP for LabVIEW 8.6
          BTIVI_2010.ZIP   BTIDriver LabVIEW library ZIP for LabVIEW 2010
          BTIVI.DLL        BTIDriver Labview Wrapper DLL
          README.TXT       This document



     INTRODUCTION

          The BTIVI_8.6.ZIP file contains the BTIDriver
          LabVIEW library for LabVIEW 8.6 and the
          BTIVI_2010.ZIP file contains the BTIDriver LabVIEW
          library for LabVIEW 2010.



     INSTALLATION

          To install the BTIDriver LabVIEW library, create a
          folder called BTIVI in the LabVIEW user.lib folder.
          The user.lib folder is typically located at:

          C:\Program Files\National Instruments\LabVIEW
          X.Y\user.lib

          where X.Y is the version of your LabVIEW
          installation (eg.  8.6 or 2010).

          Extract the contents of BTIVI_8.6.ZIP or
          BTIVI_2010.ZIP into the BTIVI folder you created.

          Next, if running 32-bit Windows, copy the BTIVI.DLL
          file to the SYSTEM32 folder of your Windows
          installation typically located at:

               C:\WINDOWS\SYSTEM32

          If running 64-bit Windows, copy the BTIVI.DLL file
          to the SYSWOW64 folder of your Windows installation
          typically located at:

               C:\WINDOWS\SYSWOW64



     USING THE FUNCTION PALETTE

          Once the LabVIEW library and the DLL have been
          installed, the Ballard VIs will be accessible from
          within the Function Palette under:

          "User Libraries" -> "BTIVI"

          which contains the following VIs:

               VIs - Functions organized hierarchically by
               protocol and function class.

               examples - Examples which use the BTIDriver
               API.  These are also organized by protocol.

               globals - Definitions of constants and
               structures used by the BTIDriver API.  Many
               API functions will require certain flags to be
               set by ORing together global constants from
               these VIs as shown in the exampes.

               subvi - A helper VI for handling errors.



     VI INFORMATION

          Each VI corresponds to a single BTIDriver API
          function.  In order to handle LabVIEW-specific
          details, each of these functions calls into
          BTIVI.DLL.  This means that VI names and parameters
          are slightly different compared to the C
          declaration found in the User's Manual.

          For example, the function BTI1553_BCConfig() is
          contained in the VI "1553 BC Config.VI" The
          function prefix is shortened simply to the
          protocol, and the parts of the function name are
          separated by spaces.

          For better LabVIEW support, most of the VIs return
          an ERRVAL, even if they didn't in the original C
          declaration.  For example, the C function
          BTI1553_ChIs1553() returns a BOOL, but the VI "1553
          Ch Is1553.VI" passes this BOOL value through an out
          parameter called "return_value".  The VI's actual
          return value ("function return") is now an ERRVAL.
          Any VI with a parameter labeled "return_value"
          adopts this convention.



     VERSION COMPATIBILITY

          The VIs in this version of the LabVIEW driver are
          not compatible with older versions of the driver.
          Updating your old LabVIEW programs which use the
          old Ballard VIs is a manual process with several
          steps.

               1.  Replace each VI in your program with the
               new VI.  This can be done through the context
               menu:

               Replace -> All Palletes -> BTIVI -> (Protocol) -> (Class)

               2.  In many cases, the wires for the new VI
               will be attached correctly since the names of
               the parameters are not changed.  However, some
               clean-up of the wires may be suggested since
               the connector locations may have changed.

               3.  If any parameters have changed, or the
               return value was not an ERRVAL in the old VI,
               one or more of the connectors may be
               incorrect.  A red X on a wire or gray VI icon
               will often indicate this condition if there is
               a type mismatch, but not always.  Take care to
               make sure to verify correct wiring after
               replacement.

               4.  Any global constants need to be relinked
               in a similar fashion.  After doing this, make
               sure to set the flag value back to what it was
               before since it will go back to the default
               after relinking.

          Note that the BTIVI library in BTIVI_8.6.ZIP is
          compatible with LabVIEW version 8.6, and the BTIVI
          library in BTIVI_2010.ZIP is compatible with
          LabVIEW 2010.



     WARNING

          Before using the LabVIEW libraries, verify that the
          drivers for the BTIDriver compliant device are
          correctly installed for your particular operating
          system.  Refer to the README.TXT file in the
          <DRIVERS> folder on this disk.



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
