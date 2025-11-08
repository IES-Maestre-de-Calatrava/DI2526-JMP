using EjemploGrid_Rosa.persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace EjemploGrid_Rosa.domain
{
    class Persona
    {
        private String nombre;
        private String apellidos;
        private int edad;
        private List<Persona> listaPersonas;

        public Persona(string nombre, string apellidos, int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

        // CREAMOS UN CONSTRUCTOR VACIO PARA PODER LLAMAR A LA LISTA DE PERSISTENCIA
        public Persona()
        {
            listaPersonas = new List<Persona>();
        }

        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }

       
        // NOS DEVUELVE LA LISTA DE PERSONAS DESDE LA BASE DE DATOS (SIMULACION)
        public List<Persona> getPersonas()
        {
            listaPersonas = PersonaPersistence.LeerPersonas();
            return listaPersonas;
        }
    }
}
