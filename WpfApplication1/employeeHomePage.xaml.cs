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
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using System.Data;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for employeeHomePage.xaml
    /// </summary>
    public partial class employeeHomePage : Window
    {
        public employeeHomePage()
        {
            InitializeComponent();
            hometext.Text = " Hello And Welcome To Hotel Taj \n The Leading Hotel Chain In India.";
        }

        private void buttonEmployeeHomePage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            employeeHomePage h = new employeeHomePage();
            h.Show();
        }

        private void buttonLogout(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully Logged out");
            this.Hide();
            MainWindow h = new MainWindow();
            h.Show();
        }

        private void buttonEditProfile(object sender, RoutedEventArgs e)
        {
            this.Hide();
            editProfilePage h = new editProfilePage(2);
            h.Show();
        }
    }
}
