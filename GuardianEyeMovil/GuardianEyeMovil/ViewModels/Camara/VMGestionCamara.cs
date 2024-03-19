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
                var confirmarEliminar = await DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar esta cámara?", "Sí", "No");
                if (confirmarEliminar)
                {
                    Uri request = new Uri("http://guardianeyeapi.somee.com/Api/Camara/" + Id);
                    var client = new HttpClient();
                    var response = await client.DeleteAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Mensaje", "Cámara eliminada correctamente", "Ok");
                        MessagingCenter.Send(this, "ActualizarListaCamaras");
                        await Volver();
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Error al eliminar la cámara", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        public async Task EditarCamara()
        {
            try
            {
                MCamara editarCamara = new MCamara()
                {
                    Ubicacion = Ubicacion,
                    Estado = Estado,
                    Modelo = Modelo,
                };

                Uri Request = new Uri("http://guardianeyeapi.somee.com/Api/Camara/" + Id);
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(editarCamara);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(Request, content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Cámara actualizada correctamente", "Ok");
                    MessagingCenter.Send(this, "ActualizarListaCamaras");
                    await Volver();
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error al actualizar la cámara", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async Task Volver()
        {
            Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand EditarCamaraCommand => new Command(async () => await EditarCamara());

        #endregion

    }
}
