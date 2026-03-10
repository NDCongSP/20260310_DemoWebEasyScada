using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Services;

public class RealtimeDataService : IRealtimeDataService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly ApplicationDbContext _db;

    public RealtimeDataService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RealtimeDataDto?> GetFirstOrDefaultAsync(CancellationToken ct = default)
    {
        var entity = await _db.RealtimeData
            .FirstOrDefaultAsync(ct);
        return entity == null ? null : MapToDto(entity);
    }

    private RealtimeDataDto MapToDto(Domain.Entities.RealtimeData entity)
    {
        List<TemperaturePointDto>? temps = null;
        if (!string.IsNullOrWhiteSpace(entity.C00))
        {
            try { temps = JsonSerializer.Deserialize<List<TemperaturePointDto>>(entity.C00, JsonOptions); }
            catch { /* ignore */ }
        }
        return new RealtimeDataDto
        {
            Id = entity.Id,
            C00 = entity.C00,
            CreatedAt = entity.CreatedAt,
            Temperatures = temps ?? new List<TemperaturePointDto>()
        };
    }
}
