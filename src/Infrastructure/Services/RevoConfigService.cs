using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Services;

public class RevoConfigService : IRevoConfigService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly ApplicationDbContext _db;

    public RevoConfigService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RevoConfigDto?> GetActiveConfigAsync(CancellationToken ct = default)
    {
        var entity = await _db.RevoConfigs
            .Where(x => x.Actived == true)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync(ct);
        return entity == null ? null : MapToDto(entity);
    }

    public async Task<RevoConfigDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _db.RevoConfigs.FindAsync(new object[] { id }, ct);
        return entity == null ? null : MapToDto(entity);
    }

    public async Task<RevoConfigDto> SaveConfigAsync(RevoConfigDto dto, CancellationToken ct = default)
    {
        var locationsJson = dto.Locations != null
            ? JsonSerializer.Serialize(dto.Locations, JsonOptions)
            : dto.C000;

        if (dto.Id == Guid.Empty)
        {
            var entity = new RevoConfig
            {
                Id = Guid.NewGuid(),
                C000 = locationsJson,
                ReloadIntervalSeconds = dto.ReloadIntervalSeconds ?? 10,
                Actived = dto.Actived ?? true,
                CreatedAt = DateTime.UtcNow
            };
            _db.RevoConfigs.Add(entity);
            await _db.SaveChangesAsync(ct);
            return MapToDto(entity);
        }

        var existing = await _db.RevoConfigs.FindAsync(new object[] { dto.Id }, ct);
        if (existing == null)
            throw new InvalidOperationException("Config not found.");
        existing.C000 = locationsJson;
        existing.ReloadIntervalSeconds = dto.ReloadIntervalSeconds ?? 10;
        existing.Actived = dto.Actived ?? true;
        await _db.SaveChangesAsync(ct);
        return MapToDto(existing);
    }

    private static RevoConfigDto MapToDto(RevoConfig e)
    {
        List<LocationConfigItemDto>? locations = null;
        if (!string.IsNullOrWhiteSpace(e.C000))
        {
            try
            {
                locations = JsonSerializer.Deserialize<List<LocationConfigItemDto>>(e.C000, JsonOptions);
            }
            catch { /* ignore */ }
        }
        return new RevoConfigDto
        {
            Id = e.Id,
            C000 = e.C000,
            ReloadIntervalSeconds = e.ReloadIntervalSeconds ?? 10,
            Actived = e.Actived ?? true,
            CreatedAt = e.CreatedAt,
            Locations = locations ?? new List<LocationConfigItemDto>()
        };
    }
}
