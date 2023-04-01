using AmiCog.Application.Common.Errors;
using AmiCog.Application.Common.Interfaces.Authentication;
using AmiCog.Application.Common.Interfaces.Persistence;
using AmiCog.Domain.Entities;
using FluentResults;

namespace AmiCog.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Result.Fail<AuthenticationResult>(new UserNotExistsError());
        }

        if (user.Password != password)
        {
            return Result.Fail<AuthenticationResult>(new InvalidPasswordError());
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user,
            token);
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if the user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
        }
        
        // create user ( generate unique id )
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