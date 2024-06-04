namespace Logica
{
    public class StockService
    {
        Producto producto;
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
                    ingredienteStock.Stock.Cantidad =- ingredienteDelPlato;
                }
            }
        }
    }
}