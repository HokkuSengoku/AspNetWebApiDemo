


using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TodoApi.DataAccess;
using TodoApi.DataAccess.EntityFrameworkCore;
using TodoApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<EfSuperLearningContext>(opt =>
    opt.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=SuperLearningUser"));
/*builder.Services.AddTransient<ISuperLearningRepository, EFSuperLearningRepository>();*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle*/
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