using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public enum ColorPieza { Blanco, Negro }
    internal abstract class Pieza
    {
        public ColorPieza Color { get; private set; }
        public abstract char Simbolo { get; }
        public abstract string Nombre { get; }

        public Pieza(ColorPieza color)
        {
            Color = color;
        }

        public abstract bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero);

        // Lógica común de validación de destino
        protected bool EsDestinoValido(Posicion destino, Pieza[,] tablero)
        {
            Pieza piezaDestino = tablero[destino.Fila, destino.Columna];

            // 1. Si la casilla está vacía, es válido.
            if (piezaDestino == null) return true;

            // 2. Si la casilla tiene una pieza, solo es válido si es del color opuesto (captura).
            return piezaDestino.Color != this.Color;
        }

        // --- MÉTODOS AUXILIARES PARA COMPROBAR OBSTRUCCIÓN (Usados por Torre, Alfil, Reina) ---

        // Verifica si no hay piezas entre origen y destino (horizontal o vertical)
        protected bool NoHayObstruccionRecta(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            int difFila = destino.Fila - origen.Fila;
            int difColumna = destino.Columna - origen.Columna;

            int dirF = Math.Sign(difFila);
            int dirC = Math.Sign(difColumna);

            int r = origen.Fila + dirF;
            int c = origen.Columna + dirC;

            while (r != destino.Fila || c != destino.Columna)
            {
                if (tablero[r, c] != null) return false;
                r += dirF;
                c += dirC;
            }
            return true;
        }

        // Verifica si no hay piezas entre origen y destino (diagonal)
        protected bool NoHayObstruccionDiagonal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            int difFila = destino.Fila - origen.Fila;
            int difColumna = destino.Columna - origen.Columna;

            // Si el movimiento no es diagonal, retorna true (la validación diagonal se hace fuera)
            if (Math.Abs(difFila) != Math.Abs(difColumna)) return true;

            int dirF = Math.Sign(difFila);
            int dirC = Math.Sign(difColumna);

            int r = origen.Fila + dirF;
            int c = origen.Columna + dirC;

            while (r != destino.Fila) // Basta con comprobar una coordenada
            {
                if (tablero[r, c] != null) return false;
                r += dirF;
                c += dirC;
            }
            return true;
        }
    }
}
