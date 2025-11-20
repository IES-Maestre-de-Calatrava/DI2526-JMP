using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Tablero
    {
        public int ratones = 0;
        public int contadorRatones = 0;
        public char [,] tablero;
        public int escala = 15;
        private Random r = new Random();

        /**
         * 
         * Constructor de la Ciudad 
        */
        public Tablero()
        {
            tablero = new char[escala, escala];
            this.ratones = 0;
        }

        /**
        * Genera un numero aleatorio entre 0, 100
        * @param minimo Número mínimo
        * @param maximo Número máximo
        * @return Número entre minimo y maximo
        */
        public char GenerarEnemigoAleatorio()
        {
            // Los rangos se ponen de acuerdo a la frecuencia en la que van a aparecer los enemigos
            int numeroAleatorio = r.Next(0, 100);
            if (numeroAleatorio < 5)
            {
                return 'R';
                contadorRatones++;
            }
            if (numeroAleatorio < 10)
            {
                return 'P';
            }
            else return '.';
          
        }


        /**
         * Metodo para rellenar el tablero con los enemigos
         */
        public void RellenarTablero()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = GenerarEnemigoAleatorio();

                }

            }
        }

        /**
         * Metodo para mostar el Tablero por consola
         */
        public void MostrarTablero()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Ratones: " + this.ratones);
            Console.WriteLine("-------------------------");

        }
        

        /**
         * Método que devuelve el tipo de entidad dependiendo del char del teclado
         * @param       int posX posicion de la X en el tablero
         * @param       int posY poscicion de la Y en el tablero
         * @return      el tipo de entidad
         */
        public Entidad ObtenerEntidad(int posX, int posY)
        {
            char simbolo = tablero[posX, posY];
            switch (simbolo)
            {
                case 'R':
                    return new Raton(posX, posY);
                case 'P':
                    return new Pared(posX, posY);
                default:
                    return null;
            }
        }


        public Boolean ComprobarRatones()
        {
            Boolean finJuego = false;
            if(this.ratones == this.contadorRatones)
            {
                finJuego = true;
            }

            return finJuego;
        }


    }
}
