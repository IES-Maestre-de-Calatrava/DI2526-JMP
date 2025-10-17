using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoMario
{
    internal class App
    {
        public static void Main(String[] args)
        {
            // Creo los tableros 
            Tablero tableroX = new Tablero(8, 8);
            Tablero tableroNumeros = new Tablero(8, 8);
            int posX = 2;
            int posY = 4;
            int s1 = 6;
            int s2 = 6;

            // relleno el tablero visible con "X"
            tableroX.RellenarTableroX("X");

            // relleno el tablero NO visible con numeros aleatorios
            tableroNumeros.RellenarTableroAleatorio();
    
            // creo el movimiento y coloco mi "M" y mi "S"
            Movimiento mover = new Movimiento(tableroX, tableroNumeros, posX, posY, s1, s2);
            mover.ColocarLetra();
            mover.ColocarSalida();



            // Bucle con la logica de las acciones, uso ConsoleKeyInfo para moverme con las teclas
            Boolean salir = false;
            Boolean vivo;
            while (salir == false)
            {
                Console.Clear();
                tableroX.MostrarTablero();

                Console.WriteLine("Intenta llegar a la posición ["+s1+", "+s2+"] vivo y con 6 pociones o mas!!");
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
                if (!tableroX.ComprobarVidas())
                {
                    Console.Clear();
                    tableroX.MostrarTablero();
                    Console.WriteLine("TE QUEDASTE SIN VIDAS, GAME OVER!");
                    salir = true;
                }

                // si estoy en la casilla de salida con vidas y con las pocimas requeridas salgo
                if (tableroX.ComprobarVidas() == true && tableroX.pocimas >= 6 && mover.HaLlegadoMeta(s1,s2))
                {
                    Console.Clear();
                    tableroX.MostrarTablero();
                    Console.WriteLine("FELICIDADES HAS GANADO!!");
                    salir = true;
                }
            }
            
        }
    }
}
