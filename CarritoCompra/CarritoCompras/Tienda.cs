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
    }
}
