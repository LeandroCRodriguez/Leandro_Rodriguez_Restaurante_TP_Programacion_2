using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Menu
    {
        List<Plato> platos;
        List<Bebida> bebida;

        public Menu(List<Plato> platos, List<Bebida> bebida) 
            //Puse lista de bebidas aunque en el diagrama aparece como un atributo
        {
            this.platos = platos;
            this.bebida = bebida;
        }

        public List<Plato> Platos { get => platos; set => platos = value; }
        public List<Bebida> Bebida { get => bebida; set => bebida = value; }
    }
}
