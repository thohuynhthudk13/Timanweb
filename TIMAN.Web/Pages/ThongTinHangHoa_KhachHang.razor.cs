using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;

namespace TIMAN.Web.Pages
{
    public partial class ThongTinHangHoa_KhachHang
    {
        [Parameter]
        public string id { set; get; }
        [Inject] private IProductApiClient ProductApiClient { set; get; }

        private int SoLuong = 1;
        private Product Product = new Product();
        private List<Product> Products = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductApiClient.GetProduct(Int32.Parse(id));
            if (Product!=null)
            {
                Products = await ProductApiClient.GetProductsByCategoryId(Product.CategoryId);
                Products = Products.Where(x => x.Id != Product.Id).ToList();
            }
        }
        protected override async Task OnParametersSetAsync()
        {
            Product = await ProductApiClient.GetProduct(Int32.Parse(id));
            if (Product != null)
            {
                Products = await ProductApiClient.GetProductsByCategoryId(Product.CategoryId);
                Products = Products.Where(x => x.Id != Product.Id).ToList();
            }
        }
    }
}
