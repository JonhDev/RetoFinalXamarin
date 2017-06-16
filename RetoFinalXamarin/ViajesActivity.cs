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
using System.Threading.Tasks;

namespace RetoFinalXamarin
{
    [Activity(Label = "ViajesActivity")]
    public class ViajesActivity : Activity
    {
        Button add, get;
        EditText list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViajesActivity);
            add = FindViewById<Button>(Resource.Id.agregar);
            get = FindViewById<Button>(Resource.Id.actualizar);
            list = FindViewById<EditText>(Resource.Id.lista);

            Cargar();

            add.Click += delegate
            {
                StartActivity(typeof(AddActivity));
            };

            get.Click += async delegate
            {
                await Cargar();
            };
        }

        private async Task Cargar()
        {
            AzureService azure = new AzureService();
            var l = await azure.getViajes();
            list.Text = "";
            foreach (var item in l)
            {
                list.Append($"{item.Aerolinea} con destino a {item.Destino} en la fecha {item.Fecha} \n");
            }
        }
    }
}