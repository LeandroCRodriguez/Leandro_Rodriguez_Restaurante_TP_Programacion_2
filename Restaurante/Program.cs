using Logica;

namespace Restaurante
{
    public class Program
    {
        static void Main(string[] args)
        {
            MiRestaurante restaurante = new MiRestaurante(50000);
            restaurante.InicializarDatos();

            // MOSTRAR MENÚ DISPONIBLE
            Menu menuDisponible = new Menu(restaurante.PlatosDisponibles, restaurante.Bebidas);
            menuDisponible.MostrarMenu();

            //INGRESAR PRODUCTOS Y PAGARLE AL PROVEEDOR. YA LO PROBÉ CON FONDOS INSUFICIENTES
            Proveedor pescaderiaLosPollosHermanos = new Proveedor("Pescaderia los Pollos Hermanos", "555222", "La pampa 244", "Merluza", EMedioDePago.Efectivo, EDiasDeLaSemana.Jueves);
            Producto merluza = new Producto(200, "Merluza", new Stock(pescaderiaLosPollosHermanos, 5000));
            restaurante.StockProductos.Add(merluza);
            restaurante.PagarProveedor(merluza);

            //MOSTRAR PRODUCTOS EN STOCK
            StockService stockService = new StockService();
            List<Producto> stockVigente = stockService.ConsultarStockVigente(restaurante.StockProductos);
            Console.WriteLine("\nPRODUCTOS EN STOCK");
            foreach (Producto stock in stockVigente)
            {
                Console.WriteLine(stock.MostrarProducto());
            }


            //Dentro de este método, ya hago el EGRESO DE STOCK cuando creo un plato
            restaurante.AgregarPlatoPedidoParaMesa("Milanesa con pure",ENumeroDeMesa.Mesa1); 
            restaurante.AgregarPlatoPedidoParaMesa("Fideos con bolognesa", ENumeroDeMesa.Mesa1);
            restaurante.AgregarPlatoPedidoParaMesa("Milanesa con pure", ENumeroDeMesa.Mesa2);
            restaurante.AgregarPlatoPedidoParaMesa("Fideos con bolognesa", ENumeroDeMesa.Mesa2);
            restaurante.AgregarPlatoPedidoParaMesa("Milanesa con pure", ENumeroDeMesa.Mesa3);
            restaurante.AgregarPlatoPedidoParaMesa("Fideos con bolognesa", ENumeroDeMesa.Mesa3);
            restaurante.AgregarPlatoPedidoParaMesa("Milanesa con pure", ENumeroDeMesa.Mesa4);
            restaurante.AgregarPlatoPedidoParaMesa("Fideos con bolognesa", ENumeroDeMesa.Mesa4);
            restaurante.AgregarPlatoPedidoParaMesa("Milanesa con pure", ENumeroDeMesa.Mesa5);
            restaurante.AgregarPlatoPedidoParaMesa("Fideos con bolognesa", ENumeroDeMesa.Mesa5);

            // ASIGNAR MESAS
            //Dentro de este método llamo a  AsignarPlatoAMesa() y ahi
            //corroboro que haya stock.
            restaurante.AsignarMesas();

            //MOSTRAR PRODUCTOS EN STOCK NUEVAMENTE
            Console.WriteLine("\nPRODUCTOS EN STOCK DESCONTANDO CANTIDADES");
            foreach (Producto stock in stockVigente)
            {
                Console.WriteLine(stock.MostrarProducto());
            }
            //MOSTRAR PRODUCTOS POR AGOTARSE
            List<Producto> stockPorAgotarse = stockService.ConsultarStockPorAgotarse(restaurante.StockProductos);
            Console.WriteLine("PRODUCTOS POR AGOTARSE");
            foreach (Producto stock in stockPorAgotarse)
            {
                Console.WriteLine(stock.MostrarProducto());
            }

            //MOSTRAR PLATOS POR PRODUCTO
            PlatoService platoService = new PlatoService();
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes);
            Producto bolaDeLomo = new Producto(200, "Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000));
            Ingrediente ingredienteLomo = new Ingrediente(bolaDeLomo, 50);
            List<Plato> platosPorIngrediente = platoService.GetPlatosPorIngrediente(ingredienteLomo, restaurante.PlatosDisponibles);
            Console.WriteLine("Platos por ingrediente");
            foreach (Plato plato in platosPorIngrediente)
            {
                Console.WriteLine(plato.MostrarPlato());
            }

            //MOSTRAR PLATOS DISPONIBLES
            List<Plato> platosDisponibles = restaurante.PlatosDisponibles;
            Console.WriteLine("Platos disponibles");
            foreach (Plato plato in platosDisponibles)
            {
                Console.WriteLine(plato.MostrarPlato());
            }

            //CREAR PLATO
            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123", 123456, ERol.Cocinero);
            Empleado lele = new Empleado("Lele", "Peri", 1578451256, "asd 322", 321654, ERol.Encargado);
            Plato pizza = platoService.CrearPlato(pepe, "Pizza", 15);
            pizza.AgregarIngrediente(new Ingrediente(new Producto("Queso"), 200));
            pizza.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 200));
            platoService.EstablecerPrecioDePlato(pizza, lele, 80);
            restaurante.PlatosDisponibles.Add(pizza);
            menuDisponible.MostrarMenu(); //TENGO QUE RENOVAR EL MOSTRARMENU PARA QUE SE VEA EL PLATO

            //EDITAR PLATO
            Plato pizzaEditada = platoService.EditarPlato(pepe, "Pizza", 15, restaurante.PlatosDisponibles);
            pizza.AgregarIngrediente(new Ingrediente(new Producto("Queso"), 250));
            pizza.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 250));
            platoService.EstablecerPrecioDePlato(pizzaEditada, lele, 90);
            restaurante.PlatosDisponibles.Add(pizzaEditada);
            Console.WriteLine($"fue modificado");
            menuDisponible.MostrarMenu();

            //ELIMINAR PLATO
            platoService.EliminarPlato(pizzaEditada, pepe, platosDisponibles);
            Console.WriteLine($"fue eliminado");
            menuDisponible.MostrarMenu();


            //CONSUMO TOTAL Y DELIVERY
            restaurante.CalcularConsumoTotal();
            restaurante.CalcularConsumoDelivery();

            //PAGAR SUELDOS A EMPLEADOS POR ORDEN
            restaurante.PagarSueldosAEmpleados(lele);

            //FUNCIONALIDADES
            //Ingresar Productos ✓
            //Descontar productos cuando se sirven en la mesa  ✓
            //Consulta stock vigente ✓
            //Consulta stock por agotarse ✓
            //COMIDA
            //ABM Platos ✓ Faltaría ver el metodo EliminarPlato() ✓
            //Consulta platos por producto ✓
            //Consulta platos disponibles ✓
            //CONTABILIDAD
            //Pago a proveedores ✓
            //Pago por orden de prioridad ✓
            //Consumo total ✓
            //consumo Delivery y mesero ✓
            //consumo no pago 
            //consumo por medio de pago
            //Top 3 ventas
        }
    }
}