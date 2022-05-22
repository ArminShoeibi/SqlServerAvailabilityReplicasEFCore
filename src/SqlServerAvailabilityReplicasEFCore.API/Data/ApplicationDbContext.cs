using Microsoft.EntityFrameworkCore;

namespace SqlServerAvailabilityReplicasEFCore.API.Data;

public class ApplicationDbContext : DbContext
{
    public static string DefaultConnectionStringKey => "WriteDB";
    public static string ReadConnectionStringKey => "ReadDB";

    public static string? WriteConnectionString { get; set; }
    public static string? ReadConnectionString { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
