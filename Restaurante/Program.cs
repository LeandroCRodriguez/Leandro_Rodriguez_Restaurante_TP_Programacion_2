using Logica;

namespace Restaurante
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Crear una lista de stock
            List<Producto> stockProductos = new List<Producto>();
            stockProductos.Add(new Producto("Bola de lomo", new Stock(new Proveedor("Carniceria Pepe", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes), 5000)));
            stockProductos.Add(new Producto("Carne picada", new Stock(new Proveedor("Carniceria Pepe", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes), 6000)));
            stockProductos.Add(new Producto("Pollo", new Stock(new Proveedor("Granja La Pollería", "897845", "Venado Tuerto 655", "Pollo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes), 4500)));
            stockProductos.Add(new Producto("Huevos", new Stock(new Proveedor("Granja La Pollería", "897845", "Venado Tuerto 655", "huevo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes), 4500)));
            stockProductos.Add(new Producto("Papa", new Stock(new Proveedor("Verdulería Juan", "789456", "La plumita 1243", "Papa", EMedioDePago.Contado, EDiasDeLaSemana.Miercoles), 3000)));
            stockProductos.Add(new Producto("Tomates", new Stock(new Proveedor("Verdulería Juan", "789456", "La plumita 1243", "Tomate", EMedioDePago.Contado, EDiasDeLaSemana.Miercoles), 3000)));
            stockProductos.Add(new Producto("Harina", new Stock(new Proveedor("El Almacén", "123456", "Ayacucho 322", "Carne", EMedioDePago.Efectivo, EDiasDeLaSemana.Jueves), 5000)));
            stockProductos.Add(new Producto("Aceite", new Stock(new Proveedor("El Almacén", "123456", "Ayacucho 322", "Carne", EMedioDePago.Efectivo, EDiasDeLaSemana.Jueves), 5000)));

            //Lista de ingredientes
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

            //Crear una lista de Platos disponibles
            List<Plato> platosDisponibles = new List<Plato>();
            platosDisponibles.Add(milaConPure);
            platosDisponibles.Add(fideosConBolognesa);
            platosDisponibles.Add(polloConEnsalada);

            //Crear lista de bebidas

            List<Bebida> bebidas = new List<Bebida>();
            bebidas.Add(new Bebida(150,"Coca", new Stock(50),false));
            bebidas.Add(new Bebida(200,"Cerveza", new Stock(65),true));
            bebidas.Add(new Bebida(200,"agua", new Stock(100),false));

            //Para asignar un plato a la lista de platos disponibles.
            LocalRestaurante miRestaurante = new LocalRestaurante();

 
            //miRestaurante.ConstruirPlato(stockProductos,)

            //Para asignar un mesero a una mesa

            Mesero pepe = new Mesero("Pepe", "Gomez", 1587459865, "Abc123",123456);
            Mesero lele = new Mesero("Lele", "Peri", 1578451256, "asd 322",321654);
            Cocinero verónica = new Cocinero("Verónica", "Gomez", 1565498712, "asd 344", 654987);
            Cocinero augusto = new Cocinero("Augusto", "Perez", 1556239875, "peru 566", 659878);
            Encargado churita = new Encargado("Churita", "Corazón", 1587541265, "chile 655",100000);
            
            Mesa unaMesa = new Mesa(ENumeroDeMesa.Mesa1,5,mesero1, platosDisponibles, bebidas);
 

        }
    }
}