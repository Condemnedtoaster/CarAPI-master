using Microsoft.EntityFrameworkCore;
using CarAPI;
using CarAPI.Contexts;
using CarAPI.Repositories;

const string policyName = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
    options.AddPolicy(name: "OnlyGET",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .WithMethods("GET")
                                  .AllowAnyHeader();
                              });
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

bool useSql = true;
if (useSql)
{
    var optionsBuilder =
        new DbContextOptionsBuilder<CarContext>();
    optionsBuilder.UseSqlServer(Secrets.ConnectionString);
    CarContext context = 
        new CarContext(optionsBuilder.Options);
    builder.Services.AddSingleton<ICarRepository>(
        new CarRepositoryDB(context));
}
else
{
    builder.Services.AddSingleton<ICarRepository>
        (new CarRepository());
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
