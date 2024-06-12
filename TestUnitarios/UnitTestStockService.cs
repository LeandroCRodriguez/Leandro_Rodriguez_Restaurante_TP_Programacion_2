using Logica;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTestStockService
    {
        [TestMethod]
        public void ConsultarStockVigente_DeberiaDevolverStockVigente()
        {
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes);
            Proveedor polleriaMartita = new Proveedor("Pollería Martita", "897845", "Venado Tuerto 655", "Pollo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes);
            List<Producto> stockProductos = new List<Producto>();
            stockProductos.Add(new Producto("Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000)));
            stockProductos.Add(new Producto("Carne picada", new Stock(carniceriaElSeniorDeLosNovillos, 6000)));
            stockProductos.Add(new Producto("Pollo", new Stock(polleriaMartita, 4500)));
            StockService stock = new StockService();
            stock.ConsultarStockVigente(stockProductos);
            Assert.AreEqual(3, stockProductos.Count, "La cantidad de productos en el stock debería ser 3");
        }

        [TestMethod]
        public void ConsultarStockPorAgotarse_DeberiaDevolverStockPorAgotarse()
        {
            Proveedor carniceriaElSeniorDeLosNovillos = new Proveedor("Carniceria El Señor de los Novillos", "123456", "Ayacucho 322", "Carne", EMedioDePago.Transferencia, EDiasDeLaSemana.Martes);
            Proveedor polleriaMartita = new Proveedor("Pollería Martita", "897845", "Venado Tuerto 655", "Pollo", EMedioDePago.Efectivo, EDiasDeLaSemana.Viernes);
            List<Producto> stockProductos = new List<Producto>();
            stockProductos.Add(new Producto("Bola de lomo", new Stock(carniceriaElSeniorDeLosNovillos, 5000)));
            stockProductos.Add(new Producto("Carne picada", new Stock(carniceriaElSeniorDeLosNovillos, 6000)));
            stockProductos.Add(new Producto("Pollo", new Stock(polleriaMartita, 10)));
            StockService stock = new StockService();
            List<Producto> productosPorAgotarse = stock.ConsultarStockPorAgotarse(stockProductos);

            Assert.AreEqual(1, productosPorAgotarse.Count, "La cantidad de productos en el stock por agotarse debería ser 1");
            Assert.AreEqual("Pollo", productosPorAgotarse[0].Nombre, "El producto por agotarse debería ser 'Pollo'");
        }

        [TestMethod]
        public void RealizarIngresoDeStock_EncargadoDeberiaIncrementarStock()
        {
            Empleado lele = new Empleado("Lele", "Peri", 1578451256, "asd 322", 321654, ERol.Encargado);
            Producto producto = new Producto("Bola de lomo", new Stock(5000));
            StockService stockService = new StockService(producto);

            stockService.RealizarIngresoDeStock(lele, 100);

            Assert.AreEqual(5100, producto.Stock.Cantidad, "El stock debería haberse incrementado en 100");
        }

        [TestMethod]
        [ExpectedException(typeof(RolNoCompatibleExcepcion))]
        public void RealizarIngresoDeStock_NoEncargadoDeberiaLanzarExcepcion()
        {
            Empleado augusto = new Empleado("Augusto", "Perez", 1556239875, "peru 566", 659878, ERol.Delivery);
            Producto producto = new Producto("Bola de lomo", new Stock(5000));
            StockService stockService = new StockService(producto);

            stockService.RealizarIngresoDeStock(augusto, 100);
        }

        public void RealizarEgresoStock_DeberiaReducirStockCorrectamente()
        {
            Plato milaConPure = new Plato(145, "Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papas"), 200));

            Producto producto1 = new Producto("Bola de lomo", new Stock(5000));
            Producto producto2 = new Producto("Papas", new Stock(500));
            List<Producto> stockProductos = new List<Producto>();
            stockProductos.Add(producto1);
            stockProductos.Add(producto2);

            StockService stockService = new StockService();

            stockService.RealizarEgresoStock(milaConPure, stockProductos);

            Assert.AreEqual(4800, producto1.Stock.Cantidad, "El stock de Bola de lomo debería haberse reducido en 200");
            Assert.AreEqual(400, producto2.Stock.Cantidad, "El stock de Papas debería haberse reducido en 100");
        }
    }
}
