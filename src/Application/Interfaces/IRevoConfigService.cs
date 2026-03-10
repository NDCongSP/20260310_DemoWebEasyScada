using Application.DTOs;

namespace Application.Interfaces;

public interface IRevoConfigService
{
    Task<RevoConfigDto?> GetActiveConfigAsync(CancellationToken ct = default);
    Task<RevoConfigDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<RevoConfigDto> SaveConfigAsync(RevoConfigDto dto, CancellationToken ct = default);
}
