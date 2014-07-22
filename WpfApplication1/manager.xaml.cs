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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        public manager()
        {
            InitializeComponent();
            hometext.Text = " Hello And Welcome To Hotel Taj \n The Leading Hotel Chain In India.";
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manager h = new manager();
            h.Show();
        }

        private void empmanage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            employeemanagement h = new employeemanagement();
            h.Show();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully Logged out");
            this.Hide();
            MainWindow h = new MainWindow();
            h.Show();
        }

        private void roommanage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            roommanagement h = new roommanagement();
            h.Show();
        }
    }
}
