using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts
                .Include(p => p.Theme)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Post?> GetById(long id)
        {
            return await _context.Posts
                .Include(p => p.Theme)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Post>> GetByTitle(string title)
        {
            return await _context.Posts
                .Include(p => p.Theme)
                .Include(p => p.User)
                .Where(p => p.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Post?> Create(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> Update(Post post)
        {
            var postUpdate = await _context.Posts.FindAsync(post.Id);
            if (postUpdate == null)
                return null;

            _context.Entry(postUpdate).CurrentValues.SetValues(post);
            await _context.SaveChangesAsync();
            return postUpdate;
        }

        public async Task Delete(long id)
        {
            var postDelete = await _context.Posts.FindAsync(id);
            if (postDelete != null)
            {
                _context.Posts.Remove(postDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}