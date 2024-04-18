using Amazon.Runtime.Internal.Auth;
using GuardianEyeMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace GuardianEyeMovil.ViewModels.Camara
{
    public class VMGestionCamara : BaseViewModel
    {
        #region VARIABLES
        private string _id;
        private string _ubicacion;
        private string _estado;
        private string _modelo;
        public MCamara _MCamara { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMGestionCamara(INavigation navigation, MCamara mCamara)
        {
            Navigation = navigation;
            _MCamara = mCamara;
            CargarDatosCamara(mCamara);
        }
        #endregion
        #region OBJETOS

        public string Id
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }

        public string Ubicacion
        {
            get { return _ubicacion; }
            set { SetValue(ref _ubicacion, value); }
        }
        public string Estado
        {
            get { return _estado; }
            set { SetValue(ref _estado, value); }
        }
        public string Modelo
        {
            get { return _modelo; }
            set { SetValue(ref _modelo, value); }
        }
        #endregion
        #region PROCESOS

        private void CargarDatosCamara(MCamara mCamara)
        {
            Id = mCamara.Id;
            Ubicacion = mCamara.Ubicacion;
            Estado = mCamara.Estado;
            Modelo = mCamara.Modelo;
        }
        public async Task EliminarCamara()
        {
            try
            {
                bool confirmarEliminar = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar esta cámara?", "Sí", "No");
                if (confirmarEliminar)
                {
                    Uri requestUri = new Uri($"http://guardianeyeapi.somee.com/Api/Camara/{Id}");
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.DeleteAsync(requestUri);
                        if (response.IsSuccessStatusCode)
                        {
                            await Application.Current.MainPage.DisplayAlert("Mensaje", "Cámara eliminada correctamente", "Ok");
                            MessagingCenter.Send(this, "ActualizarListaCamaras");
                            await Volver();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Mensaje", "Error al eliminar la cámara", "Ok");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public async Task EditarCamara()
        {
            try
            {
                MCamara editarCamara = new MCamara()
                {
                    Id = Id,
                    Ubicacion = Ubicacion,
                    Estado = Estado,
                    Modelo = Modelo
                };

                Uri requestUri = new Uri($"http://guardianeyeapi.somee.com/Api/Camara/{Id}");
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(editarCamara);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(requestUri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.DisplayAlert("Mensaje", "Cámara actualizada correctamente", "Ok");
                        MessagingCenter.Send(this, "ActualizarListaCamaras");
                        await Volver();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Mensaje", "Error al actualizar la cámara", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async Task Volver()
        {
            Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand EditarCamaraCommand => new Command(async () => await EditarCamara());
        public ICommand EliminarCamaraCommand => new Command(async () => await EliminarCamara());

        #endregion

    }
}
