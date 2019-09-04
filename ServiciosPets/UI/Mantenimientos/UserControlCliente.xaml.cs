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
    /// Lógica de interacción para UserControlCliente.xaml
    /// </summary>
    public partial class UserControlCliente : UserControl
    {
        public UserControlCliente()
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
            ClassCliente Logica = new ClassCliente();
            string resp = Logica.NuevoCliente(TextNIT.Text, TextNombreCliente.Text, TextApellidoCliente.Text, TextDireccion.Text, TextTel1.Text);
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
            if (TextClienteId.Text != "")
            {
                string resp = "";
                ClassCliente Logica = new ClassCliente();
                Clientes INFO = new Clientes();
                INFO.Cliente_Id = Convert.ToInt32(this.TextClienteId.Text);
                INFO.Nombre = this.TextNombreCliente.Text;
                INFO.Apellido = this.TextApellidoCliente.Text;
                INFO.Direccion = this.TextDireccion.Text;
                INFO.NIT = this.TextNIT.Text;
                INFO.Telefono = this.TextTel1.Text;
                resp = Logica.ActualizaCliente(INFO);
                MessageBox.Show(resp);

                /* MessageBox.Show(TextCodigo.Text);
                 MessageBox.Show(TextDescripcion.Text);
                 MessageBox.Show(TextVenta.Text);
                 MessageBox.Show(TextProductos.Text);
                 MessageBox.Show(TextReportes.Text);*/
            }
            else
            {
                MessageBox.Show("Marque el registro a modificar", "Error al Editar",
                MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassCliente Logica = new ClassCliente();
            dataGrid1.ItemsSource = Logica.ListarClientes();
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
