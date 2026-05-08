using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs;

namespace Slottet.Application.Services
{
    public class AuthService : IAuthService
    {
        private IGenericRepo<User> _repo;
        public AuthService(IGenericRepo<User> repo, IConfiguration config)
        {
            _repo = repo;
        }
        public Task<string> LoginAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> RegisterAsync(UserDto dto)
        {
            
        }
    }
}
