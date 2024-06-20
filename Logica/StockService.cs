namespace Logica
{
    public class StockService
    {
        Producto producto;
        public StockService(Producto producto)
        {
            this.producto = producto;
        }
        public StockService()
        {

        }
        public List<Producto> ConsultarStockVigente(List<Producto> stock)
        {
            return stock;
        }

        public List<Producto> ConsultarStockPorAgotarse(List<Producto> stockPorAgotarse)
        {
            List<Producto> productosPorAgotarse = new List<Producto>();
            foreach (Producto item in stockPorAgotarse)
            {
                if (item.Stock.Cantidad < 50)
                {
                    productosPorAgotarse.Add(item);
                }
            }
            return productosPorAgotarse;
        }
        public void RealizarIngresoDeStock(Empleado empleado, int cantidad)
        {
            if(empleado.Rol == ERol.Encargado)
            {
                producto.IncrementarStock(cantidad);
            }
            else
            {
                throw new RolNoCompatibleExcepcion("El Rol del Empleado no tiene acceso a la solicitud");
            }
        }
        //Ver si está bien este metodo
        public void RealizarEgresoStock(Plato plato, List<Producto> stockProductos) 
        {
            foreach (Ingrediente ingrediente in plato.Ingredientes)
            {
                int ingredienteDelPlato = ingrediente.Cantidad;
                foreach (Producto ingredienteStock in stockProductos)
                {
                    if(ingredienteStock.Nombre == ingrediente.Producto.Nombre)
                    {
                        ingredienteStock.Stock.Cantidad -= ingredienteDelPlato;
                        Console.WriteLine($"Egreso de {ingrediente.Cantidad} de {ingredienteStock.Nombre} para el plato {plato.Nombre}. Stock restante: {ingredienteStock.Stock.Cantidad}");
                    }
                }
            }
        }
    }
}