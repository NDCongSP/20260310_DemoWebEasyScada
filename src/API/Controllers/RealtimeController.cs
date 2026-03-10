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

    [HttpGet("latest")]
    public async Task<ActionResult<RealtimeDataDto?>> GetLatest(CancellationToken ct)
    {
        var data = await _realtimeService.GetLatestAsync(ct);
        return data == null ? NotFound() : Ok(data);
    }

    [HttpGet("previous")]
    public async Task<ActionResult<RealtimeDataDto?>> GetPrevious(CancellationToken ct)
    {
        var data = await _realtimeService.GetPreviousAsync(ct);
        return data == null ? NotFound() : Ok(data);
    }
}
