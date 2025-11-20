using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Tablero
    {
        private const int TAMAÑO = 8;
        private Pieza[,] celdas;

        public Tablero()
        {
            celdas = new Pieza[TAMAÑO, TAMAÑO];
            InicializarPiezas();
        }

        private void InicializarPiezas()
        {
            // Fila 7 (Fila 1 de Ajedrez - BLANCO)
            celdas[7, 0] = new Torre(ColorPieza.Blanco);
            celdas[7, 1] = new Caballo(ColorPieza.Blanco);
            celdas[7, 2] = new Alfil(ColorPieza.Blanco);
            celdas[7, 3] = new Reina(ColorPieza.Blanco);
            celdas[7, 4] = new Rey(ColorPieza.Blanco);
            celdas[7, 5] = new Alfil(ColorPieza.Blanco);
            celdas[7, 6] = new Caballo(ColorPieza.Blanco);
            celdas[7, 7] = new Torre(ColorPieza.Blanco);

            // Fila 6 (Fila 2 de Ajedrez - PEONES BLANCOS)
            for (int c = 0; c < TAMAÑO; c++)
            {
                celdas[6, c] = new Peon(ColorPieza.Blanco);
            }

            // Fila 1 (Fila 7 de Ajedrez - PEONES NEGROS)
            for (int c = 0; c < TAMAÑO; c++)
            {
                celdas[1, c] = new Peon(ColorPieza.Negro);
            }

            // Fila 0 (Fila 8 de Ajedrez - NEGRO)
            celdas[0, 0] = new Torre(ColorPieza.Negro);
            celdas[0, 1] = new Caballo(ColorPieza.Negro);
            celdas[0, 2] = new Alfil(ColorPieza.Negro);
            celdas[0, 3] = new Reina(ColorPieza.Negro);
            celdas[0, 4] = new Rey(ColorPieza.Negro);
            celdas[0, 5] = new Alfil(ColorPieza.Negro);
            celdas[0, 6] = new Caballo(ColorPieza.Negro);
            celdas[0, 7] = new Torre(ColorPieza.Negro);
        }

        public Pieza ObtenerPieza(Posicion pos)
        {
            return celdas[pos.Fila, pos.Columna];
        }

        public bool RealizarMovimiento(Posicion origen, Posicion destino, ColorPieza turnoActual)
        {
            Pieza pieza = ObtenerPieza(origen);

            if (pieza == null || pieza.Color != turnoActual)
            {
                Console.WriteLine("Error: La casilla de origen está vacía o no es tu pieza.");
                return false;
            }

            if (!pieza.EsMovimientoLegal(origen, destino, celdas))
            {
                Console.WriteLine("Error: Movimiento no legal para esta pieza.");
                return false;
            }

            // Mueve la pieza (Captura si hay pieza enemiga en destino)
            celdas[destino.Fila, destino.Columna] = pieza;
            celdas[origen.Fila, origen.Columna] = null;

            // Lógica especial para el peón
            if (pieza is Peon peon)
            {
                peon.RegistrarMovimiento();
            }

            return true;
        }

        public void Mostrar()
        {
            Console.WriteLine("\n    A  B  C  D  E  F  G  H");
            Console.WriteLine("   -------------------------");
            for (int i = 0; i < TAMAÑO; i++)
            {
                Console.Write($"{8 - i} |");
                for (int j = 0; j < TAMAÑO; j++)
                {
                    char simbolo = celdas[i, j] != null ? celdas[i, j].Simbolo : ' ';
                    // Estilo de color simple para diferenciar Blanco/Negro
                    if (celdas[i, j] != null)
                    {
                        Console.ForegroundColor = celdas[i, j].Color == ColorPieza.Blanco ? ConsoleColor.White : ConsoleColor.Yellow;
                    }
                    Console.Write($" {simbolo} ");
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("   -------------------------");
        }
    }
}
