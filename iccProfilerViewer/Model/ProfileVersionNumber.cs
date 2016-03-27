using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class ProfileVersionNumber
    {
        private byte[] version;

        public ProfileVersionNumber(byte[] version)
        {
            Debug.Assert(version.Count() == 4, "count byte Profile version must be equal 4");
            this.version = version;
        }

        public byte[] Version
        {
            get
            {
                return this.version;
            }
        }

        public int GetMajorRevision
        {
            get
            {
                return this.version[0];
            }
        }

        public int GetMinorRevision
        {
            get
            {
                return this.version[1];
            }
        }
    }
}
