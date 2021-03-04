using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StorePay.Infra.Models;
using StorePay.Services;

namespace StorePay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AcessoController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
                
        [HttpPost("Criar")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo usuario)
        {
            var user = new AppUser { UserName = usuario.Email, Email = usuario.Email };
            var result = await _userManager.CreateAsync(user, usuario.Password);
            if (result.Succeeded)
            {
                return new TokenService(_configuration).BuildToken(usuario);
            }
            else
            {
                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(erro.Code, erro.Description);
                }

                return BadRequest(ModelState);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new TokenService(_configuration).BuildToken(usuario);
            }
            else
            {
                ModelState.AddModelError("Login", "Não foi possível realizar login, usuário e/ou senha inválidos");
                return BadRequest(ModelState);
            }
        }

    }
}
