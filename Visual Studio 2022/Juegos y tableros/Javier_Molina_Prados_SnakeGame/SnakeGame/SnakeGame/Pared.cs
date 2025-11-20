using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Pared : Entidad
    {
        public char Sentidad { get; set; }

        /**
         * Constructor de la clase
         */
        public Pared(int posX, int posY) : base(posX, posY)
        {
            this.Sentidad = 'P';
        }

        /**
         * Accion de la entidad Civil
         * @param spiderman objeto spiderman
         * @param tableroVisible ciudad que ve el jugador
         * @param tableroEnemigos ciudad con enemigos que no se ve
         */
        public override void Accion(Serpiente serpiente, Tablero tablero)
        {
            string ultposicion = serpiente.ultimaPosicion;

            if(ultposicion == "arriba")
            {
                tablero.tablero[posX, posY] = 'P';
                tablero.tablero[posX + 1, posY] = 'S';
                Console.WriteLine("No puedes moverte hacia ahi porque hay una pared");

            }
            if (ultposicion == "abajo")
            {
                tablero.tablero[posX, posY] = 'P';
                tablero.tablero[posX - 1, posY] = 'S';
                Console.WriteLine("No puedes moverte hacia ahi porque hay una pared");
            }
            if(ultposicion == "derecha")
            {
                tablero.tablero[posX, posY] = 'P';
                tablero.tablero[posX, posY - 1] = 'S';
                Console.WriteLine("No puedes moverte hacia ahi porque hay una pared");
            }
            if(ultposicion == "izquierda")
            {
               
                tablero.tablero[posX, posY] = 'P';
                tablero.tablero[posX, posY - 1] = 'S';
                Console.WriteLine("No puedes moverte hacia ahi porque hay una pared");
            }


        }
    }
}
