

public class ItemCarrito
{
    public Producto Producto { get; }
    public int Cantidad { get; set; }

    public ItemCarrito(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public decimal Subtotal()
    {
        decimal subtotal = Producto.Precio * Cantidad;

        // Aplicar descuento si compra 5 o más unidades
        if (Cantidad >= 5)
        {
            subtotal *= 0.85m; // 15% de descuento
        }

        return subtotal;
    }

    public override string ToString()
    {
        return $"{Producto.Nombre} x{Cantidad} = ${Subtotal()}";
    }
}