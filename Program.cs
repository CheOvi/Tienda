using Microsoft.OpenApi.Models;
using Tienda.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tienda API", Description = "Assisting Products", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tienda API V1");
    });
}

app.MapGet("/productos/{id}", (int id) => TiendaBD.GetProducto(id));
app.MapGet("/productos", () => TiendaBD.GetProductos());
app.MapPost("/productos", (Producto producto) => TiendaBD.CreateProducto(producto));
app.MapPut("/productos", (Producto producto) => TiendaBD.UpdateProducto(producto));
app.MapDelete("/productos/{id}", (int id) => TiendaBD.RemoveProducto(id));

app.Run();
