using Curso.Biblioteca.Aplicacion.Servicios;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Contexto;
using Curso.Biblioteca.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//
builder.Services.AddDbContext<BibliotecaDbContexto>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();
builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();
builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();

builder.Services.AddTransient<ILibroServicio, LibroServicio>();
builder.Services.AddTransient<IEditorialServicio, EditorialServicio>();
builder.Services.AddTransient<IAutorServicio, AutorServicio>();

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
