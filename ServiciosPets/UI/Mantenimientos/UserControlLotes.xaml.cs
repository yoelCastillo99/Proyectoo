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
    /// Lógica de interacción para UserControlLotes.xaml
    /// </summary>
    public partial class UserControlLotes : UserControl
    {
        public UserControlLotes()
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
            ClassLotes Logica = new ClassLotes();
            string resp = Logica.NuevaDescripcion(TextDescripcion.Text, int.Parse(TextCantidad.Text), TextFechaCaducidad.Text, TextFechaProduccion.Text, int.Parse(TextProductos_Id.Text));
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
            if (TextLotesId.Text != "")
            {
                string resp = "";
                ClassLotes Logica = new ClassLotes();
                Lotes INFO = new Lotes();
                INFO.Id_Lotes = Convert.ToInt32(this.TextLotesId.Text);
                INFO.Descripcion = TextDescripcion.Text;
                INFO.Cantidad = int.Parse(TextCantidad.Text);
                INFO.Fecha_Caducidad = DateTime.Parse(TextFechaCaducidad.Text);
                INFO.Fecha_Produccion = DateTime.Parse(TextFechaProduccion.Text);
                INFO.Productos_Id = Convert.ToInt32(this.TextProductos_Id.Text);
                resp = Logica.ActualizaLotes(INFO);
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
            ClassLotes Logica = new ClassLotes();
            dataGrid1.ItemsSource = Logica.ListarLotes();
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
