using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HotelManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class employeemanagement : Page
    {
        public employeemanagement()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(employeemanagement));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(roommanagement));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(reservation));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(checkout));
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("You have Been Successfully Logged Out", "LOG OUT");
            msg.ShowAsync();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            empadd.Visibility = Visibility.Collapsed;
            empedit.Visibility = Visibility.Collapsed;
            addemployee.Visibility = Visibility.Visible;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Your record has Been Successfully Added", "Added Record");
            msg.ShowAsync();
            empadd.Visibility = Visibility.Visible;
            empedit.Visibility = Visibility.Visible;
            addemployee.Visibility = Visibility.Collapsed;
        }

        private void empedit_Click(object sender, RoutedEventArgs e)
        {
            editemployee.Visibility = Visibility.Visible;
            empadd.Visibility = Visibility.Collapsed;
            empedit.Visibility = Visibility.Collapsed; 
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            editemployee.Visibility = Visibility.Visible;
            string str = employeenumber.Text;
            if (str == "1234")
            {
                search.Visibility = Visibility.Collapsed;
                edityesno.Visibility = Visibility.Visible;
                edityesno.Text = "The record Exists ..... Please enter new data";
                editno.Visibility = Visibility.Visible;
                empno.Visibility = Visibility.Collapsed;
                employeenumber.Visibility = Visibility.Collapsed;
                editname.Visibility = Visibility.Visible;
                editmanager.Visibility = Visibility.Visible;
                editaddress.Visibility = Visibility.Visible;
                editpno.Visibility = Visibility.Visible;
                no.Visibility = Visibility.Visible;
                name.Visibility = Visibility.Visible;
                manager.Visibility = Visibility.Visible;
                address.Visibility = Visibility.Visible;
                pno.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageDialog msg = new MessageDialog("Entered employee record does not exist", "Record not Present");
                msg.ShowAsync();
                employeenumber.Text = "";
                search.Visibility = Visibility.Visible;
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Your record has Been Successfully Edited", "Edited Record");
            msg.ShowAsync();
            empadd.Visibility = Visibility.Visible;
            empedit.Visibility = Visibility.Visible;
            editemployee.Visibility = Visibility.Collapsed;
        }
        
    }
}
