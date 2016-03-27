using System;
using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class UInt64Number : IUIntXXNumber<ulong>
    {
        private ulong value;

        public UInt64Number(byte[] value)
        {
            Debug.Assert(value.Count() == 8, "count byte UInt64Number must be equal 8");

            this.value = (ulong)(value[0]
                | value[1] << 48
                | value[2] << 40
                | value[3] << 32
                | value[4] << 24
                | value[5] << 16
                | value[6] << 8
                | value[7]);
        }

        public ulong Value
        {
            get
            {
                return value;
            }
        }
    }
}
