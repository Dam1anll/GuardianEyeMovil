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
using SkiaSharp;
using GuardianEyeMovil.Views.MenuDesplegable;
using Microcharts.Forms;

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

        public async Task CalcularNotificacionesPorHora(ChartView notificationChart)
        {
            // Dicionario para agrupar notificaciones por hora
            var notificacionesPorHora = new Dictionary<int, int>();

            // Agrupa las notificaciones por la hora de su fecha
            foreach (var notificacion in ListaNotificacion)
            {
                int hora = notificacion.Fecha.Hour;

                if (notificacionesPorHora.ContainsKey(hora))
                {
                    notificacionesPorHora[hora]++;
                }
                else
                {
                    notificacionesPorHora[hora] = 1;
                }
            }

            // Convierte los datos en una lista de ChartEntry para la gráfica
            List<ChartEntry> entries = new List<ChartEntry>();
            foreach (var item in notificacionesPorHora.OrderBy(kvp => kvp.Key))
            {
                entries.Add(new ChartEntry(item.Value)
                {
                    Label = $"{item.Key}:00",
                    ValueLabel = item.Value.ToString(),
                    Color = SKColor.Parse("#1da1f2") // Elige un color para las barras
                });
            }

            // Configura la gráfica como un gráfico de líneas
            var chart = new LineChart()
            {
                Entries = entries,
                BackgroundColor = SKColor.Parse("#141414"),
                LineMode = LineMode.Straight,
                LineSize = 10,
                PointMode = PointMode.Square,
                PointSize = 20,
                LabelOrientation = Microcharts.Orientation.Horizontal,
                ValueLabelOrientation = Microcharts.Orientation.Horizontal,
                LabelTextSize = 30
            };

            // Asigna el gráfico configurado al control ChartView
            notificationChart.Chart = chart;
        }

        #endregion
        #region COMANDOS
        #endregion
    }
}
