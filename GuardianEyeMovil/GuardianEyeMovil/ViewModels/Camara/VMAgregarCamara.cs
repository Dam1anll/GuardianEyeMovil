using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GuardianEyeMovil.Models;
using Newtonsoft.Json;
using System.Net;

namespace GuardianEyeMovil.ViewModels.Camara
{
    public class VMAgregarCamara : BaseViewModel
    {
        #region VARIABLES
        private string _ubicacion;
        private string _estado;
        private string _modelo;

        ObservableCollection<MCamara> _listaCamaras;
        #endregion
        #region CONSTRUCTOR
        public VMAgregarCamara(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<MCamara> ListaCamaras
        {
            get { return _listaCamaras; }
            set
            {
                _listaCamaras = value;
                OnPropertyChanged();
            }
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
        public async Task AgregarCamara()
        {
            try 
            {
                MCamara nuevaCamara = new MCamara()
                {
                    Ubicacion = Ubicacion,
                    Estado = Estado,
                    Modelo = Modelo
                };

                var requestUri = "http://guardianeyeapi.somee.com/Api/Camara";
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(nuevaCamara);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Camara agregada correctamente", "Ok");
                    MessagingCenter.Send(this, "ActualizarListaCamaras");
                    await Volver();
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error al agregar la camara", "Ok");
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
        public ICommand AgregarCamaraCommand => new Command(async () => await AgregarCamara());
        #endregion
    }
}
