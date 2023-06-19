using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGrade.Infrastructure.Abstraction
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string name, string email);
    }
}
