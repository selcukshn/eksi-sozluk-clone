namespace Common.Models.Page
{
    public class Page
    {
        public int Total { get; set; }
        public int Take { get; set; }
        private int _current;
        public int Current
        {
            get => _current;
            set
            {
                if (value <= 0)
                    _current = 1;
                else
                    _current = value;
            }
        }
        public int Max => (int)Math.Ceiling((double)Total / (double)Take);
        public int Skip => (Current - 1) * Take;
        public Page(int total, int take, int current)
        {
            Total = total;
            Take = take;
            Current = current;
        }
    }
}