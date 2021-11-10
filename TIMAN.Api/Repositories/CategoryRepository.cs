using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Category> AddCategory(Category category)
        {
            var result = await appDbContext.categories.AddAsync(category);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteCategory(int Id)
        {
            var result = await appDbContext.categories.FindAsync(Id);
            if (result != null)
            {
                appDbContext.categories.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            return await appDbContext.categories.ToListAsync();

        }

        public async Task<Category> GetCategory(int Id)
        {
            var category = await appDbContext.categories.FindAsync(Id);
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await appDbContext.categories.FindAsync(category.Id);
            if (result!=null)
            {
                result.Name = category.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
