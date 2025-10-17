using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoMario
{
    internal class Movimiento
    {
        private Tablero tableroX;
        private Tablero tableroNumeros;

        private int posX;
        private int posY;
        private int s1;
        private int s2;

       /**
        * Constructor del movimiento
        * @param Tablero visible        tablero que el jugador va a ver rellenado con el String pasado
        * @param Tablero numero         tablero con numeros aleatorios entre 0 y 2
        * @param int i                  valor de la posX de la "M" de Mario
        * @param int j                  valor de la posY de la "M" de Mario
        * @param int s1                 valor de la pos X de la Salida "S"
        * @param int s1                 valor de la pos Y de la Salida "S"
        */
        public Movimiento(Tablero visible, Tablero numeros, int i, int j, int s1, int s2)
        {
            tableroX = visible;
            tableroNumeros = numeros;

            // Mario empieza en la posicion que le hayamos colocado
            this.posX = i;
            this.posY = j;
            this.s1 = s1;
            this.s2 = s2;
        }
        /**
         * Metodo para colocar la Letra "M" de Mario
         */
        public void ColocarLetra()
        {
            tableroX.tablero[posX, posY] = "M";
        }

        /**
        * Metodo para colocar la Letra "S" de Salida
        */
        public void ColocarSalida()
        {
            tableroX.tablero[s1, s2] = "S";
        }

        /**
         * Metodo que mueve a Mario a la Derecha
         */
        public void Derecha()
        {
            if ((posY + 1) < tableroX.tablero.GetLength(1)){
                tableroX.tablero[posX, posY] = "X";
                posY++;
                ComprobarEstado();
                ColocarLetra();
                ColocarSalida();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Mario a la Izquierda
        */
        public void Izquierda()
        {
            if ((posY - 1) >= 0){            
                tableroX.tablero[posX, posY] = "X";
                posY--;
                ComprobarEstado();
                ColocarLetra();
                ColocarSalida();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Mario hacia Abajo
        */
        public void Abajo()
        {
            if ((posX + 1) < tableroX.tablero.GetLength(0))
            {
                tableroX.tablero[posX, posY] = "X";
                posX++;
                ComprobarEstado();
                ColocarLetra();
                ColocarSalida();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

       /**
       * Metodo que mueve a Mario hacia Abajo
       */
        public void Arriba()
        {
            if ((posX - 1) >= 0)
            {
                tableroX.tablero[posX, posY] = "X";
                posX--;
                ComprobarEstado();
                ColocarLetra();
                ColocarSalida();
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
         * Este metodo comprueba que pasa a las vidas y pocimas dependiendo de la posicion y de los numeros del tablero numeros
         */ 
        public void ComprobarEstado()
        {
            Boolean vivo;
            switch (tableroNumeros.tablero[posX, posY])
            {
                case "0":
                    tableroX.vidas--;
                    break;
                case "1":
                    tableroX.vidas++;
                    break;
                case "2":
                    tableroX.pocimas = tableroX.pocimas + 2;
                    break;
            }

        }

        /**
         * Metodo que devuelve true si Mario se encuentra en la Salida
         */
        public bool HaLlegadoMeta(int s1, int s2)
        {
            return posX == s1 && posY == s2;
        }
    }
}
