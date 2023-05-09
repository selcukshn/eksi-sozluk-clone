using MediatR;

namespace Common.Models.Command
{
    public class UserUpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public UserUpdateCommand(Guid id, string username, string email, string? image)
        {
            Id = id;
            Username = username;
            Email = email;
            Image = image;
        }
    }
}