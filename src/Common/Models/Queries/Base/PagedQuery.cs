namespace Common.Models.Queries.Base
{
    public class PagedQuery
    {
        public Guid? UserId { get; set; }
        private int _current;
        public int Current
        {
            get => _current;
            set
            {
                if (value <= 0) _current = 1;
                else _current = value;
            }
        }
        private int _take;
        public int Take
        {
            get => _take;
            set
            {
                if (value == default) _take = 25;
                else _take = value;
            }
        }
        public override string ToString()
        {
            string query = $"?take={Take}&current={Current}";
            if (UserId != null)
                return $"{query}&userId={UserId}";
            return query;
        }
    }
}