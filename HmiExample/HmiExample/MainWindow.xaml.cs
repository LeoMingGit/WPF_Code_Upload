using System.Windows;
using System.Windows.Controls;
using HmiExample.Pages;
using HmiExample.PlcDriver;

/*
 *  Written by Michele Cattafesta - http://www.mesta-automation.com
 *  This code is free, i'm not responsible on anything regarding it.
 *  You are free to do what you want with this code.
 */
namespace HmiExample
{
    /// <summary>
    /// Main Page: here i start the communication
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new Page1());
            Plc.StartCommunication();
        }

        /// <summary>
        /// PageSwitcher support
        /// </summary>       
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        /// <summary>
        /// Closing the communication before quitting
        /// </summary>  
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Plc.StopCommunication = true;
        }     
    }
}
