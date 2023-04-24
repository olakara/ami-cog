using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmiCog.Application.Authentication.Commands.Register;
using AmiCog.Application.Authentication.Common;
using AmiCog.Application.Authentication.Queries.Login;
using AmiCog.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AmiCog.Api.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController( ISender mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);
            var registerResult = await _mediator.Send(command);

           return registerResult.Match(
               result => Ok(MapAuthResult(result)),
               errors =>  Problem(errors)
                   );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //var command = new Lo
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);

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
