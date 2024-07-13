using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundaDBFinalReq
{
    public class NavBarHandler
    {
        static public void NavBar_Click(object sender, EventArgs e)
        {
            BottomNavigationView navbar = (BottomNavigationView)sender;
            BottomNavigationMenu navmenu = (BottomNavigationMenu)sender;
            string thing = navmenu.FindItem(navbar.SelectedItemId).TitleFormatted.ToString();
            // Console.WriteLine(thing)
        }
    }
}