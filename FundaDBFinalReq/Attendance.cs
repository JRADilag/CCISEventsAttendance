using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Time.Temporal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FundaDBFinalReq.Admin_Events;

namespace FundaDBFinalReq
{
    [Activity(Label = "Attendance")]
    public class Attendance : Activity_Template
    {

        public class Attendance_List: List<Students> { }
        public class Students 
        {
            public string studentID { get; set; }
            public string studentName { get; set; }
            public string eventID { get; set; }
            public string eventName { get; set; }

        }
        private Attendance_List ParseData(string wholeData)
        {
            Attendance_List attendance_list = new Attendance_List();
            if (wholeData != null)
            {
                string[] rows = wholeData.Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (string entry in rows)
                {
                    string[] studentEntry = entry.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    Students student = new Students()
                    {
                        studentID = studentEntry[0],
                        eventID = studentEntry[1],
                        studentName = studentEntry[2],
                        eventName = studentEntry[3]
                    };
                    attendance_list.Add(student);
                }
                return attendance_list;
            }
            return null;
        }

        private Events getEvents()
        {
            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetData("system", "admin", "events");

            Events events = new Events();
            string[] rows = datastring.Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (string entry in rows)
            {
                string[] eventEntry = entry.Split(",", StringSplitOptions.RemoveEmptyEntries);

                EventData eventData = new EventData
                {
                    eventID = eventEntry[0],
                    eventName = eventEntry[1],
                };
                events.Add(eventData);
            }
            return events;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.attendance);
            Initialize(Resource.Id.attendance);

            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetData("system", "admin", "attendance");

            Attendance_List eventList = ParseData(datastring);
            LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.main_ll);

            Spinner spinner = FindViewById <Spinner> (Resource.Id.spinner1);

            List<string> test = new List<string>();

            Events eventData = getEvents();
            foreach (EventData a in eventData)
            {
                test.Add(a.eventName);
            }

            ArrayAdapter<string> tst = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, test);
            spinner.Adapter = tst;

            // Handle item selection
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            //foreach (Students students in eventList)
            for (int i = 0; i < 20  && i < eventList.Count; i++)
            {
                Students students = eventList[i]; 
                View child = LayoutInflater.Inflate(Resource.Layout.attendance_card, null);
                TextView name = child.FindViewById<TextView>(Resource.Id.attendanceName);
                TextView eventname = child.FindViewById<TextView>(Resource.Id.attendanceEventName);

                name.Text = students.studentName;
                eventname.Text = students.eventName;

                ll.AddView(child);

            }

            void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
            {
            Spinner spinner = (Spinner)sender;
            string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
            Toast.MakeText(this, $"Selected: {selectedItem}", ToastLength.Short).Show();

            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetDataSorted("system", "admin", "attendance", selectedItem);

            }
        }

    }
}