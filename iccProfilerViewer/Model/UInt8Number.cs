using System;
using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class UInt8Number : IUIntXXNumber<byte>
    {
        private byte value;

        public UInt8Number(byte[] value)
        {
            Debug.Assert(value.Count() == 1, "count byte UInt8Number must be equal 1");

            this.value = value[0];
        }

        public byte Value
        {
            get
            {
                return value;
            }
        }
    }
}
