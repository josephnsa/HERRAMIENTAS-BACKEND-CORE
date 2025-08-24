using Data.Base;
using Data.Repository;
using Microsoft.OpenApi.Models;
using Service.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar conexión a BD
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IConexion>(new Conexion(connectionString));

// Inyección de dependencias
builder.Services.AddScoped<IPruebaRepository, PruebaRepository>();
builder.Services.AddScoped<IPruebaService, PruebaService>();

// Configurar Swagger para .NET 9
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Microservicio API",
		Version = "v1",
		Description = "API para gestión de usuarios",
		Contact = new OpenApiContact
		{
			Name = "Development Team",
			Email = "dev@example.com"
		}
	});
});

// Add OpenAPI service para .NET 9
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservicio API V1");
	c.RoutePrefix = string.Empty; // Página principal
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ESENCIAL para .NET 9: Map OpenAPI
app.MapOpenApi();

app.Run();