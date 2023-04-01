using AmiCog.Application.Common.Errors;
using OneOf;

namespace AmiCog.Application.Services.Authentication;

public interface IAuthenticationService
{
    public OneOf<AuthenticationResult, IError> Login(string email, string password);
    OneOf<AuthenticationResult, IError> Register(string firstName,
        string lastName,
        string email,
        string password);
}