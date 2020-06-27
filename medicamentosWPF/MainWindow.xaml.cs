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

        private void textBoxCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, RoutedEventArgs e)
        {
            textBoxMedicamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            textBoxCantidad.Clear();
            radioButtonCemefar.IsChecked = false;
            radioButtonCofarma.IsChecked = false;
            radioButtonEmpsephar.IsChecked = false;
            checkBoxPrimaria.IsChecked = false;
            checkBoxSecundaria.IsChecked = false;           
        }
    }
}
