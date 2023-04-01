using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmiCog.Application.Services.Authentication;
using AmiCog.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmiCog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var registerResult = _authenticationService.Register(request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);

            return registerResult.Match(
                result => Ok(MapAuthResult(result)),
                _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists!"));
        }

        private AuthenticationResponse MapAuthResult(AuthenticationResult result)
        {
            return new AuthenticationResponse(
                result.user.Id, 
                result.user.FirstName,
                result.user.LastName,
                result.user.Email,
                result.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authenticationService.Login(request.Email, request.Password);
            
            var response = new AuthenticationResponse(result.user.Id, result.user.FirstName,
                result.user.LastName, result.user.Email,
                result.Token);
            
            return Ok(response);
        }
    }
}
