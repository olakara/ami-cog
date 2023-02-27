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
            var result = _authenticationService.Register(request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(result.Id, result.FirstName,
                                                        result.LastName, result.Email,
                                                        result.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authenticationService.Login(request.Email, request.Password);
            
            var response = new AuthenticationResponse(result.Id, result.FirstName,
                result.LastName, result.Email,
                result.Token);
            
            return Ok(response);
        }
    }
}
