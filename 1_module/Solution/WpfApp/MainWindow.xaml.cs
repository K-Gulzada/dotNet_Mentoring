using ClassLibrary;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // task 1 Show Hello Text
            SayHello obj = new SayHello();
            obj.SayHelloLabel.Content = "Hello, " + usernameTextBox.Text + "!";
            obj.Show(); //Sending value from one form to another form.
            //Close();

            // task 2 Show Hello Text using class library in second window and close first
            /* StringOperation operation = new StringOperation();
             obj.SayHelloLabel.Content = operation.ConcatStrings(usernameTextBox.Text);
             obj.Show();
             Close();*/
        }
    }
}
