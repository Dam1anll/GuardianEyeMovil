using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GuardianEyeMovil.Views;

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
        public async Task IrAInicioSesion()
        {
            if (Correo != null && Contraseña != null)
            {
                await Navigation.PushAsync(new VInicioSesion());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresa los datos necesarios", "Ok");
            }
        }
        #endregion
        #region COMANDOS
        public ICommand IrAInicioSesionCommand => new Command(async () => await IrAInicioSesion());
        #endregion
    }
}
