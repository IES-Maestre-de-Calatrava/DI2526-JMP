using EjemploGrid_Rosa.domain;
using ExampleMVCnoDatabase.Persistence;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EjemploGrid_Rosa.persistence
{
    class PersonaPersistence
    {
        private DataTable table { get; set; }
        List<Persona> listaPersonas { get; set; }

        public PersonaPersistence()
        {
            table = new DataTable();
            listaPersonas = new List<Persona>();
        }

        // SIMULACION LECTURA DE BASE DE DATOS

        /*
        public static List<Persona> LeerPersonas()
        { 
            List <Persona> listaPersonas = new List<Persona>();
            listaPersonas.Add(new Persona("Manuel", "Ruiz", 19));
            listaPersonas.Add(new Persona("Ismael", "Navarro", 20));
            listaPersonas.Add(new Persona("Rubén", "Rueda", 21));
            listaPersonas.Add(new Persona("Raúl", "Gijón", 19));
            listaPersonas.Add(new Persona("Gabriel", "Hernández", 21));
            listaPersonas.Add(new Persona("Asier", "Carretero", 21));
            listaPersonas.Add(new Persona("Adrián", "Luque", 19));
            listaPersonas.Add(new Persona("Alejandro", "Garcia", 24));
            return listaPersonas;
        }
        */


        public static List<Persona> LeerPersonas()
        {
            Persona persona = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * from mydb.persona;");
            List<Persona> listaPersonas = new List<Persona>();

            foreach (List <Object> fila in aux)
            {
                persona = new Persona(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]), Convert.ToDateTime(fila[4]), Convert.ToDouble(fila[5]), Convert.ToInt64(fila[6]));
                // para convert.ToLong he tenido que poner Convert.ToInt64, para convertir a int he tenido que poner Convert.ToInt32
                listaPersonas.Add(persona);
                Console.WriteLine(persona.ToString());
            }

            return listaPersonas;
        }

        public void Insert(Persona persona)
        {
            string fechaSQL = persona.Fecha_nacimiento.ToString("yyyy-MM-dd"); // Como en MySQL tengo el campo en DATE, debo formatear la fecha con el ToString, si la tiviese en DATETIME no seria necesario
                                                                               // En la base de datos se añadirá bien sin la fecha, en el dgv no

            string alturaSQL = persona.Altura.ToString(CultureInfo.InvariantCulture);

            DBBroker.obtenerAgente().modificar("INSERT INTO mydb.persona (nombre, apellidos, edad, fecha_nacimiento, altura, telefono) VALUES ('"
            + persona.Nombre + "', '" + persona.Apellidos + "', " + persona.Edad + ", '" + fechaSQL + "', " + alturaSQL + ", " + persona.Telefono + ");");

        }

        public void Delete(Persona persona)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mydb.persona WHERE idpersona = " + persona.Id + ";");
        }

        public void Update(Persona persona)
        {
            string fechaSQL = persona.Fecha_nacimiento.ToString("yyyy-MM-dd"); // Como en MySQL tengo el campo en DATE, debo formatear la fecha con el ToString, si la tuviese en DATETIME no seria necesario
                                                                               // En la base de datos se añadirá bien sin la fecha, en el dgv no 

            string alturaSQL = persona.Altura.ToString(CultureInfo.InvariantCulture);

            DBBroker.obtenerAgente().modificar("UPDATE mydb.persona SET nombre = '" + persona.Nombre + "', apellidos = '"
            + persona.Apellidos + "', edad = " + persona.Edad + ", fecha_nacimiento = '" + fechaSQL +
            "', altura = " + alturaSQL + ", telefono = " + persona.Telefono + " WHERE idpersona = " + persona.Id + ";");
        }

    }
}
