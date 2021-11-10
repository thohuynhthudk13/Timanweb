using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Api.Repositories
{
    public  interface ILoginRepository
    {
        
        Task<Login> Login(Login login);
    }
}
