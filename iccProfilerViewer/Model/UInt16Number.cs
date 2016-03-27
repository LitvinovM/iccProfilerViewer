using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class UInt16Number : IUIntXXNumber<ushort>
    {
        private ushort value;

        public UInt16Number(byte[] value)
        {
            Debug.Assert(value.Count() == 2, "count byte UInt16Number must be equal 2");

            this.value = (ushort) ((value[0] << 8) | value[1]);
        }

        public ushort Value
        {
            get
            {
                return value;
            }
        }
    }
}
