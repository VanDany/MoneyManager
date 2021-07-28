using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Infrastructure.Security
{
    public interface ITokenRepository
    {
        string GenerateToken(TokenUser user);
        TokenUser ValidateToken(string token);
    }
}
