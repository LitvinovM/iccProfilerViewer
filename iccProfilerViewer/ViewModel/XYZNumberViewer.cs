using iccProfilerViewer.Model;

namespace iccProfilerViewer.ViewModel
{
    public class XYZNumberViewer
    {
        private XYZNumber xyzNumber;

        public XYZNumberViewer(XYZNumber xyzNumber)
        {
            this.xyzNumber = xyzNumber;
        }

        public override string ToString()
        {
            if (xyzNumber == null)
            {
                return string.Empty;
            }

            return string.Format("xyz = '{0:0.000}' '{1:0.000}' '{2:0.000}'", xyzNumber.X.Value, xyzNumber.Y.Value, xyzNumber.Z.Value);
        }
    }
}
