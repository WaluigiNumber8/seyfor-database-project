namespace SeyforDatabaseProject.ViewModel.Validation
{
    public class ValidationBook
    {
        private readonly IDictionary<string, IList<ValidationRule>> _validationRules;
        public VMValidationHandler Errors { get; }

        public ValidationBook()
        {
            Errors = new VMValidationHandler();
            _validationRules = new Dictionary<string, IList<ValidationRule>>();
        }
        
        public void ConstructValidationRules(IList<ValidationRule> rules)
        {
            foreach (ValidationRule rule in rules)
            {
                if (!_validationRules.ContainsKey(rule.PropertyName))
                {
                    _validationRules.Add(rule.PropertyName, new List<ValidationRule>());
                }
                _validationRules[rule.PropertyName].Add(rule);
            }
        }
        
        public void Validate(string propertyName)
        {
            Errors.ClearErrors(propertyName);
            if (!_validationRules.TryGetValue(propertyName, out IList<ValidationRule>? rules)) return;
            if (rules.Count == 0) return;
            foreach (ValidationRule rule in rules)
            {
                bool passed = !rule.IsWrong();
                if (!passed) Errors.AddError(propertyName, rule.Message);
            }
            
        }
    }
}