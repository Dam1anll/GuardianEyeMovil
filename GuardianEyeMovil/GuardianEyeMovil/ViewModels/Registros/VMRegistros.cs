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
using Microcharts;
using Telegram.Bot;

namespace GuardianEyeMovil.ViewModels.Registros
{
    public class VMRegistros : BaseViewModel
    {
        #region VARIABLES
        //http://guardianeyeapi.somee.com/Api/Camara
        private ObservableCollection<MNotificacion> _listaNotificacion;
        private ITelegramBotClient _botClient;
        #endregion
        #region CONSTRUCTOR
        public VMRegistros(INavigation navigation)
        {
            Navigation = navigation;
            _botClient = new TelegramBotClient("");
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
        public ITelegramBotClient BotClient 
        {
            get { return _botClient; }
            set { SetValue(ref _botClient, value);}
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

        public async Task CrearNotificacion()
        {
            string mensajePredeterminado = "Se ha detectado movimiento sospechoso en su hogar!, mantengase alerta y llame a las autoridades si es necesario.";

            var nuevaNotificacion = new MNotificacion
            {
                Fecha = DateTime.Now,
                Mensaje = mensajePredeterminado,
                Imagen = string.Empty,
                Tipo = "Advertencia",
                Video = string.Empty,
                Titulo = "Notificación de Advertencia"
            };

            var client = new HttpClient();

            string jsonContent = JsonConvert.SerializeObject(nuevaNotificacion);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://guardianeyeapi.somee.com/Api/Notificacion", httpContent);

            if (response.IsSuccessStatusCode)
            {
                await ObtenerLista();
                await EnviarNotificacionTelegram(nuevaNotificacion);
            }
            else
            {
                await DisplayAlert("Error", "Hubo un problema al crear la notificación.", "Aceptar");
            }
        }

        public async Task EnviarNotificacionTelegram(MNotificacion nuevaNotificacion)
        {
            const string chatId = "";
            var mensajeTelegram = new StringBuilder();
            mensajeTelegram.AppendLine(nuevaNotificacion.Mensaje);

            if (!string.IsNullOrEmpty(nuevaNotificacion.Imagen))
            {
                mensajeTelegram.AppendLine($"[Ver imagen]({nuevaNotificacion.Imagen})");
            }

            if (!string.IsNullOrEmpty(nuevaNotificacion.Video))
            {
                mensajeTelegram.AppendLine($"[Ver video]({nuevaNotificacion.Video})");
            }

            await _botClient.SendTextMessageAsync(chatId, mensajeTelegram.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
        public async Task IrANotificacion(MNotificacion mNotificacion)
        {
            await Navigation.PushAsync(new VNotificacion(mNotificacion));
        }

        #endregion
        #region COMANDOS
        public ICommand IrANotificacionCommand => new Command<MNotificacion>(async (n) => await IrANotificacion(n));
        public ICommand CrearANotificacionCommand => new Command(async () => await CrearNotificacion());
        #endregion
    }
}
