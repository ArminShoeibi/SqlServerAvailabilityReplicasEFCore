using Microsoft.EntityFrameworkCore;
using SqlServerAvailabilityReplicasEFCore.API.ActionFilters;
using SqlServerAvailabilityReplicasEFCore.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(mvcOptions =>
{
    mvcOptions.Filters.Add<ReadOnlyConnectionStringActionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ApplicationDbContext.WriteConnectionString = builder.Configuration.GetConnectionString(ApplicationDbContext.DefaultConnectionStringKey);
ApplicationDbContext.ReadConnectionString = builder.Configuration.GetConnectionString(ApplicationDbContext.ReadConnectionStringKey);
builder.Services.AddDbContextPool<ApplicationDbContext>(dbContextOptionsBuilder =>
{
    dbContextOptionsBuilder.UseSqlServer(ApplicationDbContext.WriteConnectionString, sqlServerDbContextOptionsBuilder =>
    {
        sqlServerDbContextOptionsBuilder.CommandTimeout(20);
        sqlServerDbContextOptionsBuilder.EnableRetryOnFailure();
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
