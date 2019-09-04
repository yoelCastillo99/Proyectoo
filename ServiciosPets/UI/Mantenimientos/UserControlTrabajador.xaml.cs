using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MODELS;
using BLL;
using System.Collections;

namespace UI.Mantenimientos
{
    /// <summary>
    /// Lógica de interacción para UserControlTrabajador.xaml
    /// </summary>
    public partial class UserControlTrabajador : UserControl
    {
        public UserControlTrabajador()
        {
            InitializeComponent();
        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            buttonAgregar.Visibility = Visibility.Hidden;
            buttonGrabar.Visibility = Visibility.Visible;
            buttonEditar.IsEnabled = false;
            buttonListar.IsEnabled = false;
            buttonCancelar.IsEnabled = true;
            dataGrid1.ItemsSource = null;
        }

        private void ButtonGrabar_Click(object sender, RoutedEventArgs e)
        {
            ClassTrabajador Logica = new ClassTrabajador();
            string resp = Logica.NuevoTrabajador(TextDPI.Text, TextNombreEmpleado.Text, TextApellido.Text, TextDireccion.Text, TextTelefono.Text, TextUsuario.Text, TextPassword.Text, bool.Parse(TextHabilitar.Text), int.Parse(TextTipoEmpleado.Text));
            if (resp.ToUpper().Contains("ERROR"))
                MessageBox.Show(resp, "Error al grabar", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBox.Show(resp);
                buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;
            }
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e)
        {
            if (TextTrabajador_Id.Text != "")
            {
                string resp = "";
                ClassTrabajador Logica = new ClassTrabajador();
                Trabajador INFO = new Trabajador();
                INFO.Empleado_Id = Convert.ToInt32(this.TextTrabajador_Id.Text);
                INFO.Nombre = TextNombreEmpleado.Text;
                INFO.Apellido = TextApellido.Text;
                INFO.Direccion = TextDireccion.Text;
                INFO.DPI = TextDPI.Text;
                INFO.Habilitar = bool.Parse(TextHabilitar.Text);
                INFO.TipoEmpleado_Id = Convert.ToInt32(this.TextTipoEmpleado.Text);
                resp = Logica.ActualizaTrabajador(INFO);
                MessageBox.Show(resp);

            }
            else
            {
                MessageBox.Show("Marque el registro a modificar", "Error al Editar",
                MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassTrabajador Logica = new ClassTrabajador();
            dataGrid1.ItemsSource = Logica.ListarProductos();
            buttonEditar.IsEnabled = true;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            buttonAgregar.Visibility = Visibility.Visible;
            buttonGrabar.Visibility = Visibility.Hidden;
            buttonEditar.IsEnabled = false;
            buttonCancelar.IsEnabled = false;
            buttonListar.IsEnabled = true;
        }
    }
}
