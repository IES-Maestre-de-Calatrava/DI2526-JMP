using juego;
using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{



    public static void Main(string[] args)
    {
        Console.WriteLine("🚢 ¡Bienvenido a Hundir la Flota (Modo Práctica)! 🎯");

        // Creamos el tablero del "oponente" (el que intentaremos hundir)
        var tableroOponente = new Tablero();

        // --- 1. Crear Barcos (5, 4, 3, 2) ---
        var barcosAColocar = new List<Barco>
        {
            new Barco("Portaaviones", 5),
            new Barco("Acorazado", 4),
            new Barco("Crucero", 3),
            new Barco("Destructor", 2)
        };

        // --- 2. Configuración: Colocación Aleatoria de Barcos ---
        ConfiguracionAutomatica(tableroOponente, barcosAColocar);

        Console.WriteLine("\n¡Tablero enemigo listo! Comienza la fase de Disparo.");

        // --- 3. Bucle de Juego Interactivo ---
        while (!tableroOponente.TodosHundidos())
        {
            // Muestra la cuadrícula de disparos (lo que hemos acertado/fallado)
            MostrarTableroParaDisparos(tableroOponente);

            // Pide al usuario las coordenadas
            Posicion disparo = PedirDisparoUsuario();

            // Procesar el disparo en el tablero del oponente
            tableroOponente.RecibirDisparo(disparo);
        }

        Console.WriteLine("\n==============================================");
        Console.WriteLine("🎉 ¡Felicidades! ¡Todos los barcos han sido hundidos!");
        Console.WriteLine("==============================================");

        // Muestra el tablero final con todos los impactos
        MostrarTableroParaDisparos(tableroOponente);
    }

    // ------------------------------------------------------------------
    //                         MÉTODOS AUXILIARES
    // ------------------------------------------------------------------

    /// <summary>
    /// Pide al usuario una coordenada de disparo válida (Ej: A1, J10).
    /// </summary>
    private static Posicion PedirDisparoUsuario()
    {
        while (true)
        {
            Console.Write("\nIntroduce coordenada de disparo (Ej: A1 a J10): ");
            string entrada = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(entrada) || entrada.Length < 2 || entrada.Length > 3)
            {
                Console.WriteLine("❌ Error de formato. Intenta de nuevo (Ej: C7).");
                continue;
            }

            char letraColumna = entrada[0];
            string parteFila = entrada.Substring(1);

            int columna, fila;

            // 1. Convertir la letra de la columna (A-J) a índice (0-9)
            if (letraColumna >= 'A' && letraColumna <= 'J')
            {
                columna = letraColumna - 'A';
            }
            else
            {
                Console.WriteLine("❌ Columna no válida. Usa letras de A a J.");
                continue;
            }

            // 2. Convertir la parte numérica de la fila (1-10) a índice (0-9)
            if (int.TryParse(parteFila, out int numeroFila))
            {
                if (numeroFila >= 1 && numeroFila <= 10)
                {
                    fila = numeroFila - 1;
                    return new Posicion(fila, columna);
                }
                else
                {
                    Console.WriteLine("❌ Fila no válida. Usa números de 1 a 10.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("❌ Formato de fila no válido.");
                continue;
            }
        }
    }

    /// <summary>
    /// Coloca los barcos de forma aleatoria en el tablero.
    /// </summary>
    private static void ConfiguracionAutomatica(Tablero tablero, List<Barco> barcos)
    {
        var rnd = new Random();
        foreach (var barco in barcos)
        {
            bool colocado = false;
            while (!colocado)
            {
                // Generar posición inicial y orientación aleatorias
                var inicio = new Posicion(rnd.Next(10), rnd.Next(10));
                bool esHorizontal = rnd.Next(2) == 1;

                colocado = tablero.ColocarBarco(barco, inicio, esHorizontal);
            }
            Console.WriteLine($"- Barco {barco.Nombre} ({barco.Longitud} casillas) colocado.");
        }
    }

    /// <summary>
    /// Muestra el tablero de disparos del jugador (impactos y fallos).
    /// </summary>
    private static void MostrarTableroParaDisparos(Tablero tablero)
    {
        Console.WriteLine("\n     A B C D E F G H I J");
        Console.WriteLine("    ---------------------");
        for (int f = 0; f < 10; f++)
        {
            // Imprimir número de fila (1-10)
            Console.Write($"{f + 1,2} | ");
            for (int c = 0; c < 10; c++)
            {
                char simbolo = '~'; // Agua (no disparado)

                // Nota: La clase Tablero debe tener el array DisparosRecibidos
                if (tablero.DisparosRecibidos[f, c])
                {
                    // Si se disparó
                    if (tablero.Cuadricula[f, c] != null)
                    {
                        simbolo = 'X'; // Impacto
                    }
                    else
                    {
                        simbolo = 'O'; // Fallo
                    }
                }

                Console.Write($"{simbolo} ");
            }
            Console.WriteLine();
        }
    }
}