using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Bebida : Producto
    {
        bool conAlcohol;

        public Bebida(double precio, string nombre, Stock stock, bool conAlcohol) 
            : base(precio, nombre, stock)
        {
            this.conAlcohol = conAlcohol;
        }

        public bool ConAlcohol { get { return conAlcohol; } set { conAlcohol = value; } }
    }
}
