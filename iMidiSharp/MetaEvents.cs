using System;
using System.Collections.Generic;
using System.Text;

namespace iMidiSharp
{

    abstract class MetaEvent : TrackEvent
    {
        public const byte MetaEventIdentifierByte = 0xFF;
    }

    class EndOfTrack : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x2F, 0x00 });
                return bytes.ToArray();
            }
        }

        public EndOfTrack(DeltaTime deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }

    class Tempo : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x51, 0x03 });
                bytes.AddRange(Tools.Convert24BitNumberToByteArray(TempoValue));
                return bytes.ToArray();
            }
        }
        private uint _tempoValue;

        public uint TempoValue
        {
            get
            {
                return _tempoValue;
            }
            set
            {
                if (value > 0xFFFFFF)
                    throw new ArgumentOutOfRangeException("value", value, "Tempo value is outside of the allowed range (0 - 16777215");
                _tempoValue = value;
            }
        }

        public Tempo(DeltaTime deltaTime, TempoInputMode mode, uint tempo)
        {
            DeltaTime = deltaTime;

            if (mode == TempoInputMode.MicrosecondsPerQuarterNote)
                TempoValue = tempo;
            else
                TempoValue = 60000000 / tempo;
        }
    }

    class TimeSignature : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x58, 0x04, Numerator, NegativePowerOf2Denominator, MidiClocksBetweenMetronomeTicks, DemiSemiQuaversPerQuarterNote });
                return bytes.ToArray();
            }
        }
        public byte Numerator { get; set; }
        public byte NegativePowerOf2Denominator { get; set; }
        public byte MidiClocksBetweenMetronomeTicks { get; set; }
        public byte DemiSemiQuaversPerQuarterNote { get; set; }

        public TimeSignature(DeltaTime deltaTime, byte numerator, byte negativePowerOf2Denominator, byte midiClocksBetweenMetronomeTicks, byte demiSemiQuaversPerQuarterNote = 8)
        {
            DeltaTime = deltaTime;

            Numerator = numerator;
            NegativePowerOf2Denominator = negativePowerOf2Denominator;
            MidiClocksBetweenMetronomeTicks = midiClocksBetweenMetronomeTicks;
            DemiSemiQuaversPerQuarterNote = demiSemiQuaversPerQuarterNote;
        }
    }

    class KeySignature : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x59, 0x02, (byte)Sharps, Convert.ToByte(!IsMajorKey) });
                return bytes.ToArray();
            }
        }
        public bool IsMajorKey { get; set; }

        private sbyte _sharps;

        public sbyte Sharps
        {
            get
            {
                return _sharps;
            }
            set
            {
                if (value < -7 || value > 7)
                    throw new ArgumentOutOfRangeException("value", value, "Number of sharps specified is outside of the allowed range (-7 - 7");

                _sharps = value;
            }
        }
        public KeySignature(DeltaTime deltaTime, sbyte numberOfSharps, bool isMajorKey)
        {
            DeltaTime = deltaTime;

            Sharps = numberOfSharps;
            IsMajorKey = isMajorKey; // False signifies major.
        }

        public KeySignature(DeltaTime deltaTime, KeySignatures keySignature)
        {
            DeltaTime = deltaTime;

            IsMajorKey = keySignature.ToString("g").Contains("Major");
            Sharps = (sbyte)keySignature;
        }
    }

    class SequenceOrTrackName : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x03, _length });
                bytes.AddRange(Encoding.UTF8.GetBytes(Text));
                return bytes.ToArray();
            }
        }
        private string _text;
        private byte _length;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value.Length > byte.MaxValue)
                    throw new ArgumentOutOfRangeException("value", "Specified string is too long.");

                _text = value;
                _length = (byte)value.Length;
            }
        }

        public SequenceOrTrackName(DeltaTime deltaTime, string text)
        {
            DeltaTime = deltaTime;

            Text = text;
        }
    }

    class MidiPort : MetaEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { MetaEventIdentifierByte, 0x21, 0x01, Port });
                return bytes.ToArray();
            }
        }
        private byte _port;

        public byte Port
        {
            get
            {
                return _port;
            }
            set
            {
                if (value > 127)
                    throw new ArgumentOutOfRangeException("value", value, "Specified MIDI port is outside of the allowed range (0 - 127)");

                _port = value;
            }
        }

        public MidiPort(DeltaTime deltaTime, byte port)
        {
            DeltaTime = deltaTime;

            Port = port;
        }
    }
}
