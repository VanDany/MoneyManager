using Microsoft.AspNetCore.Mvc;
using ModelsAPI.Client.Data;
using ModelsAPI.Client.Repositories;
using MoneyManager.API.Infrastructure.Security;
using MoneyManager.API.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            User user = _authRepository.Login(form.Email, form.Password);

            if (user is null)
                return Unauthorized(new { Error = "mail ou mot de passe invalide" });

            user.Token = _tokenRepository.GenerateToken(new TokenUser() { Id = user.Id, Username = user.Username, EmailAddress = user.EmailAddress });

            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            //Why I have to put a value for xp and level?
            _authRepository.Register(new User(form.Username, form.EmailAddress, form.Password, 0, 1));
            return NoContent();
        }
    }
}
