using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Api.Repositories;
using TIMAN.Model;

namespace TIMAN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _LoginRepository;

        public LoginController(ILoginRepository LoginRepository)
        {
            _LoginRepository = LoginRepository;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var LoginFromDb = await _LoginRepository.Login(login);

            if (LoginFromDb == null)
            {
                return NotFound($"{login.UserName} is not found");
            }

            return Ok(LoginFromDb);
        }
    }
}
