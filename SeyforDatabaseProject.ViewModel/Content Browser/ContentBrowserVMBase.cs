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

        private string _headerText;
        public string HeaderText
        {
            get => _headerText;
            set
            {
                _headerText = value;
                OnPropertyChanged();
            }
        }
        
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
        protected abstract string AssetTypeInString { get; }

        public ContentBrowserVMBase(DatabaseItemList<TAssetType> list, IServiceContentBrowser browserService)
        {
            PickableItems = new ObservableCollection<ContentBrowserItemVM>();

            SelectCommand = new SelectAssetSingleCommand<TAssetType>(this, list, browserService);
            CancelCommand = new CloseContentBrowserCommand(browserService);
            RefreshEntriesCommand = new RefreshEntriesCommand<TAssetType>(this, list);

            HeaderText = $"Pick {AssetTypeInString}";
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