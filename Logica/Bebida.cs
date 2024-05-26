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
        public Bebida(double precio, string nombre,bool conAlcohol, int stock) 
            : base(precio, nombre, stock)
        {
            this.conAlcohol = conAlcohol;
        }
    }
}
