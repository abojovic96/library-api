using Books.Database.Models;
using Books.Database.Repository.Interfaces;
using Books.Logic.Interfaces;
using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        private IUserRepository _userRepository;

        public AuthenticationLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(string username, string password, string email)
        {
            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
            };

            var result = await _userRepository.CreateUser(user, password, email);

            return result;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            var user = await _userRepository.FindByUsername(username);
            var isPasswordCorrect = await _userRepository.CheckPassword(user, password);

            return user != null && isPasswordCorrect;
        }

        public TokenInfo GenerateToken(string username)
        {
            var token =  _userRepository.GenerateToken(username);
            return new TokenInfo()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }

        public async Task<bool> UserExists(string username)
        {
            var user = await _userRepository.FindByUsername(username);
            return user != null;
        }

        public bool ConfirmPassword(string passward, string confirmPassword)
        {
            bool result = passward == confirmPassword;
            return result;
        }

        public async Task<bool> CheckEmail(string email)
        {
            var user = await _userRepository.FindByEmail(email);
            return user != null;
        }
    }
}
