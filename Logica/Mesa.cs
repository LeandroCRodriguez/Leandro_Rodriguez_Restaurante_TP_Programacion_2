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
        List<int>numeroDeMesa;
        int capacidad;
        Mesero mesero;
        Producto stock;

        public Mesa(Plato plato, List<int> numeroDeMesa, int capacidad, Mesero mesero)
        {
            this.plato = plato;
            this.numeroDeMesa = numeroDeMesa;
            this.capacidad = capacidad;
            this.mesero = mesero;
        }



    }
}
