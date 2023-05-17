namespace Common.Models.Queries.Base
{
    public class EntryQuery
    {
        public string? Url { get; set; }
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value == default) _count = 25;
                else _count = value;
            }
        }
    }
}