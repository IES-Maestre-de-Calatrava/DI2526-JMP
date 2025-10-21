using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class App
    {
        public static void Main(String[] args)
        {
            // Creo los tableros 
            Ciudad tableroVisible = new Ciudad();
            Ciudad tableroEnemigos = new Ciudad();
            int posX = 0;
            int posY = 0;

            // relleno el tablero visible con "X"
            tableroVisible.RellenarTableroVisible('#');

            // relleno el tablero NO visible con las letras de los enemigos aleatorios
            tableroEnemigos.RellenarTableroEnemigos();


            
            // creo el movimiento y coloco mi "S"
            Spiderman mover = new Spiderman(tableroVisible, tableroEnemigos, posX, posY);
            mover.ColocarLetra();


            // Bucle con la logica de las acciones, uso ConsoleKeyInfo para moverme con las teclas
            Boolean salir = false;
            Boolean vivo;
            while (salir == false)
            {
                Console.Clear();
                tableroVisible.MostrarTablero();

                Console.WriteLine("Intenta rescatar a 6 Civiles sin morir");
                Console.WriteLine("Entidades:");
                Console.WriteLine("Doctor Octopus: ¡Ten ciudado con él, resta 1 vida y retrocedes 2 casillas!");
                Console.WriteLine("Duende Verde: ¡Ten ciudado con él, resta 1 vida!");
                Console.WriteLine("Mysterio: ¡Ten ciudado con él, cambia tu posición aleatoriamente!");
                Console.WriteLine("Bonus: ¡Estas de suerte, el proximo salto es doble!");
                Console.WriteLine("Civil: ¡Intenta salvarlos!");




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

                // si me quedo sin vidas acaba
                if (!tableroVisible.ComprobarVidas())
                {
                    Console.Clear();
                    tableroVisible.MostrarTablero();
                    Console.WriteLine("TE QUEDASTE SIN VIDAS, GAME OVER!");
                    salir = true;
                }

                // si tengo vidas y he salvado a 6 civiles
                if (tableroVisible.ComprobarVidas() == true && tableroVisible.civiles == 6)
                {
                    Console.Clear();
                    tableroVisible.MostrarTablero();
                    Console.WriteLine("FELICIDADES HAS GANADO!!");
                    salir = true;
                }
            }
            
        }
    }
}
