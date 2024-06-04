namespace Logica
{
    public class MesaService
    {
        public Mesa AsignarPlatoAMesa(ENumeroDeMesa numeroMesa,int capacidad,
            Empleado mesero,List<Plato>platosAsginados, List<Bebida> bebidasAsignadas,
            List<Producto> stockProductos, List<Plato> platosDisponibles)
        {
            foreach (Producto producto in stockProductos)
            {
                int cantidadStockProducto = producto.Stock.Cantidad;
                foreach (Plato unPlato in platosDisponibles)
                {
                    List<Ingrediente> ingredientes = unPlato.Ingredientes;
                    foreach (Ingrediente ingrediente in ingredientes)
                    {
                        int cantidadIngrediente = ingrediente.Cantidad;
                        if (cantidadStockProducto > cantidadIngrediente)
                        {
                            return new Mesa(numeroMesa, capacidad, mesero, platosAsginados, bebidasAsignadas);
                        }                        
                    }
                }
            }
            throw new Exception("No hay suficiente stock para asignar esos platos a la mesa");
        }
    }
}

//hay alguna manera de hacer menos foreach? Necesito acceder a la cantidad de
//la lista de stock y preguntar si es mayor a la cantidad que hay en la lista
//de ingredientes que se encuentra dentro de la lista de platos. Si es mayor,
//entonces se puede asignar un plato a una mesa, sino no.