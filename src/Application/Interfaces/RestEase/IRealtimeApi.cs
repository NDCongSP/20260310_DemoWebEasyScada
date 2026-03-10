using Application.DTOs;
using RestEase;

namespace Application.Interfaces.RestEase;

/// <summary>
/// Interface RestEase cho Realtime API.
/// </summary>
[BasePath("api/Realtime")]
public interface IRealtimeApi
{
    [Get("latest")]
    Task<RealtimeDataDto?> GetLatestAsync(CancellationToken ct = default);

    [Get("previous")]
    Task<RealtimeDataDto?> GetPreviousAsync(CancellationToken ct = default);
}
