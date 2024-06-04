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
        List<Ingrediente> ingredientes; //Tendría que haber puesto a la lista dentro de los parámetros?
                                        // ¿cual es la diferencia?   
        
        public Plato(int precio, string nombre, double tiempoDePreparacion)             
        {
            this.precio = precio;
            ingredientes = new List<Ingrediente>();
            this.nombre = nombre;
            this.tiempoDePreparacion = tiempoDePreparacion;
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
    }
}
