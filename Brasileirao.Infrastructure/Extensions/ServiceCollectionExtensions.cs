using Brasileirao.Application.Commands.AdicionarCampeonato;
using Brasileirao.Application.Validators;
using Brasileirao.Domain.Repositories;
using Brasileirao.Infrastructure.Persistence;
using Brasileirao.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brasileirao.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("BRASILEIRAOAPI_DB_CONNECTION_STRING");
        services.AddDbContext<BrasileiraoApiDbContext>(
            opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        return services;
    }

    public static IServiceCollection AddFluentValidationSevices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AdicionarTimeCommandValidator>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
        services.AddScoped<ICampeonatoTimeRepository, CampeonatoTimeRepository>();
        services.AddScoped<IJogadorRepository, JogadorRepository>();
        services.AddScoped<IJogadorTituloRepository, JogadorTituloRepository>();
        services.AddScoped<ITimeRepository, TimeRepository>();
        services.AddScoped<ITimeTituloRepository, TimeTituloRepository>();
        services.AddScoped<ITituloRepository, TituloRepository>();
        services.AddScoped<IPartidaRepository, PartidaRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }


    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(AdicionarCampeonatoCommand).Assembly));
        return services;
    }
}