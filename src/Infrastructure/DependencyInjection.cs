using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var conn = config.GetConnectionString("DefaultConnection")
            ?? "Server=(localdb)\\mssqllocaldb;Database=DemoBlazorRealtime;Trusted_Connection=True;MultipleActiveResultSets=true";
        services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(conn));
        services.AddScoped<IRevoConfigService, RevoConfigService>();
        services.AddScoped<IRealtimeDataService, RealtimeDataService>();
        return services;
    }
}
