using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
    public class PlatoService
    {  
        public Plato CrearPlato(Plato plato, Empleado empleado) //Reveer los métodos, porque son verificaciones.
        {
            if(empleado.Rol == ERol.Cocinero)
            {                
                return plato;
            }
            else
            {
                throw new Exception();//Ver qué tipo de excepción
            }
        }
        public Plato EditarPlato(Plato plato, Empleado empleado)
        {
            if (empleado.Rol == ERol.Cocinero)
            {                
                return plato;
            }
            else
            {
                throw new Exception();//Ver qué tipo de excepción
            }
        }
        public Plato EliminarPlato(Plato plato, Empleado empleado)
        {
            if (empleado.Rol == ERol.Cocinero)
            {
                return plato;
            }
            else
            {
                throw new Exception();//Ver qué tipo de excepción
            }
        }

        public void GetPlatosPorIngrediente(Ingrediente ingrediente)
        {

        }

        public void GetPlatosNoDisponibles(Ingrediente ingrediente, List<Plato> platosSiDisponibles)
        {
            List<Plato> platosNoDisponibles = new List<Plato>();
            foreach (Plato plato in platosSiDisponibles)
            {
                List<Ingrediente> ingredientes = plato.Ingredientes;
                foreach (Ingrediente unIngrediente in ingredientes)
                {
                    int cantidadEnElStock = unIngrediente.Producto.Stock.Cantidad;
                    int cantidadEnElIngrediente = unIngrediente.Cantidad;
                    if(cantidadEnElStock < cantidadEnElIngrediente)
                    {
                        platosNoDisponibles.Add(plato);
                    }
                }
            }
        }

        public Plato EstablecerPrecioDePlato(Plato plato, Empleado empleado)
        {
            if(empleado.Rol == ERol.Encargado)
            {
                return plato;
            }
            else
            {
                throw new Exception();//Ver qué tipo de excepción
            }

        }
    }
}