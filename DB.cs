namespace Tienda.DB;


public record Producto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class TiendaBD
{
    private static List<Producto> _producto = new List<Producto>()
{
 new Producto{ Id=1, Name="Iphone", Description = "13 pro max" },
 new Producto{ Id=2, Name="Tablet", Description=" ipan 2021"},
 new Producto{ Id=3, Name="Ovidio", Description="perez"},
 new Producto{ Id=4, Name="Roberto", Description="Marroco"}
};

    public static List<Producto> GetProductos()
    {
        return _producto;
    }

    public static Producto? GetProducto(int id)
    {
        return _producto.SingleOrDefault(producto => producto.Id == id);
    }

    public static Producto CreateProducto(Producto producto)
    {
        _producto.Add(producto);
        return producto;
    }

    public static Producto UpdateProducto(Producto update)
    {
        _producto = _producto.Select(producto =>
        {
            if (producto.Id == update.Id)
            {
                producto.Name = update.Name;
            }
            return producto;
        }).ToList();
        return update;
    }

    public static void RemoveProducto(int id)
    {
        _producto = _producto.FindAll(producto => producto.Id != id).ToList();
    }
}