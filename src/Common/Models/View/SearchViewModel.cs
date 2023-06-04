namespace Common.Models.View
{
    public class SearchViewModel
    {
        public List<SearchResultUserModel>? User { get; set; }
        public List<SearchResultEntryModel>? Entry { get; set; }
        public SearchFirstResult? GetFirstResult()
        {
            if (Entry != null && Entry.Any())
                return new SearchFirstResult(Entry.First());
            else if (User != null && User.Any())
                return new SearchFirstResult(User.First());
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