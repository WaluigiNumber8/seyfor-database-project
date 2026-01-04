namespace SeyforDatabaseProject.Model.Utils
{
    public static class DateTimeExtensions
    {
        public static bool WithinRange(this DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            return dateTime >= startDate && dateTime <= endDate;
        }
    }
}