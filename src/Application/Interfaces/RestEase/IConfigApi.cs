using Application.DTOs;
using RestEase;

namespace Application.Interfaces.RestEase;

/// <summary>
/// Interface RestEase cho Config API.
/// </summary>
[BasePath("api/Config")]
public interface IConfigApi
{
    [Get("active")]
    Task<RevoConfigDto?> GetActiveAsync(CancellationToken ct = default);

    [Get("{id}")]
    Task<RevoConfigDto?> GetByIdAsync([Path] Guid id, CancellationToken ct = default);

    [Post("")]
    Task<RevoConfigDto> CreateAsync([Body] RevoConfigDto dto, CancellationToken ct = default);

    [Put("{id}")]
    Task<RevoConfigDto> UpdateAsync([Path] Guid id, [Body] RevoConfigDto dto, CancellationToken ct = default);
}
