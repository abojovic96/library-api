using Books.Database.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindByUsername(string username);
        Task<bool> CheckPassword(ApplicationUser applicationUser, string password);
        JwtSecurityToken GenerateToken(string username);
        Task<bool> CreateUser(ApplicationUser user, string password, string email);

        Task<ApplicationUser> FindByEmail(string email);
    }
}
