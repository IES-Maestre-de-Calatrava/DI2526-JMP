using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceptasElReto.domain
{
    internal class Grupo
    {
        private int idGrupo;
        private String nombre;

        public Grupo(int idGrupo, string nombre)
        {
            this.idGrupo = idGrupo;
            this.nombre = nombre;
        }

        public int IdGrupo { get => idGrupo; set => idGrupo = value; }
        public String Nombre { get => nombre; set => nombre = value; }
    }
}
