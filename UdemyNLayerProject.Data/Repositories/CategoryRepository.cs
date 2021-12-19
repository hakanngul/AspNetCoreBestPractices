using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appContext
        {
            get => _context as AppDbContext;
        }

        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await
                _appContext.Categories
                    .Include(x => x.Products)
                    .SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}