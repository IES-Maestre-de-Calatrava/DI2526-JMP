using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito_Hundir_Barcos
{
    internal class Barco
    {
        public int posX { get; set; }
        public int posY { get; set; } // Esto es como aplicar getter y setter

        public char Sentidad { get; set; }

        public int longitud { get; set; }
        public Barco(int posX, int posY, int longitud)
        {
            this.posX = posX;
            this.posY = posY;
            this.Sentidad = 'B';
            this.longitud = longitud;
        }












    }
}
