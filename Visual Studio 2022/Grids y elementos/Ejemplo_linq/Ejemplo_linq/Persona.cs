using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_linq
{
    internal class Persona
    {
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }

        public Persona(String nombre, String apellidos, int edad)
        {
            this.Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }


    }
}
