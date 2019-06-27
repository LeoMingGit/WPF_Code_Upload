using System.Windows;
using System.Windows.Controls;

/*
 *  Written by Michele Cattafesta - http://www.mesta-automation.com
 *  This code is free, i'm not responsible on anything regarding it.
 *  You are free to do what you want with this code.
 */
namespace HmiExample.Pages
{
    /// <summary>
    /// This is the menu common to all pages
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }        

        private void btnGotoPage1_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page1());
        }

        private void btnGotoPage2_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page2());
        }
    }
}
