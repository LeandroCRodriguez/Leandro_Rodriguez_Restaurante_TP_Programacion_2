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
        public Bebida(string nombre, double precio,bool conAlcohol, Dictionary<string, int> stock) 
            : base(nombre, precio, stock)
        {
            this.conAlcohol = conAlcohol;
        }
    }
}
