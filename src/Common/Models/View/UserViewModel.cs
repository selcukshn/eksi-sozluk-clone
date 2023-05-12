namespace Common.Models.View
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string? Image { get; set; }
    }
}