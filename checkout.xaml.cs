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
    public sealed partial class checkout : Page
    {
        public checkout()
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

        private void checkoutbox_Click(object sender, RoutedEventArgs e)
        {
            string str=rid.Text;
            if (str == "1234")
            {
                roomconfirm.Visibility = Visibility.Collapsed;
                bill.Visibility = Visibility.Visible;
                final.Text = "1200";
            }
            else
            {
                MessageDialog msg = new MessageDialog("Sorry Invalid RoomID has Been Entered", "CHECKOUT UNSUCCESSFUL");
                msg.ShowAsync(); 
            }
            rid.Text = "";
        }

        private void finalconfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("You have Been Successfully Checked Out", "CHECKOUT SUCCESSFUL");
            msg.ShowAsync();
            this.Frame.Navigate(typeof(Home));
        }
    }
}
