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
    /// Interaction logic for checkout.xaml
    /// </summary>
    public partial class checkout : Window
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
        
        public checkout()
        {
            InitializeComponent();
        }
       
        private void checkoutbox_Click(object sender, RoutedEventArgs e)
        {
            string str = rid.Text;
            if (str == "")
            {
                MessageBox.Show("Please fill the fields before submitting", "Error");

            }
            else
            {
                connection();
                string strsql = "select * from reservation where room_id =" + str + "";
                OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Room ID Invalid");
                    rid.Text = "";
                }

                else
                {
                    double cust = int.Parse(dt1.Rows[0]["CUSTOMER_ID"].ToString());
                    double price = int.Parse(dt1.Rows[0]["charges"].ToString());
                    MessageBox.Show("Amount Payable is : " + price + "\n press ok when amoount is collected");
                    connection();
                    string comd = "delete from reservation where  room_id= " + rid.Text + "";
                    OracleCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();
                    comd = "update customer set checked_out = 'y'";
                    cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();
                    roomconfirm.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Checkout SUCCESSFUL");
                    this.Hide();
                    Home h = new Home();
                    h.Show();
                }

            }
        }

       
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            //send back to receptionist home page 
            this.Hide();
            Home h = new Home();
            h.Show();
        }
    }
}
