using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class ItemCarrito
    {
        //atributos
        private string producto { get; set; };
        private string cantidad { get; private set; };

        //constructor
        public void itemcarrito(string producto, string cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }
    }
}
