using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SqlServerAvailabilityReplicasEFCore.API.Attributes;
using SqlServerAvailabilityReplicasEFCore.API.Data;

namespace SqlServerAvailabilityReplicasEFCore.API.ActionFilters;

public class ReadOnlyConnectionStringActionFilter : IActionFilter
{
    private readonly ApplicationDbContext _db;
    private bool _connectionStringChanged = false;
    public ReadOnlyConnectionStringActionFilter(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<ReadOnlyConnectionStringAttribute>().Any())
        {
            // Change your query tracking here.
            // Don't worry about changing it to defualt value after this, because ObjectPool takes care of that.
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            _db.Database.SetConnectionString(ApplicationDbContext.ReadConnectionString);
            _connectionStringChanged = true;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (_connectionStringChanged) _db.Database.SetConnectionString(ApplicationDbContext.WriteConnectionString);
    }
}
