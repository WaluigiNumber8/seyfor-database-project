using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    /// <summary>
    /// VM for the content browser window.
    /// </summary>
    public abstract class ContentBrowserVMBase<TAssetType> : ViewModelBase, IViewModelWithList<TAssetType> where TAssetType : DatabaseItemBase<TAssetType>
    {
        #region Properties

        private ObservableCollection<ContentBrowserItemVM> _pickableItems;

        public ObservableCollection<ContentBrowserItemVM> PickableItems
        {
            get { return _pickableItems; }
            set { _pickableItems = value; }
        }

        #endregion

        #region Commands

        public ICommand SelectCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand RefreshEntriesCommand { get; }

        #endregion

        public Action<TAssetType> WhenConfirm { get; set; }
        protected abstract string GetAssetTextIdentifier(TAssetType item);

        public ContentBrowserVMBase(DatabaseItemList<TAssetType> list)
        {
            PickableItems = new ObservableCollection<ContentBrowserItemVM>();

            SelectCommand = new SelectAssetSingleCommand<TAssetType>(this, list);
            RefreshEntriesCommand = new RefreshEntriesCommand<TAssetType>(this, list);
        }

        public void UpdateEntries(IEnumerable<TAssetType> items)
        {
            PickableItems.Clear();
            foreach (TAssetType item in items)
            {
                PickableItems.Add(new ContentBrowserItemVM(item.ID, GetAssetTextIdentifier(item)));
            }
        }
    }
}