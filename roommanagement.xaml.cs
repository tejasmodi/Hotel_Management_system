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
    public sealed partial class roommanagement : Page
    {
        public roommanagement()
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
            addroom.Visibility = Visibility.Collapsed;
            editroom.Visibility = Visibility.Collapsed;
            add.Visibility = Visibility.Visible;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Your room has Been Successfully Added", "Added Room");
            msg.ShowAsync();
            addroom.Visibility = Visibility.Visible;
            editroom.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Collapsed;
        }
        private void empedit_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            addroom.Visibility = Visibility.Collapsed;
            editroom.Visibility = Visibility.Collapsed; 
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            string str = rid.Text;
            if (str == "1234")
            {
                search.Visibility = Visibility.Collapsed;
                edityesno.Visibility = Visibility.Visible;
                edityesno.Text = "The record Exists ..... Please enter new data";
                editno.Visibility = Visibility.Visible;
                roomid.Visibility = Visibility.Collapsed;
                rid.Visibility = Visibility.Collapsed;
                edittype.Visibility = Visibility.Visible;
                editmanager.Visibility = Visibility.Visible;
                editprice.Visibility = Visibility.Visible;
                no.Visibility = Visibility.Visible;
                type.Visibility = Visibility.Visible;
                manager.Visibility = Visibility.Visible;
                price.Visibility = Visibility.Visible;
                editr.Visibility = Visibility.Visible;
            }
            else
            {
                MessageDialog msg = new MessageDialog("Entered Room does not exist", "Room not Present");
                msg.ShowAsync();
                rid.Text = "";
                search.Visibility = Visibility.Visible;
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Your room has Been Successfully Edited", "Edited Room");
            msg.ShowAsync();
            addroom.Visibility = Visibility.Visible;
            editroom.Visibility = Visibility.Visible;
            edit.Visibility = Visibility.Collapsed;
        }
    }
}
