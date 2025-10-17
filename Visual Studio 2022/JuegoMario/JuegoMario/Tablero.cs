

class Tablero
{
    public int vidas = 3;
    public int pocimas = 0;
    public String[,] tablero;

    /**
     * 
     * Constructor del tablero pasandole filas y columnas
    */
    public Tablero(int filas, int columnas)
    {
        tablero = new String[filas, columnas];
    }

    /**
    * Genera un numero aleatorio entre dos numeros.
    * Entre el minimo y el maximo incluidos
    * @param minimo Número mínimo
    * @param maximo Número máximo
    * @return Número entre minimo y maximo
    */
    public int GenerarNumAleatorio(int minimo, int maximo)
    {
        Random rnd = new Random();
        return rnd.Next(minimo, maximo + 1);
    }

    
    /**
     * Metodo para rellenar el tablero con numeros aleatorios entre 0 y 2
     */
    public void RellenarTableroAleatorio()
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = GenerarNumAleatorio(0, 2).ToString();

            }

        }
    }

    /**
     * Metodo que rellena el tablero con un string dado
     * @param String cadena         el String que va a rellenar el tablero
     */ 
    public void RellenarTableroX(String cadena)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = cadena;
            }
        }
    }


    /**
     * Metodo para mostar el Tablero por consola
     */ 
    public void MostrarTablero()
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write(tablero[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Vidas: " + vidas);
        Console.WriteLine("Pocimas: " + pocimas + " ml");
        Console.WriteLine("-------------------------");
    }

    /**
     * Metodo que comprueba si tenemos vidas o no 
     * @return      true o false
     */
    public Boolean ComprobarVidas()
    {
        return vidas > 0;
    }

}