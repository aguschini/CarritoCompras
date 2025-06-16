using System;
using System.Collections.Generic;
using System.Linq;

public class Tienda
{
    public List<Producto> Productos { get; } = new List<Producto>();
    public List<Categoria> Categorias { get; } = new List<Categoria>();

    public List<Producto> ObtenerProductosPorCategoria(string nombreCategoria)
    {
        return Productos.Where(p => p.Categoria.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Producto BuscarProducto(int codigo)
    {
        return Productos.FirstOrDefault(p => p.Codigo == codigo);
    }
}