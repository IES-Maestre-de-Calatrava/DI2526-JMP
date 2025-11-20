using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Peon : Pieza
    {
        public override char Simbolo => Color == ColorPieza.Blanco ? 'P' : 'p';
        public override string Nombre => "Peón";

        // Propiedad para el movimiento inicial
        private bool HaMovido { get; set; } = false;

        public Peon(ColorPieza color) : base(color) { }

        public override bool EsMovimientoLegal(Posicion origen, Posicion destino, Pieza[,] tablero)
        {
            int difFila = destino.Fila - origen.Fila;
            int difColumna = Math.Abs(destino.Columna - origen.Columna);
            int direccion = Color == ColorPieza.Blanco ? -1 : 1; // Blanco se mueve hacia arriba (-1), Negro hacia abajo (+1)

            Pieza piezaDestino = tablero[destino.Fila, destino.Columna];

            // 1. Movimiento de Captura (Diagonal)
            if (difColumna == 1)
            {
                // Debe ser un movimiento de 1 casilla en diagonal hacia adelante y capturar.
                if (difFila == direccion && piezaDestino != null && piezaDestino.Color != Color)
                {
                    return true;
                }
                return false;
            }

            // 2. Movimiento Hacia Adelante (Recto)
            if (difColumna == 0)
            {
                // El destino debe estar vacío
                if (piezaDestino != null) return false;

                // Movimiento normal de 1 casilla
                if (difFila == direccion)
                {
                    return true;
                }

                // Movimiento inicial de 2 casillas
                if (!HaMovido && difFila == direccion * 2)
                {
                    // Comprobar que la casilla intermedia (1 casilla adelante) esté vacía
                    int filaIntermedia = origen.Fila + direccion;
                    if (tablero[filaIntermedia, origen.Columna] == null)
                    {
                        return true;
                    }
                }
                return false;
            }

            // Cualquier otro movimiento es inválido para el peón
            return false;
        }

        // Método auxiliar para ser llamado por Tablero.RealizarMovimiento
        public void RegistrarMovimiento()
        {
            HaMovido = true;
        }
    }

}
