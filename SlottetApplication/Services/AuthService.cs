using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs;

namespace Slottet.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _repo;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        
        public AuthService(IUserRepo repo, IConfiguration config, ITokenService tokenService)
        {
            _repo = repo;
            _config = config; //unsure if necessary - Gavin
            _tokenService = tokenService;
        }
        public async Task<string?> LoginAsync(UserDto request)
        {
            var user = await _repo.GetByUserName(request.Username);
            if (user == null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return _tokenService.GenerateToken(user);
        }

        public async Task<User?> RegisterAsync(UserDto request)
        {
            
            var existing = await _repo.GetByUserName(request.Username);
            if (existing != null) { return null; }

            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;
            user.Role = request.Role;

            await _repo.AddAsync(user);
            return user;
        }

        public async Task RemoveUserAsync(int id)
        {
           await _repo.DeleteAsync(id);
        }
    }
}
