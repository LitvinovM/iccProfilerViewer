﻿using System.Diagnostics;
using System.Linq;

namespace iccProfilerViewer.Model
{
    public class s15Fixed16Number
    {
        private const double DENOMINATOR = 65536.0;
        
        private int fractional;
        private int integral;
        private double value;

        public s15Fixed16Number(byte[] value)
        {
            Debug.Assert(value.Count() == 4, "count byte s15Fixed16Number must be equal 4");

            this.integral = (short)((value[0] << 8) | value[1]);
            this.fractional = (value[2] << 8) | value[3];

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
