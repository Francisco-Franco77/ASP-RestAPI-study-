using Microsoft.EntityFrameworkCore;
using Playmove.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true, reloadOnChange: true);
var path = builder.Configuration.GetValue<string>("DbPath");
builder.Services.AddDbContext<PlaymoveDataContext>(opt => opt.UseSqlServer(builder.Configuration.GetValue<string>("DbPath")));

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
