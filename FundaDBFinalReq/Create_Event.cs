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
    [Activity(Label = "Create_Event", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Create_Event : Activity_Template
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.admin_create_event);
            Initialize(Resource.Id.events);
            // Create your application here      

            Button cancel = FindViewById<Button>(Resource.Id.button1);
            cancel.Click += (s, e) => { Finish(); } ;
        }
    }
}