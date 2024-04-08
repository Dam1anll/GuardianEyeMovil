using GuardianEyeMovil.Models;
using GuardianEyeMovil.ViewModels.Camara;
using GuardianEyeMovil.Views.Camara;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using GuardianEyeMovil.Views.Registros;

namespace GuardianEyeMovil.ViewModels.Registros
{
    public class VMRegistros : BaseViewModel
    {
        #region VARIABLES
        //http://guardianeyeapi.somee.com/Api/Camara
        private ObservableCollection<MNotificacion> _listaNotificacion;
        #endregion
        #region CONSTRUCTOR
        public VMRegistros(INavigation navigation)
        {
            Navigation = navigation;
            ObtenerLista();
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
        public void ProcesoSimple()
        {

        }
        public async Task IrANotificacion(MNotificacion mNotificacion)
        {
            await Navigation.PushAsync(new VNotificacion(mNotificacion));
        }

        #endregion
        #region COMANDOS
        public ICommand IrANotificacionCommand => new Command<MNotificacion>(async (n) => await IrANotificacion(n));
        #endregion
    }
}
