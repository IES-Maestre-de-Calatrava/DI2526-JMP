/**
 * Desarrolla una aplicación de consola en C# que permita a dos jugadores realizar movimientos válidos en un tablero de ajedrez,
 * sin implementar jaque, jaque mate o enroque.
 * Tablero: Una matriz de $8 x8$ que almacena objetos de tipo Pieza (o null si la casilla está vacía).
 * Piezas: Implementa la clase base Pieza y hereda a Peon, Torre, Alfil, Caballo, Reina y Rey.
 * Lógica de Movimiento (Polimorfismo): Cada subclase de Pieza debe implementar 
 * un método EsMovimientoLegal(origen, destino, tablero) que verifique si el movimiento 
 * es válido según sus reglas específicas (ej. el Caballo salta en 'L', el Alfil se mueve en diagonal, etc.).
 * Flujo del Juego:El juego se juega por turnos (Blanco -> Negro).
 * El jugador introduce la posición inicial y final (ej. A2 A4).
 * El programa debe verificar: a) Si la pieza es del color correcto, b) Si el movimiento es legal para ese tipo de pieza,
 * y c) Si el destino es válido (capturar una pieza enemiga o casilla vacía).
 */

using Ajedrez;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Juego juego = new Juego();
        juego.Iniciar();

        Console.WriteLine("\nPresiona cualquier tecla para finalizar...");
        Console.ReadKey();
    }
}