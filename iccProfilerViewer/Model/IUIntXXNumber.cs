namespace iccProfilerViewer.Model
{
    public interface IUIntXXNumber<TValie> where TValie : struct
    {
        TValie Value { get; }
    }
}
