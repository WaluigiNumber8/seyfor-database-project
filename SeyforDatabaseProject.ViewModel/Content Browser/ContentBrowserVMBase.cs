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
    public abstract class ContentBrowserVMBase<TItemType> : ViewModelBase, IViewModelWithList<TItemType> where TItemType : DatabaseItemBase<TItemType>
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

        public Action<IList<TItemType>> WhenConfirm { get; set; }
        protected abstract string GetAssetTextIdentifier(TItemType item);
        protected abstract string AssetTypeInString { get; }

        public ContentBrowserVMBase(DatabaseItemList<TItemType> list, IServiceContentBrowser browserService)
        {
            PickableItems = new ObservableCollection<ContentBrowserItemVM>();

            SelectCommand = new SelectAssetsCommand<TItemType>(this, list, browserService);
            CancelCommand = new CloseContentBrowserCommand(browserService);
            RefreshEntriesCommand = new RefreshEntriesCommand<TItemType>(this, list);

            HeaderText = $"Pick {AssetTypeInString}";
        }

        public void UpdateEntries(IEnumerable<TItemType> items)
        {
            PickableItems.Clear();
            foreach (TItemType item in items)
            {
                PickableItems.Add(new ContentBrowserItemVM(item.ID, GetAssetTextIdentifier(item)));
            }
        }
    }
}