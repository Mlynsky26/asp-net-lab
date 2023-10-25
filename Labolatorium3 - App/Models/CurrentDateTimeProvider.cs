namespace Labolatorium3___App.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
