using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    public abstract class DatabaseServiceBase
    {
        protected readonly DatabaseContextFactory _contextFactory;

        public DatabaseServiceBase(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}