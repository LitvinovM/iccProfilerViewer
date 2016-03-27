using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMModelBase
{
    /// <summary>
    /// Enables automatic RaisePropertyChanged transformation for class or property
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MagicAttribute : Attribute { }

    /// <summary>
    /// Disables automatic RaisePropertyChanged transformation for class or property
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class NoMagicAttribute : Attribute { }

    /// <summary>
    /// Base class for automatic INotifyPropertyChanged transformation in property setters
    /// </summary>
    [Magic]
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Indicates RaisePropertyChanged injection point 
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static void Raise() { }

        protected virtual void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            var e = PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
