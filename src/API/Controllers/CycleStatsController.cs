using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CycleStatsController(ICycleStatsServices statsService) : BaseApiController
{
    [HttpGet("pressure")]
    public async Task<ActionResult<IEnumerable<PressureStatsDto>>> GetPressureStats()
    {
        var stats = await statsService.CyclePressureIncomplet();
        
        if (stats == null) return NotFound("Stats not found");

        return Ok(stats);
    }
}