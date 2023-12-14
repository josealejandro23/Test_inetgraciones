using Microsoft.EntityFrameworkCore;
using Test_jvarg361.DBContext;
using Test_jvarg361.Security;
using Test_jvarg361.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//añadimos el contexto de bases de datos a la aplicación
builder.Services.AddDbContext<ApplicationDbContext>
    (opciones => opciones.UseSqlServer("name=DefaultConnection")
);
//Inyectamos el dbContext a utilizar en la aplicación.
builder.Services.AddTransient<IApplicationContextDB, ApplicationDbContext>();
//se inyectan mediante interfaces los servicios a utilizar durante el tiempo de vida de la aplicación
//se inyectan en Transient para mantener el consumo de memoria bajo al no almacenar los servicios en caché
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProducService, ProductService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();

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
//se indica el uso del middleware de validación de autenticación
app.UseSecretCodeAuthentication();

app.Run();
