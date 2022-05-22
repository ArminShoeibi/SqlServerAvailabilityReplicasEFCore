using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlServerAvailabilityReplicasEFCore.API.Attributes;
using SqlServerAvailabilityReplicasEFCore.API.Data;

namespace SqlServerAvailabilityReplicasEFCore.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[ReadOnlyConnectionString] // Controller Level
public class ReportsController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public ReportsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetOrderById()
    {
        return Ok(_db.Database.GetConnectionString());
    }
}
