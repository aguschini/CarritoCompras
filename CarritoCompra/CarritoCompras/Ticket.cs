using System;
using System.Collections.Generic;
using System.Linq;

public class Ticket
{
    public int Id { get; }
    public DateTime FechaCompra { get; }
    public List<ItemTicket> Items { get; } = new List<ItemTicket>();
    public decimal Total { get; }

    public Ticket(int id, List<ItemCarrito> itemsCarrito)
    {
        Id = id;
        FechaCompra = DateTime.Now;
        Total = itemsCarrito.Sum(i => i.Subtotal()) * 1.21m;

        foreach (var item in itemsCarrito)
        {
            Items.Add(new ItemTicket(
                item.Producto.Codigo,
                item.Producto.Nombre,
                item.Cantidad,
                item.Producto.Precio,
                item.Subtotal()
            ));
        }
    }

    public override string ToString()
    {
        return $"Ticket #{Id} - {FechaCompra} - Total: ${Total}";
    }

    public string DetalleCompleto()
    {
        var detalle = $"=== TICKET #{Id} ===\n";
        detalle += $"Fecha: {FechaCompra}\n";
        detalle += "Productos:\n";

        foreach (var item in Items)
        {
            detalle += $"- {item.Nombre} x{item.Cantidad} @ ${item.PrecioUnitario} = ${item.Subtotal}\n";
        }

        detalle += $"Subtotal: ${Items.Sum(i => i.Subtotal)}\n";
        detalle += $"IVA (21%): ${Items.Sum(i => i.Subtotal) * 0.21m}\n";
        detalle += $"TOTAL: ${Total}\n";

        return detalle;
    }
}

public class ItemTicket
{
    public int CodigoProducto { get; }
    public string Nombre { get; }
    public int Cantidad { get; }
    public decimal PrecioUnitario { get; }
    public decimal Subtotal { get; }

    public ItemTicket(int codigoProducto, string nombre, int cantidad, decimal precioUnitario, decimal subtotal)
    {
        CodigoProducto = codigoProducto;
        Nombre = nombre;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        Subtotal = subtotal;
    }
}