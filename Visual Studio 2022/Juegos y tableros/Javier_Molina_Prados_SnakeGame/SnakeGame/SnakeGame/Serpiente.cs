using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Serpiente
    {

        private Tablero tablero;
        private Random r = new Random();

        public String ultimaPosicion;
        private int posX;
        private int posY;
        public int saltoPendiente;
        /**
         * Constructor de serpiente
         * @param Tablero visible        tablero que el jugador va a ver rellenado con el String pasado
         * @param int i                  valor de la posX de Spiderman
         * @param int j                  valor de la posY de Spiderman
         */
        public Serpiente(Tablero visible, int i, int j)
        {
            tablero = visible;

            // Serpiente empieza en la posicion que le hayamos colocado
            this.posX = i;
            this.posY = j;
            this.ultimaPosicion = "";
        }
        /**
         * Metodo para colocar a la Serpiente
         */
        public void ColocarLetra()
        {
            tablero.tablero[posX, posY] = 'S';
        }


        /**
         * Metodo que mueve a Serpiente a la Derecha
         */
        public void Derecha()
        {
            if ((posY + 1) < tablero.tablero.GetLength(1))
            {
                tablero.tablero[posX, posY] = 'X';
                posY = posY + 1 + saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "derecha";
                ComprobarEvento();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Serpiente a la Izquierda
        */
        public void Izquierda()
        {
            if ((posY - 1) >= 0)
            {
                tablero.tablero[posX, posY] = 'X';
                posY = posY - 1 - saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "izquierda";
                ComprobarEvento();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Serpiente hacia Abajo
        */
        public void Abajo()
        {
            if ((posX + 1) < tablero.tablero.GetLength(0))
            {
                tablero.tablero[posX, posY] = 'X';
                posX = posX + 1 + saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "abajo";
                ComprobarEvento();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Serpiente hacia Abajo
        */
        public void Arriba()
        {
            if ((posX - 1) >= 0)
            {
                tablero.tablero[posX, posY] = 'X';
                posX = posX - 1 - saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "arriba";
                ComprobarEvento();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }


        /**
         * Este metodo relaciona la entidad que corresponde en el tablero con la accion que ha de realizar cada entidad
         */
        public void ComprobarEvento()
        {
            Entidad entidad = tablero.ObtenerEntidad(posX, posY);

            if (entidad != null)
            {
                entidad.Accion(this, tablero);
            }
        }
    }
}
