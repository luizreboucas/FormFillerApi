using FormFiller.Presentation.DTOs.Login;
using FormFiller.Presentation.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FormFiller.Application.UseCases;
using FormFiller.Application.UseCases.Models;
using FormFiller.Presentation.DTOs.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FormFiller.Presentation.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        public LoginValidator validator;
        public LoginUseCase loginUseCase;

        public LoginController(LoginValidator _validator, LoginUseCase _loginUseCase)
        {
            this.validator = _validator;
            this.loginUseCase = _loginUseCase;
        }
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO request)
        {
            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            try
            {
                var result = await loginUseCase.LoginExec(new LoginRequest(request.Email, request.Password));
                if (result == null)
                {
                    return Unauthorized("Credenciais inválidas");
                }
                var claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new[]
                        {
                            new Claim(ClaimTypes.Name, result.Username),
                            new Claim(ClaimTypes.NameIdentifier, result.Id.ToString())
                        },
                        JwtBearerDefaults.AuthenticationScheme
                    )
                );
                return SignIn(claimsPrincipal);
            }
            catch (Exception ex)
            {
                return Problem("Ocorreu um erro ao realizar o login: " + ex.Message);
            }
        }
    }
}
