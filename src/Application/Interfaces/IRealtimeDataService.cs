using Application.DTOs;

namespace Application.Interfaces;

public interface IRealtimeDataService
{
    Task<RealtimeDataDto?> GetLatestAsync(CancellationToken ct = default);
    Task<RealtimeDataDto?> GetPreviousAsync(CancellationToken ct = default);
}
