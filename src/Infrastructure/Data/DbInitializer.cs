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
            new() { Id = loc1, Name = "Oven 1", Publish = true ,Path = "Local Station/Channel1"},
            new() { Id = loc2, Name = "Oven 2", Publish = true ,Path = "Local Station/Channel2"},
            new() { Id = loc3, Name = "Oven 3", Publish = false ,Path = "Local Station/Channel3"}
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
            new() { LocationId = loc1, Temperature = 245.5,Path = "Local Station/Channel1" },
            new() { LocationId = loc2, Temperature = 252.0,Path = "Local Station/Channel2" }
        };
        var c00_1 = JsonSerializer.Serialize(temps1, JsonOptions);
        context.RealtimeData.Add(new RealtimeData
        {
            Id = Guid.NewGuid(),
            C00 = c00_1,
            CreatedAt = DateTime.UtcNow.AddMinutes(-2)
        });

        
        await context.SaveChangesAsync();
    }
}
