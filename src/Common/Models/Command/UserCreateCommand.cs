using MediatR;

namespace Common.Models.Command
{
    public class UserCreateCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public UserCreateCommand(string username, string email, string password, string rePassword)
        {
            Username = username;
            Email = email;
            Password = password;
            RePassword = rePassword;
        }
    }
}