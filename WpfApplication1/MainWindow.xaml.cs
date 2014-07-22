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
using Oracle.DataAccess.Client;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string constr = "";
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            string str1=username.Text;
            string str2=pass.Password;
            connection();
            string strsql = "select designation from employee where employee_id =" + str1 + "and password =" + "'" + str2 + "'";
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
                string desig = dt1.Rows[0]["designation"].ToString();
                if (desig == "receptionist")
                {
                    this.Hide();
                    Home h = new Home();
                    h.Show();
                }
                else if (desig == "employee")
                {
                    this.Hide();
                    employeeHomePage h = new employeeHomePage();
                    h.Show();
                }
                else
                {
                    this.Hide();
                    manager h = new manager();
                    h.Show();
                }
            }
        }

        
    }
}
