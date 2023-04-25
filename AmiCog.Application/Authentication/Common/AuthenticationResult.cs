using AmiCog.Domain.Entities;

namespace AmiCog.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);