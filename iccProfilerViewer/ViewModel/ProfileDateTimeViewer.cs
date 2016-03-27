using iccProfilerViewer.Model;

namespace iccProfilerViewer.ViewModel
{
    public class ProfileDateTimeViewer
    {
        private ProfileDateTime dateTime;

        public ProfileDateTimeViewer(ProfileDateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public override string ToString()
        {
            if (dateTime == null)
            {
                return string.Empty;
            }

            return string.Format("{0:00}.{1:00}.{2:0000}", dateTime.Day, dateTime.Month, dateTime.Year);
        }
    }
}
