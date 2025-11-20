using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Torre : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'T' : 't';
        public override string Nombre => "Torre";

        public Torre(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            if (!EsDestinoValido(destino, tablero)) return false;

            int difFila = Math.Abs(destino.Fila - origen.Fila);
            int difColumna = Math.Abs(destino.Columna - origen.Columna);

            // 1. Movimiento en línea recta: Fila o Columna debe ser 0.
            if (difFila != 0 && difColumna != 0) return false;

            // 2. Comprobar obstrucción.
            return NoHayObstruccionRecta(origen, destino, tablero);
        }
    }
}
