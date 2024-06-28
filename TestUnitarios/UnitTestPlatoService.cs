using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestPlatoService
    {
        [TestMethod]
        public void CrearPlato_DeberiaCrearUnPlatoCorrectamente()
        {
            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123", 123456, ERol.Cocinero);
            PlatoService platoService = new PlatoService();
            Plato platoCreado = platoService.CrearPlato(pepe,"Lasagna de ricota y verduras", 50);

            Assert.IsNotNull(platoCreado, "El plato creado no debería ser nulo.");
            Assert.AreEqual("Lasagna de ricota y verduras", platoCreado.Nombre, "El nombre del plato no es correcto.");
            Assert.AreEqual(50, platoCreado.TiempoDePreparacion, "El tiempo de preparación del plato no es correcto.");
        }

        [TestMethod]
        public void EditarPlato_DeberiaEditarUnPlatoExistente()
        {
            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123", 123456, ERol.Cocinero);
            PlatoService platoService = new PlatoService();
            MiRestaurante restaurante = new MiRestaurante(2000);
            Plato milaConPure = new Plato(145, "Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papa"), 200));
            restaurante.PlatosDisponibles.Add(milaConPure);
            Plato milaConPureEditada = platoService.EditarPlato(pepe, "Milanesa con pure", 20, restaurante.PlatosDisponibles);

            Assert.IsNotNull(milaConPureEditada, "El plato creado no debería ser nulo.");
            Assert.AreEqual("Milanesa con pure", milaConPureEditada.Nombre, "El nombre del plato no es correcto.");
            Assert.AreEqual(20, milaConPureEditada.TiempoDePreparacion, "El tiempo de preparación del plato no es correcto.");
        }

        [TestMethod]
        public void EliminarPlato_DeberiaEliminarUnPlatoCorrectamente()
        {
            Plato milaConPure = new Plato(145, "Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Bola de lomo"), 200));
            milaConPure.AgregarIngrediente(new Ingrediente(new Producto("Papa"), 200));

            Plato fideosConBolognesa = new Plato(110, "Fideos con bolognesa", 35);
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Harina"), 200));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(new Producto("Carne picada"), 200));

            List<Plato> platosDisponibles = new List<Plato>();
            platosDisponibles.Add(milaConPure);
            platosDisponibles.Add(fideosConBolognesa);

            Empleado pepe = new Empleado("Pepe", "Gomez", 1587459865, "Abc123", 123456, ERol.Cocinero);
            PlatoService platoService = new PlatoService();
            bool resultado = platoService.EliminarPlato(milaConPure, pepe, platosDisponibles);
            Assert.IsTrue(resultado, "El plato debería ser eliminado correctamente.");
            Assert.AreEqual(1, platosDisponibles.Count, "La lista de platos disponibles debería tener 1 plato");
        }

        [TestMethod]
        public void EstablecerPrecioDePlato_DeberiaPonerleUnPrecioAlPlato()
        {
            Empleado lele = new Empleado("Lele", "Peri", 1578451256, "asd 322", 321654, ERol.Encargado);
            Plato polloConEnsalada = new Plato(125, "Pollo con ensalada", 25);
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("Tomate"), 1));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("lechuga"), 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(new Producto("pollo"), 250));

            PlatoService platoService = new PlatoService();
            Plato platoPrecioActualizado = platoService.EstablecerPrecioDePlato(polloConEnsalada, lele,150);
            Assert.IsNotNull(platoPrecioActualizado, "El plato no debería ser nulo");
            Assert.AreEqual(platoPrecioActualizado.Precio, 150, "El precio no es correcto");
        }

        [TestMethod]
        public void GetPlatosPorIngrediente_DeberiaDevolverUnaListaDePlatosPorIngrediente()
        {
            Producto bolaDeLomo = new Producto("Bola de lomo", new Stock(5000));
            Producto papa = new Producto("Papa", new Stock(5000));
            Producto harina = new Producto("Harina", new Stock(5000));
            Producto carnePicada = new Producto("Carne picada", new Stock(5000));
            Producto tomate = new Producto("Tomate", new Stock(50)); 
            Producto lechuga = new Producto("Lechuga", new Stock(200));
            Producto pollo = new Producto("Pollo", new Stock(250));

            Plato milaConPure = new Plato(145, "Milanesa con pure", 30);
            milaConPure.AgregarIngrediente(new Ingrediente(bolaDeLomo, 200));
            milaConPure.AgregarIngrediente(new Ingrediente(papa, 200));

            Plato fideosConBolognesa = new Plato(110, "Fideos con bolognesa", 35);
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(harina, 200));
            fideosConBolognesa.AgregarIngrediente(new Ingrediente(carnePicada, 200));

            Plato polloConEnsalada = new Plato(125, "Pollo con ensalada", 25);
            polloConEnsalada.AgregarIngrediente(new Ingrediente(tomate, 1));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(lechuga, 100));
            polloConEnsalada.AgregarIngrediente(new Ingrediente(pollo, 250));

            //Lista de Platos disponibles
            List<Plato> platosDisponibles = new List<Plato>();
            platosDisponibles.Add(milaConPure);
            platosDisponibles.Add(fideosConBolognesa);
            platosDisponibles.Add(polloConEnsalada);

            Ingrediente ingredienteFaltante = new Ingrediente(new Producto("Tomate"), 150);
            PlatoService platoService = new PlatoService();
            List<Plato> platosNoDisponibles = platoService.GetPlatosNoDisponibles(ingredienteFaltante, platosDisponibles);

            Assert.IsTrue(platosNoDisponibles.Contains(polloConEnsalada), "El plato 'Pollo con ensalada' debería estar en la lista de platos no disponibles debido al stock insuficiente de tomate.");
            Assert.AreEqual(1, platosNoDisponibles.Count, "Debería haber 1 plato no disponible debido al stock insuficiente.");
        }
        [TestMethod]
        [ExpectedException(typeof(RolNoCompatibleExcepcion))]
        public void CrearPlato_DeberiaLanzarExcepcionSiRolNoEsCocinero()
        {
            Empleado mesero = new Empleado("Juan", "Pérez", 123456789, "contraseña123", 123456, ERol.Mesero);
            PlatoService platoService = new PlatoService();

            platoService.CrearPlato(mesero, "Ensalada", 15);

            // Si llega aquí, la prueba falla
            Assert.Fail("Se esperaba una excepción de tipo RolNoCompatibleExcepcion.");
        }

        [TestMethod]
        [ExpectedException(typeof(RolNoCompatibleExcepcion))]
        public void EditarPlato_DeberiaLanzarExcepcionSiRolNoEsCocinero()
        {
            Empleado mesero = new Empleado("Juan", "Pérez", 123456789, "contraseña123", 123456, ERol.Mesero);
            PlatoService platoService = new PlatoService();
            List<Plato> platos = new List<Plato>
            {
                new Plato("Ensalada", 15)
            };

            platoService.EditarPlato(mesero, "Ensalada", 20, platos);

            // Si llega aquí, la prueba falla
            Assert.Fail("Se esperaba una excepción de tipo RolNoCompatibleExcepcion.");
        }

        [TestMethod]
        [ExpectedException(typeof(RolNoCompatibleExcepcion))]
        public void EliminarPlato_DeberiaLanzarExcepcionSiRolNoEsCocinero()
        {
            Empleado mesero = new Empleado("Juan", "Pérez", 123456789, "contraseña123", 123456, ERol.Mesero);
            PlatoService platoService = new PlatoService();
            List<Plato> platos = new List<Plato>
            {
                new Plato("Ensalada", 15)
            };

            platoService.EliminarPlato(platos[0], mesero, platos);

            // Si llega aquí, la prueba falla
            Assert.Fail("Se esperaba una excepción de tipo RolNoCompatibleExcepcion.");
        }
    }
}
