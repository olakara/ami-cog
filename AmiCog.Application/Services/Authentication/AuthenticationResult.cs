using AmiCog.Domain.Entities;

namespace AmiCog.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token);