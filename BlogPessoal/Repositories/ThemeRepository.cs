using Microsoft.EntityFrameworkCore;
using PernalBlog.Repositories;
using PersonalBlog.Data;
using PersonalBlog.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Repositories
{
    public class ThemeRepository : IThemeRepository

    {
        private readonly AppDbContext _context;

        public ThemeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Theme>> GetAll()
        {
            return await _context.Themes
                .Include(t => t.Posts)
                .ToListAsync();
        }

        public async Task<Theme?> GetById(long id)
        {
            return await _context.Themes
                .Include(t => t.Posts)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Theme>> GetByDescription(string description)
        {
            return await _context.Themes
                .Include(t => t.Posts)
                .Where(t => t.Description.Contains(description))
                .ToListAsync();
        }

        public async Task<Theme?> Create(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();
            return theme;
        }

        public async Task<Theme?> Update(Theme theme)
        {
            var themeUpdate = await _context.Themes.FindAsync(theme.Id);
            if (themeUpdate == null)
                return null;
            _context.Entry(themeUpdate).CurrentValues.SetValues(theme);
            await _context.SaveChangesAsync();
            return themeUpdate;
        }

        public async Task Delete(long id)
        {
            var themeDelete = await _context.Themes.FindAsync(id);
            if (themeDelete != null)
            {
                _context.Themes.Remove(themeDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}