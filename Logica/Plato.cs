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
        DateTime tiempoDePreparacion;
        int precio;
        List<Ingrediente> ingredientes; //Tendría que haber puesto a la lista dentro de los parámetros?

        public Plato(int precio, string nombre, DateTime tiempoDePreparacion):this(nombre,tiempoDePreparacion)
        {
            this.precio = precio;
        }

        public Plato(string nombre, DateTime tiempoDePreparacion)             
        {
            ingredientes = new List<Ingrediente>();
            this.nombre = nombre;
            this.tiempoDePreparacion = tiempoDePreparacion;
        }
                
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public DateTime TiempoDePreparacion { get { return tiempoDePreparacion; } set { tiempoDePreparacion = value; } }

        public int Precio { get { return precio; } set { precio = value; } }
        public List<Ingrediente> Ingredientes { get { return ingredientes; } set { ingredientes = value; } }

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            ingredientes.Add(ingrediente);
        }    
    }
}
