using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Org.BouncyCastle.Crypto.Engines;

namespace AceptasElReto
{
    class AlumnadoPersistence
    {
        private DataTable table { get; set; }
        List<Alumnado> listaPersonas { get; set; }

        public AlumnadoPersistence()
        {
            table = new DataTable();
            listaPersonas = new List<Alumnado>();
        }


        public static List<Alumnado> LeerPersonas()
        {
            Alumnado persona = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * from aceptasreto.alumnado;");
            List<Alumnado> listaPersonas = new List<Alumnado>();

            foreach (List <Object> fila in aux)
            {
                persona = new Alumnado(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]), Convert.ToInt32(fila[4]));
                
                listaPersonas.Add(persona);
                Console.WriteLine(persona.ToString());
            }

            return listaPersonas;
        }

        public void Insert(Alumnado persona)
        {
            DBBroker.obtenerAgente().modificar("INSERT INTO aceptasreto.alumnado (nombre, apellidos, especialidad, grupo) VALUES ('"
            + persona.Nombre + "', '" + persona.Apellidos + "', "+ persona.Especialidad +", " + persona.Grupo + ");");

        }

        public void Delete(Alumnado persona)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM aceptasreto.alumnado WHERE idAlumnado = " + persona.Id + ";");
        }

        public void Update(Alumnado persona)
        {
            DBBroker.obtenerAgente().modificar("UPDATE aceptasreto.alumnado SET nombre = '" + persona.Nombre + "', apellidos = '"
            + persona.Apellidos + "', especialidad = " + persona.Especialidad + ", grupo = " + persona.Grupo + " WHERE idAlumnado = " + persona.Id + ";");
        }

    }
}
