using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Estufa.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EstufaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EstufaContext") ?? throw new InvalidOperationException("Connection string 'EstufaContext' not found.")));

// Add services to the container.

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

app.Run();
