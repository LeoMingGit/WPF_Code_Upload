using System.Windows.Controls;

namespace HmiExample
{
  	public static class Switcher
  	{
        public static MainWindow pageSwitcher;

    	public static void Switch(UserControl newPage)
    	{
      		pageSwitcher.Navigate(newPage);
    	}    	
  	}
}
