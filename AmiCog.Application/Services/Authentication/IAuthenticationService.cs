using AmiCog.Application.Common.Errors;
using OneOf;

namespace AmiCog.Application.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Login(string email, string password);
    OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName,
        string lastName,
        string email,
        string password);
}