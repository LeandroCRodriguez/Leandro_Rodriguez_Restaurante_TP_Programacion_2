using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Ingrediente
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public Ingrediente(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
    }
}
