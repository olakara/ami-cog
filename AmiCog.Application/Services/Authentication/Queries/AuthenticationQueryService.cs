using AmiCog.Application.Common.Interfaces.Authentication;
using AmiCog.Application.Common.Interfaces.Persistence;
using AmiCog.Application.Services.Authentication.Common;
using AmiCog.Domain.Common.Errors;
using AmiCog.Domain.Entities;
using ErrorOr;

namespace AmiCog.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (user.Password != password)
        {
            return new [] {Errors.Authentication.InvalidCredentials};
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user, token);
    }
}