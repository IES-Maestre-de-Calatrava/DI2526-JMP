using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal abstract class Entidad
    {
        // Clase abstracta de la que heredaran nuestros enemigos civiles y bonus
        public int posX { get; set; }
        public int posY { get; set; } // Esto es como aplicar getter y setter

        public char Sentidad {  get; set; }
        public Entidad(int posX, int posY) {
            this.posX = posX;
            this.posY = posY;
        }


        /**
         * Clase base abstracta para ejecutar la acciones de los enemigos
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public abstract void Accion(Spiderman spiderman, Ciudad tableroVisible, Ciudad tableroEnemigos);


    }
}
