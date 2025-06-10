using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main()
        {
            var tienda = InicializarTienda();
            var carrito = new Carrito();

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarCategorias(tienda);
                        break;
                    case "2":
                        MostrarProductos(tienda);
                        break;
                    case "3":
                        MostrarProductosPorCategoria(tienda);
                        break;
                    case "4":
                        AgregarAlCarrito(tienda, carrito);
                        break;
                    case "5":
                        EliminarDelCarrito(carrito);
                        break;
                    case "6":
                        MostrarCarrito(carrito);
                        break;
                    case "7":
                        MostrarTotal(carrito);
                        break;
                    case "8":
                        FinalizarCompra(carrito);
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

        static Tienda InicializarTienda()
        {
            var tienda = new Tienda();

            // Crear categorías
            var electronica = new Categoria("Electrónica", "Productos electrónicos");
            var ropa = new Categoria("Ropa", "Prendas de vestir");
            var hogar = new Categoria("Hogar", "Artículos para el hogar");

            tienda.AgregarCategoria(electronica);
            tienda.AgregarCategoria(ropa);
            tienda.AgregarCategoria(hogar);

            // Agregar productos
            tienda.AgregarProducto(new Producto("Smartphone", 599.99m, 10, electronica));
            tienda.AgregarProducto(new Producto("Laptop", 999.99m, 5, electronica));
            tienda.AgregarProducto(new Producto("Auriculares", 49.99m, 15, electronica));
            tienda.AgregarProducto(new Producto("Camiseta", 19.99m, 20, ropa));
            tienda.AgregarProducto(new Producto("Pantalón", 39.99m, 12, ropa));
            tienda.AgregarProducto(new Producto("Sartén", 29.99m, 8, hogar));

            return tienda;
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

        static void MostrarCategorias(Tienda tienda)
        {
            Console.WriteLine("\n=== CATEGORÍAS DISPONIBLES ===");
            foreach (var categoria in tienda.Categorias)
            {
                Console.WriteLine($"- {categoria.Nombre}: {categoria.Descripcion}");
            }
        }

        static void MostrarProductos(Tienda tienda)
        {
            Console.WriteLine("\n=== PRODUCTOS DISPONIBLES ===");
            Console.WriteLine("{0,-5} {1,-30} {2,-10} {3,-10} {4}", "Cód", "Nombre", "Precio", "Stock", "Categoría");
            foreach (var producto in tienda.Productos)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-10:C} {3,-10} {4}",
                    producto.Codigo,
                    producto.Nombre,
                    producto.Precio,
                    producto.Stock,
                    producto.Categoria.Nombre);
            }
        }

        static void MostrarProductosPorCategoria(Tienda tienda)
        {
            MostrarCategorias(tienda);
            Console.Write("\nIngrese el nombre de la categoría: ");
            var nombreCategoria = Console.ReadLine();

            var productos = tienda.ObtenerProductosPorCategoria(nombreCategoria);

            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos en esta categoría.");
                return;
            }

            Console.WriteLine($"\n=== PRODUCTOS EN CATEGORÍA {nombreCategoria.ToUpper()} ===");
            Console.WriteLine("{0,-5} {1,-30} {2,-10} {3,-10}", "Cód", "Nombre", "Precio", "Stock");
            foreach (var producto in productos)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-10:C} {3,-10}",
                    producto.Codigo,
                    producto.Nombre,
                    producto.Precio,
                    producto.Stock);
            }
        }

        static void AgregarAlCarrito(Tienda tienda, Carrito carrito)
        {
            MostrarProductos(tienda);

            Console.Write("\nIngrese el código del producto: ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            Console.Write("Ingrese la cantidad: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad inválida.");
                return;
            }

            var producto = tienda.BuscarProducto(codigo);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            if (carrito.AgregarItem(producto, cantidad))
            {
                Console.WriteLine($"Producto '{producto.Nombre}' agregado al carrito.");
            }
            else
            {
                Console.WriteLine("No se pudo agregar el producto. Verifique el stock disponible.");
            }
        }

        static void EliminarDelCarrito(Carrito carrito)
        {
            if (carrito.Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            MostrarCarrito(carrito);

            Console.Write("\nIngrese el código del producto a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            if (carrito.RemoverItem(codigo))
            {
                Console.WriteLine("Producto eliminado del carrito.");
            }
            else
            {
                Console.WriteLine("No se encontró el producto en el carrito.");
            }
        }

        static void MostrarCarrito(Carrito carrito)
        {
            if (carrito.Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("\n=== CONTENIDO DEL CARRITO ===");
            Console.WriteLine("{0,-5} {1,-30} {2,-10} {3,-10} {4}", "Cód", "Nombre", "Precio", "Cantidad", "Subtotal");
            foreach (var item in carrito.Items)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-10:C} {3,-10} {4:C}",
                    item.Producto.Codigo,
                    item.Producto.Nombre,
                    item.Producto.Precio,
                    item.Cantidad,
                    item.CalcularSubtotal());
            }
        }

        static void MostrarTotal(Carrito carrito)
        {
            if (carrito.Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            MostrarCarrito(carrito);
            Console.WriteLine($"\nTOTAL A PAGAR: {carrito.CalcularTotal():C}");
        }

        static void FinalizarCompra(Carrito carrito)
        {
            if (carrito.Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío. No hay nada que comprar.");
                return;
            }

            MostrarTotal(carrito);

            Console.Write("\n¿Confirmar compra? (S/N): ");
            var confirmacion = Console.ReadLine().ToUpper();

            if (confirmacion == "S")
            {
                if (carrito.RealizarCompra())
                {
                    Console.WriteLine("¡Compra realizada con éxito! Gracias por su compra.");
                }
                else
                {
                    Console.WriteLine("No se pudo completar la compra. Verifique el stock disponible.");
                }
            }
            else
            {
                Console.WriteLine("Compra cancelada.");
            }
        }
    }
