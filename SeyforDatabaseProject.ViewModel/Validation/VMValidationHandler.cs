using System.Collections;
using System.ComponentModel;

namespace SeyforDatabaseProject.ViewModel.Validation
{
    /// <summary>
    /// Handles validation processing on the view model layer.
    /// </summary>
    public class VMValidationHandler : INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private readonly Dictionary<string, IList<string>> _propertyErrors;

        public VMValidationHandler()
        {
            _propertyErrors = new Dictionary<string, IList<string>>();
        }

        public void AddError(string propertyName, string message)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(message);
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        public IEnumerable GetErrors(string? propertyName) => _propertyErrors!.GetValueOrDefault(propertyName, new List<string>());

        public bool HasErrors
        {
            get => _propertyErrors.Count != 0;
        }

        private void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}