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

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtInput.Focus();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var service = new CurrencyService.ConvertServiceClient();

            txtResult.Text = "Result: " + service.GetCurrencyInWords(txtInput.Text);

            service.Close();            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();

            txtResult.Text = "";
        }
    }
}
