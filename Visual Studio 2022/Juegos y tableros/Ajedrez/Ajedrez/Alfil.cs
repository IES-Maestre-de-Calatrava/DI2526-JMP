using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Alfil : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'B' : 'b';
        public override string Nombre => "Alfil";

        public Alfil(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            if (!EsDestinoValido(destino, tablero)) return false;

            int difFila = destino.Fila - origen.Fila;
            int difColumna = destino.Columna - origen.Columna;

            // 1. Movimiento en diagonal: |ΔF| debe ser igual a |ΔC|.
            if (Math.Abs(difFila) != Math.Abs(difColumna) || difFila == 0) return false;

            // 2. Comprobar obstrucción diagonal.
            return NoHayObstruccionDiagonal(origen, destino, tablero);
        }
    }
}
