namespace Common.Models.View
{
    public class SearchViewModel
    {
        public List<SearchResultUserModel> User { get; set; }
        public List<SearchResultEntryModel> Entry { get; set; }
        public SearchFirstResult? GetFirstResult()
        {
            if (Entry[0] != null)
                return new SearchFirstResult(Entry[0]);
            else if (User[0] != null)
                return new SearchFirstResult(User[0]);
            return null;
        }
        public bool HaveItem()
        {
            return User.Any() || Entry.Any();
        }
    }
    public class SearchResultUserModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }

    public class SearchResultEntryModel
    {
        public string Url { get; set; }
        public string Subject { get; set; }
    }
    public class SearchFirstResult
    {
        public SearchResultUserModel? User { get; set; }
        public SearchResultEntryModel? Entry { get; set; }
        public SearchFirstResult(SearchResultUserModel user)
        {
            User = user;
        }
        public SearchFirstResult(SearchResultEntryModel entry)
        {
            Entry = entry;
        }
    }

}