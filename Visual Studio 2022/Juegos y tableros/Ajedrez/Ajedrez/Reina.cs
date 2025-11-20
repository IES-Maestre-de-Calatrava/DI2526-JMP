using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Reina  : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'Q' : 'q';
        public override string Nombre => "Reina";

        public Reina(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            if (!EsDestinoValido(destino, tablero)) return false;

            int difFila = Math.Abs(destino.Fila - origen.Fila);
            int difColumna = Math.Abs(destino.Columna - origen.Columna);

            bool esRecto = difFila == 0 || difColumna == 0;
            bool esDiagonal = difFila == difColumna && difFila != 0;

            // 1. Comprobar si el movimiento es recto o diagonal.
            if (!esRecto && !esDiagonal) return false;

            // 2. Comprobar obstrucción según el tipo de movimiento.
            if (esRecto)
            {
                return NoHayObstruccionRecta(origen, destino, tablero);
            }
            else // esDiagonal
            {
                return NoHayObstruccionDiagonal(origen, destino, tablero);
            }
        }
    }
}
