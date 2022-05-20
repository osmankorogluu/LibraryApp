using LibraryApp.Infrastructure.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserLoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await _mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
