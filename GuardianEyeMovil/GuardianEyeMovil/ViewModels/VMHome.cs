using GuardianEyeMovil.Models;
using GuardianEyeMovil.Views.Registros;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Microcharts;
using System.Linq;

namespace GuardianEyeMovil.ViewModels
{
    public class VMHome : BaseViewModel
    {
        #region VARIABLES
        //http://guardianeyeapi.somee.com/Api/Camara
        private ObservableCollection<MNotificacion> _listaNotificacion;
        #endregion
        #region CONSTRUCTOR
        public VMHome(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<MNotificacion> ListaNotificacion
        {
            get { return _listaNotificacion; }
            set
            {
                SetValue(ref _listaNotificacion, value);
                OnpropertyChanged();
            }

        }
        #endregion
        #region PROCESOS
        public async Task ObtenerLista()
        {
            Uri RequestUri = new Uri("http://guardianeyeapi.somee.com/Api/Notificacion");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ListaNotificacion = JsonConvert.DeserializeObject<ObservableCollection<MNotificacion>>(content);
            }
            else
            {
                await DisplayAlert("Mensaje", "Error al cargar la lista de Notificaciones", "Ok");
            }
        }

        #endregion
        #region COMANDOS
        #endregion
    }
}
