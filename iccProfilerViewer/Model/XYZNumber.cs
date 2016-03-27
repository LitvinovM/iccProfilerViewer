using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class XYZNumber
    {
        private s15Fixed16Number x;
        private s15Fixed16Number y;
        private s15Fixed16Number z;
        
        public XYZNumber(byte[] value)
        {
            Debug.Assert(value.Count() == 12, "count byte XYZNumber must be equal 12");

            this.x = new s15Fixed16Number(value.Skip(0).Take(4).ToArray());
            this.y = new s15Fixed16Number(value.Skip(4).Take(4).ToArray());
            this.z = new s15Fixed16Number(value.Skip(8).Take(4).ToArray());
        }

        public s15Fixed16Number X
        {
            get
            {
                return x;
            }
        }

        public s15Fixed16Number Y
        {
            get
            {
                return y;
            }
        }

        public s15Fixed16Number Z
        {
            get
            {
                return z;
            }
        }
    }
}
