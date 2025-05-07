using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BALLARD;

/**
*
*  BTI429 DRIVER EXAMPLE 14  (06/07/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP14 -- Example 14.
*                     "Program to get BNR from ARINC words"
*
**/

/**
*
*  This is a utility function example program and does not access
*  any Device hardware. This program will recreate Table 6-2 "BNR
*  DATA ENCODING EXAMPLES" from the ARINC SPECIFICATION 429, PART 1.
*
*  NOTE: This example is intended to recreate a specific page in the
*  ARINC specification. As such, the ARINC data is presented verbatim.
*  When operating Ballard hardware, the ARINC label should be
*  presented in human readable order, NOT ARINC order as this table
*  shows. See the BTI429 Programming Manual for more details.
*
**/

namespace EXAMP14
{
    public class Win32Interop
    {
        [DllImport("crtdll.dll")]
        public static extern int _kbhit();
    }

    class Examp14
    {
        private const Int32 CARDNUM = 0;
        private const Int32 MAX_CORES = 4;
        private const Int32 MAX_CHANNELS = 32;

        /********************************
        *
        *	BNR
        *
        *********************************/

        public static double BTI429_BNRGetValDbl(UInt32 msg, UInt16 sigbit, double dblResolution)
        {
            double dblResult;

            dblResult = BTI429.BTI429_BNRGetMant(msg, sigbit) * dblResolution;

            if (0 != BTI429.BTI429_BNRGetSign(msg)) dblResult = -dblResult;

            return (dblResult);
        }

        public static UInt32 BTI429_BNRPutValDbl(double dblVal, UInt32 msg, UInt16 sigbit, double dblResolution)
        {
            UInt32 ulResult;
            UInt32 mantissa;
            bool bNegative;

            bNegative = (0 > dblVal) ? true : false;									//Record if value is negative

            if (bNegative) dblVal = -dblVal;								//If negative, make positive

            mantissa = (UInt32)(dblVal / dblResolution);						//Scale to remove decimal

            ulResult = BTI429.BTI429_BNRPutMant(msg, mantissa, sigbit, (UInt16)(bNegative ? 1:0));	//Fold in original message

            return (ulResult);
        }

        /********************************
        *
        *	BNR Angular
        *
        *********************************/

        public static double BTI429_BNRAngularGetValDbl(UInt32 msg, UInt16 sigbit, UInt16 bPlusMinus180)
        {
            double dblResult;
            double dblResolution;

            dblResolution = 180.0;
            dblResolution /= (1 << sigbit);

            dblResult = BTI429_BNRGetValDbl(msg, sigbit, dblResolution);

            if ((0 == bPlusMinus180) && 0 > dblResult) dblResult = dblResult + 360.0;

            return (dblResult);
        }

        public static UInt32 BTI429_BNRAngularPutValDbl(double dblVal, UInt32 msg, UInt16 sigbit)
        {
            UInt32 ulResult;
            double dblResolution;

            dblResolution = 180.0;
            dblResolution /= (1 << sigbit);

            if (dblVal > 180) dblVal = dblVal - 360;

            ulResult = BTI429_BNRPutValDbl(dblVal, msg, sigbit, dblResolution);

            return (ulResult);
        }


        static void Main(string[] args)
        {
            UInt32 msg;

	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n    *                                                                    *");
            Console.Write("\n    *  EXAMP14    (06/07/2011)                                           *");
            Console.Write("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	        Console.Write("\n    *  All rights reserved.                                              *");
	        Console.Write("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    *  BTI429 Example 14                                                 *");
	        Console.Write("\n    *  \"Program to get BNR from ARINC words\"                             *");
	        Console.Write("\n    *                                                                    *");
	        Console.Write("\n    **********************************************************************");
	        Console.Write("\n\n");

	        Console.Write("\t\t\t\tTable 6-2\n");
	        Console.Write("\t\t\tBNR DATA ENCODING EXAMPLES\n\n");

	        Console.Write("\tPARAMETER\t  (Label)\tMSG\t\tRESULT\n");
	        Console.Write("    ----------------------------------------------------------------------\n");

	        msg = 0x60000002;
	        Console.Write(" {0,30}","Selected Course (100)");
	        Console.Write("\t\t{0:X8}",msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, (UInt16)12, (UInt16)1));
	        Console.Write(" Deg.\n");

	        msg = 0x6D550082;
	        Console.Write(" {0,30}","Selected Heading (101)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, 12, 1));
	        Console.Write(" Deg.\n");

	        msg = 0xEA028042;
	        Console.Write(" {0,30}","Selected Altitude (102)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 16, 1.0));
	        Console.Write(" Ft.\n");

	        msg = 0x6D3800C2;
	        Console.Write(" {0,30}","Selected Airspeed (103)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 11, 0.25));
	        Console.Write(" Knots\n");

	        msg = 0xFDD80022;
	        Console.Write(" {0,30}","Selected Vertical Speed (104)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 10, 16.0));
	        Console.Write(" Ft/Min\n");

	        msg = 0xE3200062;
	        Console.Write(" {0,30}","Selected Mach (106)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 12, 1.0));
	        Console.Write(" m Mach.\n");

	        msg = 0x78720032;
	        Console.Write(" {0,30}","Desired Track (114)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, 12, 0));
	        Console.Write(" Deg.\n");

	        msg = 0xE6600072;
	        Console.Write(" {0,30}","Cross Track Distance (116)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 15, 0.004));
	        Console.Write(" NM\n");

	        msg = 0x64B000F2;
	        Console.Write(" {0,30}","Vertical Deviation (117)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 11, 1.0));
	        Console.Write(" Ft.\n");

	        msg = 0xE2AB0006;
	        Console.Write(" {0,30}","Flight Director Roll (140)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, 12, 1));
	        Console.Write(" Deg.\n");

	        msg = 0xF0E40086;
	        Console.Write(" {0,30}","Flight Director Pitch (141)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, 12, 1));
	        Console.Write(" Deg.\n");

	        msg = 0x67800046;
	        Console.Write(" {0,30}","Fast/Slow (142)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 12, 0.008));
	        Console.Write(" Knots\n");

            /*	msg = 0x6972A016;
	            Console.Write(" {0,30}","Greenwich Mean Time (150)");
	            Console.Write("\t\t{0:X8}",msg);
	            Console.Write("\t({0:f})",BTI429.BTI429_BNRGetValDbl(msg, 12, 0.0178125));
	            Console.Write("\n");
            */
            msg = 0x64C9002E;
	        Console.Write(" {0,30}","Radio Height (164)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 16, 0.125));
	        Console.Write(" Ft.\n");

	        msg = 0xE0D800DE;
	        Console.Write(" {0,30}","Localizer Deviation (173)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRGetValDbl(msg, 12, 0.0001));
	        Console.Write(" DDM\n");

	        msg = 0xFD80003E;
	        Console.Write(" {0,30}","Glide Slope Deviation (174)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRGetValDbl(msg, 12, 0.0002));
	        Console.Write(" Deg.\n");

	        msg = 0x680EE041;
	        Console.Write(" {0,30}","DME Distance (202)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 16, 0.008));
	        Console.Write(" NM\n");

	        msg = 0x657E40C1;
	        Console.Write(" {0,30}","Altitude (29.92) (203)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 17, 1.0));
	        Console.Write(" Ft.\n");

	        msg = 0x634080A1;
	        Console.Write(" {0,30}","Mach (205)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRGetValDbl(msg, 16, 0.0000625));
	        Console.Write(" Mach\n");

	        msg = 0xE6A40061;
	        Console.Write(" {0,30}","Computed Airspeed (206)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 14, 0.0625));
	        Console.Write(" Knots\n");

	        msg = 0x646A0011;
	        Console.Write(" {0,30}","True Airspeed (210)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 15, 0.0625));
	        Console.Write(" Knots\n");

	        msg = 0x606800D1;
	        Console.Write(" {0,30}","Static Air Temp (213)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 11, 0.25));
	        Console.Write(" Deg. C\n");

	        msg = 0x7F320091;
	        Console.Write(" {0,30}","Total Air Temp (211)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 11, 0.25));
	        Console.Write(" Deg. C\n");

	        msg = 0x788E0051;
	        Console.Write(" {0,30}","Altitude Rate (212)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 11, 16.0));
	        Console.Write(" Ft/Min\n");

	        msg = 0xE73EA813;
	        Console.Write(" {0,30}","Present Pos. Lat. (310)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\tN {0:f}",BTI429_BNRGetValDbl(msg, 20, 0.000172));
	        Console.Write(" Deg\n");

	        msg = 0x7716C093;
	        Console.Write(" {0,30}","Present Pos. Long. (311)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\tW {0:f}",BTI429_BNRGetValDbl(msg, 20, 0.000172));
	        Console.Write("\n");

	        msg = 0xE28A0053;
	        Console.Write(" {0,30}","Ground Speed (312)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 15, 0.125));
	        Console.Write(" Knots\n");

	        msg = 0x6A0500CB;
	        Console.Write(" {0,30}","Flight Path Accel (323)");
            Console.Write("\t\t{0:X8}", msg);
	        Console.Write("\t{0:f}",BTI429_BNRGetValDbl(msg, 12, 0.001));
	        Console.Write(" g\n");

	        Console.Write("\n");

            /////////////////////////////////////////////////////////////////////////////////////////

            Console.Write("\t\t\tBCD DATA ENCODING EXAMPLES\n\n");

            Console.Write("\tPARAMETER\t  (Label)\tMSG\t\tRESULT\n");
            Console.Write("    ----------------------------------------------------------------------\n");

            msg = 0x60000002;
            Console.Write(" {0,30}", "Selected Course (100)");
            Console.Write("\t\t{0:X8}", msg);
            Console.Write("\t{0:f}", BTI429_BNRAngularGetValDbl(msg, (UInt16)12, (UInt16)1));
            Console.Write(" Deg.\n");

            System.Text.StringBuilder test  = new System.Text.StringBuilder("aaa");
            System.Text.StringBuilder resol = new System.Text.StringBuilder("0.1");
           
            msg = 0x12345678;

            Console.Write("\n Before - {0}", test);

            BTI429.BTI429_BCDGetVal(test, msg, 6, resol);
           
            Console.Write("\n After  - {0}", test);





            Console.Write("\n");

            /////////////////////////////////////////////////////////////////////////////////////////
            
            Console.Write("\nPress any key to exit....\n\n");

            while (0 == Win32Interop._kbhit())
            {
                //Wait!!!!
            }

            /////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
