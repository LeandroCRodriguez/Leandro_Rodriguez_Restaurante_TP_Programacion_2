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
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Contacto = contacto;
            this.Direccion = direccion;
            this.Sueldo = sueldo;
            this.Rol = rol;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public float Contacto { get => contacto; set => contacto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public float Sueldo { get => sueldo; set => sueldo = value; }
        public ERol Rol { get => rol; set => rol = value; }
    }
}
