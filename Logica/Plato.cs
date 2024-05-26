using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
    public class Plato
    {
        string nombre;
        double tiempoDePreparacion;
        Producto producto;
        List<Ingrediente> ingredientes;
        int precio;


        public Plato(string nombre, double tiempoDePreparacion,
            List<Ingrediente> ingredientes) 
        {
            this.nombre = nombre;
            this.tiempoDePreparacion = tiempoDePreparacion;
            this.ingredientes = ingredientes;
        }
        public Plato(int precio, string nombre, double tiempoDePreparacion,
            List<Ingrediente> ingredientes) 
            :this(nombre, tiempoDePreparacion, ingredientes) //constructor para el encargado
        {
            this.precio = precio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double TiempoDePreparacion { get => tiempoDePreparacion; set => tiempoDePreparacion = value; }
        //public Producto Producto { get => producto; set => producto = value; }

        public int Precio { get => precio; set => precio = value; }
        public List<Ingrediente> Ingredientes { get => ingredientes; set => ingredientes = value; }


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
