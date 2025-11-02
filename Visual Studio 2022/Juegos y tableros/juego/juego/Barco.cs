using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juego
{
    internal class Barco
    {
        public string Nombre { get; private set; }
        public int Longitud { get; private set; }
        public List<Posicion> Posiciones { get; private set; } = new List<Posicion>();
        public int ImpactosRecibidos { get; private set; } = 0;

        public bool EstaHundido => ImpactosRecibidos >= Longitud;

        public Barco(string nombre, int longitud)
        {
            Nombre = nombre;
            Longitud = longitud;
        }

        // Marca que esta posición del barco ha sido impactada
        public bool RecibirImpacto(Posicion impacto)
        {
            // Solo cuenta el impacto si es una posición que ocupa
            if (Posiciones.Any(p => p.Equals(impacto)))
            {
                ImpactosRecibidos++;
                Console.WriteLine($"¡Impacto en el {Nombre}!");
                if (EstaHundido)
                {
                    Console.WriteLine($"¡El {Nombre} ha sido hundido!");
                }
                return true;
            }
            return false; // No fue un impacto válido (aunque esto lo debería verificar el Tablero)
        }

        // Asigna las posiciones al barco. Usado por la clase Tablero.
        public void AsignarPosiciones(List<Posicion> posiciones)
        {
            Posiciones = posiciones;
        }
    }
}
