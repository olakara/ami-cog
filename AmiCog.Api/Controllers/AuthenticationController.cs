using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmiCog.Application.Authentication.Commands.Register;
using AmiCog.Application.Authentication.Common;
using AmiCog.Application.Authentication.Queries.Login;
using AmiCog.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AmiCog.Api.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController( ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // var command = new RegisterCommand(request.FirstName,
            //     request.LastName, 
            //     request.Email,
            //     request.Password);
            var command = _mapper.Map<RegisterCommand>(request);
            var registerResult = await _mediator.Send(command);

           return registerResult.Match(
               result => Ok(_mapper.Map<AuthenticationResponse>(result)),
               errors =>  Problem(errors)
                   );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            
            //var query = new LoginQuery(request.Email, request.Password);
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            return authResult.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors =>  Problem(errors)
            );
        }
        
        private AuthenticationResponse MapAuthResult(AuthenticationResult result)
        {
            return new AuthenticationResponse(
                result.User.Id, 
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token);
        }
    }
}
