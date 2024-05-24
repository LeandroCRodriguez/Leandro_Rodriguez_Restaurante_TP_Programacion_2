using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Mesa
    {
        Plato plato;
        int numeroDeMesa;
        int capacidad;
        Mesero mesero;
        Producto stock;

        public Mesa(Plato plato, int numeroDeMesa, int capacidad, Mesero mesero, Producto stock)
        {
            this.plato = plato;
            this.numeroDeMesa = numeroDeMesa;
            this.capacidad = capacidad;
            this.mesero = mesero;
            this.stock = stock;
        }

    }
}
