using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Doctor_Octopus : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */
        public Doctor_Octopus(int posX, int posY) : base(posX, posY)
        {
            this.Sentidad = 'D';
        }

        /**
         * Accion de la entidad Doctor_Octopus
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos)
        {
            tableroVisible.vidas--;
            tableroEnemigos.tablero[posX, posY] = 'X';
            spiderman.retrocederDosCasillas();
        }
    }
}
