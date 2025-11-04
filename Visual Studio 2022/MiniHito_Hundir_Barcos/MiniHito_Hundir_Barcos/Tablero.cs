using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito_Hundir_Barcos
{
    internal class Tablero
    {
    public char [,] tablero;
    public int escala;
    public char casilla;
    private Random r = new Random();


        /**
         * 
         * Constructor del Tablero 
        */
        public Tablero()
    {
            this.escala = 15;
            this.casilla = '.';

            tablero = new char[escala, escala];
    }


    /**
     * Metodo que rellena el tablero con un char dado
     * @param char         el char que va a rellenar el tablero
     */
    public void RellenarTablero()
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = casilla;
            }
        }
    }


    /**
     * Metodo para mostar el Tablero por consola
     */
    public void MostrarTablero()
    {

        Console.WriteLine("Bienvenido a Hundir la flota ");
        
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write(tablero[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
       
    }


        
        /**
         * Metodo que elige si los barcos van en horizontal o en vertical (aleatorio)
         * Retorna true si es horizontal, false si es vertical.
         */
        public Boolean elegirDireccion()
        {
            // r.Next(0, 2) genera 0 (Vertical) o 1 (Horizontal).
            // Si el resultado es 1, es horizontal (true). Si es 0, es vertical (false).
            return r.Next(0, 2) == 1;
        }




        public int PedirLongitudMaxima()
        {
            int maximo = 0; // Almacenará el tamaño máximo final
            int x = 0;      // 0 significa entrada inválida, 1 significa válida

            // Loop para asegurar una entrada válida
            while (x == 0)
            {
                Console.Write("Introduce el tamaño máximo de los barcos (entre 1 y 5): ");

                string res = Console.ReadLine();

                try
                {
                    // Intentamos convertir la cadena usando int.Parse()
                    int valorLeido = int.Parse(res);

                    // Validamos el rango (1 a 5)
                    if (valorLeido >= 1 && valorLeido <= 5)
                    {
                        maximo = valorLeido; // Si es válido, guardamos el valor y
                        x = 1; // ... salimos del bucle.
                    }
                    else
                    {
                        Console.WriteLine("Error: El tamaño de los barcos debe estar entre 1 y 5. Vuelva a intentar.");
                        x = 0; // Se mantiene en el bucle
                    }
                }
                catch (FormatException)
                {
                    // Si el parseo falla (no es un número)
                    Console.WriteLine("Error: Por favor, introduce solo números enteros.");
                    x = 0; // Se mantiene en el bucle
                }
                catch (OverflowException)
                {
                    // Si el número es muy grande
                    Console.WriteLine("Error: El número introducido es demasiado grande.");
                    x = 0;
                }
            }

            // Genera una longitud aleatoria entre 1 y el máximo validado (maximo + 1 porque r.Next es exclusivo del límite superior)
            int longitud = r.Next(1, maximo + 1);

            return longitud;
        }


        /**
        * Genera una longitud aleatoria para un solo barco, usando el máximo establecido.
        */
        public int GenerarLongitudAleatoria(int maximo)
        {
            // Genera una longitud aleatoria entre 1 y el máximo validado 
            // (+ 1 porque r.Next es exclusivo del límite superior)
            return r.Next(1, maximo + 1);
        }


        /**
         * Metodo que comprueba si un barco de una longitud dada cabe 
         * y si no colisiona con otros barcos en una posición y dirección dadas.
         */
        private bool EsPosicionValida(int inicioX, int inicioY, int longitud, bool esHorizontal)
        {
            for (int i = 0; i < longitud; i++)
            {
                int currentX = esHorizontal ? inicioX : inicioX + i;
                int currentY = esHorizontal ? inicioY + i : inicioY;

                // 1. Comprueba si la posición está dentro de los límites del tablero (0 a escala-1)
                if (currentX < 0 || currentX >= escala || currentY < 0 || currentY >= escala)
                {
                    return false; // Está fuera de límites
                }

                // 2. Comprueba si la casilla ya está ocupada por otro barco ('B')
                if (tablero[currentX, currentY] == 'B')
                {
                    return false; // Colisión
                }
            }
            return true;
        }



        public void generarBarco(int longitud)
        {
            int intentosMaximos = 100;
            bool colocado = false;

            // Usamos un bucle for para intentar colocar el barco de forma segura y sin recursión.
            for (int intento = 0; intento < intentosMaximos && !colocado; intento++)
            {
                // 1. Determinar la dirección para el intento actual
                bool esHorizontal = elegirDireccion();

                // 2. Generar límites aleatorios para posX y posY para que el barco quepa
                //    Esto asegura que la posición inicial generada aleatoriamente permite
                //    que el barco de 'longitud' quepa en el tablero.
                int maxStartX = escala - (esHorizontal ? 0 : longitud);
                int maxStartY = escala - (esHorizontal ? longitud : 0);

                int posX = r.Next(0, maxStartX); // Posición inicial en X
                int posY = r.Next(0, maxStartY); // Posición inicial en Y

                // 3. Validar si el barco cabe y no colisiona usando el método auxiliar
                if (EsPosicionValida(posX, posY, longitud, esHorizontal))
                {
                    // 4. Si la posición es válida, colocamos el barco
                    for (int i = 0; i < longitud; i++)
                    {
                        // IMPORTANTE: Colocamos cada segmento SÓLO desplazando 'i' de la posición inicial.
                        // NO se modifica posX ni posY.
                        if (esHorizontal)
                        {
                            tablero[posX, posY + i] = 'B';
                        }
                        else // Vertical
                        {
                            tablero[posX + i, posY] = 'B';
                        }
                    }
                    colocado = true; // Barco colocado, salimos del bucle de intentos.
                }
                // Si la posición no es válida, el bucle simplemente incrementa 'intento' y prueba otra posición.
            }

            if (!colocado)
            {
                Console.WriteLine($"[AVISO] No se pudo colocar un barco de longitud {longitud} después de {intentosMaximos} intentos. (Posiblemente el tablero está muy lleno)");
            }
        }



        /**
         * Metodo que me coloca 5 barcos en el tablero llamando a generarBarco().
         * Ahora cada barco tiene una longitud aleatoria diferente.
         */
        public void ColocarBarco()
        {
            Console.WriteLine("\n--- Fase de colocación de barcos ---");

            // Llama UNA sola vez para obtener el máximo permitido por el usuario
            int maximoPermitido = PedirLongitudMaxima();

            for (int i = 0; i < 5; i++)
            {
                // Llama DENTRO del bucle para obtener una longitud ALEATORIA para CADA barco
                int longitudBarco = GenerarLongitudAleatoria(maximoPermitido);

                Console.WriteLine($"Colocando barco {i + 1} de longitud {longitudBarco}...");
                generarBarco(longitudBarco);
            }
            Console.WriteLine("--- Colocación de barcos finalizada ---");
        }













    }

}
