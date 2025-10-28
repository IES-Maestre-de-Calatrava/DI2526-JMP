using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Spiderman
    {

        private Ciudad tableroVisible;
        private Ciudad tableroEnemigos;
        private Random r = new Random();

        public String ultimaPosicion;
        private int posX;
        private int posY;
        public int saltoPendiente;        
        /**
         * Constructor de Spiderman
         * @param Tablero visible        tablero que el jugador va a ver rellenado con el String pasado
         * @param Tablero Enemigos       tablero que el jugador no ve lleno de enemigos
         * @param int i                  valor de la posX de Spiderman
         * @param int j                  valor de la posY de Spiderman
         */
        public Spiderman(Ciudad visible, Ciudad enemigos, int i, int j)
        {
            tableroVisible = visible;
            tableroEnemigos = enemigos;

            // Spiderman empieza en la posicion que le hayamos colocado
            this.posX = i;
            this.posY = j;
            this.saltoPendiente= 0;
            this.ultimaPosicion = "";
        }
        /**
         * Metodo para colocar a Spiderman
         */
        public void ColocarLetra()
        {
            tableroVisible.tablero[posX, posY] = 'S';
        }


        /**
         * Metodo que mueve a Spiderman a la Derecha
         */
        public void Derecha()
        {
            if ((posY + 1) < tableroVisible.tablero.GetLength(1))
            {
                tableroVisible.tablero[posX, posY] = 'X';
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
        * Metodo que mueve a Spiderman a la Izquierda
        */
        public void Izquierda()
        {
            if ((posY - 1) >= 0)
            {
                tableroVisible.tablero[posX, posY] = 'X';
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
        * Metodo que mueve a Spiderman hacia Abajo
        */
        public void Abajo()
        {
            if ((posX + 1) < tableroVisible.tablero.GetLength(0))
            {
                tableroVisible.tablero[posX, posY] = 'X';
                posX = posX + 1 + saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "abajo";
                ComprobarEvento() ;
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }

        /**
        * Metodo que mueve a Spiderman hacia Abajo
        */
        public void Arriba()
        {
            if ((posX - 1) >= 0)
            {
                tableroVisible.tablero[posX, posY] = 'X';
                posX = posX - 1 - saltoPendiente;
                saltoPendiente = 0;
                ColocarLetra();

                ultimaPosicion = "arriba";
                ComprobarEvento() ;
            }
            else
            {
                Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
            }

        }


        /**
         * Este metodo relaciona la entidad que corresponde en el tablero de los enemigos con la accion que ha de realizar cada entidad
         */ 
        public void ComprobarEvento()
        {
            Entidad entidad = tableroEnemigos.ObtenerEntidad(posX, posY);

            if (entidad != null)
            {
                entidad.Accion(this, tableroVisible, tableroEnemigos);
            }
        }

        /**
         * Método que cambia la posicion de spiderman aleatoriamente
         */ 
        public void CambiarPosicionAleatorio()
        {
            int numeroAleatorioX = r.Next(0, 15);
            int numeroAleatorioY = r.Next(0, 15);

            // Borrar la posición anterior
            tableroVisible.tablero[posX, posY] = 'X';

            // Cambiar las coordenadas
            posX = numeroAleatorioX;
            posY = numeroAleatorioY;

            // Colocar el símbolo de nuevo en la nueva posición
            tableroVisible.tablero[posX, posY] = 'S';
        }

        public void retrocederDosCasillas()
        {
            tableroVisible.tablero[posX, posY] = 'X';

            int maxX = tableroVisible.tablero.GetLength(0) - 1;
            int maxY = tableroVisible.tablero.GetLength(0) - 1;


            switch (ultimaPosicion)
            {
                case "derecha":
                    // Movernos a la izquierda dos casillas sin salirnos
                    posY = Math.Max(0, posY - 2);
                    break;
                case "izquierda":
                    // Movernos a la derecha dos casillas sin salirnos
                    posY = Math.Min(maxY, posY + 2);
                    break;
                case "arriba":
                    // Movernos hacia abajo dos casillas sin salirnos
                    posX = Math.Min(maxY,posX + 2);
                    break;
                case "abajo":
                    // Movernos hacia arriba dos casillas sin salirnos
                    posX = Math.Max(0, posX - 2);
                    break;
                default:
                    Console.WriteLine("No hay dirección anterior registrada.");
                    break;
            }

            // Colocar a Spiderman en la nueva posición
            ColocarLetra();
        }

    }
    
}
