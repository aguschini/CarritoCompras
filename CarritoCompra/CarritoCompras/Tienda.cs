using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        private List<Producto> Productos { get; } = new List<Producto>();
        private List<Categoria> Categorias { get; } = new List<Categoria>();

        public void Tienda()
        {
            this.Productos = new List<Producto>();
            this.Categorias = new List<Categoria>();
        }
        public void AgregarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            if (!Categorias.Any(c => c.Nombre == categoria.Nombre))
            {
                Categorias.Add(categoria);
            }
        }
        public void AgregarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            if (!Productos.Any(p => p.Codigo == producto.Codigo))
            {
                Productos.Add(producto);
            }
        }
        public List<Producto> ObtenerProductosPorCategoria(string nombreCategoria)
        {
            return Productos
                .Where(p => p.Categoria.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public Producto BuscarProducto(int codigo)
        {
            return Productos.FirstOrDefault(p => p.Codigo == codigo);
        }
    }
}
