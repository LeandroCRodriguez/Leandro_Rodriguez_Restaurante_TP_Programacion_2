﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Delivery : Empleado
    {
        bool mesaCerrada;
        bool yaPago;
        Mesa mesa;

        public Delivery(string nombre, string apellido, float contacto, string direccion, 
            float sueldo, ERol rol, bool mesaCerrada, bool yaPago, Mesa mesa) 
            : base(nombre, apellido, contacto, direccion, sueldo, rol)
        {
            this.mesaCerrada = mesaCerrada;
            this.yaPago = yaPago;
            this.mesa = mesa;
        }
    }
}
