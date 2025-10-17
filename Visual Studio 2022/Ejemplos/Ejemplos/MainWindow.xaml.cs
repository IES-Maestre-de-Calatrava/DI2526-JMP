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

namespace Ejemplos
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

        private void txtOtroDoc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string edad = txtEdad.Text;
            string sexo = rbMasculino.IsChecked == true ? "Masculino" :
                          rbFemenino.IsChecked == true ? "Femenino" : "No especificado";

            string curso = (cbCurso.SelectedItem as ComboBoxItem) ? .Content.ToString() ?? "No seleccionado";
            string horario = (cbHorario.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "No seleccionado";
            string ti = chkTI.IsChecked == true ? "Si" : "No";
            string otroDoc = chkOtroDoc.IsChecked == true ? txtOtroDoc.Text : "Ninguno";

            string mensaje = $"Nombre: {nombre}\nEdad: {edad}\nSexo: {sexo}\nCurso: {curso}\nHorario: {horario}\nT.I: {ti}\nOtro Documento: {otroDoc}";

            MessageBox.Show(mensaje, "Datos del alumno", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}