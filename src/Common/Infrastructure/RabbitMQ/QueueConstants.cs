namespace Common.Infrastructure.RabbitMQ
{
    public static class QueueConstants
    {
        public const string Host = "localhost";
        public const string DefaultExchangeType = "direct";
        public const string FavoriteExchange = "favorite_exc";
        public const string CreateEntryFavoriteQueue = "create_entry_favorite_queue";
        public const string CreateEntryCommentFavoriteQueue = "create_entry_comment_favorite_queue";

        public const string VoteExchange = "vote_exc";
        public const string CreateEntryVoteQueue = "create_entry_vote_queue";
        public const string CreateEntryVoteCommentQueue = "create_entry_comment_vote_queue";

    }
}