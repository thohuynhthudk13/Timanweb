using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;

namespace TIMAN.Web.Pages
{
    public partial class TaoHangHoa
    {
        [Inject] private IProductApiClient ProductApiClient { set; get; }
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }

        private Product Product = new Product();
        private List<Category> Categories = new List<Category>();
        protected override async Task OnInitializedAsync()
        {
            Categories = await ProductApiClient.GetCategories();
            Product.CategoryId = 1;
        }
        private async Task SubmitProduct(EditContext context)
        {
            var result = await ProductApiClient.AddProduct(Product);
            if (result)
            {
                await JsRuntime.InvokeVoidAsync("alert", "Lưu thành công");
                Navigation.NavigateTo("/admin");
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("alert", "Lưu không thành công");
            }
        }
    }
}
