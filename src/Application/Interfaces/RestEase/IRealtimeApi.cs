using Application.DTOs;
using RestEase;

namespace Application.Interfaces.RestEase;

/// <summary>
/// Interface RestEase cho Realtime API.
/// </summary>
[BasePath("api/Realtime")]
public interface IRealtimeApi
{
    [Get("first")]
    Task<RealtimeDataDto?> GetFirstOrDefaultAsync(CancellationToken ct = default);
}
