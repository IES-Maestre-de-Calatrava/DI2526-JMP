using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito_Hundir_Barcos
{
    internal class App
    {
        public static void Main(String[] args)
        {
            Tablero tablero = new Tablero();

           
            
            tablero.RellenarTablero();

            tablero.ColocarBarco();

            tablero.MostrarTablero();

            Console.WriteLine();
            


        }

    }
}
