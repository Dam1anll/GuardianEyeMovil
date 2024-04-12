using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GuardianEyeMovil.Views;
using GuardianEyeMovil.Views.RecuperarContraseña;
using System.Net.Http;
using Newtonsoft.Json;

namespace GuardianEyeMovil.ViewModels
{
    public class VMRegistro : BaseViewModel
    {
        #region VARIABLES
        private string _correo;
        private string _contraseña;
        #endregion
        #region CONTRUCTOR
        public VMRegistro(INavigation navigation)
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
            get { return _contraseña; }
            set { SetValue(ref _contraseña, value); }
        }
        #endregion
        #region PROCESOS
        public async Task RegistrarUsuario()
        {
            var usuario = new Models.MUsuario
            {
                Correo = Correo,
                Contraseña = Contraseña
            };

            var jsonUsuario = JsonConvert.SerializeObject(usuario);

            using (var client = new HttpClient())
            {
                var url = "http://guardianeyeapi.somee.com/Api/Usuario/register";

                try
                {
                    var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado exitosamente.", "Aceptar");
                        await IrAInicioSesion();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar el usuario.", "Aceptar");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
                }
            }
        }
        public async Task IrAInicioSesion()
        {
            await Navigation.PushAsync(new VInicioSesion());
        }
        #endregion
        #region COMANDOS
        public ICommand IrAInicioSesionCommand => new Command(async () => await IrAInicioSesion());
        public ICommand RegistrarUsuarioCommand => new Command(async () => await RegistrarUsuario());
        #endregion
    }
}
