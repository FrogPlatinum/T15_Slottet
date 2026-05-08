using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Infrastructure.Data;

namespace Slottet.Infrastructure
{
    public class UserDbRepo : IGenericRepo<User>
    {
        private readonly UserDbContext _repo;
        public UserDbRepo(UserDbContext context)
        {
            _repo = context;
        }
        public async Task<User> AddAsync(User entity)
        {
            _repo.Users.Add(entity);
            await _repo.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _repo.Users.FindAsync(id);
            if (user != null)
            {
                _repo.Users.Remove(user);
                await _repo.SaveChangesAsync();
            }
            return;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repo.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User entity)
        {
            _repo.Users.Update(entity);
            await _repo.SaveChangesAsync();
        }
    }
}
