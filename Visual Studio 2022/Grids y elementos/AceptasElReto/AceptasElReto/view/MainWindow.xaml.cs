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

namespace AceptasElReto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Alumnado> lstPersonas;
        private Alumnado persona;
        public MainWindow()
        {
            InitializeComponent();
            lstPersonas = new List<Alumnado>();

            // Descargar los registros de la base de datos
            persona = new Alumnado();
            cargarPersonas();


            /*
            // Descargamos los datos de la base de datos (simulada)
            //1º Intstanciamos la Persona y la inicializamos, para ello hemos creado un constructor vacio
            Persona persona = new Persona();
            
            lstPersonas = persona.getPersonas();

            // 3º Sincronizamos la lista con el DataGridView
            dgvPersonas.ItemsSource = lstPersonas;
            dgvPersonasEdad.ItemsSource = lstPersonas;
            */


        }


        private void cargarPersonas()
        {
            lstPersonas = new List<Alumnado>();
            var personas = AlumnadoPersistence.LeerPersonas();

            foreach (var p in personas)
            {
                lstPersonas.Add(p);
            }

            dgvPersonas.ItemsSource = lstPersonas;
            //dgvPersonasEdad.ItemsSource = lstPersonas;
        }

        public void start()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtCurso.Text = "";
            dgvPersonas.SelectedItem = null;
            //dgvPersonasEdad.SelectedItem = null;
        }



        private void dgvPersonas_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPersonas.SelectedItem is Alumnado personaSeleccionada)
            {
                // Carga los datos de la persona seleccionada en los TextBox
                txtNombre.Text = personaSeleccionada.Nombre;
                txtApellido.Text = personaSeleccionada.Apellidos;
                txtCurso.Text = personaSeleccionada.Grupo.ToString();

                // Habilita los botones de Update y Delete para la edición
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Añadir"; // Vuelve al texto original si es necesario
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCurso.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
                return;
            }

            if (int.TryParse(txtCurso.Text, out int curso))
            {


                // Añadimos la persona con los datos actualizados
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;

                Alumnado persona = new Alumnado(nombre, apellido,1, curso);
                persona.insertar();

                lstPersonas.Add(persona);

                start();
                cargarPersonas();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida.");
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (dgvPersonas.SelectedItem is Alumnado personaSeleccionada)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text) ||
                   string.IsNullOrWhiteSpace(txtCurso.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos.");
                    return;
                }

                if (int.TryParse(txtCurso.Text, out int curso))
                {
                    // Actualizamos los datos de la persona seleccionada
                    personaSeleccionada.Nombre = txtNombre.Text;
                    personaSeleccionada.Apellidos = txtApellido.Text;
                    personaSeleccionada.Grupo = curso;
                    personaSeleccionada.actualizar();
                    start();
                    cargarPersonas();

                }
                else
                {
                    MessageBox.Show("Por favor, ingrese una edad válida.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una persona para actualizar.");
                return;
            }
            start();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (dgvPersonas.SelectedItem is not Alumnado personaSeleccionada)
            {
                MessageBox.Show("Por favor, seleccione una persona para eliminar.");
                return;
            }
            else
            {
                // Eliminamos de la lista aquel registro Seleccionado de dataGridView
                lstPersonas.Remove((Alumnado)dgvPersonas.SelectedItem);
                personaSeleccionada.borrar();


            }

            start();
            cargarPersonas();

        }



        /*
        private void cbFiltroEdad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            AplicarFiltroEdad();
            
        }
        

        private void BtnMostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            
            var ordenado = lstPersonas.OrderBy(p => p.Edad);
            dgvPersonas.ItemsSource = ordenado.ToList();
            dgvPersonasEdad.ItemsSource = ordenado.ToList();
            dgvPersonas.Items.Refresh();
            dgvPersonasEdad.Items.Refresh();
            
        }

        private void txtFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (cbFiltro.SelectedItem == ciFiltroNombre)
            {
                AplicarFiltroNombre();
            }

            else if (cbFiltro.SelectedItem == ciFiltroApellido) { 
                AplicarFiltroApellido();
            }

            else if (cbFiltro.SelectedItem == ciFiltroEdad)
            {
                AplicarFiltroEdad();
            }

            else
            {
                // Si no hay filtro seleccionado, mostramos todas las personas
                dgvPersonas.ItemsSource = lstPersonas;
                dgvPersonasEdad.ItemsSource = lstPersonas;
                dgvPersonas.Items.Refresh();
                dgvPersonasEdad.Items.Refresh();
            }
            
        }


        private void AplicarFiltroEdad()
        {

            if (!int.TryParse(txtFiltro.Text, out int edadFiltro))
            {
                // Si no es un número válido, mostramos todas las personas
                dgvPersonas.ItemsSource = lstPersonas;
                dgvPersonasEdad.ItemsSource = lstPersonas;
                dgvPersonas.Items.Refresh();
                dgvPersonasEdad.Items.Refresh();
                return;
            }

            IEnumerable<Persona> resultado;

            if (cbFiltroEdad.SelectedItem == ciOlderThan)
            {
                 //Con LAMBDA expression syntax 
                resultado = lstPersonas.Where(p => p.Edad > edadFiltro);
            }

            else if (cbFiltroEdad.SelectedItem == ciYoungerThan)
            {
                // Con LAMBDA expression syntax 
                resultado = lstPersonas.Where(p => p.Edad < edadFiltro);
            }

            else if (cbFiltroEdad.SelectedItem == ciExactly)
            {
                // Con LAMBDA expression syntax 
                resultado = lstPersonas.Where(p => p.Edad == edadFiltro);
            }
            else
            {
                // Si no hay filtro seleccionado, mostramos todas las personas
                resultado = lstPersonas;
            }

            // Y Aqui abajo hacemos el ToList() y el refresh del DataGrid
            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }


        private void AplicarFiltroNombre()
        {
            string filtroEnMinusculas = txtFiltro.Text.ToLower();
            var resultado = lstPersonas.Where(p => p.Nombre.ToLower().Contains(txtFiltro.Text));

            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }

        private void AplicarFiltroApellido()
        {
            string filtroEnMinusculas = txtFiltro.Text.ToLower();
            var resultado = lstPersonas.Where(p => p.Apellidos.ToLower().Contains(txtFiltro.Text));
            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            
            if (cbOrden.SelectedItem == ciOrdenNombre)
            {
                OrdenarPorNombre();
            }

            else if (cbOrden.SelectedItem == ciOrdenApellido)
            {
                OrdenarPorApellido();
            }

            else if (cbOrden.SelectedItem == ciOrdenEdad)
            {
                OrdenarPorEdad();
            }

            else
            {
                // Si no se ha seleccionado un filtro de orden, mostramos todas las personas
                dgvPersonas.ItemsSource = lstPersonas;
                dgvPersonasEdad.ItemsSource = lstPersonas;
                dgvPersonas.Items.Refresh();
                dgvPersonasEdad.Items.Refresh();
            }
            
        }


        private void OrdenarPorNombre()
        {
            var resultado = lstPersonas.OrderBy(p => p.Nombre.ToLower());

            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }


        private void OrdenarPorApellido()
        {
            var resultado = lstPersonas.OrderBy(p => p.Apellidos.ToLower());

            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }

        private void OrdenarPorEdad()
        {
            var resultado = lstPersonas.OrderBy(p => p.Edad);

            dgvPersonas.ItemsSource = resultado.ToList();
            dgvPersonasEdad.ItemsSource = resultado.ToList();
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();
        }

        private void BtnMaximo_Click(object sender, RoutedEventArgs e)
        {
            

            Persona personaMayor = lstPersonas.OrderByDescending(p => p.Edad).FirstOrDefault();

            var listaUnaPersona = new List<Persona> { personaMayor };

            dgvPersonas.ItemsSource = listaUnaPersona;
            dgvPersonasEdad.ItemsSource = listaUnaPersona;
            dgvPersonasEdad.Items.Refresh();
            dgvPersonas.Items.Refresh();

            

        }
        */

    }

}