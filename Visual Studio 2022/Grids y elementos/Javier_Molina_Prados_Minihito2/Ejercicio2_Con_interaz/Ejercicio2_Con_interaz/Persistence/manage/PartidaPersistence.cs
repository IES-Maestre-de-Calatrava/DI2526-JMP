using Ejercicio2_Con_interaz.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Con_interaz.Persistence.manage
{
    internal class PartidaPersistence
    {

        private DataTable table { get; set; }
        List<Partida> listaPartidas { get; set; }

        public PartidaPersistence()
        {
            table = new DataTable();
            listaPartidas = new List<Partida>();
        }

        public static List<Partida> LeerPartidas()
        {
            Partida partida = null;

            List<object> aux = DBBroker.obtenerAgente().leer("SELECT * from examen.partida;");
            List<Partida> listaPartidas = new List<Partida>();

            foreach (List<object> fila in aux)
            {
                partida = new Partida(Convert.ToInt32(fila[0]), fila[1].ToString(), Convert.ToDateTime(fila[2]), fila[3].ToString(), Convert.ToDouble(fila[4]));
                listaPartidas.Add(partida);
                Console.WriteLine(partida.ToString());
            }

            return listaPartidas;
        }

        public void Insert(Partida partida)
        {

            string fechaSQL = partida.Fecha_juego.ToString("yyyy-MM-dd");

            string puntuacionSQL = partida.Puntuacion.ToString(CultureInfo.InvariantCulture);

            DBBroker.obtenerAgente().modificar("INSERT INTO examen.partida (nickname, fecha_juego, nivel, puntuacion) VALUES ('"
            + partida.Nickname + "', '" + fechaSQL + "', '" + partida.Nivel + "', " + puntuacionSQL + ");");

        }

        public void Delete(Partida partida)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM examen.partida WHERE id = " + partida.ID + ";");
        }

        public void Update(Partida partida)
        {

            string fechaSQL = partida.Fecha_juego.ToString("yyyy-MM-dd");

            string puntuacionSQL = partida.Puntuacion.ToString(CultureInfo.InvariantCulture);

            DBBroker.obtenerAgente().modificar("UPDATE examen.partida SET nickname = '" + partida.Nickname + "', fecha_juego = '"
            + fechaSQL + "', nivel = '" + partida.Nivel + "', puntuacion = " + puntuacionSQL + " WHERE id = " + partida.ID + ";");
        }
    }
}
