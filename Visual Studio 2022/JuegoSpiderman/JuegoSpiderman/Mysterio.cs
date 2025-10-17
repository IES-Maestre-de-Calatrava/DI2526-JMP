using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Mysterio : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */
        public Mysterio(int posX, int posY) : base(posX, posY) 
        {
            this.Sentidad = 'M';
        }

        /**
         * Accion de la entidad Mysterio
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos)
        {
            tableroEnemigos.tablero[posX, posY] = 'X';
            spiderman.CambiarPosicionAleatorio();

        }

     }
}
