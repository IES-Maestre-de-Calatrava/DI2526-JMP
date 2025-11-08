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
using System.Collections.ObjectModel;

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
          

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (btnUpdate.IsEnabled == false)
            { 

                // Añadimos la persona con los datos actualizados
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                int edad = int.Parse(txtEdad.Text);
                Persona persona = new Persona(nombre, apellido, edad);

                lstPersonas.Add(persona);
            }
            else
            {
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                int edad = int.Parse(txtEdad.Text);
                Persona persona = new Persona(nombre, apellido, edad);

                lstPersonas.Add(persona);
            }

            start();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            Persona personaSeleccionada = (Persona)dgvPersonas.SelectedItem;
            personaSeleccionada.Nombre = txtNombre.Text;
            personaSeleccionada.Apellidos = txtApellido.Text;
            txtEdad.Text = personaSeleccionada.Edad.ToString();

            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnAdd.Content = "Actualizar datos";


            start();





            /* Esto lo hago guardandome la posicion del objeto seleccionado y eliminandolo para insertar uno nuevo en esa posicion, pero no es necesario
            Persona persona = (Persona)dgvPersonas.SelectedItem;
            List<Persona> lst =(List<Persona>)dgvPersonas.ItemsSource;
            int posicion = lst.IndexOf(persona);
            lst.Remove(persona);
            lst.Insert(posicion, new Persona(txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text)));
            dgvPersonas.Items.Refresh();
            */

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Eliminamos de la lista aquel registro Seleccionado de dataGridView
            lstPersonas.Remove((Persona)dgvPersonas.SelectedItem);
            start();
        }
    }

}