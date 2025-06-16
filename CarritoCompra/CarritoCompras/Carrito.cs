using System.Collections.Generic;
using System.Linq;

public class Carrito
{
    private List<ItemCarrito> items = new List<ItemCarrito>();

    public void AgregarItem(Producto producto, int cantidad)
    {
        // Verificar si el producto ya está en el carrito
        var itemExistente = items.FirstOrDefault(i => i.Producto.Codigo == producto.Codigo);

        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            items.Add(new ItemCarrito(producto, cantidad));
        }
    }

    public void EliminarItem(int codigoProducto)
    {
        items.RemoveAll(i => i.Producto.Codigo == codigoProducto);
    }

    public decimal CalcularTotal()
    {
        decimal subtotal = items.Sum(i => i.Subtotal());
        decimal iva = subtotal * 0.21m;
        return subtotal + iva;
    }

    public List<ItemCarrito> ObtenerItems()
    {
        return new List<ItemCarrito>(items);
    }

    public void Vaciar()
    {
        items.Clear();
    }
}