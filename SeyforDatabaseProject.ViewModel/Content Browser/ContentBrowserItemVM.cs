using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    /// <summary>
    /// Represents an item that is shown in the list of <see cref="ContentBrowserVMBase"/>.
    /// </summary>
    public class ContentBrowserItemVM : ViewModelBase
    {
        public int ID { get; }
        public string TextIdentifier {get;}

        public ContentBrowserItemVM(int id, string textIdentifier)
        {
            ID = id;
            TextIdentifier = textIdentifier;
        }
    }
}