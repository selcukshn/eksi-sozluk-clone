namespace Common.Models.Page
{
    public class PagedViewModel<T>
    {
        public Page Page { get; set; }
        public ICollection<T> Data { get; set; }
        public PagedViewModel(Page page, ICollection<T> data)
        {
            Page = page;
            Data = data;
        }
    }
}