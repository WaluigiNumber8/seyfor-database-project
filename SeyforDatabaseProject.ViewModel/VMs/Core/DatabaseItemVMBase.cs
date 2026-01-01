using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class DatabaseItemVMBase<T> : ViewModelBase, IIDHolder where T : DatabaseItemBase<T>
    {
        public int ID { get => _item.ID; }
        
        protected readonly T _item;

        public DatabaseItemVMBase(T item)
        {
            _item = item;
        }
    }
}