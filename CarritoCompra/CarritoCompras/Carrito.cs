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

        public IReadOnlyList<ItemCarrito> Items => _items.AsReadOnly();
        public void carrito(List<ItemCarrito> items)
        {
            _items = new List<ItemCarrito>();
        }
        public bool AgregarItem(Producto producto, int cantidad)
        {
            if (producto == null || cantidad <= 0 || cantidad > producto.Stock)
                return false;

            var itemExistente = _items.FirstOrDefault(i => i.Producto.Codigo == producto.Codigo);

            if (itemExistente != null)
            {
                if (!itemExistente.ActualizarCantidad(itemExistente.Cantidad + cantidad))
                    return false;
            }
            else
            {
                _items.Add(new ItemCarrito(producto, cantidad));
            }

            return true;
        }

        public bool RemoverItem(int codigoProducto)
        {
            var item = _items.FirstOrDefault(i => i.Producto.Codigo == codigoProducto);
            if (item == null)
                return false;

            return _items.Remove(item);
        }

        public decimal CalcularTotal()
        {
            return _items.Sum(item => item.CalcularSubtotal());
        }

        public bool RealizarCompra()
        {

            foreach (var item in _items)
            {
                if (item.Cantidad > item.Producto.Stock)
                    return false;
            }

            foreach (var item in _items)
            {
                item.Producto.ReducirStock(item.Cantidad);
            }

            _items.Clear();
            return true;
        }
    }
}
