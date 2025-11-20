using Ejercicio2_Con_interaz.Persistence.manage;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio2_Con_interaz.domain
{
    internal class Partida
    {
        private int id;
        private string nickname;
        private DateTime fecha_juego;
        private string nivel;
        private double puntuacion;

        private List<Partida> listaPartidas;
        public PartidaPersistence pm = new PartidaPersistence();
        string id_;

        public Partida(int id,  string nickname, DateTime fecha_juego, string nivel, double puntuacion)
        {
            this.id = id;
            this.nickname = nickname;
            this.fecha_juego = fecha_juego;
            this.nivel = nivel;
            this.puntuacion = puntuacion;
        }

        public Partida(string nickname, DateTime fecha_juego, string nivel, double puntuacion)
        {
            this.nickname = nickname;
            this.fecha_juego = fecha_juego;
            this.nivel = nivel;
            this.puntuacion = puntuacion;
        }

        public Partida()
        {
            pm = new PartidaPersistence();
        }

        

        public List<Partida> getListaPartidas()
        {
            listaPartidas = PartidaPersistence.LeerPartidas();
            return listaPartidas;
        }



        public int ID { get =>  id; set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public DateTime Fecha_juego { get => fecha_juego; set => fecha_juego = value; }
        public string Nivel { get => nivel; set => nivel = value; }
        public double Puntuacion { get => puntuacion; set => puntuacion = value; }

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

