using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundaDBFinalReq
{
    [Activity(Label = "Activity_Template")]
    public class Activity_Template : Activity
    {
        BottomNavigationView navbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_template);            


            // Create your application here
        }
        protected void Initialize(int id)
        {
            Intent toHome = new Intent(this, (typeof(Admin_Home)));
            toHome.SetFlags(ActivityFlags.ReorderToFront);
            Intent toEvents = new Intent(this, (typeof(Admin_Events)));
            toEvents.SetFlags(ActivityFlags.ReorderToFront);
            Intent toAttendance = new Intent(this, (typeof(Attendance)));
            toAttendance.SetFlags(ActivityFlags.ReorderToFront);
            navbar = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigationView1);
            navbar.Menu.FindItem(id).SetChecked(true);
            navbar.Menu.FindItem(Resource.Id.home).SetIntent(toHome);
            navbar.Menu.FindItem(Resource.Id.events).SetIntent(toEvents);
            navbar.Menu.FindItem(Resource.Id.attendance).SetIntent(toAttendance);

            navbar.Menu.FindItem(id).SetIntent(null);
        }
        
    }
}