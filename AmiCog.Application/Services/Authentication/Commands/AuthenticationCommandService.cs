using AmiCog.Application.Common.Interfaces.Authentication;
using AmiCog.Application.Common.Interfaces.Persistence;
using AmiCog.Application.Services.Authentication.Common;
using AmiCog.Domain.Common.Errors;
using AmiCog.Domain.Entities;
using ErrorOr;

namespace AmiCog.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

   

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
       
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            Email = email,
            FirstName = firstName,
            Password = password,
            LastName = lastName
        };
        _userRepository.Add(user);
        
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);
        return new AuthenticationResult(user, token);
    }
}