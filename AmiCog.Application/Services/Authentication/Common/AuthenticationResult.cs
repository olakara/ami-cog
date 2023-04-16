using AmiCog.Domain.Entities;

namespace AmiCog.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User user,
    string Token);