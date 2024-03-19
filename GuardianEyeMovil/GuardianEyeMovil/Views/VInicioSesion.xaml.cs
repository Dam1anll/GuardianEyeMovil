using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VInicioSesion : ContentPage
    {
        public VInicioSesion()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new VMInicioSesion(Navigation);
        }
    }
}