using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using Google.Android.Material.BottomNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundaDBFinalReq
{
    [Activity(Label = "Admin_Home", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Admin_Home : Activity_Template
    {

        DatabaseHander databaseHandler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.admin_home);
            Initialize(Resource.Id.home);

            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetData();

            TextView tv = FindViewById<TextView>(Resource.Id.textView2);
            tv.Text = datastring;
            //CardView cw = new CardView(this);
            //cw.set

            //LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            //ll.AddView(cw);

        }
    }
}