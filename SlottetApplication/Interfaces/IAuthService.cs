using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs;

namespace Slottet.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto dto);
        Task<string> LoginAsync(UserDto dto);
    }
}
