using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using GuardianEyeMovil.Models;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.Views.Camara;
using GuardianEyeMovil.ViewModels.Camara;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuardianEyeMovil.ViewModels.Camara
{
    public class VMListaCamaras : BaseViewModel
    {
        #region VARIABLES
        //http://guardianeyeapi.somee.com/Api/Camara
        private ObservableCollection<MCamara> _listaCamaras;
        #endregion
        #region CONSTRUCTOR
        public VMListaCamaras(INavigation navigation)
        {
            Navigation = navigation;
            ObtenerLista();

            MessagingCenter.Subscribe<VMAgregarCamara>(this, "ActualizarListaCamaras", async (sender) =>
            {
                await ObtenerLista();
            });

            MessagingCenter.Subscribe<VMGestionCamara>(this, "ActualizarListaCamaras", async (sender) =>
            {
                await ObtenerLista();
            });
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<MCamara> ListaCamaras
        {
            get { return _listaCamaras; }
            set
            {
                SetValue(ref _listaCamaras, value);
                OnpropertyChanged();
            }

        }
        #endregion
        #region PROCESOS
        public async Task ObtenerLista()
        {
            Uri RequestUri = new Uri("http://guardianeyeapi.somee.com/Api/Camara");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ListaCamaras = JsonConvert.DeserializeObject<ObservableCollection<MCamara>>(content);
            }
            else
            {
                await DisplayAlert("Mensaje", "Error al cargar la lista de Cámaras", "Ok");
            }
        }
        public void ProcesoSimple()
        {

        }
        public async Task IrAAgregarCamara()
        {
            await Navigation.PushAsync(new VAgregarCamara());
        }

        public async Task IrAGestionCamara(MCamara mCamara)
        {
            await Navigation.PushAsync(new VGestionCamara(mCamara));
        }

        #endregion
        #region COMANDOS
        public ICommand IrAAgregarCamaraCommand => new Command(async () => await IrAAgregarCamara());
        public ICommand IrAGestionCamaraCommand => new Command<MCamara>(async (a) => await IrAGestionCamara(a));
        #endregion
    }
}
