using System.Windows;

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

            txtResult.Text = "Result: ";
        }
    }
}
