using GuardianEyeMovil.Models;
using GuardianEyeMovil.ViewModels.Camara;
using GuardianEyeMovil.Views.Registros;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace GuardianEyeMovil.ViewModels.Registros
{
    public class VMNotificacion : BaseViewModel
    {
        #region VARIABLES
        private string _id;
        private DateTime _fecha;
        private string _mensaje;
        private string _imagen = null;
        private string _tipo;
        private string _video = null;
        private string _titulo; 

        public MNotificacion _MNotificacion { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMNotificacion(INavigation navigation, MNotificacion mNotificacion)
        {
            Navigation = navigation;
            _MNotificacion = mNotificacion;
            CargarDatosNotificacion(mNotificacion);
        }
        #endregion
        #region OBJETOS
        public string Id
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { SetValue(ref _fecha, value); }
        }
        public string Mensaje
        {
            get { return _mensaje; }
            set { SetValue(ref _mensaje, value); }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { SetValue(ref _tipo, value); }
        }
        public string Video
        {
            get { return _video; }
            set { SetValue(ref _video, value); }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        #endregion
        #region PROCESOS
        private void CargarDatosNotificacion(MNotificacion mNotificacion)
        {
            Id = mNotificacion.Id;
            Fecha = mNotificacion.Fecha;
            Mensaje = mNotificacion.Mensaje;
            Imagen = mNotificacion.Imagen;
            Tipo = mNotificacion.Tipo;
            Video = mNotificacion.Video;
            Titulo = mNotificacion.Titulo;
        }
        #endregion
        #region COMANDOS
        #endregion
    }
}
