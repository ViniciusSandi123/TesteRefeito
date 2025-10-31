using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TesteRefeito.Data;
using TesteRefeito.Mappings;
using TesteRefeito.Repositories;
using TesteRefeito.Repositories.Interfaces;
using TesteRefeito.Services;
using TesteRefeito.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

//Mapeamento
builder.Services.AddAutoMapper(typeof(Mappings));

//Repositorios
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmesRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IStreamingRepository, StreamingRepository>();

//Servi�os
builder.Services.AddScoped<IGeneroService, GenerosServices>();
builder.Services.AddScoped<IStreamingService, StreamingServices>();
builder.Services.AddScoped<IFilmesService, FilmesServices>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://+:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
