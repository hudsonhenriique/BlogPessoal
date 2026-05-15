using PersonalBlog.Models;
using System.Collections.Generic;

namespace PersonalBlog.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(long id);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(User user);
        Task<User?> Update(User user);
        Task Delete(long id);
    }
}