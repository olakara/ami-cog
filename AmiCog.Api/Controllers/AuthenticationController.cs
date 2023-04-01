using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmiCog.Application.Common.Errors;
using AmiCog.Application.Services.Authentication;
using AmiCog.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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
            var registerResult= _authenticationService.Register(request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);

            return registerResult.Match(
                result => Ok(MapAuthResult(result)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
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
            
            return result.Match(
                result => Ok(MapAuthResult(result)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
        }
    }
}
