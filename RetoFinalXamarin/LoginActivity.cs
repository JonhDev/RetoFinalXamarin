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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        Button iniciar;
        EditText user, pass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            iniciar = FindViewById<Button>(Resource.Id.btnIniciar);
            user = FindViewById<EditText>(Resource.Id.logUser);
            pass = FindViewById<EditText>(Resource.Id.logPwd);

            iniciar.Click += async delegate
            {
                AzureService azure = new AzureService();
                var login = await azure.LoginUser(user.Text, pass.Text);
                if (login)
                {
                    Constants.Nombre = user.Text;
                    StartActivity(typeof(ViajesActivity));
                }
                else
                    Toast.MakeText(this, "Mal logeado", ToastLength.Short).Show();
            };
            // Create your application here
        }
    }
}