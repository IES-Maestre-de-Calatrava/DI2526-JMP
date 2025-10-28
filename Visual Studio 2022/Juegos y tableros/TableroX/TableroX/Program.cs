using System.Security.Cryptography.X509Certificates;

class Utilites{

    public static void RellenarTablero(String[,] tablero, String cadena)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = cadena;
            }
        }
        Console.WriteLine();
    }

    public static void MostrarTablero(String[,] tablero)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {      // con el GetLength(0), cogemos la longitud de las columnas, y con 1 la de las filas
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write(tablero[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    public static void ColocarLetra(String[,] tablero)
    {
        tablero[0, 0] = "0";
        Console.WriteLine();
    }
   

    public static void Derecha(String[,] tablero)
    {
        for(int i = 0; i < tablero.GetLength(0); i++)
        {
            for( int j = 0;j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j] == "0")
                {
                    if ((j + 1) < tablero.GetLength(1))
                    {
                        tablero[i, j] = "X";
                        tablero[i, j + 1] = "0";
                        i = 4;
                        j = 4;
                    }
                    else
                    {
                        Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
                    }
                }
                
            }
        }
        Console.WriteLine() ;
    }

    public static void Izquierda(String[,] tablero)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j] == "0")
                {
                    if ((j - 1) >= 0) 
                    {
                        tablero[i, j] = "X";
                        tablero[i, j - 1] = "0";
                        i = 4;
                        j = 4;
                    }
                    else
                    {
                        Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
                    }
                }

            }
        }
        Console.WriteLine();
    }


    public static void Abajo(String[,] tablero)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j] == "0")
                {
                    if ((i + 1) < tablero.GetLength(0))
                    {
                        tablero[i, j] = "X";
                        tablero[i + 1, j] = "0";
                        i = 4;
                        j = 4;
                    }
                    else
                    {
                        Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
                    }
                }

            }
        }
        Console.WriteLine();
    }


    public static void Arriba(String[,] tablero)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j] == "0")
                {
                    if ((i - 1) >= 0)
                    {
                        tablero[i, j] = "X";
                        tablero[i - 1, j] = "0";
                        i = 4;
                        j = 4;
                    }
                    else
                    {
                        Console.WriteLine("NO PUEDES SALIRTE DEL TABLERO");
                    }
                }

            }
        }
        Console.WriteLine();
    }





    public static void Main(String[] args)
    {
        String [,] tablero = new string[4, 4];
        RellenarTablero(tablero, "X");
        MostrarTablero(tablero);
        Console.WriteLine();
        ColocarLetra(tablero);
        MostrarTablero(tablero);


        Boolean salir = true;
        while (salir == true) {
            Console.WriteLine("Elige una de estas 4 opciones");
            Console.WriteLine("1. Derecha");
            Console.WriteLine("2. Izquierda");
            Console.WriteLine("3. Abajo");
            Console.WriteLine("4. Arriba");
            Console.WriteLine("0. Salir");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 0: salir = false;
                    break;
                case 1: Derecha(tablero);
                    break;
                case 2: Izquierda(tablero);
                    break;     
                case 3: Abajo(tablero);
                    break;     
                case 4: Arriba(tablero);
                    break;
                        
            }
            MostrarTablero(tablero);

        }

        /*
        // Derecha
        Derecha(tablero);
        MostrarTablero(tablero);
        Derecha(tablero);
        MostrarTablero(tablero); 
        Derecha(tablero);
        MostrarTablero(tablero);

        // me salgo 
        Derecha(tablero);
        MostrarTablero(tablero);

        // izquierda
        Izquierda(tablero);
        MostrarTablero(tablero);
        Izquierda(tablero);
        MostrarTablero(tablero); 
        Izquierda(tablero);
        MostrarTablero(tablero); 

        // me salgo
        Izquierda(tablero);
        MostrarTablero(tablero);


        // abajo
        Abajo(tablero);
        MostrarTablero(tablero);
        Abajo(tablero);
        MostrarTablero(tablero);
        Abajo(tablero);
        MostrarTablero(tablero);

        // me salgo
        Abajo(tablero);
        MostrarTablero(tablero);

        // arriba
        Arriba(tablero);
        MostrarTablero(tablero);
        Arriba(tablero);
        MostrarTablero(tablero);
        Arriba(tablero);
        MostrarTablero(tablero);

        // me salgo
        Arriba(tablero);
        MostrarTablero(tablero);
        */






    }
}