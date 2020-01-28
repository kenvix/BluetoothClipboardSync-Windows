using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kenvix.ClipboardSync.Feature.Preferences;
using Kenvix.ClipboardSync.Utils;

namespace Kenvix.ClipboardSync.Feature.Bluetooth
{
    public class RfcommCommunicator
    {
        private readonly Stream stream;
        private readonly BinaryWriter writer;
        private readonly BinaryReader reader;

        public RfcommCommunicator(Stream stream)
        {
            if (!stream.CanRead || !stream.CanWrite)
                throw new ArgumentException("Stream must can be read and write");

            this.stream = stream;
            this.writer = new BinaryWriter(stream);
            this.reader = new BinaryReader(stream);
        }

        public void WriteData(byte type, byte options = 0, byte[] data = null)
        {
            stream.WriteByte(type); //Type

            if (data != null)
            {
                var isCompressed = (options & RfcommFrame.OptionCompressed) > 0;
                byte[] outputData;

                if (isCompressed || data.Length > MainPreferences.minGzipCompressSize)
                {
                    options = (byte) (options | RfcommFrame.OptionCompressed);
                    isCompressed = true;
                    outputData = GzipCompressUtils.Compress(data);
                }
                else
                {
                    outputData = data;
                }

                stream.WriteByte(options);
                writer.Write((short) outputData.Length);
                writer.Write(data);

                if (isCompressed)
                    writer.Write((short) data.Length);
            }
            else
            {
                writer.Write((short) 0);
            }
        }

        public void WriteData(RfcommFrame frame)
        {
            WriteData(frame.type, frame.option, frame.data);
        }

        public RfcommFrame ReadData()
        {
            byte type = reader.ReadByte();
            byte option = reader.ReadByte();
            short length = reader.ReadInt16();
            byte[] data = null;

            if (length > 0)
            {
                data = new byte[length];
                reader.Read(data, 0, length);

                if ((option & RfcommFrame.OptionCompressed) > 0)
                {
                    short actualLength = reader.ReadInt16();
                    data = GzipCompressUtils.Decompress(data);
                    length = actualLength;
                }
                
            }

            return new RfcommFrame(type, option, length, data);
        }
    }
}
