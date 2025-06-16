using System.Collections.Generic;

public static class Database
{
    private static Tienda tienda;
    private static Carrito carrito = new Carrito();

    static Database()
    {
        // Inicializamos la tienda con datos precargados
        tienda = new Tienda();
        CargarDatosIniciales();
    }

    public static Tienda Tienda => tienda;
    public static Carrito Carrito => carrito;

    private static void CargarDatosIniciales()
    {
        // Crear categorías
        var electronica = new Categoria("Electrónica", "Productos electrónicos y dispositivos");
        var ropa = new Categoria("Ropa", "Prendas de vestir para hombres, mujeres y niños");
        var hogar = new Categoria("Hogar", "Artículos para el hogar y decoración");
        var deportes = new Categoria("Deportes", "Equipamiento deportivo y outdoor");
        var libros = new Categoria("Libros", "Libros de todos los géneros");

        tienda.Categorias.AddRange(new[] { electronica, ropa, hogar, deportes, libros });

        // Crear productos
        tienda.Productos.Add(new Producto("Smartphone X1", 899.99m, 50, electronica));
        tienda.Productos.Add(new Producto("Tablet Pro", 349.99m, 30, electronica));
        tienda.Productos.Add(new Producto("Laptop Elite", 1299.99m, 20, electronica));
        tienda.Productos.Add(new Producto("Auriculares Inalámbricos", 79.99m, 100, electronica));

        tienda.Productos.Add(new Producto("Camiseta Casual", 24.99m, 200, ropa));
        tienda.Productos.Add(new Producto("Jeans Slim Fit", 49.99m, 150, ropa));
        tienda.Productos.Add(new Producto("Zapatos Urbanos", 89.99m, 80, ropa));
        tienda.Productos.Add(new Producto("Chaqueta de Cuero", 199.99m, 40, ropa));

        tienda.Productos.Add(new Producto("Sofá de 3 plazas", 799.99m, 15, hogar));
        tienda.Productos.Add(new Producto("Mesa de Centro", 149.99m, 25, hogar));
        tienda.Productos.Add(new Producto("Juego de Sábanas", 39.99m, 60, hogar));
        tienda.Productos.Add(new Producto("Lámpara Moderna", 59.99m, 45, hogar));

        tienda.Productos.Add(new Producto("Balón de Fútbol", 29.99m, 70, deportes));
        tienda.Productos.Add(new Producto("Raqueta de Tenis", 89.99m, 40, deportes));
        tienda.Productos.Add(new Producto("Mancuernas 5kg", 39.99m, 50, deportes));

        tienda.Productos.Add(new Producto("Novela Best Seller", 14.99m, 120, libros));
        tienda.Productos.Add(new Producto("Libro de Cocina", 29.99m, 60, libros));
        tienda.Productos.Add(new Producto("Guía de Viajes", 19.99m, 45, libros));
    }

    public static void FinalizarCompra()
    {
        foreach (var item in carrito.ObtenerItems())
        {
            item.Producto.Stock -= item.Cantidad;
        }
        carrito.Vaciar();
    }
}