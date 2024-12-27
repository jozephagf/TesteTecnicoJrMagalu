using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TesteTecnicoJrMagalu.Database;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Swagger Documentação Web API",
        Description = "Teste Técnico Jr - Magalu",
        Contact = new OpenApiContact() { Name = "José Alberto", Email = "josezealberto@outlook.com" },
        License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<ICTeRepository, CteRepository>();
builder.Services.AddTransient<IUFRepository, UFRepository>();
builder.Services.AddTransient<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddTransient<ICteInfCargaInfQRepository, CteInfCargaInfQRepository>();

var connectionString = "Server=localhost;" +
              "Port=5432;Database=TesteTecnicoMagalu;" +
              "User Id=postgres;" +
              "Password=Jalb123;";

builder.Services.AddDbContext<ConnectionContext>(options => options.UseNpgsql(connectionString));

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
