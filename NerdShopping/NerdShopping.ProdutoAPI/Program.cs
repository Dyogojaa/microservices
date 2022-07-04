using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NerdShopping.ProdutoAPI.Config;
using NerdShopping.ProdutoAPI.Model.Context;
using NerdShopping.ProdutoAPI.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration["MySqlConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(option => option.UseMySql(connection, new MySqlServerVersion(new Version(8,0,29))));
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
