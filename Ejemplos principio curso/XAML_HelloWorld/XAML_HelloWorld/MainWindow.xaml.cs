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

namespace XAML_HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCambiarTexto_Click(object sender, RoutedEventArgs e)
        {
            String textoUsuario = txtEntrada.Text;       // Obtenemos el texto del TextBox
            if (!String.IsNullOrEmpty(textoUsuario))
            {
                txtHola.Text = textoUsuario;            // Cambiamos el TextBlock
            }
            else
            {
                txtHola.Text = "¡Hola mundo!";          // si está vacío, volvemos al original 
            }
        }
    }
}