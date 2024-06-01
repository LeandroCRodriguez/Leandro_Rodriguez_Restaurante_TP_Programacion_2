using Logica;

namespace Restaurante
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Lista de proveedores
            List<Proveedor> proveedores = new List<Proveedor>();
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes);
            Proveedor polleriaMartita = new Proveedor("Pollería Martita", "897845", "Venado Tuerto 655", "Pollo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes);
            Proveedor verduleriaHabemusPapa = new Proveedor("Verdulería Habemus Papa", "789456", "La plumita 1243", "Papa", EMedioDePago.Contado, EDiasDeLaSemana.Miercoles);
            Proveedor almacenTutanJamon = new Proveedor("Almacén Tutan Jamón", "123456", "Ayacucho 322", "Carne", EMedioDePago.Efectivo, EDiasDeLaSemana.Jueves);
            proveedores.Add(carniceriaElSeniorDeLosNovillos);
            proveedores.Add(polleriaMartita);
            proveedores.Add(verduleriaHabemusPapa);
            proveedores.Add(almacenTutanJamon);


            //Lista de stock
            List<Producto> stockProductos = new List<Producto>();
            stockProductos.Add(new Producto("Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000)));
            stockProductos.Add(new Producto("Carne picada", new Stock(carniceriaElSeniorDeLosNovillos, 6000)));
            stockProductos.Add(new Producto("Pollo", new Stock(polleriaMartita, 4500)));
            stockProductos.Add(new Producto("Huevos", new Stock(polleriaMartita, 4500)));
            stockProductos.Add(new Producto("Papa", new Stock(verduleriaHabemusPapa, 3000)));
            stockProductos.Add(new Producto("Tomates", new Stock(verduleriaHabemusPapa, 3000)));
            stockProductos.Add(new Producto("Harina", new Stock(almacenTutanJamon, 5000)));
            stockProductos.Add(new Producto("Aceite", new Stock(almacenTutanJamon, 5000)));

            //Lista de platos con sus ingredientes
            Plato milaConPure = new Plato("Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papa"), 200));
            
            Plato fideosConBolognesa = new Plato("Fideos con bolognesa", 35);
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 200));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Carne picada"), 200));

            Plato polloConEnsalada = new Plato("Pollo con ensalada", 25);
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("Tomate"), 1));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("lechuga"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("pollo"), 250));

            //Lista de Platos disponibles
            List<Plato> platosDisponibles = new List<Plato>();
            platosDisponibles.Add(milaConPure);
            platosDisponibles.Add(fideosConBolognesa);
            platosDisponibles.Add(polloConEnsalada);

            //Lista de bebidas

            List<Bebida> bebidas = new List<Bebida>();
            bebidas.Add(new Bebida(150,"Coca", new Stock(50),false));
            bebidas.Add(new Bebida(200,"Cerveza", new Stock(65),true));
            bebidas.Add(new Bebida(200,"agua", new Stock(100),false));

            List<Empleado> empleados = new List<Empleado>();
            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123",123456,ERol.Cocinero);
            Empleado lele = new Empleado("Lele", "Peri", 1578451256, "asd 322",321654,ERol.Encargado);
            Empleado verónica = new Empleado("Verónica", "Gomez", 1565498712, "asd 344", 654987, ERol.Mesero);
            Empleado augusto = new Empleado("Augusto", "Perez", 1556239875, "peru 566", 659878,ERol.Delivery);
            Empleado churita = new Empleado("Churita", "Corazón", 1587541265, "chile 655",100000, ERol.Mesero);
            empleados.Add(pepe);
            empleados.Add(lele);
            empleados.Add(verónica);
            empleados.Add(augusto);
            empleados.Add(churita);

            
            //Para asignar un mesero a una mesa
            Mesa unaMesa = new Mesa(ENumeroDeMesa.Mesa1,5, churita, platosDisponibles, bebidas);
            Menu menuDisponible = new Menu(platosDisponibles, bebidas);
            menuDisponible.MostrarMenu();
            PlatoService MiPlato = new PlatoService();
            Plato milanesa = new Plato("Milanesa", 30);
            MiPlato.CrearPlato(milanesa, pepe);


            LocalRestaurante miRestaurante = new LocalRestaurante();


            //Agregar los métodos:
            //Agregar,Eliminar,Modificar,Consultar
            //Agregar los ID


        }
    }
}