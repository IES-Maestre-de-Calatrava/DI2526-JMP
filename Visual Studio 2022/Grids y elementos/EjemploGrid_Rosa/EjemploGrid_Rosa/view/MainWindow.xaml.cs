using EjemploGrid_Rosa.domain;
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
using EjemploGrid_Rosa.domain;

namespace EjemploGrid_Rosa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Persona> lstPersonas;
        private Persona persona;
        public MainWindow()
        {
            InitializeComponent();
            lstPersonas = new List<Persona>();

            // Descargamos los datos de la base de datos (simulada)
            //1º Intstanciamos la Persona y la inicializamos, para ello hemos creado un constructor vacio
            Persona persona = new Persona();
            
            // 2º Llamamos al metodo getPersonas, de la clase Persona< que a su vez llama al metodo leerPersonas de la clase PersonasPersistence
            lstPersonas = persona.getPersonas();


            // 3º Sincronizamos la lista con el DataGridView
            dgvPersonas.ItemsSource = lstPersonas;


        }

        public void start()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";    
            txtEdad.Text = "";
        }



        private void dgvPersonas_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            // txtNombre.Text = "Ha cambiado la seleccion";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int edad = int.Parse(txtEdad.Text);
            Persona persona = new Persona(nombre, apellido, edad);

            lstPersonas.Add(persona);
            dgvPersonas.Items.Refresh();

            start();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Persona personaSeleccionada = (Persona)dgvPersonas.SelectedItem;
            personaSeleccionada.Nombre = txtNombre.Text;
            personaSeleccionada.Apellidos = txtApellido.Text;
            personaSeleccionada.Edad = int.Parse(txtEdad.Text);

            lstPersonas.Remove((Persona)dgvPersonas.SelectedItem);
            lstPersonas.Add(personaSeleccionada);
            dgvPersonas.Items.Refresh();

            start();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Eliminamos de la lista aquel registro Seleccionado de dataGridView
            lstPersonas.Remove((Persona)dgvPersonas.SelectedItem);
            dgvPersonas.Items.Refresh();
            start();
        }
    }

}