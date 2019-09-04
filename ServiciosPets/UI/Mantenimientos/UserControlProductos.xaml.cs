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
    /// Lógica de interacción para UserControlProductos.xaml
    /// </summary>
    public partial class UserControlProductos : UserControl
    {
        public UserControlProductos()
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
            ClassProductos Logica = new ClassProductos();
            string resp = Logica.NuevoProducto(float.Parse(this.TextDescuento.Text), TextNombreProducto.Text, float.Parse(TextPrecioDesc.Text), TextUnidad.Text, bool.Parse(TextHabilitar.Text), int.Parse(TextTipo.Text));
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
            if (TextProductoId.Text != "")
            {
                string resp = "";
                ClassProductos Logica = new ClassProductos();
                Productos INFO = new Productos();
                INFO.Productos_Id = Convert.ToInt32(this.TextProductoId.Text);
                INFO.Nombre_Producto = TextNombreProducto.Text;
                INFO.Descuento = float.Parse(TextDescuento.Text);
                INFO.PreciosinDecuento = float.Parse(TextPrecioDesc.Text);
                INFO.Unidad_de_medida = TextUnidad.Text;
                INFO.Habilitar = bool.Parse(TextHabilitar.Text);
                INFO.Tipo_Id = Convert.ToInt32(this.TextTipo.Text);
                resp = Logica.ActualizaProducto(INFO);
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
            ClassProductos Logica = new ClassProductos();
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
