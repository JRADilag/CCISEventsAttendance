using Android.App;
using Android.Content;
using Android.Media.Metrics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace FundaDBFinalReq
{
    [Activity(Label = "Admin_Events")]
    public class Admin_Events : Activity_Template
    {

        public class Events : List<EventData> { }
        public class EventData 
        {
            public string eventID { get; set; }
            public string eventName { get; set; }
            public string eventLocation { get; set; }
            public string eventDescription { get; set; }
            public string eventStart { get; set; }
            public string eventEnd { get; set; }
        }
        public Events ParseData(string wholeData)
        {
            Events events = new Events();
            if (wholeData != null){
                string[] rows = wholeData.Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (string entry in rows)
                {
                    string[] eventEntry = entry.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    EventData eventData = new EventData
                    {
                        eventID = eventEntry[0],
                        eventName = eventEntry[1],
                        eventLocation = eventEntry[2],
                        eventDescription = eventEntry[3],
                        eventStart = eventEntry[4],
                        eventEnd = eventEntry[5]
                    };
                    events.Add(eventData);
                }
                return events;
            }
            return null;
        }

        private void toAddEvent(object sender, EventArgs e)
        {
            Intent createEvent = new Intent(this, (typeof(Create_Event)));
            StartActivity(createEvent);
            Finish();
        }
        public void populateEvents()
        {
            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetData("system", "admin", "events");
            Events eventList = ParseData(datastring);
            LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.main_ll);
            foreach (EventData eventData in eventList)
            {
                View child = LayoutInflater.Inflate(Resource.Layout.event_card, null);
                TextView name = child.FindViewById<TextView>(Resource.Id.eventName);
                TextView description = child.FindViewById<TextView>(Resource.Id.eventDescription);
                TextView timedate = child.FindViewById<TextView>(Resource.Id.eventTimeDate);
                TextView loc = child.FindViewById<TextView>(Resource.Id.eventLocation);

                child.Click += (s, e) => {

                    Intent editEvent = new Intent(this, (typeof(Edit_Event)));

                    string details = $"{name.Text},{description.Text},{timedate.Text},{loc.Text},{eventData.eventID.ToString()}";
                    editEvent.PutExtra("eventDetails", details);
                    StartActivity(editEvent);
                    Finish();
                
                };

                description.Text = eventData.eventDescription;
                timedate.Text = $"{eventData.eventStart.Substring(0, 15)} {eventData.eventStart.Substring(26, 2)}";
                loc.Text = eventData.eventLocation;
                name.Text = eventData.eventName;
                ll.AddView(child);

            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.admin_event);
            Initialize(Resource.Id.events);
            
            Button addEvent = FindViewById<Button>(Resource.Id.event_create);
            addEvent.Click += toAddEvent;

            populateEvents();
        }
            }
}