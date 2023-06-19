using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Domain.Entities;

namespace TaskGrade.Infrastructure.Abstraction
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
