using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using RetoFinalXamarin.Services;
using System;
using RetoFinalXamarin.Models;

namespace RetoFinalXamarin
{
    [Activity(Label = "RetoFinalXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button registrar;
        TextView yaTiene;
        EditText usuario, pass;
        MobileServiceUser user;
        MobileServiceClient client;
        private IMobileServiceTable<Usuario> _TodoItemTable;
        public string faceCode { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            registrar = FindViewById<Button>(Resource.Id.btnRegistro);
            client = new MobileServiceClient(Constants.AppUrl);
            usuario = FindViewById<EditText>(Resource.Id.regUser);
            pass = FindViewById<EditText>(Resource.Id.regPwd);
            yaTiene = FindViewById<TextView>(Resource.Id.regYa);
            CurrentPlatform.Init();
            ChecarConexion();
            registrar.Click += async delegate
            {
                AzureService ser = new AzureService();
                var Noexiste = await ser.CorroborarUsuario(usuario.Text);
                if (!Noexiste)
                {
                    await ser.InsertarEntidad(usuario.Text, pass.Text);
                    Toast.MakeText(this, "Registrado :)", ToastLength.Short).Show();
                    StartActivity(typeof(LoginActivity));
                }
                else
                {
                    Toast.MakeText(this, "El usuario existe", ToastLength.Short).Show();
                    usuario.Text = "";
                    pass.Text = "";
                }
                
            };
            yaTiene.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += delegate
            {
                ChecarConexion();
            };
        }

        private void ChecarConexion()
        {
            if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "¡Tenemos conexión!", ToastLength.Short).Show();
                registrar.Enabled = true;
            }                
            else
            {
                Toast.MakeText(this, "¡No hay conexión a internet!\nconectate para continuar", ToastLength.Short).Show();
                registrar.Enabled = false;
            }
        }


        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}

