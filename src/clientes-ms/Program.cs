using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using clientes_ms.libs;
using clientes_ms.Infrastructure.Persistence.Context;
using MicroservicesTemplate.Domain.Repositories;
using MicroservicesTemplate.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
//forzar a q salga por ese puerto
///builder.WebHost.UseUrls("http://localhost:5002");

//builder.WebHost.ConfigureKestrel(options =>
//{
//   // options.ListenAnyIP(90); // Escucha en el puerto 80 para que Docker lo pueda mapear
//});

// Cargar variables del .env
Env.Load();

// Obtener cadena de conexión
var connectionString = EnvironmentConfiguration.GetConnectionString();

// Configurar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Inyectar repositorios genéricos
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// Cargar MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// 🔥 Configuración de CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Servicios adicionales
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


var apiRootPath = EnvironmentConfiguration.GetApiRootPath();
if (!string.IsNullOrEmpty(apiRootPath))
{
    app.UsePathBase(apiRootPath);
}

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"{apiRootPath}/swagger/v1/swagger.json", "Clientes API V1");
        c.RoutePrefix = "swagger";  //Se deja esto si quieres acceder mediante /clients/swagger
    });
}
//// Swagger solo en entorno de desarrollo
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// 🔥 Usar la política de CORS antes de Authorization
app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.MapControllers();

app.Run();
