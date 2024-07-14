using Android.App;
using Android.Content;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        string xamppIP = "192.168.56.1";


        public DatabaseHander(Context currentContext)
        {
            context = currentContext;
        }

        public string GetData(string username, string password, string page)
        {
                        // DATABASE.PHP MUST BE IN HTDOCS FOLDER

            string url = $"http://{xamppIP}/Database.php/?username={username}&password={password}&page={page}";
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            return res;
        }

        public string InsertData(string username, string password, string page, string evname, string evloc, string evdesc, string evstart, string evend)
        {
            //string url = $"http://{xamppIP}/DatabaseInsert.php/?username={username}&password={password}&page={page}&evname={evname}&evloc={evloc}&evdesc={evdesc}&evstart={evstart}&evedn={evend}";
            string url = $"http://{xamppIP}/DatabaseInsert.php/?username={username}&password={password}&page={page}&evname={evname}&evloc={evloc}&evdesc={evdesc}";
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            return res;
        }

    }
}