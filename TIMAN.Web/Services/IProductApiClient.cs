using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Web.Services
{
   public interface IProductApiClient
    {
        Task<List<Product>> GetProducts(string search = null);
        Task<Product> GetProduct(int Id);
        Task<bool> AddProduct(Product Product);
        Task<bool> UpdateProduct(Product Product);
        Task<bool> DeleteProduct(int Id);
        Task<List<Category>> GetCategories();
        Task<List<Product>> GetProductsByCategoryId(int categoryId);
        Task<Category> GetCategoryById(int Id);
    }
}
