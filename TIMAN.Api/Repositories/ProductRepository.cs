using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Api;
using TIMAN.Model;

namespace TIMAN.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Product> AddProduct(Product Product)
        {
            var result = await appDbContext.products.AddAsync(Product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int Id)
        {
            var result = await appDbContext.products.FindAsync(Id);
            if (result != null)
            {
                appDbContext.products.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<List<Product>> GetProducts(string timkiem)
        {
            if (!string.IsNullOrEmpty(timkiem))
            {
                return await appDbContext.products.Include("Category").Where(x=>x.Name.ToLower().Contains(timkiem.ToLower())).ToListAsync();
            }
            return await appDbContext.products.Include("Category").ToListAsync();

        }

        public async Task<Product> GetProduct(int Id)
        {
            var Product = await appDbContext.products.Include("Category").FirstOrDefaultAsync(x => x.Id == Id);
            return Product;
        }

        public async Task<Product> UpdateProduct(Product Product)
        {
            var result = await appDbContext.products.FindAsync(Product.Id);
            if (result != null)
            {
                result.Name = Product.Name;
                result.CategoryId = Product.CategoryId;
                result.Description = Product.Description;
                result.Price = Product.Price;
                result.ThumbnailImage = Product.ThumbnailImage;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<List<Product>> GetProductByCategoryId(int categoryId)
        {
            var result = await appDbContext.products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return result;
        }
    }
}
