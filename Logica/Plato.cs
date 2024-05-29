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
        int precio;
        List<Ingrediente> ingredientes;
        


        public Plato(string nombre, double tiempoDePreparacion) 
        {
            this.nombre = nombre;
            this.tiempoDePreparacion = tiempoDePreparacion;
            ingredientes = new List<Ingrediente>();
        }
        public Plato(int precio, string nombre, double tiempoDePreparacion) 
            :this(nombre, tiempoDePreparacion) //constructor para el encargado
        {
            this.precio = precio;
        }
                
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public double TiempoDePreparacion { get { return tiempoDePreparacion; } set { tiempoDePreparacion = value; } }
        //public Producto Producto { get => producto; set => producto = value; }

        public int Precio { get { return precio; } set { precio = value; } }
        public List<Ingrediente> Ingredientes { get { return ingredientes; } set { ingredientes = value; } }

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            ingredientes.Add(ingrediente);
        }

        public Producto HacerMilaConPure(Producto producto)
        {
            return producto;//Falta logica
        }
        public Producto HacerFideosConBolognesa(Producto producto)
        {
            return producto;//Falta logica
        }
    }
}
