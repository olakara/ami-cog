using AmiCog.Api.Common.Errors;
using AmiCog.Api.Common.Mapping;
using AmiCog.Application;
using AmiCog.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddMappings();

    builder.Services.AddSingleton<ProblemDetailsFactory, AmiCogProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
