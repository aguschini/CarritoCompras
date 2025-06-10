using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Carrito
    {
        private List<ItemCarrito> _items;

        public void carrito(List<ItemCarrito> items)
        {
            _items = new List<ItemCarrito>();
        }
    }
}
