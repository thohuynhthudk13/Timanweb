using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;
using TIMAN.Web.Services;

namespace TIMAN.Web.Shared
{
    public partial class MainLayout
    {
        [Inject] private ILoginApiClient LoginApiClient { set; get; }

        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] ILocalStorageService localStorage { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        private Login Login = new Login();
        private bool checkLogged = false;
        private string TuKhoaTimKiem;

        public void TimKiemSanPham()
        {
            if (!string.IsNullOrEmpty(TuKhoaTimKiem))
            {
                UriHelper.NavigateTo($"tim-kiem/{TuKhoaTimKiem}");
                TuKhoaTimKiem = null;
            }
           
        }
        protected override async Task OnInitializedAsync()
        {
            var loggedLocalStorage = await localStorage.GetItemAsync<bool>("logged");
            checkLogged = loggedLocalStorage;
            //await .SetItemAsync("logged", "true");
        }
        private async Task SubmitLogin(EditContext context)
        {
            var result = await LoginApiClient.Login(Login);
            if (result)
            {
                await JsRuntime.InvokeVoidAsync("alert", "Đăng nhập thành công");
                await localStorage.SetItemAsync("logged",true);
                checkLogged = true;
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("alert", "Đăng nhập không thành công");
            }
        }
    }
}
