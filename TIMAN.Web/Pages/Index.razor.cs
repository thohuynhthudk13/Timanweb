using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;
using TIMAN.Web.Shared;

namespace TIMAN.Web.Pages
{
    public partial class Index
    {
        [Inject] private IProductApiClient ProductApiClient { set; get; }
    

        private List<Product> Products;
        protected string ToaDo { get; set; }

        private bool HienThiSanPham = true;

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductApiClient.GetProducts();
        }
        protected void DiChuyenChuot(MouseEventArgs e)
        {
            ToaDo = $"Tọa độ chuột trên hình: X = {e.ClientX }, tọa độ Y = {e.ClientY}";
        }
        protected void HienAnSanPham()
        {
            HienThiSanPham = !HienThiSanPham;
        }
        
        

    }
}
