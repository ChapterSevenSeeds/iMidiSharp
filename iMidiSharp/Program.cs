using iMidiSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                string input = Console.ReadLine();
                string todo;

                if (input.Length >= 5)
                    todo = input.Substring(0, 5).ToLower().Trim();
                else
                    todo = input.ToLower().Trim();

                if (todo == "start")
                    break;
                else if (todo == "test")
                {
                    Test();
                    return;
                }
                else
                {
                    string value = input.Substring(5);
                    if (todo == "vtnv")
                        Console.WriteLine($"Variable length quantity {value} to non-variable length quantity: {(uint.TryParse(value, out uint result) ? Tools.ConvertVariableLengthQuantityToRegular(result) : 0)}");
                    else if (todo == "nvtv")
                        Console.WriteLine($"Non-variable length quantity {value} to variable length quantity: {(uint.TryParse(value, out uint result) ? Tools.ConvertRegularQuantityToVariableLength(result) : 0)}");
                }
            }

            uint ppqn = 32767;

            MidiHeaderChunk header = new MidiHeaderChunk(MidiType.One, ushort.MaxValue, new TickDivSpecification((ushort)ppqn), false);

            DeltaTime zero = new DeltaTime(DeltaTimeInputMode.VariableLength, 0);
            DeltaTime currentNoteLength = new DeltaTime(DeltaTimeInputMode.NonVariableLength, ppqn * 4);
            DeltaTime one = new DeltaTime(DeltaTimeInputMode.VariableLength, 1);


            int trackMax = 480;//Can be ushort.maxvalue
            List<MidiTrackChunk> tracks = new List<MidiTrackChunk>();
            
            for(int i = 0; i < trackMax; i++)
            {
                tracks.Add(new MidiTrackChunk(header));
                tracks[i].AddTrackUnloader(@"E:\" + i, 1000);
                tracks[i].AddEvent(new SequenceOrTrackName(zero, "Piano."));
                tracks[i].AddEvent(new TimeSignature(zero, 4, 2, 0x18));
                tracks[i].AddEvent(new KeySignature(zero, KeySignatures.CMajor));
                tracks[i].AddEvent(new ProgramChange(zero, 1, 0));
                tracks[i].AddEvent(new SetControllerValue(zero, 1, MidiController.ResetAllControllers, 0));
                tracks[i].AddEvent(new SetControllerValue(zero, 1, MidiController.ChannelVolumeMSB, 0x64));
                tracks[i].AddEvent(new SetControllerValue(zero, 1, MidiController.PanMSB, 0x40));
                tracks[i].AddEvent(new SetControllerValue(zero, 1, MidiController.ReverbSendLevel, 0x00));
                tracks[i].AddEvent(new SetControllerValue(zero, 1, MidiController.ChorusSendLevel, 0x00));
                tracks[i].AddEvent(new MidiPort(zero, 0));
            }

            tracks[0].AddEvent(new Tempo(zero, TempoInputMode.QuarterNotesPerMinute, 120));

            int trackIndex = 0;
            DeltaTime currentTime;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Note count {Math.Pow(2, i)}");

                //currentNoteLength /= 2;

                //for (ulong k = 0; k < Math.Pow(2, i); ++k)
                //{
                //    ulong tick = (trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition;

                //    while (tick > 0x0FFFFFFF)
                //    {
                //        tracks[trackIndex].AddEvent(new TimeSignature(zero, 4, 2, 0x18));
                //        tick -= 0x0FFFFFFF;
                //    }

                //    currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)tick);
                //    tracks[trackIndex].AddEvent(new NoteOn(currentTime, 1, Notes.C4, 0x50));
                //    tracks[trackIndex].AddEvent(new NoteOff(currentNoteLength, 1, Notes.C4, 0x50));

                //    trackIndex++;
                //    if (trackIndex >= trackMax)
                //        trackIndex = 0;
                //}
            }

            currentNoteLength.SetDeltaTimeFromVariableLengthTime(0x818000);

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Note count {Math.Pow(2, i + 3)}");

                //currentNoteLength /= 2;

                //for (ulong k = 0; k < Math.Pow(2, i + 4); ++k)
                //{
                //    ulong tick = (trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition;

                //    while (tick > 0x0FFFFFFF)
                //    {
                //        tracks[trackIndex].AddEvent(new TimeSignature(zero, 4, 2, 0x18));
                //        tick -= 0x0FFFFFFF;
                //    }

                //    currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)tick);
                //    tracks[trackIndex].AddEvent(new NoteOn(currentTime, 1, Notes.C4, 0x50));
                //    tracks[trackIndex].AddEvent(new NoteOff(currentNoteLength, 1, Notes.C4, 0x50));

                //    trackIndex++;
                //    if (trackIndex >= trackMax)
                //        trackIndex = 0;
                //}
            }

            for (int i = 0; i < 18; i++)
            {
                Console.WriteLine($"Note count {Math.Pow(2, i + 18)}");

                //ulong tick = (trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition;
                //currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)tick);
                //tracks[trackIndex].AddEvent(new Tempo(currentTime, TempoInputMode.QuarterNotesPerMinute, (uint)(60000000 / Math.Pow(2, 19 - i))));

                //for (ulong k = 0; k < Math.Pow(2, i + 20); ++k)
                //{
                //    currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)((trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition));
                //    tracks[trackIndex].AddEvent(new NoteOn(currentTime, 1, Notes.C4, 0x50));
                //    tracks[trackIndex].AddEvent(new NoteOff(currentNoteLength, 1, Notes.C4, 0x50));

                //    while (tick > 0x0FFFFFFF)
                //    {
                //        tracks[trackIndex].AddEvent(new TimeSignature(zero, 4, 2, 0x18));
                //        tick -= 0x0FFFFFFF;
                //    }

                //    trackIndex++;
                //    if (trackIndex >= trackMax)
                //        trackIndex = 0;
                //}
            }

            Console.WriteLine($"Note count 65536000000");

            //ulong tick = (trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition;
            //currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)tick);
            //tracks[trackIndex].AddEvent(new Tempo(currentTime, TempoInputMode.QuarterNotesPerMinute, (uint)(60000000 / Math.Pow(2, 19 - i))));

            //for (ulong k = 0; k < Math.Pow(2, i + 20); ++k)
            //{
            //    currentTime = new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)((trackIndex == 0 ? tracks[trackMax - 1].TrackTickPosition : tracks[trackIndex - 1].TrackTickPosition) - tracks[trackIndex].TrackTickPosition));
            //    tracks[trackIndex].AddEvent(new NoteOn(currentTime, 1, Notes.C4, 0x50));
            //    tracks[trackIndex].AddEvent(new NoteOff(currentNoteLength, 1, Notes.C4, 0x50));

            //    while (tick > 0x0FFFFFFF)
            //    {
            //        tracks[trackIndex].AddEvent(new TimeSignature(zero, 4, 2, 0x18));
            //        tick -= 0x0FFFFFFF;
            //    }

            //    trackIndex++;
            //    if (trackIndex >= trackMax)
            //        trackIndex = 0;
            //}

            //foreach (MidiTrackChunk track in tracks)
            //{
            //    track.AddEvent(new EndOfTrack(one));
            //    header.AddTrack(track);
            //}

            //MidiFile myMidi = new MidiFile(@"E:\asdf.mid", header);

            //myMidi.WriteFile();
            //Console.WriteLine("Done");
            //Console.ReadLine();
        }

        static void Test()
        {
            MidiHeaderChunk header = new MidiHeaderChunk(MidiType.One, 2, new TickDivSpecification(32767), false);
            MidiTrackChunk track = new MidiTrackChunk(header);
            MidiTrackChunk tempoTrack = new MidiTrackChunk(header);

            DeltaTime zero = new DeltaTime(DeltaTimeInputMode.VariableLength, 0);
            DeltaTime currentNoteLength = new DeltaTime(DeltaTimeInputMode.NonVariableLength, 32767 * 16);
            DeltaTime one = new DeltaTime(DeltaTimeInputMode.VariableLength, 1);

            track.AddEvent(new SequenceOrTrackName(zero, "Piano."));
            track.AddEvent(new TimeSignature(zero, 4, 2, 0x18));
            track.AddEvent(new KeySignature(zero, KeySignatures.CMajor));
            track.AddEvent(new ProgramChange(zero, 1, 0));
            track.AddEvent(new SetControllerValue(zero, 1, MidiController.ResetAllControllers, 0));
            track.AddEvent(new SetControllerValue(zero, 1, MidiController.ChannelVolumeMSB, 0x64));
            track.AddEvent(new SetControllerValue(zero, 1, MidiController.PanMSB, 0x40));
            track.AddEvent(new SetControllerValue(zero, 1, MidiController.ReverbSendLevel, 0x00));
            track.AddEvent(new SetControllerValue(zero, 1, MidiController.ChorusSendLevel, 0x00));
            track.AddEvent(new MidiPort(zero, 0));

            tempoTrack.AddEvent(new Tempo(zero, TempoInputMode.QuarterNotesPerMinute, 60000000));

            for(int i = 0; i < 10000; i++)
            {
                track.AddEvent(new NoteOn(zero, 1, Notes.C4, 64));
                track.AddEvent(new NoteOff(currentNoteLength, 1, Notes.C4, 64));
            }

            tempoTrack.AddEvent(new EndOfTrack(one));
            track.AddEvent(new EndOfTrack(one));

            header.AddTrack(tempoTrack);
            header.AddTrack(track);

            MidiFile myMidi = new MidiFile(@"D:\No Backup\asdf.mid", header);

            myMidi.WriteFile();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}

namespace iMidiSharp
{
    class MidiFile
    {
        public string FilePath { get; private set; }
        public MidiHeaderChunk HeaderChunk { get; private set; }



        public MidiFile(string outputFile, MidiType type, ushort trackCount, ushort partsPerQuarterNote)
        {
            FilePath = outputFile;
            HeaderChunk = new MidiHeaderChunk(type, trackCount, new TickDivSpecification(partsPerQuarterNote));
        }


        public MidiFile(string outputFile, MidiType type, ushort trackCount, FPS fps, byte ticksPerFrame)
        {
            FilePath = outputFile;
            HeaderChunk = new MidiHeaderChunk(type, trackCount, new TickDivSpecification(fps, ticksPerFrame));
        }

        public MidiFile(string outputFile, MidiHeaderChunk headerChunk)
        {
            FilePath = outputFile;
            HeaderChunk = headerChunk;
        }

        public void WriteFile()
        {
            FileStream stream = File.Create(FilePath);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(HeaderChunk.HeaderBytes);

            foreach(MidiTrackChunk track in HeaderChunk.Tracks)
            {
                writer.Write(track.TrackHeaderBytes);

                if (track.Unloader == null)
                {
                    foreach (TrackEvent trackEvent in track.Events)
                    {
                        writer.Write(trackEvent.Bytes);
                    }
                }
                else
                {
                    track.Unloader.Compressor.CopyTo(writer.BaseStream);

                    track.Unloader.Close();

                }
            }

            writer.Close();
            stream.Close();
        }
    }








    #region Midi file chunks

    /*
    * Please remember that data types are stored in BIG ENDIAN format.
    */

    /// <summary>
    /// The component representing the header of the midi file.
    /// </summary>
    class MidiHeaderChunk
    {
        /*
        * The header chunk must appear at the start of every midi file.
        * The chunk appears as follows:
        * 
        * * {4 bytes} (Chunk type) MThd, {uint32} (chunk size) 6, {ushort} (midi type} [0, 1, or 2], {ushort} (track count), {16 bits} (tickdiv specification)
        */

        public const string HEADER_DECLARATION_STRING = "MThd";
        public const int HEADER_CHUNK_SIZE = 6;

        public ushort TrackCount { get; private set; }
        public TickDivSpecification TickDiv { get; private set; }
        public MidiType Type { get; private set; }
        public bool IsStrict { get; private set; }

        public List<MidiTrackChunk> Tracks { get; private set; }


        public byte[] HeaderBytes
        {
            get
            {
                List<byte> bytes = new List<byte>();

                // Add the MThd
                bytes.AddRange(Encoding.UTF8.GetBytes(HEADER_DECLARATION_STRING));
                // And then the size.
                bytes.AddRange(Tools.GetBytes(HEADER_CHUNK_SIZE));
                // Now the midi type
                bytes.AddRange(Tools.GetBytes((ushort)Type));
                // Now the track count
                bytes.AddRange(Tools.GetBytes(TrackCount));
                // Now the tickDiv
                bytes.AddRange(TickDiv.Bytes);

                return bytes.ToArray();
            }
        }

        /// <summary>
        /// Initializes a new midi file header chunk.
        /// </summary>
        /// <param name="type">Midi file format (0, 1, or 2).</param>
        /// <param name="trackCount">Number of tracks.</param>
        /// <param name="tickDivSpecification">The timing specification of the midi file.</param>
        /// <param name="isStrict">If true, any adjustments made to the midi tracks that do not match what was 
        /// specified to the midi header when created will throw exceptions.</param>
        public MidiHeaderChunk(MidiType type, ushort trackCount, TickDivSpecification tickDivSpecification, bool isStrict = false)
        {
            if (isStrict && type == MidiType.Zero && trackCount > 1)
                throw new ArgumentException("Midi format 1 only supports 1 track.");

            TickDiv = tickDivSpecification;
            Type = type;
            TrackCount = trackCount;
            IsStrict = isStrict;

            Tracks = new List<MidiTrackChunk>();
        }

        public void AddTrack(MidiTrackChunk track)
        {
            if (IsStrict)
            {
                if (Type == MidiType.Zero && Tracks.Count == 1)
                    throw new InvalidOperationException("Specified midi type does not allow more than one track.");

                if (Tracks.Count == TrackCount)
                    throw new InvalidOperationException("Specified track count is currently met and cannot be adjusted.");
            }

            if (Tracks.Count == ushort.MaxValue)
                throw new InvalidOperationException("Track count cannot exceed 65535.");

            Tracks.Add(track);

            TrackCount = (ushort)Tracks.Count;

            if (Tracks.Count > 1 && Type == MidiType.Zero)
                Type = MidiType.One;
        }
    }

    


    /// <summary>
    /// The component representing a MIDI track.
    /// </summary>
    class MidiTrackChunk
    {
        public const int END_OF_TRACK_BYTE_LENGTH = 3;
        public const string HEADER_DECLARATION_STRING = "MTrk";

        private bool trackIsEnded = false;

        /// <summary>
        /// Represents the header of the track chunk.
        /// Contains, in bytes, and in big endian order, {(string) MTrk, (int32) track length}
        /// </summary>
        public byte[] TrackHeaderBytes
        {
            get
            {
                List<byte> bytes = new List<byte>();

                // Add the MTrk
                bytes.AddRange(Encoding.UTF8.GetBytes(HEADER_DECLARATION_STRING));

                //Add the length of the track
                bytes.AddRange(Tools.GetBytes(TrackByteLength));

                return bytes.ToArray();
            }
        }

        /// <summary>
        /// The header pertaining to the midi file to which this track will be applied to.
        /// </summary>
        public MidiHeaderChunk HeaderChunk { get; private set; }

        /// <summary>
        /// Represents the current delta time position in the track in traditional format (not variable-length).
        /// It is automatically advanced when events are added to the track.
        /// </summary>
        public ulong TrackTickPosition { get; private set; }

        /// <summary>
        /// Represents the current byte length of the track.
        /// </summary>
        public uint TrackByteLength { get; private set; }

        /// <summary>
        /// Represents the events of the track.
        /// </summary>
        internal List<TrackEvent> Events { get; private set; }

        public TrackUnloader Unloader { get; private set; } = null;

        public MidiTrackChunk(MidiHeaderChunk headerChunk)
        {
            HeaderChunk = headerChunk;
            TrackTickPosition = 0;

            Events = new List<TrackEvent>();
        }

        public void AddEvent(TrackEvent trackEvent)
        {
            if (TrackByteLength + trackEvent.Bytes.Length + END_OF_TRACK_BYTE_LENGTH > uint.MaxValue)
                throw new InvalidOperationException("Track only has enough space left for an end of track event.");

            if (trackIsEnded)
                throw new InvalidOperationException("This track cannot append events because there exists an End of Track event.");

            Events.Add(trackEvent);
            TrackByteLength += (uint)trackEvent.Bytes.Length;
            TrackTickPosition += Tools.ConvertVariableLengthQuantityToRegular(trackEvent.DeltaTime.Value);

            if (trackEvent is EndOfTrack)
            {
                trackIsEnded = true;

                if (Unloader != null)
                {
                    Unloader.Unload();
                    Unloader.PrepareForAggregation();
                }
            }
            else if (Unloader != null)
            {
                if (Events.Count >= Unloader.TrackEventThreshold)
                    Unloader.Unload();
            }
        }

        public void AddTrackUnloader(string fileName, int trackEventThreshold)
        {
            Unloader = new TrackUnloader(fileName, trackEventThreshold, this);
        }
    }

    #endregion

    #region Misc components

    /// <summary>
    /// The final 16 bits of a Midi File Header Chunk. 
    /// Specifies the timing format of the midi file.
    /// There are two formats for this and they are 
    /// specified in the constructors.
    /// </summary>
    class TickDivSpecification
    {
        public ushort TickDiv { get; private set; }
        public byte[] Bytes
        {
            get
            {
                return Tools.GetBytes(TickDiv);
            }
        }

        /// <summary>
        /// Sets tickDiv to 0b0_{15 bits, partsPerQuarterNote}.
        /// </summary>
        /// <param name="partsPerQuarterNote">Ticks per quarter note (0 - 32767).</param>
        public TickDivSpecification(ushort partsPerQuarterNote)
        {
            if (partsPerQuarterNote > 0x7FFF)
                throw new ArgumentOutOfRangeException("partsPerQuarterNote", "Parts per quarter note specified is outside of the allowed range (0 - 32767).");

            TickDiv = 0;
            TickDiv |= partsPerQuarterNote;
        }

        /// <summary>
        /// Sets tickDiv to 0b1_{7 bits, 2's complement representation of FPS}_{ticksPerFrame}.
        /// </summary>
        /// <param name="fps">One of the 4 SMPTE FPS standards.</param>
        /// <param name="ticksPerFrame">Ticks per frame (0 - 255)</param>
        public TickDivSpecification(FPS fps, byte ticksPerFrame)
        {
            TickDiv = 0b10000000_00000000;
            TickDiv |= (ushort)(((sbyte)fps & 0b01111111) << 8);
            TickDiv |= ticksPerFrame;
        }
    }

    /// <summary>
    /// Represents a variable-length time delay from the previous MIDI event 
    /// for a new MIDI event.
    /// </summary>
    struct DeltaTime
    {
        public static DeltaTime MaxValue = new DeltaTime(DeltaTimeInputMode.VariableLength, 0xFFFFFF7F);

        private uint _value;
        private byte[] _bytes;

        /// <summary>
        /// The byte array representation of the DeltaTime value.
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                return _bytes;
            }
            private set
            {
                _bytes = value;
            }
        }

        /// <summary>
        /// The unsigned integer representation of the variable-length DeltaTime value.
        /// </summary>
        public uint Value
        {
            get
            {
                return _value;
            }
            private set
            {
                if (value > 0xFFFFFF7F)
                    throw new ArgumentOutOfRangeException("quantity", value, "Variable-length quantity is out of the accepted range (0 - 4294967167)");

                _value = value;
                Bytes = Tools.ConvertVariableLengthQuantityToByteArray(_value);
            }
        }

        /// <summary>
        /// Returns the byte length of the DeltaTime value.
        /// </summary>
        public int ByteLength
        {
            get
            {
                return Bytes.Length;
            }
        }

        /// <summary>
        /// Constructs a new DeltaTime object.
        /// </summary>
        /// <param name="mode">Specifies the format of the input value.</param>
        /// <param name="input">The delta time value.</param>
        public DeltaTime(DeltaTimeInputMode mode, uint input) : this()
        {
            if (mode == DeltaTimeInputMode.NonVariableLength)
                SetDeltaTimeFromRegularValue(input);
            else
                SetDeltaTimeFromVariableLengthTime(input);
        }

        /// <summary>
        /// Converts a non-variable-length value to the corresponding variable-length quantity and sets the internal value accordingly.
        /// </summary>
        /// <param name="input">The non-variable-length input value (0 - 268435455).</param>
        public void SetDeltaTimeFromRegularValue(uint input)
        {
            Value = Tools.ConvertRegularQuantityToVariableLength(input);
        }

        /// <summary>
        /// Assigns the specified variable-length quantity to the interal DeltaTime value.
        /// </summary>
        /// <param name="input">The variable-length input value (0 - 4294967167).</param>
        public void SetDeltaTimeFromVariableLengthTime(uint input)
        {
            Value = input;
        }


        public static DeltaTime operator /(DeltaTime leftHand, int rightHand)
        {
            return new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)(Tools.ConvertVariableLengthQuantityToRegular(leftHand.Value) / rightHand));
        }

        public static DeltaTime operator *(DeltaTime leftHand, int rightHand)
        {
            return new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)(Tools.ConvertVariableLengthQuantityToRegular(leftHand.Value) * rightHand));
        }

        public static DeltaTime operator +(DeltaTime leftHand, uint rightHand)
        {
            return new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)(Tools.ConvertVariableLengthQuantityToRegular(leftHand.Value) + rightHand));
        }

        public static DeltaTime operator -(DeltaTime leftHand, uint rightHand)
        {
            return new DeltaTime(DeltaTimeInputMode.NonVariableLength, (uint)(Tools.ConvertVariableLengthQuantityToRegular(leftHand.Value) - rightHand));
        }
    }

    class TrackUnloader
    {
        public int TrackEventThreshold { get; set; }
        public string FileName { get; set; }
        public GZipStream Compressor { get; private set; }
        public FileStream Stream { get; private set; }
        private MidiTrackChunk Track { get; set; }

        public TrackUnloader(string fileName, int trackEventThreshold, MidiTrackChunk track)
        {
            Track = track;
            TrackEventThreshold = trackEventThreshold;
            Stream = File.Create(fileName);
            Compressor = new GZipStream(Stream, CompressionLevel.Optimal);
            FileName = fileName;
        }

        public void PrepareForAggregation()
        {
            Compressor.Close();
            Stream = File.OpenRead(FileName);
            Compressor = new GZipStream(Stream, CompressionMode.Decompress);
        }

        public void Close()
        {
            Compressor.Close();
            Stream.Close();
            File.Delete(FileName);
        }

        public void Unload()
        {
            foreach(TrackEvent eventItem in Track.Events)
            {
                Compressor.Write(eventItem.Bytes);
            }

            Track.Events.Clear();
        }
    }

    #endregion

    /// <summary>
    /// Various tools.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Converts an unsigned short to a big-endian order byte array.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The corresponding byte array in big-endian order.</returns>
        public static byte[] GetBytes(ushort input)
        {
            return new byte[] { (byte)(input >> 8), (byte)input };
        }

        /// <summary>
        /// Converts an integer to a big-endian order byte array.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The corresponding byte array in big-endian order.</returns>
        public static byte[] GetBytes(int input)
        {
            return new byte[] { (byte)(input >> 24), (byte)(input >> 16), (byte)(input >> 8), (byte)input };
        }

        /// <summary>
        /// Converts an unsigned integer to a big-endian order byte array.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The corresponding byte array in big-endian order.</returns>
        public static byte[] GetBytes(uint input)
        {
            return GetBytes((int)input);
        }

        /// <summary>
        /// Converts the smaller 24 bits of an unsigned integer to a big-endian order byte array.
        /// This is currently only used to set the tempo in a midi track.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The corresponding 3-element byte array in big-endian order.</returns>
        public static byte[] Convert24BitNumberToByteArray(uint input)
        {
            return new byte[] { (byte)(input >> 16), (byte)(input >> 8), (byte)input };
        }

        /// <summary>
        /// Converts a non-variable length unsigned integer to the corresponding variable-length quantity.
        /// </summary>
        /// <param name="quantity">The input value (0 - 268435455).</param>
        /// <returns>The corresponding variable-length quantity.</returns>
        public static uint ConvertRegularQuantityToVariableLength(uint quantity)
        {
            if (quantity > 0x0FFFFFFF)
                throw new ArgumentOutOfRangeException("quantity", "Non-variable-length quantity is outside the accepted range (0 - 268435455)");

            uint newValue = quantity;

            uint smallByteShiftMask = 0b11111111_11111111_11111111_10000000;
            uint middleByteShiftMask = 0b11111111_11111111_10000000_00000000;
            uint largeByteShiftMask = 0b11111111_10000000_00000000_00000000;

            if (newValue > 0b01111111)
            {
                newValue = ((newValue & smallByteShiftMask) << 1) | (newValue & ~smallByteShiftMask);
                newValue = ((newValue & middleByteShiftMask) << 1) | (newValue & ~middleByteShiftMask) | 0b10000000_00000000;
            }
            else
                return quantity;
            
            if(newValue > 0b11111111_11111111)
                newValue = ((newValue & largeByteShiftMask) << 1) | (newValue & ~largeByteShiftMask) | 0b10000000_10000000_00000000;

            if (newValue > 0b11111111_11111111_11111111)
                newValue |= 0b10000000_10000000_10000000_00000000;

            return newValue;
        }

        /// <summary>
        /// Converts a variable-length quantity to the corresponding fixed-length value.
        /// </summary>
        /// <param name="quantity">The input value (0 - 4294967167).</param>
        /// <returns>The corresponding fixed-length value.</returns>
        public static uint ConvertVariableLengthQuantityToRegular(uint quantity)
        {
            if (quantity > 0xFFFFFF7F)
                throw new ArgumentOutOfRangeException("quantity", "Variable-length quantity is out of the accepted range (0 - 4294967167)");

            uint newValue = quantity;

            uint smallByteShiftMask = 0b11111111_11111111_11111111_00000000;
            uint middleByteShiftMask = 0b11111111_11111111_00000000_00000000;
            uint largeByteShiftMask = 0b11111111_00000000_00000000_00000000;

            if (newValue > 0b11111111_11111111_11111111)
                newValue &= 0b01111111_11111111_11111111_11111111;

            if (newValue > 0b11111111_11111111)
                newValue = ((newValue & largeByteShiftMask) >> 1) | (newValue & ((~largeByteShiftMask) >> 1));

            if (newValue > 0b01111111)
            {
                newValue = ((newValue & middleByteShiftMask) >> 1) | (newValue & ((~middleByteShiftMask) >> 1));
                newValue = ((newValue & smallByteShiftMask) >> 1) | (newValue & ((~smallByteShiftMask) >> 1));
            }
            else
                return quantity;

            return newValue;
        }

        /// <summary>
        /// Converts a variable-length quantity to the corresponding byte array of the appropriate size. 
        /// </summary>
        /// <param name="quantity">The variable-length quantity (0 - 4294967167).</param>
        /// <returns>The corresponding byte array of the appropriate size (1-4 bytes).</returns>
        public static byte[] ConvertVariableLengthQuantityToByteArray(uint quantity)
        {
            if (quantity > 0xFFFFFF7F)
                throw new ArgumentOutOfRangeException("quantity", "Variable-length quantity is out of the accepted range (0 - 4294967167)");

            if (quantity > 0b11111111_11111111_11111111)
                return GetBytes((int)quantity);
            if (quantity > 0b11111111_11111111)
                return new byte[] { (byte)(quantity >> 16), (byte)(quantity >> 8), (byte)quantity };
            if (quantity > 0b01111111)
                return new byte[] { (byte)(quantity >> 8), (byte)quantity };
            else
                return new byte[] { (byte)quantity };
        }
    }
}