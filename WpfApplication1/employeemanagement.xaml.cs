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
    /// Interaction logic for employeemanagement.xaml
    /// </summary>
    public partial class employeemanagement : Window
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
        
        public employeemanagement()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            connection();

            string comd = "select max(employee_id) from employee";
            OracleDataAdapter da1 = new OracleDataAdapter(comd, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "set");
            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables[0];
            int employeeId = 0;
            string emp;
            if (dt1.Rows.Count == 0)
            {
                emp = "1000";
            }
            else
            {
                emp = dt1.Rows[0]["max(employee_id)"].ToString();
                employeeId = Convert.ToInt32(emp);
                emp = Convert.ToString(employeeId + 1);
            }

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            if (nm.Text == "" || mid.Text == "" || dob.Text == "" || desig.Text == "" || addr.Text == "" || phone.Text == "" || mail.Text == "")
            {
                MessageBox.Show("Please fill all details", "ERROR");
                
            }
            else
            {
                comd = "insert into employee values (" + emp + ",'" + nm.Text + "'," + mid.Text + ",'" + dob.Text + "','" + desig.Text + "','" + addr.Text + "'," + phone.Text + ",'" + mail.Text + "','" + finalString + "' )";
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = comd;
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Username: " + emp + "\n Password: " + finalString + " ", "Added Record");
                empadd.Visibility = Visibility.Visible;
                maincancel.Visibility = Visibility.Visible;
                empdelete.Visibility = Visibility.Visible;
                addemployee.Visibility = Visibility.Collapsed;
            }
        }




        private void deletesearch_Click(object sender, RoutedEventArgs e)
        {
            deletegrid.Visibility = Visibility.Visible;
            string str = delemployeenumber.Text;
            if (str == "")
            {
                MessageBox.Show("Please fill all details", "ERROR");

            }
            else
            {
                connection();
                string strsql = "select * from employee where employee_id =" + str + "";
                OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Employee ID", "ERROR");
                    delemployeenumber.Text = "";

                }
                else
                {
                    string comd = "delete from employee where  employee_id= " + str + "";
                    OracleCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Your record has Been Successfully Deleted", "Deleted Record");
                    empadd.Visibility = Visibility.Visible;
                    maincancel.Visibility = Visibility.Visible;
                    empdelete.Visibility = Visibility.Visible;
                    deletegrid.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void empdelete_Click(object sender, RoutedEventArgs e)
        {
            deletegrid.Visibility = Visibility.Visible;
            empadd.Visibility = Visibility.Collapsed;
            empdelete.Visibility = Visibility.Collapsed;
            maincancel.Visibility = Visibility.Collapsed;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            empadd.Visibility = Visibility.Visible;
            maincancel.Visibility = Visibility.Visible;
            empdelete.Visibility = Visibility.Visible;
            deletegrid.Visibility = Visibility.Collapsed;
            addemployee.Visibility = Visibility.Collapsed;
        }

        private void empadd_Click(object sender, RoutedEventArgs e)
        {
            addemployee.Visibility = Visibility.Visible;
            empadd.Visibility = Visibility.Collapsed;
            empdelete.Visibility = Visibility.Collapsed;
            maincancel.Visibility = Visibility.Collapsed;
        }

        private void maincancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manager h = new manager();
            h.Show();
        }
        
    }
}
