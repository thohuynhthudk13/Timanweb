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
    public partial class ChinhSuaHangHoa
    {
        [Parameter]
        public string id { set; get; }
        [Inject] private IProductApiClient ProductApiClient { set; get; }
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }

        private Product Product = new Product();
        private List<Category> Categories = new List<Category>();


        protected override async Task OnInitializedAsync()
        {
            Product = await ProductApiClient.GetProduct(Int32.Parse(id));
            Categories = await ProductApiClient.GetCategories();
        }
        private async Task SubmitProduct(EditContext context)
        {
            var result = await ProductApiClient.UpdateProduct(Product);
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
