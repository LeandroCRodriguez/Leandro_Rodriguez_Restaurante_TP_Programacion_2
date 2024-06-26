﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum EMedioDePagoCliente
    {
        BilleteraVirtual,
        Contado,
        TarjetaCredito,
    }
    public class MiRestaurante
    {
        public List<Proveedor> Proveedores { get;  set; }
        public List<Producto> StockProductos { get;  set; }
        public List<Plato> PlatosDisponibles { get;  set; }
        public List<Bebida> Bebidas { get;  set; }
        public List<Empleado> Empleados { get;  set; }
        public List<Mesa> Mesas { get;  set; }

        public double arcas { get; set; }

        private Dictionary<ENumeroDeMesa, List<Plato>> platosPorMesa;
        private Dictionary<ENumeroDeMesa, List<Bebida>> bebidasPorMesa;

        

        public MiRestaurante(double arcas)
        {
            this.Proveedores = new List<Proveedor>();
            this.StockProductos = new List<Producto>();
            this.PlatosDisponibles = new List<Plato>();
            this.Bebidas = new List<Bebida>();
            this.Empleados = new List<Empleado>();
            this.Mesas = new List<Mesa>();
            this.arcas = arcas;

            platosPorMesa = new Dictionary<ENumeroDeMesa, List<Plato>>
            {
                { ENumeroDeMesa.Mesa1, new List<Plato>() },
                { ENumeroDeMesa.Mesa2, new List<Plato>() },
                { ENumeroDeMesa.Mesa3, new List<Plato>() },
                { ENumeroDeMesa.Mesa4, new List<Plato>() },
                { ENumeroDeMesa.Mesa5, new List<Plato>() }
            };
            bebidasPorMesa = new Dictionary<ENumeroDeMesa, List<Bebida>>
            {
                { ENumeroDeMesa.Mesa1, new List<Bebida>() },
                { ENumeroDeMesa.Mesa2, new List<Bebida>() },
                { ENumeroDeMesa.Mesa3, new List<Bebida>() },
                { ENumeroDeMesa.Mesa4, new List<Bebida>() },
                { ENumeroDeMesa.Mesa5, new List<Bebida>() }
            };
        }

        public void InicializarDatos()
        {
            //Inicializar Proveedores
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePagoProveedor.Transferencia, EDiasDeLaSemana.Martes);
            Proveedor polleriaMartita = new Proveedor("Pollería Martita", "897845", "Venado Tuerto 655", "Pollo", EMedioDePagoProveedor.Efectivo, EDiasDeLaSemana.Viernes);
            Proveedor verduleriaHabemusPapa = new Proveedor("Verdulería Habemus Papa", "789456", "La plumita 1243", "Papa", EMedioDePagoProveedor.Contado, EDiasDeLaSemana.Miercoles);
            Proveedor almacenTutanJamon = new Proveedor("Almacén Tutan Jamón", "123456", "Ayacucho 322", "Carne", EMedioDePagoProveedor.Efectivo, EDiasDeLaSemana.Jueves);
            Proveedores.Add(carniceriaElSeniorDeLosNovillos);
            Proveedores.Add(polleriaMartita);
            Proveedores.Add(verduleriaHabemusPapa);
            Proveedores.Add(almacenTutanJamon);

            //Inicializar Stock de Productos 
            StockProductos.Add(new Producto(200, "Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000)));
            StockProductos.Add(new Producto(150,"Carne picada", new Stock(carniceriaElSeniorDeLosNovillos, 6000)));
            StockProductos.Add(new Producto(180,"Pollo", new Stock(polleriaMartita, 4500)));
            StockProductos.Add(new Producto(180,"Huevos", new Stock(polleriaMartita, 4500)));
            StockProductos.Add(new Producto(25, "Papa", new Stock(verduleriaHabemusPapa, 3000)));
            StockProductos.Add(new Producto(100, "Tomates", new Stock(verduleriaHabemusPapa, 3000)));
            StockProductos.Add(new Producto(25, "Harina", new Stock(almacenTutanJamon, 5000)));
            StockProductos.Add(new Producto(50, "Aceite", new Stock(almacenTutanJamon, 40)));
            StockProductos.Add(new Producto(80, "Queso", new Stock(almacenTutanJamon, 2000)));


            //Inicializar Platos
            Plato milaConPure = new Plato(145, "Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papa"), 200));

            Plato fideosConBolognesa = new Plato(110, "Fideos con bolognesa", 35);
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 200));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Carne picada"), 200));

            Plato polloConEnsalada = new Plato(125, "Pollo con ensalada", 25);
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("Tomate"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("lechuga"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("pollo"), 250));

            Plato lasagnaDeVerduras = new Plato(125, "Lasagna de verduras", 40);
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
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa1, 4, ObtenerEmpleadoPorNombre("Churita"), platosPorMesa[ENumeroDeMesa.Mesa1], Bebidas, StockProductos));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa2, 4, ObtenerEmpleadoPorNombre("Churita"), platosPorMesa[ENumeroDeMesa.Mesa2], Bebidas, StockProductos));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa3, 4, ObtenerEmpleadoPorNombre("Verónica"), platosPorMesa[ENumeroDeMesa.Mesa3], Bebidas, StockProductos));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa4, 4, ObtenerEmpleadoPorNombre("Verónica"), platosPorMesa[ENumeroDeMesa.Mesa4], Bebidas, StockProductos));
                Mesas.Add(mesaService.AsignarPlatoAMesa(ENumeroDeMesa.Mesa5, 4, ObtenerEmpleadoPorNombre("Augusto"), platosPorMesa[ENumeroDeMesa.Mesa5], Bebidas, StockProductos));   
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar la mesa: {ex.Message}");
            }
        }
       
        public void AgregarPlatoPedidoParaMesa(string nombrePlato, ENumeroDeMesa mesa)
        {
            Plato platoEncontrado = null;
            foreach (Plato plato in PlatosDisponibles)
            {
                if (nombrePlato == plato.Nombre)
                {
                    platoEncontrado = plato;
                }
            }
            try
            {
                if (platoEncontrado != null)
                {
                    bool mesaEncontrada = false;
                    foreach (var key in platosPorMesa.Keys)
                    {
                        if (key == mesa)
                        {
                            mesaEncontrada = true;
                            break;
                        }
                    }

                    if (!mesaEncontrada)
                    {
                        platosPorMesa[mesa] = new List<Plato>();
                    }

                    platosPorMesa[mesa].Add(platoEncontrado);
                    Console.WriteLine($"Plato '{platoEncontrado.Nombre}' agregado a mesa {(int)mesa}.");
                }
                else
                {
                    Console.WriteLine($"Plato '{nombrePlato}' no encontrado en el menú o mesa no válida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar plato: {ex.Message}");
            }
        }

        public void AgregarBebidaPedidoParaMesa(string nombreBebida, ENumeroDeMesa mesa)
        {
            Bebida bebidaEncontrada = null;
            foreach (Bebida bebida in Bebidas)
            {
                if (nombreBebida == bebida.Nombre)
                {
                    bebidaEncontrada = bebida;
                }
            }
            try
            {
                if (bebidaEncontrada != null)
                {
                    if (!bebidasPorMesa.ContainsKey(mesa))
                    {
                        bebidasPorMesa[mesa] = new List<Bebida>();
                    }
                    bebidasPorMesa[mesa].Add(bebidaEncontrada);
                    Console.WriteLine($"Platos '{bebidaEncontrada.Nombre}' agregados a mesa {(int)mesa}.");
                }
                else
                {
                    Console.WriteLine($"Plato '{nombreBebida}' no encontrado en el menú o mesa no válida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la bebida: {ex.Message}");
            }
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

        //public void CalcularConsumoTotal()
        //{
        //    double consumoTotal = 0;

        //    foreach (Mesa mesa in Mesas)
        //    {
        //        if (mesa.Platos != null)
        //        {
        //            foreach (Plato plato in mesa.Platos)
        //            {
        //                consumoTotal += plato.Precio;
        //                mesa.EstadoMesa = true;
        //            }
        //            foreach (Bebida bebida in mesa.Bebidas)
        //            {
        //                consumoTotal += bebida.Precio;
        //                mesa.EstadoMesa = true;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine($"La mesa {(int)mesa.EnumeroDeMesa} no tiene platos asignados.");
        //        }
        //    }            
        //    arcas += consumoTotal;
        //    Console.WriteLine($"Total recaudado hoy: {consumoTotal}");
        //    Console.WriteLine($"Arcas actuales: {arcas}");
        //}

        public void CalcularConsumoTotal()
        {
            double consumoTotal = 0;

            foreach (Mesa mesa in Mesas)
            {
                double consumoMesa = 0;
                if (mesa.Platos != null)
                {
                    foreach (Plato plato in mesa.Platos)
                    {
                        consumoMesa += plato.Precio;
                        mesa.EstadoMesa = true;
                    }
                    foreach (Bebida bebida in mesa.Bebidas)
                    {
                        consumoMesa += bebida.Precio;
                        mesa.EstadoMesa = true;
                    }
                }
                else
                {
                    Console.WriteLine($"La mesa {(int)mesa.EnumeroDeMesa} no tiene platos asignados.");
                }
                mesa.TotalVentas = consumoMesa;
                consumoTotal += consumoMesa;
            }
            arcas += consumoTotal;
            Console.WriteLine($"Total recaudado hoy: {consumoTotal}");
            Console.WriteLine($"Arcas actuales: {arcas}");
        }

        public void MostrarTop3Ventas()
        {
            var top3Ventas = new List<(string Nombre, double TotalVentas, bool EsDelivery)>();

            // Rellenar la lista con los datos de las ventas
            foreach (var mesa in Mesas)
            {
                top3Ventas.Add((mesa.Mesero.Nombre, mesa.TotalVentas, mesa.Mesero.Rol == ERol.Delivery));
            }

            for (int i = 0; i < top3Ventas.Count - 1; i++)
            {
                for (int j = i + 1; j < top3Ventas.Count; j++)
                {
                    if (top3Ventas[i].TotalVentas < top3Ventas[j].TotalVentas)
                    {
                        var temp = top3Ventas[i];
                        top3Ventas[i] = top3Ventas[j];
                        top3Ventas[j] = temp;
                    }
                }
            }

            var top3 = new List<(string Nombre, double TotalVentas, bool EsDelivery)>();

            int count = 0;
            foreach (var item in top3Ventas)
            {
                if (count < 3)
                {
                    top3.Add(item);
                    count++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Top 3 de ventas (incluye meseros y delivery):");

            int posicion = 1;
            foreach (var item in top3)
            {
                string tipo;
                if (item.EsDelivery)
                {
                    tipo = "Delivery";
                }
                else
                {
                    tipo = "Mesero";
                }
                Console.WriteLine($"{posicion}. {item.Nombre} ({tipo}): {item.TotalVentas}");
                posicion++;
            }
        }

        public void CalcularConsumoDelivery()
        {
            double consumoTotalDelivery = 0;
            foreach (Mesa mesa in Mesas)
            {
                if (mesa.Mesero.Rol == ERol.Delivery)
                {
                    if (mesa.Platos != null)
                    {
                        foreach (Plato plato in mesa.Platos)
                        {
                            consumoTotalDelivery += plato.Precio;
                        }
                        foreach (Bebida bebida in mesa.Bebidas)
                        {
                            consumoTotalDelivery += bebida.Precio;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"La mesa {mesa.EnumeroDeMesa} no tiene platos asignados.");
                    }
                }
            }
            Console.WriteLine($"Total recaudado por delivery hoy: {consumoTotalDelivery}");
        }

        public void PagarProveedor(Producto producto)
        {
            if(arcas >= producto.Precio)
            {
                this.arcas -= producto.Precio;
                Console.WriteLine($"Pago realizado al proveedor {producto.Stock.Proveedor.Nombre} por {producto.Precio}. Arcas restantes: {arcas}.");
            }
            else
            {
                double cuentaCorriente = producto.Precio - arcas;
                arcas = 0;
                Proveedor proveedorCuentaCorriente = producto.Stock.Proveedor;
                proveedorCuentaCorriente.CuentaCorriente += cuentaCorriente;
                Console.WriteLine($"Fondos insuficientes. Se ha agregado {cuentaCorriente} a la cuenta corriente del proveedor {proveedorCuentaCorriente.Nombre}.");
            }
        }             
        public void PagarSueldosAEmpleados(Empleado empleado)
        {
            int sueldoEncargado = 2000;
            int sueldoCocinero = 1500;
            int sueldoMesero = 1000;
            int sueldoDelivery = 800;

            List<Empleado> encargados = new List<Empleado>();
            List<Empleado> cocineros = new List<Empleado>();
            List<Empleado> meseros = new List<Empleado>();
            List<Empleado> deliverys = new List<Empleado>();

            if (empleado.Rol == ERol.Encargado)
            {
                foreach (Empleado unEmpleado in Empleados)
                {
                    switch (unEmpleado.Rol)
                    {
                        case ERol.Encargado:
                            encargados.Add(unEmpleado);
                            break;
                        case ERol.Cocinero:
                            cocineros.Add(unEmpleado);
                            break;
                        case ERol.Mesero:
                            meseros.Add(unEmpleado);
                            break;
                        case ERol.Delivery:
                            deliverys.Add(unEmpleado);
                            break;
                    }
                }
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
            PagarSueldos(encargados, sueldoEncargado);
            PagarSueldos(cocineros, sueldoCocinero);
            PagarSueldos(meseros, sueldoMesero);
            PagarSueldos(deliverys, sueldoDelivery);
        }
        public void PagarSueldos(List<Empleado> empleados, int sueldo)
        {
            foreach (Empleado unEmpleado in empleados)
            {
                if (this.arcas >= sueldo)
                {
                    unEmpleado.Sueldo += sueldo;
                    this.arcas -= sueldo;
                    Console.WriteLine($"Sueldo de {sueldo} pagado a {unEmpleado.Nombre} ({unEmpleado.Rol}). Arcas restantes: {this.arcas}");
                }
                else
                {
                    Console.WriteLine($"No hay suficiente dinero para pagar a {unEmpleado.Nombre} ({unEmpleado.Rol}). Arcas restantes: {this.arcas}");
                }
            }
        }
    }
}
