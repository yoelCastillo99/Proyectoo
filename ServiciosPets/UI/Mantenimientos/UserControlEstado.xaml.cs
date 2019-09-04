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

using BLL;
using MODELS;
namespace UI.Mantenimientos
{
    /// <summary>
    /// Lógica de interacción para UserControlEstado.xaml
    /// </summary>
    public partial class UserControlEstado : UserControl
    {
        public UserControlEstado()
        {
            InitializeComponent();
        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassAccesos Lg = new ClassAccesos();
            dataGrid1.ItemsSource = Lg.MostrarTodo();
            buttonEditar.IsEnabled = true;
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

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            buttonAgregar.Visibility = Visibility.Visible;
            buttonGrabar.Visibility = Visibility.Hidden;
            buttonEditar.IsEnabled = false;
            buttonCancelar.IsEnabled = false;
            buttonListar.IsEnabled = true;
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e)
        {
            if (TextCodigo.Text != "")
            {
                string resp = "";
                ClassAccesos Logica = new ClassAccesos();
                Accesos INFO = new Accesos();
                INFO.Accesos_Id = Convert.ToInt32(this.TextCodigo.Text);
                INFO.Descripcion = this.TextDescripcion.Text;
                INFO.Ventas = bool.Parse(TextVenta.Text);
                INFO.Productos = bool.Parse(TextProductos.Text);
                INFO.Reportes = bool.Parse(TextReportes.Text);
                resp = Logica.ActualizaAcceso(INFO);
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

        private void ButtonGrabar_Click(object sender, RoutedEventArgs e)
        {
            ClassAccesos Logica = new ClassAccesos();
            string mensaje = Logica.NuevoAcceso(this.TextDescripcion.Text, bool.Parse(this.TextVenta.Text), bool.Parse(this.TextProductos.Text), bool.Parse(this.TextReportes.Text));
            if (mensaje.ToUpper().Contains("ERROR"))
                MessageBox.Show(mensaje, "Error al grabar", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBox.Show("se creó el nuevo registro");
                buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;
                  
            }

        }
    }
    
}
