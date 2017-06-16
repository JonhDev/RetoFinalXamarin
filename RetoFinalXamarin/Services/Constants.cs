using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RetoFinalXamarin.Services
{
    public static class Constants
    {
        public static string AppUrl { get; set; } = @"http://xamchamp.azurewebsites.net";
        public static string DataBase { get; set; } = "syncstore.db";
        public static string Nombre { get; set; }
    }
}