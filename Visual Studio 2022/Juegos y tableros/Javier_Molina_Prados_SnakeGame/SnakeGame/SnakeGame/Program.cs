using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class App
    {
        public static void Main(String[] args)
        {
            // Creo el tablero 
            Tablero tablero = new Tablero();
            int posX = 0;
            int posY = 0;

            // relleno el tablero 
            tablero.RellenarTablero();

            // creo el movimiento y coloco mi "S"
            Serpiente mover = new Serpiente(tablero, posX, posY);
            mover.ColocarLetra();


            // Bucle con la logica de las acciones, uso ConsoleKeyInfo para moverme con las teclas
            Boolean salir = false;
            Boolean vivo;
            while (salir == false)
            {
                Console.Clear();
                tablero.MostrarTablero();

                Console.WriteLine("Intenta comerte a todos los ratones");
                Console.WriteLine("Entidades:");
                Console.WriteLine("Raton: ¡Intenta comertelos a todos, dan puntos!");
                Console.WriteLine("Pared: ¡Ten ciudado con ella, no puedes atraversarlas");

                Console.WriteLine("Z. Salir");

                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.Z:
                        salir = true;
                        break;
                    case ConsoleKey.RightArrow:
                        mover.Derecha();
                        break;
                    case ConsoleKey.LeftArrow:
                        mover.Izquierda();
                        break;
                    case ConsoleKey.DownArrow:
                        mover.Abajo();
                        break;
                    case ConsoleKey.UpArrow:
                        mover.Arriba();
                        break;

                }

                
                
                /* te comento esto porque el tablero no me coge las acciones de las entidades no se porque, entoces el numero de ratones y su contador como al inicializar
                 * estan a cero, y no se porque no se guarda el numero al generarlos, se sale inmediatamente
                 * 
                // si me he comido a todos los ratones
                if (tablero.ComprobarRatones())
                {
                    Console.Clear();
                    tablero.MostrarTablero();
                    Console.WriteLine("You won! There are no more mice left to eat");
                    salir = true;
                }
                */
            }

        }
    }
}
