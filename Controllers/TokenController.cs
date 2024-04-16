using fiap_jwt_api.Interfaces;
using fiap_jwt_api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace fiap_jwt_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] Users user)
        {
            try
            {
                var tokenGenerated = _tokenService.GetToken(user);

                return string.IsNullOrEmpty(tokenGenerated) ? Unauthorized() : Ok(tokenGenerated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
