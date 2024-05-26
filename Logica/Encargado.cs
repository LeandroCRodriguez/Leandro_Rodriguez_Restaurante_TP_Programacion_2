using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Encargado : Empleado
    {
        Producto stock;
        Proveedor proveedor;
        float dineroRecaudado;
        Plato precio;

        public Encargado(string nombre, string apellido, float contacto, string direccion, 
            float sueldo, float dineroRecaudado, 
            Plato precio) 
            :base(nombre, apellido, contacto, direccion, sueldo, ERol.Encargado)
        {
            this.dineroRecaudado = dineroRecaudado;
            this.precio = precio;
        }
        public void RealizarIngresoDeStock(Producto producto, int cantidad)
        {
            producto.IncrementarStock(cantidad);
        }

        public List<Producto> ConsultarStockVigente(List<Producto> stock)
        {            
            return stock;
        }
        public List<Producto> ConsultarStockPorAgotarse(List<Producto> stockPorAgotarse)
        {
            List<Producto> productosPorAgotarse = new List<Producto>();
            foreach (Producto item in stockPorAgotarse)
            {
                if(item.Stock < 50)
                {
                    productosPorAgotarse.Add(item);
                }
            }
            return productosPorAgotarse;
        }
    }
}
