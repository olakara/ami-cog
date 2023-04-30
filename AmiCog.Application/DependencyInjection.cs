using System.Reflection;
using AmiCog.Application.Authentication.Commands.Register;
using AmiCog.Application.Authentication.Common;
using AmiCog.Application.Common.Behaviors;
using MediatR;
using ErrorOr;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AmiCog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}