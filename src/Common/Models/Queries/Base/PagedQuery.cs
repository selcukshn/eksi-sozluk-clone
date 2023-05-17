namespace Common.Models.Queries.Base
{
    public class PagedQuery
    {
        public Guid UserId { get; set; }
        public int Current { get; set; }
        private int _take;
        public int Take
        {
            get => _take;
            set
            {
                if (value == default) _take = 5;
                else _take = value;
            }
        }
    }
}