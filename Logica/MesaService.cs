namespace Logica
{
    public class MesaService
    {
        public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa, int capacidad,
            Empleado mesero, List<Plato> platosAsignados, List<Bebida> bebidasAsignadas,
            List<Producto> stockProductos)
        {
            foreach (Plato unPlato in platosAsignados)
            {
                foreach (Ingrediente ingrediente in unPlato.Ingredientes)
                {
                    Producto productoCorrespondiente = null;
                    foreach (Producto producto in stockProductos)
                    {
                        if (producto.Nombre == ingrediente.Producto.Nombre)
                        {
                            productoCorrespondiente = producto;
                        }                        
                    }
                    if (productoCorrespondiente == null || productoCorrespondiente.Stock.Cantidad < ingrediente.Cantidad)
                    {
                        throw new Exception($"No hay suficiente stock de {ingrediente.Producto.Nombre} para asignar el plato {unPlato.Nombre} a la mesa");
                    }
                }
            }
            foreach (Plato unPlato in platosAsignados)
            {
                // Realizamos el egreso de stock para cada plato asignado
                StockService stokService = new StockService();
                stokService.RealizarEgresoStock(unPlato, stockProductos);
            }

            Console.WriteLine($"Mesa {numeroMesa} asignada correctamente");
            return new Mesa(numeroMesa, capacidad, mesero, platosAsignados, bebidasAsignadas);
        }
    }
}

