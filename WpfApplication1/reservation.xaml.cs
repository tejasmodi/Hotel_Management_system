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
    /// Interaction logic for reservation.xaml
    /// </summary>
    public partial class reservation : Window
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
        
        public reservation()
        {
            InitializeComponent();
            
            //generate customer no. automatically
            connection();
            string comd = "select max(customer_id) from customer";
            OracleDataAdapter da1 = new OracleDataAdapter(comd, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "set");
            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables[0];
            int customerId=0;
            string cust;
            if (dt1.Rows.Count == 0)
            {
                cid.Text = "1000";
            } 
            else
            {
                cust = dt1.Rows[0]["max(customer_id)"].ToString();
                customerId = Convert.ToInt32(cust);
                cid.Text = Convert.ToString(customerId + 1);
            }
            
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (fname.Text == "" || lname.Text == "" || cell.Text == ""  || pno.Text == "" || address.Text == "" || start.Text == "" || end.Text == "" || rid.Text == "")
            {
                MessageBox.Show("Please fill all the details", "ERROR");
            }

            else
            {
                //check for gender
                string gender;
                if (gen_male.IsChecked == true)
                {
                    gender = "m";
                }
                else
                {
                    gender = "f";
                }

                string comd = "select * from reservation where room_id=" + rid.Text + "";
                OracleDataAdapter da1 = new OracleDataAdapter(comd, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count != 0)
                {
                    MessageBox.Show("Room already occupied", "ERROR");
                    fname.Text = "";
                    lname.Text = "";
                    cell.Text = "";
                    gen_female.IsChecked = false;
                    gen_male.IsChecked = false;
                    pno.Text = "";
                    address.Text = "";
                    start.Text = "";
                    end.Text = "";
                    rid.Text = "";

                }
                else
                {
                    //update customer table
                    connection();
                    comd = "insert into customer values (" + cid.Text + ",'" + fname.Text + "','" + lname.Text + "','" + gender + "','" + address.Text + "'," + pno.Text + ",'" + mail.Text + "'," + cell.Text + ",'" + start.Text + "','" + end.Text + "','n' ," + rid.Text + ")";
                    OracleCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();

                    //find out no. of days
                    DateTime checkin = Convert.ToDateTime(start.Text);
                    DateTime checkout = Convert.ToDateTime(end.Text);
                    TimeSpan difference = checkout - checkin;
                    var days = difference.TotalDays;
                    int da = Convert.ToInt32(days);

                    //find price of allotted room
                    comd = "select price from room where room_id=" + rid.Text + "";
                    da1 = new OracleDataAdapter(comd, con);
                    ds1 = new DataSet();
                    da1.Fill(ds1, "set");
                    dt1 = new DataTable();
                    dt1 = ds1.Tables[0];
                    int price = Convert.ToInt32(dt1.Rows[0]["price"]);
                    price = price * da;

                    //update reservation table
                    comd = "insert into reservation values (" + cid.Text + "," + rid.Text + "," + price + ")";
                    cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Your room has Been Successfully Reserved \n room no :" + rid.Text , "Room Reserved");

                    //set each box to default null value
                    cid.Text = "";
                    fname.Text = "";
                    lname.Text = "";
                    cell.Text = "";
                    gen_female.IsChecked = false;
                    gen_male.IsChecked = false;
                    pno.Text = "";
                    address.Text = "";
                    start.Text = "";
                    end.Text = "";
                    rid.Text = "";
                    cancel_Click(sender, e);
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
