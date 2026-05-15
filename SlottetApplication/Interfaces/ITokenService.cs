using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;

namespace Slottet.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
