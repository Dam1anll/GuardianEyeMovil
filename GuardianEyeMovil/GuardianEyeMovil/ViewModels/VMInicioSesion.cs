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
        public string Contraseña
        {
            get { return _contra; }
            set { SetValue(ref _contra, value); }
        }
        #endregion
        #region PROCESOS
       
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

        private async Task IniciarSesion()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = "http://guardianeyeapi.somee.com/Api/Usuario/login";

                var loginData = new
                {
                    Correo = Correo,
                    Contraseña = Contraseña
                };

                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<TokenResponse>(responseContent).Token;
                    await IrAHome();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña incorrectas", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public class TokenResponse
        {
            public string Token { get; set; }
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
