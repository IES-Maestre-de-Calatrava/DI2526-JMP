using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Posicion
    {
        public int Fila { get; private set; } // 0-7 (0 es la fila 8 del ajedrez, 7 es la fila 1)
        public int Columna { get; private set; } // 0-7 (0 es la columna A, 7 es la columna H)

        public Posicion(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }

        // Método Estático para convertir notación de ajedrez (ej. "A1") a coordenadas de matriz (ej. (7, 0))
        public static Posicion Parse(string notacion)
        {
            if (string.IsNullOrEmpty(notacion) || notacion.Length != 2)
                throw new ArgumentException("Formato de posición inválido (Ej: A1, E4).");

            char columnaChar = char.ToUpper(notacion[0]);
            char filaChar = notacion[1];

            // Columna: 'A' -> 0, 'B' -> 1, ...
            int col = columnaChar - 'A';

            // Fila: '1' -> 7, '2' -> 6, ...
            if (!int.TryParse(filaChar.ToString(), out int filaAjedrez) || filaAjedrez < 1 || filaAjedrez > 8)
                throw new ArgumentException("Fila inválida (de 1 a 8).");

            int fila = 8 - filaAjedrez; // 8-1=7, 8-8=0 (Invierte para coordenadas de matriz)

            if (col < 0 || col > 7)
                throw new ArgumentException("Columna inválida (de A a H).");

            return new Posicion(fila, col);
        }
    }
}
