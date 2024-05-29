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
        }
        public void RealizarEgresoStock(Plato plato)
        {

        }
    }
}