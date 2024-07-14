using Android.App;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using static FundaDBFinalReq.Admin_Events;

namespace FundaDBFinalReq
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText username_edit_text;
        EditText password_edit_text;
        Button login_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            username_edit_text = FindViewById<EditText>(Resource.Id.username_edittxt);
            password_edit_text = FindViewById<EditText>(Resource.Id.password_edittxt);
            login_button = FindViewById<Button>(Resource.Id.login_btn);

            login_button.Click += Login;
        }
        public void Login(object sender, EventArgs e)
        {
            DatabaseHander databaseHandler;
            databaseHandler = new DatabaseHander(this);
            string datastring = databaseHandler.GetDataLogin("system", "admin", "events", username_edit_text.Text, password_edit_text.Text);

            if (datastring == "1")
            {
                Intent i = new Intent(this, typeof(Admin_Home));
                string datum = $"{username_edit_text.Text}";
                i.PutExtra("data", datum);
                StartActivity(i);

            }
            else
            {
                Toast.MakeText(this, datastring, ToastLength.Short).Show();

            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}