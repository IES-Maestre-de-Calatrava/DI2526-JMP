using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juego
{
    internal class Tablero
    {

        private const int Tamano = 10;
        // La matriz almacena referencias a los Barcos, o null si es agua.
        public Barco[,] Cuadricula { get; private set; } = new Barco[Tamano, Tamano];
        public bool[,] DisparosRecibidos { get; set; } = new bool[Tamano, Tamano];

        public List<Barco> Barcos { get; private set; } = new List<Barco>();

        public Tablero()
        {
            // Inicializar la cuadrícula (ya se inicializa a 'null' por defecto)
        }

        // Devuelve true si el disparo fue un impacto
        public bool RecibirDisparo(Posicion p)
        {
            if (p.Fila < 0 || p.Fila >= Tamano || p.Columna < 0 || p.Columna >= Tamano)
            {
                Console.WriteLine("Disparo fuera de los límites.");
                return false;
            }

            if (DisparosRecibidos[p.Fila, p.Columna])
            {
                Console.WriteLine("Ya habías disparado a esta posición.");
                return false;
            }

            DisparosRecibidos[p.Fila, p.Columna] = true;

            var barcoImpactado = Cuadricula[p.Fila, p.Columna];

            if (barcoImpactado != null)
            {
                barcoImpactado.RecibirImpacto(p);
                return true; // Impacto
            }
            else
            {
                Console.WriteLine("¡Agua!");
                return false; // Fallo
            }
        }

        public bool TodosHundidos()
        {
            return Barcos.All(b => b.EstaHundido);
        }

        // Intenta colocar un barco. Verifica límites y solapamiento.
        public bool ColocarBarco(Barco barco, Posicion inicio, bool esHorizontal)
        {
            var posiciones = new List<Posicion>();

            for (int i = 0; i < barco.Longitud; i++)
            {
                int f = esHorizontal ? inicio.Fila : inicio.Fila + i;
                int c = esHorizontal ? inicio.Columna + i : inicio.Columna;

                // 1. Verificar límites
                if (f >= Tamano || c >= Tamano || f < 0 || c < 0)
                {
                    return false;
                }

                var p = new Posicion(f, c);

                // 2. Verificar solapamiento
                if (Cuadricula[f, c] != null)
                {
                    return false;
                }

                posiciones.Add(p);
            }

            // Si es válido, colocar el barco en la cuadrícula
            foreach (var p in posiciones)
            {
                Cuadricula[p.Fila, p.Columna] = barco;
            }
            barco.AsignarPosiciones(posiciones);
            Barcos.Add(barco);
            return true;
        }
}
}
