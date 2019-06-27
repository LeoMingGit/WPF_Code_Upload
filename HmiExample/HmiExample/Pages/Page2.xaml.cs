#region Using
using System;
using System.Windows.Controls;
using HmiExample.PlcDriver;
using System.Windows.Threading; 
#endregion

/*
 *  Written by Michele Cattafesta - http://www.mesta-automation.com
 *  This code is free, i'm not responsible on anything regarding it.
 *  You are free to do what you want with this code.
 */
namespace HmiExample.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();  //this timer is synchronized with GUI

        public Page2()
        {
            InitializeComponent();
                timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            timer_Tick(null, null); //this will refresh the textboxes before you show the page
        }

        /// <summary>
        /// Refresh GUI
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            txtCount.Text = Plc.MyPlcVariable.ToString();
        }

        /// <summary>
        /// Release resources:
        /// - the DispatcherTimer must be released when UserControl is closed, else it will cause a memory leak.
        ///   ref: http://geekswithblogs.net/dotnetrodent/archive/2009/11/05/136015.aspx        /// 
        /// </summary>        
        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
