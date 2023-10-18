
    public class Birth
    {
        public DateTime Date { get; set; }
        public string? Name { get; set; }

        public bool IsValid()
        {
            return Name != null &&  Date != null && Date < DateTime.Now;
        }

        public int Age()
        {
            DateTime end = DateTime.Now;
            return (end.Year - Date.Year - 1) +
             (((end.Month > Date.Month) ||
             ((end.Month == Date.Month) && (end.Day >= Date.Day))) ? 1 : 0);
        }
    }

