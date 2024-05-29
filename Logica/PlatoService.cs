using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
    public class PlatoService
    {
        public Plato CrearPlato(Plato plato, Empleado empleado)
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

        public void GetPlatosNoDisponibles(Ingrediente ingrediente)
        {
            
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