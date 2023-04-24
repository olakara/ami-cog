using AmiCog.Domain.Entities;

namespace AmiCog.Application.Authentication.Common;

public record AuthenticationResult(
    User user,
    string Token);