using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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

            foreach (Students students in eventList)
            {
                View child = LayoutInflater.Inflate(Resource.Layout.attendance_card, null);
                TextView name = child.FindViewById<TextView>(Resource.Id.attendanceName);
                TextView eventname = child.FindViewById<TextView>(Resource.Id.attendanceEventName);

                name.Text = students.studentName;
                eventname.Text = students.eventName;

                ll.AddView(child);

            }
        }

    }
}