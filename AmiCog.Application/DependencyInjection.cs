using AmiCog.Application.Authentication.Commands.Register;
using AmiCog.Application.Authentication.Common;
using AmiCog.Application.Common.Behaviors;
using MediatR;
using ErrorOr;
using Microsoft.Extensions.DependencyInjection;

namespace AmiCog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<
                IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
                ValidateRegisterCommandBehavior>();
        return services;
    }
}