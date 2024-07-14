﻿using Android.App;
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
            cancel.Click += (s, e) => { Finish(); };
            Button submit = FindViewById<Button>(Resource.Id.button2);
            submit.Click += Submit;
        }
        public class Event
        {
            public string eventID { get; set; }
            public string eventName { get; set; }
            public string eventLocation { get; set; }
            public string eventDescription { get; set; }
            public string eventStart { get; set; }
            public string eventEnd { get; set; }
        }
        void Submit(object sender, EventArgs e)
        {
            Event newEvent = new Event
            {
                eventName = FindViewById<EditText>(Resource.Id.createEventName).Text,
                eventLocation = FindViewById<EditText>(Resource.Id.createEventLocation).Text,
                eventDescription = FindViewById<EditText>(Resource.Id.createEventDescription).Text,
                eventStart = FindViewById<EditText>(Resource.Id.createEventStart).Text,
                eventEnd = FindViewById<EditText>(Resource.Id.createEventEnd).Text,
            };

            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.InsertData("system", "admin", "events", newEvent.eventName, newEvent.eventLocation, newEvent.eventDescription, newEvent.eventStart, newEvent.eventEnd);
            StartActivity(new Intent(this, typeof(Admin_Events)));
            Finish();
        }
    }
}