using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Infrastructure.Abstraction;
using TaskGrade.Infrastructure.Persistence;

namespace TaskGrade.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(string name, string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Name == name);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Email != email)
            {
                throw new Exception("Email is wrong");
            }

            return _tokenService.GenerateAccessToken(user);
        }
    }
}
