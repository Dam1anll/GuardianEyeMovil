using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VPerfil : ContentPage
    {
        public VPerfil()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}