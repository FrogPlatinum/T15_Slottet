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
        private readonly IGenericRepo<User> _repo;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AuthService(IGenericRepo<User> repo, IConfiguration config, ITokenService tokenService)
        {
            _repo = repo;
            _config = config;
            _tokenService = tokenService;
        }
        public async Task<string?> LoginAsync(UserDto request)
        {
            var user = await _repo.GetByIdAsync(request.Id);
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
            //Refactor this into a repo method, if we have more time. Pulling the entire table is no good.. --Gavin
            var existing = (await _repo.GetAllAsync()).Any(u => u.Username == request.Username);
            if (existing) { return null; }

            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            await _repo.AddAsync(user);
            return user;
        }
    }
}
