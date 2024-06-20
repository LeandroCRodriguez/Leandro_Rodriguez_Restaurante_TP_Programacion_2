namespace Logica
{
    public class MesaService
    {
        //public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa, int capacidad,
        //    Empleado mesero, List<Plato> platosAsginados, List<Bebida> bebidasAsignadas,
        //    List<Producto> stockProductos, List<Plato> platosDisponibles)
        //{
        //    foreach (Producto producto in stockProductos)
        //    {
        //        int cantidadStockProducto = producto.Stock.Cantidad;
        //        foreach (Plato unPlato in platosAsginados)
        //        {
        //            List<Ingrediente> ingredientes = unPlato.Ingredientes;
        //            foreach (Ingrediente ingrediente in ingredientes)
        //            {
        //                int cantidadIngrediente = ingrediente.Cantidad;
        //                if (cantidadStockProducto > cantidadIngrediente)
        //                {
        //                    //Realizo egreso de stock
        //                    StockService stokService = new StockService();
        //                    stokService.RealizarEgresoStock(unPlato, stockProductos);    
        //                }
        //                else
        //                {
        //                    throw new Exception("No hay suficiente stock para asignar esos platos a la mesa");
        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine($"Mesa {numeroMesa} asignada correctamente");
        //    return new Mesa(numeroMesa, capacidad, mesero, platosAsginados, bebidasAsignadas);
        //}

        //VERSIÓN 2 MI METODO

        public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa, int capacidad,
            Empleado mesero, List<Plato> platosAsignados, List<Bebida> bebidasAsignadas,
            List<Producto> stockProductos, List<Plato> platosDisponibles)
        {
            foreach (Plato unPlato in platosAsignados)
            {
                foreach (Ingrediente ingrediente in unPlato.Ingredientes)
                {
                    Producto productoCorrespondiente = null;
                    foreach (Producto producto in stockProductos)
                    {
                        int cantidadIngrediente = ingrediente.Cantidad;
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


        //public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa, int capacidad,
        //Empleado mesero, List<Plato> platosAsignados, List<Bebida> bebidasAsignadas,
        //List<Producto> stockProductos, List<Plato> platosDisponibles)
        //{
        //    // Crear una lista para los platos que pueden ser asignados
        //    List<Plato> platosQuePuedenSerAsignados = new List<Plato>();

        //    foreach (Plato unPlato in platosAsignados)
        //    {
        //        bool puedeAsignarPlato = true;

        //        // Verificar si hay suficiente stock para todos los ingredientes del plato
        //        foreach (Ingrediente ingrediente in unPlato.Ingredientes)
        //        {
        //            Producto productoStock = null;

        //            // Buscar el producto correspondiente al ingrediente en el stock usando foreach
        //            foreach (Producto producto in stockProductos)
        //            {
        //                if (producto.Nombre == ingrediente.Producto.Nombre)
        //                {
        //                    productoStock = producto;
        //                    break;
        //                }
        //            }

        //            if (productoStock == null || productoStock.Stock.Cantidad < ingrediente.Cantidad)
        //            {
        //                // Si no hay suficiente stock para algún ingrediente, no se puede asignar este plato
        //                puedeAsignarPlato = false;
        //                break;
        //            }
        //        }

        //        if (puedeAsignarPlato)
        //        {
        //            // Restar ingredientes del stock
        //            foreach (Ingrediente ingrediente in unPlato.Ingredientes)
        //            {
        //                foreach (Producto producto in stockProductos)
        //                {
        //                    if (producto.Nombre == ingrediente.Producto.Nombre)
        //                    {
        //                        producto.Stock.Cantidad -= ingrediente.Cantidad;
        //                        break;
        //                    }
        //                }
        //            }
        //            // Agregar el plato a la lista de platos que pueden ser asignados
        //            platosQuePuedenSerAsignados.Add(unPlato);
        //        }
        //    }

        //    // Verificar si hay platos que se pueden asignar
        //    if (platosQuePuedenSerAsignados.Count == 0)
        //    {
        //        throw new Exception("No hay suficiente stock para asignar esos platos a la mesa");
        //    }

        //    // Crear y devolver una nueva mesa con los platos asignados
        //    Console.WriteLine($"Mesa {numeroMesa} asignada correctamente");
        //    return new Mesa(numeroMesa, capacidad, mesero, platosQuePuedenSerAsignados, bebidasAsignadas);
        //}

        //public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa, int capacidad,
        //Empleado mesero, List<Plato> platosAsignados, List<Bebida> bebidasAsignadas,
        //List<Producto> stockProductos, List<Plato> platosDisponibles)
        //{
        //    List<Plato> platosAsignables = new List<Plato>();

        //    foreach (Plato unPlato in platosAsignados)
        //    {
        //        bool puedeAsignar = true;

        //        foreach (Ingrediente ingrediente in unPlato.Ingredientes)
        //        {
        //            Producto productoStock = stockProductos.FirstOrDefault(p => p.Nombre == ingrediente.Producto.Nombre);

        //            if (productoStock == null || productoStock.Stock.Cantidad < ingrediente.Cantidad)
        //            {
        //                puedeAsignar = false;
        //                break;
        //            }
        //        }

        //        if (puedeAsignar)
        //        {
        //            // Restar ingredientes del stock
        //            foreach (Ingrediente ingrediente in unPlato.Ingredientes)
        //            {
        //                Producto productoStock = stockProductos.FirstOrDefault(p => p.Nombre == ingrediente.Producto.Nombre);
        //                if (productoStock != null)
        //                {
        //                    productoStock.Stock.Cantidad -= ingrediente.Cantidad;
        //                }
        //            }
        //            platosAsignables.Add(unPlato);
        //        }
        //    }

        //    if (platosAsignables.Count == 0)
        //    {
        //        throw new Exception("No hay suficiente stock para asignar esos platos a la mesa");
        //    }

        //    Console.WriteLine($"Mesa {numeroMesa} asignada correctamente");
        //    return new Mesa(numeroMesa, capacidad, mesero, platosAsignables, bebidasAsignadas);
        //}

    }
}

//hay alguna manera de hacer menos foreach? Necesito acceder a la cantidad de
//la lista de stock y preguntar si es mayor a la cantidad que hay en la lista
//de ingredientes que se encuentra dentro de la lista de platos. Si es mayor,
//entonces se puede asignar un plato a una mesa, sino no.