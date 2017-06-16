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
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using RetoFinalXamarin.Models;
using System.Threading.Tasks;
using System.IO;
using Android.Util;

namespace RetoFinalXamarin.Services
{
    public class AzureService
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"http://xamchamp.azurewebsites.net");

        private IMobileServiceTable<Usuario> _TodoItemTable;
        private IMobileServiceTable<Viajes> _ViajeTable;

        public async Task InsertarEntidad(string user, string pwd)
        {
            _TodoItemTable = clienteServicio.GetTable<Usuario>();


            await _TodoItemTable.InsertAsync(new Usuario
            {
                Nombre = user,
                FacebookCode = pwd
            });
        }

        public async Task InsertarViaje(string destino, string aerolinea, string fecha)
        {
            _ViajeTable = clienteServicio.GetTable<Viajes>();


            await _ViajeTable.InsertAsync(new Viajes
            {
                Nombre = Constants.Nombre,
                Destino = destino,
                Fecha = fecha,
                Aerolinea = aerolinea
            });
        }
        public async Task<List<Viajes>> getViajes()
        {
            List<Viajes> res = new List<Viajes>();
            _ViajeTable = clienteServicio.GetTable<Viajes>();
            try
            {
                res = await _ViajeTable.Where(usuario => usuario.Nombre == Constants.Nombre).ToListAsync();
                return res;
            }
            catch (Exception e)
            {
                Log.WriteLine(LogPriority.Error, "ERROR", e.Message);
            }
            return null;
        }

        public async Task<bool> LoginUser(string user, string pwd)
        {
            List<Usuario> res = new List<Usuario>();
            _TodoItemTable = clienteServicio.GetTable<Usuario>();
            try
            {
                res = await _TodoItemTable.Where(usuario => usuario.Nombre == user).ToListAsync();
                if (res.Count > 0)
                    if (res[0].FacebookCode.Equals(pwd))
                    {
                        return true;
                    }
                else
                    return false;
            }
            catch (Exception e)
            {
                Log.WriteLine(LogPriority.Error, "ERROR", e.Message);
            }
            return false;
        }

        public async Task<bool> CorroborarUsuario(string user)
        {
            List<Usuario> res = new List<Usuario>();
            _TodoItemTable = clienteServicio.GetTable<Usuario>();
            try
            {
                res = await _TodoItemTable.Where(usuario => usuario.Nombre == user).ToListAsync();
                if (res.Count > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                Log.WriteLine(LogPriority.Error, "ERROR", e.Message);
            }
            return false;

            
        }
    }
}