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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        string constr = "";
        //string admin = "admin";
        //string adminpass = "dbms";
        OracleConnection con = null;
        OracleDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        OracleDataReader dr;
        OracleCommand cmd;
        int count;
        public void connection()
        {
            con = new OracleConnection();
            con.ConnectionString = constr;
            con.ConnectionString = @"User Id=system;Password=tejas;Data Source=localhost:1521/XE;";
            con.Open();
        }
        
        public Home()
        {
            InitializeComponent();
            hometext.Text = " Hello And Welcome To Hotel Taj \n The Leading Hotel Chain In India.";
        }

        private void buttonReceptionistHomePage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }

        private void buttonEditProfile(object sender, RoutedEventArgs e)
        {
            this.Hide();
            editProfilePage h = new editProfilePage(1);
            h.Show();
        }
      
        private void buttonReservation(object sender, RoutedEventArgs e)
        {
            this.Hide();
            reservation h = new reservation();
            h.Show();
        }

        private void buttonCheckout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            checkout h = new checkout();
            h.Show();
        }

        private void buttonLogout(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully Logged out");
            this.Hide();
            MainWindow h = new MainWindow();
            h.Show();
        }
    }
}
