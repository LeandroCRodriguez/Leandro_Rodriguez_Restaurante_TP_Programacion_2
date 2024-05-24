using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum ERol
    {
        Cocinero,
        Encargado,
        Mesero,
        Delivery
    }
    public class Empleado
    {
        string nombre;
        string apellido;
        float contacto;
        string direccion;
        float sueldo;
        ERol rol;

        public Empleado(string nombre, string apellido, float contacto, string direccion, 
            float sueldo, ERol rol)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.contacto = contacto;
            this.direccion = direccion;
            this.sueldo = sueldo;
            this.rol = rol;
        }
    }
}
