using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels.Camara;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Camara
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VListaCamaras : ContentPage
    {
        public VListaCamaras()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new VMListaCamaras(Navigation);
        }
    }
}