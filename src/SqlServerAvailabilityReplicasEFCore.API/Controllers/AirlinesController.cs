using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlServerAvailabilityReplicasEFCore.API.Attributes;
using SqlServerAvailabilityReplicasEFCore.API.Data;

namespace SqlServerAvailabilityReplicasEFCore.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AirlinesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public AirlinesController(ApplicationDbContext db)
    {
        _db = db;
    }

    [ReadOnlyConnectionString] // Action method level
    [HttpGet]
    public IActionResult GetAirlines()
    {
        string currentConnectionString = _db.Database.GetConnectionString()!;
        return Ok(currentConnectionString);
    }

    [HttpPost]
    public IActionResult CreateAirline()
    {
        string currentConnectionString = _db.Database.GetConnectionString()!;
        return Ok(currentConnectionString);
    }

}
