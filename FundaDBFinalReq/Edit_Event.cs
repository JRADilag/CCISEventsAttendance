﻿using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FundaDBFinalReq
{
    [Activity(Label = "Edit_Event", Theme = "@style/AppTheme", MainLauncher = false)]
    
    public class Edit_Event: Activity_Template
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.admin_edit_event);
            Initialize(Resource.Id.events);
            // Create your application here      

            Button cancel = FindViewById<Button>(Resource.Id.button1);
            cancel.Click += (s, e) => { Finish(); };
            Button submit = FindViewById<Button>(Resource.Id.button2);
            submit.Click += Submit;
            Button delete = FindViewById<Button>(Resource.Id.button3);
            delete.Click += Delete;

            String eventDetails = Intent.GetStringExtra("eventDetails");

            string[] eventDetailsArray = eventDetails.Split(",");

            FindViewById<EditText>(Resource.Id.event_name_edittxt).Text = eventDetailsArray[0];
            FindViewById<EditText>(Resource.Id.event_desc_edittxt).Text= eventDetailsArray[1];
            FindViewById<EditText>(Resource.Id.event_location_edittxt).Text = eventDetailsArray[3];
            FindViewById<EditText>(Resource.Id.event_start_edittxt).Text = eventDetailsArray[2];

        }
        public class EventToEdit
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

            String eventDetails = Intent.GetStringExtra("eventDetails");
            string[] eventDetailsArray = eventDetails.Split(",");

            EventToEdit editEvent = new EventToEdit
            {
                eventID = eventDetailsArray[4],
                eventName = FindViewById<EditText>(Resource.Id.event_name_edittxt).Text,
                eventLocation = FindViewById<EditText>(Resource.Id.event_location_edittxt).Text,
                eventDescription = FindViewById<EditText>(Resource.Id.event_desc_edittxt).Text,
                eventStart = FindViewById<EditText>(Resource.Id.event_start_edittxt).Text,
                eventEnd = FindViewById<EditText>(Resource.Id.event_end_edittxt).Text
            };

            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.EditData("system", "admin", "events", editEvent.eventID, editEvent.eventName, editEvent.eventLocation, editEvent.eventDescription, editEvent.eventStart, editEvent.eventEnd);
            //string datastring = databaseHandler.InsertData("system", "admin", "events", newEvent.eventName, newEvent.eventLocation, newEvent.eventDescription, newEvent.eventStart, newEvent.eventEnd);
            StartActivity(new Intent(this, typeof(Admin_Events)));
            Finish();
        }
    void Delete(object sender, EventArgs e)
        {

            String eventDetails = Intent.GetStringExtra("eventDetails");
            string[] eventDetailsArray = eventDetails.Split(",");
            string eventID = eventDetailsArray[4];

            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.DeleteData("system", "admin", "events", eventID);
            StartActivity(new Intent(this, typeof(Admin_Events)));
            Finish();
        }}
}