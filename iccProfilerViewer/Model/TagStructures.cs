using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class TagStructures
    {
        private byte[] tag;

        public TagStructures(byte[] tag)
        {
            Debug.Assert(tag.Count() == 12, "count byte TagStructures must be equal 12");
            this.tag = tag;
        }

        public byte[] Signature
        {
            get
            {
                return this.tag.Take(4).ToArray();
            }
        }

        public UInt32Number Offset
        {
            get
            {
                return new UInt32Number(this.tag.Skip(4).Take(4).ToArray());
            }
        }

        public UInt32Number ElementSize
        {
            get
            {
                return new UInt32Number(this.tag.Skip(8).Take(4).ToArray());
            }
        }
    }
}
