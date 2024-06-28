using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Stock
    {
        Proveedor proveedor;
        int cantidad;

        public Stock(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public Stock(Proveedor proveedor, int cantidad)
        {
            this.proveedor = proveedor;
            this.cantidad = cantidad;
        }
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
