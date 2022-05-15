using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Interfaces
{
    public interface IAuthenticationLogic
    {
        Task<bool> ValidateUser(string username, string password);
        Task<bool> CreateUser(string username, string password, string email);
        TokenInfo GenerateToken(string username);
        Task<bool> UserExists(string username);
        bool ConfirmPassword(string passward, string confirmPassword);
        Task<bool> CheckEmail(string email);
    }
}
