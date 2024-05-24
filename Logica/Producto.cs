namespace Logica
{
    public class Producto
    {
        string nombre;
        double precio;
        Dictionary<string, int> stock;

        public Producto(string nombre, double precio, Dictionary<string, int> stock)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
        }
    }
}