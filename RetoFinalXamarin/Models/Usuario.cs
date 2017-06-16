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
using Microsoft.WindowsAzure.MobileServices;

namespace RetoFinalXamarin.Models
{
    public class Usuario
    {
        [Newtonsoft.Json.JsonProperty("Facecode")]
        public string FacebookCode { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string id { get; set; }

        [Newtonsoft.Json.JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [Version]
        public string Version { get; set; }


    }
}