using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Api;
using TIMAN.Model;

namespace TIMAN.Api.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext appDbContext;
        public LoginRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Login> Login(Login login)
        {
            var result = await appDbContext.logins.FirstOrDefaultAsync(x => x.UserName == login.UserName && x.Password == login.Password);
            return result;
        }
    }
}
