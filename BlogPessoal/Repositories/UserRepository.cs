using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context
                .Users.Include(u => u.Posts)
                .ToListAsync();
        }

        public async Task<User?> GetById(long id)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Update(User user)
        {
            var userUpdate = await _context.Users.FindAsync(user.Id);
            if (userUpdate == null)
                return null;

            _context.Entry(userUpdate).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return userUpdate;
        }

        public async Task Delete(long id)
        {
            var userDelete = await _context.Users.FindAsync(id);
            if (userDelete != null)
            {
                _context.Users.Remove(userDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}