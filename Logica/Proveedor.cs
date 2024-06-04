using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        string cuit;
        string direccion;
        string tipoDeProducto;
        EMedioDePago medioDePago;
        EDiasDeLaSemana ediasDeLaSemana;

        public Proveedor(string nombre, string cuit, string direccion, string tipoDeProducto, 
            EMedioDePago medioDePago, EDiasDeLaSemana ediasDeLaSemana)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            this.direccion = direccion;
            this.tipoDeProducto = tipoDeProducto;
            this.medioDePago = medioDePago;
            this.ediasDeLaSemana = ediasDeLaSemana;
        }

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Cuit { get { return cuit; } set { cuit = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string TipoDeProducto { get { return tipoDeProducto; } set { tipoDeProducto = value; } }
        public EMedioDePago MedioDePago { get { return medioDePago; } set { medioDePago = value; } }
        public EDiasDeLaSemana EdiasDeLaSemana { get { return ediasDeLaSemana; } set { ediasDeLaSemana = value; } }


        public string MostrarProveedor()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {Nombre}");
            sb.AppendLine($"CUIT: {Cuit}");
            sb.AppendLine($"Dirección: {Direccion}");
            sb.AppendLine($"Tipo de Producto: {TipoDeProducto}");
            sb.AppendLine($"Medio de Pago: {MedioDePago}");
            sb.AppendLine($"Día de Entrega: {EdiasDeLaSemana}");
            return sb.ToString();
        }
    }
}
