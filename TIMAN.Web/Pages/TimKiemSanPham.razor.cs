using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;

namespace TIMAN.Web.Pages
{
    public partial class TimKiemSanPham
    {
        [Parameter]
        public string TenSanPham { set; get; }

        [Inject] private IProductApiClient ProductApiClient { set; get; }


        private List<Product> Products = new List<Product>();


        protected override async Task OnInitializedAsync()
        {
            Products = await ProductApiClient.GetProducts(TenSanPham);
        }
        protected override async Task OnParametersSetAsync()
        {
            Products = await ProductApiClient.GetProducts(TenSanPham);
        }

    }
}
