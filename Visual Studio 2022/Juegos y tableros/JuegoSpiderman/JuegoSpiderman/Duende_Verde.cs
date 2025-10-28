using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Duende_Verde : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */
        public Duende_Verde(int posX, int posY) : base(posX, posY) 
        {
            this.Sentidad = 'G';
        }

        /**
         * Accion de la entidad Duende Verde
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos)
        {
            tableroVisible.vidas--;
            tableroEnemigos.tablero[posX, posY] = 'X';
        }
    }
}
