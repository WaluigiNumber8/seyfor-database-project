namespace SeyforDatabaseProject.ViewModel.Validation
{
    public class ValidationRule
    {
        public string PropertyName { get; }
        public Func<bool> IsWrong { get; }
        public string Message { get; }

        public ValidationRule(string propertyName, string message, Func<bool> isWrong)
        {
            PropertyName = propertyName;
            Message = message;
            IsWrong = isWrong;
        }
    }
}