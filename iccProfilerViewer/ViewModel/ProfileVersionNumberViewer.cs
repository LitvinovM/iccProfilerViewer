using iccProfilerViewer.Model;

namespace iccProfilerViewer.ViewModel
{
    public class ProfileVersionNumberViewer
    {
        private ProfileVersionNumber version;

        public ProfileVersionNumberViewer(ProfileVersionNumber version)
        {
            this.version = version;
        }

        public override string ToString()
        {
            if (version == null)
            {
                return string.Empty;
            }

            return string.Format("{0}.{1}", version.GetMajorRevision, version.GetMinorRevision);
        }
    }
}
