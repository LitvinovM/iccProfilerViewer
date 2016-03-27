using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class UInt32Number : IUIntXXNumber<uint>
    {
        private uint value;

        public UInt32Number(byte[] value)
        {
            Debug.Assert(value.Count() == 4, "count byte UInt32Number must be equal 4");

            this.value = (uint)(value[0] << 24
                | value[1] << 16
                | value[2] << 8
                | value[3]);
        }

        public uint Value
        {
            get
            {
                return value;
            }
        }
    }
}
