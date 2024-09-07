var webApplicationBuilder = WebApplication.CreateBuilder(args);


#region Services Configuration
webApplicationBuilder.Services.AddControllers().AddJsonOptions(options =>
{
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
options.JsonSerializerOptions.WriteIndented = true;

});

webApplicationBuilder.Services.AddApplicationServices();

webApplicationBuilder.Services.AddEndpointsApiExplorer();
webApplicationBuilder.Services.AddSwaggerGen();

webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
});

webApplicationBuilder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = (actionContext) =>
    {
        var errors = actionContext.ModelState.Where(e => e.Value!.Errors.Count > 0)
            .SelectMany(x => x.Value!.Errors)
            .Select(x => x.ErrorMessage).ToArray();

        return new BadRequestObjectResult(new ApiValidationErrorResponse(errors));
    };
}); 
#endregion


var app = webApplicationBuilder.Build();

#region DataBase Migration
using var scope = app.Services.CreateScope();

var service = scope.ServiceProvider;

var _dbContect = service.GetRequiredService<ApplicationDbContext>();

var loggerFactory = service.GetRequiredService<ILoggerFactory>();

try
{
    await _dbContect.Database.MigrateAsync();
    await ApplicationContextSeed.SeedDataAsync(_dbContect);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}
#endregion

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
