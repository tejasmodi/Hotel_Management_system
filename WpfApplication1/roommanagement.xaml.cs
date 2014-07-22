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
    /// Interaction logic for roommanagement.xaml
    /// </summary>
    public partial class roommanagement : Window
    {
        string constr = "";
        OracleConnection con = null;
        OracleDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        OracleDataReader dr;
        OracleCommand cmd;
        int count;
        string str="";
        public void connection()
        {
            con = new OracleConnection();
            con.ConnectionString = constr;
             con.ConnectionString = @"User Id=system;Password=tejas;Data Source=localhost:1521/XE;";
            con.Open();
        }
        public roommanagement()
        {
            InitializeComponent();
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            connection();
            if (rmid.Text == "" || rmtype.Text == "" || pr.Text == "")
            {

                MessageBox.Show("Please fill all the details", "Error");

            }
            else
            {
                string comd = "insert into room values (" + rmid.Text + ",'" + rmtype.Text + "'," + pr.Text + ")";
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = comd;
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Your room has Been Successfully Added", "Added Room");
                addroom.Visibility = Visibility.Visible;
                editroom.Visibility = Visibility.Visible;
                empdelete.Visibility = Visibility.Visible;
                maincancel.Visibility = Visibility.Visible;
                add.Visibility = Visibility.Collapsed;
            }
        }
        private void roomedit_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            addroom.Visibility = Visibility.Collapsed;
            empdelete.Visibility = Visibility.Collapsed;
            maincancel.Visibility = Visibility.Collapsed;
            editroom.Visibility = Visibility.Collapsed;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            str = rid.Text;
            if (str == "")
            {
                MessageBox.Show("Please fill all the details", "Error");
            }
            else
            {
                connection();
                string strsql = "select * from room where room_id =" + str + "";
                OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Entered Room does not exist", "Room not Present");
                    rid.Text = "";
                    search.Visibility = Visibility.Visible;
                }
                else
                {
                    string roomtype = dt1.Rows[0]["room_type"].ToString();
                    string roomprice = dt1.Rows[0]["price"].ToString();
                    search.Visibility = Visibility.Collapsed;

                    roomid.Visibility = Visibility.Collapsed;
                    rid.Visibility = Visibility.Collapsed;
                    edittype.Visibility = Visibility.Visible;

                    searchcancel.Visibility = Visibility.Collapsed;
                    editprice.Visibility = Visibility.Visible;

                    type.Visibility = Visibility.Visible;
                    type.Text = roomtype;
                    innercancel.Visibility = Visibility.Visible;
                    price.Visibility = Visibility.Visible;
                    price.Text = roomprice;
                    editr.Visibility = Visibility.Visible;
                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (type.Text == "" || price.Text == "")
            {
                MessageBox.Show("Please fill all the details", "Error");
            }
            else
            {
                connection();
                int room = Convert.ToInt32(str);
                string comd = "update room set room_type='" + type.Text + "',price=" + price.Text + " where room_id = " + room + "";
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = comd;
                cmd1.ExecuteNonQuery();


                MessageBox.Show("Your room has Been Successfully Edited", "Edited Room");
                addroom.Visibility = Visibility.Visible;
                editroom.Visibility = Visibility.Visible;
                empdelete.Visibility = Visibility.Visible;
                maincancel.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Collapsed;
            }
        }
        private void deletesearch_Click(object sender, RoutedEventArgs e)
        {
            deletegrid.Visibility = Visibility.Visible;
            string str = delroomnumber.Text;
            if (str == "")
            {
                MessageBox.Show("Please fill all the details", "Error");
            }
            else
            {
                connection();
                string strsql = "select * from room where room_id =" + str + "";
                OracleDataAdapter da1 = new OracleDataAdapter(strsql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "set");
                DataTable dt1 = new DataTable();
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Room ID", "ERROR");
                    delroomnumber.Text = "";
                    search.Visibility = Visibility.Visible;
                }
                else
                {
                    string comd = "delete from room where  room_id= " + str + "";
                    OracleCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = comd;
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Your record has Been Successfully Deleted", "Deleted Record");
                    addroom.Visibility = Visibility.Visible;
                    editroom.Visibility = Visibility.Visible;
                    empdelete.Visibility = Visibility.Visible;
                    maincancel.Visibility = Visibility.Visible;
                    deletegrid.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void empdelete_Click(object sender, RoutedEventArgs e)
        {
            deletegrid.Visibility = Visibility.Visible;
            addroom.Visibility = Visibility.Collapsed;
            editroom.Visibility = Visibility.Collapsed;
            empdelete.Visibility = Visibility.Collapsed;
            maincancel.Visibility = Visibility.Collapsed;
        }

        private void addroom_Click(object sender, RoutedEventArgs e)
        {
            addroom.Visibility = Visibility.Collapsed;
            editroom.Visibility = Visibility.Collapsed;
            empdelete.Visibility = Visibility.Collapsed;
            maincancel.Visibility = Visibility.Collapsed;
            add.Visibility = Visibility.Visible;
        }
        private void maincancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manager h = new manager();
            h.Show();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            addroom.Visibility = Visibility.Visible;
            editroom.Visibility = Visibility.Visible;
            empdelete.Visibility = Visibility.Visible;
            maincancel.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Collapsed;
            deletegrid.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Collapsed;
        }
       
    }
}
