using AmiCog.Application.Common.Errors;
using FluentResults;

namespace AmiCog.Application.Services.Authentication;

public interface IAuthenticationService
{
    public Result<AuthenticationResult> Login(string email, string password);
    Result<AuthenticationResult> Register(string firstName,
        string lastName,
        string email,
        string password);
}