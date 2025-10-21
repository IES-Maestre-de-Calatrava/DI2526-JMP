using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCoches
{
    internal class Coche
    {
        private int _id;
        private String _marca;
        private String _modelo;
        private int _km;
        private double _precio;


        public Coche(int id, string marca, string modelo, int km, double precio)
        {
            this._id = id;
            this._marca = marca;
            this._modelo = modelo;
            this._km = km;
            this._precio = precio;
        }

        public int id { get => _id; set => _id = value; }
        public string marca { get => _marca; set => _marca = value; }
        public string modelo { get => _modelo; set => _modelo = value; }
        public int km { get => _km; set => _km = value; }
        public double precio { get => _precio; set => _precio = value; }

        public override string ToString()
        {
            return "Marca:" + marca + " ,modelo:" + modelo + " con un precio de " + precio;
        }




    }



    internal class Program
    {
        static void Main(string[] args)
        {
            //creamos el objeto coche
            Coche c = new Coche(1, "BMW", "Z4", 100, 53000);
            //get atributos del coche
            Console.WriteLine(c.marca);
            Console.WriteLine(c.modelo);
            Console.WriteLine(c.km);
            Console.WriteLine(c.precio);
            Console.ReadLine();
            //modifico el precio
            c.precio = 24000;
            //Muestro el coche completo utilizando el toString;
            Console.WriteLine(c.ToString());
            Console.ReadLine();


            List<Coche> listaCoches = new List<Coche>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Introduce los datos del coche {i + 1}:");

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Marca: ");
                string marca = Console.ReadLine();

                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();

                Console.Write("Km: ");
                int km = int.Parse(Console.ReadLine());

                Console.Write("Precio: ");
                double precio = double.Parse(Console.ReadLine());

                Coche coche = new Coche(id, marca, modelo, km, precio);
                listaCoches.Add(coche);

                Console.WriteLine("Coche añadido correctamente.");
            }
            //Recorrer lista
            foreach (Coche coche in listaCoches)
            {
                Console.WriteLine(coche);
            }

            Console.WriteLine("Coche más caro");
            Coche cocheMasCaro = listaCoches.MaxBy(c => c.precio);
            Console.WriteLine(cocheMasCaro);

            Console.WriteLine("Coche más barato");
            Coche cocheMasBarato = listaCoches.MinBy(c => c.precio);
            Console.WriteLine(cocheMasBarato);

            Console.Write("Introduce la marca a buscar: ");
            string marcaBuscada = Console.ReadLine();

            List<Coche> listaFiltrados = new List<Coche>();

            listaFiltrados = listaCoches.Where(c => c.marca.Equals(marcaBuscada, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine($"Coches de la marca {marcaBuscada}:");
            if (listaFiltrados.Any())
            {
                foreach (Coche f in listaFiltrados)
                {
                    Console.WriteLine(f);
                }
            }
            else
            {
                Console.WriteLine(" No se encontraron coches de esa marca.");
            }


            double precioMedio = listaCoches.Average(c => c.precio);
            Console.WriteLine($"Media de precio de la lista de coches: {precioMedio}");

        }
    }
}
