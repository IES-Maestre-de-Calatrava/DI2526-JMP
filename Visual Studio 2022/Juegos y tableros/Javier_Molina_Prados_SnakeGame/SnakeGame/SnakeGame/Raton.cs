using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Raton : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */
        public Raton(int posX, int posY) : base(posX, posY){
         
            this.Sentidad = 'C';
        }

        /**
         * Accion de la entidad Civil
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Serpiente serpiente, Tablero tablero)
        {
            tablero.ratones++;
            tablero.tablero[posX, posY] = 'X';
        }
    }
}
