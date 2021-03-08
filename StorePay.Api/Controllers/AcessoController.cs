using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StorePay.Infra.Models;
using StorePay.Services;
using StorePay.Domain.Entities;
using StorePay.Api.ViewModels;

namespace StorePay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;        

        public AcessoController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] CredenciaisVM credenciais)
        {
            var userIdentity = await _userManager.FindByNameAsync(credenciais.UserName);

            if(userIdentity == null)
            {
                return FalhaLogin();
            }

            var result = await _signInManager.PasswordSignInAsync(userIdentity, credenciais.Password, false, false);

            if (!result.Succeeded)
            {
                return FalhaLogin();
            }

            return new TokenService(_configuration).BuildToken(userIdentity.Email);
        }

        private ActionResult<UserToken> FalhaLogin()
        {
            ModelState.AddModelError("Login", "Não foi possível realizar login, usuário e/ou senha inválidos");
            return BadRequest(ModelState);
        }
    }
}
