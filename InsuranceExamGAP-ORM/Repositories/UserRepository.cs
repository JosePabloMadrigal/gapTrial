using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using InsuranceExamGAP_ORM.Settings;
using InsuranceExamGAP_ORM.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly InsuranceContext _context;
        public UserRepository(InsuranceContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public User CheckUserPassword(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null && CryptoUtils.CheckPassword(user.PasswordHash, password) == false) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.PasswordHash = null;


            return user;
        }

        public async Task<User> RegisterUser(User user)
        {
            User userExist = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (userExist != null)
            {
                return null;
            }
            string savedPasswordHash = CryptoUtils.TransformPassword(user.Password);

            user = _context.Users.Add(new User
             {
                 UserName = user.UserName,
                 FullName = user.FullName,
                 PasswordHash = savedPasswordHash,
                 Role = user.Role

            }).Entity;

            await _context.SaveChangesAsync();
            return user;
        }

        public User GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}