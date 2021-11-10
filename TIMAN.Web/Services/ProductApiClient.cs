using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Web.Services
{
    public class ProductApiClient : IProductApiClient
    {
        public HttpClient _httpClient;
        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddProduct(Product Product)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/products", Product);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var result = await _httpClient.DeleteAsync($"/api/products/{Id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<List<Category>> GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>($"/api/categories");
            return result;
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Category>($"/api/categories/GetById?Id={Id}");
            return result;
        }

        public async Task<Product> GetProduct(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"/api/products/GetById?id={Id}");
            return result;
        }

        public async Task<List<Product>> GetProducts(string timkiem = null)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>($"/api/products?timkiem={timkiem}");
            return result;
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>($"/api/products/GetByCategoryId?categoryId={categoryId}");
            return result;
        }

        public async Task<bool> UpdateProduct(Product Product)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/products/{Product.Id}", Product);
            return result.IsSuccessStatusCode;
        }
    }
}
