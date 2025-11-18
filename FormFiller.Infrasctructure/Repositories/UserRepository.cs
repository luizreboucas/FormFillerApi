using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Entities.Interfaces;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Database;
using Microsoft.EntityFrameworkCore;
using FormFiller.Application.Exceptions;

namespace FormFiller.Infrasctructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext context;


        public UserRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<User> Create(User user)
        {
            var newUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }

        public async void Delete(Guid id)
        {
            var userToBeRemoved = await context.Users.FindAsync(id);
            if (userToBeRemoved == null) throw new NotFoundInTheDatabaseExeption("Registro não encontrado no banco");
            context.Users.Remove(userToBeRemoved);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Update(User userNewData)
        {
            var user = context.Users.Update(userNewData);
            await context.SaveChangesAsync();
            return user.Entity;
        }
    }
}
