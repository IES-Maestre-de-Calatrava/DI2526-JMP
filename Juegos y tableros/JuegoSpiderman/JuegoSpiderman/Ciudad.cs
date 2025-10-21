using JuegoSpiderman;

class Ciudad
{
    public int vidas = 3;
    public int civiles = 0;
    public char [,] tablero;
    public int escala = 15;
    private Random r = new Random();

    /**
     * 
     * Constructor de la Ciudad 
    */
    public Ciudad()
    {
        tablero = new char[escala, escala];
        this.vidas = 3;
        this.civiles = 0;
    }

    /**
    * Genera un numero aleatorio entre 0, 100
    * @param minimo Número mínimo
    * @param maximo Número máximo
    * @return Número entre minimo y maximo
    */
    public char GenerarEnemigoAleatorio()
    {
        // Los rangos se ponen de acuerdo a la frecuencia en la que van a aparecer los enemigos
        int numeroAleatorio = r.Next(0, 100);
        if (numeroAleatorio < 10)
        {
            return 'C';
        }
        if (numeroAleatorio < 20)
        {
            return 'D';
        }
        if (numeroAleatorio < 30)
        {
            return 'G';
        }
        if (numeroAleatorio < 40)
        {
            return 'M';
        }
        if (numeroAleatorio < 60)
        {
            return 'B';
        }
        else return 'N';
          
    }


    /**
     * Metodo para rellenar el tablero con los enemigos
     */
    public void RellenarTableroEnemigos()
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = GenerarEnemigoAleatorio();

            }

        }
    }

    /**
     * Metodo que rellena el tablero con un string dado
     * @param String cadena         el String que va a rellenar el tablero
     */
    public void RellenarTableroVisible(char casilla)
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
        Console.WriteLine("Civiles: " + civiles);
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

    /**
     * Método que devuelve el tipo de entidad dependiendo del char del teclado
     * @param       int posX posicion de la X en el tablero
     * @param       int posY poscicion de la Y en el tablero
     * @return      el tipo de entidad
     */
    public Entidad ObtenerEntidad(int posX, int posY)
    {
        char simbolo = tablero[posX, posY];
        switch (simbolo)
        {
            case 'B':
                return new Bonus(posX, posY);
            case 'C':
                return new Civil(posX, posY);
            case 'D':
                return new Doctor_Octopus(posX, posY);
            case 'G':
                return new Duende_Verde(posX, posY);
            case 'M':
                return new Mysterio(posX, posY);
            default:
                return null;
        }
    }

}