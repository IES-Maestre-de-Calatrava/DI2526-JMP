using Ejercicio2_Con_interaz.domain;
using Ejercicio2_Con_interaz.Persistence.manage;
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
using System;

namespace Ejercicio2_Con_interaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rng = new Random();
        private List<Partida> lstPartidas;
        private Partida partida;
        public MainWindow()
        {

            InitializeComponent();

            int contador = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int entero = rng.Next(0, 10);

                    Label label = new Label();

                    if (entero == 0)
                    {
                        label.Content = $"{i},{j}      S";

                    }
                    else if (entero == 1)
                    {
                        label.Content = $"{i},{j}      R";
                    }
                    else
                    {
                        label.Content = $"{i},{j}";
                    }



                    contador++;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    contenedor.Children.Add(label);
                }
            }

            lstPartidas = new List<Partida>();

            // Descargar los registros de la base de datos
            partida = new Partida();
            cargarPartidas();
        }




        private void cargarPartidas()
        {
            lstPartidas = new List<Partida>();
            var partidas = PartidaPersistence.LeerPartidas();

            foreach (var p in partidas)
            {
                lstPartidas.Add(p);
            }

            dgvPartidas.ItemsSource = lstPartidas;
        }


        public void start()
        {
            txtNickname.Text = "";
            txtPuntuacion.Text = "";
            dpFecha.SelectedDate = null;
            cb.Text = "";
            dgvPartidas.SelectedItem = null;
        }


        private void dgvPartidas_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPartidas.SelectedItem is Partida partidaSeleccionada)
            {
                // Carga los datos de la persona seleccionada en los TextBox
                txtNickname.Text = partidaSeleccionada.Nickname;
                txtPuntuacion.Text = partidaSeleccionada.Puntuacion.ToString();
                cb.Text = partidaSeleccionada.Nivel.ToString();
                dpFecha.SelectedDate = partidaSeleccionada.Fecha_juego;


                // Habilita los botones de Update y Delete para la edición
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Añadir"; // Vuelve al texto original si es necesario
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNickname.Text) ||
                string.IsNullOrWhiteSpace(txtPuntuacion.Text) ||
                !dpFecha.SelectedDate.HasValue)
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
                return;
            }


            // Añadimos la persona con los datos actualizados
            String nickname = txtNickname.Text;
            DateTime fecha_juego = dpFecha.SelectedDate.Value; // esto pone a la fecha seleccionada 00:00:00
            string nivel = seleccionarNivel();
            double puntuacion = double.Parse(txtPuntuacion.Text);


            Partida partida = new Partida(nickname, fecha_juego, nivel, puntuacion);
            partida.insertar();

            lstPartidas.Add(partida);

            start();
            cargarPartidas();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionarNivel();
        }


        private string seleccionarNivel()
        {
            string nivel = "Principiante";

            if (cb.SelectedItem == principiante)
            {
                nivel = "Principiante";
            }
            else if (cb.SelectedItem == intermedio)
            {
                nivel = "Intermedio";
            }
            else if (cb.SelectedItem == avanzado)
            {
                nivel = "Avanzado";
            }
            else if (cb.SelectedItem == experto)
            {
                nivel = "Experto";
            }
            else if (cb.SelectedItem == maestro)
            {
                nivel = "Maestro";
            }

            return nivel;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {

            if (dgvPartidas.SelectedItem is Partida partidaSeleccionada)
            {
                if (string.IsNullOrWhiteSpace(txtNickname.Text) ||
                   string.IsNullOrWhiteSpace(txtPuntuacion.Text) ||
                   !dpFecha.SelectedDate.HasValue)  //esto es que si no se ha seleccionado fecha
                {
                    MessageBox.Show("Por favor, rellene todos los campos.");
                    return;
                }


                // Actualizamos los datos de la persona seleccionada
                partidaSeleccionada.Nickname = txtNickname.Text;
                partidaSeleccionada.Fecha_juego = dpFecha.SelectedDate.Value; // esto igual pone 00:00:00
                partidaSeleccionada.Nivel = seleccionarNivel();
                partidaSeleccionada.Puntuacion = double.Parse(txtPuntuacion.Text);



                partidaSeleccionada.actualizar();

                start();

                cargarPartidas();


                start();

            }

        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvPartidas.SelectedItem is not Partida partidaSeleccionada)
            {
                MessageBox.Show("Por favor, seleccione una partida para eliminar.");
                return;
            }
            else
            {
                // Eliminamos de la lista aquel registro Seleccionado de dataGridView
                lstPartidas.Remove((Partida)dgvPartidas.SelectedItem);
                partidaSeleccionada.borrar();


            }

            start();
            cargarPartidas();
        }

       
    }
}