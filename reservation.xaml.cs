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
    public sealed partial class reservation : Page
    {
        public reservation()
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
            custadd.Visibility = Visibility.Collapsed;
            addcustomer.Visibility = Visibility.Visible;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Your room has Been Successfully Reserved", "Room Reserved");
            msg.ShowAsync();
            custadd.Visibility = Visibility.Visible;
            addcustomer.Visibility = Visibility.Collapsed;
            cid.Text = "";
            name.Text = "";
            cell.Text = "";
            pno.Text = "";
            address.Text = "";
            start.Text = "";
            end.Text = "";
            rid.Text = "";
        }
    }
}
