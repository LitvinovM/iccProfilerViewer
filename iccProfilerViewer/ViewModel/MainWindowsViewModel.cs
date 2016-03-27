using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using iccProfilerViewer.Model;
using MVVMModelBase;

namespace iccProfilerViewer.ViewModel
{
    public class MainWindowsViewModel : PropertyChangedBase
    {
        private IccProfile model;

        public MainWindowsViewModel(MainWindow mainWindows)
        {
            this.BindOpenCommandEvent(mainWindows);
            this.BindCloseCommandEvent(mainWindows);
        }

        public string CmmType
        {
            get { return Encoding.Default.GetString(this.model?.CmmType.ToArray() ?? new byte[0]); }
        }

        public ProfileVersionNumberViewer ProfileVersion
        {
            get { return new ProfileVersionNumberViewer(this.model?.ProfileVersion); }
        }

        public string ProfileClass
        {
            get { return Encoding.Default.GetString(this.model?.ProfileClass.ToArray() ?? new byte[0]); }
        }

        public string ColorSpaceOfData
        {
            get { return Encoding.Default.GetString(this.model?.ColorSpaceOfData.ToArray() ?? new byte[0]); }
        }

        public string ProfileConnectionSpace
        {
            get { return Encoding.Default.GetString(this.model?.ProfileConnectionSpace.ToArray() ?? new byte[0]); }
        }

        public ProfileDateTimeViewer DateAndTimeCreated
        {
            get { return new ProfileDateTimeViewer(this.model?.DateAndTimeCreated); }
        }

        public string PrimaryPlatform
        {
            get { return Encoding.Default.GetString(this.model?.PrimaryPlatform.ToArray() ?? new byte[0]); }
        }

        public string RenderIntent
        {
            get { return Encoding.Default.GetString(this.model?.RenderIntent.ToArray() ?? new byte[0]); }
        }

        public XYZNumberViewer XYZValue
        {
            get { return new XYZNumberViewer(this.model?.XYZValue); }
        }

        public UIntXXNumberViewer<uint> TagCount
        {
            get { return new UIntXXNumberViewer<uint>(this.model?.TagCount); }
        }

        public ObservableCollection<TagStructuresViewer> TagStructures
        {
            get { return new ObservableCollection<TagStructuresViewer>((this.model?.TagStructures.Select(z => new TagStructuresViewer(z)) ?? Enumerable.Empty<TagStructuresViewer>())); }
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".icc";
            dlg.Filter = "International Color Consortium (*.icc)|*.icc|International Color Consortium (*.icm)|*.icm";

            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;

                model = new IccProfile(File.ReadAllBytes(filename));

                foreach (var prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    this.RaisePropertyChanged(prop.Name);
                }
            }
        }

        private void BindCloseCommandEvent(MainWindow mainWindows)
        {
            var bindingClose = new CommandBinding();
            bindingClose.Command = ApplicationCommands.Close;
            bindingClose.Executed += new ExecutedRoutedEventHandler((z, x) => mainWindows.Close());
            mainWindows.CommandBindings.Add(bindingClose);
        }

        private void BindOpenCommandEvent(MainWindow mainWindows)
        {
            var bindingOpen = new CommandBinding();
            bindingOpen.Command = ApplicationCommands.Open;
            bindingOpen.Executed += new ExecutedRoutedEventHandler(OpenCommandBinding_Executed);
            mainWindows.CommandBindings.Add(bindingOpen);
        }
    }
}
