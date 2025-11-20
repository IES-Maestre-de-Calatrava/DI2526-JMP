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

        private List<Alumnado> lstAlumnosSinGrupo;
        private List<Alumnado> lstAlumnosEnGrupo;
        private List<AceptasElReto.domain.Grupo> lstGrupos;
        public MainWindow()
        {
            InitializeComponent();
            lstPersonas = new List<Alumnado>();

            // Descargar los registros de la base de datos
            persona = new Alumnado();
            cargarPersonas();
            cargarDatosAsignacion();
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
        }

        private void cargarDatosAsignacion()
        {
            // 1. Cargar Grupos Existentes
            // Necesitas acceder a GrupoPersistence (asegúrate del 'using' o usa el namespace completo)
            lstGrupos = AceptasElReto.persistence.manage.GrupoPersistence.LeerGrupos();
            dgvGrupos.ItemsSource = lstGrupos;

            // 2. Cargar Alumnos SIN Asignar
            lstAlumnosSinGrupo = AlumnadoPersistence.LeerAlumnosSinGrupo();
            dgvAlumnosSinGrupo.ItemsSource = lstAlumnosSinGrupo;

            // 3. Inicializar la lista de Alumnos En Grupo (vacía o con la selección por defecto)
            // Se llenará al seleccionar un grupo. La inicializamos vacía.
            lstAlumnosEnGrupo = new List<Alumnado>();
            dgvAlumnosEnGrupo.ItemsSource = lstAlumnosEnGrupo;
        }

        public void start()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            cb.Text = "";
            dgvPersonas.SelectedItem = null;
            dgvAlumnosSinGrupo.SelectedItem = null;
            dgvAlumnosEnGrupo.SelectedItem = null;
            dgvGrupos.SelectedItem = null;
        }



        private void dgvPersonas_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPersonas.SelectedItem is Alumnado personaSeleccionada)
            {
                // Carga los datos de la persona seleccionada en los TextBox
                txtNombre.Text = personaSeleccionada.Nombre;
                txtApellido.Text = personaSeleccionada.Apellidos;
                cb.Text = personaSeleccionada.Grupo.ToString();

                // Habilita los botones de Update y Delete para la edición
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Añadir"; // Vuelve al texto original si es necesario
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
                return;
            }

            // Añadimos la persona con los datos actualizados
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int grupo = seleccionarCursoComercio();

            Alumnado persona = new Alumnado(nombre, apellido, 1, grupo);
            persona.insertar();

            lstPersonas.Add(persona);

            start();
            cargarPersonas();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (dgvPersonas.SelectedItem is Alumnado personaSeleccionada)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, rellene todos los campos.");
                    return;
                }
                // Actualizamos los datos de la persona seleccionada
                personaSeleccionada.Nombre = txtNombre.Text;
                personaSeleccionada.Apellidos = txtApellido.Text;
                personaSeleccionada.Grupo = seleccionarCursoComercio();
                personaSeleccionada.actualizar();
                start();
                cargarPersonas();
                start();
            }
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

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionarCursoComercio();
        }

        private int seleccionarCursoComercio()
        {
            int curso = 0;

            if (cb.SelectedItem == SCI1)
            {
                curso = 1;
            }
            else
                if (cb.SelectedItem == SCI2)
            {
                curso = 2;
            }

            return curso;
        }

        public void dgvGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Nota: La clase Grupo está en AceptasElReto.domain
            if (dgvGrupos.SelectedItem is AceptasElReto.domain.Grupo grupoSeleccionado)
            {
                // 1. Cargar la lista filtrada de la BBDD
                lstAlumnosEnGrupo = AlumnadoPersistence.LeerAlumnosPorGrupo(grupoSeleccionado.IdGrupo);

                // 2. Asignar la nueva lista al DataGrid de la derecha
                dgvAlumnosEnGrupo.ItemsSource = lstAlumnosEnGrupo;

                // Es importante refrescar el DataGrid para asegurar que los datos se muestren
                dgvAlumnosEnGrupo.Items.Refresh();
            }
            else
            {
                // Si se deselecciona o la selección es nula, vaciamos la lista
                dgvAlumnosEnGrupo.ItemsSource = new List<Alumnado>();
                dgvAlumnosEnGrupo.Items.Refresh();
            }
        }

        private void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Verificar si hay un grupo seleccionado
            if (dgvGrupos.SelectedItem is not AceptasElReto.domain.Grupo grupoSeleccionado)
            {
                MessageBox.Show("Por favor, seleccione un grupo de destino.");
                return;
            }

            // 2. Obtener los alumnos seleccionados en la lista de la izquierda (Sin Grupo)
            var alumnosAAsignar = dgvAlumnosSinGrupo.SelectedItems.OfType<Alumnado>().ToList();

            if (alumnosAAsignar.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un alumno para asignar.");
                return;
            }

            int idDestino = grupoSeleccionado.IdGrupo;

            // 3. Actualizar la base de datos para cada alumno
            foreach (var alumno in alumnosAAsignar)
            {
                // 🚨 CRUCIAL: Modificar el objeto y llamar a la persistencia para hacer UPDATE
                alumno.Grupo = idDestino;
                // Asumiendo que tienes un método 'actualizar' en la clase Alumnado que llama a la persistencia
                alumno.actualizar();
            }

            // 4. Recargar y refrescar las tres listas para reflejar el cambio
            cargarDatosAsignacion(); // Recarga la lista de Grupos (no cambia), la lista SIN Grupo y la lista EN Grupo

            cargarPersonas(); // Carga la lista completa de personas nueva

            // Opcional: Volver a seleccionar el grupo que se estaba editando para que se muestre la lista de la derecha actualizada
            dgvGrupos.SelectedItem = grupoSeleccionado;
        }

    }
}