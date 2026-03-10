using Application.DTOs;

namespace Application.Interfaces;

public interface IRealtimeDataService
{
    /// <summary>
    /// Lấy bản ghi first or default (theo CreatedAt tăng dần).
    /// </summary>
    Task<RealtimeDataDto?> GetFirstOrDefaultAsync(CancellationToken ct = default);
}
