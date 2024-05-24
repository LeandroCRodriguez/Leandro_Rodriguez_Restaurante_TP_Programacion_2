using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum EPago
    {
        BilleteraVirtual,
        TarjetaDeCredito,
        Contado
    }
    public class Mesero : Empleado
    {
        Mesa mesa;
        bool yaPago;
        bool mesaCerrada;

        public Mesero(string nombre, string apellido, float contacto, string direccion, 
            float sueldo, ERol rol, bool mesaCerrada, bool yaPago, Mesa mesa) 
            : base(nombre, apellido, contacto, direccion, sueldo, rol)
        {
            this.mesa = mesa;
            this.yaPago = yaPago;
            this.mesaCerrada = mesaCerrada;
        }
    }
}
