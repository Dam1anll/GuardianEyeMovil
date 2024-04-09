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
            // Crear un objeto de usuario con los datos ingresados por el usuario
            var usuario = new Models.MUsuario
            {
                Correo = Correo,
                Contraseña = Contraseña
                // Puedes completar aquí con otros datos si es necesario
            };

            // Serializar el objeto de usuario a formato JSON
            var jsonUsuario = JsonConvert.SerializeObject(usuario);

            // Crear un cliente HTTP
            using (var client = new HttpClient())
            {
                // Establecer la URL del endpoint de registro de usuario
                var url = "http://guardianeyeapi.somee.com/Api/Usuario/register";

                try
                {
                    // Crear un contenido de solicitud HTTP con el objeto de usuario serializado
                    var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                    // Realizar una solicitud HTTP POST al endpoint de registro de usuario
                    var response = await client.PostAsync(url, content);

                    // Verificar si la solicitud fue exitosa (código de estado HTTP 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Mostrar un mensaje de éxito
                        await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado exitosamente.", "Aceptar");
                    }
                    else
                    {
                        // Mostrar un mensaje de error
                        await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar el usuario.", "Aceptar");
                    }
                }
                catch (Exception ex)
                {
                    // Capturar y manejar cualquier excepción
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
