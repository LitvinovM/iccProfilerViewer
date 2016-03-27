using iccProfilerViewer.Model;

namespace iccProfilerViewer.ViewModel
{
    public class UIntXXNumberViewer<TValue> where TValue : struct
    {
        private IUIntXXNumber<TValue> uIntXXNumber;

        public UIntXXNumberViewer(IUIntXXNumber<TValue> uIntXXNumber)
        {
            this.uIntXXNumber = uIntXXNumber;
        }

        public override string ToString()
        {
            if (uIntXXNumber == null)
            {
                return string.Empty;
            }

            return uIntXXNumber.Value.ToString();
        }
    }
}
