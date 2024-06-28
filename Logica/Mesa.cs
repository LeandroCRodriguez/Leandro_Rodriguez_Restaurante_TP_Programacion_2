using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum ENumeroDeMesa
    {
        Mesa1 = 1,
        Mesa2 = 2,
        Mesa3 = 3,
        Mesa4 = 4,
        Mesa5 = 5,
        Mesa6 = 6,
        Mesa7 = 7,
        Mesa8 = 8,
        Mesa9 = 9,
        Mesa10 = 10
    }
    public class Mesa
    {
        int capacidad;
        ENumeroDeMesa enumeroDeMesa;
        Empleado mesero;
        List<Plato> platos;
        List<Bebida> bebidas;
        bool estadoMesa;

        public Mesa(ENumeroDeMesa enumeroDeMesa, int capacidad, Empleado mesero, 
            List<Plato> platos, List<Bebida> bebidas)
        //La lista de platos y de bebidas son necesarias acá, porque las listas de la clase Menu
        //son para mostrar justamente el menu
        {
            this.Capacidad = capacidad;
            this.EnumeroDeMesa = enumeroDeMesa;
            this.Mesero = mesero;
            this.Platos = platos;
            this.Bebidas = bebidas;
            this.EstadoMesa = true;
        }
        public int Capacidad { get { return capacidad; } set { capacidad = value; } }
        public ENumeroDeMesa EnumeroDeMesa { get { return enumeroDeMesa; } set { enumeroDeMesa = value; } }
        public Empleado Mesero { get { return mesero; } set { mesero = value; } }
        public List<Plato> Platos { get => platos; set => platos = value; }
        public List<Bebida> Bebidas { get => bebidas; set => bebidas = value; }
        public bool EstadoMesa { get => estadoMesa; set => estadoMesa = value; }
    }
}
