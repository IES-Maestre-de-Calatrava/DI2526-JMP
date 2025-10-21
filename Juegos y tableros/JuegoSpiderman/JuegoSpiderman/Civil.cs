using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Civil : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */ 
        public Civil(int posX, int posY) : base(posX, posY)
        {
            this.Sentidad = 'C';
        }

        /**
         * Accion de la entidad Civil
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos)
        {
            tableroVisible.civiles++;
            tableroEnemigos.tablero[posX, posY] = 'X';
        }
    }
}
