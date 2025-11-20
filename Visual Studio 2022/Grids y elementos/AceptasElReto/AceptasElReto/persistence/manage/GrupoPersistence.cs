using AceptasElReto.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceptasElReto.persistence.manage
{
    internal class GrupoPersistence
    {

        private DataTable table { get; set; }
        List<Alumnado> listagrupos { get; set; }

        public GrupoPersistence()
        {
            table = new DataTable();
            listagrupos = new List<Alumnado>();
        }

        public static List<Grupo> LeerGrupos()
        {
            Grupo grupo = null;
            List<Grupo> listaGrupos = new List<Grupo>();

            string sql = @"SELECT idgrupo, nombre from aceptasreto.grupo";

            List<Object> aux = DBBroker.obtenerAgente().leer(sql);
            foreach (List<Object> fila in aux)
            {
                grupo = new Grupo(
                    Convert.ToInt32(fila[0]),
                    fila[1].ToString()
                );
                listaGrupos.Add(grupo);
            }
            return listaGrupos;
        }


    }
}
