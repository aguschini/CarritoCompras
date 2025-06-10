using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Producto
    {
        //atributos
        private int codigo { get; set; };
        private string nombre { get; set; };
        private float precio { get; set; };
        private string stock { get; set; };
        private Categoria categoria { get; set; };

        //constructor
        public void producto(int codigo, string nombre, float precio, string stock, Categoria categoria)
        {
            this.codigo = Interlocked.Increment(ref ultimoCodigo);
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.categoria = categoria;
        }
    }
}
