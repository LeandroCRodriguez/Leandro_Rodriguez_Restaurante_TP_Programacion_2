using Logica;

namespace Restaurante
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime tiempoActual = DateTime.Now;
            MiRestaurante restaurante = new MiRestaurante(50000);
            restaurante.InicializarDatos();

            // Mostrar el menú disponible
            Menu menuDisponible = new Menu(restaurante.PlatosDisponibles, restaurante.Bebidas);
            menuDisponible.MostrarMenu();
            // Crear platos pedidos por consola y asignar a las mesas
            restaurante.CrearPlatosPedidosParaMesas(); //Dentro de este método, ya hago el egreso
                                                       //de stock cuando creo un plato

            // Asignar mesas con los platos ya creados
            restaurante.AsignarMesas(); //Dentro de este método llamo a  AsignarPlatoAMesa() y ahi
                                        //corroboro que haya stock.
                                         
        }
    }
}