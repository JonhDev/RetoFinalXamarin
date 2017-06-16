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
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace RetoFinalXamarin.Models
{
    public class Viajes
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [JsonProperty("Destino")]
        public string Destino { get; set; }
        [JsonProperty("Aerolinea")]
        public string Aerolinea { get; set; }
        [JsonProperty("Fecha")]
        public string Fecha { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [Version]
        public string Version { get; set; }
    }
}