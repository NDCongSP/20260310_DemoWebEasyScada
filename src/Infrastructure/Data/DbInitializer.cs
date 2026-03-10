using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Data;

public static class DbInitializer
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        if (context.Database.GetPendingMigrations().Any())
            await context.Database.MigrateAsync();

        if (await context.RevoConfigs.AnyAsync())
            return;

        var loc1 = Guid.NewGuid();
        var loc2 = Guid.NewGuid();
        var loc3 = Guid.NewGuid();
        var locations = new List<LocationConfigItem>
        {
            new() { Id = loc1, Name = "Khu lò 1", Publish = true },
            new() { Id = loc2, Name = "Khu lò 2", Publish = true },
            new() { Id = loc3, Name = "Khu lò 3", Publish = false }
        };
        var c000 = JsonSerializer.Serialize(locations, JsonOptions);

        var config = new RevoConfig
        {
            Id = Guid.NewGuid(),
            C000 = c000,
            ReloadIntervalSeconds = 10,
            Actived = true,
            CreatedAt = DateTime.UtcNow
        };
        context.RevoConfigs.Add(config);

        var temps1 = new List<TemperaturePoint>
        {
            new() { LocationId = loc1, Temperature = 245.5 },
            new() { LocationId = loc2, Temperature = 252.0 }
        };
        var c00_1 = JsonSerializer.Serialize(temps1, JsonOptions);
        context.RealtimeData.Add(new RealtimeData
        {
            Id = Guid.NewGuid(),
            C00 = c00_1,
            CreatedAt = DateTime.UtcNow.AddMinutes(-2)
        });

        var temps2 = new List<TemperaturePoint>
        {
            new() { LocationId = loc1, Temperature = 246.2 },
            new() { LocationId = loc2, Temperature = 251.1 }
        };
        var c00_2 = JsonSerializer.Serialize(temps2, JsonOptions);
        context.RealtimeData.Add(new RealtimeData
        {
            Id = Guid.NewGuid(),
            C00 = c00_2,
            CreatedAt = DateTime.UtcNow
        });

        await context.SaveChangesAsync();
    }
}
