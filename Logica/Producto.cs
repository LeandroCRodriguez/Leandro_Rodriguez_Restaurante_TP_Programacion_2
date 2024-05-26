using System.Text;

namespace Logica
{
    public class Producto
    {
        string nombre;
        double precio;
        int stock;

        public Producto(string nombre,int stock)
        {
            this.nombre = nombre;            
            this.stock = stock;
        }

        public Producto(double precio, string nombre, int stock) :this(nombre, stock)
        {
            this.precio = precio;
        }

        public string Nombre { get { return nombre; } }
        public double Precio { get { return precio; } }
        public int Stock { get { return stock; } }

        public void IncrementarStock(int cantidad)
        {
            stock += cantidad;
        }

        public void DecrementarStock(int cantidad)
        {
            stock -= cantidad;
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