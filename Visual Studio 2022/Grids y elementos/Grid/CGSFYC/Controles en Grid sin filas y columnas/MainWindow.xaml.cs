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

namespace Controles_en_Grid_sin_filas_y_columnas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Importante esta linea

            // Diapositiva 32
            for (int i = 0; i < 2; i++) // Creamos 3 columnas
            {
                for (int j = 0; j < 3; j++) // Por 2 filas
                {
                    Button button = new Button();
                    button.Width = 100;
                    button.Height = 50;
                    // Sintaxis de la cadena.
                    button.Content = $"Button {i}, {j}";

                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Top;

                    button.Margin = new Thickness(20 + i * 110, 10 + j * 55, 0, 0);
                    // Primero es el margen izquierdo,
                    // El segundo es el marges superior

                    // Nombre de la Grid que defini en el XAML
                    MainGrid.Children.Add(button); 
                }
            }
        }
    }
}