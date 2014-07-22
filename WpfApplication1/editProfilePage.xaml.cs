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
    /// Interaction logic for editProfilePage.xaml
    /// </summary>
    public partial class editProfilePage : Window
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
        int b;
        public void connection()
        {
            con = new OracleConnection();
            con.ConnectionString = constr;
            con.ConnectionString = @"User Id=system;Password=tejas;Data Source=localhost:1521/XE;";
            con.Open();
        }
        public editProfilePage(int a)
        {
            InitializeComponent();
            if (a == 1)
            {
                b = 1;
            }
            else
            {
                b = 2;
            }
        }

        private void buttonCheckProfile(object sender, RoutedEventArgs e)
        {
            string str1 = username.Text;
            string str2 = pass.Password;
            if (str1 == "" || str2 == "")
            {
                MessageBox.Show("Please fill all fields", "ERROR");
                username.Text = "";
                pass.Password = "";
            }
            else
            {
                connection();
                string strsql = "select * from employee where employee_id =" + str1 + " and password =" + "'" + str2 + "'" + "";
                OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid credentials", "ERROR");
                    username.Text = "";
                    pass.Password = "";
                }
                else
                {
                    this.Hide();
                    profilePage h = new profilePage(b, str1);
                    h.Show();
                }
            }

        }

        private void buttonCancel(object sender, RoutedEventArgs e)
        {
            if(b == 1)
            {   
                this.Hide();
                Home h = new Home();
                h.Show();
            }
            if (b == 2)
            {
                this.Hide();
                employeeHomePage h = new employeeHomePage();
                h.Show();
            }

        }
    }
}
