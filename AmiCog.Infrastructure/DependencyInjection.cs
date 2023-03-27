using AmiCog.Application.Common.Interfaces.Authentication;
using AmiCog.Application.Common.Interfaces.Persistence;
using AmiCog.Application.Common.Interfaces.Services;
using AmiCog.Infrastructure.Authentication;
using AmiCog.Infrastructure.Persistence;
using AmiCog.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmiCog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}