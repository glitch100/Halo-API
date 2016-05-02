using System;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public struct RawGuid : IFormattable, IComparable, IComparable<Guid>, IEquatable<RawGuid>
    {
        private readonly uint _data1;
        private readonly ushort _data2;
        private readonly ushort _data3;
        private readonly ulong _data4;
        private readonly Guid guid;
    
        public RawGuid(Guid guid)
        {
            var bytes = guid.ToByteArray();

            _data1 = (uint)BitConverter.ToInt32(bytes, 0);
            _data2 = (ushort)BitConverter.ToInt16(bytes, 4);
            _data3 = (ushort)BitConverter.ToInt16(bytes, 6);
            _data4 = (ulong)BitConverter.ToInt64(bytes, 8);
            this.guid = guid;
        }

        [JsonConstructor]
        public RawGuid(uint data1, ushort data2, ushort data3, ulong data4)
        {
            _data1 = data1;
            _data2 = data2;
            _data3 = data3;
            _data4 = data4;
            guid = new Guid((int)data1, (short)data2, (short)data3, BitConverter.GetBytes((long)data4));
        }

        public uint Data1 { get { return _data1; } }
        public ushort Data2 { get { return _data2; } }
        public ushort Data3 { get { return _data3; } }
        public ulong Data4 { get { return _data4; } }
    
        [JsonIgnore]
        public Guid Guid { get { return guid; } }

        public bool Equals(RawGuid other)
        {
            return guid.Equals(other.guid);
        }

        public override bool Equals(object obj)
        {
            return guid.Equals(obj);
        }

        public int CompareTo(Guid other)
        {
            return guid.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            return guid.CompareTo(obj);
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return guid.ToString(format, provider);
        }

        public static bool operator ==(RawGuid left, RawGuid right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RawGuid left, RawGuid right)
        {
            return !left.Equals(right);
        }
    }
}