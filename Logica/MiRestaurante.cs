using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MiRestaurante
    {
        public List<Proveedor> Proveedores { get;  set; }
        public List<Producto> StockProductos { get;  set; }
        public List<Plato> PlatosDisponibles { get;  set; }
        public List<Bebida> Bebidas { get;  set; }
        public List<Empleado> Empleados { get;  set; }
        public List<Mesa> Mesas { get;  set; }

        public double arcas { get; set; }


        private List<Plato> platosMesaUno;
        private List<Plato> platosMesaDos;
        private List<Plato> platosMesaTres;
        private List<Plato> platosMesaCuatro;
        private List<Plato> platosMesaCinco;


        public MiRestaurante(double arcas)
        {
            this.Proveedores = new List<Proveedor>();
            this.StockProductos = new List<Producto>();
            this.PlatosDisponibles = new List<Plato>();
            this.Bebidas = new List<Bebida>();
            this.Empleados = new List<Empleado>();
            this.Mesas = new List<Mesa>();
            this.arcas = arcas;

        }

        public void InicializarDatos()
        {
            //Inicializar Proveedores
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes);
            Proveedor polleriaMartita = new Proveedor("Pollería Martita", "897845", "Venado Tuerto 655", "Pollo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes);
            Proveedor verduleriaHabemusPapa = new Proveedor("Verdulería Habemus Papa", "789456", "La plumita 1243", "Papa", EMedioDePago.Contado, EDiasDeLaSemana.Miercoles);
            Proveedor almacenTutanJamon = new Proveedor("Almacén Tutan Jamón", "123456", "Ayacucho 322", "Carne", EMedioDePago.Efectivo, EDiasDeLaSemana.Jueves);
            Proveedores.Add(carniceriaElSeniorDeLosNovillos);
            Proveedores.Add(polleriaMartita);
            Proveedores.Add(verduleriaHabemusPapa);
            Proveedores.Add(almacenTutanJamon);

            //Inicializar Stock de Productos 
            StockProductos.Add(new Producto("Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000)));
            StockProductos.Add(new Producto("Carne picada", new Stock(carniceriaElSeniorDeLosNovillos, 6000)));
            StockProductos.Add(new Producto("Pollo", new Stock(polleriaMartita, 4500)));
            StockProductos.Add(new Producto("Huevos", new Stock(polleriaMartita, 4500)));
            StockProductos.Add(new Producto("Papa", new Stock(verduleriaHabemusPapa, 3000)));
            StockProductos.Add(new Producto("Tomates", new Stock(verduleriaHabemusPapa, 3000)));
            StockProductos.Add(new Producto("Harina", new Stock(almacenTutanJamon, 5000)));
            StockProductos.Add(new Producto("Aceite", new Stock(almacenTutanJamon, 5000)));



            //Inicializar Platos
            Plato milaConPure = new Plato(145, "Milanesa con pure", DateTime.Now.AddMinutes(30));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papa"), 200));

            Plato fideosConBolognesa = new Plato(110, "Fideos con bolognesa", DateTime.Now.AddMinutes(35));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 200));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Carne picada"), 200));

            Plato polloConEnsalada = new Plato(125, "Pollo con ensalada", DateTime.Now.AddMinutes(25));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("Tomate"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("lechuga"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("pollo"), 250));

            Plato lasagnaDeVerduras = new Plato(125, "Lasagna de verduras", DateTime.Now.AddMinutes(40));
            lasagnaDeVerduras.AgregarIngrediente(new Ingrediente(new Producto("Tomate"), 100));
            lasagnaDeVerduras.AgregarIngrediente(new Ingrediente(new Producto("harina"), 150));
            lasagnaDeVerduras.AgregarIngrediente(new Ingrediente(new Producto("espinaca"), 250));

            //Lista de Platos disponibles
            PlatosDisponibles.Add(milaConPure);
            PlatosDisponibles.Add(fideosConBolognesa);
            PlatosDisponibles.Add(polloConEnsalada);
            PlatosDisponibles.Add(lasagnaDeVerduras); 

            //Inicializar bebidas
            Bebidas.Add(new Bebida(350, "Coca", new Stock(150), false));
            Bebidas.Add(new Bebida(200, "Cerveza", new Stock(65), true));
            Bebidas.Add(new Bebida(200, "agua", new Stock(100), false));
            Bebidas.Add(new Bebida(200, "agua con gas", new Stock(50), false));
            Bebidas.Add(new Bebida(500, "vino", new Stock(50), true));

            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123", 123456, ERol.Cocinero);
            Empleado lele = new Empleado("Lele", "Peri", 1578451256, "asd 322", 321654, ERol.Encargado);
            Empleado veronica = new Empleado("Verónica", "Gomez", 1565498712, "asd 344", 654987, ERol.Mesero);
            Empleado augusto = new Empleado("Augusto", "Perez", 1556239875, "peru 566", 659878, ERol.Delivery);
            Empleado churita = new Empleado("Churita", "Corazón", 1587541265, "chile 655", 100000, ERol.Mesero);
            Empleados.Add(pepe);
            Empleados.Add(lele);
            Empleados.Add(veronica);
            Empleados.Add(augusto);
            Empleados.Add(churita);
        }

        public void AsignarMesas()
        {
            try
            {
                MesaService mesaService = new MesaService();
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa1, 4, ObtenerEmpleadoPorNombre("Churita"), platosMesaUno, Bebidas, StockProductos, PlatosDisponibles));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa2, 4, ObtenerEmpleadoPorNombre("Churita"), platosMesaDos, Bebidas, StockProductos, PlatosDisponibles));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa3, 4, ObtenerEmpleadoPorNombre("Verónica"), platosMesaTres, Bebidas, StockProductos, PlatosDisponibles));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa4, 4, ObtenerEmpleadoPorNombre("Verónica"), platosMesaCuatro, Bebidas, StockProductos, PlatosDisponibles));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa5, 4, ObtenerEmpleadoPorNombre("Verónica"), platosMesaCinco, Bebidas, StockProductos, PlatosDisponibles));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar la mesa: {ex.Message}");
            }            
        }

        public List<Plato> CrearPlatosPedidosPorConsola()
        {
            List<Plato> platosPedidos = new List<Plato>();

            while (true)
            {
                Console.WriteLine("Ingrese el nombre del plato (o 'fin' para terminar):");
                string nombrePlato = Console.ReadLine();
                if (nombrePlato == "fin")
                {
                    break;
                }
                Plato platoEncontrado = null;
                foreach (Plato plato in PlatosDisponibles)
                {
                    if (nombrePlato == plato.Nombre)
                    {
                        platoEncontrado = plato;
                        //Realizo egreso de stock
                        StockService stokService = new StockService();
                        stokService.RealizarEgresoStock(platoEncontrado, StockProductos);
                    }
                }
                try
                {
                    if (platoEncontrado != null)
                {
                    platosPedidos.Add(platoEncontrado);
                    Console.WriteLine($"Plato '{nombrePlato}' agregado.");
                }
                else
                {
                    Console.WriteLine($"Plato '{nombrePlato}' no encontrado en el menú.");
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar plato: {ex.Message}");
                }
            }

            return platosPedidos;
        }
        public void CrearPlatosPedidosParaMesas()
        {
            platosMesaUno = CrearPlatosPedidosPorConsola();
            platosMesaDos = CrearPlatosPedidosPorConsola();
            platosMesaTres = CrearPlatosPedidosPorConsola();
            platosMesaCuatro = CrearPlatosPedidosPorConsola();
            platosMesaCinco = CrearPlatosPedidosPorConsola();
        }
        
        public Empleado ObtenerEmpleadoPorNombre(string nombre)
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado.Nombre == nombre)
                {
                    return empleado;
                }
            }
            throw new Exception($"Empleado con nombre {nombre} no encontrado.");
        }

        //  Las funcionalidades que nos piden ofrecer son: 
        //● Consumo de delivery únicamente.
        //● Consultar el estado actual de una mesa en particular (consumo no pagado). ● Registrar el consumo por medio de pago(consultas individuales). 
        //● Consumo por mesero.
        //● Top 3 de ventas(incluye meseros y delivery). 
        //public double ConsumoTotal()
        //{
        //    double consumoTotal = 0;
        //    foreach (Plato plato in platosMesaUno)
        //    {
        //        consumoTotal += plato.Precio;
        //        arcas += plato.Precio;
        //    }
        //    foreach (Plato plato in platosMesaDos)
        //    {
        //        consumoTotal += plato.Precio;
        //        arcas += plato.Precio;
        //    }
        //    foreach (Plato plato in platosMesaTres)
        //    {
        //        consumoTotal += plato.Precio;
        //        arcas += plato.Precio;
        //    }
        //    foreach (Plato plato in platosMesaCuatro)
        //    {
        //        consumoTotal += plato.Precio;
        //        arcas += plato.Precio;
        //    }
        //    foreach (Plato plato in platosMesaCinco)
        //    {
        //        consumoTotal += plato.Precio;
        //        arcas += plato.Precio;
        //    }
        //    return consumoTotal;
        //}


        //Creo que está bien este metodo, sino hay uno re largo arriba que no contempla aún el consumo del delivery
        public double ConsumoTotal(bool soloDelivery = false)
        {
            double consumoTotal = 0;
            double consumoTotalDelivery = 0;

            foreach (Mesa mesa in Mesas)
            {
                foreach (Plato plato in mesa.Platos)
                {
                    if(soloDelivery == true || mesa.Mesero.Rol == ERol.Delivery)
                    {
                        consumoTotalDelivery += plato.Precio;
                    }
                    else
                    {
                        consumoTotal += plato.Precio;
                    }
                }
            }
            arcas += consumoTotal + consumoTotalDelivery;
            return consumoTotal + consumoTotalDelivery;
        }                
    }
}
