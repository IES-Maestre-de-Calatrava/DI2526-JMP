using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Rey : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'K' : 'k';
        public override string Nombre => "Rey";

        public Rey(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            if (!EsDestinoValido(destino, tablero)) return false;

            int difFila = Math.Abs(destino.Fila - origen.Fila);
            int difColumna = Math.Abs(destino.Columna - origen.Columna);

            // Movimiento Rey: 1 casilla en cualquier dirección
            return difFila <= 1 && difColumna <= 1 && (difFila != 0 || difColumna != 0);
        }
    }
}
