using Android.App;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

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
            Intent i = new Intent(this, typeof(Admin_Home));
            StartActivity(i);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}