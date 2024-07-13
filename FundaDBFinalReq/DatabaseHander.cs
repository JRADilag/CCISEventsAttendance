using Android.App;
using Android.Content;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FundaDBFinalReq
{
    internal class DatabaseHander
    {

        HttpWebResponse response;
        HttpWebRequest request;
        string res = "";
        Context context;

        public DatabaseHander(Context currentContext)
        {
            context = currentContext;
        }

        public string GetData()
        {
            string username = "system";
            string password = "admin";
            string xamppIP = "192.168.56.1";
            string url = $"http://{xamppIP}/Database.php/?username={username}&password={password}";

            // DATABASE.PHP MUST BE IN HTDOCS FOLDER

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            return res;
        }

    }
}