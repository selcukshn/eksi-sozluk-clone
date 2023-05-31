namespace Common.Models.Queries.Base
{
    public class EntryQuery
    {
        public string? Url { get; set; }
        private int _count = 25;
        public int Count
        {
            get => _count;
            set
            {
                if (int.TryParse(value.ToString(), out int count))
                {
                    if (count != default) _count = value;
                }
            }
        }
    }
}