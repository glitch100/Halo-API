using System;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public struct RawGuid : IFormattable, IComparable, IComparable<Guid>, IEquatable<RawGuid>
    {
        private readonly uint data1;
        private readonly ushort data2;
        private readonly ushort data3;
        private readonly ulong data4;
        private readonly Guid guid;
    
        public RawGuid(Guid guid)
        {
            var bytes = guid.ToByteArray();

            this.data1 = (uint)BitConverter.ToInt32(bytes, 0);
            this.data2 = (ushort)BitConverter.ToInt16(bytes, 4);
            this.data3 = (ushort)BitConverter.ToInt16(bytes, 6);
            this.data4 = (ulong)BitConverter.ToInt64(bytes, 8);
            this.guid = guid;
        }

        [JsonConstructor]
        public RawGuid(uint data1, ushort data2, ushort data3, ulong data4)
        {
            this.data1 = data1;
            this.data2 = data2;
            this.data3 = data3;
            this.data4 = data4;
            this.guid = new Guid((int)data1, (short)data2, (short)data3, BitConverter.GetBytes((long)data4));
        }

        public uint Data1 { get { return this.data1; } }
        public ushort Data2 { get { return this.data2; } }
        public ushort Data3 { get { return this.data3; } }
        public ulong Data4 { get { return this.data4; } }
    
        [JsonIgnore]
        public Guid Guid { get { return this.guid; } }

        public bool Equals(RawGuid other)
        {
            return this.guid.Equals(other.guid);
        }

        public override bool Equals(object obj)
        {
            return this.guid.Equals(obj);
        }

        public int CompareTo(Guid other)
        {
            return this.guid.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            return this.guid.CompareTo(obj);
        }

        public override int GetHashCode()
        {
            return this.guid.GetHashCode();
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return this.guid.ToString(format, provider);
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