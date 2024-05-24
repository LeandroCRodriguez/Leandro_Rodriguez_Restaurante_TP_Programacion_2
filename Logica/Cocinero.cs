using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Cocinero : Empleado
    {
        Plato plato;
        Producto stock;

        public Cocinero(string nombre, string apellido, float contacto, string direccion, 
            float sueldo, ERol rol, Plato Plato, Producto stock) 
            : base(nombre, apellido, contacto, direccion, sueldo, rol)
        {
            this.plato = plato;
            this.stock = stock;
        }

        public Plato CrearPlato()
        {
            return this.plato;//Falta logica
        }
        public Plato ModificarPlato ()
        {
            return this.plato;//Falta logica
        }
        public Plato EliminarPlato()
        {
            return this.plato;//Falta logica
        }
    }
}
