using AmiCog.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace AmiCog.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;