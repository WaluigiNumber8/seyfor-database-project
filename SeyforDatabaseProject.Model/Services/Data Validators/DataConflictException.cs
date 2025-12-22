namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Thrown when there is a data conflict during validation.
    /// </summary>
    public class DataConflictException : Exception
    {
        public DataConflictException(string message) : base(message) { }
    }
}