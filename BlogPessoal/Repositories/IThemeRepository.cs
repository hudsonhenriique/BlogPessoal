using PersonalBlog.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PernalBlog.Repositories
{
    public interface IThemeRepository
    {
        Task<IEnumerable<Theme>> GetAll();
        Task<Theme?> GetById(long id);
        Task<IEnumerable<Theme>> GetByDescription(string description);
        Task<Theme?> Create(Theme theme);
        Task<Theme?> Update(Theme theme);
        Task Delete(long id);
    }
}