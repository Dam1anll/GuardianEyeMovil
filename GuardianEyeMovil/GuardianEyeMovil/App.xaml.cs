using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GuardianEyeMovil.Views.Camara;
using GuardianEyeMovil.Views;

namespace GuardianEyeMovil
{
    public partial class App : Application
    {
        #pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        public static MasterDetailPage MasterDet { get; set; }
        #pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new VInicioSesion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
