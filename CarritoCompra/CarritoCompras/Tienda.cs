using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

public class Tienda
{
    public List<Producto> Productos { get; } = new List<Producto>();
    public List<Categoria> Categorias { get; } = new List<Categoria>();
    public List<Ticket> Tickets { get; } = new List<Ticket>();
    private int proximoIdTicket = 1;

    public List<Producto> ObtenerProductosPorCategoria(string nombreCategoria)
    {
        return Productos.Where(p => p.Categoria.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Producto BuscarProducto(int codigo)
    {
        return Productos.FirstOrDefault(p => p.Codigo == codigo);
    }

    public void AgregarTicket(List<ItemCarrito> itemsCarrito)
    {
        var ticket = new Ticket(proximoIdTicket++, itemsCarrito);
        Tickets.Add(ticket);
    }

    public Ticket BuscarTicket(int id)
    {
        return Tickets.FirstOrDefault(t => t.Id == id);
    }
}