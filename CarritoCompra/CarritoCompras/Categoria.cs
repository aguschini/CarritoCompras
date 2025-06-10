using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Categoria
    {
        //atributos
        private string nombre { get; set; };
        private string descripcion { get; set; };

        //contructor
        public void categoria(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
