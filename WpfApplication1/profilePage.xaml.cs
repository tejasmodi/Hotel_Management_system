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
    /// Interaction logic for profilePage.xaml
    /// </summary>
    public partial class profilePage : Window
    {
        string username;
        string constr = "";
        OracleConnection con = null;
        OracleDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        OracleDataReader dr;
        OracleCommand cmd;
        int count;
        int s;
        int b;
        public void connection()
        {
            con = new OracleConnection();
            con.ConnectionString = constr;
            con.ConnectionString = @"User Id=system;Password=tejas;Data Source=localhost:1521/XE;";
            con.Open();
        }
        public profilePage(int a,string str)
        {
            InitializeComponent();
            b = a;
            s = Convert.ToInt32(str);
            connection();
            string strsql = "select * from employee where employee_id =" + str + "";
            OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "set");
            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables[0];
            string dateOfBirth = dt1.Rows[0]["dob"].ToString();
            dateOfBirth = dateOfBirth.Substring(0, 10);
            string month = dateOfBirth.Split(' ')[0].Substring(3, 2);
            int mon = Convert.ToInt32(month);
            string newMonth="";
            switch (mon)
            {
                case 01:
                    newMonth = "jan";
                    break;
                case 02:
                    newMonth = "feb";
                    break;
                case 03:
                    newMonth = "mar";
                    break;
                case 04:
                    newMonth = "apr";
                    break;
                case 05:
                    newMonth = "may";
                    break;
                case 06:
                    newMonth = "jun";
                    break;
                case 07:
                    newMonth = "jul";
                    break;
                case 08:
                    newMonth = "aug";
                    break;
                case 09:
                    newMonth = "sep";
                    break;
                case 10:
                    newMonth = "oct";
                    break;
                case 11:
                    newMonth = "nov";
                    break;
                case 12:
                    newMonth = "dec";
                    break;
            }
            dateOfBirth = dateOfBirth.Replace(month,newMonth);
            nm.Text = dt1.Rows[0]["name"].ToString();
            mid.Text = dt1.Rows[0]["manager_id"].ToString();
            dob.Text = dateOfBirth;
            desig.Text = dt1.Rows[0]["designation"].ToString();
            addr.Text = dt1.Rows[0]["address"].ToString();
            phone.Text = dt1.Rows[0]["phone"].ToString();
            mail.Text = dt1.Rows[0]["mail_id"].ToString();
        }
        private void passwordChange_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            changePassword h = new changePassword(b,s);
            h.Show();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (nm.Text == "" || mid.Text == "" || dob.Text == "" || desig.Text == "" || addr.Text == "" || phone.Text == "" || mail.Text == "")
            {
                MessageBox.Show("Please fill all details", "Error");
            }
            else
            {

                connection();
                string comd = "update employee set name = '" + nm.Text + "',manager_id = " + mid.Text + ",dob = '" + dob.Text + "',designation = '" + desig.Text + "',address = '" + addr.Text + "',phone = " + phone.Text + ",mail_id = '" + mail.Text + "' where employee_id = " + s + " ";
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = comd;
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Your record has Been Successfully Added", "Added Record");
                buttonCancel(sender, e);
            }
        }
        private void buttonCancel(object sender, RoutedEventArgs e)
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
    }
}