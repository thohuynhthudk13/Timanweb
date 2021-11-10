using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Api.Repositories
{
    public  interface IProductRepository
    {
        Task<List<Product>> GetProducts(string timkiem);
        Task<Product> GetProduct(int Id);
        Task<Product> AddProduct(Product Product);
        Task<Product> UpdateProduct(Product Product);
        Task<Product> DeleteProduct(int Id);
        Task<List<Product>> GetProductByCategoryId(int categoryId);
    }
}
