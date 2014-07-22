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
    /// Interaction logic for changePassword.xaml
    /// </summary>
    public partial class changePassword : Window
    {
        string constr = "";
        OracleConnection con = null;
        OracleDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        OracleDataReader dr;
        OracleCommand cmd;
        int count;
        int b=0;
        int s = 0;
        public void connection()
        {

            con = new OracleConnection();
            con.ConnectionString = constr;
            con.ConnectionString = @"User Id=system;Password=tejas;Data Source=localhost:1521/XE;";
            con.Open();
        }
        public changePassword(int a, int str)
        {
            InitializeComponent();
            b = a;
            s = str;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (old.Password == "" || newpassword.Password == "" || newConfirm.Password == "")
            {
                MessageBox.Show("Please fill all the fields", "Error");
                
            }
            else
            {
                string str1 = old.Password;
                string str2 = newpassword.Password;
                string str3 = newConfirm.Password;
                if (str2 == str3)
                {
                    connection();
                    string strsql = "select password from employee where employee_id =" + s + "";
                    OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "set");
                    DataTable dt1 = new DataTable();
                    dt1 = ds1.Tables[0];
                    string pass = dt1.Rows[0]["password"].ToString();
                    if (pass == old.Password)
                    {
                        connection();
                        string comd = "update employee set password = '" + newConfirm.Password + "' where employee_id = " + s + "";
                        OracleCommand cmd1 = con.CreateCommand();
                        cmd1.CommandText = comd;
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("password changed successfully", "Success");
                        cancel_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Existing password is incorrect", "Error");
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("New password and comfirm password do not match", "Error");
                    reset();
                }
            }
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (b == 1)
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
        private void reset()
        {
            old.Password = "";
            newpassword.Password = "";
            newConfirm.Password = "";
        }
    }
}
