using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    private readonly IRevoConfigService _configService;

    public ConfigController(IRevoConfigService configService)
    {
        _configService = configService;
    }

    [HttpGet("active")]
    public async Task<ActionResult<RevoConfigDto?>> GetActive(CancellationToken ct)
    {
        var config = await _configService.GetActiveConfigAsync(ct);
        return config == null ? NotFound() : Ok(config);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RevoConfigDto?>> GetById(Guid id, CancellationToken ct)
    {
        var config = await _configService.GetByIdAsync(id, ct);
        return config == null ? NotFound() : Ok(config);
    }

    [HttpPost]
    public async Task<ActionResult<RevoConfigDto>> Save([FromBody] RevoConfigDto dto, CancellationToken ct)
    {
        var result = await _configService.SaveConfigAsync(dto, ct);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<RevoConfigDto>> Update(Guid id, [FromBody] RevoConfigDto dto, CancellationToken ct)
    {
        dto.Id = id;
        var result = await _configService.SaveConfigAsync(dto, ct);
        return Ok(result);
    }
}
