using System.Windows.Markup;

namespace SeyforDatabaseProject.Views.MarkupExtensions
{
    /// <summary>
    /// Simplifies binding to enum values in XAML.
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException($"'{enumType}' must be an enum.");
            }

            EnumType = enumType;
        }

        public override object? ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}