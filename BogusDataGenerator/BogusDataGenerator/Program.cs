using BogusDataGenerator.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Access
builder.Services.AddDbContextFactory<BogusDataExampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));

builder.Services.AddScoped<DataGenerator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/api/fakedata/generate", async (DataGenerator generator) =>
{
    await generator.Generate();
    return Results.Ok();
});

app.MapDelete("/api/fakedata/clear", async (DataGenerator generator) =>
{
    await generator.Clear();
    return Results.NoContent();
});

app.Run();
