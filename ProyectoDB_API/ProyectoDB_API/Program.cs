using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoDB_API.Models;
using ProyectoDB_API.Repositories;
using ProyectoDB_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Add(new ServiceDescriptor(typeof(ICategoria), new CategoriaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDetalleVenta), new DetalleVentaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IPersona), new PersonaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProducto), new ProductoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IVenta), new VentaRepository()));

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
