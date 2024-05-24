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
            float sueldo, ERol rol, Producto stock, Proveedor proveedor, float dineroRecaudado, 
            Plato precio) 
            :base(nombre, apellido, contacto, direccion, sueldo, rol)
        {
            this.stock = stock;
            this.proveedor = proveedor;
            this.dineroRecaudado = dineroRecaudado;
            this.precio = precio;
        }

    }
}
