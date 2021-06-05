using System;
using System.Collections.Generic;
using System.Text;

namespace iMidiSharp
{
    public enum MidiType
    {
        Zero,
        One,
        Two
    }

    public enum FPS
    {
        SMPTE24 = -24,
        SMPTE25 = -25,
        SMPTE29 = -29,
        SMPTE30 = -30
    }

    public enum Notes
    {
        BSharpMinus2 = 0,
        CMinus1 = 0,

        BDoubleSharpMinus2 = 1,
        CSharpMinus1 = 1,
        DFlatMinus1 = 1,

        CDoubleSharpMinus1 = 2,
        DMinus1 = 2,
        EDoubleFlatMinus1 = 2,

        DSharpMinus1 = 3,
        EFlatMinus1 = 3,
        FDoubleFlatMinus1 = 3,

        DDoubleSharpMinus1 = 4,
        EMinus1 = 4,
        FFlatMinus1 = 4,

        ESharpMinus1 = 5,
        FMinus1 = 5,
        GDoubleFlatMinus1 = 5,

        EDoubleSharpMinus1 = 6,
        FSharpMinus1 = 6,
        GFlatMinus1 = 6,

        FDoubleSharpMinus1 = 7,
        GMinus1 = 7,
        ADoubleFlatMinus1 = 7,

        GSharpMinus1 = 8,
        AFlatMinus1 = 8,

        GDoubleSharpMinus1 = 9,
        AMinus1 = 9,
        BDoubleFlatMinus1 = 9,

        ASharpMinus1 = 10,
        BFlatMinus1 = 10,
        CDoubleFlat0 = 10,

        ADoubleSharpMinus1 = 11,
        BMinus1 = 11,
        CFlat0 = 11,

        BSharpMinus1 = 12,
        C0 = 12,
        DDoubleFlat0 = 12,

        BDoubleSharpMinus1 = 13,
        CSharp0 = 13,
        DFlat0 = 13,

        CDoubleSharp0 = 14,
        D0 = 14,
        EDoubleFlat0 = 14,

        DSharp0 = 15,
        EFlat0 = 15,
        FDoubleFlat0 = 15,

        DDoubleSharp0 = 16,
        E0 = 16,
        FFlat0 = 16,

        ESharp0 = 17,
        F0 = 17,
        GDoubleFlat0 = 17,

        EDoubleSharp0 = 18,
        FSharp0 = 18,
        GFlat0 = 18,

        FDoubleSharp0 = 19,
        G0 = 19,
        ADoubleFlat0 = 19,

        GSharp0 = 20,
        AFlat0 = 20,

        // This is the lowest note on the typical piano
        GDoubleSharp0 = 21,
        A0 = 21,
        BDoubleFlat0 = 21,

        ASharp0 = 22,
        BFlat0 = 22,
        CDoubleFlat1 = 22,

        ADoubleSharp0 = 23,
        B0 = 23,
        CFlat1 = 23,

        BSharp0 = 24,
        C1 = 24,
        DDoubleFlat1 = 24,

        BDoubleSharp0 = 25,
        CSharp1 = 25,
        DFlat1 = 25,

        CDoubleSharp1 = 26,
        D1 = 26,
        EDoubleFlat1 = 26,

        DSharp1 = 27,
        EFlat1 = 27,
        FDoubleFlat1 = 27,

        DDoubleSharp1 = 28,
        E1 = 28,
        FFlat1 = 28,

        ESharp1 = 29,
        F1 = 29,
        GDoubleFlat1 = 29,

        EDoubleSharp1 = 30,
        FSharp1 = 30,
        GFlat1 = 30,

        FDoubleSharp1 = 31,
        G1 = 31,
        ADoubleFlat1 = 31,

        GSharp1 = 32,
        AFlat1 = 32,

        GDoubleSharp1 = 33,
        A1 = 33,
        BDoubleFlat1 = 33,

        ASharp1 = 34,
        BFlat1 = 34,
        CDoubleFlat2 = 34,

        ADoubleSharp1 = 35,
        B1 = 35,
        CFlat2 = 35,

        BSharp1 = 36,
        C2 = 36,
        DDoubleFlat2 = 36,

        BDoubleSharp1 = 37,
        CSharp2 = 37,
        DFlat2 = 37,

        CDoubleSharp2 = 38,
        D2 = 38,
        EDoubleFlat2 = 38,

        DSharp2 = 39,
        EFlat2 = 39,
        FDoubleFlat2 = 39,

        DDoubleSharp2 = 40,
        E2 = 40,
        FFlat2 = 40,

        ESharp2 = 41,
        F2 = 41,
        GDoubleFlat2 = 41,

        EDoubleSharp2 = 42,
        FSharp2 = 42,
        GFlat2 = 42,

        FDoubleSharp2 = 43,
        G2 = 43,
        ADoubleFlat2 = 43,

        GSharp2 = 44,
        AFlat2 = 44,

        GDoubleSharp2 = 45,
        A2 = 45,
        BDoubleFlat2 = 45,

        ASharp2 = 46,
        BFlat2 = 46,
        CDoubleFlat3 = 46,

        ADoubleSharp2 = 47,
        B2 = 47,
        CFlat3 = 47,

        BSharp2 = 48,
        C3 = 48,
        DDoubleFlat3 = 48,

        BDoubleSharp2 = 49,
        CSharp3 = 49,
        DFlat3 = 49,

        CDoubleSharp3 = 50,
        D3 = 50,
        EDoubleFlat3 = 50,

        DSharp3 = 51,
        EFlat3 = 51,
        FDoubleFlat3 = 51,

        DDoubleSharp3 = 52,
        E3 = 52,
        FFlat3 = 52,

        ESharp3 = 53,
        F3 = 53,
        GDoubleFlat3 = 53,

        EDoubleSharp3 = 54,
        FSharp3 = 54,
        GFlat3 = 54,

        FDoubleSharp3 = 55,
        G3 = 55,
        ADoubleFlat3 = 55,

        GSharp3 = 56,
        AFlat3 = 56,

        GDoubleSharp3 = 57,
        A3 = 57,
        BDoubleFlat3 = 57,

        ASharp3 = 58,
        BFlat3 = 58,
        CDoubleFlat4 = 58,

        ADoubleSharp3 = 59,
        B3 = 59,
        CFlat4 = 59,

        BSharp3 = 60,
        C4 = 60,
        DDoubleFlat4 = 60,

        BDoubleSharp3 = 61,
        CSharp4 = 61,
        DFlat4 = 61,

        CDoubleSharp4 = 62,
        D4 = 62,
        EDoubleFlat4 = 62,

        DSharp4 = 63,
        EFlat4 = 63,
        FDoubleFlat4 = 63,

        DDoubleSharp4 = 64,
        E4 = 64,
        FFlat4 = 64,

        ESharp4 = 65,
        F4 = 65,
        GDoubleFlat4 = 65,

        EDoubleSharp4 = 66,
        FSharp4 = 66,
        GFlat4 = 66,

        FDoubleSharp4 = 67,
        G4 = 67,
        ADoubleFlat4 = 67,

        GSharp4 = 68,
        AFlat4 = 68,

        GDoubleSharp4 = 69,
        A4 = 69,
        BDoubleFlat4 = 69,

        ASharp4 = 70,
        BFlat4 = 70,
        CDoubleFlat5 = 70,

        ADoubleSharp4 = 71,
        B4 = 71,
        CFlat5 = 71,

        BSharp4 = 72,
        C5 = 72,
        DDoubleFlat5 = 72,

        BDoubleSharp4 = 73,
        CSharp5 = 73,
        DFlat5 = 73,

        CDoubleSharp5 = 74,
        D5 = 74,
        EDoubleFlat5 = 74,

        DSharp5 = 75,
        EFlat5 = 75,
        FDoubleFlat5 = 75,

        DDoubleSharp5 = 76,
        E5 = 76,
        FFlat5 = 76,

        ESharp5 = 77,
        F5 = 77,
        GDoubleFlat5 = 77,

        EDoubleSharp5 = 78,
        FSharp5 = 78,
        GFlat5 = 78,

        FDoubleSharp5 = 79,
        G5 = 79,
        ADoubleFlat5 = 79,

        GSharp5 = 80,
        AFlat5 = 80,

        GDoubleSharp5 = 81,
        A5 = 81,
        BDoubleFlat5 = 81,

        ASharp5 = 82,
        BFlat5 = 82,
        CDoubleFlat6 = 82,

        ADoubleSharp5 = 83,
        B5 = 83,
        CFlat6 = 83,

        BSharp5 = 84,
        C6 = 84,
        DDoubleFlat6 = 84,

        BDoubleSharp5 = 85,
        CSharp6 = 85,
        DFlat6 = 85,

        CDoubleSharp6 = 86,
        D6 = 86,
        EDoubleFlat6 = 86,

        DSharp6 = 87,
        EFlat6 = 87,
        FDoubleFlat6 = 87,

        DDoubleSharp6 = 88,
        E6 = 88,
        FFlat6 = 88,

        ESharp6 = 89,
        F6 = 89,
        GDoubleFlat6 = 89,

        EDoubleSharp6 = 90,
        FSharp6 = 90,
        GFlat6 = 90,

        FDoubleSharp6 = 91,
        G6 = 91,
        ADoubleFlat6 = 91,

        GSharp6 = 92,
        AFlat6 = 92,

        GDoubleSharp6 = 93,
        A6 = 93,
        BDoubleFlat6 = 93,

        ASharp6 = 94,
        BFlat6 = 94,
        CDoubleFlat7 = 94,

        ADoubleSharp6 = 95,
        B6 = 95,
        CFlat7 = 95,

        BSharp6 = 96,
        C7 = 96,
        DDoubleFlat7 = 96,

        BDoubleSharp6 = 97,
        CSharp7 = 97,
        DFlat7 = 97,

        CDoubleSharp7 = 98,
        D7 = 98,
        EDoubleFlat7 = 98,

        DSharp7 = 99,
        EFlat7 = 99,
        FDoubleFlat7 = 99,

        DDoubleSharp7 = 100,
        E7 = 100,
        FFlat7 = 100,

        ESharp7 = 101,
        F7 = 101,
        GDoubleFlat7 = 101,

        EDoubleSharp7 = 102,
        FSharp7 = 102,
        GFlat7 = 102,

        FDoubleSharp7 = 103,
        G7 = 103,
        ADoubleFlat7 = 103,

        GSharp7 = 104,
        AFlat7 = 104,

        GDoubleSharp7 = 105,
        A7 = 105,
        BDoubleFlat7 = 105,

        ASharp7 = 106,
        BFlat7 = 106,
        CDoubleFlat8 = 106,

        ADoubleSharp7 = 107,
        B7 = 107,
        CFlat8 = 107,

        // This is the highest note on the typical piano.
        BSharp7 = 108,
        C8 = 108,
        DDoubleFlat8 = 108,

        BDoubleSharp7 = 109,
        CSharp8 = 109,
        DFlat8 = 109,

        CDoubleSharp8 = 110,
        D8 = 110,
        EDoubleFlat8 = 110,

        DSharp8 = 111,
        EFlat8 = 111,
        FDoubleFlat8 = 111,

        DDoubleSharp8 = 112,
        E8 = 112,
        FFlat8 = 112,

        ESharp8 = 113,
        F8 = 113,
        GDoubleFlat8 = 113,

        EDoubleSharp8 = 114,
        FSharp8 = 114,
        GFlat8 = 114,

        FDoubleSharp8 = 115,
        G8 = 115,
        ADoubleFlat8 = 115,

        GSharp8 = 116,
        AFlat8 = 116,

        GDoubleSharp8 = 117,
        A8 = 117,
        BDoubleFlat8 = 117,

        ASharp8 = 118,
        BFlat8 = 118,
        CDoubleFlat9 = 118,

        ADoubleSharp8 = 119,
        B8 = 119,
        CFlat9 = 119,

        BSharp8 = 120,
        C9 = 120,
        DDoubleFlat9 = 120,

        BDoubleSharp8 = 121,
        CSharp9 = 121,
        DFlat9 = 121,

        CDoubleSharp9 = 122,
        D9 = 122,
        EDoubleFlat9 = 122,

        DSharp9 = 123,
        EFlat9 = 123,
        FDoubleFlat9 = 123,

        DDoubleSharp9 = 124,
        E9 = 124,
        FFlat9 = 124,

        ESharp9 = 125,
        F9 = 125,
        GDoubleFlat9 = 125,

        EDoubleSharp9 = 126,
        FSharp9 = 126,
        GFlat9 = 126,

        FDoubleSharp9 = 127,
        G9 = 127,
        ADoubleFlat9 = 127,
    }

    public enum DeltaTimeInputMode
    {
        VariableLength,
        NonVariableLength
    }

    public enum KeySignatures
    {
        CMajor = 0,
        AMinor = 0,

        GMajor = 1,
        EMinor = 1,

        DMajor = 2,
        BMinor = 2,

        AMajor = 3,
        FSharpMinor = 3,

        EMajor = 4,
        CSharpMinor = 4,

        BMajor = 5,
        GSharpMinor = 5,

        FSharpMajor = 6,
        DSharpMinor = 6,

        CSharpMajor = 7,
        ASharpMinor = 7,

        FMajor = -1,
        DMinor = -1,

        BFlatMajor = -2,
        GMinor = -2,

        EFlatMajor = -3,
        CMinor = -3,

        AFlatMajor = -4,
        FMinor = -4,

        DFlatMajor = -5,
        BFlatMinor = -5,

        GFlatMajor = -6,
        EFlatMinor = -6,

        CFlatMajor = -7,
        AFlatMinor = -7
    }

    public enum MidiController
    {
        BankSelectMSB = 0,
        ModulationWheelMSB = 1,
        BreathControllerMSB = 2,
        FootControllerMSB = 4,
        PortamentoTimeMSB = 5,
        DataEntryMSB = 6,
        ChannelVolumeMSB = 7,
        BalanceMSB = 8,
        PanMSB = 10,
        ExpressionControllerMSB = 11,
        EffectControl1MSB = 12,
        EffectControl2MSB = 13,
        GeneralPurposeController1MSB = 16,
        GeneralPurposeController2MSB = 17,
        GeneralPurposeController3MSB = 18,
        GeneralPurposeController4MSB = 19,

        BankSelectLSB = 32,
        ModulationWheelLSB = 33,
        BreathControllerLSB = 34,
        FootControllerLSB = 36,
        PortamentoTimeLSB = 37,
        DataEntryLSB = 38,
        ChannelVolumeLSB = 39,
        BalanceLSB = 40,
        PanLSB = 42,
        ExpressionControllerLSB = 43,
        EffectControl1LSB = 44,
        EffectControl2LSB = 45,
        GeneralPurposeController1LSB = 48,
        GeneralPurposeController2LSB = 49,
        GeneralPurposeController3LSB = 50,
        GeneralPurposeController4LSB = 51,

        SustainSwitch = 64,
        PortamentoSwitch = 65,
        SostenutoSwitch = 66,
        SoftPedalSwitch = 67,
        LegatoSwitch = 68,
        Hold2Switch = 69,

        SoundController1 = 70,
        SoundController2 = 71,
        SoundController3 = 72,
        SoundController4 = 73,
        SoundController5 = 74,
        SoundController6 = 75,
        SoundController7 = 76,
        SoundController8 = 77,
        SoundController9 = 78,
        SoundController10 = 79,
        GeneralPurposeController5 = 80,
        GeneralPurposeController6 = 81,
        GeneralPurposeController7 = 82,
        GeneralPurposeController8 = 83,
        PortamentoControl = 84,
        HighResolutionVelocityPrefix = 88,
        ReverbSendLevel = 91,
        TremeloDepth = 92,
        ChorusSendLevel = 93,
        CelesteDepth = 94,
        PhaserDepth = 95,

        DataIncrement = 96,
        DataDecrement = 97,
        NonRegisteredParameterNumberLSB = 98,
        NonRegisteredParameterNumberMSB = 99,
        RegisteredParameterNumberLSB = 100,
        RegisteredParameterNumberMSB = 101,

        AllSoundOff = 120,
        ResetAllControllers = 121,
        LocalControlSwitch = 122,
        AllNotesOff = 123,
        OmniModeOff = 124,
        OmniModeOn = 125,
        MonoModeOn = 126,
        PolyModeOn = 127
    }

    public enum TempoInputMode
    {
        MicrosecondsPerQuarterNote,
        QuarterNotesPerMinute
    }
}
