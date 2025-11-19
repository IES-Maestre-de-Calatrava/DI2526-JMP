using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;


namespace AceptasElReto
{
    class Alumnado
    {
        private int idAlumnado;
        private String nombre;
        private String apellidos;
        private int especialidad;
        private int grupo;

        private List<Alumnado> listaPersonas;
        public AlumnadoPersistence pm = new AlumnadoPersistence();
        int Id_;

        public Alumnado(int id, string nombre, string apellidos, int especialidad, int grupo)
        {
            this.idAlumnado = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.especialidad = especialidad;
            this.grupo = grupo;
        }

        public Alumnado(string nombre, string apellidos, int especialidad, int curso)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.especialidad = 1;
            this.grupo = curso;
        }


        public Alumnado()
        {
            pm = new AlumnadoPersistence();
        }

        public Alumnado(int id)
        {
            Id_ = id;
            pm = new AlumnadoPersistence();
        }

        public List<Alumnado> getListaPersonas()
        {
            listaPersonas = AlumnadoPersistence.LeerPersonas();
            return listaPersonas;
        }




        public int Id { get => idAlumnado; set => idAlumnado = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public int Especialidad { get => especialidad; set => especialidad = value; }
        public int Grupo { get => grupo; set => grupo = value; }

       

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
