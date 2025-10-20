using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controles_a_UniformGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++){
                for(int j = 0; j < 3; j++)
                {
                    Button boton = new Button();
                    boton.Width = 50;
                    boton.Height = 40;

                    // Esta es la logica de la ultima fila, va checkeando las columnas (j) para poner los simbolos
                    if(i == 3)
                    {
                        switch (j)
                        {
                            case 0:
                                boton.Content = "=";
                                break;
                            case 1:
                                boton.Content = "0";
                                break;
                            case 2:
                                boton.Content = "C";
                                break;

                        }
                    }
                    else
                    {
                        // formula que pone el 7,8,9  4,5,6  1,2,3
                        boton.Content = (9 - 3 * i) - (2 - j);
                        boton.HorizontalAlignment = HorizontalAlignment.Center;
                        boton.VerticalAlignment = VerticalAlignment.Center;
                    }

                    contenedor.Children.Add(boton);
                }
            }
        }
    }
}