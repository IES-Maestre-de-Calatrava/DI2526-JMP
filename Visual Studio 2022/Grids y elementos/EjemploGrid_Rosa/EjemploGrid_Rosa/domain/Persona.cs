using EjemploGrid_Rosa.persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;


namespace EjemploGrid_Rosa.domain
{
    class Persona
    {
        private int id;
        private String nombre;
        private String apellidos;
        private int edad;
        private DateTime fecha_nacimiento;
        private Double altura;
        private long telefono;

        private List<Persona> listaPersonas;
        public PersonaPersistence pm = new PersonaPersistence();
        int Id_;

        public Persona(int id, string nombre, string apellidos, int edad, DateTime fecha_nacimiento, double altura, long telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.fecha_nacimiento = fecha_nacimiento;
            this.altura = altura;
            this.telefono = telefono;
        }

        public Persona(string nombre, string apellidos, int edad, double altura, long telefono)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.altura = altura;
            this.telefono = telefono;
        }


        public Persona(string nombre, string apellidos, int edad, DateTime fecha_nacimiento, double altura, long telefono)
        {

            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.fecha_nacimiento = fecha_nacimiento;
            this.altura = altura;
            this.telefono = telefono;
        }


        public Persona()
        {
            pm = new PersonaPersistence();
        }

        public Persona(int id)
        {
            Id_ = id;
            pm = new PersonaPersistence();
        }

        public List<Persona> getListaPersonas()
        {
            listaPersonas = PersonaPersistence.LeerPersonas();
            return listaPersonas;
        }




        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public double Altura { get => altura; set => altura = value; }
        public long Telefono { get => telefono; set => telefono = value; }

        public void insertar()
        {
            pm.Insert(this);
        }

        public void borrar()
        {
            pm.Delete(this);
        }

        public void actualizar()
        {
            pm.Update(this);
        }

    }
}
