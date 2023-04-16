using AmiCog.Application.Services.Authentication.Common;
using ErrorOr;

namespace AmiCog.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
}