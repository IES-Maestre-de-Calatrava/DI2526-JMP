using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EjemploGrid_Rosa.domain;

namespace EjemploGrid_Rosa.persistence
{
    class PersonaPersistence
    {
        private DataTable table { get; set; } // REVISAR A POSTERIORI
        public PersonaPersistence()
        {
            table = new DataTable();
        }

        // SIMULACION LECTURA DE BASE DE DATOS

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
    }
}
