using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost("account/login")]
        public async Task<IActionResult> Login([FromBody]GetUserTokenQuery loginUser, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(loginUser, cancellationToken);

            return Ok(response);
        }
        
    }    
}