using AmiCog.Application.Services.Authentication;
using AmiCog.Application.Services.Authentication.Commands;
using AmiCog.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace AmiCog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}