using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTI422
    {
        /**
        *
        *  BTI422 WIN32 DRIVER  Version 1.1.2  (03/02/2010)
        *  Copyright (c) 2004-2010
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTI422NET.CS -- 32-bit
        *                      BTI422 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTI422 Driver.
        *
        **/

        /**
        *
        *  BTI422 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTI422 Driver.
        *
        **/

        private static class BTI422_32
        {
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOCheckRx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOCheckRx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOCheckTx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOCheckTx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOConfigRx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOConfigRx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOConfigTx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOConfigTx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFODataRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFODataRd(ref byte buf, Int32 count, ref UInt32 status, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFODataWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFODataWr(ref byte buf, Int32 count, UInt32 ctrlflags, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOFlushRx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOFlushRx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOFlushTx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOFlushTx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_FIFOGapWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOGapWr(UInt16 gapcount, UInt32 ctrlflags, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_ParamAmplitudeGet(ref UInt16 dacval, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortConfig(UInt32 configval, UInt16 bitrateflag, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortGetCount@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI422_PortGetCount(ref Int32 portcount, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI422_PortGetInfo(UInt16 infotype, Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortIs422@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortIs422(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortStart(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortStop(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_DllUsageCount();
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI422_PortCreate(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_PortReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortReset(Int32 portnum, UInt32 handleval);
            [DllImport("BTI422.DLL", EntryPoint = "_BTI422_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_TestProtocol(UInt32 handleval);
        }

        private static class BTI422_64
        {
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOCheckRx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOCheckRx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOCheckTx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOCheckTx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOConfigRx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOConfigRx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOConfigTx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOConfigTx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFODataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFODataRd(ref byte buf, Int32 count, ref UInt32 status, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFODataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFODataWr(ref byte buf, Int32 count, UInt32 ctrlflags, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOFlushRx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOFlushRx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOFlushTx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOFlushTx(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_FIFOGapWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_FIFOGapWr(UInt16 gapcount, UInt32 ctrlflags, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_ParamAmplitudeGet(ref UInt16 dacval, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortConfig(UInt32 configval, UInt16 bitrateflag, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI422_PortGetCount(ref Int32 portcount, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI422_PortGetInfo(UInt16 infotype, Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortIs422", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortIs422(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortStart(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortStop(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_DllUsageCount();
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI422_PortCreate(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_PortReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_PortReset(Int32 portnum, UInt32 handleval);
            [DllImport("BTI42264.DLL", EntryPoint = "BTI422_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI422_TestProtocol(UInt32 handleval);
        }

        public static Int32 BTI422_FIFOCheckRx(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOCheckRx(portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOCheckRx(portnum, handleval);
        }
        public static Int32 BTI422_FIFOCheckTx(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOCheckTx(portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOCheckTx(portnum, handleval);
        }
        public static Int32 BTI422_FIFOConfigRx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOConfigRx(configval, threshold, portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOConfigRx(configval, threshold, portnum, handleval);
        }
        public static Int32 BTI422_FIFOConfigTx(UInt32 configval, Int32 threshold, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOConfigTx(configval, threshold, portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOConfigTx(configval, threshold, portnum, handleval);
        }
        public static Int32 BTI422_FIFODataRd(ref byte buf, Int32 count, ref UInt32 status, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFODataRd(ref buf, count, ref status, portnum, handleval);
            else
                return BTI422_64.BTI422_FIFODataRd(ref buf, count, ref status, portnum, handleval);
        }
        public static Int32 BTI422_FIFODataWr(ref byte buf, Int32 count, UInt32 ctrlflags, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFODataWr(ref buf, count, ctrlflags, portnum, handleval);
            else
                return BTI422_64.BTI422_FIFODataWr(ref buf, count, ctrlflags, portnum, handleval);
        }
        public static Int32 BTI422_FIFOFlushRx(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOFlushRx(portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOFlushRx(portnum, handleval);
        }
        public static Int32 BTI422_FIFOFlushTx(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOFlushTx(portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOFlushTx(portnum, handleval);
        }
        public static Int32 BTI422_FIFOGapWr(UInt16 gapcount, UInt32 ctrlflags, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_FIFOGapWr(gapcount, ctrlflags, portnum, handleval);
            else
                return BTI422_64.BTI422_FIFOGapWr(gapcount, ctrlflags, portnum, handleval);
        }
        public static Int32 BTI422_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_ParamAmplitudeConfig(configval, dacval, portnum, handleval);
            else
                return BTI422_64.BTI422_ParamAmplitudeConfig(configval, dacval, portnum, handleval);
        }
        public static Int32 BTI422_ParamAmplitudeGet(ref UInt16 dacval, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_ParamAmplitudeGet(ref dacval, portnum, handleval);
            else
                return BTI422_64.BTI422_ParamAmplitudeGet(ref dacval, portnum, handleval);
        }
        public static Int32 BTI422_PortConfig(UInt32 configval, UInt16 bitrateflag, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortConfig(configval, bitrateflag, portnum, handleval);
            else
                return BTI422_64.BTI422_PortConfig(configval, bitrateflag, portnum, handleval);
        }
        public static void BTI422_PortGetCount(ref Int32 portcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI422_32.BTI422_PortGetCount(ref portcount, handleval);
            else
                BTI422_64.BTI422_PortGetCount(ref portcount, handleval);
        }
        public static UInt32 BTI422_PortGetInfo(UInt16 infotype, Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortGetInfo(infotype, portnum, handleval);
            else
                return BTI422_64.BTI422_PortGetInfo(infotype, portnum, handleval);
        }
        public static Int32 BTI422_PortIs422(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortIs422(portnum, handleval);
            else
                return BTI422_64.BTI422_PortIs422(portnum, handleval);
        }
        public static Int32 BTI422_PortStart(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortStart(portnum, handleval);
            else
                return BTI422_64.BTI422_PortStart(portnum, handleval);
        }
        public static Int32 BTI422_PortStop(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortStop(portnum, handleval);
            else
                return BTI422_64.BTI422_PortStop(portnum, handleval);
        }
        public static Int32 BTI422_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_DllUsageCount();
            else
                return BTI422_64.BTI422_DllUsageCount();
        }
        public static UInt32 BTI422_PortCreate(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortCreate(portnum, handleval);
            else
                return BTI422_64.BTI422_PortCreate(portnum, handleval);
        }
        public static Int32 BTI422_PortReset(Int32 portnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_PortReset(portnum, handleval);
            else
                return BTI422_64.BTI422_PortReset(portnum, handleval);
        }
        public static Int32 BTI422_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI422_32.BTI422_TestProtocol(handleval);
            else
                return BTI422_64.BTI422_TestProtocol(handleval);
        }

        /**
        *
        *  Port number constants
        *
        **/

        public const UInt32 PORT0 = 0x0000;          //Port 0
        public const UInt32 PORT1 = 0x0001;          //Port 1
        public const UInt32 PORT2 = 0x0002;          //Port 2
        public const UInt32 PORT3 = 0x0003;          //Port 3
        public const UInt32 PORT4 = 0x0004;          //Port 4
        public const UInt32 PORT5 = 0x0005;          //Port 5
        public const UInt32 PORT6 = 0x0006;          //Port 6
        public const UInt32 PORT7 = 0x0007;          //Port 7
        public const UInt32 PORT8 = 0x0008;          //Port 8
        public const UInt32 PORT9 = 0x0009;          //Port 9
        public const UInt32 PORT10 = 0x000A;          //Port 10
        public const UInt32 PORT11 = 0x000B;          //Port 11
        public const UInt32 PORT12 = 0x000C;          //Port 12
        public const UInt32 PORT13 = 0x000D;          //Port 13
        public const UInt32 PORT14 = 0x000E;          //Port 14
        public const UInt32 PORT15 = 0x000F;          //Port 15
        public const UInt32 PORT16 = 0x0010;          //Port 16
        public const UInt32 PORT17 = 0x0011;          //Port 17
        public const UInt32 PORT18 = 0x0012;          //Port 18
        public const UInt32 PORT19 = 0x0013;          //Port 19
        public const UInt32 PORT20 = 0x0014;          //Port 20
        public const UInt32 PORT21 = 0x0015;          //Port 21
        public const UInt32 PORT22 = 0x0016;          //Port 22
        public const UInt32 PORT23 = 0x0017;          //Port 23
        public const UInt32 PORT24 = 0x0018;          //Port 24
        public const UInt32 PORT25 = 0x0019;          //Port 25
        public const UInt32 PORT26 = 0x001A;          //Port 26
        public const UInt32 PORT27 = 0x001B;          //Port 27
        public const UInt32 PORT28 = 0x001C;          //Port 28
        public const UInt32 PORT29 = 0x001D;          //Port 29
        public const UInt32 PORT30 = 0x001E;          //Port 30
        public const UInt32 PORT31 = 0x001F;          //Port 31

        /**
        *
        *  Bitrate configuration options
        *
        **/

        public const UInt32 BITRATE422_CLK1 = 0x8000;      //CLK1, 20 MHz (default)
        public const UInt32 BITRATE422_CLK2 = 0x0000;      //CLK2, 9.216 MHz (standard option)
        public const UInt32 BITRATE422_XMTSLOPEHIGH = 0x0000;      //Transmit with high speed slope (default)
        public const UInt32 BITRATE422_XMTSLOPELOW = 0x4000;      //Transmit with low speed slope

        // These defines assume an external clock of 9.216 MHz
        public const UInt32 BITRATE422_921600BPS = 0x0000;          //External Clock, Div = 0
        public const UInt32 BITRATE422_460800BPS = 0x0001;          //External Clock, Div = 1
        public const UInt32 BITRATE422_230400BPS = 0x0003;          //External Clock, Div = 3
        public const UInt32 BITRATE422_115200BPS = 0x0007;          //External Clock, Div = 7
        public const UInt32 BITRATE422_57600BPS = 0x000F;          //External Clock, Div = 15
        public const UInt32 BITRATE422_38400BPS = 0x0017;          //External Clock, Div = 23
        public const UInt32 BITRATE422_28800BPS = 0x001F;          //External Clock, Div = 31
        public const UInt32 BITRATE422_19200BPS = 0x002F;          //External Clock, Div = 47
        public const UInt32 BITRATE422_14400BPS = 0x003F;          //External Clock, Div = 63
        public const UInt32 BITRATE422_9600BPS = 0x005F;          //External Clock, Div = 95
        public const UInt32 BITRATE422_7200BPS = 0x007F;          //External Clock, Div = 127
        public const UInt32 BITRATE422_4800BPS = 0x00BF;          //External Clock, Div = 191
        public const UInt32 BITRATE422_3600BPS = 0x00FF;          //External Clock, Div = 255
        public const UInt32 BITRATE422_2400BPS = 0x017F;          //External Clock, Div = 383
        public const UInt32 BITRATE422_1800BPS = 0x01FF;          //External Clock, Div = 511
        public const UInt32 BITRATE422_1200BPS = 0x02FF;          //External Clock, Div = 767
        public const UInt32 BITRATE422_900BPS = 0x03FF;          //External Clock, Div = 1023
        public const UInt32 BITRATE422_600BPS = 0x05FF;          //External Clock, Div = 1535
        public const UInt32 BITRATE422_300BPS = 0x0BFF;          //External Clock, Div = 3071

        public const UInt32 BITRATE422_1000000BPS = 0x8001;          //Internal Clock, Div = 1
        public const UInt32 BITRATE422_500000BPS = 0x8003;          //Internal Clock, Div = 3
        public const UInt32 BITRATE422_400000BPS = 0x8004;          //Internal Clock, Div = 4
        public const UInt32 BITRATE422_250000BPS = 0x8007;          //Internal Clock, Div = 7
        public const UInt32 BITRATE422_200000BPS = 0x8009;          //Internal Clock, Div = 9
        public const UInt32 BITRATE422_100000BPS = 0x8013;          //Internal Clock, Div = 19
        public const UInt32 BITRATE422_80000BPS = 0x8018;          //Internal Clock, Div = 24
        public const UInt32 BITRATE422_50000BPS = 0x8027;          //Internal Clock, Div = 39
        public const UInt32 BITRATE422_40000BPS = 0x8031;          //Internal Clock, Div = 49
        public const UInt32 BITRATE422_25000BPS = 0x804F;          //Internal Clock, Div = 79
        public const UInt32 BITRATE422_20000BPS = 0x8063;          //Internal Clock, Div = 99
        public const UInt32 BITRATE422_12500BPS = 0x809F;          //Internal Clock, Div = 159
        public const UInt32 BITRATE422_10000BPS = 0x80C7;          //Internal Clock, Div = 199

        /**
        *
        *  Port configuration options
        *
        **/

        public const UInt32 PORTCFG422_DEFAULT = 0x00000000;	//Select all default settings (XMT & RCV) (default)
        public const UInt32 PORTCFG422_RCVALL = 0x00000000;	//Recieve all data (RCV) (default)
        public const UInt32 PORTCFG422_RCVGOOD = 0x40000000;	//Receive only error free data (RCV)
        public const UInt32 PORTCFG422_SELFTEST = 0x00000004;	//Enable internal wraparound (XMT & RCV)
        public const UInt32 PORTCFG422_SELFTESTOFF = 0x00000000;	//Disable internal wraparound (XMT & RCV) (default)
        public const UInt32 PORTCFG422_ACTIVE = 0x00000000;	//Enable channel activity (XMT & RCV) (default)
        public const UInt32 PORTCFG422_INACTIVE = 0x00000040;	//Disable channel activity (XMT & RCV)
        public const UInt32 PORTCFG422_PARITYNONE = 0x00000000;	//Disable parity (XMT & RCV) (default)
        public const UInt32 PORTCFG422_PARITYODD = 0x00800000;	//Enable odd parity (XMT & RCV)
        public const UInt32 PORTCFG422_PARITYEVEN = 0x00400000;	//Enable even parity (XMT & RCV)
        public const UInt32 PORTCFG422_PARITYMARK = 0x00200000;	//Force set parity (XMT & RCV)
        public const UInt32 PORTCFG422_PARITYSPACE = 0x00100000;	//Force clear parity (XMT & RCV)
        public const UInt32 PORTCFG422_BUSINVERT = 0x80000000;	//Enable bus polarity inversion (XMT & RCV)
        public const UInt32 PORTCFG422_BUSINVERTOFF = 0x00000000;	//Disable bus polarity inversion (XMT & RCV) (default)
        public const UInt32 PORTCFG422_MODE232 = 0x08000000;	//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
        public const UInt32 PORTCFG422_MODE422 = 0x00000000;	//Enable RS-422 mode (balanced) (XMT) (default)

        /**
        *
        *  FIFO configuration options
        *
        **/

        public const UInt32 FIFOCFG422_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 FIFOCFG422_NONE = 0x00000000;	//Disable FIFO Events (default)
        public const UInt32 FIFOCFG422_TXTHRESHOLD = 0x00000001;	//Enable Transmit FIFO Threshold Event
        public const UInt32 FIFOCFG422_TXEMPTY = 0x00000002;	//Enable Transmit FIFO Empty Event
        public const UInt32 FIFOCFG422_RXTHRESHOLD = 0x00000004;	//Enable Receive FIFO Threshold Event
        public const UInt32 FIFOCFG422_RXFULL = 0x00000008;	//Enable Receive FIFO Full Event
        public const UInt32 FIFOCFG422_RXERROR = 0x00000010;	//Enable Receive Error Event

        /**
        *
        *  FIFO word configuration options
        *
        **/

        public const UInt32 WRDCFG422_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 WRDCFG422_GAPEN = 0x00008000;	//Enable the use of data as gap
        public const UInt32 WRDCFG422_GAPENOFF = 0x00000000;	//Disable the use of data as gap (default)
        public const UInt32 WRDCFG422_FRAMEERR = 0x00001000;	//Enable Frame Error
        public const UInt32 WRDCFG422_FRAMEERROFF = 0x00000000;	//Disable Frame Error (default)
        public const UInt32 WRDCFG422_PARERR = 0x00000800;	//Enable Parity Error
        public const UInt32 WRDCFG422_PARERROFF = 0x00000000;	//Disable Parity Error (default)
        public const UInt32 WRDCFG422_ATOMIC = 0x80000000;	//Enable atomic FIFO access
        public const UInt32 WRDCFG422_ATOMICOFF = 0x00000000;	//Disable atomic FIFO access (default)

        /**
        *
        *  FIFO gap configuration options
        *
        **/

        public const UInt32 GAPCFG422_DEFAULT = 0x00000000;	//Select all default settings

        /**
        *
        *  Bit fields of the FIFO status flags.
        *
        **/

        public const UInt32 WRDSTAT422_ANYERR = 0x0020;	//Any error
        public const UInt32 WRDSTAT422_BITERR = 0x0010;	//Any bit error
        public const UInt32 WRDSTAT422_NRZERR = 0x0008;	//Bit error (NRZ)
        public const UInt32 WRDSTAT422_EDGEERR = 0x0004;	//Bit error (Edge)
        public const UInt32 WRDSTAT422_PARERR = 0x0002;	//Parity error
        public const UInt32 WRDSTAT422_FRAMEERR = 0x0001;	//Frame error

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFG422_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFG422_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFG422_AMPLOFF = 0x00000001;	//Disables parametric amplitude control

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFO422_PARAM = 0x0001;	//Channel supports parametric control

    }	//end class
}	//end namespace
