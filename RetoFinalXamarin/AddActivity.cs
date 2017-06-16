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
using RetoFinalXamarin.Services;

namespace RetoFinalXamarin
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        EditText destino, aero, fecha;
        Button add;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addViaje);

            destino = FindViewById<EditText>(Resource.Id.destinoedit);
            aero = FindViewById<EditText>(Resource.Id.aerolineaedit);
            fecha = FindViewById<EditText>(Resource.Id.fechaedit);
            add = FindViewById<Button>(Resource.Id.buttonadd);

            add.Click += async delegate
            {
                AzureService azure = new AzureService();
                await azure.InsertarViaje(destino.Text, aero.Text, fecha.Text);
                Finish();
            };

            // Create your application here
        }
    }
}