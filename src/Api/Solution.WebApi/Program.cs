using PdsCleanAppCore;
using PdsCleanAppInfrastructure;
using PdsCleanAppInfrastructure.DbPersistence;
using PdsCleanWebAPI;
using Serilog;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration);
}));

// Add services to the container.
builder.Services.AddWebAPIServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
try
{
    var seed = args[0].Contains("/seed");
    if (seed)
    {
        args = args.Except(new[] { "/seed" }).ToArray();
    }
    if (seed)
    {
        using var scope = app.Services.CreateAsyncScope();

        if (args[1] == "studentcoursedataseed")
        {
            var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await ApplicationDbContextInitialiser.SeedDefaultStudentCourseDataAsync(appDbContext);
        }

        return 0;
    }
}
catch
{
    return 1;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseSerilogRequestLogging();
app.UseCors("GeneralPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
return 0;