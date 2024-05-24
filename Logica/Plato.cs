using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Plato
    {
        string nombre;
        double tiempoDePreparacion;
        Producto producto;
        int cantidadIngredientes;
        int precio;

        public Plato(string nombre, double tiempoDePreparacion, Producto producto, 
            int cantidadIngredientes, int precio)
        {
            this.nombre = nombre;
            this.tiempoDePreparacion = tiempoDePreparacion;
            this.producto = producto;
            this.cantidadIngredientes = cantidadIngredientes;
            this.precio = precio;
        }



        public Producto HacerMilaConPure()
        {
            return producto;//Falta logica
        }
        public Producto HacerFideosConBolognesa()
        {
            return producto;//Falta logica
        }
    }
}
