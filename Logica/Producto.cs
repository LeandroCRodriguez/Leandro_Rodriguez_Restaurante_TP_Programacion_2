using System.Text;

namespace Logica
{
    public class Producto
    {
        string nombre;
        double precio;
        Stock stock;

        public Producto(string nombre, Stock stock)
        {
            this.nombre = nombre;            
            this.stock = stock;
        }

        public Producto(double precio, string nombre, Stock stock) 
            :this(nombre, stock)
        {
            this.precio = precio;
        }

        public Producto(string nombre)//Para crear lista de platos
        {
            this.nombre = nombre;
        }

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        public Stock Stock { get { return stock; } set { stock = value; } }


        public void IncrementarStock(int cantidad)
        {
            stock.Cantidad += cantidad;
        }

        public void DecrementarStock(int cantidad)
        {
            stock.Cantidad -= cantidad;
        }

        public string MostrarProducto()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(nombre);
            sb.AppendLine(precio.ToString());
            sb.AppendLine(stock.ToString());
            return sb.ToString();
        }
    }
}