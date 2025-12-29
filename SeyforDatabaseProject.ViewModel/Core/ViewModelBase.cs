using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// A base for all ViewModels containing changeable properties.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public virtual void Dispose() { }
    }
}