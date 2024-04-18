using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GuardianEyeMovil.Views;
using GuardianEyeMovil.Views.MenuDesplegable;
using GuardianEyeMovil.Views.Registros;
using GuardianEyeMovil.Views.Trasmision;
using GuardianEyeMovil.Views.Perfil;
using GuardianEyeMovil.Views.Camara;

namespace GuardianEyeMovil.ViewModels
{
    public class VMMenuDesplegable : BaseViewModel
    {
        #region Variables
        #endregion
        #region Navigation
        public VMMenuDesplegable(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetos

        #endregion
        #region Procesos
        public async Task IrHome()
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VHome());

        }
        public async Task IrHistorial()
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VRegistros());
        }
        public async Task IrTransmicion()
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VTrasmisionCamara());
        }
        public async Task IrUsuario()
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VPerfil());
        }
        public async Task IrACamaras()
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VListaCamaras());
        }

        #pragma warning disable CS1998 
        public async Task Retroceder()
        #pragma warning restore CS1998 
        {
            App.MasterDet.IsPresented = false;

        }
        public async Task IrCerrarSesion()
        {
            await Navigation.PushAsync(new VInicioSesion());
        }

        #endregion
        #region Comandos
        public ICommand IrHomeCommand => new Command(async () => await IrHome());
        public ICommand IrHistorialCommand => new Command(async () => await IrHistorial());
        public ICommand IrTrasnmicionCommand => new Command(async () => await IrTransmicion());
        public ICommand IrAUsuarioCommand => new Command(async () => await IrUsuario());
        public ICommand IrACamarasCommand => new Command(async () => await IrACamaras());
        public ICommand RetrocederCommand => new Command(async () => await Retroceder());
        public ICommand IrCerrarSesionCommand => new Command(async () => await IrCerrarSesion());
        #endregion
    }
}
