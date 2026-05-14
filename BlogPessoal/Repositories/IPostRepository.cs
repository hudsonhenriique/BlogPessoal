using PersonalBlog.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBlog.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post?> GetById(long id);
        Task<IEnumerable<Post>> GetByTitle(string title);
        Task<Post?> Create(Post post);
        Task<Post?> Update(Post post);
        Task Delete (long id);
    }
}
