using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
    public class PlatoService
    {
        public Plato CrearPlato(Empleado empleado,string nombrePlato, int tiempoDePreparacion) 
        {
            if(empleado.Rol == ERol.Cocinero)
            {
                
                return new Plato(nombrePlato, tiempoDePreparacion);                
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
        }
        public Plato EditarPlato(Empleado empleado, string nombrePlato, int tiempoDePreparacion, List<Plato> platos)
        {
            if (empleado.Rol == ERol.Cocinero)
            {
                Plato platoEncontrado = null;
                foreach (Plato plato in platos)
                {
                    if(plato.Nombre == nombrePlato)
                    {
                        platoEncontrado = plato;
                    }
                    
                }
                if (platoEncontrado != null)
                {
                    EliminarPlato(platoEncontrado, empleado, platos);
                    return new Plato(nombrePlato, tiempoDePreparacion);
                }
                else
                {
                    throw new Exception("Plato no encontrado");
                }
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
        }
        public bool EliminarPlato(Plato plato, Empleado empleado, List<Plato>platos)
        {
            if (empleado.Rol == ERol.Cocinero)
            {
                Console.WriteLine($"El plato {plato.Nombre}");
                return platos.Remove(plato);
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
        }

        public List<Plato> GetPlatosPorIngrediente(Ingrediente ingrediente, List<Plato> platosDisponibles)
        {
            List<Plato> platosDisponiblesPorIngrediente = new List<Plato>();
            foreach (Plato plato in platosDisponibles)
            {
                List<Ingrediente> ingredientes = plato.Ingredientes;
                foreach (Ingrediente unIngrediente in ingredientes)
                {
                    string nombreIngrediente = unIngrediente.Producto.Nombre;
                    if (nombreIngrediente == ingrediente.Producto.Nombre)
                    {
                        platosDisponiblesPorIngrediente.Add(plato);
                    }
                }                
            }
            return platosDisponiblesPorIngrediente;
        }

        public List<Plato> GetPlatosNoDisponibles(Ingrediente ingrediente, List<Plato> platosSiDisponibles)
        {
            List<Plato> platosNoDisponibles = new List<Plato>();
            foreach (Plato plato in platosSiDisponibles)
            {
                foreach (Ingrediente unIngrediente in plato.Ingredientes)
                {
                    int cantidadEnElStock = unIngrediente.Producto.Stock.Cantidad;
                    int cantidadIngrediente = ingrediente.Cantidad;
                    if(unIngrediente.Producto.Nombre == ingrediente.Producto.Nombre && cantidadEnElStock < cantidadIngrediente)
                    {
                        platosNoDisponibles.Add(plato);
                    }
                }
            }
            return platosNoDisponibles;
        }
        public Plato EstablecerPrecioDePlato(Plato plato, Empleado empleado, int nuevoPrecio)
        {
            if(empleado.Rol == ERol.Encargado)
            {
                plato.Precio = nuevoPrecio;
                return plato;
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
        }        
    }
}