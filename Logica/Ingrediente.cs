using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Ingrediente
    {
        Producto producto;
        private int cantidad;
                

        public Ingrediente(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        public Producto Producto { get { return producto; } set { producto = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

    }
}
