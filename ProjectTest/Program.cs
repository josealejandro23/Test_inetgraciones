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

//a�adimos el contexto de bases de datos a la aplicaci�n
builder.Services.AddDbContext<ApplicationDbContext>
    (opciones => opciones.UseSqlServer("name=DefaultConnection")
);
//Inyectamos el dbContext a utilizar en la aplicaci�n.
builder.Services.AddTransient<IApplicationContextDB, ApplicationDbContext>();
//se inyectan mediante interfaces los servicios a utilizar durante el tiempo de vida de la aplicaci�n
//se inyectan en Transient para mantener el consumo de memoria bajo al no almacenar los servicios en cach�
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
//se indica el uso del middleware de validaci�n de autenticaci�n
app.UseSecretCodeAuthentication();

app.Run();
