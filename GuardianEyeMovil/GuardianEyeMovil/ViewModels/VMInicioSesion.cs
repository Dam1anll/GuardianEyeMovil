using GuardianEyeMovil.Views;
using GuardianEyeMovil.Views.MenuDesplegable;
using GuardianEyeMovil.Views.RecuperarContraseña;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using GuardianEyeMovil.Models;

namespace GuardianEyeMovil.ViewModels
{
    public class VMInicioSesion : BaseViewModel
    {
        #region VARIABLES
        private string _correo;
        private string _contra;
        #endregion
        #region CONTRUCTOR
        public VMInicioSesion(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Correo
        {
            get { return _correo; }
            set { SetValue(ref _correo, value); }
        }
        public string Contra
        {
            get { return _contra; }
            set { SetValue(ref _contra, value); }
        }
        #endregion
        #region PROCESOS
        //public async Task IniciarSesion()
        //{
        //    try
        //    {
        //        var loginModel = new MUsuario
        //        {
        //            Correo = Correo,
        //            Contraseña = Contra
        //        };

        //        var json = JsonConvert.SerializeObject(loginModel);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        using (var httpClient = new HttpClient())
        //        {
        //            var response = await httpClient.PostAsync("http://guardianeyeapi.somee.com/Api/Usuario/login", content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var responseContent = await response.Content.ReadAsStringAsync();

        //                var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
        //                var token = tokenResponse.Token.Value;

        //                await IrAHome();
        //            }
        //            else
        //            {
        //                await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña incorrectos.", "OK");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}
        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new VRegistro());
        }
        public async Task IrSolicitud()
        {
            await Navigation.PushAsync(new VIngresarCorreo());
        }

        public async Task IrAHome()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            var paginaPrincipal = new NavigationPage(new VPaginaPrincipal());
            NavigationPage.SetHasBackButton(paginaPrincipal, false);
            Application.Current.MainPage = paginaPrincipal;
        }

        #endregion
        #region COMANDOS
        public ICommand IrARegistroCommand => new Command(async () => await IrARegistro());
        public ICommand IrAHomeCommand => new Command(async () => await IrAHome());
        public ICommand IrSolicitudCommand => new Command(async () => await IrSolicitud());
        //public ICommand IniciarSesionCommand => new Command(async () => await IniciarSesion());

        #endregion
    }
}
