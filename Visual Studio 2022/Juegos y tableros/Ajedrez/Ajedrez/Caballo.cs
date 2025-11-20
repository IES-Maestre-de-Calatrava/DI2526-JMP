using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Caballo : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'N' : 'n';
        public override string Nombre => "Caballo";

        public Caballo(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            if (!EsDestinoValido(destino, tablero)) return false;

            int difFila = Math.Abs(destino.Fila - origen.Fila);
            int difColumna = Math.Abs(destino.Columna - origen.Columna);

            // Movimiento en 'L': (2, 1) o (1, 2). El Caballo es la única pieza que salta.
            return (difFila == 2 && difColumna == 1) || (difFila == 1 && difColumna == 2);
        }
    }
}
