using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class ProfileDateTime
    {
        private byte[] dateTime;

        public ProfileDateTime(byte[] version)
        {
            Debug.Assert(version.Count() == 12, "count byte Profile datetime must be equal 4");
            this.dateTime = version;
        }

        public byte[] DateTime
        {
            get
            {
                return this.dateTime;
            }
        }

        public int Year
        {
            get
            {
                return (this.dateTime[0] << 8) | this.dateTime[1];
            }
        }

        public int Month
        {
            get
            {
                return (this.dateTime[2] << 8) | this.dateTime[3];
            }
        }

        public int Day
        {
            get
            {
                return (this.dateTime[4] << 8) | this.dateTime[5];
            }
        }

        public int Hours
        {
            get
            {
                return (this.dateTime[6] << 8) | this.dateTime[7];
            }
        }

        public int Minutes
        {
            get
            {
                return (this.dateTime[8] << 8) | this.dateTime[9];
            }
        }

        public int Seconds
        {
            get
            {
                return (this.dateTime[10] << 8) | this.dateTime[11];
            }
        }
    }
}
