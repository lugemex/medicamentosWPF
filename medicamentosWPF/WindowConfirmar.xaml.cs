using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace medicamentosWPF
{
    /// <summary>
    /// Lógica de interacción para WindowConfirmar.xaml
    /// </summary>
    public partial class WindowConfirmar : Window
    {
        public WindowConfirmar()
        {
            InitializeComponent();
        }

        private void TextBoxDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxResumen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pedido enviado");
            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
            
        }
    }
}
