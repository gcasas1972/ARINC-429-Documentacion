using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTIDIO
    {
        /**
        *
        *  BTIDIO WIN32 DRIVER  Version 1.1.2  (03/02/2010)
        *  Copyright (c) 2005-2010
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTIDIONET.CS -- 32-bit
        *                      BTIDIO Driver Include Header File.
        *
        **/

        /**
        *
        *  BTIDIO Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTIDIO Driver.
        *
        **/

        private static class BTIDIO_32
        {
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankConfig(UInt32 configval, UInt16 threshold, UInt16 samplerate, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankFaultClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTIDIO_BankFaultClr(byte mask, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankFaultRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTIDIO_BankFaultRd(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankIsDIO@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankIsDIO(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTIDIO_BankRd(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankStart(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankStop(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankWr(byte value, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankWrMask@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankWrMask(byte value, byte mask, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_DiscreteConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteConfig(UInt32 configval, Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_DiscreteRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteRd(Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_DiscreteWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteWr(Int32 value, Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankClear(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankGetCount@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankGetCount(UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTIDIO_BankGetInfo(UInt16 infotype, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankGetSampleRate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankGetSampleRate(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankGetThreshold@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankGetThreshold(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankSetSampleRate@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankSetSampleRate(UInt16 samplerate, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_BankSetThreshold@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankSetThreshold(UInt16 threshold, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_DiscreteGetCount@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteGetCount(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DllUsageCount();
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_GetBankCount@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_GetBankCount(UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_IsBank@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_IsBank(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO.DLL", EntryPoint = "_BTIDIO_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_TestProtocol(UInt32 handleval);
        }

        private static class BTIDIO_64
        {
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankConfig(UInt32 configval, UInt16 threshold, UInt16 samplerate, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankFaultClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTIDIO_BankFaultClr(byte mask, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankFaultRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTIDIO_BankFaultRd(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankIsDIO", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankIsDIO(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTIDIO_BankRd(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankStart(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankStop(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankWr(byte value, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankWrMask", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankWrMask(byte value, byte mask, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_DiscreteConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteConfig(UInt32 configval, Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_DiscreteRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteRd(Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_DiscreteWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteWr(Int32 value, Int32 ionum, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankClear(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_BankGetCount(UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTIDIO_BankGetInfo(UInt16 infotype, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankGetSampleRate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankGetSampleRate(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankGetThreshold", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankGetThreshold(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankSetSampleRate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankSetSampleRate(UInt16 samplerate, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_BankSetThreshold", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTIDIO_BankSetThreshold(UInt16 threshold, Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_DiscreteGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DiscreteGetCount(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_DllUsageCount();
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_GetBankCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_GetBankCount(UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_IsBank", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_IsBank(Int32 banknum, UInt32 handleval);
            [DllImport("BTIDIO64.DLL", EntryPoint = "BTIDIO_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTIDIO_TestProtocol(UInt32 handleval);
        }

        public static Int32 BTIDIO_BankConfig(UInt32 configval, UInt16 threshold, UInt16 samplerate, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankConfig(configval, threshold, samplerate, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankConfig(configval, threshold, samplerate, banknum, handleval);
        }
        public static void BTIDIO_BankFaultClr(byte mask, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTIDIO_32.BTIDIO_BankFaultClr(mask, banknum, handleval);
            else
                BTIDIO_64.BTIDIO_BankFaultClr(mask, banknum, handleval);
        }
        public static byte BTIDIO_BankFaultRd(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankFaultRd(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankFaultRd(banknum, handleval);
        }
        public static Int32 BTIDIO_BankIsDIO(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankIsDIO(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankIsDIO(banknum, handleval);
        }
        public static byte BTIDIO_BankRd(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankRd(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankRd(banknum, handleval);
        }
        public static Int32 BTIDIO_BankStart(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankStart(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankStart(banknum, handleval);
        }
        public static Int32 BTIDIO_BankStop(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankStop(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankStop(banknum, handleval);
        }
        public static Int32 BTIDIO_BankWr(byte value, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankWr(value, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankWr(value, banknum, handleval);
        }
        public static Int32 BTIDIO_BankWrMask(byte value, byte mask, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankWrMask(value, mask, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankWrMask(value, mask, banknum, handleval);
        }
        public static Int32 BTIDIO_DiscreteConfig(UInt32 configval, Int32 ionum, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_DiscreteConfig(configval, ionum, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_DiscreteConfig(configval, ionum, banknum, handleval);
        }
        public static Int32 BTIDIO_DiscreteRd(Int32 ionum, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_DiscreteRd(ionum, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_DiscreteRd(ionum, banknum, handleval);
        }
        public static Int32 BTIDIO_DiscreteWr(Int32 value, Int32 ionum, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_DiscreteWr(value, ionum, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_DiscreteWr(value, ionum, banknum, handleval);
        }
        public static Int32 BTIDIO_BankClear(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankClear(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankClear(banknum, handleval);
        }
        public static Int32 BTIDIO_BankGetCount(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankGetCount(handleval);
            else
                return BTIDIO_64.BTIDIO_BankGetCount(handleval);
        }
        public static UInt32 BTIDIO_BankGetInfo(UInt16 infotype, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankGetInfo(infotype, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankGetInfo(infotype, banknum, handleval);
        }
        public static UInt16 BTIDIO_BankGetSampleRate(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankGetSampleRate(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankGetSampleRate(banknum, handleval);
        }
        public static UInt16 BTIDIO_BankGetThreshold(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankGetThreshold(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankGetThreshold(banknum, handleval);
        }
        public static UInt16 BTIDIO_BankSetSampleRate(UInt16 samplerate, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankSetSampleRate(samplerate, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankSetSampleRate(samplerate, banknum, handleval);
        }
        public static UInt16 BTIDIO_BankSetThreshold(UInt16 threshold, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_BankSetThreshold(threshold, banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_BankSetThreshold(threshold, banknum, handleval);
        }
        public static Int32 BTIDIO_DiscreteGetCount(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_DiscreteGetCount(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_DiscreteGetCount(banknum, handleval);
        }
        public static Int32 BTIDIO_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_DllUsageCount();
            else
                return BTIDIO_64.BTIDIO_DllUsageCount();
        }
        public static Int32 BTIDIO_GetBankCount(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_GetBankCount(handleval);
            else
                return BTIDIO_64.BTIDIO_GetBankCount(handleval);
        }
        public static Int32 BTIDIO_IsBank(Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_IsBank(banknum, handleval);
            else
                return BTIDIO_64.BTIDIO_IsBank(banknum, handleval);
        }
        public static Int32 BTIDIO_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTIDIO_32.BTIDIO_TestProtocol(handleval);
            else
                return BTIDIO_64.BTIDIO_TestProtocol(handleval);
        }

        /**
        *
        *  Bank number constants
        *
        **/

        public const UInt32 BANKA = 0x0000;           //Bank A
        public const UInt32 BANKB = 0x0001;           //Bank B
        public const UInt32 BANKC = 0x0002;           //Bank C
        public const UInt32 BANKD = 0x0003;           //Bank D

        /**
        *
        *  Bank configuration options
        *
        **/

        public const UInt32 BANKCFGDIO_DEFAULT = 0x00000000;	//Select all default settings (in & out) (default)
        public const UInt32 BANKCFGDIO_INPUT = 0x00000000;	//Select input mode (in) (default)
        public const UInt32 BANKCFGDIO_OUTPUT = 0x00000001;	//Select output mode (out)
        public const UInt32 BANKCFGDIO_INOUT = 0x00000002;	//Select concurrent input and output mode (in & out)
        public const UInt32 BANKCFGDIO_SERIES = 0x00000000;	//Select series mode (in) (default)
        public const UInt32 BANKCFGDIO_SHUNT = 0x00000004;	//Select shunt mode (in)
        public const UInt32 BANKCFGDIO_POLIN_INVOFF = 0x00000000;	//Disable polarity inversion for bank input (in) (default)
        public const UInt32 BANKCFGDIO_POLIN_INV = 0x00000100;	//Enable polarity inversion for bank input (in)
        public const UInt32 BANKCFGDIO_POLOUT_INVOFF = 0x00000000;	//Disable polarity inversion for bank output (out) (default)
        public const UInt32 BANKCFGDIO_POLOUT_INV = 0x00000200;	//Enable polarity inversion for bank output (out)
        public const UInt32 BANKCFGDIO_ACTIVE = 0x00000000;	//Enable bank activity (in & out) (default)
        public const UInt32 BANKCFGDIO_INACTIVE = 0x00000010;	//Disables bank activity (in & out)
        public const UInt32 BANKCFGDIO_SEQSEL = 0x00000000;	//Sequential monitoring of selected transitions (in & out) (default)
        public const UInt32 BANKCFGDIO_SEQALL = 0x00000020;	//Every transition will be recorded in the Sequential Record (in & out)
        public const UInt32 BANKCFGDIO_NOLOGFAULT = 0x00000000;	//No entry will be made in the Event Log List when an output detects a fault (out) (default)
        public const UInt32 BANKCFGDIO_LOGFAULT = 0x00000040;	//An entry will be made in the Event Log List when an output detects a fault (out)
        public const UInt32 BANKCFGDIO_NOLOGEDGE = 0x00000000;	//No entry will be made in the Event Log List when an input detects an edge (in) (default)
        public const UInt32 BANKCFGDIO_LOGEDGE = 0x00000080;	//An entry will be made in the Event Log List when an input detects an edge (in)
        public const UInt32 BANKCFGDIO_LOGALL = 0x000000C0;	//An entry will be made in the Event Log List when an input detects an edge and when an output detects a fault (in & out)

        public const UInt32 THRESHOLDDIO_TTL = 0x00F0;	//Corresponds to a 1.4V switching threshold (TTL)
        public const UInt32 THRESHOLDDIO_CMOS = 0x01B0;	//Corresponds to a 2.5V switching threshold (CMOS)
        public const UInt32 THRESHOLDDIO_1_4V = 0x00F0;	//Corresponds to a 1.4V switching threshold
        public const UInt32 THRESHOLDDIO_2_5V = 0x01B0;	//Corresponds to a 2.5V switching threshold
        public const UInt32 THRESHOLDDIO_5V = 0x0370;	//Corresponds to a 5V switching threshold
        public const UInt32 THRESHOLDDIO_7V = 0x04D0;	//Corresponds to a 7V switching threshold
        public const UInt32 THRESHOLDDIO_12V = 0x0850;	//Corresponds to a 12V switching threshold
        public const UInt32 THRESHOLDDIO_16V = 0x0B10;	//Corresponds to a 16V switching threshold
        public const UInt32 THRESHOLDDIO_10KOHM = 0x00F0;	//Corresponds to approx. 10kOhm switching threshold (Shunt)
        public const UInt32 THRESHOLDDIO_25KOHM = 0x01B0;	//Corresponds to approx. 25kOhm switching threshold (Shunt)
        public const UInt32 THRESHOLDDIO_100KOHM = 0x0300;	//Corresponds to approx. 100kOhm switching threshold (Shunt)

        public const UInt32 SAMPLERATEDIO_US = 0x0000;	//Corresponds to a 1us base sample clock
        public const UInt32 SAMPLERATEDIO_MS = 0x8000;	//Corresponds to a 1ms base sample clock

        /**
        *
        *  Discrete configuration options
        *
        **/

        public const UInt32 DISCCFGDIO_DEFAULT = 0x00000000;	//Select all default settings (in & out) (default)
        public const UInt32 DISCCFGDIO_INPUT = 0x00000000;	//Select input mode (in) (default)
        public const UInt32 DISCCFGDIO_OUTPUT = 0x00000001;	//Select output mode (out)
        public const UInt32 DISCCFGDIO_INOUT = 0x00000002;	//Select concurrent input and output mode (in & out)
        public const UInt32 DISCCFGDIO_POLIN_INVOFF = 0x00000000;	//Disable polarity inversion for input (in) (default)
        public const UInt32 DISCCFGDIO_POLIN_INV = 0x00000004;	//Enable polarity inversion for input (in)
        public const UInt32 DISCCFGDIO_POLOUT_INVOFF = 0x00000000;	//Disable polarity inversion for output (out) (default)
        public const UInt32 DISCCFGDIO_POLOUT_INV = 0x00000008;	//Enable polarity inversion for output (out)
        public const UInt32 DISCCFGDIO_SEQNONE = 0x00000000;	//No transitions for this input will be recorded in the Sequential Record (in & out) (default)
        public const UInt32 DISCCFGDIO_SEQPOSEDGE = 0x00000010;	//Positive transitions for this input will be recorded in the Sequential Record (in & out)
        public const UInt32 DISCCFGDIO_SEQNEGEDGE = 0x00000020;	//Negative transitions for this input will be recorded in the Sequential Record (in & out)
        public const UInt32 DISCCFGDIO_SEQANYEDGE = 0x00000030;	//Every transition for this input will be recorded in the Sequential Record (in & out)
        public const UInt32 DISCCFGDIO_NOLOGEDGE = 0x00000000;	//No transitions for this input will create an entry in the Event Log List (in & out) (default)
        public const UInt32 DISCCFGDIO_LOGPOSEDGE = 0x00000040;	//Positive transitions for this input will create an entry in the Event Log List (in & out)
        public const UInt32 DISCCFGDIO_LOGNEGEDGE = 0x00000080;	//Negative transitions for this input will create an entry in the Event Log List (in & out)
        public const UInt32 DISCCFGDIO_LOGANYEDGE = 0x000000C0;	//Every transition for this input will create an entry in the Event Log List (in & out)
        public const UInt32 DISCCFGDIO_NOLOGFAULT = 0x00000000;	//No faults for this output will create an entry in the Event Log List (out) (default)
        public const UInt32 DISCCFGDIO_LOGFAULT = 0x00000100;	//Every fault for this output will create an entry in the Event Log List (out)
        public const UInt32 DISCCFGDIO_LOGALL = 0x000001C0;	//Every transition for this input and every fault for this output will create an entry in the Event Log Lit (in/out)

        /**
        *
        *  Bank info fields.
        *
        **/

        public const UInt32 INFODIO_INPUT = 0x0001;	//Bank is input capable
        public const UInt32 INFODIO_OUTPUT = 0x0002;	//Bank is output capable
        public const UInt32 INFODIO_SERIES = 0x0004;	//Bank is series capable
        public const UInt32 INFODIO_SHUNT = 0x0008;	//Bank is shunt capable

    }	//end class
}	//end namespace
