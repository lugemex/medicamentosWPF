using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace medicamentosWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonBorrar_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMedicamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            TextBoxCantidad.Clear();
            radioButtonCemefar.IsChecked = false;
            radioButtonCofarma.IsChecked = false;
            radioButtonEmpsephar.IsChecked = false;
            checkBoxPrimaria.IsChecked = false;
            checkBoxSecundaria.IsChecked = false;           
        }
     
        private void ButtonConfirmar_Click(object sender, RoutedEventArgs e)
        {
            //comprobación del nombre de medicamento
            if (string.IsNullOrEmpty(TextBoxMedicamento.Text))
            {
                MessageBox.Show("Favor de escribir el nombre del medicamento");
            }
            //comprobación de tipo
            else if ((bool)(comboBoxTipo.SelectedItem == null))
            {
                MessageBox.Show("Favor de seleccionar un Tipo de medicamento");
            }
            //comprobación de una cantidad positiva
            //else if ()
            //{

            //}
            //comprobación de distribuidor
            else if ((bool)(!radioButtonCemefar.IsChecked & !radioButtonCofarma.IsChecked & !radioButtonEmpsephar.IsChecked)==true)
            {
                MessageBox.Show("Favor de seleccionar algún distribuidor");
            }
            else if ((bool)(!checkBoxPrimaria.IsChecked & !checkBoxSecundaria.IsChecked))
            {
                MessageBox.Show("Favor de seleccionar algúna sucursal");
            }
            else
            {
                WindowConfirmar objWindowConfirmar = new WindowConfirmar();
                //this.Visibility = Visibility.Hidden;
                this.Close();
                objWindowConfirmar.Show();
                string Sucursal = null;
                string Distribuidor = null;
                //asignar titulo a la ventana nueva
                if ((bool)radioButtonCofarma.IsChecked)
                {
                    Distribuidor = "Cofarma";
                }
                else if ((bool)radioButtonCemefar.IsChecked)
                {
                    Distribuidor = "Cemefar";
                }
                else if ((bool)radioButtonEmpsephar.IsChecked)
                {
                    Distribuidor = "Empsepar";
                }
                objWindowConfirmar.Title = Distribuidor;
                //elegir dirección de envío
                if ((bool)checkBoxPrimaria.IsChecked)
                {
                    Sucursal = "Calle de la Rosa n. 28.";
                }
                else if ((bool)checkBoxSecundaria.IsChecked)
                {
                    Sucursal = "Calle Alcazabilla n. 3.";
                }
                objWindowConfirmar.TextBoxResumen.Text = TextBoxCantidad.Text + " unidades del " + comboBoxTipo.Text + " " + TextBoxMedicamento.Text;
                objWindowConfirmar.TextBoxDireccion.Text = Sucursal;
            }

            
            
        }

        private void CheckBoxPrimaria_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxSecundaria.IsChecked = false;
        }

        private void CheckBoxSecundaria_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxPrimaria.IsChecked = false;
        }

        private void ComboBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }

        private void TextBoxMedicamento_KeyDown(object sender, KeyEventArgs e)
        {
            // el evento e-Key devuelve el código de la tecla física (NO DEL ASCII)!! D0=34 y D9=43;A=44-Z=69;num 74-83
            //MessageBox.Show(Convert.ToString(e.Key));
            if (e.Key==Key.Enter | e.Key == Key.Escape | e.Key == Key.RightShift | e.Key == Key.LeftShift | e.Key == Key.Capital| e.Key == Key.Oem3) //key.Oem3== ñ (146)
            {
                return;
            }
            else if (e.Key < Key.NumPad0) //<74
            {
                if (e.Key < Key.D0 | e.Key > Key.Z)// entre 34 y 43
                {
                    MessageBox.Show("Favor de introducir sólo caracteres numéricos");
                    e.Handled = true;
                }
            }

            else if (e.Key > Key.NumPad9) //> 83
            {
                MessageBox.Show("Favor de introducir sólo caracteres numéricos 2");
                e.Handled = true;
            }
        }

        private void TextBoxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            // el evento e-Key devuelve el código de la tecla física (NO DEL ASCII)!! D0=34 y D9=43;74-83
            //MessageBox.Show(Convert.ToString((int)e.Key));
            if (e.Key == Key.Enter | e.Key==Key.Escape)
            {
                //MessageBox.Show("tecla válida");
                return;
            }
            else if (e.Key < Key.NumPad0) //<74
            {
                if (e.Key < Key.D0 | e.Key > Key.D9)// entre 34 y 43
                {
                    MessageBox.Show("Favor de introducir sólo caracteres numéricos");
                    e.Handled=true;  
                }
            }
            
            else if (e.Key > Key.NumPad9) //> 83
            {
                MessageBox.Show("Favor de introducir sólo caracteres numéricos 2");
                e.Handled = true;
            }

        }
    }
}
