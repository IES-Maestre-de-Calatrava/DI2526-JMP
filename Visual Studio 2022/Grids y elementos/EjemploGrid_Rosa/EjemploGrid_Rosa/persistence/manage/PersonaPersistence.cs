using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EjemploGrid_Rosa.domain;
using ExampleMVCnoDatabase.Persistence;
using Org.BouncyCastle.Crypto.Engines;

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
                persona = new Persona(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]));
                listaPersonas.Add(persona);
                Console.WriteLine(persona.ToString());
            }

            return listaPersonas;
        }

        public void Insert(Persona persona)
        {
            DBBroker.obtenerAgente().modificar("INSERT INTO mydb.persona (nombre, apellidos, edad) VALUES ('"
            + persona.Nombre + "', '" + persona.Apellidos + "', " + persona.Edad + ");");

        }

        public void Delete(Persona persona)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mydb.persona WHERE idpersona = " + persona.Id + ";");
        }

        public void Update(Persona persona)
        {
            DBBroker.obtenerAgente().modificar("UPDATE mydb.persona SET nombre = '" + persona.Nombre + "', apellidos = '"
            + persona.Apellidos + "', edad = " + persona.Edad + " WHERE idpersona = " + persona.Id + ";");
        }

    }
}
