using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestMesaService
    {
        [TestMethod]
        public void AsignarPlatoAMesa_DeberiaAsignarMesaSiHaySuficienteStock()
        {

            ENumeroDeMesa numeroMesa = ENumeroDeMesa.Mesa1; 
            int capacidad = 4;
            Empleado veronica = new Empleado("Verónica", "Gomez", 1565498712, "asd 344", 654987, ERol.Mesero);

            List<Plato> platosAsignados = new List<Plato>();
            List<Bebida> bebidasAsignadas = new List<Bebida>();

            Producto producto1 = new Producto("Carne", new Stock(500));
            Producto producto2 = new Producto("Papas", new Stock(200));
            List<Producto> stockProductos = new List<Producto> { producto1, producto2 };

            Ingrediente ingrediente1 = new Ingrediente(new Producto("Carne"), 100);
            Ingrediente ingrediente2 = new Ingrediente(new Producto("Papas"), 50);
            Plato platoDisponible = new Plato(101, "Milanesa con papas", 10);
            platoDisponible.AgregarIngrediente(ingrediente1);
            platoDisponible.AgregarIngrediente(ingrediente2);
            List<Plato> platosDisponibles = new List<Plato> { platoDisponible };

            MesaService mesaService = new MesaService();

            Mesa mesaAsignada = mesaService.AsignarPlatoAMesa(numeroMesa, capacidad, veronica, platosAsignados, bebidasAsignadas, stockProductos, platosDisponibles);

            Assert.IsNotNull(mesaAsignada, "La mesa debería ser asignada correctamente.");
            Assert.AreEqual(numeroMesa, mesaAsignada.EnumeroDeMesa, "El número de mesa asignado no es correcto.");
            Assert.AreEqual(capacidad, mesaAsignada.Capacidad, "La capacidad de la mesa asignada no es correcta.");
            Assert.AreEqual(veronica, mesaAsignada.Mesero, "El mesero asignado no es correcto.");
        }
        // Hacer test para los casos que sí, que no, y los casos de borde
    }
}
