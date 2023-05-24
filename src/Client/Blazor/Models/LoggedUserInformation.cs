using Common.Models.View;

namespace Blazor.Models
{
    public class LoggedUserInformation
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public LoggedUserInformation() { }
        public LoggedUserInformation(Guid userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }

        public LoggedUserInformation(UserLoginViewModel model)
        {
            UserId = model.Id;
            Username = model.Username;
            Email = model.Email;
        }
    }
}