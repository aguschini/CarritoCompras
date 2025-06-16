using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            MostrarMenu();
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    VerCategorias();
                    break;
                case "2":
                    VerProductos();
                    break;
                case "3":
                    VerProductosPorCategoria();
                    break;
                case "4":
                    AgregarAlCarrito();
                    break;
                case "5":
                    EliminarDelCarrito();
                    break;
                case "6":
                    VerCarrito();
                    break;
                case "7":
                    VerTotalAPagar();
                    break;
                case "8":
                    FinalizarCompra();
                    break;
                case "9":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Ver categorías disponibles");
        Console.WriteLine("2. Ver todos los productos");
        Console.WriteLine("3. Ver productos por categoría");
        Console.WriteLine("4. Agregar producto al carrito");
        Console.WriteLine("5. Eliminar producto del carrito");
        Console.WriteLine("6. Ver contenido del carrito");
        Console.WriteLine("7. Ver total a pagar");
        Console.WriteLine("8. Finalizar compra");
        Console.WriteLine("9. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void VerCategorias()
    {
        Console.WriteLine("\n=== CATEGORÍAS DISPONIBLES ===");
        foreach (var categoria in Database.Tienda.Categorias)
        {
            Console.WriteLine(categoria);
        }
    }

    static void VerProductos()
    {
        Console.WriteLine("\n=== PRODUCTOS DISPONIBLES ===");
        foreach (var producto in Database.Tienda.Productos)
        {
            Console.WriteLine(producto);
        }
    }

    static void VerProductosPorCategoria()
    {
        VerCategorias();
        Console.Write("\nIngrese el nombre de la categoría: ");
        var nombreCategoria = Console.ReadLine();

        var productos = Database.Tienda.ObtenerProductosPorCategoria(nombreCategoria);

        if (productos.Any())
        {
            Console.WriteLine($"\n=== PRODUCTOS EN CATEGORÍA {nombreCategoria.ToUpper()} ===");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }
        else
        {
            Console.WriteLine("Categoría no encontrada o sin productos.");
        }
    }

    static void AgregarAlCarrito()
    {
        VerProductos();
        Console.Write("\nIngrese el código del producto: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código inválido.");
            return;
        }

        var producto = Database.Tienda.BuscarProducto(codigo);
        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.Write("Ingrese la cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Cantidad inválida.");
            return;
        }

        if (cantidad > producto.Stock)
        {
            Console.WriteLine($"No hay suficiente stock. Stock disponible: {producto.Stock}");
            return;
        }

        Database.Carrito.AgregarItem(producto, cantidad);
        Console.WriteLine($"Producto agregado al carrito: {producto.Nombre} x{cantidad}");
    }

    static void EliminarDelCarrito()
    {
        var items = Database.Carrito.ObtenerItems();
        if (!items.Any())
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }

        Console.WriteLine("\n=== PRODUCTOS EN EL CARRITO ===");
        foreach (var item in items)
        {
            Console.WriteLine($"[{item.Producto.Codigo}] {item}");
        }

        Console.Write("\nIngrese el código del producto a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código inválido.");
            return;
        }

        Database.Carrito.EliminarItem(codigo);
        Console.WriteLine("Producto eliminado del carrito.");
    }

    static void VerCarrito()
    {
        var items = Database.Carrito.ObtenerItems();
        if (!items.Any())
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }

        Console.WriteLine("\n=== CONTENIDO DEL CARRITO ===");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"\nSubtotal: ${items.Sum(i => i.Subtotal())}");
        Console.WriteLine($"IVA (21%): ${items.Sum(i => i.Subtotal()) * 0.21m}");
        Console.WriteLine($"Total a pagar: ${Database.Carrito.CalcularTotal()}");
    }

    static void VerTotalAPagar()
    {
        var total = Database.Carrito.CalcularTotal();
        Console.WriteLine($"\nTotal a pagar: ${total}");
    }

    static void FinalizarCompra()
    {
        var items = Database.Carrito.ObtenerItems();
        if (!items.Any())
        {
            Console.WriteLine("El carrito está vacío. No hay nada que comprar.");
            return;
        }

        VerCarrito();
        Console.Write("\n¿Confirmar compra? (S/N): ");
        var confirmacion = Console.ReadLine()?.ToUpper();

        if (confirmacion == "S")
        {
            Database.FinalizarCompra();
            Console.WriteLine("¡Compra realizada con éxito! Gracias por su compra.");
        }
        else
        {
            Console.WriteLine("Compra cancelada.");
        }
    }
}