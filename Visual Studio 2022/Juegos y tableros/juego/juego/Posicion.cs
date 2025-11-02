using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juego
{
    partial class Posicion
    {
        public int Fila { get; set; }
        public int Columna { get; set; }

        public Posicion(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }

        // Permite comparar dos posiciones fácilmente
        public override bool Equals(object obj)
        {
            if (obj is Posicion otra)
            {
                return Fila == otra.Fila && Columna == otra.Columna;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fila, Columna);
        }
    }
}
