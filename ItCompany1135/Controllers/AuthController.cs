using ItCompany1135.CQRS.Commands;
using ItCompany1135.CQRS.DTO;
using ItCompany1135.DB;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ItCompany1135.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginData data)
        {
            var command = new LoginCommand() { Data = data };
            var result = await mediator.SendAsync(command);
            if (result == null)
                return Forbid();
            return Ok(result);
        }
    }
}
