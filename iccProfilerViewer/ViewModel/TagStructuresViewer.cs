using System.Text;
using iccProfilerViewer.Model;

namespace iccProfilerViewer.ViewModel
{
    public class TagStructuresViewer
    {
        private TagStructures tagStructures;

        public TagStructuresViewer(TagStructures tagStructures)
        {
            this.tagStructures = tagStructures;
        }

        public string Signature
        {
            get
            {
                return Encoding.Default.GetString(this.tagStructures?.Signature ?? new byte[0]);
            }
        }

        public uint Offset
        {
            get
            {
                return this.tagStructures?.Offset.Value ?? 0;
            }
        }

        public uint ElementSize
        {
            get
            {
                return this.tagStructures?.ElementSize.Value ?? 0;
            }
        }
        
        public override string ToString()
        {
            if (tagStructures == null)
            {
                return string.Empty;
            }

            return string.Format("Signature '{0}' start index '{1}'", this.Signature, this.Offset);
        }
    }
}
