using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Juego
    {
        private Tablero tablero;
        private ColorPieza turnoActual;

        public Juego()
        {
            tablero = new Tablero();
            turnoActual = ColorPieza.Blanco;
        }

        public void Iniciar()
        {
            Console.WriteLine("--- Ajedrez Simplificado (Blanco vs Negro) ---");
            Console.WriteLine("Instrucciones: Introduce [Origen] [Destino] (Ej: E2 E4)");

            while (true)
            {
                tablero.Mostrar();
                Console.ForegroundColor = turnoActual == ColorPieza.Blanco ? ConsoleColor.White : ConsoleColor.Yellow;
                Console.WriteLine($"\nTurno de {turnoActual}.");
                Console.ResetColor();
                Console.Write("Tu jugada: ");

                string[] input = Console.ReadLine().ToUpper().Split(' ');

                if (input.Length != 2)
                {
                    Console.WriteLine("Entrada inválida. Usa el formato [Origen Destino] (Ej: E2 E4).");
                    continue;
                }

                try
                {
                    Posicion origen = Posicion.Parse(input[0]);
                    Posicion destino = Posicion.Parse(input[1]);

                    if (tablero.RealizarMovimiento(origen, destino, turnoActual))
                    {
                        // Si el movimiento fue legal, cambia de turno
                        turnoActual = turnoActual == ColorPieza.Blanco ? ColorPieza.Negro : ColorPieza.Blanco;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error de Posición: {ex.Message}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error: Coordenadas fuera de rango. Revisa tu entrada.");
                }
            }
        }
    }
}
