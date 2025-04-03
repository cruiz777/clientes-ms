using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using clientes_ms.libs;
using clientes_ms.Infrastructure.Persistence.Context;
using MicroservicesTemplate.Domain.Repositories;
using MicroservicesTemplate.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del .env
Env.Load();

// Obtener cadena de conexión
var connectionString = EnvironmentConfiguration.GetConnectionString();

// Agregar DbContext con cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Añadir servicios con DIP
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

//Este comando ensambla todos los queries, commands y handlers de mi capa de aplicacion
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Configuración estándar
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware y endpoints
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
