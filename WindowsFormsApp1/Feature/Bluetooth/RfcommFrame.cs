using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenvix.ClipboardSync.Feature.Bluetooth
{
    public class RfcommFrame
    {
        public readonly byte type;
        public readonly byte option;
        public readonly short length;
        public readonly byte[] data = null;

        public const byte OptionNone = 0b0000000;
        public const byte OptionCompressed = 0b0000001;
        public const byte OptionPartial = 0b0000010;
        public const byte OptionEncrypted = 0b0000100;
        public const byte OptionTest = 0b1000000;
        public const byte OptionMessageError = 0b0100000;
        public const byte OptionMessageSuccess = 0b0010000;

        public const byte TypeUpdateClipboard = 0x11;
        public const byte TypeEmergency = 0x18;
        public const byte TypePing = 0x01;
        public const byte TypePong = 0x02;
        public const byte TypeHello = 0x03;

        public RfcommFrame(byte type, byte option, short length, byte[] data = null)
        {
            this.type = type;
            this.option = option;
            this.length = length;
            this.data = data;
        }

        public override int GetHashCode()
        {
            return 31 + type ^ option ^ length ^ (data == null ? 0 : data.GetHashCode());
        }
    }
}
