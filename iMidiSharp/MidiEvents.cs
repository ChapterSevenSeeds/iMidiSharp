using System;
using System.Collections.Generic;
using System.Text;

namespace iMidiSharp
{
    abstract class TrackEvent
    {
        public DeltaTime DeltaTime { get; set; }
        public abstract byte[] Bytes { get; }
    }

    abstract class MidiEvent : TrackEvent
    {
        private byte _channel;

        /// <summary>
        /// The one-based midi channel to which this midi event pertains.
        /// </summary>
        public byte Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                if (value > 16 || value < 1)
                    throw new ArgumentOutOfRangeException("channel", value, "Channel number is outside of the allowed range (1, 16).");

                _channel = value;
            }
        }
    }

    abstract class MidiNoteEvent : MidiEvent
    {
        private byte _velocity;
        private Notes _note;

        public Notes Note
        {
            get
            {
                return _note;
            }
            private set
            {
                _note = value;
            }
        }
        public byte Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                if (value > 127)
                    throw new ArgumentOutOfRangeException("velocity", value, "Specified velocity is outside of the allowed range (0 - 127)");

                _velocity = value;
            }
        }

        public void SetNoteValue(Notes note)
        {
            if (note > Notes.ADoubleFlat9 || note < Notes.BSharpMinus2)
                throw new ArgumentOutOfRangeException("note", "Specified note value is outside of the allowed range (C-1 - G9)");

            Note = note;
        }
        public void SetNoteValue(byte note)
        {
            if (note > 127)
                throw new ArgumentOutOfRangeException("note", "Specified note value is outside of the allowed range (0 - 127)");

            Note = (Notes)note;
        }
    }

    class NoteOff : MidiNoteEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { (byte)((8 << 4) | (Channel - 1)), (byte)Note, Velocity });
                return bytes.ToArray();
            }
        }
        public NoteOff(DeltaTime deltaTime, byte channel, Notes note, byte velocity)
        {
            Channel = channel;
            SetNoteValue(note);
            Velocity = velocity;

            DeltaTime = deltaTime;
        }

        public NoteOff(DeltaTime deltaTime, byte channel, byte note, byte velocity) : this(deltaTime, channel, (Notes)note, velocity) { }
    }

    class NoteOn : MidiNoteEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { (byte)((9 << 4) | (Channel - 1)), (byte)Note, Velocity });
                return bytes.ToArray();
            }
        }
        public NoteOn(DeltaTime deltaTime, byte channel, Notes note, byte velocity)
        {
            Channel = channel;
            SetNoteValue(note);
            Velocity = velocity;

            DeltaTime = deltaTime;
        }

        public NoteOn(DeltaTime deltaTime, byte channel, byte note, byte velocity) : this(deltaTime, channel, (Notes)note, velocity) { }
    }

    class SetControllerValue : MidiEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { (byte)((0xB << 4) | (Channel - 1)), (byte)Controller, Value });
                return bytes.ToArray();
            }
        }
        private byte _value;
        private MidiController _controller;

        public MidiController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                if ((byte)value > 127 || (byte)value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Specified controller is outside of the allowed range (0 - 127)");

                _controller = value;
            }
        }

        public byte Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value > 127)
                    throw new ArgumentOutOfRangeException("value", value, "Specified value is outside of the allowed range (0 - 127)");

                _value = value;
            }
        }
        public SetControllerValue(DeltaTime deltaTime, byte channel, MidiController controller, byte value)
        {
            DeltaTime = deltaTime;
            Channel = channel;
            Controller = controller;
            Value = value;
        }

        public SetControllerValue(DeltaTime deltaTime, byte channel, byte controller, byte value) : this(deltaTime, channel, (MidiController)controller, value) { }
    }

    class ProgramChange : MidiEvent
    {
        public override byte[] Bytes
        {
            get
            {
                List<byte> bytes = new List<byte>();
                bytes.AddRange(DeltaTime.Bytes);
                bytes.AddRange(new byte[] { (byte)((0xC << 4) | (Channel - 1)), Program });
                return bytes.ToArray();
            }
        }
        private byte _program;

        public byte Program
        {
            get
            {
                return _program;
            }
            set
            {
                if (value > 127)
                    throw new ArgumentOutOfRangeException("value", value, "Specified controller is outside of the allowed range (0 - 127)");

                _program = value;
            }
        }
        public ProgramChange(DeltaTime deltaTime, byte channel, byte program)
        {
            DeltaTime = deltaTime;

            Channel = channel;
            Program = program;
        }
    }
}
