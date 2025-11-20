using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AceptasElReto.domain;
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
            List<Alumnado> listaPersonas = new List<Alumnado>();
            
            string sql = @"
            SELECT 
                A.idAlumnado, A.nombre, A.apellidos, A.especialidad, A.grupo, 
                G.nombre   -- <--- Campo que trae el texto
            FROM 
                aceptasreto.alumnado A
            INNER JOIN
                aceptasreto.grupo G ON A.grupo = G.idgrupo;
            ";

            List<Object> aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<Object> fila in aux)
            {
                // Creamos el objeto Alumnado, pasando el nuevo string
                persona = new Alumnado(
                    Convert.ToInt32(fila[0]),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    Convert.ToInt32(fila[3]),
                    Convert.ToInt32(fila[4]), // El ID numérico
                    fila[5].ToString()        // El TEXTO del curso
                );

                listaPersonas.Add(persona);
            }
            return listaPersonas;
        }




        // 📁 AlumnadoPersistence.cs (AÑADIR ESTE MÉTODO)

        public static List<Alumnado> LeerAlumnosSinGrupo()
        {
            Alumnado persona = null;
            List<Alumnado> listaPersonas = new List<Alumnado>();

            // Filtramos donde el campo 'grupo' sea 0 (o NULL, dependiendo de la configuración de la BD)
            string sql = @"
            SELECT 
                A.idAlumnado, A.nombre, A.apellidos, A.especialidad, A.grupo, 
                G.nombre   
            FROM 
                aceptasreto.alumnado A
            LEFT JOIN
                aceptasreto.grupo G ON A.grupo = G.idgrupo
            WHERE 
                A.grupo IS NULL OR A.grupo = 0; -- Ajusta el 0 si usas NULL para no asignado
            ";

            List<Object> aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<Object> fila in aux)
            {
                // Usamos el constructor de 6 parámetros
                // El nombre del grupo (fila[5]) será "" o NULL si no está asignado.
                persona = new Alumnado(
                    Convert.ToInt32(fila[0]),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    Convert.ToInt32(fila[3]),
                    Convert.ToInt32(fila[4]),
                    fila[5] != null ? fila[5].ToString() : "" // Maneja el NULL si viene de la BD
                );

                listaPersonas.Add(persona);
            }
            return listaPersonas;
        }


        // 📁 AlumnadoPersistence.cs (AÑADIR ESTE MÉTODO)

        public static List<Alumnado> LeerAlumnosPorGrupo(int idGrupo)
        {
            Alumnado persona = null;
            List<Alumnado> listaPersonas = new List<Alumnado>();

            // Consulta con INNER JOIN y filtro WHERE por el ID del grupo
            string sql = $@"
            SELECT 
                A.idAlumnado, A.nombre, A.apellidos, A.especialidad, A.grupo, 
                G.nombre   
            FROM 
                aceptasreto.alumnado A
            INNER JOIN
                aceptasreto.grupo G ON A.grupo = G.idgrupo
            WHERE 
                A.grupo = {idGrupo};
            ";

            List<Object> aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<Object> fila in aux)
            {
                // Usamos el constructor de 6 parámetros. Aquí fila[5] nunca será NULL.
                persona = new Alumnado(
                    Convert.ToInt32(fila[0]),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    Convert.ToInt32(fila[3]),
                    Convert.ToInt32(fila[4]),
                    fila[5].ToString()
                );

                listaPersonas.Add(persona);
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
