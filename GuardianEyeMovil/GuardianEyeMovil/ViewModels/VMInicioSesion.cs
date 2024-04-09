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
        public async Task IniciarSesion()
        {
            var credenciales = new LoginModel
            {
                Correo = Correo,
                Contraseña = Contra
            };

            var jsonCredenciales = JsonConvert.SerializeObject(credenciales);

            using (var client = new HttpClient())
            {
                var url = "http://guardianeyeapi.somee.com/Api/Usuario/login";

                try
                {
                    var content = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var tokenJson = await response.Content.ReadAsStringAsync();
                        var token = JsonConvert.DeserializeObject<TokenResponse>(tokenJson);

                        AppSettings.Token = token.Token;

                        await IrAHome();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Credenciales incorrectas", "Aceptar");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
                }
            }
        }
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
        public ICommand IniciarSesionCommand => new Command(async () => await IniciarSesion());

        #endregion
    }
}
