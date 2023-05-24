using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Helpers;
using Common.Models.Command;
using Common.Models.View;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Commands.User.Login
{
    public class UserLoginCommandHandler : GenericHandler<IUserRepository, UserLoginCommand, UserLoginViewModel>
    {
        private readonly IConfiguration Configuration;

        public UserLoginCommandHandler(IUserRepository repository, IMapper mapper, IConfiguration configuration) : base(repository, mapper)
        {
            Configuration = configuration;
        }

        public override async Task<UserLoginViewModel> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Email == request.Email && e.Password == HashHelper.GeneratePassword(request.Password));

            if (user == null)
                throw new UserNotFoundException("E-posta adresi veya şifre hatalı.");
            if (!user.EmailConfirmed)
                throw new UserEmailNotConfirmedException("E-posta adresiniz onaylanmamış. Giriş yapabilmek için e-posta adresinizi onaylamanız gerekmektedir.");
            var result = base.Mapper.Map<UserLoginViewModel>(user);

            var claims = new Claim[]{
                new Claim("Id",user.Id.ToString()),
                new Claim("Email",user.Email),
                new Claim("Username",user.Username),
            };
            result.Token = GenerateJWTToken(claims);

            return result;
        }
        private string GenerateJWTToken(IEnumerable<Claim> claims)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToDouble(Configuration["JWT:ValidDay"]));
                var token = new JwtSecurityToken(Configuration["JWT:Issuer"], Configuration["JWT:Audience"], claims, null, expiry, credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}