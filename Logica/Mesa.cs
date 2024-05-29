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
        Mesero mesero;
        List<Plato> platos;
        List<Bebida> bebidas;

        public Mesa(ENumeroDeMesa enumeroDeMesa, int capacidad, Mesero mesero, 
            List<Plato> platos, List<Bebida> bebidas)
        {
            this.Capacidad = capacidad;
            this.EnumeroDeMesa = enumeroDeMesa;
            this.Mesero = mesero;
            this.Platos = platos;
            this.Bebidas = bebidas;
        }

        public int Capacidad { get { return capacidad; } set { capacidad = value; } }
        public ENumeroDeMesa EnumeroDeMesa { get { return enumeroDeMesa; } set { enumeroDeMesa = value; } }
        public Mesero Mesero { get { return mesero; } set { mesero = value; } }
        public List<Plato> Platos { get => platos; set => platos = value; }
        public List<Bebida> Bebidas { get => bebidas; set => bebidas = value; }

        public Plato AsignarPlato(Plato plato)
        {
            return plato;//Es necesario asignar un plato acá si ya lo tengo en el constructor?
        }



    }
}
