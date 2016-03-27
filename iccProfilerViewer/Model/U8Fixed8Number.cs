using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class U8Fixed8Number
    {
        private const double DENOMINATOR = 256.0;

        private int fractional;
        private int integral;
        private double value;

        public U8Fixed8Number(byte[] value)
        {
            Debug.Assert(value.Count() == 2, "count byte U8Fixed8Number must be equal 2");

            this.integral = value[0];
            this.fractional = value[1];

            this.value = this.integral + (this.fractional / DENOMINATOR);
        }

        public double Value
        {
            get
            {
                return value;
            }
        }
    }
}
