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
            float sueldo,  bool mesaCerrada, bool yaPago, Mesa mesa) 
            : base(nombre, apellido, contacto, direccion, sueldo, ERol.Mesero)
        {
            this.mesa = mesa;
            this.yaPago = yaPago;
            this.mesaCerrada = mesaCerrada;
        }
    }
}
