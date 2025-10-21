using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Bonus : Entidad
    {
        public char Sentidad { get; set; }
        /**
         * Constructor de la clase
         */ 
        public Bonus(int posX, int posY) : base(posX, posY) 
        {
            this.Sentidad = 'B';
        }

        /**
         * Accion de la entidad Bonus
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos)
        {
            spiderman.saltoPendiente = 1;
            tableroEnemigos.tablero[posX, posY] = 'X';
        }
    }
}
