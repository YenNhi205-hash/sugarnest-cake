using Domain.IExternalServices;
using Domain.IRepositories;
using Domain.IRepositories.Base;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Models;

namespace Infrastructure;

public static class Extension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        //services.AddScoped<IEmailSenderService>(provider =>
        //{
        //    var settings = provider.GetRequiredService<IOptions<EmailSettings>>().Value;
        //    return new EmailSenderService(settings.Username, settings.Password);
        //});

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
