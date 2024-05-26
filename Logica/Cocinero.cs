using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Cocinero : Empleado
    {
        Plato plato;
        Producto stock;
        private List<Plato> platosDisponibles;

        public Cocinero(string nombre, string apellido, float contacto, string direccion, 
            float sueldo,  Plato plato, Producto stock) 
            : base(nombre, apellido, contacto, direccion, sueldo, ERol.Cocinero)
        {
            this.plato = plato;
            this.stock = stock;
            platosDisponibles = new List<Plato>();
        }

        public void CrearPlato(string nombre, List<Ingrediente> ingredientes, double tiempoDePreparacion)
        {
            Plato nuevoPlato = new Plato(nombre, tiempoDePreparacion, ingredientes);
            platosDisponibles.Add(nuevoPlato);
            
        }
        public void ModificarPlato(Plato platoExistente, string nuevoNombre, double nuevoTiempoDePreparacion, List<Ingrediente> nuevosingredientes)
        {
            platoExistente.Nombre = nuevoNombre;
            platoExistente.TiempoDePreparacion = nuevoTiempoDePreparacion;
            platoExistente.Ingredientes = nuevosingredientes;
        }
        public void EliminarPlato(Plato plato)
        {
            platosDisponibles.Remove(plato);
        }
    }
}
