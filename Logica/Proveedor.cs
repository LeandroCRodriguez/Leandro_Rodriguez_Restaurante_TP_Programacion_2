using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum EMedioDePago
    {
        Contado,
        Efectivo,
        Transferencia
    }
    public enum EDiasDeLaSemana
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes
    }
    public class Proveedor
    {
        string nombre;
        double cuit;
        int direccion;
        Producto tipoDeProducto;
        EMedioDePago medioDePago;
        EDiasDeLaSemana ediasDeLaSemana;

        public Proveedor(string nombre, double cuit, int direccion, Producto tipoDeProducto, 
            EMedioDePago medioDePago, EDiasDeLaSemana ediasDeLaSemana)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            this.direccion = direccion;
            this.tipoDeProducto = tipoDeProducto;
            this.medioDePago = medioDePago;
            this.ediasDeLaSemana = ediasDeLaSemana;
        }
    }
}
