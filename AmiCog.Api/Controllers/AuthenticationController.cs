using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmiCog.Application.Services.Authentication;
using AmiCog.Application.Services.Authentication.Commands;
using AmiCog.Application.Services.Authentication.Common;
using AmiCog.Application.Services.Authentication.Queries;
using AmiCog.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;


namespace AmiCog.Api.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var registerResult= _authenticationCommandService.Register(request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);

           return registerResult.Match(
               result => Ok(MapAuthResult(result)),
               errors =>  Problem(errors)
                   );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);

            return authResult.Match(
                result => Ok(MapAuthResult(result)),
                errors =>  Problem(errors)
            );
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
    }
}
