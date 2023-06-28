using ProyectoDesarrollo.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(IPersona), new PersonaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICategoria), new CategoriaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProducto), new ProductoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IVenta), new VentaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDetalleVenta),new DetalleVentaRepository()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Logueo}/{action=Index}/{id?}");

app.Run();
