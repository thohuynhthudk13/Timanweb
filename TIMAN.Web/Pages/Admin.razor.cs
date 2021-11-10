using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;

namespace TIMAN.Web.Pages
{
    public partial class Admin
    {
        [Inject] private IProductApiClient ProductApiClient { set; get; }
        private List<Product> Products = new List<Product>();
        [Inject] IJSRuntime JsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductApiClient.GetProducts();
        }

        private string keyword;

        public async Task SearchProduct()
        {
            Products = await ProductApiClient.GetProducts(keyword);

        }
        public async Task OnDeleteProdyct(int Id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Bạn có chắc muốn xóa?"); // Confirm
            if (confirmed)
            {
                var result = await ProductApiClient.DeleteProduct(Id);

                if (result)
                {
                    await JsRuntime.InvokeVoidAsync("alert", "Xóa thành công");
                    Products = await ProductApiClient.GetProducts();
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("alert", "Xóa không thành công");
                }
            }
        }
    }
}
