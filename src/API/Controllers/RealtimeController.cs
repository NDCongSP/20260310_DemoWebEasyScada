using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RealtimeController : ControllerBase
{
    private readonly IRealtimeDataService _realtimeService;

    public RealtimeController(IRealtimeDataService realtimeService)
    {
        _realtimeService = realtimeService;
    }

    [HttpGet("first")]
    public async Task<ActionResult<RealtimeDataDto?>> GetFirst(CancellationToken ct)
    {
        var data = await _realtimeService.GetFirstOrDefaultAsync(ct);
        return data == null ? NotFound() : Ok(data);
    }
}
