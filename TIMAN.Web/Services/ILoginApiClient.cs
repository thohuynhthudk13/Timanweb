using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Web.Services
{
   public interface ILoginApiClient
    {
       
        Task<bool> Login(Login login);
       
    }
}
